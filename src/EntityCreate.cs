using Aoi;
using Config;
using LuaFramework;
using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ThirdParty;
using UnityEngine;
using Xft;

public class EntityCreate : MonoBehaviour
{
	private class EntityCreateEvent
	{
		public EntityCreate.OnRoleCreated roleEvent
		{
			get;
			private set;
		}

		public EntityCreate.OnNpcCreated npcEvent
		{
			get;
			private set;
		}

		public EntityCreateEvent(EntityCreate.OnRoleCreated roleEvent, EntityCreate.OnNpcCreated npcEvent)
		{
			this.roleEvent = roleEvent;
			this.npcEvent = npcEvent;
		}
	}

	public delegate void OnRoleCreated(SceneEntity entity, S2c_aoi_syncplayer sync);

	public delegate void OnNpcCreated(SceneEntity entity, S2c_aoi_syncnpc sync);

	private bool beginAddPlayer;

	private bool beginAddNpc;

	private Dictionary<string, EntityCreate.EntityCreateEvent> entityCreateEvents = new Dictionary<string, EntityCreate.EntityCreateEvent>();

	public SceneEntity _mainRole
	{
		get;
		private set;
	}

	public List<string> _needDeleteNpcs
	{
		get;
		private set;
	}

	public List<S2c_aoi_addplayer> _players
	{
		get;
		private set;
	}

	public List<S2c_aoi_addnpc> _npcs
	{
		get;
		private set;
	}

	public S2c_aoi_addself _heroInfo
	{
		get;
		private set;
	}

	public string[] _aiderInfo
	{
		get;
		private set;
	}

	public bool isInAsynceLoad
	{
		get;
		private set;
	}

	public bool hidePlayer
	{
		get;
		set;
	}

	public PositionSync positionSync
	{
		get;
		set;
	}

	public CameraFollow cf
	{
		get;
		private set;
	}

	private EntityCreate()
	{
		this._players = new List<S2c_aoi_addplayer>();
		this._npcs = new List<S2c_aoi_addnpc>();
		this._needDeleteNpcs = new List<string>();
	}

	private void Start()
	{
		this.positionSync = base.transform.GetOrAddComponent<PositionSync>();
		this.isInAsynceLoad = false;
	}

	private string EntityTypeToString(RoleManager.EntityType type)
	{
		switch (type)
		{
		case RoleManager.EntityType.EntityType_Self:
			return "Self";
		case RoleManager.EntityType.EntityType_Role:
			return "Player";
		case RoleManager.EntityType.EntityType_Npc:
		case RoleManager.EntityType.EntityType_Lingqi:
		case RoleManager.EntityType.EntityType_Partner:
		case RoleManager.EntityType.EntityType_Aider:
		case RoleManager.EntityType.EntityType_Pet:
		case RoleManager.EntityType.EntityType_Beauty:
		case RoleManager.EntityType.EntityType_XunLuo:
			return "Npc";
		case RoleManager.EntityType.EntityType_Monster:
			return "Monster";
		default:
			return string.Empty;
		}
	}

	private string GetEntityName(RoleManager.EntityType type, string id)
	{
		return string.Format("{0}_{1}", this.EntityTypeToString(type), id);
	}

	private GameObject _loadEntityRes(RoleManager.EntityType type, string id)
	{
		GameObject gameObject = null;
		switch (type)
		{
		case RoleManager.EntityType.EntityType_Self:
		{
			GameObject original = Util.LoadPrefab("Prefab/SceneObj/MainRole");
			gameObject = UnityEngine.Object.Instantiate<GameObject>(original);
			break;
		}
		case RoleManager.EntityType.EntityType_Role:
			gameObject = ObjectPool.instance.PushToPool("Prefab/SceneObj/Role", 15, null);
			break;
		case RoleManager.EntityType.EntityType_Npc:
		case RoleManager.EntityType.EntityType_XunLuo:
			gameObject = ObjectPool.instance.PushToPool("Prefab/SceneObj/Npc", 15, null);
			break;
		case RoleManager.EntityType.EntityType_Monster:
			gameObject = ObjectPool.instance.PushToPool("Prefab/SceneObj/Monster", 15, null);
			break;
		case RoleManager.EntityType.EntityType_Lingqi:
			gameObject = ObjectPool.instance.PushToPool("Prefab/SceneObj/LingQi", 15, null);
			break;
		case RoleManager.EntityType.EntityType_Partner:
			gameObject = ObjectPool.instance.PushToPool("Prefab/SceneObj/Partner", 15, null);
			break;
		case RoleManager.EntityType.EntityType_Aider:
			gameObject = ObjectPool.instance.PushToPool("Prefab/SceneObj/LingQi", 15, null);
			break;
		case RoleManager.EntityType.EntityType_Pet:
			gameObject = ObjectPool.instance.PushToPool("Prefab/SceneObj/Pet", 15, null);
			break;
		case RoleManager.EntityType.EntityType_Beauty:
			gameObject = ObjectPool.instance.PushToPool("Prefab/SceneObj/Beauty", 15, null);
			break;
		}
		gameObject.name = this.GetEntityName(type, id);
		return gameObject;
	}

