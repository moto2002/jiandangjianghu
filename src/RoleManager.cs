using Aoi;
using Config;
using LuaFramework;
using LuaInterface;
using System;
using System.Collections.Generic;
using ThirdParty;
using UnityEngine;

public class RoleManager : Singleton<RoleManager>
{
	public enum SceneType
	{
		SceneType_Zhucheng = 1,
		SceneType_ClientFuben,
		SceneType_ServerFuben,
		SceneType_WorldBoss,
		SceneType_Jingjichange
	}

	public enum EntityType
	{
		EntityType_None,
		EntityType_Self,
		EntityType_Role,
		EntityType_Npc,
		EntityType_Monster,
		EntityType_Lingqi,
		EntityType_Partner,
		EntityType_Aider,
		EntityType_Pet,
		EntityType_Beauty,
		EntityType_XunLuo
	}

	public enum GameMode
	{
		Plot = 1,
		Waiting,
		PlotCheck,
		Game,
		Guide
	}

	private bool isBlocked;

	public bool canMainRoleMove = true;

	public bool createNpcNeedAni;

	public bool clientServer;

	public Camera mainCamera;

	public AudioSource audioSource;

	public RoleManager.GameMode mode;

	private float[] speeds = new float[]
	{
		1f,
		1.09f,
		1.18f
	};

	private GameObject mainSceneGo;

	public int sceneType
	{
		get;
		set;
	}

	public static ObservableDictionary<string, SceneEntity> sceneEntities
	{
		get;
		private set;
	}

	public static Dictionary<string, SceneEntity> partnerAndLingQiEntities
	{
		get;
		private set;
	}

	public static List<SceneEntity> xunLuoEntities
	{
		get;
		private set;
	}

	public static List<SceneEntity> roles
	{
		get;
		private set;
	}

	public static List<SceneEntity> roleParts
	{
		get;
		private set;
	}

	public static List<SceneEntity> monsters
	{
		get;
		private set;
	}

	public static List<SceneEntity> npcs
	{
		get;
		private set;
	}

	public static List<GameObject> jumpGates
	{
		get;
		private set;
	}

	public SceneEntity mainRole
	{
		get
		{
			return this.entityCreate._mainRole;
		}
	}

	public int curSceneNo
	{
		get;
		set;
	}

	public int curSceneId
	{
		get;
		set;
	}

	public float cameraOffsetY
	{
		get;
		set;
	}

	public float cameraDistance
	{
		get;
		set;
	}

	public float maxClimbHeight
	{
		get;
		set;
	}

	public AsyncOperation ao
	{
		get;
		set;
	}

	public AssetBundle sceneAsset
	{
		get;
		set;
	}

	public PositionSync positionSync
	{
		get
		{
			return this.entityCreate.positionSync;
		}
	}

	public bool newAoiMoveType
	{
		get;
		set;
	}

	public EntityCreate entityCreate
	{
		get;
		private set;
	}

	public CameraFollow cf
	{
		get
		{
			return this.entityCreate.cf;
		}
	}

	public bool loadingFinished
	{
		get;
		private set;
	}

	public int playerShowCount
	{
		get;
		private set;
	}

	static RoleManager()
	{
		RoleManager.sceneEntities = new ObservableDictionary<string, SceneEntity>();
		RoleManager.partnerAndLingQiEntities = new Dictionary<string, SceneEntity>();
		RoleManager.roles = new List<SceneEntity>();
		RoleManager.roleParts = new List<SceneEntity>();
		RoleManager.monsters = new List<SceneEntity>();
		RoleManager.npcs = new List<SceneEntity>();
		RoleManager.jumpGates = new List<GameObject>();
		RoleManager.sceneEntities.ItemAdd += new EventHandler<EventArgs<KeyValuePair<string, SceneEntity>>>(RoleManager.OnAddSceneEntity);
		RoleManager.sceneEntities.ItemRemove += new EventHandler<EventArgs<KeyValuePair<string, SceneEntity>>>(RoleManager.OnRemoveSceneEntity);
		RoleManager.xunLuoEntities = new List<SceneEntity>();
	}

