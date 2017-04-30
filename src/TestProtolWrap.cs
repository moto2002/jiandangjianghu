using LuaInterface;
using System;

public class TestProtolWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("TestProtol");
		L.RegVar("data", new LuaCSFunction(TestProtolWrap.get_data), new LuaCSFunction(TestProtolWrap.set_data));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_data(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.tolua_pushlstring(L, TestProtol.data, TestProtol.data.Length);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_data(IntPtr L)
	{
		int result;
		try
		{
			byte[] data = ToLua.CheckByteBuffer(L, 2);
			TestProtol.data = data;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