	public GameObject InitilizeSelfEntity(Aoi_add_normalmsg nmsg, S2c_aoi_syncplayer sync, string name)
	{
		GameObject gameObject = this._loadEntityRes(RoleManager.EntityType.EntityType_Self, nmsg.char_no.ToString());
		SceneEntity component = gameObject.GetComponent<SceneEntity>();
		if (component == null)
		{
			Debug.LogError("Initilize entity error! Type: " + RoleManager.EntityType.EntityType_Self);
			return null;
		}
		object[] array = Util.CallMethod("PLAYERLOADER", "LoadMainRole", new object[]
		{
			component
		});
		component.SetKeyValue("clubname", sync.clubname);
		component.SetKeyValue("clubpost", sync.clubpost);
		if (array == null || array.Length == 0)
		{
			Debug.LogError("获取主角模型资源路径错误");
			return null;
		}
		GameObject gameObject2 = (GameObject)array[0];
		if (gameObject2 == null)
		{
			Debug.LogError(string.Concat(new object[]
			{
				"加载角色模型错误![id]",
				nmsg.char_no,
				" [type]",
				RoleManager.EntityType.EntityType_Self
			}));
		}
		Vector3 pos = Util.Convert2RealPosition(nmsg.x, nmsg.y, nmsg.z);
		this.SetEntityInfo(gameObject, gameObject2, pos, sync.dir360, sync.speed, component, name, sync.grade, string.Empty, sync.comp, nmsg.hpmax, nmsg.hp, false, RoleManager.EntityType.EntityType_Self, sync.pkinfo);
		Util.CallMethod("PLAYERLOADER", "LoadOtherShape", new object[]
		{
			component,
			1,
			component.weapon,
			sync.shenyi_model
		});
		if (sync.up_mount == 1)
		{
			component.isRide = true;
		}
		if (component.weapon_model != null)
		{
			component.ChangeShader(component.weapon_model);
		}
		if (component.shenyi_model != null)
		{
			component.ChangeShader(component.shenyi_model);
		}
		return gameObject;
	}

	private void AsyncInitilizeEntity(Aoi_add_normalmsg nmsg, S2c_aoi_syncplayer syncPlayer, S2c_aoi_syncnpc syncNpc, string name, string ownerId, RoleManager.EntityType entityType, Action<GameObject> callback = null)
	{
		GameObject go = this._loadEntityRes(entityType, nmsg.rid);
		SceneEntity obj = null;
		if (go)
		{
			obj = go.GetComponent<SceneEntity>();
			Util.CallMethod("PLAYERLOADER", "SetXlsInfo", new object[]
			{
				obj,
				(int)entityType,
				nmsg.char_no,
				(syncPlayer == null) ? 0 : syncPlayer.isyunbiao
			});
			if (syncPlayer != null)
			{
				obj.SetData(nmsg.rid, nmsg.char_no, syncPlayer.sex, syncPlayer.speed, syncPlayer.weapon, syncPlayer.mount_model, syncPlayer.partnerhorse_model, syncPlayer.lingqin_model, syncPlayer.lingyi_model, syncPlayer.pet_model, syncPlayer.shenjian_model, syncPlayer.shenyi_model, syncPlayer.jingmai_model, syncPlayer.score, syncPlayer.up_mount, syncPlayer.up_horse, syncPlayer.fashion, syncPlayer.dazuo, 0, 0, syncPlayer.isyunbiao);
				obj.SetKeyValue("clubname", syncPlayer.clubname);
				obj.SetKeyValue("clubpost", syncPlayer.clubpost);
			}
			else
			{
				obj.SetData(nmsg.rid, nmsg.char_no, 0, 0f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, syncNpc.shield_hp, syncNpc.shield_hpmax, 0);
			}
			int shape = (syncPlayer == null) ? syncNpc.shape : syncPlayer.shape;
			if (syncPlayer != null && syncPlayer.fashion > 0)
			{
				shape = syncPlayer.fashion;
			}
			int grade = (syncPlayer == null) ? syncNpc.grade : syncPlayer.grade;
			int comp = (syncPlayer == null) ? syncNpc.comp : syncPlayer.comp;
			bool canAttack = syncPlayer != null || syncNpc.canattk == 1;
			string pkMode = (syncPlayer == null) ? string.Empty : syncPlayer.pkinfo;
			this.AsyncLoadCharacter(go.transform, shape, entityType, obj, delegate(GameObject model, string prefabPath)
			{
				if (model == null)
				{
					model = Util.LoadBucket(go.transform);
					obj.isBucket = true;
				}
				model.transform.localScale = Vector3.one;
				Vector3 pos = Util.Convert2RealPosition(nmsg.x, nmsg.y, nmsg.z);
				this.SetEntityInfo(go, model, pos, (syncPlayer == null) ? syncNpc.dir : syncPlayer.dir360, (syncPlayer == null) ? 0f : syncPlayer.speed, obj, name, grade, ownerId, comp, nmsg.hpmax, nmsg.hp, canAttack, entityType, pkMode);
				if (callback != null)
				{
					callback(go);
				}
				if (syncPlayer != null)
				{
					Util.CallMethod("PLAYERLOADER", "LoadOtherShape", new object[]
					{
						obj,
						(int)entityType,
						syncPlayer.shenjian_model,
						syncPlayer.shenyi_model
					});
					if (obj.up_mount == 1)
					{
						obj.isRide = true;
					}
				}
			});
			return;
		}
	}

