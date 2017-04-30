using Config;
using LuaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ThirdParty;
using UnityEngine;

public class SceneEntity : MonoBehaviour
{
	public bool selectable;

	public RoleManager.EntityType entityType;

	public Move move;

	public MoveController controller;

	public RunToTarget runToTarget;

	public SelectTarget selectTarget;

	public Buffs buffs;

	public Action deadCallBack;

	public RoleAction roleAction;

	public HeadTitle title;

	public string headTitle;

	public string husongTitle;

	public CastSkill castSkill;

	public Horse horse;

	public RoleStateTransition roleState;

	public GameObject selectParticle;

	public GameObject chongCiParticle;

	public GameObject jumpChongCiParticle;

	public GameObject jumpTrailParticle;

	public GameObject daZuoParticle;

	public string id;

	private int _hp;

	private bool _ride;

	private SceneEntity _attacker;

	private int _daZuo;

	public GameObject selectEffectGo
	{
		get;
		private set;
	}

	public GameObject chongCiEffectGo
	{
		get;
		private set;
	}

	public GameObject jumpChongCiEffectGo
	{
		get;
		private set;
	}

	public GameObject jumpTrailEffect1Go
	{
		get;
		private set;
	}

	public GameObject jumpTrailEffect2Go
	{
		get;
		private set;
	}

	public GameObject daZuoEffectGo
	{
		get;
		private set;
	}

	public int char_id
	{
		get;
		set;
	}

	public int sex
	{
		get;
		set;
	}

	public int grade
	{
		get;
		set;
	}

	public int dir
	{
		get;
		set;
	}

	public int hp
	{
		get
		{
			return this._hp;
		}
		set
		{
			if (value > 0)
			{
				if (this.roleAction != null && this.roleAction.curNextStatus == 15)
				{
					this.roleAction.SetReliveStatus();
					if (!base.gameObject.activeSelf)
					{
						base.gameObject.SetActive(true);
					}
					if (this.entityType == RoleManager.EntityType.EntityType_Self)
					{
						this.roleState.RemoveState(512);
					}
				}
			}
			else if (this.roleAction != null && this.roleAction.curStatus != 15 && this.entityType != RoleManager.EntityType.EntityType_Npc)
			{
				this.Dead(this._hp <= 0);
			}
			this._hp = value;
			if (this.title != null)
			{
				this.title.UpdateHp();
			}
		}
	}

	public int maxhp
	{
		get;
		set;
	}

	public bool canAttack
	{
		get
		{
			return this.entityType != RoleManager.EntityType.EntityType_Npc && this.entityType != RoleManager.EntityType.EntityType_XunLuo;
		}
	}

	public int comp
	{
		get;
		set;
	}

	public bool isBoss
	{
		get;
		set;
	}

	public int hpType
	{
		get;
		set;
	}

	public List<int> buffIdList
	{
		get;
		set;
	}

	public float bodyRadius
	{
		get;
		set;
	}

	public string ownerId
	{
		get;
		set;
	}

	public int npcBloodType
	{
		get;
		set;
	}

	public float scaleNum
	{
		get;
		set;
	}

	public List<string> teamMemberIds
	{
		get;
		private set;
	}

	public int partnerFollow
	{
		get;
		set;
	}

	public float headNameYoffset
	{
		get;
		set;
	}

	public bool isRide
	{
		get
		{
			return this._ride;
		}
		set
		{
			if (this.roleAction == null)
			{
				return;
			}
			bool ride = this._ride;
			this._ride = value;
			if (!ride && value)
			{
				this.horse.RideHorse(true);
			}
			else if (ride && !value)
			{
				this.horse.RideHorse(false);
			}
			if (this.move.jumpMode == 0)
			{
				if (this.move.InMoving())
				{
					this.roleAction.SetRoleMove(0);
				}
				else if (!this.roleAction.Stop() && this.daZuo == 0)
				{
					this.roleAction.SetRoleIdle();
				}
			}
		}
	}

	public string pkInfo
	{
		get;
		set;
	}

	public int score
	{
		get;
		set;
	}

