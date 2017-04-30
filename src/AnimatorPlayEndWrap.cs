using LuaInterface;
using System;
using UnityEngine;

public class AnimatorPlayEndWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AnimatorPlayEnd), typeof(MonoBehaviour), null);
		L.RegFunction("PlayEnd", new LuaCSFunction(AnimatorPlayEndWrap.PlayEnd));
		L.RegFunction("__eq", new LuaCSFunction(AnimatorPlayEndWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("isPlaying", new LuaCSFunction(AnimatorPlayEndWrap.get_isPlaying), new LuaCSFunction(AnimatorPlayEndWrap.set_isPlaying));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayEnd(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AnimatorPlayEnd animatorPlayEnd = (AnimatorPlayEnd)ToLua.CheckObject(L, 1, typeof(AnimatorPlayEnd));
			animatorPlayEnd.PlayEnd();
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
	private static int get_isPlaying(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimatorPlayEnd animatorPlayEnd = (AnimatorPlayEnd)obj;
			bool isPlaying = animatorPlayEnd.isPlaying;
			LuaDLL.lua_pushboolean(L, isPlaying);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isPlaying on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isPlaying(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimatorPlayEnd animatorPlayEnd = (AnimatorPlayEnd)obj;
			bool isPlaying = LuaDLL.luaL_checkboolean(L, 2);
			animatorPlayEnd.isPlaying = isPlaying;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isPlaying on a nil value");
		}
		return result;
	}
}
