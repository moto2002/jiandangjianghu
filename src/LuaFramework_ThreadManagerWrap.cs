using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_ThreadManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ThreadManager), typeof(Manager), null);
		L.RegFunction("AddEvent", new LuaCSFunction(LuaFramework_ThreadManagerWrap.AddEvent));
		L.RegFunction("__eq", new LuaCSFunction(LuaFramework_ThreadManagerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			ThreadManager threadManager = (ThreadManager)ToLua.CheckObject(L, 1, typeof(ThreadManager));
			ThreadEvent ev = (ThreadEvent)ToLua.CheckObject(L, 2, typeof(ThreadEvent));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			Action<NotiData> func;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				func = (Action<NotiData>)ToLua.CheckObject(L, 3, typeof(Action<NotiData>));
			}
			else
			{
				LuaFunction func2 = ToLua.ToLuaFunction(L, 3);
				func = (DelegateFactory.CreateDelegate(typeof(Action<NotiData>), func2) as Action<NotiData>);
			}
			threadManager.AddEvent(ev, func);
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
}
