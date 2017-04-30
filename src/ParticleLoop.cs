using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class ParticleLoop : MonoBehaviour
{
	public float loopTime;

	private void Start()
	{
		base.StartCoroutine(this.StartLoop());
	}

	[DebuggerHidden]
	private IEnumerator StartLoop()
	{
		ParticleLoop.<StartLoop>c__Iterator1 <StartLoop>c__Iterator = new ParticleLoop.<StartLoop>c__Iterator1();
		<StartLoop>c__Iterator.<>f__this = this;
		return <StartLoop>c__Iterator;
	}
}
