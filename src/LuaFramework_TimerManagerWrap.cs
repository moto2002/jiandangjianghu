using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_TimerManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TimerManager), typeof(Manager), null);
		L.RegFunction("AddRepeatingTimer", new LuaCSFunction(LuaFramework_TimerManagerWrap.AddRepeatingTimer));
		L.RegFunction("RemoveRepeatingTimer", new LuaCSFunction(LuaFramework_TimerManagerWrap.RemoveRepeatingTimer));
		L.RegFunction("AddTimer", new LuaCSFunction(LuaFramework_TimerManagerWrap.AddTimer));
		L.RegFunction("__eq", new LuaCSFunction(LuaFramework_TimerManagerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegFunction("UpdateFunc", new LuaCSFunction(LuaFramework_TimerManagerWrap.LuaFramework_TimerManager_UpdateFunc));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddRepeatingTimer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 6);
			TimerManager timerManager = (TimerManager)ToLua.CheckObject(L, 1, typeof(TimerManager));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			string timerName = ToLua.CheckString(L, 3);
			float delay = (float)LuaDLL.luaL_checknumber(L, 4);
			float interval = (float)LuaDLL.luaL_checknumber(L, 5);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 6);
			TimerManager.UpdateFunc func;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				func = (TimerManager.UpdateFunc)ToLua.CheckObject(L, 6, typeof(TimerManager.UpdateFunc));
			}
			else
			{
				LuaFunction func2 = ToLua.ToLuaFunction(L, 6);
				func = (DelegateFactory.CreateDelegate(typeof(TimerManager.UpdateFunc), func2) as TimerManager.UpdateFunc);
			}
			timerManager.AddRepeatingTimer(go, timerName, delay, interval, func);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveRepeatingTimer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TimerManager timerManager = (TimerManager)ToLua.CheckObject(L, 1, typeof(TimerManager));
			string timerName = ToLua.CheckString(L, 2);
			timerManager.RemoveRepeatingTimer(timerName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddTimer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			TimerManager timerManager = (TimerManager)ToLua.CheckObject(L, 1, typeof(TimerManager));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			string timerName = ToLua.CheckString(L, 3);
			float delay = (float)LuaDLL.luaL_checknumber(L, 4);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 5);
			TimerManager.UpdateFunc func;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				func = (TimerManager.UpdateFunc)ToLua.CheckObject(L, 5, typeof(TimerManager.UpdateFunc));
			}
			else
			{
				LuaFunction func2 = ToLua.ToLuaFunction(L, 5);
				func = (DelegateFactory.CreateDelegate(typeof(TimerManager.UpdateFunc), func2) as TimerManager.UpdateFunc);
			}
			timerManager.AddTimer(go, timerName, delay, func);
			result = 0;
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
	private static int LuaFramework_TimerManager_UpdateFunc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(TimerManager.UpdateFunc), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(TimerManager.UpdateFunc), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
