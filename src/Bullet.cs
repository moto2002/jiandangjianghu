using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public Explosion explosionPrefab;

	public float shootDistance;

	public float shootSpeed;

	private void OnEnable()
	{
		base.StartCoroutine(this.Shoot());
	}

	private void OnDisable()
	{
		base.StopAllCoroutines();
	}

	[DebuggerHidden]
	private IEnumerator Shoot()
	{
		Bullet.<Shoot>c__Iterator17 <Shoot>c__Iterator = new Bullet.<Shoot>c__Iterator17();
		<Shoot>c__Iterator.<>f__this = this;
		return <Shoot>c__Iterator;
	}
}
