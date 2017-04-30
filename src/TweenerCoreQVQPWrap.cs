using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using LuaInterface;
using System;
using UnityEngine;

public class TweenerCoreQVQPWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TweenerCore<Quaternion, Vector3, QuaternionOptions>), typeof(Tweener), "TweenerCoreQVQP");
		L.RegFunction("ChangeStartValue", new LuaCSFunction(TweenerCoreQVQPWrap.ChangeStartValue));
		L.RegFunction("ChangeEndValue", new LuaCSFunction(TweenerCoreQVQPWrap.ChangeEndValue));
		L.RegFunction("ChangeValues", new LuaCSFunction(TweenerCoreQVQPWrap.ChangeValues));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("startValue", new LuaCSFunction(TweenerCoreQVQPWrap.get_startValue), new LuaCSFunction(TweenerCoreQVQPWrap.set_startValue));
		L.RegVar("endValue", new LuaCSFunction(TweenerCoreQVQPWrap.get_endValue), new LuaCSFunction(TweenerCoreQVQPWrap.set_endValue));
		L.RegVar("changeValue", new LuaCSFunction(TweenerCoreQVQPWrap.get_changeValue), new LuaCSFunction(TweenerCoreQVQPWrap.set_changeValue));
		L.RegVar("plugOptions", new LuaCSFunction(TweenerCoreQVQPWrap.get_plugOptions), new LuaCSFunction(TweenerCoreQVQPWrap.set_plugOptions));
		L.RegVar("getter", new LuaCSFunction(TweenerCoreQVQPWrap.get_getter), new LuaCSFunction(TweenerCoreQVQPWrap.set_getter));
		L.RegVar("setter", new LuaCSFunction(TweenerCoreQVQPWrap.get_setter), new LuaCSFunction(TweenerCoreQVQPWrap.set_setter));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangeStartValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)ToLua.CheckObject(L, 1, typeof(TweenerCore<Quaternion, Vector3, QuaternionOptions>));
			object newStartValue = ToLua.ToVarObject(L, 2);
			float newDuration = (float)LuaDLL.luaL_checknumber(L, 3);
			Tweener o = tweenerCore.ChangeStartValue(newStartValue, newDuration);
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
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(TweenerCore<Quaternion, Vector3, QuaternionOptions>), typeof(object), typeof(bool)))
			{
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)ToLua.ToObject(L, 1);
				object newEndValue = ToLua.ToVarObject(L, 2);
				bool snapStartValue = LuaDLL.lua_toboolean(L, 3);
				Tweener o = tweenerCore.ChangeEndValue(newEndValue, snapStartValue);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(TweenerCore<Quaternion, Vector3, QuaternionOptions>), typeof(object), typeof(float), typeof(bool)))
			{
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)ToLua.ToObject(L, 1);
				object newEndValue2 = ToLua.ToVarObject(L, 2);
				float newDuration = (float)LuaDLL.lua_tonumber(L, 3);
				bool snapStartValue2 = LuaDLL.lua_toboolean(L, 4);
				Tweener o2 = tweenerCore2.ChangeEndValue(newEndValue2, newDuration, snapStartValue2);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion,UnityEngine.Vector3,DG.Tweening.Plugins.Options.QuaternionOptions>.ChangeEndValue");
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
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)ToLua.CheckObject(L, 1, typeof(TweenerCore<Quaternion, Vector3, QuaternionOptions>));
			object newStartValue = ToLua.ToVarObject(L, 2);
			object newEndValue = ToLua.ToVarObject(L, 3);
			float newDuration = (float)LuaDLL.luaL_checknumber(L, 4);
			Tweener o = tweenerCore.ChangeValues(newStartValue, newEndValue, newDuration);
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
	private static int get_startValue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)obj;
			Vector3 startValue = tweenerCore.startValue;
			ToLua.Push(L, startValue);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index startValue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_endValue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)obj;
			Vector3 endValue = tweenerCore.endValue;
			ToLua.Push(L, endValue);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index endValue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_changeValue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)obj;
			Vector3 changeValue = tweenerCore.changeValue;
			ToLua.Push(L, changeValue);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index changeValue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_plugOptions(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)obj;
			QuaternionOptions plugOptions = tweenerCore.plugOptions;
			ToLua.PushValue(L, plugOptions);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index plugOptions on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_getter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)obj;
			DOGetter<Quaternion> getter = tweenerCore.getter;
			ToLua.Push(L, getter);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index getter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_setter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)obj;
			DOSetter<Quaternion> setter = tweenerCore.setter;
			ToLua.Push(L, setter);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index setter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_startValue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)obj;
			Vector3 startValue = ToLua.ToVector3(L, 2);
			tweenerCore.startValue = startValue;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index startValue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_endValue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)obj;
			Vector3 endValue = ToLua.ToVector3(L, 2);
			tweenerCore.endValue = endValue;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index endValue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_changeValue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)obj;
			Vector3 changeValue = ToLua.ToVector3(L, 2);
			tweenerCore.changeValue = changeValue;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index changeValue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_plugOptions(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)obj;
			QuaternionOptions plugOptions = (QuaternionOptions)ToLua.CheckObject(L, 2, typeof(QuaternionOptions));
			tweenerCore.plugOptions = plugOptions;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index plugOptions on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_getter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			DOGetter<Quaternion> getter;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				getter = (DOGetter<Quaternion>)ToLua.CheckObject(L, 2, typeof(DOGetter<Quaternion>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				getter = (DelegateFactory.CreateDelegate(typeof(DOGetter<Quaternion>), func) as DOGetter<Quaternion>);
			}
			tweenerCore.getter = getter;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index getter on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_setter(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			DOSetter<Quaternion> setter;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				setter = (DOSetter<Quaternion>)ToLua.CheckObject(L, 2, typeof(DOSetter<Quaternion>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				setter = (DelegateFactory.CreateDelegate(typeof(DOSetter<Quaternion>), func) as DOSetter<Quaternion>);
			}
			tweenerCore.setter = setter;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index setter on a nil value");
		}
		return result;
	}
}