	public void SetTimeScale(int level)
	{
		if (level < this.speeds.Length && level >= 0)
		{
			Time.timeScale = this.speeds[level];
		}
		else
		{
			Debug.Log("Invalid time scale level!");
		}
	}

	public static RoleManager GetInstance()
	{
		return Singleton<RoleManager>.Instance;
	}

	private void Awake()
	{
		this.mode = RoleManager.GameMode.Game;
		this.entityCreate = base.transform.GetOrAddComponent<EntityCreate>();
	}

	public void AddPlayer(S2c_aoi_addplayer cmd)
	{
		this.entityCreate.AddPlayer(cmd);
	}

	public void AddHero(S2c_aoi_addself cmd)
	{
		if (!PreLoadingScene.inPreloading)
		{
			this.entityCreate.AddHero(cmd);
			this.curSceneNo = cmd.nmsg.map_no;
			this.curSceneId = cmd.nmsg.map_id;
			Util.CallMethod("Game", "LoadSceneViaPreloading", new object[]
			{
				cmd.nmsg.map_no
			});
		}
	}

	public void AddNpc(S2c_aoi_addnpc cmd)
	{
		this.entityCreate.AddNpc(cmd);
	}

	public void AddAider(string model, string posStr, int dir)
	{
		this.entityCreate.AddAider(model, posStr, dir);
	}

	public void SyncTargetPosition(string id, int x, float y, int z, float speed, int type)
	{
		if (this.mainRole != null && id == this.mainRole.id)
		{
			return;
		}
		SceneEntity sceneEntity = RoleManager.sceneEntities[id];
		if (sceneEntity == null)
		{
			return;
		}
		sceneEntity.move.SetServerPos(Util.Convert2RealPosition(x, y, z), speed, type, 0, 0.1f, false, null);
	}

	public void CorrectTargetPosition(int x, float y, int z)
	{
		if (this.mainRole == null)
		{
			return;
		}
		this.mainRole.move.StopPath();
		this.mainRole.move.SetServerPos(Util.Convert2RealPosition(x, y, z), 0f, 0, 0, 0.1f, true, null);
	}

	public void DeleteObjectsById(string id, bool deleteSelf = true)
	{
		if (this.entityCreate.DeleteObjectsById(id))
		{
			return;
		}
		if (!RoleManager.sceneEntities.ContainsKey(id))
		{
			return;
		}
		if (!deleteSelf && id == Singleton<RoleManager>.Instance.mainRole.id)
		{
			return;
		}
		SceneEntity sceneEntity = RoleManager.sceneEntities[id];
		RoleManager.sceneEntities.Remove(id);
		if (sceneEntity != null)
		{
			if (sceneEntity.lingqiObj != null && sceneEntity.lingqiObj.gameObject != null)
			{
				RoleManager.partnerAndLingQiEntities.Remove(sceneEntity.lingqiObj.id);
				sceneEntity.lingqiObj.Recycle();
				sceneEntity.lingqiObj = null;
			}
			if (sceneEntity.partnerObj != null && sceneEntity.partnerObj.gameObject != null)
			{
				RoleManager.partnerAndLingQiEntities.Remove(sceneEntity.partnerObj.id);
				sceneEntity.partnerObj.Recycle();
				sceneEntity.partnerObj = null;
			}
			if (sceneEntity.petObj != null && sceneEntity.petObj.gameObject != null)
			{
				RoleManager.partnerAndLingQiEntities.Remove(sceneEntity.petObj.id);
				sceneEntity.petObj.Recycle();
				sceneEntity.petObj = null;
			}
			if (sceneEntity.beautyObj != null && sceneEntity.beautyObj.gameObject != null)
			{
				RoleManager.partnerAndLingQiEntities.Remove(sceneEntity.beautyObj.id);
				sceneEntity.beautyObj.Recycle();
				sceneEntity.beautyObj = null;
			}
			if (sceneEntity.gameObject != null)
			{
				sceneEntity.Recycle();
			}
			HusongFollow component = this.mainRole.transform.GetComponent<HusongFollow>();
			if (component != null && component.targetId == id)
			{
				component.targetEntity = null;
			}
		}
		if (this.positionSync != null)
		{
			this.positionSync.DeleteObjectPosition(id);
		}
	}

