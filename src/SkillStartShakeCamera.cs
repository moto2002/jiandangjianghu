using System;
using System.Collections;
using System.Diagnostics;
using ThirdParty;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillStartShakeCamera : SkillBase
{
	public float delay;

	public Vector3 shakeAmount;

	public float time;

	public float rate;

	public override void StartSkill(float speed)
	{
		this.delay += this.delay - this.delay * speed;
		Skill component = base.gameObject.GetComponent<Skill>();
		if (component == null || component.startGo == null)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		SceneEntity component2 = component.startGo.GetComponent<SceneEntity>();
		if (component2 == null)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		if (component2.entityType == RoleManager.EntityType.EntityType_Self && Singleton<RoleManager>.Instance.mainCamera != null)
		{
			base.StartCoroutine(this.ShakeCamera());
		}
	}

	[DebuggerHidden]
	private IEnumerator ShakeCamera()
	{
		SkillStartShakeCamera.<ShakeCamera>c__Iterator4D <ShakeCamera>c__Iterator4D = new SkillStartShakeCamera.<ShakeCamera>c__Iterator4D();
		<ShakeCamera>c__Iterator4D.<>f__this = this;
		return <ShakeCamera>c__Iterator4D;
	}
}
