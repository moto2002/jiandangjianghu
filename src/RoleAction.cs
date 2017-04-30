using LuaFramework;
using System;
using System.Collections.Generic;
using UnityEngine;
using Xft;

public class RoleAction : MonoBehaviour
{
	public enum state
	{
		none,
		idle,
		run,
		jump01,
		jump02,
		jump03,
		attack01,
		attack02,
		attack03,
		attack04,
		attack05,
		skill01,
		skill02,
		skill03,
		skill04,
		die,
		hurt,
		sit01,
		sit02,
		rideidle,
		riderun,
		rideattack,
		show01,
		show02,
		show03,
		dash,
		fall01,
		fall02,
		fall03,
		jumpdash,
		stun
	}

	public SceneEntity self;

	public List<XWeaponTrail> weaponTrails = new List<XWeaponTrail>();

	private bool trailActive;

	public Animator animator
	{
		get;
		set;
	}

	public Animator horseAnimator
	{
		get;
		set;
	}

	public Animator wingAnimator
	{
		get;
		set;
	}

	public Animator lingyiAnimator
	{
		get;
		set;
	}

	public Animator lingqinAnimator
	{
		get;
		set;
	}

	public int curStatus
	{
		get;
		set;
	}

	public int curNextStatus
	{
		get;
		set;
	}

	public bool inAttackCombo
	{
		get;
		set;
	}

	private void Awake()
	{
		this.curNextStatus = 1;
	}

	private void Start()
	{
	}

	private void Update()
	{
		if (this.curNextStatus == this.curStatus || this.animator == null || (this.self.model != null && !this.self.model.activeSelf))
		{
			return;
		}
		if (this.curStatus == 25)
		{
			this.self.chongCiEffectGo.SetActive(false);
			this.self.move.speedFactor = 1f;
		}
		if (this.curStatus == 17)
		{
			this.self.daZuoEffectGo.SetActive(false);
		}
		this.curStatus = this.curNextStatus;
		if (this.curStatus == 25)
		{
			this.self.move.speedFactor = 3f;
			this.self.chongCiEffectGo.SetActive(true);
		}
		if (this.weaponTrails.Count > 0)
		{
			if (this.Stop() && !this.trailActive)
			{
				for (int i = 0; i < this.weaponTrails.Count; i++)
				{
					this.weaponTrails[i].Activate();
				}
				this.trailActive = true;
			}
			else if (!this.Stop() && this.trailActive)
			{
				for (int j = 0; j < this.weaponTrails.Count; j++)
				{
					this.weaponTrails[j].Deactivate();
				}
				this.trailActive = false;
			}
		}
		this.animator.SetInteger("status", this.curNextStatus);
		this.PlayActionAudio();
		this.animator.Update(0f);
		this.UpdateOtherAnimator();
	}

	private void UpdateOtherAnimator()
	{
		if (this.self.entityType == RoleManager.EntityType.EntityType_Self || this.self.entityType == RoleManager.EntityType.EntityType_Role)
		{
			if (this.self.shenyi_model != null && this.self.shenyi_model.activeSelf)
			{
				if (this.wingAnimator == null)
				{
					this.wingAnimator = this.self.shenyi_model.GetComponent<Animator>();
				}
				this.wingAnimator.SetInteger("status", this.curNextStatus);
			}
			if (this.curNextStatus == 17)
			{
				this.self.daZuoEffectGo.SetActive(true);
			}
		}
		else if (this.self.entityType == RoleManager.EntityType.EntityType_Partner)
		{
			if (this.self.lingyi_model != null && this.self.lingyi_model.activeSelf)
			{
				if (this.lingyiAnimator == null)
				{
					this.lingyiAnimator = this.self.lingyi_model.GetComponent<Animator>();
				}
				this.lingyiAnimator.SetInteger("status", this.curNextStatus);
			}
			if (this.self.lingqin_model != null && this.self.lingqin_model.activeSelf)
			{
				if (this.lingqinAnimator == null)
				{
					this.lingqinAnimator = this.self.lingqin_model.GetComponent<Animator>();
				}
				this.lingqinAnimator.SetInteger("status", this.curNextStatus);
			}
		}
		if (this.horseAnimator != null && (this.curNextStatus == 19 || this.curNextStatus == 20))
		{
			if (this.curNextStatus == 19)
			{
				this.horseAnimator.SetInteger("status", 1);
				if (this.self.entityType == RoleManager.EntityType.EntityType_Self)
				{
					AppFacade.Instance.GetManager<SoundManager>("SoundManager").StopEffectSound(this.self.horse.rideRunAudioName, 4);
				}
			}
			else
			{
				this.horseAnimator.SetInteger("status", 2);
				if (this.self.entityType == RoleManager.EntityType.EntityType_Self)
				{
					AppFacade.Instance.GetManager<SoundManager>("SoundManager").PlayEffectSound(this.self.horse.rideRunAudioName, this.self.transform.position, true);
				}
			}
		}
	}

