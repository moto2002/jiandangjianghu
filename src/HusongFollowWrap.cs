using LuaInterface;
using System;
using UnityEngine;

public class HusongFollowWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(HusongFollow), typeof(MonoBehaviour), null);
		L.RegFunction("__eq", new LuaCSFunction(HusongFollowWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("self", new LuaCSFunction(HusongFollowWrap.get_self), new LuaCSFunction(HusongFollowWrap.set_self));
		L.RegVar("targetId", new LuaCSFunction(HusongFollowWrap.get_targetId), new LuaCSFunction(HusongFollowWrap.set_targetId));
		L.RegVar("targetEntity", new LuaCSFunction(HusongFollowWrap.get_targetEntity), new LuaCSFunction(HusongFollowWrap.set_targetEntity));
		L.EndClass();
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
	private static int get_self(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HusongFollow husongFollow = (HusongFollow)obj;
			SceneEntity self = husongFollow.self;
			ToLua.Push(L, self);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index self on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetId(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HusongFollow husongFollow = (HusongFollow)obj;
			string targetId = husongFollow.targetId;
			LuaDLL.lua_pushstring(L, targetId);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetId on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetEntity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HusongFollow husongFollow = (HusongFollow)obj;
			SceneEntity targetEntity = husongFollow.targetEntity;
			ToLua.Push(L, targetEntity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetEntity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_self(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HusongFollow husongFollow = (HusongFollow)obj;
			SceneEntity self = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			husongFollow.self = self;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index self on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_targetId(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HusongFollow husongFollow = (HusongFollow)obj;
			string targetId = ToLua.CheckString(L, 2);
			husongFollow.targetId = targetId;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetId on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_targetEntity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			HusongFollow husongFollow = (HusongFollow)obj;
			SceneEntity targetEntity = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			husongFollow.targetEntity = targetEntity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetEntity on a nil value");
		}
		return result;
	}
}
