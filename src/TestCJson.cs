using LuaInterface;
using System;
using UnityEngine;

public class TestCJson : LuaClient
{
	private string script = "\r\n    local json = require 'cjson'\r\n\r\n    function Test(str)\r\n\t    local data = json.decode(str)\r\n        print(data.glossary.title)\r\n\t    s = json.encode(data)\r\n\t    print(s)\r\n    end\r\n";

	protected override LuaFileUtils InitLoader()
	{
		return new LuaResLoader();
	}

	protected override void OpenLibs()
	{
		base.OpenLibs();
		base.OpenCJson();
	}

	protected override void OnLoadFinished()
	{
		base.OnLoadFinished();
		TextAsset textAsset = (TextAsset)Resources.Load("jsonexample", typeof(TextAsset));
		string str = textAsset.ToString();
		this.luaState.DoString(this.script, "LuaState.cs");
		LuaFunction function = this.luaState.GetFunction("Test", true);
		function.BeginPCall();
		function.Push(str);
		function.PCall();
		function.EndPCall();
		function.Dispose();
	}

	protected override void CallMain()
	{
	}
}