	private void PlayActionAudio()
	{
		if (this.self.entityType != RoleManager.EntityType.EntityType_Self)
		{
			return;
		}
		if (this.curNextStatus != 17 && this.curNextStatus != 18)
		{
			AppFacade.Instance.GetManager<SoundManager>("SoundManager").StopEffectSound("sit", 4);
		}
		else
		{
			AppFacade.Instance.GetManager<SoundManager>("SoundManager").PlayEffectSound("sit", this.self.transform.position, true);
		}
		string name = (this.self.sex != 1) ? "move-female" : "move-male";
		if (this.curNextStatus != 2)
		{
			AppFacade.Instance.GetManager<SoundManager>("SoundManager").StopEffectSound(name, 4);
		}
		else
		{
			AppFacade.Instance.GetManager<SoundManager>("SoundManager").PlayEffectSound(name, this.self.transform.position, true);
		}
		if (this.curNextStatus == 29)
		{
			AppFacade.Instance.GetManager<SoundManager>("SoundManager").PlayEffectSound("jumpdash", this.self.transform.position, false);
		}
		else if (this.curNextStatus >= 3 && this.curNextStatus <= 5)
		{
			AppFacade.Instance.GetManager<SoundManager>("SoundManager").PlayEffectSound("jump", this.self.transform.position, false);
		}
		if (this.curNextStatus == 15)
		{
			string name2 = (this.self.sex != 1) ? "die-female" : "die-male";
			AppFacade.Instance.GetManager<SoundManager>("SoundManager").PlayEffectSound(name2, this.self.transform.position, false);
		}
	}

	private void OnEnable()
	{
		this.trailActive = false;
		this.curNextStatus = 1;
	}

	private void OnDisable()
	{
		this.animator = null;
		this.horseAnimator = null;
		this.wingAnimator = null;
		this.lingyiAnimator = null;
		this.lingqinAnimator = null;
		this.curStatus = 0;
		this.curNextStatus = 0;
		this.trailActive = false;
		this.weaponTrails.Clear();
	}

	public void ResetRoleAnimation(GameObject model)
	{
		if (model == null)
		{
			Debug.Log("Model error: empty Model in " + this.self.name);
			return;
		}
		this.animator = model.GetComponent<Animator>();
		if (this.animator == null)
		{
			Debug.Log("Animation error: empty animator in " + this.self.name);
		}
		else
		{
			this.ResetToIdleImmediate();
		}
	}

	public void ResetWingsAnimation(GameObject model)
	{
		if (model == null)
		{
			Debug.Log("Model error: empty Model in " + this.self.name);
			return;
		}
		if (this.self.entityType == RoleManager.EntityType.EntityType_Partner)
		{
			this.lingyiAnimator = model.GetComponent<Animator>();
			if (this.lingyiAnimator == null)
			{
				Debug.Log("Animation error: empty animator in " + this.self.name);
			}
			else if (this.curStatus == 0)
			{
				this.lingyiAnimator.SetInteger("status", this.curNextStatus);
			}
		}
		else
		{
			this.wingAnimator = model.GetComponent<Animator>();
			if (this.wingAnimator == null)
			{
				Debug.Log("Animation error: empty animator in " + this.self.name);
			}
			else if (this.curStatus == 0)
			{
				this.wingAnimator.SetInteger("status", this.curNextStatus);
			}
		}
	}

	public void ResetLingQinAnimation(GameObject model)
	{
		if (model == null)
		{
			Debug.Log("Model error: empty Model in " + this.self.name);
			return;
		}
		this.lingqinAnimator = model.GetComponent<Animator>();
		if (this.lingqinAnimator == null)
		{
			Debug.Log("Animation error: empty animator in " + this.self.name);
		}
		else if (this.curStatus == 0)
		{
			this.lingqinAnimator.SetInteger("status", this.curNextStatus);
		}
	}

