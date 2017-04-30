using LuaInterface;
using System;
using UnityEngine;

public class SDKCallbackWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SDKCallback), typeof(MonoBehaviour), null);
		L.RegFunction("InitCallback", new LuaCSFunction(SDKCallbackWrap.InitCallback));
		L.RegFunction("OnInitSuc", new LuaCSFunction(SDKCallbackWrap.OnInitSuc));
		L.RegFunction("OnLoginSuc", new LuaCSFunction(SDKCallbackWrap.OnLoginSuc));
		L.RegFunction("OnSwitchLogin", new LuaCSFunction(SDKCallbackWrap.OnSwitchLogin));
		L.RegFunction("OnLogout", new LuaCSFunction(SDKCallbackWrap.OnLogout));
		L.RegFunction("OnPaySuc", new LuaCSFunction(SDKCallbackWrap.OnPaySuc));
		L.RegFunction("__eq", new LuaCSFunction(SDKCallbackWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InitCallback(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			SDKCallback obj = SDKCallback.InitCallback();
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnInitSuc(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SDKCallback sDKCallback = (SDKCallback)ToLua.CheckObject(L, 1, typeof(SDKCallback));
			sDKCallback.OnInitSuc();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnLoginSuc(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SDKCallback sDKCallback = (SDKCallback)ToLua.CheckObject(L, 1, typeof(SDKCallback));
			string jsonData = ToLua.CheckString(L, 2);
			sDKCallback.OnLoginSuc(jsonData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnSwitchLogin(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SDKCallback sDKCallback = (SDKCallback)ToLua.CheckObject(L, 1, typeof(SDKCallback));
			sDKCallback.OnSwitchLogin();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnLogout(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SDKCallback sDKCallback = (SDKCallback)ToLua.CheckObject(L, 1, typeof(SDKCallback));
			sDKCallback.OnLogout();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPaySuc(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SDKCallback sDKCallback = (SDKCallback)ToLua.CheckObject(L, 1, typeof(SDKCallback));
			string jsonData = ToLua.CheckString(L, 2);
			sDKCallback.OnPaySuc(jsonData);
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
