using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillForceBack : SkillBase
{
	[DebuggerHidden]
	private IEnumerator ApplyTargetEvent()
	{
		SkillForceBack.<ApplyTargetEvent>c__Iterator49 <ApplyTargetEvent>c__Iterator = new SkillForceBack.<ApplyTargetEvent>c__Iterator49();
		<ApplyTargetEvent>c__Iterator.<>f__this = this;
		return <ApplyTargetEvent>c__Iterator;
	}

	private void Forceback()
	{
		Skill component = base.gameObject.GetComponent<Skill>();
		if (component)
		{
		}
		UnityEngine.Object.Destroy(this);
	}
}
