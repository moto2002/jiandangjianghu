using LuaInterface;
using System;
using ThirdParty;
using UnityEngine;

public class SensitiveWordLogicWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SensitiveWordLogic), typeof(Singleton<SensitiveWordLogic>), null);
		L.RegFunction("GetInstance", new LuaCSFunction(SensitiveWordLogicWrap.GetInstance));
		L.RegFunction("filter", new LuaCSFunction(SensitiveWordLogicWrap.filter));
		L.RegFunction("isSensitive", new LuaCSFunction(SensitiveWordLogicWrap.isSensitive));
		L.RegFunction("__eq", new LuaCSFunction(SensitiveWordLogicWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInstance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			SensitiveWordLogic instance = SensitiveWordLogic.GetInstance();
			ToLua.Push(L, instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int filter(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SensitiveWordLogic sensitiveWordLogic = (SensitiveWordLogic)ToLua.CheckObject(L, 1, typeof(SensitiveWordLogic));
			string src = ToLua.CheckString(L, 2);
			string replace = ToLua.CheckString(L, 3);
			string str = sensitiveWordLogic.filter(src, replace);
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
	private static int isSensitive(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SensitiveWordLogic sensitiveWordLogic = (SensitiveWordLogic)ToLua.CheckObject(L, 1, typeof(SensitiveWordLogic));
			string src = ToLua.CheckString(L, 2);
			bool value = sensitiveWordLogic.isSensitive(src);
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
