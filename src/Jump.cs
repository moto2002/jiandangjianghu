using LuaFramework;
using Pathfinding;
using System;
using System.Collections.Generic;
using ThirdParty;
using UnityEngine;

public class Jump : JumpBase
{
	private float reachMaxTime;

	private bool endPointReachable = true;

	private float maxJumpHeight;

	private bool isDashed;

	private bool fallWhenReachWalkPoint;

	private bool reachedMaxTime;

	private void Start()
	{
		base.jumpMode = 0;
	}

	public override void UpdateJump(bool isGrounded, Vector3 finalPosition, bool shakeCamera = false)
	{
		if (isGrounded)
		{
			if (shakeCamera)
			{
				base.OnCollision();
			}
			this.JumpClear();
			if (this._self.move.InFindingPath())
			{
				this._self.roleAction.SetRoleMove(0);
			}
			else if (this._self.controller != null && this._self.controller.moveType != MoveController.MoveType.None)
			{
				this._self.roleAction.SetRoleMove(0);
			}
			else
			{
				this._self.roleAction.SetRoleIdle();
			}
			NNInfo nearest = AstarPath.active.GetNearest(finalPosition);
			if (nearest.node.Walkable)
			{
				this._self.transform.position = nearest.clampedPosition;
			}
			else
			{
				Vector3 walkablePointWhenFalldown = this.GetWalkablePointWhenFalldown(nearest.clampedPosition, this._self.transform.forward, -0.5f);
				if (!walkablePointWhenFalldown.Equals(Vector3.zero))
				{
					this._self.transform.position = walkablePointWhenFalldown;
				}
				else
				{
					Debug.LogError("降落目标区域没有可移动的点");
				}
			}
			Singleton<RoleManager>.Instance.cf.jumpMode = base.jumpMode;
			this.SendJumpFinished();
			return;
		}
		this.curTime += Time.deltaTime;
		Vector3 vector = Vector3.zero;
		if (base.jumpMode == 1 || base.jumpMode == 3)
		{
			base.curVertSpeed -= this.gravity * Time.deltaTime;
			this.offsetY += base.curVertSpeed * Time.deltaTime;
			this.offsetX += base.startHorizSpeed * Time.deltaTime;
			Vector3 vector2 = this._self.transform.forward * this.offsetX;
			vector = new Vector3(base.startPos.x + vector2.x, base.startPos.y + this.offsetY, base.startPos.z + vector2.z);
			if (base.curVertSpeed <= 0f && base.jumpMode == 1)
			{
				base.jumpMode = 3;
				this._self.roleAction.SetRoleFall(this.curJumpAction);
				this.lastSyncTime = Time.realtimeSinceStartup;
				Singleton<RoleManager>.Instance.cf.jumpMode = base.jumpMode;
				this.SendJumpMessageToServer(0f, base.curVertSpeed, base.startHorizSpeed, base.horizAcceleration, base.startHorizSpeed, this.lastSyncTime);
			}
		}
		else if (base.jumpMode == 2)
		{
			base.curHorizSpeed -= base.horizAcceleration * Time.deltaTime;
			this.offsetX += base.curHorizSpeed * Time.deltaTime;
			if (this.fallWhenReachWalkPoint && AstarPath.active.GetNearest(this._self.transform.position).node.Walkable)
			{
				this.RoleFall(0f, true);
				return;
			}
			if (base.curHorizSpeed <= base.endHorizSpeed)
			{
				this.RoleFall(base.endHorizSpeed, false);
				return;
			}
			Vector3 vector3 = this._self.transform.forward * this.offsetX;
			vector = new Vector3(base.startPos.x + vector3.x, base.startPos.y + this.offsetY, base.startPos.z + vector3.z);
		}
		if (vector.Equals(Vector3.zero))
		{
			return;
		}
		if ((!this.endPointReachable && base.startHorizSpeed > 0f) || this.reachedMaxTime)
		{
			Vector3 vector4 = this._self.transform.forward * 0.5f;
			Vector3 origin = new Vector3(vector.x + vector4.x, vector.y, vector.z + vector4.z);
			NNInfo nearest2 = AstarPath.active.GetNearest(this._self.transform.position);
			if (base.jumpMode == 2 && Mathf.Abs(nearest2.clampedPosition.y - this._self.transform.position.y) < 0.3f)
			{
				this.RoleFall(0f, true);
				return;
			}
			origin.y += 0.5f;
			RaycastHit[] array = Physics.RaycastAll(origin, Vector3.down, 500f);
			bool flag = false;
			for (int i = 0; i < array.Length; i++)
			{
				NNInfo nearest3 = AstarPath.active.GetNearest(array[i].point);
				if (array[i].transform.gameObject.layer == LayerMask.NameToLayer("Ground") && nearest3.node.Walkable)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				if (this.offsetY < this.maxJumpHeight * 0.1f && this.curTime < 0.1f)
				{
					this.UpdateJump(true, base.startPos, true);
					return;
				}
				if (!nearest2.node.Walkable)
				{
					vector = this.GetWalkablePointWhenFalldown(this._self.transform.position, this._self.transform.forward, -0.5f);
					this.UpdateJump(true, (!vector.Equals(Vector3.zero)) ? vector : base.startPos, true);
					return;
				}
				if (base.jumpMode != 3)
				{
					this.RoleFall(0f, true);
					return;
				}
				base.startHorizSpeed = 0f;
				vector = new Vector3(this._self.transform.position.x, base.startPos.y + this.offsetY, this._self.transform.position.z);
			}
		}
		int groundedState = base.GetGroundedState(vector);
		if (groundedState == 1)
		{
			this._self.transform.position = vector;
			this.UpdateJump(true, this._self.transform.position, false);
		}
		else if (groundedState == 0 || this.endPointReachable)
		{
			this._self.transform.position = vector;
		}
		else if (groundedState == -1)
		{
			this.UpdateJump(true, this._self.transform.position, base.jumpMode != 3);
		}
		if (this.curTime > this.reachMaxTime - 0.2f)
		{
			this.reachedMaxTime = true;
		}
		if (this.curTime > this.MAX_JUMP_PROTECTTIME && base.jumpMode != 0)
		{
			this.BackToStart();
			Debug.LogWarning("超出跳跃最大时间限制");
			return;
		}
		if (this.lastSyncTime > 0f && Time.realtimeSinceStartup - this.lastSyncTime >= 0.5f)
		{
			this.lastSyncTime = Time.realtimeSinceStartup;
			if (base.jumpMode == 1 || base.jumpMode == 3)
			{
				this.SendJumpMessageToServer(0f, base.curVertSpeed, base.startHorizSpeed, base.horizAcceleration, base.endHorizSpeed, this.lastSyncTime);
			}
			else if (base.jumpMode == 2)
			{
				this.SendJumpMessageToServer(0f, base.curVertSpeed, base.curHorizSpeed, base.horizAcceleration, base.endHorizSpeed, this.lastSyncTime);
			}
		}
	}

