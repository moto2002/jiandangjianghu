using LuaInterface;
using System;
using UnityEngine;

public class TestReflection : LuaClient
{
	private string script = "    \r\n    require 'tolua.reflection'          \r\n    tolua.loadassembly('Assembly-CSharp')\r\n    tolua.loadassembly('mscorlib')         \r\n    local BindingFlags = require 'System.Reflection.BindingFlags'\r\n\r\n    function DoClick()\r\n        print('do click')        \r\n    end \r\n\r\n    function Test()  \r\n        local t = typeof('TestExport')        \r\n        local func = tolua.getmethod(t, 'TestReflection')           \r\n        func:Call()        \r\n        func:Destroy()\r\n        func = nil\r\n        \r\n        local objs = {Vector3.one, Vector3.zero}\r\n        local array = tolua.toarray(objs, typeof(Vector3))\r\n        local obj = tolua.createinstance(t, array)\r\n        --local constructor = tolua.getconstructor(t, typeof(Vector3):MakeArrayType())\r\n        --local obj = constructor:Call(array)        \r\n        --constructor:Destroy()\r\n\r\n        func = tolua.getmethod(t, 'Test', typeof('System.Int32'):MakeByRefType())        \r\n        local r, o = func:Call(obj, 123)\r\n        print(r..':'..o)\r\n        func:Destroy()\r\n\r\n        local property = tolua.getproperty(t, 'Number')\r\n        local num = property:Get(obj, null)\r\n        print('object Number: '..num)\r\n        property:Set(obj, 456, null)\r\n        num = property:Get(obj, null)\r\n        property:Destroy()\r\n        print('object Number: '..num)\r\n\r\n        local field = tolua.getfield(t, 'field')\r\n        num = field:Get(obj)\r\n        print('object field: '.. num)\r\n        field:Set(obj, 2048)\r\n        num = field:Get(obj)\r\n        field:Destroy()\r\n        print('object field: '.. num)       \r\n        \r\n        field = tolua.getfield(t, 'OnClick')\r\n        local onClick = field:Get(obj)        \r\n        onClick = onClick + DoClick        \r\n        field:Set(obj, onClick)        \r\n        local click = field:Get(obj)\r\n        click:DynamicInvoke()\r\n        field:Destroy()\r\n        click:Destroy()\r\n    end  \r\n";

	private string tips;

	protected override LuaFileUtils InitLoader()
	{
		Application.logMessageReceived += new Application.LogCallback(this.ShowTips);
		return new LuaResLoader();
	}

	protected override void CallMain()
	{
	}

	private void TestAction()
	{
		Debugger.Log("Test Action");
	}

	protected override void OnLoadFinished()
	{
		base.OnLoadFinished();
		this.luaState.CheckTop();
		this.luaState.DoString(this.script, "TestReflection.cs");
		LuaFunction function = this.luaState.GetFunction("Test", true);
		function.Call();
		function.Dispose();
	}

	private void ShowTips(string msg, string stackTrace, LogType type)
	{
		this.tips += msg;
		this.tips += "\r\n";
	}

	private new void OnApplicationQuit()
	{
		Application.logMessageReceived += new Application.LogCallback(this.ShowTips);
		this.Destroy();
	}

	private void OnGUI()
	{
		GUI.Label(new Rect((float)(Screen.width / 2 - 250), (float)(Screen.height / 2 - 150), 500f, 300f), this.tips);
	}
}
