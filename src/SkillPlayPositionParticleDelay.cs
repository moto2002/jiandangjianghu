using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillPlayPositionParticleDelay : SkillBase
{
	public float delay;

	public GameObject particle;

	public bool particleAutoDestroy = true;

	[DebuggerHidden]
	private IEnumerator ApplyTargetEvent()
	{
		SkillPlayPositionParticleDelay.<ApplyTargetEvent>c__Iterator4A <ApplyTargetEvent>c__Iterator4A = new SkillPlayPositionParticleDelay.<ApplyTargetEvent>c__Iterator4A();
		<ApplyTargetEvent>c__Iterator4A.<>f__this = this;
		return <ApplyTargetEvent>c__Iterator4A;
	}

	private void PlayParticle()
	{
		if (this.particle == null)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		Skill component = base.gameObject.GetComponent<Skill>();
		if (component && this.enableParticle)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.particle);
			if (this.particleAutoDestroy && gameObject.GetComponent<ParticleParentAutoDestroy>() == null)
			{
				gameObject.AddComponent<ParticleParentAutoDestroy>();
				gameObject.GetComponent<ParticleParentAutoDestroy>().SetOnce();
			}
			gameObject.transform.localPosition = component.targetPos;
			gameObject.transform.localRotation = Quaternion.identity;
		}
		UnityEngine.Object.Destroy(this);
	}
}
