using System;
using UnityEngine;

public class ParticleAutoDestroy : MonoBehaviour
{
	private Animator animator;

	private bool isAddEvent;

	private void Start()
	{
		this.animator = base.gameObject.GetComponent<Animator>();
		if (base.GetComponent<Animation>() && !base.GetComponent<Animation>().isPlaying)
		{
			UnityEngine.Object.Destroy(base.GetComponent<Animation>());
		}
		ParticleSystem component = base.gameObject.GetComponent<ParticleSystem>();
		if (component != null && component.maxParticles > 500)
		{
			if (QualitySettings.GetQualityLevel() == 0)
			{
				component.maxParticles = 600;
			}
			else if (QualitySettings.GetQualityLevel() == 1)
			{
				component.maxParticles = 300;
			}
			else if (QualitySettings.GetQualityLevel() == 2)
			{
				component.maxParticles = 100;
			}
		}
	}

	private void Update()
	{
		if (this.animator && this.animator.GetCurrentAnimatorStateInfo(0).IsName("end"))
		{
			UnityEngine.Object.Destroy(this.animator);
			this.animator = null;
		}
		if (base.GetComponent<ParticleSystem>() && !base.GetComponent<ParticleSystem>().IsAlive())
		{
			UnityEngine.Object.Destroy(base.GetComponent<ParticleSystem>());
		}
		if (base.GetComponent<Animation>() && (base.GetComponent<Animation>().wrapMode == WrapMode.Once || base.GetComponent<Animation>().clip.wrapMode == WrapMode.Once) && !this.isAddEvent)
		{
			this.isAddEvent = true;
			base.GetComponent<Animation>().clip.AddEvent(new AnimationEvent
			{
				functionName = "DestroyAnimation",
				time = base.GetComponent<Animation>().clip.length
			});
		}
		if (!this.animator && !base.GetComponent<ParticleSystem>() && !base.GetComponent<Animation>())
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void DestroyAnimation()
	{
		UnityEngine.Object.Destroy(base.GetComponent<Animation>());
	}
}
