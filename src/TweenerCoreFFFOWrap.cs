using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using LuaInterface;
using System;

public class TweenerCoreFFFOWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TweenerCore<float, float, FloatOptions>), typeof(Tweener), "TweenerCoreFFFO");
		L.RegFunction("ChangeStartValue", new LuaCSFunction(TweenerCoreFFFOWrap.ChangeStartValue));
		L.RegFunction("ChangeEndValue", new LuaCSFunction(TweenerCoreFFFOWrap.ChangeEndValue));
		L.RegFunction("ChangeValues", new LuaCSFunction(TweenerCoreFFFOWrap.ChangeValues));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("startValue", new LuaCSFunction(TweenerCoreFFFOWrap.get_startValue), new LuaCSFunction(TweenerCoreFFFOWrap.set_startValue));
		L.RegVar("endValue", new LuaCSFunction(TweenerCoreFFFOWrap.get_endValue), new LuaCSFunction(TweenerCoreFFFOWrap.set_endValue));
		L.RegVar("changeValue", new LuaCSFunction(TweenerCoreFFFOWrap.get_changeValue), new LuaCSFunction(TweenerCoreFFFOWrap.set_changeValue));
		L.RegVar("plugOptions", new LuaCSFunction(TweenerCoreFFFOWrap.get_plugOptions), new LuaCSFunction(TweenerCoreFFFOWrap.set_plugOptions));
		L.RegVar("getter", new LuaCSFunction(TweenerCoreFFFOWrap.get_getter), new LuaCSFunction(TweenerCoreFFFOWrap.set_getter));
		L.RegVar("setter", new LuaCSFunction(TweenerCoreFFFOWrap.get_setter), new LuaCSFunction(TweenerCoreFFFOWrap.set_setter));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangeStartValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)ToLua.CheckObject(L, 1, typeof(TweenerCore<float, float, FloatOptions>));
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
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(TweenerCore<float, float, FloatOptions>), typeof(object), typeof(bool)))
			{
				TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)ToLua.ToObject(L, 1);
				object newEndValue = ToLua.ToVarObject(L, 2);
				bool snapStartValue = LuaDLL.lua_toboolean(L, 3);
				Tweener o = tweenerCore.ChangeEndValue(newEndValue, snapStartValue);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(TweenerCore<float, float, FloatOptions>), typeof(object), typeof(float), typeof(bool)))
			{
				TweenerCore<float, float, FloatOptions> tweenerCore2 = (TweenerCore<float, float, FloatOptions>)ToLua.ToObject(L, 1);
				object newEndValue2 = ToLua.ToVarObject(L, 2);
				float newDuration = (float)LuaDLL.lua_tonumber(L, 3);
				bool snapStartValue2 = LuaDLL.lua_toboolean(L, 4);
				Tweener o2 = tweenerCore2.ChangeEndValue(newEndValue2, newDuration, snapStartValue2);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Core.TweenerCore<float,float,DG.Tweening.Plugins.Options.FloatOptions>.ChangeEndValue");
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
			TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)ToLua.CheckObject(L, 1, typeof(TweenerCore<float, float, FloatOptions>));
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
			TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)obj;
			float startValue = tweenerCore.startValue;
			LuaDLL.lua_pushnumber(L, (double)startValue);
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
			TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)obj;
			float endValue = tweenerCore.endValue;
			LuaDLL.lua_pushnumber(L, (double)endValue);
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
			TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)obj;
			float changeValue = tweenerCore.changeValue;
			LuaDLL.lua_pushnumber(L, (double)changeValue);
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
			TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)obj;
			FloatOptions plugOptions = tweenerCore.plugOptions;
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
			TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)obj;
			DOGetter<float> getter = tweenerCore.getter;
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
			TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)obj;
			DOSetter<float> setter = tweenerCore.setter;
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
			TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)obj;
			float startValue = (float)LuaDLL.luaL_checknumber(L, 2);
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
			TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)obj;
			float endValue = (float)LuaDLL.luaL_checknumber(L, 2);
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
			TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)obj;
			float changeValue = (float)LuaDLL.luaL_checknumber(L, 2);
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
			TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)obj;
			FloatOptions plugOptions = (FloatOptions)ToLua.CheckObject(L, 2, typeof(FloatOptions));
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
			TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			DOGetter<float> getter;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				getter = (DOGetter<float>)ToLua.CheckObject(L, 2, typeof(DOGetter<float>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				getter = (DelegateFactory.CreateDelegate(typeof(DOGetter<float>), func) as DOGetter<float>);
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
			TweenerCore<float, float, FloatOptions> tweenerCore = (TweenerCore<float, float, FloatOptions>)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			DOSetter<float> setter;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				setter = (DOSetter<float>)ToLua.CheckObject(L, 2, typeof(DOSetter<float>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				setter = (DelegateFactory.CreateDelegate(typeof(DOSetter<float>), func) as DOSetter<float>);
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
