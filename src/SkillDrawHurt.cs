using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillDrawHurt : SkillBase
{
	public float delay;

	[DebuggerHidden]
	private IEnumerator ApplyTargetEvent()
	{
		SkillDrawHurt.<ApplyTargetEvent>c__Iterator48 <ApplyTargetEvent>c__Iterator = new SkillDrawHurt.<ApplyTargetEvent>c__Iterator48();
		<ApplyTargetEvent>c__Iterator.<>f__this = this;
		return <ApplyTargetEvent>c__Iterator;
	}

	private void DrawHurt()
	{
		Skill component = base.gameObject.GetComponent<Skill>();
		if (component)
		{
		}
		UnityEngine.Object.Destroy(this);
	}
}