	private Vector3 GetWalkablePointWhenFalldown(Vector3 position, Vector3 dir, float decrement)
	{
		if (decrement > 0f)
		{
			Debug.LogError("增量只能为负数");
			return Vector3.zero;
		}
		Vector3 position2 = position + dir * decrement;
		NNInfo nearest = AstarPath.active.GetNearest(position2);
		if (nearest.node.Walkable)
		{
			return nearest.clampedPosition;
		}
		return this.GetWalkablePointWhenFalldown(position, dir, decrement - 0.5f);
	}

	public override void RoleJump(float vertSpeed, float horizSpeed, float dashIncFactor, float horizAccSpeed, float horizEndSpeed)
	{
		this.StartJump(vertSpeed, horizSpeed, dashIncFactor, horizAccSpeed, horizEndSpeed);
	}

	private void StartJump(float vertSpeed, float horizSpeed, float dashIncFactor, float horizAccSpeed, float horizEndSpeed)
	{
		if (!this._self.roleAction.CanJump())
		{
			return;
		}
		if (base.jumpMode == 0)
		{
			if (!this.CanJump())
			{
				return;
			}
			if (this._self.entityType == RoleManager.EntityType.EntityType_Self)
			{
				Singleton<RoleManager>.Instance.cf.CameraTargetToSelf(false);
			}
			this.JumpClear();
			base.jumpMode = 1;
			base.curVertSpeed = vertSpeed;
			base.startVertSpeed = vertSpeed;
			this.maxJumpHeight = base.startVertSpeed * base.startVertSpeed * 0.5f / this.gravity;
			if (this._self.move.InMoving())
			{
				base.startHorizSpeed = this._self.move.speed * this._self.move.speedFactor;
			}
			else
			{
				base.startHorizSpeed = 0f;
			}
			base.curHorizSpeed = base.startHorizSpeed;
			base.endHorizSpeed = base.startHorizSpeed;
			this.endPointReachable = this.IsTargetReachable(base.startHorizSpeed, horizEndSpeed, 0f);
			base.startPos = this._self.transform.position;
			this.curJumpAction = this._self.roleAction.SetRoleJump(0);
			this.lastSyncTime = Time.realtimeSinceStartup;
			Singleton<RoleManager>.Instance.cf.jumpMode = base.jumpMode;
			this.SendJumpMessageToServer(this.reachMaxTime, base.startVertSpeed, base.startHorizSpeed, base.horizAcceleration, base.endHorizSpeed, this.lastSyncTime);
		}
		else if (!this.isDashed)
		{
			if (this.offsetY < this.maxJumpHeight * 0.5f)
			{
				return;
			}
			base.jumpMode = 2;
			this.endPointReachable = this.IsTargetReachable(horizSpeed * dashIncFactor, horizEndSpeed, horizAccSpeed);
			if (!this.endPointReachable)
			{
				if (!this.isJumpDashAvaliable())
				{
					return;
				}
				if (!AstarPath.active.GetNearest(this._self.transform.position).node.Walkable)
				{
					this.fallWhenReachWalkPoint = true;
				}
			}
			base.startHorizSpeed = horizSpeed * dashIncFactor;
			base.curHorizSpeed = base.startHorizSpeed;
			base.horizAcceleration = horizAccSpeed;
			base.endHorizSpeed = horizEndSpeed;
			this.isDashed = true;
			this._self.roleAction.SetActionStatus(29);
			this.lastSyncTime = Time.realtimeSinceStartup;
			Singleton<RoleManager>.Instance.cf.jumpMode = base.jumpMode;
			this.SendJumpMessageToServer(this.reachMaxTime, base.startVertSpeed, base.startHorizSpeed, horizAccSpeed, base.endHorizSpeed, this.lastSyncTime);
		}
	}

