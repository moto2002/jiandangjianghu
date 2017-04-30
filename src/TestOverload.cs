using LuaInterface;
using System;
using UnityEngine;

public class TestOverload : MonoBehaviour
{
	private string script = "                  \r\n        require 'TestExport'                                        \r\n        local out = require 'tolua.out'\r\n        local GameObject = UnityEngine.GameObject                                \r\n\r\n        function Test(to)            \r\n            assert(to:Test(1) == 4)            \r\n            local flag, num = to:Test(out.int)\r\n            assert(flag == 3 and num == 1024, 'Test(out)')\r\n            assert(to:Test('hello') == 6, 'Test(string)')\r\n            assert(to:Test(System.Object.New()) == 8)            \r\n            assert(to:Test(true) == 15)\r\n            assert(to:Test(123, 456) == 5)            \r\n            assert(to:Test('123', '456') == 1)\r\n            assert(to:Test(System.Object.New(), '456') == 1)\r\n            assert(to:Test('123', 456) == 9)\r\n            assert(to:Test('123', System.Object.New()) == 9)\r\n            assert(to:Test(1,2,3) == 12)            \r\n            assert(to:TestGeneric(GameObject().transform) == 11)\r\n            assert(to:TestCheckParamNumber(1,2,3) == 6)\r\n            assert(to:TestCheckParamString('1', '2', '3') == '123')\r\n            assert(to:Test(TestExport.Space.World) == 10)        \r\n            print(to.this:get(123))\r\n            to.this:set(1, 456)           \r\n        end\r\n    ";

	private void Awake()
	{
		LuaState luaState = new LuaState();
		luaState.Start();
		LuaBinder.Bind(luaState);
		this.Bind(luaState);
		luaState.DoString(this.script, "TestOverload.cs");
		TestExport testExport = new TestExport();
		LuaFunction function = luaState.GetFunction("Test", true);
		function.Call(new object[]
		{
			testExport
		});
		luaState.Dispose();
	}

	private void Bind(LuaState state)
	{
		state.BeginModule(null);
		TestExportWrap.Register(state);
		state.BeginModule("TestExport");
		TestExport_SpaceWrap.Register(state);
		state.EndModule();
		state.EndModule();
	}
}
