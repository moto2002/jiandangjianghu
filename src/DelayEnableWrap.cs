using LuaInterface;
using System;
using UnityEngine;

public class DelayEnableWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(DelayEnable), typeof(MonoBehaviour), null);
		L.RegFunction("__eq", new LuaCSFunction(DelayEnableWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("delay", new LuaCSFunction(DelayEnableWrap.get_delay), new LuaCSFunction(DelayEnableWrap.set_delay));
		L.EndClass();
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
	private static int get_delay(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			DelayEnable delayEnable = (DelayEnable)obj;
			float delay = delayEnable.delay;
			LuaDLL.lua_pushnumber(L, (double)delay);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index delay on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_delay(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			DelayEnable delayEnable = (DelayEnable)obj;
			float delay = (float)LuaDLL.luaL_checknumber(L, 2);
			delayEnable.delay = delay;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index delay on a nil value");
		}
		return result;
	}
}
