using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillPlayTargetAnimate : SkillBase
{
	public float delay;

	public RoleAction.state state;

	[DebuggerHidden]
	private IEnumerator ApplyTargetEvent()
	{
		SkillPlayTargetAnimate.<ApplyTargetEvent>c__Iterator4B <ApplyTargetEvent>c__Iterator4B = new SkillPlayTargetAnimate.<ApplyTargetEvent>c__Iterator4B();
		<ApplyTargetEvent>c__Iterator4B.<>f__this = this;
		return <ApplyTargetEvent>c__Iterator4B;
	}

	private void PlayAnimate()
	{
		if (this.state == RoleAction.state.none)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		Skill component = base.gameObject.GetComponent<Skill>();
		if (component)
		{
			for (int i = 0; i < component.targetGos.Count; i++)
			{
				if (!(component.targetGos[i] == null))
				{
					SceneEntity component2 = component.targetGos[i].GetComponent<SceneEntity>();
					if (component2 && component.startGo != null)
					{
						SceneEntity component3 = component.startGo.GetComponent<SceneEntity>();
						if (component3 != null && component3.entityType == RoleManager.EntityType.EntityType_Self && this.state == RoleAction.state.hurt)
						{
							component2.OnHurt();
						}
						if (!component2.roleAction.CancelHurt())
						{
							component2.roleAction.SetActionStatus((int)this.state);
						}
						if (component2.entityType == RoleManager.EntityType.EntityType_Self && component3.entityType == RoleManager.EntityType.EntityType_Role)
						{
							component2.roleState.AddState(1);
						}
					}
				}
			}
		}
		UnityEngine.Object.Destroy(this);
	}
}
