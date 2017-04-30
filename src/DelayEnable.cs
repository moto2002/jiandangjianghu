using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class DelayEnable : MonoBehaviour
{
	public float delay;

	private BoxCollider bc;

	private Vector3 defaultSize;

	private void Start()
	{
		this.bc = base.GetComponent<BoxCollider>();
		this.defaultSize = this.bc.size;
		this.bc.size = Vector3.one;
		base.StartCoroutine(this.Delay());
	}

	[DebuggerHidden]
	private IEnumerator Delay()
	{
		DelayEnable.<Delay>c__Iterator2F <Delay>c__Iterator2F = new DelayEnable.<Delay>c__Iterator2F();
		<Delay>c__Iterator2F.<>f__this = this;
		return <Delay>c__Iterator2F;
	}
}
