using System;
using UnityEngine;

public abstract class JumpBase : MonoBehaviour
{
	public enum JumpMode
	{
		None,
		Jump,
		JumpDash,
		Fall,
		PlotJumpWait
	}

	public SceneEntity _self;

	private int _mode;

	[HideInInspector]
	public float offsetY;

	[HideInInspector]
	public float offsetX;

	protected float gravity = 9.80665f;

	protected float lastSyncTime;

	protected int curJumpAction;

	protected float curTime;

	protected float MAX_JUMP_PROTECTTIME = 7f;

	[HideInInspector]
	public int jumpMode
	{
		get
		{
			return this._mode;
		}
		protected set
		{
			this._mode = value;
			if (this._self != null)
			{
				this._self.jumpTrailEffect1Go.SetActive(this._mode != 0);
				this._self.jumpTrailEffect2Go.SetActive(this._mode != 0);
				if (value == 2)
				{
					this._self.jumpChongCiEffectGo.SetActive(true);
				}
			}
		}
	}

	public Vector3 startPos
	{
		get;
		protected set;
	}

	public float startVertSpeed
	{
		get;
		protected set;
	}

	public float curVertSpeed
	{
		get;
		protected set;
	}

	public float horizAcceleration
	{
		get;
		protected set;
	}

	public float startHorizSpeed
	{
		get;
		protected set;
	}

	public float curHorizSpeed
	{
		get;
		protected set;
	}

	public float endHorizSpeed
	{
		get;
		protected set;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public virtual void UpdateJump(bool isGrounded, Vector3 finalPosition, bool shakeCamera = false)
	{
	}

	protected int GetGroundedState(Vector3 curPos)
	{
		RaycastHit[] array = Physics.RaycastAll(curPos, Vector3.down, 500f);
		for (int i = 0; i < array.Length; i++)
		{
			Transform transform = array[i].transform;
			if (transform.gameObject.layer.Equals(LayerMask.NameToLayer("Ground")) && Vector3.Distance(curPos, transform.position) < 0.5f)
			{
				return 1;
			}
		}
		if (array.Length == 0)
		{
			return -1;
		}
		return 0;
	}

	public virtual void RoleJump(float vertSpeed, float horizSpeed, float dashIncFactor, float horizAccSpeed, float horizEndSpeed)
	{
	}

	public virtual void SyncJump(int dir, int type, float vertSpeed, float horizSpeed, float horizAccSpeed, float endHorizSpeed, float curX, float curY, float curZ, float curTimer)
	{
	}

	public virtual void OnJumpFinished(int x, int z, float realX, float realY, float realZ, float timer)
	{
	}

	protected virtual void JumpClear()
	{
		this.jumpMode = 0;
		this.startPos = Vector3.zero;
		this.curVertSpeed = 0f;
		this.startVertSpeed = 0f;
		this.offsetX = 0f;
		this.offsetY = 0f;
		this.startHorizSpeed = 0f;
		this.curHorizSpeed = 0f;
		this.horizAcceleration = 0f;
		this.curJumpAction = 0;
	}

	protected void OnCollision()
	{
	}

	public void StopJump()
	{
		this.JumpClear();
	}
}
