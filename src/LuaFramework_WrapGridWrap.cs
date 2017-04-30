using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_WrapGridWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(WrapGrid), typeof(MonoBehaviour), null);
		L.RegFunction("InitGrid", new LuaCSFunction(LuaFramework_WrapGridWrap.InitGrid));
		L.RegFunction("__eq", new LuaCSFunction(LuaFramework_WrapGridWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InitGrid(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			WrapGrid wrapGrid = (WrapGrid)ToLua.CheckObject(L, 1, typeof(WrapGrid));
			wrapGrid.InitGrid();
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
