using LuaInterface;
using System;
using UnityEngine;

public class TestInt64 : MonoBehaviour
{
	private string tips = string.Empty;

	private string script = "            \r\n            function TestInt64(x)                \r\n                x = x + 789\t\t\r\n                assert(tostring(x) == '9223372036854775807')\t\t\r\n                local low, high = int64.tonum2(x)                \r\n                print('x value is: '..tostring(x)..' low is: '.. low .. ' high is: '..high.. ' type is: '.. tolua.typename(x))           \r\n                local y = int64.new(1,2)                \r\n                local z = int64.new(1,2)\r\n                \r\n                if y == z then\r\n                    print('int64 equals is ok, value: '..int64.tostring(y))\r\n                end\r\n\r\n                x = int64.new(123)                   \r\n            \r\n                if int64.equals(x, 123) then\r\n                    print('int64 equals to number ok')\r\n                else\r\n                    print('int64 equals to number failed')\r\n                end\r\n\r\n                x = int64.new('78962871035984074')\r\n                print('int64 is: '..tostring(x))\r\n\r\n                local str = tostring(int64.new(3605690779, 30459971))                \r\n                local n2 = int64.new(str)\r\n                local l, h = int64.tonum2(n2)                        \r\n                print(str..':'..tostring(n2)..' low:'..l..' high:'..h)                  \r\n\r\n                print('----------------------------uint64-----------------------------')\r\n                x = uint64.new('18446744073709551615')                                \r\n                print('uint64 max is: '..tostring(x))\r\n                l, h = uint64.tonum2(x)      \r\n                str = tostring(uint64.new(l, h))\r\n                print(str..':'..tostring(x)..' low:'..l..' high:'..h)     \r\n\r\n                return y\r\n            end\r\n        ";

	private void Start()
	{
		Application.logMessageReceived += new Application.LogCallback(this.ShowTips);
		new LuaResLoader();
		LuaState luaState = new LuaState();
		luaState.Start();
		luaState.DoString(this.script, "TestInt64.cs");
		LuaFunction function = luaState.GetFunction("TestInt64", true);
		function.BeginPCall();
		function.Push(9223372036854775018L);
		function.PCall();
		long num = function.CheckLong();
		Debugger.Log("int64 return from lua is: {0}", num);
		function.EndPCall();
		function.Dispose();
		luaState.CheckTop();
		luaState.Dispose();
	}

	private void ShowTips(string msg, string stackTrace, LogType type)
	{
		this.tips += msg;
		this.tips += "\r\n";
	}

	private void OnDestroy()
	{
		Application.logMessageReceived -= new Application.LogCallback(this.ShowTips);
	}

	private void OnGUI()
	{
		GUI.Label(new Rect((float)(Screen.width / 2 - 200), (float)(Screen.height / 2 - 150), 400f, 300f), this.tips);
	}
}