	private bool CanJump()
	{
		if (!this._self.move.InMoving())
		{
			return true;
		}
		Vector3 position = this._self.transform.position + this._self.transform.forward * 1f;
		return AstarPath.active.GetNearest(position).node.Walkable;
	}

	private bool isJumpDashAvaliable()
	{
		RaycastHit[] array = Physics.RaycastAll(this._self.transform.position, Vector3.down, 500f);
		bool flag = false;
		for (int i = 0; i < array.Length; i++)
		{
			NNInfo nearest = AstarPath.active.GetNearest(array[i].point);
			if (array[i].transform.gameObject.layer == LayerMask.NameToLayer("Ground") && nearest.node.Walkable)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			Vector3 vector = this._self.transform.forward * 1f;
			Vector3 origin = new Vector3(this._self.transform.position.x + vector.x, this._self.transform.position.y, this._self.transform.position.z + vector.z);
			RaycastHit[] array2 = Physics.RaycastAll(origin, Vector3.down, 500f);
			bool flag2 = false;
			for (int j = 0; j < array2.Length; j++)
			{
				NNInfo nearest2 = AstarPath.active.GetNearest(array2[j].point);
				if (array2[j].transform.gameObject.layer == LayerMask.NameToLayer("Ground") && nearest2.node.Walkable)
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				return false;
			}
		}
		return flag;
	}

	private void SendJumpFinished()
	{
		List<object> list = new List<object>();
		Vector3 vector = Util.Convert2MapPosition(this._self.transform.position.x, this._self.transform.position.z, this._self.transform.position.y);
		list.Add(vector.x);
		list.Add(vector.z);
		list.Add(this._self.transform.position.x);
		list.Add(this._self.transform.position.y);
		list.Add(this._self.transform.position.z);
		list.Add(Time.realtimeSinceStartup);
		this.lastSyncTime = 0f;
		Util.CallMethod("Network", "SendFlyOver", new object[]
		{
			list
		});
	}

	private void SendJumpMessageToServer(float totalTime, float vertSpeed, float horizSpeed, float horizAccSpeed, float horizEndSpeed, float timer)
	{
		List<object> list = new List<object>();
		Vector3 vector = Util.Convert2MapPosition(this._self.transform.position.x, this._self.transform.position.z, this._self.transform.position.y);
		list.Add(vector.x);
		list.Add(vector.z);
		list.Add(vector.y);
		if (base.jumpMode == 1)
		{
			list.Add(2);
		}
		else if (base.jumpMode == 2)
		{
			list.Add(3);
		}
		else
		{
			if (base.jumpMode != 3)
			{
				Debug.LogError("发送跳跃协议错误");
				return;
			}
			list.Add(4);
		}
		list.Add(totalTime);
		list.Add(Convert.ToInt32(this._self.transform.rotation.eulerAngles.y));
		list.Add(vertSpeed);
		list.Add(horizSpeed);
		list.Add(horizAccSpeed);
		list.Add(horizEndSpeed);
		list.Add(this._self.transform.position.x);
		list.Add(this._self.transform.position.y);
		list.Add(this._self.transform.position.z);
		list.Add(timer);
		Util.CallMethod("Network", "SendFly", new object[]
		{
			list
		});
	}

