using LuaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class JumpSync : JumpBase
{
	private struct jumpItem
	{
		public int dir;

		public int step;

		public float vertSpeed;

		public float horizSpeed;

		public float horizAccSpeed;

		public float endHorizSpeed;

		public Vector3 curPos;
	}

	private float jumpStartTime;

	private readonly float MAX_JUMP_TIME = 3.5f;

	private Queue<JumpSync.jumpItem> jumpQueue = new Queue<JumpSync.jumpItem>();

	private bool inProcess;

	private float timeSinceLastSync;

	private bool preGrounded;

	private void Start()
	{
	}

	public override void UpdateJump(bool isGrounded, Vector3 finalPosition, bool shakeCamera = false)
	{
		if (this.lastSyncTime > 0f)
		{
			this.timeSinceLastSync += Time.deltaTime;
		}
		if (!isGrounded)
		{
			Vector3 zero = Vector3.zero;
			if (base.jumpMode == 1 || base.jumpMode == 3)
			{
				base.curVertSpeed -= this.gravity * Time.deltaTime;
				this.offsetY += base.curVertSpeed * Time.deltaTime;
				this.offsetX += base.startHorizSpeed * Time.deltaTime;
				Vector3 vector = this._self.transform.forward * this.offsetX;
				zero = new Vector3(base.startPos.x + vector.x, base.startPos.y + this.offsetY, base.startPos.z + vector.z);
				if (base.curVertSpeed <= 0f && base.jumpMode == 1)
				{
					return;
				}
			}
			else if (base.jumpMode == 2)
			{
				base.curHorizSpeed -= base.horizAcceleration * Time.deltaTime;
				this.offsetX += base.curHorizSpeed * Time.deltaTime;
				if (base.curHorizSpeed > base.endHorizSpeed)
				{
					Vector3 vector2 = this._self.transform.forward * this.offsetX;
					zero = new Vector3(base.startPos.x + vector2.x, base.startPos.y + this.offsetY, base.startPos.z + vector2.z);
				}
			}
			if (zero.Equals(Vector3.zero))
			{
				return;
			}
			if (this.jumpStartTime > 0f && Time.realtimeSinceStartup - this.jumpStartTime >= this.MAX_JUMP_TIME && !isGrounded)
			{
				isGrounded = true;
			}
			this._self.transform.position = zero;
		}
		else
		{
			this.JumpClear();
			this.jumpStartTime = 0f;
			this._self.transform.position = finalPosition;
		}
	}

	public override void SyncJump(int dir, int step, float vertSpeed, float horizSpeed, float horizAccSpeed, float horizEndSpeed, float curX, float curY, float curZ, float curTimer)
	{
		if (this._self.entityType == RoleManager.EntityType.EntityType_Self)
		{
			return;
		}
		if (step == 4 && base.jumpMode == 3 && curTimer - this.lastSyncTime < 0.5f)
		{
			return;
		}
		if (base.jumpMode == 0 && step == 2 && this.inProcess)
		{
			this.jumpQueue.Clear();
			this.inProcess = false;
			Debug.LogWarning("清空跳跃队列");
		}
		JumpSync.jumpItem item = default(JumpSync.jumpItem);
		item.dir = dir;
		item.step = step;
		item.vertSpeed = vertSpeed;
		item.horizSpeed = horizSpeed;
		item.horizAccSpeed = horizAccSpeed;
		item.endHorizSpeed = horizEndSpeed;
		item.curPos = new Vector3(curX, curY, curZ);
		this.jumpQueue.Enqueue(item);
		this.lastSyncTime = curTimer;
		this.timeSinceLastSync = 0f;
	}

	public override void OnJumpFinished(int x, int z, float realX, float realY, float realZ, float timer)
	{
		Vector3 vector = Util.Convert2RealPosition(x, z);
		Vector3 vector2 = new Vector3(realX, realY, realZ);
		if (!vector.Equals((Vector3)AstarPath.active.GetNearest(vector2).node.position))
		{
			Debug.LogError("降落点与地图实际点不一致!");
		}
		this.jumpQueue.Clear();
		this.inProcess = false;
		if (base.jumpMode != 0)
		{
			this.UpdateJump(true, vector2, false);
		}
		else if (this.preGrounded)
		{
			this._self.move.WalkTo(vector2, 0.1f, 0, null, false);
		}
		else
		{
			float speed = this._self.move.speed;
			if (timer - this.lastSyncTime > 1f)
			{
				this._self.move.SetServerPos(vector2, speed, 0, 0, 0.1f, true, null);
			}
			else if (Vector3.Distance(this._self.transform.position, vector2) > 1f)
			{
				if (this.jumpQueue.Count > 0)
				{
					this.jumpQueue.Clear();
					this.inProcess = false;
				}
				this._self.move.SetServerPos(vector2, speed, 0, 1, 0.1f, false, null);
			}
		}
		this.preGrounded = false;
	}

	protected override void JumpClear()
	{
		base.JumpClear();
		this._self.move.StopPath();
	}

	private void LateUpdate()
	{
		if (this.jumpQueue.Count > 0 && !this.inProcess)
		{
			this.inProcess = true;
			JumpSync.jumpItem item = this.jumpQueue.Dequeue();
			if (base.jumpMode == 0)
			{
				Vector3 vector = (Vector3)AstarPath.active.GetNearest(this._self.transform.position).node.position;
				Vector3 vector2 = (Vector3)AstarPath.active.GetNearest(item.curPos).node.position;
				if (item.step == 2)
				{
					if (!vector.Equals(vector2))
					{
						this._self.transform.position = item.curPos;
						this.DealJump(item);
					}
					else
					{
						this.DealJump(item);
					}
				}
				else
				{
					if (!vector.Equals(vector2))
					{
						this._self.move.SetServerPos(item.curPos, 5f, 0, 0, 0.1f, false, null);
					}
					this.inProcess = false;
				}
			}
			else if (base.jumpMode == 1)
			{
				if (item.step == 2)
				{
					this.CheckReset(item);
				}
				else
				{
					this.DealJump(item);
				}
			}
			else if (base.jumpMode == 2)
			{
				if (item.step == 3)
				{
					this.CheckReset(item);
				}
				else if (item.step == 4)
				{
					this.DealJump(item);
				}
				else
				{
					this.inProcess = false;
					Debug.LogError("错误!冲刺后收到起跳消息!");
				}
			}
			else if (item.step == 4)
			{
				this.CheckReset(item);
			}
			else if (item.step == 3)
			{
				this.DealJump(item);
			}
			else
			{
				this.inProcess = false;
				Debug.LogError("错误!下落时收到起跳消息!");
			}
		}
	}

	private void CheckReset(JumpSync.jumpItem item)
	{
		if (item.step == 2)
		{
			if (this._self.transform.position.y > item.curPos.y)
			{
				base.curVertSpeed -= 0.5f;
			}
			else if (this._self.transform.position.y < item.curPos.y)
			{
				base.curVertSpeed += 0.5f;
			}
		}
		else if (item.step == 3)
		{
			this._self.transform.position.y = 0f;
			Vector3 curPos = item.curPos;
			curPos.y = 0f;
			if (!(this._self.transform.position - curPos).normalized.Equals(this._self.transform.forward.normalized))
			{
				base.curHorizSpeed -= 0.5f;
			}
		}
		else if (item.step == 4)
		{
			if (this._self.transform.position.y < item.curPos.y)
			{
				base.curVertSpeed += 0.5f;
			}
			else if (this._self.transform.position.y > item.curPos.y)
			{
				base.curVertSpeed -= 0.5f;
			}
		}
		this.inProcess = false;
	}

	private void DealJump(JumpSync.jumpItem item)
	{
		this.StartJump(item);
	}

	private void StartJump(JumpSync.jumpItem item)
	{
		if (Convert.ToInt32(this._self.transform.rotation.eulerAngles.y) != item.dir)
		{
			this._self.transform.rotation = Quaternion.Euler(this._self.transform.rotation.eulerAngles.x, (float)item.dir, this._self.transform.rotation.eulerAngles.z);
		}
		if (item.step == 2)
		{
			this.JumpClear();
			base.jumpMode = 1;
			base.curVertSpeed = item.vertSpeed;
			base.startVertSpeed = item.vertSpeed;
			base.startHorizSpeed = item.horizSpeed;
			base.horizAcceleration = item.horizAccSpeed;
			base.startPos = item.curPos;
			this.curJumpAction = this._self.roleAction.SetRoleJump(0);
			this.jumpStartTime = Time.realtimeSinceStartup;
			this.inProcess = false;
		}
		else if (item.step == 3)
		{
			if (item.curPos.y > this._self.transform.position.y && base.jumpMode == 1)
			{
				float num = item.curPos.y - this._self.transform.position.y;
				base.curVertSpeed = Mathf.Sqrt(item.vertSpeed * item.vertSpeed + 2f * this.gravity * num);
				base.StartCoroutine(this.WaitForJumpDashPosition(item));
			}
			else
			{
				base.jumpMode = 2;
				base.startHorizSpeed = item.horizSpeed;
				base.curHorizSpeed = item.horizSpeed;
				base.endHorizSpeed = item.endHorizSpeed;
				base.horizAcceleration = item.horizAccSpeed;
				this._self.roleAction.SetActionStatus(29);
				this.inProcess = false;
			}
		}
		else
		{
			if (base.jumpMode == 2)
			{
				base.startHorizSpeed = item.endHorizSpeed;
			}
			else
			{
				base.startHorizSpeed = item.horizSpeed;
			}
			if (base.jumpMode != 3)
			{
				base.jumpMode = 3;
			}
			base.curVertSpeed = item.vertSpeed;
			base.horizAcceleration = 0f;
			this._self.roleAction.SetRoleFall(this.curJumpAction);
			this.inProcess = false;
		}
	}

	[DebuggerHidden]
	private IEnumerator WaitForJumpDashPosition(JumpSync.jumpItem item)
	{
		JumpSync.<WaitForJumpDashPosition>c__Iterator3E <WaitForJumpDashPosition>c__Iterator3E = new JumpSync.<WaitForJumpDashPosition>c__Iterator3E();
		<WaitForJumpDashPosition>c__Iterator3E.item = item;
		<WaitForJumpDashPosition>c__Iterator3E.<$>item = item;
		<WaitForJumpDashPosition>c__Iterator3E.<>f__this = this;
		return <WaitForJumpDashPosition>c__Iterator3E;
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (base.jumpMode != 0)
		{
			if (collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
			{
				this.UpdateJump(true, AstarPath.active.GetNearest(this._self.transform.position).clampedPosition, false);
				this.lastSyncTime += this.timeSinceLastSync;
				this.timeSinceLastSync = 0f;
				if (!this.preGrounded)
				{
					this.preGrounded = true;
				}
			}
			else if (collider.gameObject.CompareTag("Wall"))
			{
				if (base.jumpMode != 3)
				{
					base.jumpMode = 3;
				}
				base.startHorizSpeed = 0f;
				base.horizAcceleration = 0f;
				this._self.roleAction.SetRoleFall(this.curJumpAction);
				this.lastSyncTime += this.timeSinceLastSync;
				this.timeSinceLastSync = 0f;
			}
		}
	}
}
