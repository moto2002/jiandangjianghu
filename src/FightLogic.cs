using LuaFramework;
using System;
using ThirdParty;
using UnityEngine;

public class FightLogic : Singleton<FightLogic>
{
	public static FightLogic GetInstance()
	{
		return Singleton<FightLogic>.Instance;
	}

	private void Awake()
	{
	}

	public static Vector3 GetSkillTargetPos(int tx, int ty, string axyz, SceneEntity obj)
	{
		string[] array = axyz.Split(new char[]
		{
			','
		});
		if (array.Length != 3 || (Convert.ToSingle(array[0]).Equals(0f) && Convert.ToSingle(array[1]).Equals(0f)))
		{
			return Util.Convert2RealPosition(tx, ty);
		}
		return new Vector3(Convert.ToSingle(array[0]), Convert.ToSingle(array[2]), Convert.ToSingle(array[1]));
	}

	public void SkillBtnClick()
	{
		if (Singleton<RoleManager>.Instance.mainRole == null)
		{
			return;
		}
		Singleton<RoleManager>.Instance.mainRole.runToTarget.clear();
	}

	public static bool GetCanCastSkill()
	{
		return !(Singleton<RoleManager>.Instance.mainRole == null) && !Singleton<RoleManager>.Instance.mainRole.runToTarget.HasMoveCmd() && Singleton<RoleManager>.Instance.mainRole.controller.moveType != MoveController.MoveType.Joystick && Singleton<RoleManager>.Instance.mainRole.controller.moveType != MoveController.MoveType.Keyboard && Singleton<RoleManager>.Instance.mainRole.move.jumpMode == 0 && !Singleton<RoleManager>.Instance.mainRole.roleAction.Stop() && !Singleton<RoleManager>.Instance.mainRole.roleAction.NeedWaitToIdle();
	}

	public void CancelMove(SceneEntity obj)
	{
		if (obj == null || obj.move == null)
		{
			return;
		}
		obj.move.StopPath();
	}

	public Vector3 GetTargetHeadPos(SceneEntity target)
	{
		if (target == null)
		{
			return Vector3.zero;
		}
		Transform transform = SkillBase.Find(target.model.transform, "Dummy001");
		if (transform == null)
		{
			return Vector3.zero;
		}
		return transform.position;
	}

	public Vector3 GetTargetHurtPos(SceneEntity target)
	{
		if (target == null)
		{
			return Vector3.zero;
		}
		Transform transform = SkillBase.Find(target.model.transform, "Dummy002");
		if (transform == null)
		{
			return Vector3.zero;
		}
		return transform.position;
	}

	public GameObject CastSkill(GameObject go, int skillId, int skillType, int stamp, string folderName, string prefabName, string target_id, Vector3 targetPos, bool needneedFeedback, string[] targetIds, bool isAct)
	{
		SceneEntity component = go.GetComponent<SceneEntity>();
		if (component != null)
		{
			component.castSkill = go.transform.GetOrAddComponent<CastSkill>();
			return component.castSkill.StartSkill(skillId, skillType, stamp, folderName, prefabName, target_id, targetPos, needneedFeedback, targetIds, isAct);
		}
		CastSkill orAddComponent = go.transform.GetOrAddComponent<CastSkill>();
		return orAddComponent.StartSkill(skillId, skillType, stamp, folderName, prefabName, target_id, targetPos, needneedFeedback, targetIds, isAct);
	}

	public void SetSkillInfo(GameObject obj, GameObject skill, int skillType, bool showEff)
	{
		CastSkill component = obj.GetComponent<CastSkill>();
		component.SetSkillInfo(skill, skillType, showEff);
	}

	public void SkillRunToTarget(SceneEntity attacker, GameObject targetGo, float radius, bool needDash)
	{
		if (attacker == null || targetGo == null || attacker.roleAction.Stop())
		{
			return;
		}
		Move.PathFinished pathFinished = new Move.PathFinished(this.OnDashFinished);
		attacker.runToTarget.Target(targetGo, radius, (!needDash) ? null : pathFinished, (!needDash) ? 0 : 1);
		if (attacker.entityType == RoleManager.EntityType.EntityType_Self)
		{
			attacker.roleState.AddState(1);
		}
	}

	private void OnDashFinished()
	{
		Util.CallMethod("HEROSKILLMGR", "SendDashCmd", new object[]
		{
			1
		});
	}
}
