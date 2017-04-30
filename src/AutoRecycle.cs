using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class AutoRecycle : MonoBehaviour
{
	private float delay;

	public void Play()
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
		base.StartCoroutine(this.Recycle());
	}

	[DebuggerHidden]
	private IEnumerator Recycle()
	{
		AutoRecycle.<Recycle>c__Iterator2E <Recycle>c__Iterator2E = new AutoRecycle.<Recycle>c__Iterator2E();
		<Recycle>c__Iterator2E.<>f__this = this;
		return <Recycle>c__Iterator2E;
	}
}
