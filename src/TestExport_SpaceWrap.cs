using LuaInterface;
using System;

public class TestExport_SpaceWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(TestExport.Space));
		L.RegVar("World", new LuaCSFunction(TestExport_SpaceWrap.get_World), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(TestExport_SpaceWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_World(IntPtr L)
	{
		ToLua.Push(L, TestExport.Space.World);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		TestExport.Space space = (TestExport.Space)num;
		ToLua.Push(L, space);
		return 1;
	}
}
