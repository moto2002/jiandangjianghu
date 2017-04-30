using LuaInterface;
using System;
using UnityEngine;

public class TestCoroutine : MonoBehaviour
{
	public TextAsset luaFile;

	private LuaState lua;

	private LuaLooper looper;

	private void Awake()
	{
		this.lua = new LuaState();
		this.lua.Start();
		LuaBinder.Bind(this.lua);
		this.looper = base.gameObject.AddComponent<LuaLooper>();
		this.looper.luaState = this.lua;
		this.lua.DoString(this.luaFile.text, "TestCoroutine.cs");
		LuaFunction function = this.lua.GetFunction("TestCortinue", true);
		function.Call();
		function.Dispose();
	}

	private void OnDestroy()
	{
		this.looper.Destroy();
		this.lua.Dispose();
		this.lua = null;
	}

	private void OnGUI()
	{
		if (GUI.Button(new Rect(50f, 50f, 120f, 45f), "Start Counter"))
		{
			LuaFunction function = this.lua.GetFunction("StartDelay", true);
			function.Call();
			function.Dispose();
		}
		else if (GUI.Button(new Rect(50f, 150f, 120f, 45f), "Stop Counter"))
		{
			LuaFunction function2 = this.lua.GetFunction("StopDelay", true);
			function2.Call();
			function2.Dispose();
		}
	}
}
