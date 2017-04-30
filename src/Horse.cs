using LuaFramework;
using System;
using ThirdParty;
using UnityEngine;

public class Horse : MonoBehaviour
{
	public GameObject horseParticle;

	public Vector3 ridePosition;

	private SceneEntity _self;

	private Transform horseTrans;

	public int id
	{
		get;
		set;
	}

	public GameObject horseGo
	{
		get;
		set;
	}

	public string rideRunAudioName
	{
		get;
		set;
	}

	private void Awake()
	{
		this._self = base.GetComponent<SceneEntity>();
		if (this.horseParticle != null)
		{
			ObjectPool.CreatePool(this.horseParticle, 5);
		}
	}

	private void OnDisable()
	{
		this.id = 0;
		this.horseGo = null;
	}

	private void Update()
	{
		if (this.horseTrans != null && this._self.model != null)
		{
			this._self.model.transform.position = this.horseTrans.position + this.ridePosition;
		}
	}

	public void SetHorseData(float x, float y, float z, string rideRunAudio)
	{
		if (this.horseGo != null)
		{
			this._self.roleAction.horseAnimator = this.horseGo.GetComponent<Animator>();
			this.ridePosition = new Vector3(x, y, z);
			if (this._self.entityType == RoleManager.EntityType.EntityType_Partner)
			{
				this._self.model.transform.localPosition = new Vector3(x, y, z);
				if (this._self.lingqin > 0 && this._self.lingqin_model != null)
				{
					this._self.lingqin_model.transform.localPosition = new Vector3(x, y, z);
				}
			}
			this.rideRunAudioName = rideRunAudio;
			if (string.IsNullOrEmpty(this.rideRunAudioName))
			{
				this.rideRunAudioName = "horse-move";
			}
		}
	}

	public void RideHorse(bool ride)
	{
		if (this._self.model == null)
		{
			return;
		}
		if (ride && this.horseGo == null)
		{
			Util.CallMethod("PLAYERLOADER", "LoadHorse", new object[]
			{
				this._self,
				this._self.entityType,
				this.id
			});
			if ((this._self.entityType == RoleManager.EntityType.EntityType_Self && this.horseGo != null) || (this._self.entityType == RoleManager.EntityType.EntityType_Partner && this._self.ownerId == Singleton<RoleManager>.Instance.mainRole.id))
			{
				this._self.ChangeShader(this.horseGo);
			}
			this.horseTrans = Util.Find(this.horseGo.transform, "zuoqi01");
			if (this.horseParticle != null)
			{
				GameObject gameObject = this.horseParticle.Spawn(null, this._self.transform.position);
				gameObject.transform.GetOrAddComponent<AutoRecycle>().Play();
			}
		}
		else if (!ride && this.horseGo != null)
		{
			this.horseTrans = null;
			this.Recycle();
			this._self.model.transform.localPosition = Vector3.zero;
			this._self.roleAction.horseAnimator = null;
			if (this.horseParticle != null)
			{
				GameObject gameObject2 = this.horseParticle.Spawn(null, this._self.transform.position);
				gameObject2.transform.GetOrAddComponent<AutoRecycle>().Play();
			}
		}
	}

	public void ChangeHorse(int horseId)
	{
		if (horseId == this.id)
		{
			return;
		}
		this.id = horseId;
		if (this._self.isRide)
		{
			this.horseTrans = null;
			this.Recycle();
			Util.CallMethod("PLAYERLOADER", "LoadHorse", new object[]
			{
				this._self,
				this._self.entityType,
				this.id
			});
			if ((this._self.entityType == RoleManager.EntityType.EntityType_Self && this.horseGo != null) || (this._self.entityType == RoleManager.EntityType.EntityType_Partner && this._self.ownerId == Singleton<RoleManager>.Instance.mainRole.id))
			{
				this._self.ChangeShader(this.horseGo);
				this._self.roleAction.horseAnimator = this.horseGo.GetComponent<Animator>();
				if (this._self.roleAction.curNextStatus == 19)
				{
					this._self.roleAction.horseAnimator.SetInteger("status", 1);
				}
				else
				{
					this._self.roleAction.horseAnimator.SetInteger("status", 2);
				}
			}
			this.horseTrans = Util.Find(this.horseGo.transform, "zuoqi01");
		}
	}

	public void Recycle()
	{
		if (this.horseGo != null)
		{
			this.horseGo.Recycle();
			this.horseGo = null;
		}
	}
}
