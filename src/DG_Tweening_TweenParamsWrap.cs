using DG.Tweening;
using LuaInterface;
using System;
using UnityEngine;

public class DG_Tweening_TweenParamsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TweenParams), typeof(object), null);
		L.RegFunction("Clear", new LuaCSFunction(DG_Tweening_TweenParamsWrap.Clear));
		L.RegFunction("SetAutoKill", new LuaCSFunction(DG_Tweening_TweenParamsWrap.SetAutoKill));
		L.RegFunction("SetId", new LuaCSFunction(DG_Tweening_TweenParamsWrap.SetId));
		L.RegFunction("SetTarget", new LuaCSFunction(DG_Tweening_TweenParamsWrap.SetTarget));
		L.RegFunction("SetLoops", new LuaCSFunction(DG_Tweening_TweenParamsWrap.SetLoops));
		L.RegFunction("SetEase", new LuaCSFunction(DG_Tweening_TweenParamsWrap.SetEase));
		L.RegFunction("SetRecyclable", new LuaCSFunction(DG_Tweening_TweenParamsWrap.SetRecyclable));
		L.RegFunction("SetUpdate", new LuaCSFunction(DG_Tweening_TweenParamsWrap.SetUpdate));
		L.RegFunction("OnStart", new LuaCSFunction(DG_Tweening_TweenParamsWrap.OnStart));
		L.RegFunction("OnPlay", new LuaCSFunction(DG_Tweening_TweenParamsWrap.OnPlay));
		L.RegFunction("OnRewind", new LuaCSFunction(DG_Tweening_TweenParamsWrap.OnRewind));
		L.RegFunction("OnUpdate", new LuaCSFunction(DG_Tweening_TweenParamsWrap.OnUpdate));
		L.RegFunction("OnStepComplete", new LuaCSFunction(DG_Tweening_TweenParamsWrap.OnStepComplete));
		L.RegFunction("OnComplete", new LuaCSFunction(DG_Tweening_TweenParamsWrap.OnComplete));
		L.RegFunction("OnKill", new LuaCSFunction(DG_Tweening_TweenParamsWrap.OnKill));
		L.RegFunction("OnWaypointChange", new LuaCSFunction(DG_Tweening_TweenParamsWrap.OnWaypointChange));
		L.RegFunction("SetDelay", new LuaCSFunction(DG_Tweening_TweenParamsWrap.SetDelay));
		L.RegFunction("SetRelative", new LuaCSFunction(DG_Tweening_TweenParamsWrap.SetRelative));
		L.RegFunction("SetSpeedBased", new LuaCSFunction(DG_Tweening_TweenParamsWrap.SetSpeedBased));
		L.RegFunction("New", new LuaCSFunction(DG_Tweening_TweenParamsWrap._CreateDG_Tweening_TweenParams));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Params", new LuaCSFunction(DG_Tweening_TweenParamsWrap.get_Params), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateDG_Tweening_TweenParams(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				TweenParams o = new TweenParams();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: DG.Tweening.TweenParams.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			TweenParams o = tweenParams.Clear();
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
	private static int SetAutoKill(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			bool autoKill = LuaDLL.luaL_checkboolean(L, 2);
			TweenParams o = tweenParams.SetAutoKill(autoKill);
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
	private static int SetId(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			object id = ToLua.ToVarObject(L, 2);
			TweenParams o = tweenParams.SetId(id);
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
	private static int SetTarget(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			object target = ToLua.ToVarObject(L, 2);
			TweenParams o = tweenParams.SetTarget(target);
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
	private static int SetLoops(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			int loops = (int)LuaDLL.luaL_checknumber(L, 2);
			LoopType? loopType = (LoopType?)ToLua.CheckVarObject(L, 3, typeof(LoopType?));
			TweenParams o = tweenParams.SetLoops(loops, loopType);
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
	private static int SetEase(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(TweenParams), typeof(EaseFunction)))
			{
				TweenParams tweenParams = (TweenParams)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				EaseFunction ease;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					ease = (EaseFunction)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					ease = (DelegateFactory.CreateDelegate(typeof(EaseFunction), func) as EaseFunction);
				}
				TweenParams o = tweenParams.SetEase(ease);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(TweenParams), typeof(AnimationCurve)))
			{
				TweenParams tweenParams2 = (TweenParams)ToLua.ToObject(L, 1);
				AnimationCurve ease2 = (AnimationCurve)ToLua.ToObject(L, 2);
				TweenParams o2 = tweenParams2.SetEase(ease2);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(TweenParams), typeof(Ease), typeof(float?), typeof(float?)))
			{
				TweenParams tweenParams3 = (TweenParams)ToLua.ToObject(L, 1);
				Ease ease3 = (Ease)((int)ToLua.ToObject(L, 2));
				float? overshootOrAmplitude = (float?)ToLua.ToObject(L, 3);
				float? period = (float?)ToLua.ToObject(L, 4);
				TweenParams o3 = tweenParams3.SetEase(ease3, overshootOrAmplitude, period);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.TweenParams.SetEase");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetRecyclable(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			bool recyclable = LuaDLL.luaL_checkboolean(L, 2);
			TweenParams o = tweenParams.SetRecyclable(recyclable);
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
	private static int SetUpdate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(TweenParams), typeof(bool)))
			{
				TweenParams tweenParams = (TweenParams)ToLua.ToObject(L, 1);
				bool update = LuaDLL.lua_toboolean(L, 2);
				TweenParams o = tweenParams.SetUpdate(update);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(TweenParams), typeof(UpdateType), typeof(bool)))
			{
				TweenParams tweenParams2 = (TweenParams)ToLua.ToObject(L, 1);
				UpdateType updateType = (UpdateType)((int)ToLua.ToObject(L, 2));
				bool isIndependentUpdate = LuaDLL.lua_toboolean(L, 3);
				TweenParams o2 = tweenParams2.SetUpdate(updateType, isIndependentUpdate);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.TweenParams.SetUpdate");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnStart(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			TweenCallback action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (TweenCallback)ToLua.CheckObject(L, 2, typeof(TweenCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(TweenCallback), func) as TweenCallback);
			}
			TweenParams o = tweenParams.OnStart(action);
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
	private static int OnPlay(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			TweenCallback action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (TweenCallback)ToLua.CheckObject(L, 2, typeof(TweenCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(TweenCallback), func) as TweenCallback);
			}
			TweenParams o = tweenParams.OnPlay(action);
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
	private static int OnRewind(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			TweenCallback action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (TweenCallback)ToLua.CheckObject(L, 2, typeof(TweenCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(TweenCallback), func) as TweenCallback);
			}
			TweenParams o = tweenParams.OnRewind(action);
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
	private static int OnUpdate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			TweenCallback action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (TweenCallback)ToLua.CheckObject(L, 2, typeof(TweenCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(TweenCallback), func) as TweenCallback);
			}
			TweenParams o = tweenParams.OnUpdate(action);
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
	private static int OnStepComplete(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			TweenCallback action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (TweenCallback)ToLua.CheckObject(L, 2, typeof(TweenCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(TweenCallback), func) as TweenCallback);
			}
			TweenParams o = tweenParams.OnStepComplete(action);
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
	private static int OnComplete(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			TweenCallback action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (TweenCallback)ToLua.CheckObject(L, 2, typeof(TweenCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(TweenCallback), func) as TweenCallback);
			}
			TweenParams o = tweenParams.OnComplete(action);
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
	private static int OnKill(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			TweenCallback action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (TweenCallback)ToLua.CheckObject(L, 2, typeof(TweenCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(TweenCallback), func) as TweenCallback);
			}
			TweenParams o = tweenParams.OnKill(action);
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
	private static int OnWaypointChange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			TweenCallback<int> action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (TweenCallback<int>)ToLua.CheckObject(L, 2, typeof(TweenCallback<int>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(TweenCallback<int>), func) as TweenCallback<int>);
			}
			TweenParams o = tweenParams.OnWaypointChange(action);
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
	private static int SetDelay(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			float delay = (float)LuaDLL.luaL_checknumber(L, 2);
			TweenParams o = tweenParams.SetDelay(delay);
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
	private static int SetRelative(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			bool relative = LuaDLL.luaL_checkboolean(L, 2);
			TweenParams o = tweenParams.SetRelative(relative);
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
	private static int SetSpeedBased(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TweenParams tweenParams = (TweenParams)ToLua.CheckObject(L, 1, typeof(TweenParams));
			bool speedBased = LuaDLL.luaL_checkboolean(L, 2);
			TweenParams o = tweenParams.SetSpeedBased(speedBased);
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
	private static int get_Params(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, TweenParams.Params);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
