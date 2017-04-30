using LuaInterface;
using System;
using UnityEngine;

public class PunchAwayWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(PunchAway), typeof(MonoBehaviour), null);
		L.RegFunction("StartPunch", new LuaCSFunction(PunchAwayWrap.StartPunch));
		L.RegFunction("__eq", new LuaCSFunction(PunchAwayWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("upSpeed", new LuaCSFunction(PunchAwayWrap.get_upSpeed), new LuaCSFunction(PunchAwayWrap.set_upSpeed));
		L.RegVar("horizStartSpeed", new LuaCSFunction(PunchAwayWrap.get_horizStartSpeed), new LuaCSFunction(PunchAwayWrap.set_horizStartSpeed));
		L.RegVar("horizDeceleration", new LuaCSFunction(PunchAwayWrap.get_horizDeceleration), new LuaCSFunction(PunchAwayWrap.set_horizDeceleration));
		L.RegVar("gravity", new LuaCSFunction(PunchAwayWrap.get_gravity), new LuaCSFunction(PunchAwayWrap.set_gravity));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartPunch(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PunchAway punchAway = (PunchAway)ToLua.CheckObject(L, 1, typeof(PunchAway));
			punchAway.StartPunch();
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
	private static int get_upSpeed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PunchAway punchAway = (PunchAway)obj;
			float upSpeed = punchAway.upSpeed;
			LuaDLL.lua_pushnumber(L, (double)upSpeed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index upSpeed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_horizStartSpeed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PunchAway punchAway = (PunchAway)obj;
			float horizStartSpeed = punchAway.horizStartSpeed;
			LuaDLL.lua_pushnumber(L, (double)horizStartSpeed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horizStartSpeed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_horizDeceleration(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PunchAway punchAway = (PunchAway)obj;
			float horizDeceleration = punchAway.horizDeceleration;
			LuaDLL.lua_pushnumber(L, (double)horizDeceleration);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horizDeceleration on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gravity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PunchAway punchAway = (PunchAway)obj;
			float gravity = punchAway.gravity;
			LuaDLL.lua_pushnumber(L, (double)gravity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index gravity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_upSpeed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PunchAway punchAway = (PunchAway)obj;
			float upSpeed = (float)LuaDLL.luaL_checknumber(L, 2);
			punchAway.upSpeed = upSpeed;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index upSpeed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_horizStartSpeed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PunchAway punchAway = (PunchAway)obj;
			float horizStartSpeed = (float)LuaDLL.luaL_checknumber(L, 2);
			punchAway.horizStartSpeed = horizStartSpeed;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horizStartSpeed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_horizDeceleration(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PunchAway punchAway = (PunchAway)obj;
			float horizDeceleration = (float)LuaDLL.luaL_checknumber(L, 2);
			punchAway.horizDeceleration = horizDeceleration;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horizDeceleration on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_gravity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PunchAway punchAway = (PunchAway)obj;
			float gravity = (float)LuaDLL.luaL_checknumber(L, 2);
			punchAway.gravity = gravity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index gravity on a nil value");
		}
		return result;
	}
}