	public void Clear()
	{
		if (this.positionSync != null)
		{
			this.positionSync.Clear();
		}
		RoleManager.xunLuoEntities.Clear();
		Singleton<AreaPathfinding>.Instance.Clear();
		for (int i = 0; i < RoleManager.jumpGates.Count; i++)
		{
			UnityEngine.Object.DestroyImmediate(RoleManager.jumpGates[i]);
		}
		AppFacade.Instance.GetManager<SoundManager>("SoundManager").Clear();
		RoleManager.sceneEntities.Clear();
		RoleManager.jumpGates.Clear();
		RoleManager.partnerAndLingQiEntities.Clear();
		this.loadingFinished = false;
		this.playerShowCount = 0;
		this.entityCreate.Clear();
		this.mainSceneGo = null;
		Util.CallMethod("Game", "ChangeSceneClear", new object[0]);
	}

	public void CreateJumpGate(LuaTable table)
	{
		if (table != null)
		{
			for (int i = 1; i <= table.Length; i++)
			{
				LuaTable luaTable = (LuaTable)table[i];
				int num = Convert.ToInt32(luaTable["StartMap"]);
				int endMap = Convert.ToInt32(luaTable["EndMap"]);
				int num2 = Convert.ToInt32(luaTable["ShapeNo"]);
				LuaTable luaTable2 = (LuaTable)luaTable["ConveyPos"];
				int x = Convert.ToInt32(luaTable2[1]);
				float num3 = Convert.ToSingle(luaTable2[3]);
				int z = Convert.ToInt32(luaTable2[2]);
				if (num2 == 1 && !Singleton<WorldPathfinding>.Instance.init)
				{
					Singleton<WorldPathfinding>.Instance.AddWorldPathfindingInfo(num, endMap, x, z, num3);
				}
				if (num == this.curSceneNo)
				{
					GameObject gameObject = ObjectPool.instance.PushToPool(string.Format("Prefab/SceneObj/JumpGate{0}", num2), 3, null);
					gameObject.transform.position = Util.Convert2RealPosition(x, num3, z);
					JumpGate component = gameObject.GetComponent<JumpGate>();
					component.doorNo = Convert.ToInt32(luaTable["No"]);
					component.startMap = num;
					component.endMap = endMap;
					component.type = num2;
					component.startArea = Convert.ToInt32(luaTable["StartArea"]);
					component.endArea = Convert.ToInt32(luaTable["EndArea"]);
					LuaTable luaTable3 = (LuaTable)luaTable["EndPos"];
					component.endPosition = Util.Convert2RealPosition(Convert.ToInt32(luaTable3[1]), (float)Convert.ToInt32(luaTable3[3]), Convert.ToInt32(luaTable3[2]));
					LuaTable luaTable4 = (LuaTable)luaTable["Rotation"];
					component.particleRotation = new Vector3(Convert.ToSingle(luaTable4[1]), Convert.ToSingle(luaTable4[2]), Convert.ToSingle(luaTable4[3]));
					if (num2 == 1)
					{
						this.AddJumpGateTitle(component, Convert.ToString(luaTable["EndName"]));
					}
					RoleManager.jumpGates.Add(gameObject);
					Singleton<AreaPathfinding>.Instance.AddGateInfo(component);
				}
			}
			Singleton<WorldPathfinding>.Instance.init = true;
		}
		else
		{
			Debug.LogError("no jumpgate data: " + this.curSceneNo);
		}
	}

