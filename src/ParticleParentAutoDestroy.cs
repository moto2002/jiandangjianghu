using System;
using UnityEngine;

public class ParticleParentAutoDestroy : MonoBehaviour
{
	private int maxParticles = 500;

	private void Start()
	{
		float num = 0f;
		if (base.gameObject.GetComponent<ParticleSystem>() != null)
		{
			ParticleSystem component = base.gameObject.GetComponent<ParticleSystem>();
			if (component.startDelay + component.duration > num)
			{
				num = component.startDelay + component.duration;
			}
			if (component != null && component.maxParticles > this.maxParticles)
			{
				if (QualitySettings.GetQualityLevel() == 0)
				{
					component.maxParticles = 100;
				}
				else if (QualitySettings.GetQualityLevel() == 1)
				{
					component.maxParticles = 50;
				}
				else if (QualitySettings.GetQualityLevel() == 2)
				{
					component.maxParticles = 10;
				}
			}
		}
		ParticleSystem[] componentsInChildren = base.gameObject.GetComponentsInChildren<ParticleSystem>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].startDelay + componentsInChildren[i].duration > num)
			{
				num = componentsInChildren[i].startDelay + componentsInChildren[i].duration;
			}
			if (componentsInChildren[i] != null && componentsInChildren[i].maxParticles > this.maxParticles)
			{
				if (QualitySettings.GetQualityLevel() == 0)
				{
					componentsInChildren[i].maxParticles = 100;
				}
				else if (QualitySettings.GetQualityLevel() == 1)
				{
					componentsInChildren[i].maxParticles = 50;
				}
				else if (QualitySettings.GetQualityLevel() == 2)
				{
					componentsInChildren[i].maxParticles = 10;
				}
			}
		}
		Animator[] componentsInChildren2 = base.gameObject.transform.GetComponentsInChildren<Animator>();
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			RuntimeAnimatorController runtimeAnimatorController = componentsInChildren2[j].runtimeAnimatorController;
			for (int k = 0; k < runtimeAnimatorController.animationClips.Length; k++)
			{
				if (runtimeAnimatorController.animationClips[k].length > num)
				{
					num = runtimeAnimatorController.animationClips[k].length;
				}
			}
		}
		AutoDestroy autoDestroy = base.GetComponent<AutoDestroy>();
		if (autoDestroy == null)
		{
			autoDestroy = base.gameObject.AddComponent<AutoDestroy>();
			autoDestroy.lifetime = ((num != 0f) ? num : 2f);
		}
	}

	private void Update()
	{
	}

	public void SetOnce()
	{
		ParticleSystem[] componentsInChildren = base.GetComponentsInChildren<ParticleSystem>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].loop = false;
		}
		Animation[] componentsInChildren2 = base.GetComponentsInChildren<Animation>();
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			componentsInChildren2[j].clip.wrapMode = WrapMode.Once;
			componentsInChildren2[j].wrapMode = WrapMode.Once;
		}
		ParticleAnimator[] componentsInChildren3 = base.GetComponentsInChildren<ParticleAnimator>();
		for (int k = 0; k < componentsInChildren3.Length; k++)
		{
			componentsInChildren3[k].autodestruct = true;
		}
	}
}
