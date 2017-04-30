using LuaInterface;
using System;
using UnityEngine;

public class RoleStateTransitionWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(RoleStateTransition), typeof(MonoBehaviour), null);
		L.RegFunction("IsInState", new LuaCSFunction(RoleStateTransitionWrap.IsInState));
		L.RegFunction("CanRide", new LuaCSFunction(RoleStateTransitionWrap.CanRide));
		L.RegFunction("CanWalkOnDirection", new LuaCSFunction(RoleStateTransitionWrap.CanWalkOnDirection));
		L.RegFunction("CanDaZuo", new LuaCSFunction(RoleStateTransitionWrap.CanDaZuo));
		L.RegFunction("AddState", new LuaCSFunction(RoleStateTransitionWrap.AddState));
		L.RegFunction("RemoveState", new LuaCSFunction(RoleStateTransitionWrap.RemoveState));
		L.RegFunction("ClearStateWhenDead", new LuaCSFunction(RoleStateTransitionWrap.ClearStateWhenDead));
		L.RegFunction("AddListener", new LuaCSFunction(RoleStateTransitionWrap.AddListener));
		L.RegFunction("RemoveListener", new LuaCSFunction(RoleStateTransitionWrap.RemoveListener));
		L.RegFunction("__eq", new LuaCSFunction(RoleStateTransitionWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("firstEnter", new LuaCSFunction(RoleStateTransitionWrap.get_firstEnter), new LuaCSFunction(RoleStateTransitionWrap.set_firstEnter));
		L.RegFunction("OnStateChanged", new LuaCSFunction(RoleStateTransitionWrap.RoleStateTransition_OnStateChanged));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsInState(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleStateTransition roleStateTransition = (RoleStateTransition)ToLua.CheckObject(L, 1, typeof(RoleStateTransition));
			int state = (int)LuaDLL.luaL_checknumber(L, 2);
			bool value = roleStateTransition.IsInState(state);
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
	private static int CanRide(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleStateTransition roleStateTransition = (RoleStateTransition)ToLua.CheckObject(L, 1, typeof(RoleStateTransition));
			bool value = roleStateTransition.CanRide();
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
	private static int CanWalkOnDirection(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleStateTransition roleStateTransition = (RoleStateTransition)ToLua.CheckObject(L, 1, typeof(RoleStateTransition));
			bool value = roleStateTransition.CanWalkOnDirection();
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
	private static int CanDaZuo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleStateTransition roleStateTransition = (RoleStateTransition)ToLua.CheckObject(L, 1, typeof(RoleStateTransition));
			bool value = roleStateTransition.CanDaZuo();
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
	private static int AddState(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleStateTransition roleStateTransition = (RoleStateTransition)ToLua.CheckObject(L, 1, typeof(RoleStateTransition));
			int state = (int)LuaDLL.luaL_checknumber(L, 2);
			roleStateTransition.AddState(state);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveState(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleStateTransition roleStateTransition = (RoleStateTransition)ToLua.CheckObject(L, 1, typeof(RoleStateTransition));
			int state = (int)LuaDLL.luaL_checknumber(L, 2);
			roleStateTransition.RemoveState(state);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearStateWhenDead(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleStateTransition roleStateTransition = (RoleStateTransition)ToLua.CheckObject(L, 1, typeof(RoleStateTransition));
			roleStateTransition.ClearStateWhenDead();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			RoleStateTransition roleStateTransition = (RoleStateTransition)ToLua.CheckObject(L, 1, typeof(RoleStateTransition));
			string name = ToLua.CheckString(L, 2);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			RoleStateTransition.OnStateChanged listener;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				listener = (RoleStateTransition.OnStateChanged)ToLua.CheckObject(L, 3, typeof(RoleStateTransition.OnStateChanged));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				listener = (DelegateFactory.CreateDelegate(typeof(RoleStateTransition.OnStateChanged), func) as RoleStateTransition.OnStateChanged);
			}
			roleStateTransition.AddListener(name, listener);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleStateTransition roleStateTransition = (RoleStateTransition)ToLua.CheckObject(L, 1, typeof(RoleStateTransition));
			string name = ToLua.CheckString(L, 2);
			roleStateTransition.RemoveListener(name);
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
	private static int get_firstEnter(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, RoleStateTransition.firstEnter);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_firstEnter(IntPtr L)
	{
		int result;
		try
		{
			bool firstEnter = LuaDLL.luaL_checkboolean(L, 2);
			RoleStateTransition.firstEnter = firstEnter;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RoleStateTransition_OnStateChanged(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(RoleStateTransition.OnStateChanged), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(RoleStateTransition.OnStateChanged), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
