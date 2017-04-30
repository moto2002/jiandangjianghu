using System;
using UnityEngine;

public class AnimatorPlayEnd : MonoBehaviour
{
	public bool isPlaying
	{
		get;
		set;
	}

	private void Awake()
	{
		this.isPlaying = true;
	}

	private void Start()
	{
	}

	public void PlayEnd()
	{
		this.isPlaying = false;
	}
}
