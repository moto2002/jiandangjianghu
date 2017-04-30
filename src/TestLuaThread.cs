using LuaInterface;
using System;
using UnityEngine;

public class TestLuaThread : MonoBehaviour
{
	private string script = "\r\n            function fib(n)\r\n                local a, b = 0, 1\r\n                while n > 0 do\r\n                    a, b = b, a + b\r\n                    n = n - 1\r\n                end\r\n\r\n                return a\r\n            end\r\n\r\n            function CoFunc(len)\r\n                print('Coroutine started')                \r\n                local i = 0\r\n                for i = 0, len, 1 do                    \r\n                    local flag = coroutine.yield(fib(i))\t\t\t\t\t\r\n                    if not flag then\r\n                        break\r\n                    end                                      \r\n                end\r\n                print('Coroutine ended')\r\n            end\r\n\r\n            function Test()                \r\n                local co = coroutine.create(CoFunc)                                \r\n                return co\r\n            end            \r\n        ";

	private LuaState state;

	private LuaThread thread;

	private void Start()
	{
		this.state = new LuaState();
		this.state.Start();
		this.state.LogGC = true;
		this.state.DoString(this.script, "LuaState.cs");
		LuaFunction function = this.state.GetFunction("Test", true);
		function.BeginPCall();
		function.PCall();
		this.thread = function.CheckLuaThread();
		this.thread.name = "LuaThread";
		function.EndPCall();
		function.Dispose();
		this.thread.Resume(new object[]
		{
			10
		});
	}

	private void OnDestroy()
	{
		if (this.thread != null)
		{
			this.thread.Dispose();
			this.thread = null;
		}
		this.state.Dispose();
		this.state = null;
	}

	private void Update()
	{
		this.state.CheckTop();
		this.state.Collect();
	}

	private void OnGUI()
	{
		if (GUI.Button(new Rect(10f, 10f, 120f, 40f), "Resume Thead"))
		{
			if (this.thread != null && this.thread.Resume(new object[]
			{
				true
			}) == 1)
			{
				object[] result = this.thread.GetResult();
				Debugger.Log("lua yield: " + result[0]);
			}
		}
		else if (GUI.Button(new Rect(10f, 60f, 120f, 40f), "Close Thread") && this.thread != null)
		{
			this.thread.Dispose();
			this.thread = null;
		}
	}
}