	private void SetEntityInfo(GameObject go, GameObject model, Vector3 pos, int dir360, float speed, SceneEntity obj, string name, int grade, string ownerId, int comp, int maxhp, int hp, bool canAttack, RoleManager.EntityType entityType, string pkMode = "")
	{
		go.transform.position = pos;
		obj.ChangeDir(dir360);
		this.SetEntityBaseInfo(obj, model, name, speed, grade, comp, maxhp, hp, ownerId, entityType, pkMode);
		switch (entityType)
		{
		case RoleManager.EntityType.EntityType_Self:
			this.SetSelfInfo(obj, pos);
			break;
		case RoleManager.EntityType.EntityType_Role:
			if (obj.id.Length > 0)
			{
				this.SetPlayerInfo(obj);
			}
			break;
		case RoleManager.EntityType.EntityType_Npc:
			this.SetNpcInfo(obj);
			break;
		case RoleManager.EntityType.EntityType_Monster:
			this.SetMonsterInfo(obj);
			break;
		case RoleManager.EntityType.EntityType_Lingqi:
			this.SetLingQiInfo(obj);
			break;
		case RoleManager.EntityType.EntityType_Partner:
			this.SetPartnerInfo(obj);
			break;
		case RoleManager.EntityType.EntityType_Aider:
			this.AddRoleAction(obj);
			break;
		case RoleManager.EntityType.EntityType_Pet:
			this.SetPetInfo(obj);
			break;
		case RoleManager.EntityType.EntityType_Beauty:
			this.SetBeautyInfo(obj);
			break;
		case RoleManager.EntityType.EntityType_XunLuo:
			this.AddRoleAction(obj);
			break;
		}
		obj.hp = hp;
		obj.UpdateBlockSetting(false);
		if (entityType == RoleManager.EntityType.EntityType_Lingqi || entityType == RoleManager.EntityType.EntityType_Partner || entityType == RoleManager.EntityType.EntityType_Pet || entityType == RoleManager.EntityType.EntityType_Beauty)
		{
			RoleManager.partnerAndLingQiEntities[obj.id] = obj;
		}
		else if (entityType == RoleManager.EntityType.EntityType_XunLuo)
		{
			RoleManager.xunLuoEntities.Add(obj);
		}
		else
		{
			RoleManager.sceneEntities[obj.id] = obj;
		}
	}

	private void SetEntityBaseInfo(SceneEntity obj, GameObject model, string name, float speed, int grade, int comp, int maxhp, int hp, string ownerId, RoleManager.EntityType entityType, string pkMode)
	{
		if (entityType == RoleManager.EntityType.EntityType_Self)
		{
			this._mainRole = obj;
		}
		if (entityType == RoleManager.EntityType.EntityType_Self || (ownerId == Singleton<RoleManager>.Instance.mainRole.id && (entityType == RoleManager.EntityType.EntityType_Partner || entityType == RoleManager.EntityType.EntityType_Lingqi || entityType == RoleManager.EntityType.EntityType_Pet || entityType == RoleManager.EntityType.EntityType_Beauty)))
		{
			obj.ChangeShader(model);
		}
		if (speed > 0f && obj.move != null)
		{
			obj.move.speed = speed;
		}
		obj.model = model;
		obj.grade = grade;
		obj.ownerId = ownerId;
		obj.comp = comp;
		obj.maxhp = maxhp;
		obj.hp = hp;
		obj.entityType = entityType;
		obj.AddHeadTitle(name);
		obj.UpdateMood(pkMode);
		obj.tag = this.EntityTypeToString(entityType);
		obj.gameObject.layer = 8;
		if (model != null)
		{
			BoxCollider component = model.GetComponent<BoxCollider>();
			if (component != null)
			{
				BoxCollider orAddComponent = obj.transform.GetOrAddComponent<BoxCollider>();
				orAddComponent.center = component.center;
				orAddComponent.size = component.size;
				orAddComponent.isTrigger = true;
				component.enabled = false;
			}
			this.SetEntityLayer(model.transform);
			model.tag = obj.tag;
			model.transform.GetOrAddComponent<AnimationEventReceiver>();
			this.AddFastShadow(model, entityType);
		}
	}

