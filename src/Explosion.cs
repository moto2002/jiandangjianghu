using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public AnimationCurve animationCurve;

	public float duration;

	private void OnEnable()
	{
		base.StartCoroutine(this.Shrink());
	}

	[DebuggerHidden]
	private IEnumerator Shrink()
	{
		Explosion.<Shrink>c__Iterator18 <Shrink>c__Iterator = new Explosion.<Shrink>c__Iterator18();
		<Shrink>c__Iterator.<>f__this = this;
		return <Shrink>c__Iterator;
	}
}
