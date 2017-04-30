using System;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
	public enum Type
	{
		BeginToTarget,
		ApplyTargetEvent,
		Both
	}

	[HideInInspector]
	public bool enableParticle = true;

	[HideInInspector]
	public int timestamp;

	public virtual void StartSkill(float speed)
	{
	}

	protected void SetParticleLayer(Transform particle)
	{
		for (int i = 0; i < particle.childCount; i++)
		{
			if (particle.GetChild(i).childCount > 0)
			{
				this.SetParticleLayer(particle.GetChild(i));
			}
			particle.GetChild(i).gameObject.layer = LayerMask.NameToLayer("Effect");
		}
		particle.gameObject.layer = LayerMask.NameToLayer("Effect");
	}

	public static Transform Find(Transform parent, string childname)
	{
		Transform[] componentsInChildren = parent.GetComponentsInChildren<Transform>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].name == childname)
			{
				return componentsInChildren[i];
			}
		}
		return null;
	}
}