	public void CreateFakeJumpGate(LuaTable table)
	{
		if (table != null)
		{
			for (int i = 1; i <= table.Length; i++)
			{
				LuaTable luaTable = (LuaTable)table[i];
				int num = Convert.ToInt32(luaTable["StartMap"]);
				int endMap = Convert.ToInt32(luaTable["EndMap"]);
				int num2 = Convert.ToInt32(luaTable["ShapeNo"]);
				LuaTable luaTable2 = (LuaTable)luaTable["ConveyPos"];
				int x = Convert.ToInt32(luaTable2[1]);
				float num3 = Convert.ToSingle(luaTable2[3]);
				int z = Convert.ToInt32(luaTable2[2]);
				Singleton<WorldPathfinding>.Instance.AddWorldPathfindingInfo(num, endMap, x, z, num3);
				if (num == this.curSceneNo)
				{
					GameObject gameObject = ObjectPool.instance.PushToPool(string.Format("Prefab/SceneObj/FakeJumpGate", new object[0]), 3, null);
					gameObject.transform.position = Util.Convert2RealPosition(x, num3, z);
					FakeJumpGate component = gameObject.GetComponent<FakeJumpGate>();
					component.doorNo = Convert.ToInt32(luaTable["No"]);
					component.startMap = num;
					component.endMap = Convert.ToInt32(luaTable["EndMap"]);
					component.startArea = Convert.ToInt32(luaTable["StartArea"]);
					component.endArea = Convert.ToInt32(luaTable["EndArea"]);
					component.extend = luaTable["Extend"].ToString();
					LuaTable luaTable3 = (LuaTable)luaTable["ConveyPos"];
					component.endPosition = Util.Convert2RealPosition(Convert.ToInt32(luaTable3[1]), (float)Convert.ToInt32(luaTable3[3]), Convert.ToInt32(luaTable3[2]));
					LuaTable luaTable4 = (LuaTable)luaTable["Rotation"];
					component.particleRotation = new Vector3(Convert.ToSingle(luaTable4[1]), Convert.ToSingle(luaTable4[2]), Convert.ToSingle(luaTable4[3]));
					this.AddJumpGateTitle(component, Convert.ToString(luaTable["EndName"]));
					RoleManager.jumpGates.Add(gameObject);
					Singleton<AreaPathfinding>.Instance.AddGateInfo(component);
				}
			}
		}
		else
		{
			Debug.LogError("no fakejumpgate data: " + this.curSceneNo);
		}
		Singleton<WorldPathfinding>.Instance.CheckWorldPathfinding();
	}

	public void AddJumpGateTitle(JumpGate gate, string name)
	{
		GameObject gameObject = GameObject.FindWithTag("GuiCamera");
		Transform transform = gameObject.transform.FindChild("jumpgatepanel");
		if (transform == null)
		{
			GameObject gameObject2 = new GameObject("jumpgatepanel");
			gameObject2.transform.SetParent(gameObject.transform);
			gameObject2.transform.localPosition = Vector3.zero;
			gameObject2.transform.localScale = Vector3.one;
			gameObject2.layer = LayerMask.NameToLayer("UI");
			transform = gameObject2.transform;
			UIPanel uIPanel = gameObject2.AddComponent<UIPanel>();
			uIPanel.depth = -1;
			uIPanel.renderQueue = UIPanel.RenderQueue.StartAt;
		}
		string prefabPath = "Prefab/Gui/JumpGateTitle";
		GameObject gameObject3 = ObjectPool.instance.PushToPool(prefabPath, 5, transform);
		gameObject3.transform.localScale = Vector3.one;
		gate.title = gameObject3.GetComponent<JumpGateTitle>();
		gate.title.point = gate.transform;
		gate.title.nameLab.text = name;
	}

	public void CreateXunLuoNpcs(LuaTable table)
	{
		this.entityCreate.CreateXunLuoNpcs(table);
	}

	public void FirstBlockOtherPlayers(bool show)
	{
		this.isBlocked = show;
	}

