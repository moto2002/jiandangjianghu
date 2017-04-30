using LuaInterface;
using System;
using UnityEngine;

public class TestCoroutine2 : LuaClient
{
	private string script = "\r\n        function CoExample()            \r\n            WaitForSeconds(1)\r\n            print('WaitForSeconds end time: '.. UnityEngine.Time.time)            \r\n            WaitForFixedUpdate()\r\n            print('WaitForFixedUpdate end frameCount: '..UnityEngine.Time.frameCount)\r\n            WaitForEndOfFrame()\r\n            print('WaitForEndOfFrame end frameCount: '..UnityEngine.Time.frameCount)\r\n            Yield(null)\r\n            print('yield null end frameCount: '..UnityEngine.Time.frameCount)\r\n            Yield(0)\r\n            print('yield(0) end frameCime: '..UnityEngine.Time.frameCount)\r\n            local www = UnityEngine.WWW('http://www.baidu.com')\r\n            Yield(www)\r\n            print('yield(www) end time: '.. UnityEngine.Time.time)\r\n            local s = tolua.tolstring(www.bytes)\r\n            print(s:sub(1, 128))\r\n            print('coroutine over')\r\n        end\r\n\r\n        function TestCo()            \r\n            StartCoroutine(CoExample)                                   \r\n        end\r\n\r\n        local coDelay = nil\r\n\r\n        function Delay()\r\n\t        local c = 1\r\n\r\n\t        while true do\r\n\t\t        WaitForSeconds(1) \r\n\t\t        print('Count: '..c)\r\n\t\t        c = c + 1\r\n\t        end\r\n        end\r\n\r\n        function StartDelay()\r\n\t        coDelay = StartCoroutine(Delay)            \r\n        end\r\n\r\n        function StopDelay()\r\n\t        StopCoroutine(coDelay)\r\n            coDelay = nil\r\n        end\r\n    ";

	private bool beStart;

	protected override void OnLoadFinished()
	{
		base.OnLoadFinished();
		this.luaState.DoString(this.script, "TestCoroutine2.cs");
		LuaFunction function = this.luaState.GetFunction("TestCo", true);
		function.Call();
		function.Dispose();
	}

	protected override void CallMain()
	{
	}

	private void OnGUI()
	{
		if (GUI.Button(new Rect(50f, 50f, 120f, 45f), "Start Counter"))
		{
			if (!this.beStart)
			{
				this.beStart = true;
				LuaFunction function = this.luaState.GetFunction("StartDelay", true);
				function.Call();
				function.Dispose();
			}
		}
		else if (GUI.Button(new Rect(50f, 150f, 120f, 45f), "Stop Counter") && this.beStart)
		{
			this.beStart = false;
			LuaFunction function2 = this.luaState.GetFunction("StopDelay", true);
			function2.Call();
			function2.Dispose();
		}
	}
}
