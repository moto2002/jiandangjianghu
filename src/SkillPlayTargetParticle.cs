using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillPlayTargetParticle : SkillBase
{
	public float delay;

	public GameObject particle;

	public string mountOfTargetGo = "Bip001 Spine1";

	public bool particleAutoDestroy = true;

	[DebuggerHidden]
	private IEnumerator ApplyTargetEvent()
	{
		SkillPlayTargetParticle.<ApplyTargetEvent>c__Iterator4C <ApplyTargetEvent>c__Iterator4C = new SkillPlayTargetParticle.<ApplyTargetEvent>c__Iterator4C();
		<ApplyTargetEvent>c__Iterator4C.<>f__this = this;
		return <ApplyTargetEvent>c__Iterator4C;
	}

	private void PlayParticle()
	{
		if (this.particle == null)
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
					Transform transform = SkillBase.Find(component.targetGos[i].transform, this.mountOfTargetGo);
					if (!transform)
					{
						transform = component.targetGos[i].transform;
					}
					if (this.enableParticle)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.particle);
						if (this.particleAutoDestroy && gameObject.GetComponent<ParticleParentAutoDestroy>() == null)
						{
							gameObject.AddComponent<ParticleParentAutoDestroy>();
							gameObject.GetComponent<ParticleParentAutoDestroy>().SetOnce();
						}
						gameObject.transform.parent = transform;
						gameObject.transform.localPosition = Vector3.zero;
						gameObject.transform.localRotation = Quaternion.identity;
						gameObject.transform.localScale = Vector3.one;
					}
				}
			}
		}
		UnityEngine.Object.Destroy(this);
	}
}