	private static void OnAddSceneEntity(object sender, EventArgs<KeyValuePair<string, SceneEntity>> args)
	{
		switch (args.Data.Value.entityType)
		{
		case RoleManager.EntityType.EntityType_Self:
		case RoleManager.EntityType.EntityType_Role:
			RoleManager.roles.Add(args.Data.Value);
			if (args.Data.Value.entityType == RoleManager.EntityType.EntityType_Role)
			{
				int num = (int)(User_Config.playerScreenCount * 30f);
				if (Singleton<RoleManager>.Instance.playerShowCount >= num)
				{
					RoleManager.roles[RoleManager.roles.Count - 1].ShowHideEntityModel(false);
				}
				else
				{
					Singleton<RoleManager>.Instance.playerShowCount = RoleManager.roles.Count - 1;
				}
			}
			break;
		case RoleManager.EntityType.EntityType_Npc:
			RoleManager.npcs.Add(args.Data.Value);
			break;
		case RoleManager.EntityType.EntityType_Monster:
			RoleManager.monsters.Add(args.Data.Value);
			break;
		case RoleManager.EntityType.EntityType_Lingqi:
		case RoleManager.EntityType.EntityType_Partner:
		case RoleManager.EntityType.EntityType_Pet:
			RoleManager.roleParts.Add(args.Data.Value);
			break;
		}
	}

	private static void OnRemoveSceneEntity(object sender, EventArgs<KeyValuePair<string, SceneEntity>> args)
	{
		switch (args.Data.Value.entityType)
		{
		case RoleManager.EntityType.EntityType_Self:
		case RoleManager.EntityType.EntityType_Role:
		{
			RoleManager.roles.Remove(args.Data.Value);
			int num = (int)(User_Config.playerScreenCount * 30f);
			if (RoleManager.roles.Count - 1 == num)
			{
				for (int i = 1; i < RoleManager.roles.Count; i++)
				{
					RoleManager.roles[i].ShowHideEntityModel(true);
				}
				Singleton<RoleManager>.Instance.playerShowCount = RoleManager.roles.Count - 1;
			}
			break;
		}
		case RoleManager.EntityType.EntityType_Npc:
			RoleManager.npcs.Remove(args.Data.Value);
			break;
		case RoleManager.EntityType.EntityType_Monster:
			RoleManager.monsters.Remove(args.Data.Value);
			break;
		case RoleManager.EntityType.EntityType_Lingqi:
		case RoleManager.EntityType.EntityType_Partner:
		case RoleManager.EntityType.EntityType_Pet:
			RoleManager.roleParts.Remove(args.Data.Value);
			break;
		}
	}

	public void CreateLingqi(SceneEntity obj, string magic)
	{
		this.entityCreate.CreateLingqi(obj, magic);
	}

	public void CreatePartner(SceneEntity obj, string partner)
	{
		this.entityCreate.CreatePartner(obj, partner);
	}

	public void CreatePet(SceneEntity obj, int pet)
	{
		this.entityCreate.CreatePet(obj, pet);
	}

	private void Update()
	{
		if (this.ao != null && this.ao.isDone && this.curSceneNo != 0)
		{
			this.AfterLoading();
			this.ao = null;
		}
	}

	public void BackToScene()
	{
		if (!this.loadingFinished)
		{
			this.AfterLoading();
		}
		this.mode = RoleManager.GameMode.PlotCheck;
	}

	private void LoadResources()
	{
	}

	public void AfterLoading()
	{
		this.LoadResources();
		if (this.mainSceneGo == null)
		{
			this.mainSceneGo = new GameObject("MainScene");
			this.mainSceneGo.AddComponent<MainScene>();
		}
		this.mainCamera = Camera.main;
		this.createNpcNeedAni = false;
		Singleton<AreaPathfinding>.Instance.CreateAreaInfo();
		Util.CallMethod("Game", "OnLevelLoaded", new object[0]);
		this.loadingFinished = true;
		if (this.sceneType == 2)
		{
		}
	}

