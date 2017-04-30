using DG.Tweening;
using LuaInterface;
using System;
using UnityEngine;

public class DG_Tweening_SequenceWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Sequence), typeof(Tween), null);
		L.RegFunction("SetSpeedBased", new LuaCSFunction(DG_Tweening_SequenceWrap.SetSpeedBased));
		L.RegFunction("SetRelative", new LuaCSFunction(DG_Tweening_SequenceWrap.SetRelative));
		L.RegFunction("SetDelay", new LuaCSFunction(DG_Tweening_SequenceWrap.SetDelay));
		L.RegFunction("InsertCallback", new LuaCSFunction(DG_Tweening_SequenceWrap.InsertCallback));
		L.RegFunction("PrependCallback", new LuaCSFunction(DG_Tweening_SequenceWrap.PrependCallback));
		L.RegFunction("AppendCallback", new LuaCSFunction(DG_Tweening_SequenceWrap.AppendCallback));
		L.RegFunction("PrependInterval", new LuaCSFunction(DG_Tweening_SequenceWrap.PrependInterval));
		L.RegFunction("AppendInterval", new LuaCSFunction(DG_Tweening_SequenceWrap.AppendInterval));
		L.RegFunction("Insert", new LuaCSFunction(DG_Tweening_SequenceWrap.Insert));
		L.RegFunction("Join", new LuaCSFunction(DG_Tweening_SequenceWrap.Join));
		L.RegFunction("Prepend", new LuaCSFunction(DG_Tweening_SequenceWrap.Prepend));
		L.RegFunction("Append", new LuaCSFunction(DG_Tweening_SequenceWrap.Append));
		L.RegFunction("SetAs", new LuaCSFunction(DG_Tweening_SequenceWrap.SetAs));
		L.RegFunction("OnWaypointChange", new LuaCSFunction(DG_Tweening_SequenceWrap.OnWaypointChange));
		L.RegFunction("OnKill", new LuaCSFunction(DG_Tweening_SequenceWrap.OnKill));
		L.RegFunction("OnComplete", new LuaCSFunction(DG_Tweening_SequenceWrap.OnComplete));
		L.RegFunction("OnStepComplete", new LuaCSFunction(DG_Tweening_SequenceWrap.OnStepComplete));
		L.RegFunction("OnUpdate", new LuaCSFunction(DG_Tweening_SequenceWrap.OnUpdate));
		L.RegFunction("OnRewind", new LuaCSFunction(DG_Tweening_SequenceWrap.OnRewind));
		L.RegFunction("OnPause", new LuaCSFunction(DG_Tweening_SequenceWrap.OnPause));
		L.RegFunction("OnPlay", new LuaCSFunction(DG_Tweening_SequenceWrap.OnPlay));
		L.RegFunction("OnStart", new LuaCSFunction(DG_Tweening_SequenceWrap.OnStart));
		L.RegFunction("SetUpdate", new LuaCSFunction(DG_Tweening_SequenceWrap.SetUpdate));
		L.RegFunction("SetRecyclable", new LuaCSFunction(DG_Tweening_SequenceWrap.SetRecyclable));
		L.RegFunction("SetEase", new LuaCSFunction(DG_Tweening_SequenceWrap.SetEase));
		L.RegFunction("SetLoops", new LuaCSFunction(DG_Tweening_SequenceWrap.SetLoops));
		L.RegFunction("SetTarget", new LuaCSFunction(DG_Tweening_SequenceWrap.SetTarget));
		L.RegFunction("SetId", new LuaCSFunction(DG_Tweening_SequenceWrap.SetId));
		L.RegFunction("SetAutoKill", new LuaCSFunction(DG_Tweening_SequenceWrap.SetAutoKill));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
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
				Sequence speedBased = (Sequence)ToLua.ToObject(L, 1);
				Tween o = speedBased.SetSpeedBased<Sequence>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(bool)))
			{
				Sequence t = (Sequence)ToLua.ToObject(L, 1);
				bool isSpeedBased = LuaDLL.lua_toboolean(L, 2);
				Tween o2 = t.SetSpeedBased(isSpeedBased);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Sequence.SetSpeedBased");
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
				Sequence relative = (Sequence)ToLua.ToObject(L, 1);
				Tween o = relative.SetRelative<Sequence>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(bool)))
			{
				Sequence t = (Sequence)ToLua.ToObject(L, 1);
				bool isRelative = LuaDLL.lua_toboolean(L, 2);
				Tween o2 = t.SetRelative(isRelative);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Sequence.SetRelative");
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
			Sequence t = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
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
	private static int InsertCallback(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Sequence s = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
			float atPosition = (float)LuaDLL.luaL_checknumber(L, 2);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			TweenCallback callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (TweenCallback)ToLua.CheckObject(L, 3, typeof(TweenCallback));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				callback = (DelegateFactory.CreateDelegate(typeof(TweenCallback), func) as TweenCallback);
			}
			Sequence o = s.InsertCallback(atPosition, callback);
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
	private static int PrependCallback(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Sequence s = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
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
			Sequence o = s.PrependCallback(callback);
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
	private static int AppendCallback(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Sequence s = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
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
			Sequence o = s.AppendCallback(callback);
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
	private static int PrependInterval(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Sequence s = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
			float interval = (float)LuaDLL.luaL_checknumber(L, 2);
			Sequence o = s.PrependInterval(interval);
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
	private static int AppendInterval(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Sequence s = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
			float interval = (float)LuaDLL.luaL_checknumber(L, 2);
			Sequence o = s.AppendInterval(interval);
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
	private static int Insert(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Sequence s = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
			float atPosition = (float)LuaDLL.luaL_checknumber(L, 2);
			Tween t = (Tween)ToLua.CheckObject(L, 3, typeof(Tween));
			Sequence o = s.Insert(atPosition, t);
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
	private static int Join(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Sequence s = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
			Tween t = (Tween)ToLua.CheckObject(L, 2, typeof(Tween));
			Sequence o = s.Join(t);
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
	private static int Prepend(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Sequence s = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
			Tween t = (Tween)ToLua.CheckObject(L, 2, typeof(Tween));
			Sequence o = s.Prepend(t);
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
	private static int Append(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Sequence s = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
			Tween t = (Tween)ToLua.CheckObject(L, 2, typeof(Tween));
			Sequence o = s.Append(t);
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
	private static int SetAs(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(Tween)))
			{
				Sequence t = (Sequence)ToLua.ToObject(L, 1);
				Tween asTween = (Tween)ToLua.ToObject(L, 2);
				Tween o = t.SetAs(asTween);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(TweenParams)))
			{
				Sequence t2 = (Sequence)ToLua.ToObject(L, 1);
				TweenParams tweenParams = (TweenParams)ToLua.ToObject(L, 2);
				Tween o2 = t2.SetAs(tweenParams);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Sequence.SetAs");
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
			Sequence t = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
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
			Sequence t = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
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
			Sequence t = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
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
			Sequence t = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
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
			Sequence t = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
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
			Sequence t = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
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
			Sequence t = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
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
			Sequence t = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
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
			Sequence t = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
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
				Sequence t = (Sequence)ToLua.ToObject(L, 1);
				bool isIndependentUpdate = LuaDLL.lua_toboolean(L, 2);
				Tween o = t.SetUpdate(isIndependentUpdate);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(UpdateType)))
			{
				Sequence t2 = (Sequence)ToLua.ToObject(L, 1);
				UpdateType updateType = (UpdateType)((int)ToLua.ToObject(L, 2));
				Tween o2 = t2.SetUpdate(updateType);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(UpdateType), typeof(bool)))
			{
				Sequence t3 = (Sequence)ToLua.ToObject(L, 1);
				UpdateType updateType2 = (UpdateType)((int)ToLua.ToObject(L, 2));
				bool isIndependentUpdate2 = LuaDLL.lua_toboolean(L, 3);
				Tween o3 = t3.SetUpdate(updateType2, isIndependentUpdate2);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Sequence.SetUpdate");
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
				Sequence recyclable = (Sequence)ToLua.ToObject(L, 1);
				Tween o = recyclable.SetRecyclable<Sequence>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(bool)))
			{
				Sequence t = (Sequence)ToLua.ToObject(L, 1);
				bool recyclable2 = LuaDLL.lua_toboolean(L, 2);
				Tween o2 = t.SetRecyclable(recyclable2);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Sequence.SetRecyclable");
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
				Sequence t = (Sequence)ToLua.ToObject(L, 1);
				Ease ease = (Ease)((int)ToLua.ToObject(L, 2));
				Tween o = t.SetEase(ease);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(AnimationCurve)))
			{
				Sequence t2 = (Sequence)ToLua.ToObject(L, 1);
				AnimationCurve animCurve = (AnimationCurve)ToLua.ToObject(L, 2);
				Tween o2 = t2.SetEase(animCurve);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(EaseFunction)))
			{
				Sequence t3 = (Sequence)ToLua.ToObject(L, 1);
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
				Sequence t4 = (Sequence)ToLua.ToObject(L, 1);
				Ease ease2 = (Ease)((int)ToLua.ToObject(L, 2));
				float overshoot = (float)LuaDLL.lua_tonumber(L, 3);
				Tween o4 = t4.SetEase(ease2, overshoot);
				ToLua.PushObject(L, o4);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(Ease), typeof(float), typeof(float)))
			{
				Sequence t5 = (Sequence)ToLua.ToObject(L, 1);
				Ease ease3 = (Ease)((int)ToLua.ToObject(L, 2));
				float amplitude = (float)LuaDLL.lua_tonumber(L, 3);
				float period = (float)LuaDLL.lua_tonumber(L, 4);
				Tween o5 = t5.SetEase(ease3, amplitude, period);
				ToLua.PushObject(L, o5);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Sequence.SetEase");
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
				Sequence t = (Sequence)ToLua.ToObject(L, 1);
				int loops = (int)LuaDLL.lua_tonumber(L, 2);
				Tween o = t.SetLoops(loops);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(int), typeof(LoopType)))
			{
				Sequence t2 = (Sequence)ToLua.ToObject(L, 1);
				int loops2 = (int)LuaDLL.lua_tonumber(L, 2);
				LoopType loopType = (LoopType)((int)ToLua.ToObject(L, 3));
				Tween o2 = t2.SetLoops(loops2, loopType);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Sequence.SetLoops");
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
			Sequence t = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
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
			Sequence t = (Sequence)ToLua.CheckObject(L, 1, typeof(Sequence));
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
				Sequence autoKill = (Sequence)ToLua.ToObject(L, 1);
				Tween o = autoKill.SetAutoKill<Sequence>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(bool)))
			{
				Sequence t = (Sequence)ToLua.ToObject(L, 1);
				bool autoKillOnCompletion = LuaDLL.lua_toboolean(L, 2);
				Tween o2 = t.SetAutoKill(autoKillOnCompletion);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Sequence.SetAutoKill");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
