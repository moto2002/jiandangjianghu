using System;
using UnityEngine;

public class OnDestroyAction : MonoBehaviour
{
	public Action Action
	{
		get;
		set;
	}

	private void OnDestroy()
	{
		if (this.Action != null)
		{
			this.Action();
		}
	}
}