	public void JumpSceneByEnterJumpgate(int targetMapNo)
	{
	}

	public void SetObjectHpById(string id, int nhp, int hpmax)
	{
		for (int i = 0; i < this.entityCreate._players.Count; i++)
		{
			if (this.entityCreate._players[i].nmsg.rid == id)
			{
				this.entityCreate._players[i].nmsg.hp = nhp;
				this.entityCreate._players[i].nmsg.hpmax = hpmax;
			}
		}
		for (int j = 0; j < this.entityCreate._npcs.Count; j++)
		{
			if (this.entityCreate._npcs[j].nmsg.rid == id)
			{
				this.entityCreate._npcs[j].nmsg.hp = nhp;
				this.entityCreate._npcs[j].nmsg.hpmax = hpmax;
			}
		}
	}

	public void UpdateUninitPlayerInfo(S2c_aoi_syncplayer playerInfo)
	{
		if (this.entityCreate._heroInfo != null && this.entityCreate._heroInfo.sync.rid == playerInfo.rid)
		{
			this.entityCreate._heroInfo.sync = playerInfo;
			return;
		}
		for (int i = 0; i < this.entityCreate._players.Count; i++)
		{
			if (this.entityCreate._players[i].sync.rid == playerInfo.rid)
			{
				this.entityCreate._players[i].sync = playerInfo;
				break;
			}
		}
	}

	public void UpdateUninitNpcInfo(S2c_aoi_syncnpc npcInfo)
	{
		for (int i = 0; i < this.entityCreate._players.Count; i++)
		{
			if (this.entityCreate._npcs[i].sync.rid == npcInfo.rid)
			{
				this.entityCreate._npcs[i].sync = npcInfo;
				break;
			}
		}
	}

	public void UpdateUninitSceneObjRepeatInt(string rid, string key, LuaTable tblInfo)
	{
		if (this.entityCreate._heroInfo != null && this.entityCreate._heroInfo.sync.rid == rid)
		{
			if (key.Equals("buff"))
			{
				this.entityCreate._heroInfo.sync.buff = tblInfo;
			}
			return;
		}
		int count = this.entityCreate._players.Count;
		int num = 0;
		if (num < count)
		{
			if (this.entityCreate._players[num].sync.rid == rid)
			{
				this.entityCreate._players[num].sync.buff = tblInfo;
			}
		}
		count = this.entityCreate._npcs.Count;
		int num2 = 0;
		if (num2 < count)
		{
			if (this.entityCreate._npcs[num2].sync.rid == rid)
			{
				this.entityCreate._npcs[num2].sync.buff = tblInfo;
			}
		}
	}

	public void UpdateUninitSceneObjString(string rid, string key, string value)
	{
		if (this.entityCreate._heroInfo != null && this.entityCreate._heroInfo.sync.rid == rid)
		{
			if (key.Equals("pkinfo"))
			{
				this.entityCreate._heroInfo.sync.pkinfo = value;
			}
			return;
		}
		int count = this.entityCreate._players.Count;
		int num = 0;
		if (num < count)
		{
			if (this.entityCreate._players[num].sync.rid == rid && key.Equals("pkinfo"))
			{
				this.entityCreate._players[num].sync.pkinfo = value;
			}
		}
		count = this.entityCreate._npcs.Count;
		int num2 = 0;
		if (num2 >= count)
		{
		}
	}

	public void UpdateUninitSceneObjInt(string rid, string key, int value)
	{
		if (this.entityCreate._heroInfo != null && this.entityCreate._heroInfo.sync.rid == rid)
		{
			if (key.Equals("score"))
			{
				this.entityCreate._heroInfo.sync.score = value;
			}
			else if (key.Equals("speed"))
			{
				this.entityCreate._heroInfo.sync.speed = (float)value;
			}
			return;
		}
		int count = this.entityCreate._players.Count;
		int num = 0;
		if (num < count)
		{
			if (this.entityCreate._players[num].sync.rid == rid)
			{
				if (key.Equals("score"))
				{
					this.entityCreate._players[num].sync.score = value;
				}
				else if (key.Equals("speed"))
				{
					this.entityCreate._players[num].sync.speed = (float)value;
				}
			}
		}
	}

