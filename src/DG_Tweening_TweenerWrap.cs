using DG.Tweening;
using LuaInterface;
using System;
using UnityEngine;

public class DG_Tweening_TweenerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Tweener), typeof(Tween), null);
		L.RegFunction("ChangeStartValue", new LuaCSFunction(DG_Tweening_TweenerWrap.ChangeStartValue));
		L.RegFunction("ChangeEndValue", new LuaCSFunction(DG_Tweening_TweenerWrap.ChangeEndValue));
		L.RegFunction("ChangeValues", new LuaCSFunction(DG_Tweening_TweenerWrap.ChangeValues));
		L.RegFunction("SetSpeedBased", new LuaCSFunction(DG_Tweening_TweenerWrap.SetSpeedBased));
		L.RegFunction("SetRelative", new LuaCSFunction(DG_Tweening_TweenerWrap.SetRelative));
		L.RegFunction("SetDelay", new LuaCSFunction(DG_Tweening_TweenerWrap.SetDelay));
		L.RegFunction("From", new LuaCSFunction(DG_Tweening_TweenerWrap.From));
		L.RegFunction("SetAs", new LuaCSFunction(DG_Tweening_TweenerWrap.SetAs));
		L.RegFunction("OnWaypointChange", new LuaCSFunction(DG_Tweening_TweenerWrap.OnWaypointChange));
		L.RegFunction("OnKill", new LuaCSFunction(DG_Tweening_TweenerWrap.OnKill));
		L.RegFunction("OnComplete", new LuaCSFunction(DG_Tweening_TweenerWrap.OnComplete));
		L.RegFunction("OnStepComplete", new LuaCSFunction(DG_Tweening_TweenerWrap.OnStepComplete));
		L.RegFunction("OnUpdate", new LuaCSFunction(DG_Tweening_TweenerWrap.OnUpdate));
		L.RegFunction("OnRewind", new LuaCSFunction(DG_Tweening_TweenerWrap.OnRewind));
		L.RegFunction("OnPause", new LuaCSFunction(DG_Tweening_TweenerWrap.OnPause));
		L.RegFunction("OnPlay", new LuaCSFunction(DG_Tweening_TweenerWrap.OnPlay));
		L.RegFunction("OnStart", new LuaCSFunction(DG_Tweening_TweenerWrap.OnStart));
		L.RegFunction("SetUpdate", new LuaCSFunction(DG_Tweening_TweenerWrap.SetUpdate));
		L.RegFunction("SetRecyclable", new LuaCSFunction(DG_Tweening_TweenerWrap.SetRecyclable));
		L.RegFunction("SetEase", new LuaCSFunction(DG_Tweening_TweenerWrap.SetEase));
		L.RegFunction("SetLoops", new LuaCSFunction(DG_Tweening_TweenerWrap.SetLoops));
		L.RegFunction("SetTarget", new LuaCSFunction(DG_Tweening_TweenerWrap.SetTarget));
		L.RegFunction("SetId", new LuaCSFunction(DG_Tweening_TweenerWrap.SetId));
		L.RegFunction("SetAutoKill", new LuaCSFunction(DG_Tweening_TweenerWrap.SetAutoKill));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangeStartValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Tweener tweener = (Tweener)ToLua.CheckObject(L, 1, typeof(Tweener));
			object newStartValue = ToLua.ToVarObject(L, 2);
			float newDuration = (float)LuaDLL.luaL_checknumber(L, 3);
			Tweener o = tweener.ChangeStartValue(newStartValue, newDuration);
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
	private static int ChangeEndValue(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Tweener), typeof(object), typeof(bool)))
			{
				Tweener tweener = (Tweener)ToLua.ToObject(L, 1);
				object newEndValue = ToLua.ToVarObject(L, 2);
				bool snapStartValue = LuaDLL.lua_toboolean(L, 3);
				Tweener o = tweener.ChangeEndValue(newEndValue, snapStartValue);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Tweener), typeof(object), typeof(float), typeof(bool)))
			{
				Tweener tweener2 = (Tweener)ToLua.ToObject(L, 1);
				object newEndValue2 = ToLua.ToVarObject(L, 2);
				float newDuration = (float)LuaDLL.lua_tonumber(L, 3);
				bool snapStartValue2 = LuaDLL.lua_toboolean(L, 4);
				Tweener o2 = tweener2.ChangeEndValue(newEndValue2, newDuration, snapStartValue2);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Tweener.ChangeEndValue");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangeValues(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			Tweener tweener = (Tweener)ToLua.CheckObject(L, 1, typeof(Tweener));
			object newStartValue = ToLua.ToVarObject(L, 2);
			object newEndValue = ToLua.ToVarObject(L, 3);
			float newDuration = (float)LuaDLL.luaL_checknumber(L, 4);
			Tweener o = tweener.ChangeValues(newStartValue, newEndValue, newDuration);
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Tween)))
			{
				Tweener speedBased = (Tweener)ToLua.ToObject(L, 1);
				Tween o = speedBased.SetSpeedBased<Tweener>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(bool)))
			{
				Tweener t = (Tweener)ToLua.ToObject(L, 1);
				bool isSpeedBased = LuaDLL.lua_toboolean(L, 2);
				Tween o2 = t.SetSpeedBased(isSpeedBased);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Tweener.SetSpeedBased");
			}
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Tween)))
			{
				Tweener relative = (Tweener)ToLua.ToObject(L, 1);
				Tween o = relative.SetRelative<Tweener>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(bool)))
			{
				Tweener t = (Tweener)ToLua.ToObject(L, 1);
				bool isRelative = LuaDLL.lua_toboolean(L, 2);
				Tween o2 = t.SetRelative(isRelative);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Tweener.SetRelative");
			}
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
			Tweener t = (Tweener)ToLua.CheckObject(L, 1, typeof(Tweener));
			float delay = (float)LuaDLL.luaL_checknumber(L, 2);
			Tween o = t.SetDelay(delay);
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
	private static int From(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Tweener)))
			{
				Tweener t = (Tweener)ToLua.ToObject(L, 1);
				Tweener o = t.From<Tweener>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tweener), typeof(bool)))
			{
				Tweener t2 = (Tweener)ToLua.ToObject(L, 1);
				bool isRelative = LuaDLL.lua_toboolean(L, 2);
				Tweener o2 = t2.From(isRelative);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Tweener.From");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetAs(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(Tween)))
			{
				Tweener t = (Tweener)ToLua.ToObject(L, 1);
				Tween asTween = (Tween)ToLua.ToObject(L, 2);
				Tween o = t.SetAs(asTween);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(TweenParams)))
			{
				Tweener t2 = (Tweener)ToLua.ToObject(L, 1);
				TweenParams tweenParams = (TweenParams)ToLua.ToObject(L, 2);
				Tween o2 = t2.SetAs(tweenParams);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Tweener.SetAs");
			}
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
			Tweener t = (Tweener)ToLua.CheckObject(L, 1, typeof(Tweener));
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
			Tween o = t.OnWaypointChange(action);
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
			Tweener t = (Tweener)ToLua.CheckObject(L, 1, typeof(Tweener));
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
			Tween o = t.OnKill(action);
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
			Tweener t = (Tweener)ToLua.CheckObject(L, 1, typeof(Tweener));
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
			Tween o = t.OnComplete(action);
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
			Tweener t = (Tweener)ToLua.CheckObject(L, 1, typeof(Tweener));
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
			Tween o = t.OnStepComplete(action);
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
			Tweener t = (Tweener)ToLua.CheckObject(L, 1, typeof(Tweener));
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
			Tween o = t.OnUpdate(action);
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
			Tweener t = (Tweener)ToLua.CheckObject(L, 1, typeof(Tweener));
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
			Tween o = t.OnRewind(action);
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
	private static int OnPause(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Tweener t = (Tweener)ToLua.CheckObject(L, 1, typeof(Tweener));
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
			Tween o = t.OnPause(action);
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
			Tweener t = (Tweener)ToLua.CheckObject(L, 1, typeof(Tweener));
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
			Tween o = t.OnPlay(action);
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
	private static int OnStart(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Tweener t = (Tweener)ToLua.CheckObject(L, 1, typeof(Tweener));
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
			Tween o = t.OnStart(action);
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(bool)))
			{
				Tweener t = (Tweener)ToLua.ToObject(L, 1);
				bool isIndependentUpdate = LuaDLL.lua_toboolean(L, 2);
				Tween o = t.SetUpdate(isIndependentUpdate);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(UpdateType)))
			{
				Tweener t2 = (Tweener)ToLua.ToObject(L, 1);
				UpdateType updateType = (UpdateType)((int)ToLua.ToObject(L, 2));
				Tween o2 = t2.SetUpdate(updateType);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(UpdateType), typeof(bool)))
			{
				Tweener t3 = (Tweener)ToLua.ToObject(L, 1);
				UpdateType updateType2 = (UpdateType)((int)ToLua.ToObject(L, 2));
				bool isIndependentUpdate2 = LuaDLL.lua_toboolean(L, 3);
				Tween o3 = t3.SetUpdate(updateType2, isIndependentUpdate2);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Tweener.SetUpdate");
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Tween)))
			{
				Tweener recyclable = (Tweener)ToLua.ToObject(L, 1);
				Tween o = recyclable.SetRecyclable<Tweener>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(bool)))
			{
				Tweener t = (Tweener)ToLua.ToObject(L, 1);
				bool recyclable2 = LuaDLL.lua_toboolean(L, 2);
				Tween o2 = t.SetRecyclable(recyclable2);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Tweener.SetRecyclable");
			}
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
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(Ease)))
			{
				Tweener t = (Tweener)ToLua.ToObject(L, 1);
				Ease ease = (Ease)((int)ToLua.ToObject(L, 2));
				Tween o = t.SetEase(ease);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(AnimationCurve)))
			{
				Tweener t2 = (Tweener)ToLua.ToObject(L, 1);
				AnimationCurve animCurve = (AnimationCurve)ToLua.ToObject(L, 2);
				Tween o2 = t2.SetEase(animCurve);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(EaseFunction)))
			{
				Tweener t3 = (Tweener)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				EaseFunction customEase;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					customEase = (EaseFunction)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					customEase = (DelegateFactory.CreateDelegate(typeof(EaseFunction), func) as EaseFunction);
				}
				Tween o3 = t3.SetEase(customEase);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(Ease), typeof(float)))
			{
				Tweener t4 = (Tweener)ToLua.ToObject(L, 1);
				Ease ease2 = (Ease)((int)ToLua.ToObject(L, 2));
				float overshoot = (float)LuaDLL.lua_tonumber(L, 3);
				Tween o4 = t4.SetEase(ease2, overshoot);
				ToLua.PushObject(L, o4);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(Ease), typeof(float), typeof(float)))
			{
				Tweener t5 = (Tweener)ToLua.ToObject(L, 1);
				Ease ease3 = (Ease)((int)ToLua.ToObject(L, 2));
				float amplitude = (float)LuaDLL.lua_tonumber(L, 3);
				float period = (float)LuaDLL.lua_tonumber(L, 4);
				Tween o5 = t5.SetEase(ease3, amplitude, period);
				ToLua.PushObject(L, o5);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Tweener.SetEase");
			}
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(int)))
			{
				Tweener t = (Tweener)ToLua.ToObject(L, 1);
				int loops = (int)LuaDLL.lua_tonumber(L, 2);
				Tween o = t.SetLoops(loops);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(int), typeof(LoopType)))
			{
				Tweener t2 = (Tweener)ToLua.ToObject(L, 1);
				int loops2 = (int)LuaDLL.lua_tonumber(L, 2);
				LoopType loopType = (LoopType)((int)ToLua.ToObject(L, 3));
				Tween o2 = t2.SetLoops(loops2, loopType);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Tweener.SetLoops");
			}
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
			Tweener t = (Tweener)ToLua.CheckObject(L, 1, typeof(Tweener));
			object target = ToLua.ToVarObject(L, 2);
			Tween o = t.SetTarget(target);
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
			Tweener t = (Tweener)ToLua.CheckObject(L, 1, typeof(Tweener));
			object id = ToLua.ToVarObject(L, 2);
			Tween o = t.SetId(id);
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Tween)))
			{
				Tweener autoKill = (Tweener)ToLua.ToObject(L, 1);
				Tween o = autoKill.SetAutoKill<Tweener>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(bool)))
			{
				Tweener t = (Tweener)ToLua.ToObject(L, 1);
				bool autoKillOnCompletion = LuaDLL.lua_toboolean(L, 2);
				Tween o2 = t.SetAutoKill(autoKillOnCompletion);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Tweener.SetAutoKill");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
