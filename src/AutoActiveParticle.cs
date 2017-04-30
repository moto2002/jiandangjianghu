using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class AutoActiveParticle : MonoBehaviour
{
	private float delay;

	private void OnEnable()
	{
		ParticleSystem[] componentsInChildren = base.gameObject.GetComponentsInChildren<ParticleSystem>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].duration + componentsInChildren[i].startDelay > this.delay)
			{
				this.delay = componentsInChildren[i].duration + componentsInChildren[i].startDelay;
			}
			componentsInChildren[i].Play();
		}
		base.StartCoroutine(this.AutoDisable());
	}

	[DebuggerHidden]
	private IEnumerator AutoDisable()
	{
		AutoActiveParticle.<AutoDisable>c__Iterator39 <AutoDisable>c__Iterator = new AutoActiveParticle.<AutoDisable>c__Iterator39();
		<AutoDisable>c__Iterator.<>f__this = this;
		return <AutoDisable>c__Iterator;
	}
}
