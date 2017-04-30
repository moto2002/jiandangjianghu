using System;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillPlayStartParticle : SkillBase
{
	public float delay;

	public GameObject particle;

	public string mountOfStartGo = "Bone001";

	public Vector3 distance;

	public bool particleAutoDestroy = true;

	public bool particleMoveWithParent;

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
		if (component && component.startGo)
		{
			Transform transform = SkillBase.Find(component.startGo.transform, this.mountOfStartGo);
			if (!transform)
			{
				transform = component.startGo.transform;
			}
			if (this.enableParticle)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.particle);
				if (this.particleAutoDestroy && gameObject.GetComponent<ParticleParentAutoDestroy>() == null)
				{
					gameObject.AddComponent<ParticleParentAutoDestroy>();
					gameObject.GetComponent<ParticleParentAutoDestroy>().SetOnce();
				}
				if (this.particleMoveWithParent)
				{
					gameObject.transform.parent = transform;
					gameObject.transform.localPosition = Vector3.zero + this.distance;
					gameObject.transform.localRotation = Quaternion.identity;
					gameObject.transform.localScale = Vector3.one;
				}
				else
				{
					gameObject.transform.position = transform.position;
					gameObject.transform.rotation = transform.rotation;
				}
			}
		}
		UnityEngine.Object.Destroy(this);
	}
}