	public void AddFastShadow(GameObject model, RoleManager.EntityType type)
	{
		if (type == RoleManager.EntityType.EntityType_Lingqi)
		{
			return;
		}
		if (model == null)
		{
			return;
		}
		Transform transform = model.transform.FindChild("EF01");
		if (transform != null && transform.FindChild("shadow") == null)
		{
			GameObject gameObject = new GameObject("shadow");
			gameObject.transform.SetParent(transform);
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localPosition = new Vector3(0f, 0.2f, 0f);
			gameObject.layer = transform.gameObject.layer;
			FS_ShadowSimple fS_ShadowSimple = gameObject.AddComponent<FS_ShadowSimple>();
			fS_ShadowSimple.shadowMaterial = Resources.Load<Material>("Other/ShadowMaterial");
			fS_ShadowSimple.layerMask = ~LayerMask.NameToLayer("Ground");
			fS_ShadowSimple.shadowHoverHeight = 0f;
			fS_ShadowSimple.girth = ((!(model.transform.parent.localScale != Vector3.one)) ? 0.4f : 1f);
		}
	}

	private void SetEntityLayer(Transform root)
	{
		for (int i = 0; i < root.childCount; i++)
		{
			if (root.GetChild(i).childCount > 0)
			{
				this.SetEntityLayer(root.GetChild(i));
			}
			root.GetChild(i).gameObject.layer = LayerMask.NameToLayer("SceneEntity");
		}
		root.gameObject.layer = LayerMask.NameToLayer("SceneEntity");
	}

	private void SetSelfInfo(SceneEntity obj, Vector3 pos)
	{
		if (Singleton<RoleManager>.Instance.mainCamera != null && Singleton<RoleManager>.Instance.mainCamera.GetComponent<AudioListener>() != null)
		{
			UnityEngine.Object.DestroyImmediate(Singleton<RoleManager>.Instance.mainCamera.GetComponent<AudioListener>());
		}
		this._mainRole.gameObject.AddComponent<AudioListener>();
		this.AddRoleAction(obj);
		this.CreateCameraFollow();
		if (this.positionSync != null)
		{
			this.positionSync.AddObjectPosition(obj.id, pos);
		}
		obj.SetJumpTrailEffectParent();
	}

	private void SetPartnerInfo(SceneEntity obj)
	{
		PartnerAiScript partnerAiScript = obj.gameObject.AddComponent<PartnerAiScript>();
		partnerAiScript.self = obj;
		partnerAiScript.owner = RoleManager.sceneEntities[obj.ownerId];
		obj.horse.id = RoleManager.sceneEntities[obj.ownerId].partnerhorse;
		this.AddRoleAction(obj);
	}

	private void SetLingQiInfo(SceneEntity obj)
	{
		if (obj.model != null)
		{
			obj.model.transform.localPosition = new Vector3(0.8f, 0f, 0.8f);
		}
		LingQiAiScript lingQiAiScript = obj.gameObject.AddComponent<LingQiAiScript>();
		lingQiAiScript.self = obj;
		lingQiAiScript.owner = RoleManager.sceneEntities[obj.ownerId];
		this.AddRoleAction(obj);
	}

	private void SetPetInfo(SceneEntity obj)
	{
		PetAiScript petAiScript = obj.gameObject.AddComponent<PetAiScript>();
		petAiScript.self = obj;
		petAiScript.owner = RoleManager.sceneEntities[obj.ownerId];
		this.AddRoleAction(obj);
	}

	private void SetBeautyInfo(SceneEntity obj)
	{
		BeautyAiScript beautyAiScript = obj.gameObject.AddComponent<BeautyAiScript>();
		beautyAiScript.self = obj;
		beautyAiScript.owner = RoleManager.sceneEntities[obj.ownerId];
		this.AddRoleAction(obj);
	}

