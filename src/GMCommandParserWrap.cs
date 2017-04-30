using LuaInterface;
using System;

public class GMCommandParserWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("GMCommandParser");
		L.RegFunction("ParserWalkTo", new LuaCSFunction(GMCommandParserWrap.ParserWalkTo));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ParserWalkTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string command = ToLua.CheckString(L, 1);
			GMCommandParser.ParserWalkTo(command);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
