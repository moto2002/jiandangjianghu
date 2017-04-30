using LuaInterface;
using System;
using UnityEngine;

public class TestCustomLoader : LuaClient
{
	private string tips = "Test custom loader";

	protected override LuaFileUtils InitLoader()
	{
		return new LuaResLoader();
	}

	protected override void CallMain()
	{
		LuaFunction function = this.luaState.GetFunction("Test", true);
		function.Call();
		function.Dispose();
	}

	protected override void StartMain()
	{
		this.luaState.DoFile("TestLoader.lua");
		this.CallMain();
	}

	private new void Awake()
	{
		Application.logMessageReceived += new Application.LogCallback(this.Logger);
		base.Awake();
	}

	private new void OnApplicationQuit()
	{
		base.OnApplicationQuit();
		Application.logMessageReceived -= new Application.LogCallback(this.Logger);
	}

	private void Logger(string msg, string stackTrace, LogType type)
	{
		this.tips += msg;
		this.tips += "\r\n";
	}

	private void OnGUI()
	{
		GUI.Label(new Rect((float)(Screen.width / 2 - 200), (float)(Screen.height / 2 - 200), 400f, 400f), this.tips);
	}
}