	public void JumpError(int x, int z, float y)
	{
		this._self.transform.position = Util.Convert2RealPosition(x, y, z);
		if (this.curTime > 0f)
		{
			this.SendJumpFinished();
		}
		this.JumpClear();
		this._self.move.StopPath();
	}

	protected override void JumpClear()
	{
		base.JumpClear();
		this.curTime = 0f;
		this.reachMaxTime = 0f;
		this.maxJumpHeight = 0f;
		this.isDashed = false;
		this.fallWhenReachWalkPoint = false;
		this.reachedMaxTime = false;
	}

	protected void RoleFall(float horizEndSpeed = 0f, bool shakeCamera = false)
	{
		if (shakeCamera)
		{
			base.OnCollision();
		}
		if (base.jumpMode != 3)
		{
			if (base.jumpMode == 2)
			{
				this.reachedMaxTime = true;
			}
			base.jumpMode = 3;
		}
		if (base.curVertSpeed > 0f)
		{
			base.curVertSpeed = 0f;
		}
		base.horizAcceleration = 0f;
		base.startHorizSpeed = horizEndSpeed;
		base.curHorizSpeed = horizEndSpeed;
		this._self.roleAction.SetRoleFall(this.curJumpAction);
		this.lastSyncTime = Time.realtimeSinceStartup;
		Singleton<RoleManager>.Instance.cf.jumpMode = base.jumpMode;
		this.SendJumpMessageToServer(0f, base.curVertSpeed, base.curHorizSpeed, base.horizAcceleration, base.endHorizSpeed, this.lastSyncTime);
	}

	private bool IsTargetReachable(float horizStartSpeed, float horizEndSpeed, float horizAccSpeed)
	{
		float num = 0f;
		if (base.jumpMode == 1)
		{
			this.reachMaxTime = base.startVertSpeed / this.gravity * 2f;
			num = horizStartSpeed * this.reachMaxTime;
		}
		else if (base.jumpMode == 2)
		{
			float num2 = (horizStartSpeed - horizEndSpeed) / horizAccSpeed;
			num = horizStartSpeed * num2 - horizAccSpeed * num2 * num2 * 0.5f;
			this.reachMaxTime += num2;
		}
		if (num == 0f)
		{
			return false;
		}
		Vector3 position = this._self.transform.position + this._self.transform.forward * num;
		NNInfo nearest = AstarPath.active.GetNearest(position);
		if (nearest.node == null || !nearest.node.Walkable)
		{
			return false;
		}
		if (base.jumpMode == 1 && nearest.clampedPosition.y > this._self.transform.position.y + 0.1f)
		{
			if (nearest.clampedPosition.y > this._self.transform.position.y + this.maxJumpHeight)
			{
				return false;
			}
			Vector3 position2 = this._self.transform.position + this._self.transform.forward * num * 0.5f;
			NNInfo nearest2 = AstarPath.active.GetNearest(position2);
			float num3 = ((Vector3)nearest2.node.position).y + 0.1f;
			float num4 = this._self.transform.position.y + this.maxJumpHeight;
			if (!nearest2.node.Walkable || num3 > num4)
			{
				return false;
			}
		}
		else if (base.jumpMode == 2 && nearest.clampedPosition.y > this._self.transform.position.y + 0.1f)
		{
			return false;
		}
		nearest.clampedPosition.y = nearest.clampedPosition.y + 0.5f;
		RaycastHit[] array = Physics.RaycastAll(nearest.clampedPosition, Vector3.down, 500f);
		for (int i = 0; i < array.Length; i++)
		{
			Transform transform = array[i].transform;
			NNInfo nearest3 = AstarPath.active.GetNearest(array[i].point);
			if (transform.gameObject.layer == LayerMask.NameToLayer("Ground") && nearest3.node.Walkable)
			{
				return true;
			}
		}
		return false;
	}

	private void BackToStart()
	{
		this.UpdateJump(true, base.startPos, false);
		this._self.roleAction.SetRoleIdle();
		this.SendJumpFinished();
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (base.jumpMode != 0)
		{
			if (collider.gameObject.layer == LayerMask.NameToLayer("Ground") && this.curTime > 0.1f)
			{
				if (base.jumpMode == 2)
				{
					this.RoleFall(0f, false);
				}
				this.UpdateJump(true, AstarPath.active.GetNearest(this._self.transform.position).clampedPosition, false);
			}
			else if (collider.gameObject.CompareTag("Wall"))
			{
				if (!AstarPath.active.GetNearest(this._self.transform.position).node.Walkable)
				{
					this.UpdateJump(true, this._self.transform.position, true);
				}
				else
				{
					this.RoleFall(0f, true);
				}
			}
			else if (collider.gameObject.CompareTag("JumpProtect"))
			{
				this.BackToStart();
			}
		}
	}
}
