using LuaInterface;
using System;

public class TimeConverterWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("TimeConverter");
		L.RegFunction("ConvertIntDateTime", new LuaCSFunction(TimeConverterWrap.ConvertIntDateTime));
		L.RegFunction("ConvertDateTimeInt", new LuaCSFunction(TimeConverterWrap.ConvertDateTimeInt));
		L.RegFunction("ConvertDateTimeLong", new LuaCSFunction(TimeConverterWrap.ConvertDateTimeLong));
		L.RegFunction("CovertToString", new LuaCSFunction(TimeConverterWrap.CovertToString));
		L.RegFunction("ConvertToHoursString", new LuaCSFunction(TimeConverterWrap.ConvertToHoursString));
		L.RegFunction("ConvertToDateString", new LuaCSFunction(TimeConverterWrap.ConvertToDateString));
		L.RegFunction("ConvertToLogDateString", new LuaCSFunction(TimeConverterWrap.ConvertToLogDateString));
		L.RegFunction("ConvertToDateString1", new LuaCSFunction(TimeConverterWrap.ConvertToDateString1));
		L.RegFunction("Parse", new LuaCSFunction(TimeConverterWrap.Parse));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ConvertIntDateTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			double d = LuaDLL.luaL_checknumber(L, 1);
			DateTime dateTime = TimeConverter.ConvertIntDateTime(d);
			ToLua.PushValue(L, dateTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ConvertDateTimeInt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DateTime time = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			double number = TimeConverter.ConvertDateTimeInt(time);
			LuaDLL.lua_pushnumber(L, number);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ConvertDateTimeLong(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DateTime time = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			long n = TimeConverter.ConvertDateTimeLong(time);
			LuaDLL.tolua_pushint64(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CovertToString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int seconds = (int)LuaDLL.luaL_checknumber(L, 1);
			string str = TimeConverter.CovertToString(seconds);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ConvertToHoursString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int seconds = (int)LuaDLL.luaL_checknumber(L, 1);
			string str = TimeConverter.ConvertToHoursString(seconds);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ConvertToDateString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			double d = LuaDLL.luaL_checknumber(L, 1);
			string str = TimeConverter.ConvertToDateString(d);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ConvertToLogDateString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			double d = LuaDLL.luaL_checknumber(L, 1);
			string str = TimeConverter.ConvertToLogDateString(d);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ConvertToDateString1(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			double d = LuaDLL.luaL_checknumber(L, 1);
			string str = TimeConverter.ConvertToDateString1(d);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Parse(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string dateTime = ToLua.CheckString(L, 1);
			DateTime dateTime2 = TimeConverter.Parse(dateTime);
			ToLua.PushValue(L, dateTime2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