	public S2c_aoi_addself GetHeroInfo()
	{
		return this.entityCreate._heroInfo;
	}

	public SceneEntity GetMonsterById(string id)
	{
		SceneEntity result = null;
		for (int i = 0; i < RoleManager.monsters.Count; i++)
		{
			if (RoleManager.monsters[i].id == id)
			{
				result = RoleManager.monsters[i];
			}
		}
		return result;
	}

	public SceneEntity GetSceneEntityById(string id, int type = 0)
	{
		if (this.entityCreate._heroInfo != null && this.entityCreate._heroInfo.sync.rid == id)
		{
			return null;
		}
		if (type == 0 && RoleManager.sceneEntities.ContainsKey(id))
		{
			return RoleManager.sceneEntities[id];
		}
		if ((type == 1 || type == 2) && RoleManager.partnerAndLingQiEntities.ContainsKey(id))
		{
			return RoleManager.partnerAndLingQiEntities[id];
		}
		return null;
	}

	public SceneEntity GetXunLuoNpc(int npcNo)
	{
		for (int i = 0; i < RoleManager.xunLuoEntities.Count; i++)
		{
			if (npcNo == RoleManager.xunLuoEntities[i].char_id)
			{
				return RoleManager.xunLuoEntities[i];
			}
		}
		return null;
	}

	public void SetMainRoleTarget(SceneEntity target)
	{
		if (this.mainRole == null)
		{
			return;
		}
		this.mainRole.selectTarget.OnSelected(target);
		if (target == null && this.mainRole.runToTarget.targetType == RunToTarget.TargetType.Type_GameObject)
		{
			this.mainRole.runToTarget.clear();
		}
	}

	public void SyncPlayerDash(string rid, float x, float y, float z)
	{
		SceneEntity sceneEntity;
		if (RoleManager.sceneEntities.TryGetValue(rid, out sceneEntity))
		{
			sceneEntity.move.SetServerPos(new Vector3(x, y, z), 0f, 1, 1, 1.3f, false, null);
		}
	}

	public void UpdateBlockSetting()
	{
		for (int i = 0; i < RoleManager.roles.Count; i++)
		{
			RoleManager.roles[i].UpdateBlockSetting(false);
		}
		for (int j = 0; j < RoleManager.roleParts.Count; j++)
		{
			RoleManager.roleParts[j].UpdateBlockSetting(false);
		}
		foreach (SceneEntity current in RoleManager.partnerAndLingQiEntities.Values)
		{
			current.UpdateBlockSetting(false);
		}
		int num = (int)(User_Config.playerScreenCount * 30f);
		if (this.playerShowCount > num)
		{
			for (int k = RoleManager.roles.Count - 1; k >= num; k--)
			{
				RoleManager.roles[k].ShowHideEntityModel(false);
			}
			this.playerShowCount = Math.Min(RoleManager.roles.Count - 1, num);
		}
		else if (this.playerShowCount < num)
		{
			for (int l = 1; l <= num; l++)
			{
				if (l >= RoleManager.roles.Count)
				{
					break;
				}
				RoleManager.roles[l].ShowHideEntityModel(true);
			}
			this.playerShowCount = Math.Min(RoleManager.roles.Count - 1, num);
		}
		for (int m = 0; m < RoleManager.monsters.Count; m++)
		{
			RoleManager.monsters[m].UpdateBlockSetting(false);
		}
	}

	public void UpdateAllTitleBlood()
	{
		for (int i = 0; i < RoleManager.roles.Count; i++)
		{
			if (RoleManager.roles[i] != null)
			{
				RoleManager.roles[i].title.UpdateMood();
			}
		}
	}
}
