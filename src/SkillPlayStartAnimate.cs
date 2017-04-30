using System;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillPlayStartAnimate : SkillBase
{
	public RoleAction.state state;

	public override void StartSkill(float speed)
	{
		if (this.state == RoleAction.state.none)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		Skill component = base.gameObject.GetComponent<Skill>();
		if (component && component.startGo)
		{
			Move component2 = component.startGo.GetComponent<Move>();
			if (component2 != null && component2.InMoving())
			{
				component2.StopPath();
			}
			SceneEntity component3 = component.startGo.GetComponent<SceneEntity>();
			if (component3 && component3.hp > 0)
			{
				component3.roleAction.SetActionStatus((int)this.state);
			}
		}
		UnityEngine.Object.Destroy(this);
	}

	private void OnDestroy()
	{
	}
}
