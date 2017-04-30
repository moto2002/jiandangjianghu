using System;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillPlayPositionParticle : SkillBase
{
	public float delay;

	public GameObject particle;

	public bool particleAutoDestroy = true;

	public override void StartSkill(float speed)
	{
		this.delay += this.delay - this.delay * speed;
	}

	private void Update()
	{
		this.delay -= Time.deltaTime;
		if (this.delay <= 0f)
		{
			this.PlayParticle();
		}
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
