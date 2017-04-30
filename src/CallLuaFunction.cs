using LuaInterface;
using System;
using UnityEngine;

public class CallLuaFunction : MonoBehaviour
{
	private string script = "  function luaFunc(num)                        \r\n                return num + 1\r\n            end\r\n\r\n            test = {}\r\n            test.luaFunc = luaFunc\r\n        ";

	private LuaFunction func;

	private LuaState lua;

	private string tips;

	private void Start()
	{
		Application.logMessageReceived += new Application.LogCallback(this.ShowTips);
		this.lua = new LuaState();
		this.lua.Start();
		this.lua.DoString(this.script, "LuaState.cs");
		this.func = this.lua.GetFunction("test.luaFunc", true);
		if (this.func != null)
		{
			object[] array = this.func.Call(new object[]
			{
				123456
			});
			Debugger.Log("generic call return: {0}", array[0]);
			int num = this.CallFunc();
			Debugger.Log("expansion call return: {0}", num);
		}
		this.lua.CheckTop();
	}

	private void ShowTips(string msg, string stackTrace, LogType type)
	{
		this.tips += msg;
		this.tips += "\r\n";
	}

	private void OnGUI()
	{
		GUI.Label(new Rect((float)(Screen.width / 2 - 200), (float)(Screen.height / 2 - 150), 400f, 300f), this.tips);
	}

	private void OnDestroy()
	{
		if (this.func != null)
		{
			this.func.Dispose();
			this.func = null;
		}
		this.lua.Dispose();
		this.lua = null;
		Application.logMessageReceived -= new Application.LogCallback(this.ShowTips);
	}

	private int CallFunc()
	{
		this.func.BeginPCall();
		this.func.Push(123456);
		this.func.PCall();
		int result = (int)this.func.CheckNumber();
		this.func.EndPCall();
		return result;
	}
}
