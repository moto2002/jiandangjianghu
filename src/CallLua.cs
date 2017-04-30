using LuaFramework;
using System;
using UnityEngine;

public class CallLua : MonoBehaviour
{
	public string module;

	public string func;

	private void Start()
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer)
		{
			UIRoot component = base.GetComponent<UIRoot>();
			component.scalingStyle = UIRoot.Scaling.Flexible;
			component.minimumHeight = 1080;
		}
		if (!string.IsNullOrEmpty(this.module) && !string.IsNullOrEmpty(this.func))
		{
			Util.CallMethod(this.module, this.func, new object[0]);
		}
		UnityEngine.Object.Destroy(this);
	}
}
