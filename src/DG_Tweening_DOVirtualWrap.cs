using DG.Tweening;
using LuaInterface;
using System;
using UnityEngine;

public class DG_Tweening_DOVirtualWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("DOVirtual");
		L.RegFunction("Float", new LuaCSFunction(DG_Tweening_DOVirtualWrap.Float));
		L.RegFunction("EasedValue", new LuaCSFunction(DG_Tweening_DOVirtualWrap.EasedValue));
		L.RegFunction("DelayedCall", new LuaCSFunction(DG_Tweening_DOVirtualWrap.DelayedCall));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Float(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			float from = (float)LuaDLL.luaL_checknumber(L, 1);
			float to = (float)LuaDLL.luaL_checknumber(L, 2);
			float duration = (float)LuaDLL.luaL_checknumber(L, 3);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 4);
			TweenCallback<float> onVirtualUpdate;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onVirtualUpdate = (TweenCallback<float>)ToLua.CheckObject(L, 4, typeof(TweenCallback<float>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 4);
				onVirtualUpdate = (DelegateFactory.CreateDelegate(typeof(TweenCallback<float>), func) as TweenCallback<float>);
			}
			Tweener o = DOVirtual.Float(from, to, duration, onVirtualUpdate);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EasedValue(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(AnimationCurve)))
			{
				float from = (float)LuaDLL.lua_tonumber(L, 1);
				float to = (float)LuaDLL.lua_tonumber(L, 2);
				float lifetimePercentage = (float)LuaDLL.lua_tonumber(L, 3);
				AnimationCurve easeCurve = (AnimationCurve)ToLua.ToObject(L, 4);
				float num2 = DOVirtual.EasedValue(from, to, lifetimePercentage, easeCurve);
				LuaDLL.lua_pushnumber(L, (double)num2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(Ease)))
			{
				float from2 = (float)LuaDLL.lua_tonumber(L, 1);
				float to2 = (float)LuaDLL.lua_tonumber(L, 2);
				float lifetimePercentage2 = (float)LuaDLL.lua_tonumber(L, 3);
				Ease easeType = (Ease)((int)ToLua.ToObject(L, 4));
				float num3 = DOVirtual.EasedValue(from2, to2, lifetimePercentage2, easeType);
				LuaDLL.lua_pushnumber(L, (double)num3);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(Ease), typeof(float)))
			{
				float from3 = (float)LuaDLL.lua_tonumber(L, 1);
				float to3 = (float)LuaDLL.lua_tonumber(L, 2);
				float lifetimePercentage3 = (float)LuaDLL.lua_tonumber(L, 3);
				Ease easeType2 = (Ease)((int)ToLua.ToObject(L, 4));
				float overshoot = (float)LuaDLL.lua_tonumber(L, 5);
				float num4 = DOVirtual.EasedValue(from3, to3, lifetimePercentage3, easeType2, overshoot);
				LuaDLL.lua_pushnumber(L, (double)num4);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(Ease), typeof(float), typeof(float)))
			{
				float from4 = (float)LuaDLL.lua_tonumber(L, 1);
				float to4 = (float)LuaDLL.lua_tonumber(L, 2);
				float lifetimePercentage4 = (float)LuaDLL.lua_tonumber(L, 3);
				Ease easeType3 = (Ease)((int)ToLua.ToObject(L, 4));
				float amplitude = (float)LuaDLL.lua_tonumber(L, 5);
				float period = (float)LuaDLL.lua_tonumber(L, 6);
				float num5 = DOVirtual.EasedValue(from4, to4, lifetimePercentage4, easeType3, amplitude, period);
				LuaDLL.lua_pushnumber(L, (double)num5);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.DOVirtual.EasedValue");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DelayedCall(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			float delay = (float)LuaDLL.luaL_checknumber(L, 1);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			TweenCallback callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (TweenCallback)ToLua.CheckObject(L, 2, typeof(TweenCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				callback = (DelegateFactory.CreateDelegate(typeof(TweenCallback), func) as TweenCallback);
			}
			bool ignoreTimeScale = LuaDLL.luaL_checkboolean(L, 3);
			Tween o = DOVirtual.DelayedCall(delay, callback, ignoreTimeScale);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
