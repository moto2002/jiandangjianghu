using LuaInterface;
using System;
using UnityEngine;

public class ScriptsFromFile : MonoBehaviour
{
	private LuaState lua;

	private string strLog = string.Empty;

	private void Start()
	{
		Application.logMessageReceived += new Application.LogCallback(this.Log);
		this.lua = new LuaState();
		this.lua.Start();
		string fullPath = Application.dataPath + "\\LuaFramework/ToLua/Examples/02_ScriptsFromFile";
		this.lua.AddSearchPath(fullPath);
	}

	private void Log(string msg, string stackTrace, LogType type)
	{
		this.strLog += msg;
		this.strLog += "\r\n";
	}

	private void OnGUI()
	{
		GUI.Label(new Rect(100f, (float)(Screen.height / 2 - 100), 600f, 400f), this.strLog);
		if (GUI.Button(new Rect(50f, 50f, 120f, 45f), "DoFile"))
		{
			this.strLog = string.Empty;
			this.lua.DoFile("ScriptsFromFile.lua");
		}
		else if (GUI.Button(new Rect(50f, 150f, 120f, 45f), "Require"))
		{
			this.strLog = string.Empty;
			this.lua.Require("ScriptsFromFile");
		}
		this.lua.Collect();
		this.lua.CheckTop();
	}

	private void OnApplicationQuit()
	{
		this.lua.Dispose();
		this.lua = null;
		Application.logMessageReceived -= new Application.LogCallback(this.Log);
	}
}
