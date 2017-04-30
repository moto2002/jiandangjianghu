using LuaInterface;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class TestABLoader : MonoBehaviour
{
	private int bundleCount = 2147483647;

	private string tips;

	[DebuggerHidden]
	private IEnumerator CoLoadBundle(string name, string path)
	{
		TestABLoader.<CoLoadBundle>c__Iterator26 <CoLoadBundle>c__Iterator = new TestABLoader.<CoLoadBundle>c__Iterator26();
		<CoLoadBundle>c__Iterator.path = path;
		<CoLoadBundle>c__Iterator.name = name;
		<CoLoadBundle>c__Iterator.<$>path = path;
		<CoLoadBundle>c__Iterator.<$>name = name;
		<CoLoadBundle>c__Iterator.<>f__this = this;
		return <CoLoadBundle>c__Iterator;
	}

	[DebuggerHidden]
	private IEnumerator LoadFinished()
	{
		TestABLoader.<LoadFinished>c__Iterator27 <LoadFinished>c__Iterator = new TestABLoader.<LoadFinished>c__Iterator27();
		<LoadFinished>c__Iterator.<>f__this = this;
		return <LoadFinished>c__Iterator;
	}

	[DebuggerHidden]
	public IEnumerator LoadBundles()
	{
		TestABLoader.<LoadBundles>c__Iterator28 <LoadBundles>c__Iterator = new TestABLoader.<LoadBundles>c__Iterator28();
		<LoadBundles>c__Iterator.<>f__this = this;
		return <LoadBundles>c__Iterator;
	}

	private void Awake()
	{
		Application.logMessageReceived += new Application.LogCallback(this.ShowTips);
		LuaFileUtils luaFileUtils = new LuaFileUtils();
		luaFileUtils.beZip = true;
		base.StartCoroutine(this.LoadBundles());
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

	private void OnApplicationQuit()
	{
		Application.logMessageReceived -= new Application.LogCallback(this.ShowTips);
	}

	private void OnBundleLoad()
	{
		LuaState luaState = new LuaState();
		luaState.Start();
		luaState.DoString("print('hello tolua#:'..tostring(Vector3.zero))", "LuaState.cs");
		luaState.DoFile("Main.lua");
		LuaFunction function = luaState.GetFunction("Main", true);
		function.Call();
		function.Dispose();
		luaState.Dispose();
	}
}
