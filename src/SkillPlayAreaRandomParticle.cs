using System;
using UnityEngine;

public class SkillPlayAreaRandomParticle : SkillBase
{
	public float delay;

	public int particleNums;

	public GameObject particle;

	public string mountOfStartGo = "Bone001";

	public float radius;

	public float duration;

	public Vector3 distance;

	public bool particleAutoDestroy = true;

	private float startTime;

	public override void StartSkill(float speed)
	{
		this.delay += this.delay - this.delay * speed;
	}

	private void Update()
	{
		this.delay -= Time.deltaTime;
		if (this.delay <= 0f)
		{
			this.startTime += Time.deltaTime;
			if (this.startTime >= this.duration && this.particleNums > 0)
			{
				this.PlayParticle();
				this.startTime = 0f;
				this.particleNums--;
			}
			if (this.particleNums == 0)
			{
				UnityEngine.Object.Destroy(this);
			}
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
				gameObject.transform.parent = transform;
				Vector3 b = new Vector3(UnityEngine.Random.Range(-this.radius, this.radius), 0f, UnityEngine.Random.Range(-this.radius, this.radius));
				gameObject.transform.localPosition = Vector3.zero + this.distance + b;
				gameObject.transform.localRotation = Quaternion.identity;
				gameObject.AddComponent<SkillClearParticle>().onClear = delegate
				{
					UnityEngine.Object.Destroy(this);
				};
			}
		}
	}
}
