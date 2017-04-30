using LuaFramework;
using System;
using UnityEngine;

public class AnimationEventReceiver : MonoBehaviour
{
	private SceneEntity self;

	public Action<int> ActionFinish;

	private void OnEnable()
	{
		this.self = base.GetComponentInParent<SceneEntity>();
	}

	private void OnDisable()
	{
	}

	public void OnActionFinished(int actionState)
	{
		if (this.self == null)
		{
			if (this.ActionFinish != null)
			{
				this.ActionFinish(actionState);
			}
			return;
		}
		if (this.self.entityType == RoleManager.EntityType.EntityType_Role)
		{
			this.self.move.canMove = true;
		}
		if (this.self.entityType == RoleManager.EntityType.EntityType_Self)
		{
			if (!this.self.controller.canMove)
			{
				this.self.controller.canMove = true;
			}
			if (this.self.controller.moveType != MoveController.MoveType.None || this.self.runToTarget.HasMoveCmd() || actionState != this.self.roleAction.curStatus)
			{
				return;
			}
		}
		this.self.roleAction.ResetToIdleImmediate();
	}

	public void OnSkillActionStart(int actionState)
	{
	}

	public void OnAttackFinished(int actionState)
	{
		if (this.self == null)
		{
			return;
		}
		if (this.self.entityType == RoleManager.EntityType.EntityType_Role)
		{
			this.self.move.canMove = true;
		}
		if (this.self.entityType != RoleManager.EntityType.EntityType_Self && this.self.entityType != RoleManager.EntityType.EntityType_Role)
		{
			return;
		}
		if (this.self.entityType == RoleManager.EntityType.EntityType_Self && this.self.controller.moveType != MoveController.MoveType.None)
		{
			this.self.controller.canMove = true;
			this.self.roleAction.inAttackCombo = false;
			return;
		}
		if (this.self.roleAction.inAttackCombo)
		{
			this.self.roleAction.curNextStatus = 1;
			this.self.roleAction.curStatus = 1;
			this.self.roleAction.inAttackCombo = false;
			object[] array = Util.CallMethod("HEROSKILLMGR", "SetHeroNextMartial", new object[]
			{
				1,
				0
			});
			if (array.Length > 0 && !(bool)array[0])
			{
				this.self.roleAction.curStatus = actionState;
				this.self.roleAction.curNextStatus = actionState;
			}
		}
	}
}
