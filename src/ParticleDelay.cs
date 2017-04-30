using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class ParticleDelay : MonoBehaviour
{
	public GameObject[] goes;

	public float[] delays;

	private void Start()
	{
		if (this.goes == null)
		{
			return;
		}
		if (this.goes.Length != this.delays.Length)
		{
			Debug.LogError("animator和delay长度不一致!");
			return;
		}
		for (int i = 0; i < this.goes.Length; i++)
		{
			this.goes[i].SetActive(false);
			base.StartCoroutine(this.StartDelay(this.goes[i], this.delays[i]));
		}
	}

	[DebuggerHidden]
	private IEnumerator StartDelay(GameObject go, float delay)
	{
		ParticleDelay.<StartDelay>c__Iterator0 <StartDelay>c__Iterator = new ParticleDelay.<StartDelay>c__Iterator0();
		<StartDelay>c__Iterator.delay = delay;
		<StartDelay>c__Iterator.go = go;
		<StartDelay>c__Iterator.<$>delay = delay;
		<StartDelay>c__Iterator.<$>go = go;
		return <StartDelay>c__Iterator;
	}
}
