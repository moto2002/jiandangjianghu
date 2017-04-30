using LuaInterface;
using System;
using UnityEngine;

public class SpringPanelWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SpringPanel), typeof(MonoBehaviour), null);
		L.RegFunction("Begin", new LuaCSFunction(SpringPanelWrap.Begin));
		L.RegFunction("__eq", new LuaCSFunction(SpringPanelWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("current", new LuaCSFunction(SpringPanelWrap.get_current), new LuaCSFunction(SpringPanelWrap.set_current));
		L.RegVar("target", new LuaCSFunction(SpringPanelWrap.get_target), new LuaCSFunction(SpringPanelWrap.set_target));
		L.RegVar("strength", new LuaCSFunction(SpringPanelWrap.get_strength), new LuaCSFunction(SpringPanelWrap.set_strength));
		L.RegVar("onFinished", new LuaCSFunction(SpringPanelWrap.get_onFinished), new LuaCSFunction(SpringPanelWrap.set_onFinished));
		L.RegFunction("OnFinished", new LuaCSFunction(SpringPanelWrap.SpringPanel_OnFinished));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Begin(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			Vector3 pos = ToLua.ToVector3(L, 2);
			float strength = (float)LuaDLL.luaL_checknumber(L, 3);
			SpringPanel obj = SpringPanel.Begin(go, pos, strength);
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
	private static int get_current(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, SpringPanel.current);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_target(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SpringPanel springPanel = (SpringPanel)obj;
			Vector3 target = springPanel.target;
			ToLua.Push(L, target);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index target on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_strength(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SpringPanel springPanel = (SpringPanel)obj;
			float strength = springPanel.strength;
			LuaDLL.lua_pushnumber(L, (double)strength);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index strength on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SpringPanel springPanel = (SpringPanel)obj;
			SpringPanel.OnFinished onFinished = springPanel.onFinished;
			ToLua.Push(L, onFinished);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		int result;
		try
		{
			SpringPanel current = (SpringPanel)ToLua.CheckUnityObject(L, 2, typeof(SpringPanel));
			SpringPanel.current = current;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_target(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SpringPanel springPanel = (SpringPanel)obj;
			Vector3 target = ToLua.ToVector3(L, 2);
			springPanel.target = target;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index target on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_strength(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SpringPanel springPanel = (SpringPanel)obj;
			float strength = (float)LuaDLL.luaL_checknumber(L, 2);
			springPanel.strength = strength;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index strength on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SpringPanel springPanel = (SpringPanel)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			SpringPanel.OnFinished onFinished;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onFinished = (SpringPanel.OnFinished)ToLua.CheckObject(L, 2, typeof(SpringPanel.OnFinished));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onFinished = (DelegateFactory.CreateDelegate(typeof(SpringPanel.OnFinished), func) as SpringPanel.OnFinished);
			}
			springPanel.onFinished = onFinished;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SpringPanel_OnFinished(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(SpringPanel.OnFinished), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(SpringPanel.OnFinished), func, self);
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
