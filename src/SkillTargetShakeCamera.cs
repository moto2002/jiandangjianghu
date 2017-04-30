using System;
using System.Collections;
using System.Diagnostics;
using ThirdParty;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillTargetShakeCamera : SkillBase
{
	public float delay;

	public Vector3 shakeAmount;

	public float time;

	public float rate;

	private void ApplyTargetEvent()
	{
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
		SkillTargetShakeCamera.<ShakeCamera>c__Iterator4E <ShakeCamera>c__Iterator4E = new SkillTargetShakeCamera.<ShakeCamera>c__Iterator4E();
		<ShakeCamera>c__Iterator4E.<>f__this = this;
		return <ShakeCamera>c__Iterator4E;
	}
}
