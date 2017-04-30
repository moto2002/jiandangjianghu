using LuaInterface;
using System;
using UnityEngine;

public class TestProtoBuffer : LuaClient
{
	private string script = "      \r\n        local person_pb = require 'Protol.person_pb'\r\n       \r\n        function Decoder()  \r\n            local msg = person_pb.Person()\r\n            msg:ParseFromString(TestProtol.data)\r\n            print('person_pb decoder: '..tostring(msg))\r\n        end\r\n\r\n        function Encoder()                           \r\n            local msg = person_pb.Person()\r\n            msg.id = 1024\r\n            msg.name = 'foo'\r\n            msg.email = 'bar'                                    \r\n            local pb_data = msg:SerializeToString()\r\n            TestProtol.data = pb_data\r\n        end\r\n        ";

	private string tips = string.Empty;

	private new void Awake()
	{
		Application.logMessageReceived += new Application.LogCallback(this.ShowTips);
		base.Awake();
	}

	protected override LuaFileUtils InitLoader()
	{
		return new LuaResLoader();
	}

	protected override void Bind()
	{
		base.Bind();
		this.luaState.BeginModule(null);
		TestProtolWrap.Register(this.luaState);
		this.luaState.EndModule();
	}

	protected override void CallMain()
	{
	}

	protected override void OnLoadFinished()
	{
		base.OnLoadFinished();
		this.luaState.DoString(this.script, "TestProtoBuffer.cs");
		LuaFunction function = this.luaState.GetFunction("Encoder", true);
		function.Call();
		function.Dispose();
		function = this.luaState.GetFunction("Decoder", true);
		function.Call();
		function.Dispose();
	}

	private void ShowTips(string msg, string stackTrace, LogType type)
	{
		this.tips = this.tips + msg + "\r\n";
	}

	private void OnGUI()
	{
		GUI.Label(new Rect((float)(Screen.width / 2 - 200), (float)(Screen.height / 2 - 100), 400f, 300f), this.tips);
	}

	private new void OnApplicationQuit()
	{
		base.Destroy();
		Application.logMessageReceived -= new Application.LogCallback(this.ShowTips);
	}
}