	public SceneEntity attacker
	{
		get
		{
			return this._attacker;
		}
		set
		{
			this._attacker = value;
			this.autoResetAttackerTimer = 3f;
		}
	}

	public float autoResetAttackerTimer
	{
		get;
		set;
	}

	public int daZuo
	{
		get
		{
			return this._daZuo;
		}
		set
		{
			this._daZuo = value;
			if (this._daZuo == 1)
			{
				this.move.StopPath();
				if (this.roleAction != null && this.roleAction.curNextStatus != 17)
				{
					this.roleAction.SetActionStatus(17);
				}
				if (this.roleState)
				{
					this.roleState.AddState(32);
				}
				if (this.weapon_model && this.weapon_model.activeSelf)
				{
					this.weapon_model.SetActive(false);
				}
			}
			else
			{
				if (this.roleAction != null && this.roleAction.curNextStatus == 17)
				{
					this.roleAction.SetActionStatus(1);
				}
				if (this.roleState != null)
				{
					this.roleState.RemoveState(32);
				}
				if (this.weapon_model && !this.weapon_model.activeSelf)
				{
					this.weapon_model.SetActive(true);
				}
			}
		}
	}

	public int shield_hp
	{
		get;
		set;
	}

	public int shield_hpmax
	{
		get;
		set;
	}

	public int fashion
	{
		get;
		set;
	}

	public int shape
	{
		get;
		set;
	}

	public int weapon
	{
		get;
		set;
	}

	public int lingqin
	{
		get;
		set;
	}

	public int lingyi
	{
		get;
		set;
	}

	public int partnerhorse
	{
		get;
		set;
	}

	public int pet
	{
		get;
		set;
	}

	public int shenjian
	{
		get;
		set;
	}

	public int shenyi
	{
		get;
		set;
	}

	public int jingmai
	{
		get;
		set;
	}

	public int up_mount
	{
		get;
		set;
	}

	public int up_horse
	{
		get;
		set;
	}

	public GameObject model
	{
		get;
		set;
	}

	public GameObject weapon_model
	{
		get;
		set;
	}

	public GameObject lingqin_model
	{
		get;
		set;
	}

	public GameObject lingyi_model
	{
		get;
		set;
	}

	public GameObject partnerhorse_model
	{
		get;
		set;
	}

	public GameObject pet_model
	{
		get;
		set;
	}

	public GameObject shenjian_model
	{
		get;
		set;
	}

	public GameObject shenyi_model
	{
		get;
		set;
	}

	public GameObject jingmai_model
	{
		get;
		set;
	}

	public SceneEntity lingqiObj
	{
		get;
		set;
	}

	public string lingqiStr
	{
		get;
		set;
	}

	public SceneEntity partnerObj
	{
		get;
		set;
	}

	public string partnerStr
	{
		get;
		set;
	}

	public SceneEntity petObj
	{
		get;
		set;
	}

	public int petStr
	{
		get;
		set;
	}

	public SceneEntity beautyObj
	{
		get;
		set;
	}

	public int beautyRare
	{
		get;
		set;
	}

	public bool isBucket
	{
		get;
		set;
	}

	public Dictionary<string, object> extendInfo
	{
		get;
		set;
	}

	public SceneEntity()
	{
		this._hp = 0;
		this.buffIdList = new List<int>();
		this.teamMemberIds = new List<string>();
		this.autoResetAttackerTimer = 3f;
		this.extendInfo = new Dictionary<string, object>();
	}

	private void Awake()
	{
		this.selectEffectGo = this.LoadParticle(this.selectParticle);
		this.selectEffectGo.SetActive(false);
		if (this.entityType == RoleManager.EntityType.EntityType_Role || this.entityType == RoleManager.EntityType.EntityType_Self)
		{
			this.chongCiEffectGo = this.LoadParticle(this.chongCiParticle);
			this.chongCiEffectGo.SetActive(false);
			this.jumpChongCiEffectGo = this.LoadParticle(this.jumpChongCiParticle);
			this.jumpChongCiEffectGo.SetActive(false);
			this.jumpChongCiEffectGo.AddComponent<AutoActiveParticle>();
			this.daZuoEffectGo = this.LoadParticle(this.daZuoParticle);
			this.daZuoEffectGo.SetActive(false);
			this.jumpTrailEffect1Go = this.LoadParticle(this.jumpTrailParticle);
			this.jumpTrailEffect1Go.SetActive(false);
			this.jumpTrailEffect2Go = this.LoadParticle(this.jumpTrailParticle);
			this.jumpTrailEffect2Go.SetActive(false);
		}
	}

