using System;
using System.Collections;
using System.Diagnostics;
using ThirdParty;
using UnityEngine;

public class MainScene : MonoBehaviour
{
	public static bool updateEntity;

	private void Start()
	{
		base.StartCoroutine(this._start());
	}

	[DebuggerHidden]
	private IEnumerator _start()
	{
		return new MainScene.<_start>c__Iterator42();
	}

	private void FixedUpdate()
	{
		if (MainScene.updateEntity)
		{
			Singleton<RoleManager>.Instance.entityCreate.DelayAddPlayerAndNpc();
		}
	}

	private void OnDestroy()
	{
		if (Singleton<RoleManager>.Instance)
		{
			Singleton<RoleManager>.Instance.Clear();
		}
		MainScene.updateEntity = false;
	}
}
