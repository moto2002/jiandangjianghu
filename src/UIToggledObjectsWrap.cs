using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIToggledObjectsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIToggledObjects), typeof(MonoBehaviour), null);
		L.RegFunction("Toggle", new LuaCSFunction(UIToggledObjectsWrap.Toggle));
		L.RegFunction("__eq", new LuaCSFunction(UIToggledObjectsWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("activate", new LuaCSFunction(UIToggledObjectsWrap.get_activate), new LuaCSFunction(UIToggledObjectsWrap.set_activate));
		L.RegVar("deactivate", new LuaCSFunction(UIToggledObjectsWrap.get_deactivate), new LuaCSFunction(UIToggledObjectsWrap.set_deactivate));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Toggle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIToggledObjects uIToggledObjects = (UIToggledObjects)ToLua.CheckObject(L, 1, typeof(UIToggledObjects));
			uIToggledObjects.Toggle();
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
	private static int get_activate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggledObjects uIToggledObjects = (UIToggledObjects)obj;
			List<GameObject> activate = uIToggledObjects.activate;
			ToLua.PushObject(L, activate);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index activate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_deactivate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggledObjects uIToggledObjects = (UIToggledObjects)obj;
			List<GameObject> deactivate = uIToggledObjects.deactivate;
			ToLua.PushObject(L, deactivate);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index deactivate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_activate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggledObjects uIToggledObjects = (UIToggledObjects)obj;
			List<GameObject> activate = (List<GameObject>)ToLua.CheckObject(L, 2, typeof(List<GameObject>));
			uIToggledObjects.activate = activate;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index activate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_deactivate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIToggledObjects uIToggledObjects = (UIToggledObjects)obj;
			List<GameObject> deactivate = (List<GameObject>)ToLua.CheckObject(L, 2, typeof(List<GameObject>));
			uIToggledObjects.deactivate = deactivate;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index deactivate on a nil value");
		}
		return result;
	}
}