	private void Update()
	{
		if (this.attacker != null && this.hp > 0)
		{
			this.autoResetAttackerTimer -= Time.deltaTime;
			if (this.autoResetAttackerTimer <= 0f)
			{
				this.attacker = null;
			}
		}
	}

	public GameObject LoadParticle(GameObject particle)
	{
		if (particle)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(particle);
			gameObject.transform.parent = base.transform;
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			return gameObject;
		}
		return null;
	}

	public void SetKeyValue(string key, object value)
	{
		if (this.extendInfo.ContainsKey(key))
		{
			this.extendInfo[key] = value;
		}
		else
		{
			this.extendInfo.Add(key, value);
		}
	}

	public object GetValueByKey(string key)
	{
		if (this.extendInfo.ContainsKey(key))
		{
			return this.extendInfo[key];
		}
		return null;
	}

	public void SetData(string id, int char_id, int sex = 1, float speed = 5f, int weapon = -1, int mount_model = -1, int partnerhorse_model = -1, int lingqin_model = -1, int lingyi_model = -1, int pet_model = -1, int shenjian_model = -1, int shenyi_model = -1, int jingmai_model = -1, int score = 0, int up_mount = 0, int up_horse = 0, int fashion = -1, int dazuo = 0, int shield_hp = 0, int shield_hpmax = 0, int isyunbiao = 0)
	{
		this.id = id;
		this.char_id = char_id;
		this.sex = sex;
		if (this.move != null)
		{
			this.move.speed = speed;
		}
		if (this.horse != null)
		{
			this.horse.id = mount_model;
		}
		this.weapon = weapon;
		this.lingqin = lingqin_model;
		this.lingyi = lingyi_model;
		this.partnerhorse = partnerhorse_model;
		this.pet = pet_model;
		this.shenjian = shenjian_model;
		this.shenyi = shenyi_model;
		this.jingmai = jingmai_model;
		this.score = score;
		this.up_mount = up_mount;
		this.up_horse = up_horse;
		this.fashion = fashion;
		this.daZuo = dazuo;
		this.shield_hpmax = shield_hpmax;
		this.shield_hp = shield_hp;
		this.beautyRare = isyunbiao;
	}

	public void ShowHideEntityModel(bool show)
	{
		if (this.entityType != RoleManager.EntityType.EntityType_Role)
		{
			return;
		}
		if (show)
		{
			this.UpdateBlockSetting(true);
			if (this.partnerObj != null)
			{
				this.partnerObj.UpdateBlockSetting(false);
			}
			if (this.lingqiObj != null)
			{
				this.lingqiObj.UpdateBlockSetting(false);
			}
			if (this.petObj != null)
			{
				this.petObj.UpdateBlockSetting(false);
			}
		}
		else
		{
			this.model.SetActive(false);
			if (this.horse.horseGo != null)
			{
				this.horse.horseGo.SetActive(false);
			}
			if (this.partnerObj != null)
			{
				this.partnerObj.model.SetActive(false);
				if (this.partnerObj.horse.horseGo != null)
				{
					this.partnerObj.horse.horseGo.SetActive(false);
				}
				if (this.partnerObj.lingqin_model != null)
				{
					this.partnerObj.lingqin_model.SetActive(false);
				}
			}
			if (this.lingqiObj != null)
			{
				this.lingqiObj.model.SetActive(false);
			}
			if (this.petObj != null)
			{
				this.petObj.model.SetActive(false);
			}
			if (this.lingqin_model != null)
			{
				this.lingqin_model.SetActive(false);
			}
		}
	}

	public void UpdateBlockSetting(bool ignoreWhenChangeSetting = true)
	{
		if (this.entityType == RoleManager.EntityType.EntityType_Self)
		{
			return;
		}
		if (this.model == null || (ignoreWhenChangeSetting && !this.model.activeSelf))
		{
			return;
		}
		if (this.entityType == RoleManager.EntityType.EntityType_Role)
		{
			if (User_Config.blockOtherPlayer == 1)
			{
				this.model.SetActive(false);
				if (this.horse.horseGo != null)
				{
					this.horse.horseGo.SetActive(false);
				}
				if (this.lingqin_model != null)
				{
					this.lingqin_model.SetActive(false);
				}
			}
			else
			{
				object[] array = Util.CallMethod("FIGHTMGR", "ChargeTargetStatus", new object[]
				{
					this.pkInfo
				});
				if (array == null || array.Length == 0)
				{
					Debug.LogError("角色获取pk模式信息错误");
					return;
				}
				bool flag = Convert.ToBoolean(array[0]);
				if (User_Config.blockAllianPlayer == 1 && !flag)
				{
					this.model.SetActive(false);
					if (this.horse.horseGo != null)
					{
						this.horse.horseGo.SetActive(false);
					}
					if (this.lingqin_model != null)
					{
						this.lingqin_model.SetActive(false);
					}
				}
				else
				{
					this.model.SetActive(true);
					if (this.horse.horseGo != null)
					{
						this.horse.horseGo.SetActive(true);
					}
					if (this.lingqin_model != null)
					{
						this.lingqin_model.SetActive(true);
					}
				}
			}
			return;
		}
		if (this.entityType == RoleManager.EntityType.EntityType_Monster)
		{
			this.model.SetActive(User_Config.blockMonster != 1);
			return;
		}
		if (this.ownerId == Singleton<RoleManager>.Instance.mainRole.id)
		{
			return;
		}
		SceneEntity sceneEntityById = Singleton<RoleManager>.Instance.GetSceneEntityById(this.ownerId, 0);
		if (this.entityType == RoleManager.EntityType.EntityType_Partner)
		{
			this.model.SetActive(User_Config.blockOtherPartner != 1 && sceneEntityById.model.activeSelf);
			if (this.lingqin_model != null)
			{
				this.lingqin_model.SetActive(this.model.activeSelf);
			}
			if (this.horse.horseGo != null)
			{
				this.horse.horseGo.SetActive(this.model.activeSelf);
			}
		}
		else if (this.entityType == RoleManager.EntityType.EntityType_Lingqi)
		{
			this.model.SetActive(User_Config.blockOtherLingqi != 1 && sceneEntityById.model.activeSelf);
		}
		else if (this.entityType == RoleManager.EntityType.EntityType_Pet)
		{
			this.model.SetActive(User_Config.blockOtherPet != 1 && sceneEntityById.model.activeSelf);
		}
	}

	public void ChangeShader(GameObject go)
	{
		if (go == null)
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren = go.GetComponentsInChildren<SkinnedMeshRenderer>();
		SkinnedMeshRenderer[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = array[i];
			skinnedMeshRenderer.material.shader = Shader.Find("BLSJ/Textured Add Main Role");
		}
		MeshRenderer[] componentsInChildren2 = go.GetComponentsInChildren<MeshRenderer>();
		MeshRenderer[] array2 = componentsInChildren2;
		for (int j = 0; j < array2.Length; j++)
		{
			MeshRenderer meshRenderer = array2[j];
			meshRenderer.material.shader = Shader.Find("BLSJ/Textured Add Main Role");
		}
	}

	private void OnDestroy()
	{
	}

	private void OnDisable()
	{
		this.extendInfo.Clear();
		Util.CallMethod("HEROSKILLMGR", "SceneObjDestory", new object[]
		{
			this.id
		});
	}

	public void ChangeDir(int dir)
	{
		this.dir = dir;
		base.transform.rotation = Quaternion.Euler(0f, (float)(dir - 1) * 45f, 0f);
	}

	public void DelayRotateBackAfterSelected()
	{
		base.Invoke("NpcRotateBack", 3f);
	}

	private void NpcRotateBack()
	{
	}

	private void Dead(bool dieImmediate)
	{
		this._hp = 0;
		this.move.StopPath();
		this.roleAction.SetActionStatus(15);
		if (this.castSkill != null)
		{
			this.castSkill.ClearAllSkill();
		}
		if (this.deadCallBack != null)
		{
			this.deadCallBack();
			this.deadCallBack = null;
		}
		if (this.isRide)
		{
			this.isRide = false;
		}
		if (this.entityType == RoleManager.EntityType.EntityType_Self)
		{
			Singleton<RoleManager>.Instance.cf.CameraTargetToSelf(true);
			PunchAway component = base.GetComponent<PunchAway>();
			if (component != null)
			{
				component.StartPunch();
			}
			this.roleState.AddState(512);
		}
		else if (this.entityType == RoleManager.EntityType.EntityType_Role)
		{
			PunchAway component2 = base.GetComponent<PunchAway>();
			if (component2 != null)
			{
				component2.StartPunch();
			}
		}
		else if (this.entityType == RoleManager.EntityType.EntityType_Monster && !this.isBoss && !dieImmediate)
		{
			PunchAway component3 = base.GetComponent<PunchAway>();
			if (component3 != null)
			{
				component3.StartPunch();
			}
		}
	}

	public void AddHeadTitle(string objName)
	{
		if (this.model == null)
		{
			return;
		}
		Transform transform = this.model.transform.Find("Dummy001");
		if (transform)
		{
			if (this.title != null)
			{
				Debug.LogError("title is not null!!");
				return;
			}
			GameObject gameObject = GameObject.FindWithTag("GuiCamera");
			Transform parent = gameObject.transform.FindChild("headwidget");
			string prefabPath = "Prefab/Gui/HeadTitle";
			GameObject gameObject2 = ObjectPool.instance.PushToPool(prefabPath, 15, parent);
			gameObject2.transform.localScale = Vector3.one;
			this.title = gameObject2.GetComponent<HeadTitle>();
			this.title.Head = transform;
			this.title.self = this;
			this.title.SetEntityName(objName, 0);
			this.title.ResetYOffset();
			this.title.ShowHideHeadTitle();
			this.title.UpdateExtendInfo();
		}
	}

	public void ResetHeadTitle()
	{
		Transform transform = this.model.transform.Find("Dummy001");
		if (transform)
		{
			if (this.title == null)
			{
				Debug.LogError("title is null!!");
				return;
			}
			this.title.Head = transform;
			this.title.ResetYOffset();
		}
	}

	public void AddTeamMember(string ids)
	{
		this.teamMemberIds.Clear();
		if (!string.IsNullOrEmpty(ids))
		{
			string[] array = ids.Split(new char[]
			{
				';'
			});
			for (int i = 0; i < array.Length; i++)
			{
				this.teamMemberIds.Add(array[i]);
			}
		}
	}

	public void OnHurt()
	{
		base.StartCoroutine(this.HurtEffaction());
	}

	[DebuggerHidden]
	private IEnumerator HurtEffaction()
	{
		SceneEntity.<HurtEffaction>c__Iterator40 <HurtEffaction>c__Iterator = new SceneEntity.<HurtEffaction>c__Iterator40();
		<HurtEffaction>c__Iterator.<>f__this = this;
		return <HurtEffaction>c__Iterator;
	}

	public string GetObjName()
	{
		return (!(this.title == null)) ? this.title.objName : base.name;
	}

	public void StartPlotJump(int doorNo, int endMap, Action onJumpFinished)
	{
		PlotJumpLogic orAddComponent = base.transform.GetOrAddComponent<PlotJumpLogic>();
		orAddComponent.StartPlotJump(doorNo, endMap, onJumpFinished);
	}

	public void UpdateMood(string pkInfo)
	{
		if (string.IsNullOrEmpty(pkInfo))
		{
			return;
		}
		this.pkInfo = pkInfo;
		object[] array = Util.CallMethod("FIGHTMGR", "ChargeTargetNameType", new object[]
		{
			this.pkInfo
		});
		if (array == null || array.Length == 0)
		{
			Debug.LogError("角色获取pk模式信息错误");
			return;
		}
		if (this.title != null)
		{
			this.title.SetEntityName(this.title.objName, Convert.ToInt32(array[0]));
			if (this.entityType == RoleManager.EntityType.EntityType_Self)
			{
				Singleton<RoleManager>.Instance.UpdateAllTitleBlood();
			}
			else if (this.entityType == RoleManager.EntityType.EntityType_Role)
			{
				this.title.UpdateMood();
			}
		}
	}

	public void UpdateExtendInfo()
	{
		if (this.title != null)
		{
			this.title.UpdateExtendInfo();
		}
	}

	public void Recycle()
	{
		if (this.model != null)
		{
			this.model.Recycle();
			this.model = null;
		}
		if (this.title != null)
		{
			this.title.ClearHusongTitle();
			this.title.gameObject.Recycle();
			this.title = null;
		}
		if (base.gameObject != null)
		{
			base.gameObject.Recycle();
		}
	}

	public void RecycleRoleModel()
	{
		if (this.model != null)
		{
			this.ResetJumpTrailEffect();
			this.model.Recycle();
			this.model = null;
		}
	}

	private void ResetJumpTrailEffect()
	{
		if (this.entityType != RoleManager.EntityType.EntityType_Self && this.entityType != RoleManager.EntityType.EntityType_Role)
		{
			return;
		}
		if (this.jumpTrailEffect1Go != null && this.jumpTrailEffect2Go != null)
		{
			this.jumpTrailEffect1Go.transform.SetParent(base.transform);
			this.jumpTrailEffect1Go.SetActive(false);
			this.jumpTrailEffect2Go.transform.SetParent(base.transform);
			this.jumpTrailEffect2Go.SetActive(false);
		}
	}

	public void SetJumpTrailEffectParent()
	{
		if (this.entityType != RoleManager.EntityType.EntityType_Self && this.entityType != RoleManager.EntityType.EntityType_Role)
		{
			return;
		}
		if (this.model != null && !this.isBucket)
		{
			Transform transform = Util.Find(this.model.transform, "EF02");
			if (transform != null)
			{
				this.jumpTrailEffect1Go.transform.SetParent(transform);
				this.jumpTrailEffect1Go.transform.localPosition = Vector3.zero;
				this.jumpTrailEffect1Go.transform.localScale = Vector3.one;
			}
			Transform transform2 = Util.Find(this.model.transform, "EF03");
			if (transform2 != null)
			{
				this.jumpTrailEffect2Go.transform.SetParent(transform2);
				this.jumpTrailEffect2Go.transform.localPosition = Vector3.zero;
				this.jumpTrailEffect2Go.transform.localScale = Vector3.one;
			}
		}
	}

	public void RecycleOtherModel(int modelType)
	{
		switch (modelType)
		{
		case 1:
			this.horse.Recycle();
			break;
		case 2:
			this.lingqin_model.Recycle();
			this.lingqin_model = null;
			break;
		case 3:
			this.lingyi_model.Recycle();
			this.lingyi_model = null;
			break;
		case 4:
			this.partnerhorse_model.Recycle();
			this.partnerhorse_model = null;
			break;
		case 5:
			this.petObj.model.Recycle();
			this.petObj.model = null;
			break;
		case 6:
			this.weapon_model.Recycle();
			this.weapon_model = null;
			break;
		case 7:
			this.shenyi_model.Recycle();
			this.shenyi_model = null;
			break;
		case 8:
			this.jingmai_model.Recycle();
			this.jingmai_model = null;
			break;
		case 9:
			this.beautyObj.Recycle();
			this.title.ClearHusongTitle();
			break;
		}
	}

	public void ChangeHusongTitle(string husongTitle)
	{
		if (this.title == null)
		{
			return;
		}
		this.title.SetHusongSprite(husongTitle);
	}

	public void Say(string msg)
	{
		if (this.title != null)
		{
			this.title.ShowBubble(msg);
		}
	}

	public void XunLuoNpcClick(string msg)
	{
		this.Say(msg);
		NpcXunLuo component = base.transform.GetComponent<NpcXunLuo>();
		if (component != null)
		{
			component.StartWaitingToGo();
		}
	}
}
