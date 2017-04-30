using System;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
	public float lifetime = 2f;

	public Action onDestroyCallback;

	private void Start()
	{
		UnityEngine.Object.Destroy(base.gameObject, this.lifetime);
	}

	private void OnDestroy()
	{
		if (this.onDestroyCallback != null)
		{
			this.onDestroyCallback();
		}
	}
}
