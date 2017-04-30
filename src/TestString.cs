using LuaInterface;
using System;

public class TestString : LuaClient
{
	private string script = "           \r\n    function Test()\r\n        local str = System.String.New('男儿当自强')\r\n        local index = str:IndexOfAny('儿自')\r\n        print('and index is: '..index)\r\n        local buffer = str:ToCharArray()\r\n        print('str type is: '..type(str)..' buffer[0] is ' .. buffer[0])\r\n        local luastr = tolua.tolstring(buffer)\r\n        print('lua string is: '..luastr..' type is: '..type(luastr))\r\n        luastr = tolua.tolstring(str)\r\n        print('lua string is: '..luastr)                    \r\n    end\r\n";

	protected override LuaFileUtils InitLoader()
	{
		return new LuaResLoader();
	}

	protected override void CallMain()
	{
	}

	protected override void OnLoadFinished()
	{
		base.OnLoadFinished();
		this.luaState.DoString(this.script, "LuaState.cs");
		LuaFunction function = this.luaState.GetFunction("Test", true);
		function.Call();
		function.Dispose();
	}
}
