using LuaInterface;
using System;
using ThirdParty;
using UnityEngine;

public class TimeManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TimeManager), typeof(Singleton<TimeManager>), null);
		L.RegFunction("SetServerTime", new LuaCSFunction(TimeManagerWrap.SetServerTime));
		L.RegFunction("FormatDateTime", new LuaCSFunction(TimeManagerWrap.FormatDateTime));
		L.RegFunction("TotalSecondsToCurrentTime", new LuaCSFunction(TimeManagerWrap.TotalSecondsToCurrentTime));
		L.RegFunction("__eq", new LuaCSFunction(TimeManagerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("instance", new LuaCSFunction(TimeManagerWrap.get_instance), null);
		L.RegVar("CurServerTime", new LuaCSFunction(TimeManagerWrap.get_CurServerTime), null);
		L.RegVar("CurServerTotalSeconds", new LuaCSFunction(TimeManagerWrap.get_CurServerTotalSeconds), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetServerTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			TimeManager timeManager = (TimeManager)ToLua.CheckObject(L, 1, typeof(TimeManager));
			string millisec = ToLua.CheckString(L, 2);
			uint usec = (uint)LuaDLL.luaL_checknumber(L, 3);
			timeManager.SetServerTime(millisec, usec);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FormatDateTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			DateTime time = (DateTime)ToLua.CheckObject(L, 1, typeof(DateTime));
			string format = ToLua.CheckString(L, 2);
			string str = TimeManager.FormatDateTime(time, format);
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
	private static int TotalSecondsToCurrentTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			double number = TimeManager.TotalSecondsToCurrentTime();
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
	private static int op_Equality(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object x = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object y = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool value = x == y;
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_instance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, TimeManager.instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_CurServerTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TimeManager timeManager = (TimeManager)obj;
			DateTime curServerTime = timeManager.CurServerTime;
			ToLua.PushValue(L, curServerTime);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CurServerTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_CurServerTotalSeconds(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TimeManager timeManager = (TimeManager)obj;
			ulong curServerTotalSeconds = timeManager.CurServerTotalSeconds;
			LuaDLL.tolua_pushuint64(L, curServerTotalSeconds);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index CurServerTotalSeconds on a nil value");
		}
		return result;
	}
}
