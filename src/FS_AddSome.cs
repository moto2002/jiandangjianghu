using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class FS_AddSome : MonoBehaviour
{
	private void Start()
	{
		base.StartCoroutine(this.MakeSomeNewOnes());
	}

	[DebuggerHidden]
	private IEnumerator MakeSomeNewOnes()
	{
		FS_AddSome.<MakeSomeNewOnes>c__Iterator15 <MakeSomeNewOnes>c__Iterator = new FS_AddSome.<MakeSomeNewOnes>c__Iterator15();
		<MakeSomeNewOnes>c__Iterator.<>f__this = this;
		return <MakeSomeNewOnes>c__Iterator;
	}
}
