using System;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillFovScale : SkillBase
{
	public float delay;

	public float fov;

	public float toTime;

	public float stayTime;

	public float resetTime;

	public override void StartSkill(float speed)
	{
		Skill component = base.GetComponent<Skill>();
		if (component && component.startGo && Camera.main != null)
		{
			Camera.main.GetOrAddComponent<FovScale>().SetFovValue(this.delay, this.fov, this.toTime, this.resetTime, this.stayTime, component.startGo);
		}
		UnityEngine.Object.Destroy(this);
	}
}