	public void SetActionStatus(int status)
	{
		if (this.curNextStatus == status)
		{
			return;
		}
		if (this.curNextStatus == 15)
		{
			return;
		}
		if ((status < 6 || status > 10) && this.inAttackCombo)
		{
			this.inAttackCombo = false;
		}
		if (this.self.entityType == RoleManager.EntityType.EntityType_Self && status >= 6 && status <= 14)
		{
			this.self.controller.canMove = false;
			this.self.roleState.AddState(1);
		}
		this.curNextStatus = status;
	}

	public void SetReliveStatus()
	{
		int curNextStatus;
		if (this.self.isRide)
		{
			curNextStatus = 19;
		}
		else
		{
			curNextStatus = 1;
		}
		this.inAttackCombo = false;
		this.curNextStatus = curNextStatus;
	}

	public void SetRoleIdle()
	{
		if (this.self.isRide)
		{
			this.SetActionStatus(19);
		}
		else
		{
			this.SetActionStatus(1);
		}
	}

	public void SetRoleMove(int type = 0)
	{
		if (this.self.hp <= 0)
		{
			return;
		}
		if (type == 1 && (this.self.entityType == RoleManager.EntityType.EntityType_Self || this.self.entityType == RoleManager.EntityType.EntityType_Role))
		{
			this.SetActionStatus(25);
			return;
		}
		if (this.self.move.jumpMode == 0)
		{
			if (this.self.isRide)
			{
				if (this.self.entityType == RoleManager.EntityType.EntityType_Partner)
				{
					this.SetActionStatus(1);
				}
				else
				{
					this.SetActionStatus(20);
				}
			}
			else
			{
				this.SetActionStatus(2);
			}
		}
	}

	public int SetRoleJump(int index = 0)
	{
		if (index >= 1 && index <= 3)
		{
			this.SetActionStatus(3 + (index - 1));
			return this.curNextStatus;
		}
		int num = UnityEngine.Random.Range(3, 6);
		this.SetActionStatus(num);
		return num;
	}

	public void SetRoleFall(int actionId)
	{
		if (actionId == 3)
		{
			this.SetActionStatus(26);
		}
		else if (actionId == 4)
		{
			this.SetActionStatus(27);
		}
		else if (actionId == 5)
		{
			this.SetActionStatus(28);
		}
		else
		{
			this.SetActionStatus(26);
		}
	}

	public void SetAttackCombo()
	{
		if (this.curStatus >= 6 && this.curStatus <= 10)
		{
			this.inAttackCombo = true;
		}
	}

	public void ResetToIdleImmediate()
	{
		if (this.curStatus == 15)
		{
			return;
		}
		if (this.self.entityType == RoleManager.EntityType.EntityType_Self || this.self.entityType == RoleManager.EntityType.EntityType_Role)
		{
			this.curNextStatus = ((!this.self.isRide) ? 1 : 19);
		}
		else
		{
			this.curNextStatus = 1;
		}
		this.Update();
	}

	public bool Stop()
	{
		return this.curNextStatus >= 6 && this.curNextStatus <= 14;
	}

	public bool CanJump()
	{
		return !this.Stop() && this.curNextStatus != 25;
	}

	public bool CancelHurt()
	{
		return this.curNextStatus != 1;
	}

	public bool NeedWaitToIdle()
	{
		return this.curStatus == 26 || this.curStatus == 27 || this.curStatus == 28;
	}

	private bool IsNextSkill()
	{
		return this.curStatus >= 6 && this.curStatus < 10 && this.curNextStatus == this.curStatus + 1;
	}

	public bool IsLoopAction()
	{
		return this.curNextStatus == 1 || this.curNextStatus == 19 || this.curNextStatus == 2 || this.curNextStatus == 20 || this.curNextStatus == 17 || this.curNextStatus == 25 || this.curNextStatus == 3 || this.curNextStatus == 4 || this.curNextStatus == 5 || this.curNextStatus == 29 || this.curNextStatus == 26 || this.curNextStatus == 27 || this.curNextStatus == 28 || this.curNextStatus == 18;
	}
}
