using LuaInterface;
using System;
using UnityEngine;

public class AnimationEventReceiverWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AnimationEventReceiver), typeof(MonoBehaviour), null);
		L.RegFunction("OnActionFinished", new LuaCSFunction(AnimationEventReceiverWrap.OnActionFinished));
		L.RegFunction("OnSkillActionStart", new LuaCSFunction(AnimationEventReceiverWrap.OnSkillActionStart));
		L.RegFunction("OnAttackFinished", new LuaCSFunction(AnimationEventReceiverWrap.OnAttackFinished));
		L.RegFunction("__eq", new LuaCSFunction(AnimationEventReceiverWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("ActionFinish", new LuaCSFunction(AnimationEventReceiverWrap.get_ActionFinish), new LuaCSFunction(AnimationEventReceiverWrap.set_ActionFinish));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnActionFinished(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AnimationEventReceiver animationEventReceiver = (AnimationEventReceiver)ToLua.CheckObject(L, 1, typeof(AnimationEventReceiver));
			int actionState = (int)LuaDLL.luaL_checknumber(L, 2);
			animationEventReceiver.OnActionFinished(actionState);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnSkillActionStart(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AnimationEventReceiver animationEventReceiver = (AnimationEventReceiver)ToLua.CheckObject(L, 1, typeof(AnimationEventReceiver));
			int actionState = (int)LuaDLL.luaL_checknumber(L, 2);
			animationEventReceiver.OnSkillActionStart(actionState);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnAttackFinished(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AnimationEventReceiver animationEventReceiver = (AnimationEventReceiver)ToLua.CheckObject(L, 1, typeof(AnimationEventReceiver));
			int actionState = (int)LuaDLL.luaL_checknumber(L, 2);
			animationEventReceiver.OnAttackFinished(actionState);
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
	private static int get_ActionFinish(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationEventReceiver animationEventReceiver = (AnimationEventReceiver)obj;
			Action<int> actionFinish = animationEventReceiver.ActionFinish;
			ToLua.Push(L, actionFinish);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ActionFinish on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ActionFinish(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AnimationEventReceiver animationEventReceiver = (AnimationEventReceiver)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<int> actionFinish;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				actionFinish = (Action<int>)ToLua.CheckObject(L, 2, typeof(Action<int>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				actionFinish = (DelegateFactory.CreateDelegate(typeof(Action<int>), func) as Action<int>);
			}
			animationEventReceiver.ActionFinish = actionFinish;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ActionFinish on a nil value");
		}
		return result;
	}
}
