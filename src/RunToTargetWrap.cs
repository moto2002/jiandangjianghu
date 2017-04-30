using LuaInterface;
using System;
using UnityEngine;

public class RunToTargetWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(RunToTarget), typeof(MonoBehaviour), null);
		L.RegFunction("clear", new LuaCSFunction(RunToTargetWrap.clear));
		L.RegFunction("Target", new LuaCSFunction(RunToTargetWrap.Target));
		L.RegFunction("HasMoveCmd", new LuaCSFunction(RunToTargetWrap.HasMoveCmd));
		L.RegFunction("__eq", new LuaCSFunction(RunToTargetWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("_self", new LuaCSFunction(RunToTargetWrap.get__self), new LuaCSFunction(RunToTargetWrap.set__self));
		L.RegVar("targetType", new LuaCSFunction(RunToTargetWrap.get_targetType), new LuaCSFunction(RunToTargetWrap.set_targetType));
		L.RegVar("targetArrived", new LuaCSFunction(RunToTargetWrap.get_targetArrived), new LuaCSFunction(RunToTargetWrap.set_targetArrived));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int clear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RunToTarget runToTarget = (RunToTarget)ToLua.CheckObject(L, 1, typeof(RunToTarget));
			runToTarget.clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Target(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(RunToTarget), typeof(Vector3), typeof(float), typeof(Move.PathFinished), typeof(int)))
			{
				RunToTarget runToTarget = (RunToTarget)ToLua.ToObject(L, 1);
				Vector3 pos = ToLua.ToVector3(L, 2);
				float radius = (float)LuaDLL.lua_tonumber(L, 3);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 4);
				Move.PathFinished @delegate;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					@delegate = (Move.PathFinished)ToLua.ToObject(L, 4);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 4);
					@delegate = (DelegateFactory.CreateDelegate(typeof(Move.PathFinished), func) as Move.PathFinished);
				}
				int type = (int)LuaDLL.lua_tonumber(L, 5);
				runToTarget.Target(pos, radius, @delegate, type);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(RunToTarget), typeof(GameObject), typeof(float), typeof(Move.PathFinished), typeof(int)))
			{
				RunToTarget runToTarget2 = (RunToTarget)ToLua.ToObject(L, 1);
				GameObject go = (GameObject)ToLua.ToObject(L, 2);
				float radius2 = (float)LuaDLL.lua_tonumber(L, 3);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 4);
				Move.PathFinished delegate2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					delegate2 = (Move.PathFinished)ToLua.ToObject(L, 4);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 4);
					delegate2 = (DelegateFactory.CreateDelegate(typeof(Move.PathFinished), func2) as Move.PathFinished);
				}
				int type2 = (int)LuaDLL.lua_tonumber(L, 5);
				runToTarget2.Target(go, radius2, delegate2, type2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: RunToTarget.Target");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int HasMoveCmd(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RunToTarget runToTarget = (RunToTarget)ToLua.CheckObject(L, 1, typeof(RunToTarget));
			bool value = runToTarget.HasMoveCmd();
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
	private static int get__self(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RunToTarget runToTarget = (RunToTarget)obj;
			SceneEntity self = runToTarget._self;
			ToLua.Push(L, self);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index _self on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RunToTarget runToTarget = (RunToTarget)obj;
			RunToTarget.TargetType targetType = runToTarget.targetType;
			ToLua.Push(L, targetType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetArrived(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RunToTarget runToTarget = (RunToTarget)obj;
			Move.PathFinished targetArrived = runToTarget.targetArrived;
			ToLua.Push(L, targetArrived);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetArrived on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set__self(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RunToTarget runToTarget = (RunToTarget)obj;
			SceneEntity self = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			runToTarget._self = self;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index _self on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_targetType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RunToTarget runToTarget = (RunToTarget)obj;
			RunToTarget.TargetType targetType = (RunToTarget.TargetType)((int)ToLua.CheckObject(L, 2, typeof(RunToTarget.TargetType)));
			runToTarget.targetType = targetType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_targetArrived(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RunToTarget runToTarget = (RunToTarget)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Move.PathFinished targetArrived;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				targetArrived = (Move.PathFinished)ToLua.CheckObject(L, 2, typeof(Move.PathFinished));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				targetArrived = (DelegateFactory.CreateDelegate(typeof(Move.PathFinished), func) as Move.PathFinished);
			}
			runToTarget.targetArrived = targetArrived;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetArrived on a nil value");
		}
		return result;
	}
}