	private void SetMonsterInfo(SceneEntity obj)
	{
		this.AddRoleAction(obj);
		XWeaponTrail[] componentsInChildren = obj.model.transform.GetComponentsInChildren<XWeaponTrail>(true);
		obj.roleAction.weaponTrails.AddRange(componentsInChildren);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].Deactivate();
		}
	}

	private void AddRoleAction(SceneEntity obj)
	{
		obj.roleAction = obj.GetOrAddComponent<RoleAction>();
		obj.roleAction.self = obj;
		if (obj.model != null)
		{
			Animator component = obj.model.GetComponent<Animator>();
			if (component != null)
			{
				obj.roleAction.animator = component;
				component.enabled = true;
			}
		}
	}

	private void DisableBoxCollider(SceneEntity obj)
	{
		BoxCollider component = obj.model.GetComponent<BoxCollider>();
		component.enabled = false;
	}

	private void SetPlayerInfo(SceneEntity obj)
	{
		obj.roleAction = obj.GetOrAddComponent<RoleAction>();
		obj.roleAction.self = obj;
		obj.daZuo = obj.daZuo;
		if (obj.model != null)
		{
			Animator component = obj.model.GetComponent<Animator>();
			obj.roleAction.animator = component;
			obj.SetJumpTrailEffectParent();
		}
	}

	private void SetNpcInfo(SceneEntity obj)
	{
		obj.roleAction = obj.GetOrAddComponent<RoleAction>();
		obj.roleAction.self = obj;
		if (obj.model != null)
		{
			Animator component = obj.model.GetComponent<Animator>();
			obj.roleAction.animator = component;
		}
	}

	private void AsyncLoadCharacter(Transform parent, int shape, RoleManager.EntityType type, SceneEntity entity, Action<GameObject, string> callback)
	{
		object[] array = Util.CallMethod("PLAYERLOADER", "GetPlayerAndNpcResPath", new object[]
		{
			(int)type,
			entity.sex,
			shape
		});
		if (array == null || array.Length == 0)
		{
			Debug.LogError("获取角色npc模型资源路径错误");
			return;
		}
		string prefabPath = (string)array[0];
		ObjectPool.instance.AsyncPushToPool(prefabPath, (!entity.isBoss) ? 15 : 2, parent, 0f, 0f, 0f, callback);
	}

	public void CreateLingqi(SceneEntity playerObj, string lingqiStr)
	{
		if (playerObj == null)
		{
			return;
		}
		string[] array = lingqiStr.Split(new char[]
		{
			';'
		});
		if (array == null || array.Length != 2)
		{
			return;
		}
		if (!string.IsNullOrEmpty(playerObj.lingqiStr) && playerObj.lingqiStr.Equals(lingqiStr))
		{
			return;
		}
		playerObj.lingqiStr = lingqiStr;
		string id = array[0];
		int num = Convert.ToInt32(array[1]);
		GameObject go = this._loadEntityRes(RoleManager.EntityType.EntityType_Lingqi, id);
		SceneEntity obj = null;
		if (go)
		{
			obj = go.GetComponent<SceneEntity>();
			playerObj.lingqiObj = obj;
			obj.SetData(id, 10003, 1, 5f, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, -1, 0, 0, 0, 0);
			Util.CallMethod("PLAYERLOADER", "LoadLingqi", new object[]
			{
				playerObj,
				num,
				new Action<GameObject, string>(delegate(GameObject model, string name)
				{
					if (model != null && User_Config.blockOtherLingqi == 1 && playerObj.entityType != RoleManager.EntityType.EntityType_Self)
					{
						model.SetActive(false);
					}
					this.SetEntityInfo(go, model, playerObj.transform.position, 1, 0f, obj, string.Empty, 0, playerObj.id, playerObj.comp, 1, 1, false, RoleManager.EntityType.EntityType_Lingqi, string.Empty);
				})
			});
			return;
		}
	}

	public void CreatePartner(SceneEntity playerObj, string partnerStr)
	{
		if (playerObj == null)
		{
			return;
		}
		string[] array = partnerStr.Split(new char[]
		{
			';'
		});
		if (array == null || array.Length != 2)
		{
			return;
		}
		if (!string.IsNullOrEmpty(playerObj.partnerStr))
		{
			if (playerObj.partnerStr.Equals(partnerStr))
			{
				return;
			}
			return;
		}
		else
		{
			playerObj.partnerStr = partnerStr;
			string id = array[0];
			int num = Convert.ToInt32(array[1]);
			GameObject go = this._loadEntityRes(RoleManager.EntityType.EntityType_Partner, id);
			SceneEntity obj = null;
			if (go)
			{
				obj = go.GetComponent<SceneEntity>();
				playerObj.partnerObj = obj;
				obj.SetData(id, 10002, 1, 5f, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, -1, 0, 0, 0, 0);
				Util.CallMethod("PLAYERLOADER", "LoadPartner", new object[]
				{
					playerObj,
					num,
					new Action<GameObject, string>(delegate(GameObject model, string name)
					{
						if (model != null && User_Config.blockOtherPartner == 1 && playerObj.entityType != RoleManager.EntityType.EntityType_Self)
						{
							model.SetActive(false);
						}
						this.SetEntityInfo(go, model, playerObj.transform.position + new Vector3(0.8f, 0f, 0.8f), playerObj.dir, playerObj.move.speed, obj, string.Empty, 0, playerObj.id, playerObj.comp, 1, 1, false, RoleManager.EntityType.EntityType_Partner, string.Empty);
						Util.CallMethod("PLAYERLOADER", "LoadOtherShapeOfPartner", new object[]
						{
							obj,
							6,
							playerObj.lingqin,
							playerObj.lingyi
						});
						if (playerObj.entityType == RoleManager.EntityType.EntityType_Self)
						{
							obj.ChangeShader(obj.lingyi_model);
							obj.ChangeShader(obj.lingqin_model);
						}
						if (playerObj.up_horse == 1)
						{
							obj.isRide = true;
						}
					})
				});
				return;
			}
			return;
		}
	}

	public void CreatePet(SceneEntity playerObj, int pet)
	{
		if (playerObj == null)
		{
			return;
		}
		if (playerObj.petStr > 0)
		{
			if (playerObj.petStr.Equals(pet))
			{
				return;
			}
			return;
		}
		else
		{
			playerObj.petStr = pet;
			GameObject go = this._loadEntityRes(RoleManager.EntityType.EntityType_Pet, "10000");
			SceneEntity obj = null;
			if (go)
			{
				obj = go.GetComponent<SceneEntity>();
				playerObj.petObj = obj;
				obj.SetData("10000", 10000, 1, 5f, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, -1, 0, 0, 0, 0);
				Util.CallMethod("PLAYERLOADER", "LoadPet", new object[]
				{
					playerObj,
					pet,
					new Action<GameObject, string>(delegate(GameObject model, string name)
					{
						if (model != null && User_Config.blockOtherPet == 1 && playerObj.entityType != RoleManager.EntityType.EntityType_Self)
						{
							model.SetActive(false);
						}
						this.SetEntityInfo(go, model, playerObj.transform.position - new Vector3(0.8f, 0f, 0.8f), playerObj.dir, playerObj.move.speed, obj, string.Empty, 0, playerObj.id, playerObj.comp, 1, 1, false, RoleManager.EntityType.EntityType_Pet, string.Empty);
					})
				});
				return;
			}
			return;
		}
	}

	public void CreateBeauty(SceneEntity playerObj, int yunbiao)
	{
		if (playerObj == null)
		{
			return;
		}
		GameObject go = this._loadEntityRes(RoleManager.EntityType.EntityType_Beauty, "10001");
		SceneEntity obj = null;
		if (go)
		{
			obj = go.GetComponent<SceneEntity>();
			playerObj.beautyObj = obj;
			playerObj.beautyRare = yunbiao;
			string beautyName = playerObj.title.objName + "的神使";
			obj.SetData("10001", 10001, 1, 5f, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, -1, 0, 0, 0, 0);
			Util.CallMethod("PLAYERLOADER", "LoadBeauty", new object[]
			{
				playerObj,
				yunbiao,
				new Action<GameObject, string>(delegate(GameObject model, string name)
				{
					obj.model = model;
					this.SetEntityInfo(go, obj.model, playerObj.transform.position, 1, playerObj.move.speed, obj, beautyName, 0, playerObj.id, playerObj.comp, 1, 1, false, RoleManager.EntityType.EntityType_Beauty, string.Empty);
				})
			});
			return;
		}
	}

	public void CreateAider(string model, string posStr, int dir)
	{
		GameObject go = this._loadEntityRes(RoleManager.EntityType.EntityType_Partner, "0");
		SceneEntity obj = null;
		if (go)
		{
			obj = go.GetComponent<SceneEntity>();
			obj.SetData("0", 0, 1, 5f, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, -1, 0, 0, 0, 0);
			Util.CallMethod("PLAYERLOADER", "LoadAider", new object[]
			{
				obj,
				model,
				new Action<GameObject, string>(delegate(GameObject modelGo, string name)
				{
					obj.model = modelGo;
					if (modelGo != null)
					{
						modelGo.transform.localScale = Vector3.one;
					}
					string[] array = posStr.Split(new char[]
					{
						','
					});
					this.SetEntityInfo(go, obj.model, new Vector3(Convert.ToSingle(array[0]), Convert.ToSingle(array[1]), Convert.ToSingle(array[2])), 1, 0f, obj, string.Empty, 0, string.Empty, 0, 1, 1, false, RoleManager.EntityType.EntityType_Aider, string.Empty);
					obj.ChangeDir(dir);
					Util.CallMethod("ClientFightManager", "SaveAider", new object[]
					{
						obj
					});
				})
			});
			return;
		}
	}

	[DebuggerHidden]
	private IEnumerator AsyncInitilizePlayer()
	{
		EntityCreate.<AsyncInitilizePlayer>c__Iterator3A <AsyncInitilizePlayer>c__Iterator3A = new EntityCreate.<AsyncInitilizePlayer>c__Iterator3A();
		<AsyncInitilizePlayer>c__Iterator3A.<>f__this = this;
		return <AsyncInitilizePlayer>c__Iterator3A;
	}

	[DebuggerHidden]
	private IEnumerator AsyncInitilizeNpc()
	{
		EntityCreate.<AsyncInitilizeNpc>c__Iterator3B <AsyncInitilizeNpc>c__Iterator3B = new EntityCreate.<AsyncInitilizeNpc>c__Iterator3B();
		<AsyncInitilizeNpc>c__Iterator3B.<>f__this = this;
		return <AsyncInitilizeNpc>c__Iterator3B;
	}

	[DebuggerHidden]
	private IEnumerator AsyncInitilizeXunLuoNpc(LuaTable xLNpcs, int index)
	{
		EntityCreate.<AsyncInitilizeXunLuoNpc>c__Iterator3C <AsyncInitilizeXunLuoNpc>c__Iterator3C = new EntityCreate.<AsyncInitilizeXunLuoNpc>c__Iterator3C();
		<AsyncInitilizeXunLuoNpc>c__Iterator3C.xLNpcs = xLNpcs;
		<AsyncInitilizeXunLuoNpc>c__Iterator3C.index = index;
		<AsyncInitilizeXunLuoNpc>c__Iterator3C.<$>xLNpcs = xLNpcs;
		<AsyncInitilizeXunLuoNpc>c__Iterator3C.<$>index = index;
		<AsyncInitilizeXunLuoNpc>c__Iterator3C.<>f__this = this;
		return <AsyncInitilizeXunLuoNpc>c__Iterator3C;
	}

	public void CreateXunLuoNpcs(LuaTable table)
	{
		base.StartCoroutine(this.AsyncInitilizeXunLuoNpc(table, 1));
	}

	public void DelayAddPlayerAndNpc()
	{
		if (!this.isInAsynceLoad && this.beginAddNpc && this._npcs.Count > 0)
		{
			this.isInAsynceLoad = true;
			this.beginAddNpc = false;
			base.StartCoroutine(this.AsyncInitilizeNpc());
		}
		if (!this.isInAsynceLoad && this.beginAddPlayer && this._players.Count > 0)
		{
			this.isInAsynceLoad = true;
			this.beginAddPlayer = false;
			base.StartCoroutine(this.AsyncInitilizePlayer());
		}
	}

	public void DelayAddSelf()
	{
		if (this._heroInfo != null)
		{
			try
			{
				string name = string.Empty;
				if (string.IsNullOrEmpty(this._heroInfo.sync.adname))
				{
					name = this._heroInfo.sync.name;
				}
				else
				{
					name = string.Format("<color=#fdeb40>[{0}]</color>{1}", this._heroInfo.sync.adname, this._heroInfo.sync.name);
				}
				this.InitilizeSelfEntity(this._heroInfo.nmsg, this._heroInfo.sync, name);
			}
			catch (Exception ex)
			{
				Debug.LogError(string.Format("Add hero error!\nid: {0}\nname: {1}\nshape: {2}\n{3}", new object[]
				{
					this._heroInfo.nmsg.rid,
					this._heroInfo.sync.name,
					0,
					ex.ToString()
				}));
				this.DelayAddSelf();
				return;
			}
			foreach (string current in this.entityCreateEvents.Keys)
			{
				if (this.entityCreateEvents[current].roleEvent != null)
				{
					this.entityCreateEvents[current].roleEvent(this._mainRole, this._heroInfo.sync);
				}
			}
			base.StartCoroutine(this.CreateRoleAddionalModel(this._mainRole, this._heroInfo.sync.magic, this._heroInfo.sync.partner, this._heroInfo.sync.pet_model, this._heroInfo.sync.isyunbiao));
			this._heroInfo = null;
		}
		if (this._mainRole == null)
		{
			Debug.LogError("create main role failed!");
			return;
		}
	}

	public void AddEntityCreateEventListener(string name, EntityCreate.OnRoleCreated callback1, EntityCreate.OnNpcCreated callback2)
	{
		if (!this.entityCreateEvents.ContainsKey(name))
		{
			EntityCreate.EntityCreateEvent value = new EntityCreate.EntityCreateEvent(callback1, callback2);
			this.entityCreateEvents.Add(name, value);
		}
	}

	public void RemoveEntityCreateEventListener(string name)
	{
		if (this.entityCreateEvents.ContainsKey(name))
		{
			this.entityCreateEvents.Remove(name);
		}
	}

	[DebuggerHidden]
	private IEnumerator CreateRoleAddionalModel(SceneEntity obj, string lingqi, string huoban, int pet, int isyunbiao)
	{
		EntityCreate.<CreateRoleAddionalModel>c__Iterator3D <CreateRoleAddionalModel>c__Iterator3D = new EntityCreate.<CreateRoleAddionalModel>c__Iterator3D();
		<CreateRoleAddionalModel>c__Iterator3D.lingqi = lingqi;
		<CreateRoleAddionalModel>c__Iterator3D.obj = obj;
		<CreateRoleAddionalModel>c__Iterator3D.huoban = huoban;
		<CreateRoleAddionalModel>c__Iterator3D.pet = pet;
		<CreateRoleAddionalModel>c__Iterator3D.isyunbiao = isyunbiao;
		<CreateRoleAddionalModel>c__Iterator3D.<$>lingqi = lingqi;
		<CreateRoleAddionalModel>c__Iterator3D.<$>obj = obj;
		<CreateRoleAddionalModel>c__Iterator3D.<$>huoban = huoban;
		<CreateRoleAddionalModel>c__Iterator3D.<$>pet = pet;
		<CreateRoleAddionalModel>c__Iterator3D.<$>isyunbiao = isyunbiao;
		<CreateRoleAddionalModel>c__Iterator3D.<>f__this = this;
		return <CreateRoleAddionalModel>c__Iterator3D;
	}

	private void CreateCameraFollow()
	{
		GameObject gameObject = new GameObject("CameraFollow");
		this.cf = gameObject.AddComponent<CameraFollow>();
		this.cf.target_offsety = Singleton<RoleManager>.Instance.cameraOffsetY;
		this.cf.distance = Singleton<RoleManager>.Instance.cameraDistance;
		gameObject.AddComponent<CameraZoom>();
	}

	public void AddPlayer(S2c_aoi_addplayer cmd)
	{
		for (int i = 0; i < this._players.Count; i++)
		{
			if (this._players[i].nmsg.rid == cmd.nmsg.rid)
			{
				this._players.RemoveAt(i);
				break;
			}
		}
		if (this._players.Count == 0)
		{
			this.beginAddPlayer = true;
		}
		this._players.Add(cmd);
	}

	public void AddHero(S2c_aoi_addself cmd)
	{
		this._heroInfo = cmd;
		this.ClearWhenChangeScene();
	}

	public void AddNpc(S2c_aoi_addnpc cmd)
	{
		for (int i = 0; i < this._npcs.Count; i++)
		{
			if (this._npcs[i].nmsg.rid == cmd.nmsg.rid)
			{
				this._npcs.RemoveAt(i);
				this._needDeleteNpcs.Remove(cmd.nmsg.rid);
				break;
			}
		}
		if (this._npcs.Count == 0)
		{
			this.beginAddNpc = true;
		}
		this._npcs.Add(cmd);
	}

	public void AddAider(string model, string posStr, int dir)
	{
		this._aiderInfo = new string[]
		{
			model,
			posStr,
			dir.ToString()
		};
	}

	public void ClearWhenChangeScene()
	{
		this._npcs.Clear();
		this._players.Clear();
		this._needDeleteNpcs.Clear();
	}

	public void Clear()
	{
		base.StopAllCoroutines();
		this.isInAsynceLoad = false;
		this._mainRole = null;
		this.cf = null;
	}

	public bool DeleteObjectsById(string id)
	{
		for (int i = 0; i < this._players.Count; i++)
		{
			if (this._players[i].nmsg.rid == id)
			{
				this._players.RemoveAt(i);
				return true;
			}
		}
		for (int j = 0; j < this._npcs.Count; j++)
		{
			if (this._npcs[j].nmsg.rid == id)
			{
				this._needDeleteNpcs.Add(id);
				return true;
			}
		}
		if (this._heroInfo != null && this._heroInfo.sync.rid == id)
		{
			Debug.LogError("服务器试图删除主角，但客户端主角还未创建");
			return true;
		}
		if (this.positionSync != null)
		{
			this.positionSync.DeleteObjectPosition(id);
		}
		return false;
	}

	private void DeleteDeadNpc(string rid)
	{
		for (int i = 0; i < this._needDeleteNpcs.Count; i++)
		{
			if (this._needDeleteNpcs[i].Equals(rid))
			{
				this._needDeleteNpcs.Remove(rid);
				Singleton<RoleManager>.Instance.DeleteObjectsById(rid, true);
				return;
			}
		}
	}
}
