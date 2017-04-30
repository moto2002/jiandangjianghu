using LuaInterface;
using System;
using UnityEngine;

public class LuaComponentWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaComponent), typeof(MonoBehaviour), null);
		L.RegFunction("Add", new LuaCSFunction(LuaComponentWrap.Add));
		L.RegFunction("Get", new LuaCSFunction(LuaComponentWrap.Get));
		L.RegFunction("AddClick", new LuaCSFunction(LuaComponentWrap.AddClick));
		L.RegFunction("__eq", new LuaCSFunction(LuaComponentWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("table", new LuaCSFunction(LuaComponentWrap.get_table), new LuaCSFunction(LuaComponentWrap.set_table));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Add(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			LuaTable tableClass = ToLua.CheckLuaTable(L, 2);
			LuaTable lbr = LuaComponent.Add(go, tableClass);
			ToLua.Push(L, lbr);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Get(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			LuaTable table = ToLua.CheckLuaTable(L, 2);
			LuaTable lbr = LuaComponent.Get(go, table);
			ToLua.Push(L, lbr);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaComponent luaComponent = (LuaComponent)ToLua.CheckObject(L, 1, typeof(LuaComponent));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaComponent.AddClick(go, luafunc);
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
	private static int get_table(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaComponent luaComponent = (LuaComponent)obj;
			LuaTable table = luaComponent.table;
			ToLua.Push(L, table);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index table on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_table(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LuaComponent luaComponent = (LuaComponent)obj;
			LuaTable table = ToLua.CheckLuaTable(L, 2);
			luaComponent.table = table;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index table on a nil value");
		}
		return result;
	}
}
