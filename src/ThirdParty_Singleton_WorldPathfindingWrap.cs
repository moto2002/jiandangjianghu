using LuaInterface;
using System;
using ThirdParty;
using UnityEngine;

public class ThirdParty_Singleton_WorldPathfindingWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Singleton<WorldPathfinding>), typeof(MonoBehaviour), "Singleton_WorldPathfinding");
		L.RegFunction("Init", new LuaCSFunction(ThirdParty_Singleton_WorldPathfindingWrap.Init));
		L.RegFunction("DestroySelf", new LuaCSFunction(ThirdParty_Singleton_WorldPathfindingWrap.DestroySelf));
		L.RegFunction("__eq", new LuaCSFunction(ThirdParty_Singleton_WorldPathfindingWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Instance", new LuaCSFunction(ThirdParty_Singleton_WorldPathfindingWrap.get_Instance), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Init(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Singleton<WorldPathfinding> singleton = (Singleton<WorldPathfinding>)ToLua.CheckObject(L, 1, typeof(Singleton<WorldPathfinding>));
			singleton.Init();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DestroySelf(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			Singleton<WorldPathfinding>.DestroySelf();
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
	private static int get_Instance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Singleton<WorldPathfinding>.Instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
