using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TestPerformance : MonoBehaviour
{
	private LuaState state;

	private string tips = string.Empty;

	private void Start()
	{
		Application.logMessageReceived += new Application.LogCallback(this.ShowTips);
		new LuaResLoader();
		this.state = new LuaState();
		this.state.Start();
		LuaBinder.Bind(this.state);
		this.state.DoFile("TestPerf.lua");
		this.state.LuaGC(LuaGCOptions.LUA_GCCOLLECT, 0);
		this.state.LogGC = false;
		Debug.Log(typeof(List<int>).BaseType);
	}

	private void ShowTips(string msg, string stackTrace, LogType type)
	{
		this.tips += msg;
		this.tips += "\r\n";
	}

	private void OnApplicationQuit()
	{
		Application.logMessageReceived -= new Application.LogCallback(this.ShowTips);
		this.state.Dispose();
		this.state = null;
	}

	private void OnGUI()
	{
		GUI.Label(new Rect((float)(Screen.width / 2 - 200), (float)(Screen.height / 2 - 100), 400f, 300f), this.tips);
		if (GUI.Button(new Rect(50f, 50f, 120f, 45f), "Test1"))
		{
			float num = Time.realtimeSinceStartup;
			for (int i = 0; i < 200000; i++)
			{
				Vector3 position = base.transform.position;
				base.transform.position = position + Vector3.one;
			}
			num = Time.realtimeSinceStartup - num;
			this.tips = string.Empty;
			Debugger.Log("c# Transform getset cost time: " + num);
			base.transform.position = Vector3.zero;
			LuaFunction function = this.state.GetFunction("Test1", true);
			function.BeginPCall();
			function.Push(base.transform);
			function.PCall();
			function.EndPCall();
			function.Dispose();
		}
		else if (GUI.Button(new Rect(50f, 150f, 120f, 45f), "Test2"))
		{
			float num2 = Time.realtimeSinceStartup;
			for (int j = 0; j < 200000; j++)
			{
				base.transform.Rotate(Vector3.up, 1f);
			}
			num2 = Time.realtimeSinceStartup - num2;
			this.tips = string.Empty;
			Debugger.Log("c# Transform.Rotate cost time: " + num2);
			LuaFunction function2 = this.state.GetFunction("Test2", true);
			function2.BeginPCall();
			function2.Push(base.transform);
			function2.PCall();
			function2.EndPCall();
			function2.Dispose();
		}
		else if (GUI.Button(new Rect(50f, 250f, 120f, 45f), "Test3"))
		{
			float num3 = Time.realtimeSinceStartup;
			for (int k = 0; k < 2000000; k++)
			{
				new Vector3((float)k, (float)k, (float)k);
			}
			num3 = Time.realtimeSinceStartup - num3;
			this.tips = string.Empty;
			Debugger.Log("c# new Vector3 cost time: " + num3);
			LuaFunction function3 = this.state.GetFunction("Test3", true);
			function3.Call();
			function3.Dispose();
		}
		else if (GUI.Button(new Rect(50f, 350f, 120f, 45f), "Test4"))
		{
			float num4 = Time.realtimeSinceStartup;
			for (int l = 0; l < 20000; l++)
			{
				new GameObject();
			}
			num4 = Time.realtimeSinceStartup - num4;
			this.tips = string.Empty;
			Debugger.Log("c# new GameObject cost time: " + num4);
			LuaFunction function4 = this.state.GetFunction("Test4", true);
			function4.Call();
			function4.Dispose();
		}
		else if (GUI.Button(new Rect(50f, 450f, 120f, 45f), "Test5"))
		{
			int[] array = new int[1024];
			for (int m = 0; m < 1024; m++)
			{
				array[m] = m;
			}
			float num5 = Time.realtimeSinceStartup;
			int num6 = 0;
			for (int n = 0; n < 100000; n++)
			{
				for (int num7 = 0; num7 < 1024; num7++)
				{
					num6 += array[num7];
				}
			}
			num5 = Time.realtimeSinceStartup - num5;
			this.tips = string.Empty;
			Debugger.Log("Array cost time: " + num5);
			List<int> list = new List<int>(array);
			num5 = Time.realtimeSinceStartup;
			num6 = 0;
			for (int num8 = 0; num8 < 100000; num8++)
			{
				for (int num9 = 0; num9 < 1024; num9++)
				{
					num6 += list[num9];
				}
			}
			num5 = Time.realtimeSinceStartup - num5;
			this.tips = string.Empty;
			Debugger.Log("Array cost time: " + num5);
			LuaFunction function5 = this.state.GetFunction("TestTable", true);
			function5.Call();
			function5.Dispose();
		}
		else if (GUI.Button(new Rect(50f, 550f, 120f, 40f), "Test7"))
		{
			float num10 = Time.realtimeSinceStartup;
			Vector3 b = Vector3.zero;
			for (int num11 = 0; num11 < 200000; num11++)
			{
				Vector3 vector = new Vector3((float)num11, (float)num11, (float)num11);
				vector = Vector3.Normalize(vector);
				b = vector + b;
			}
			num10 = Time.realtimeSinceStartup - num10;
			this.tips = string.Empty;
			Debugger.Log("Vector3 New Normalize cost: " + num10);
			LuaFunction function6 = this.state.GetFunction("Test7", true);
			function6.Call();
			function6.Dispose();
		}
		else if (GUI.Button(new Rect(250f, 50f, 120f, 40f), "Test8"))
		{
			float num12 = Time.realtimeSinceStartup;
			for (int num13 = 0; num13 < 200000; num13++)
			{
				Quaternion a = Quaternion.Euler((float)num13, (float)num13, (float)num13);
				Quaternion b2 = Quaternion.Euler((float)(num13 * 2), (float)(num13 * 2), (float)(num13 * 2));
				Quaternion.Slerp(a, b2, 0.5f);
			}
			num12 = Time.realtimeSinceStartup - num12;
			this.tips = string.Empty;
			Debugger.Log("Quaternion Euler Slerp cost: " + num12);
			LuaFunction function7 = this.state.GetFunction("Test8", true);
			function7.Call();
			function7.Dispose();
		}
		else if (GUI.Button(new Rect(250f, 150f, 120f, 40f), "Test9"))
		{
			this.tips = string.Empty;
			LuaFunction function8 = this.state.GetFunction("Test9", true);
			function8.Call();
			function8.Dispose();
		}
		else if (GUI.Button(new Rect(250f, 250f, 120f, 40f), "Quit"))
		{
			Application.Quit();
		}
		this.state.CheckTop();
		this.state.Collect();
	}
}
