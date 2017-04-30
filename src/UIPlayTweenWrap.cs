using AnimationOrTween;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayTweenWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIPlayTween), typeof(MonoBehaviour), null);
		L.RegFunction("Play", new LuaCSFunction(UIPlayTweenWrap.Play));
		L.RegFunction("__eq", new LuaCSFunction(UIPlayTweenWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("current", new LuaCSFunction(UIPlayTweenWrap.get_current), new LuaCSFunction(UIPlayTweenWrap.set_current));
		L.RegVar("tweenTarget", new LuaCSFunction(UIPlayTweenWrap.get_tweenTarget), new LuaCSFunction(UIPlayTweenWrap.set_tweenTarget));
		L.RegVar("tweenGroup", new LuaCSFunction(UIPlayTweenWrap.get_tweenGroup), new LuaCSFunction(UIPlayTweenWrap.set_tweenGroup));
		L.RegVar("trigger", new LuaCSFunction(UIPlayTweenWrap.get_trigger), new LuaCSFunction(UIPlayTweenWrap.set_trigger));
		L.RegVar("playDirection", new LuaCSFunction(UIPlayTweenWrap.get_playDirection), new LuaCSFunction(UIPlayTweenWrap.set_playDirection));
		L.RegVar("resetOnPlay", new LuaCSFunction(UIPlayTweenWrap.get_resetOnPlay), new LuaCSFunction(UIPlayTweenWrap.set_resetOnPlay));
		L.RegVar("resetIfDisabled", new LuaCSFunction(UIPlayTweenWrap.get_resetIfDisabled), new LuaCSFunction(UIPlayTweenWrap.set_resetIfDisabled));
		L.RegVar("ifDisabledOnPlay", new LuaCSFunction(UIPlayTweenWrap.get_ifDisabledOnPlay), new LuaCSFunction(UIPlayTweenWrap.set_ifDisabledOnPlay));
		L.RegVar("disableWhenFinished", new LuaCSFunction(UIPlayTweenWrap.get_disableWhenFinished), new LuaCSFunction(UIPlayTweenWrap.set_disableWhenFinished));
		L.RegVar("includeChildren", new LuaCSFunction(UIPlayTweenWrap.get_includeChildren), new LuaCSFunction(UIPlayTweenWrap.set_includeChildren));
		L.RegVar("onFinished", new LuaCSFunction(UIPlayTweenWrap.get_onFinished), new LuaCSFunction(UIPlayTweenWrap.set_onFinished));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Play(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIPlayTween uIPlayTween = (UIPlayTween)ToLua.CheckObject(L, 1, typeof(UIPlayTween));
			bool forward = LuaDLL.luaL_checkboolean(L, 2);
			uIPlayTween.Play(forward);
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
	private static int get_current(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UIPlayTween.current);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tweenTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			GameObject tweenTarget = uIPlayTween.tweenTarget;
			ToLua.Push(L, tweenTarget);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweenTarget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tweenGroup(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			int tweenGroup = uIPlayTween.tweenGroup;
			LuaDLL.lua_pushinteger(L, tweenGroup);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweenGroup on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_trigger(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			Trigger trigger = uIPlayTween.trigger;
			ToLua.Push(L, trigger);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index trigger on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_playDirection(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			Direction playDirection = uIPlayTween.playDirection;
			ToLua.Push(L, playDirection);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index playDirection on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_resetOnPlay(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			bool resetOnPlay = uIPlayTween.resetOnPlay;
			LuaDLL.lua_pushboolean(L, resetOnPlay);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index resetOnPlay on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_resetIfDisabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			bool resetIfDisabled = uIPlayTween.resetIfDisabled;
			LuaDLL.lua_pushboolean(L, resetIfDisabled);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index resetIfDisabled on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ifDisabledOnPlay(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			EnableCondition ifDisabledOnPlay = uIPlayTween.ifDisabledOnPlay;
			ToLua.Push(L, ifDisabledOnPlay);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ifDisabledOnPlay on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_disableWhenFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			DisableCondition disableWhenFinished = uIPlayTween.disableWhenFinished;
			ToLua.Push(L, disableWhenFinished);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index disableWhenFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_includeChildren(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			bool includeChildren = uIPlayTween.includeChildren;
			LuaDLL.lua_pushboolean(L, includeChildren);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index includeChildren on a nil value");
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
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			List<EventDelegate> onFinished = uIPlayTween.onFinished;
			ToLua.PushObject(L, onFinished);
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
			UIPlayTween current = (UIPlayTween)ToLua.CheckUnityObject(L, 2, typeof(UIPlayTween));
			UIPlayTween.current = current;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tweenTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			GameObject tweenTarget = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			uIPlayTween.tweenTarget = tweenTarget;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweenTarget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tweenGroup(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			int tweenGroup = (int)LuaDLL.luaL_checknumber(L, 2);
			uIPlayTween.tweenGroup = tweenGroup;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index tweenGroup on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_trigger(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			Trigger trigger = (Trigger)((int)ToLua.CheckObject(L, 2, typeof(Trigger)));
			uIPlayTween.trigger = trigger;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index trigger on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_playDirection(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			Direction playDirection = (Direction)((int)ToLua.CheckObject(L, 2, typeof(Direction)));
			uIPlayTween.playDirection = playDirection;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index playDirection on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_resetOnPlay(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			bool resetOnPlay = LuaDLL.luaL_checkboolean(L, 2);
			uIPlayTween.resetOnPlay = resetOnPlay;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index resetOnPlay on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_resetIfDisabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			bool resetIfDisabled = LuaDLL.luaL_checkboolean(L, 2);
			uIPlayTween.resetIfDisabled = resetIfDisabled;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index resetIfDisabled on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ifDisabledOnPlay(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			EnableCondition ifDisabledOnPlay = (EnableCondition)((int)ToLua.CheckObject(L, 2, typeof(EnableCondition)));
			uIPlayTween.ifDisabledOnPlay = ifDisabledOnPlay;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ifDisabledOnPlay on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_disableWhenFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			DisableCondition disableWhenFinished = (DisableCondition)((int)ToLua.CheckObject(L, 2, typeof(DisableCondition)));
			uIPlayTween.disableWhenFinished = disableWhenFinished;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index disableWhenFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_includeChildren(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			bool includeChildren = LuaDLL.luaL_checkboolean(L, 2);
			uIPlayTween.includeChildren = includeChildren;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index includeChildren on a nil value");
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
			UIPlayTween uIPlayTween = (UIPlayTween)obj;
			List<EventDelegate> onFinished = (List<EventDelegate>)ToLua.CheckObject(L, 2, typeof(List<EventDelegate>));
			uIPlayTween.onFinished = onFinished;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onFinished on a nil value");
		}
		return result;
	}
}
