using System;
using UnityEngine;

public class BaseScene : MonoBehaviour
{
	public static bool updateEntity;

	public static bool loadingFinished;

	private bool _createJumpGate;

	private void Awake()
	{
		BaseScene.loadingFinished = false;
	}

	public void Initilize()
	{
	}

	public void UpdateEntity()
	{
	}

	private void OnDestroy()
	{
		BaseScene.loadingFinished = false;
	}
}
