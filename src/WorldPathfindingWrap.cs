using GraphCollection;
using LuaInterface;
using System;
using System.Collections.Generic;
using ThirdParty;
using UnityEngine;

public class WorldPathfindingWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(WorldPathfinding), typeof(Singleton<WorldPathfinding>), null);
		L.RegFunction("GetInstance", new LuaCSFunction(WorldPathfindingWrap.GetInstance));
		L.RegFunction("AddWorldPathfindingInfo", new LuaCSFunction(WorldPathfindingWrap.AddWorldPathfindingInfo));
		L.RegFunction("FindPath", new LuaCSFunction(WorldPathfindingWrap.FindPath));
		L.RegFunction("BeginWorldPathfinding", new LuaCSFunction(WorldPathfindingWrap.BeginWorldPathfinding));
		L.RegFunction("CheckWorldPathfinding", new LuaCSFunction(WorldPathfindingWrap.CheckWorldPathfinding));
		L.RegFunction("IsInWorldPathfinding", new LuaCSFunction(WorldPathfindingWrap.IsInWorldPathfinding));
		L.RegFunction("StopWorldPathfinding", new LuaCSFunction(WorldPathfindingWrap.StopWorldPathfinding));
		L.RegFunction("Dump", new LuaCSFunction(WorldPathfindingWrap.Dump));
		L.RegFunction("Clear", new LuaCSFunction(WorldPathfindingWrap.Clear));
		L.RegFunction("DoCallBack", new LuaCSFunction(WorldPathfindingWrap.DoCallBack));
		L.RegFunction("__eq", new LuaCSFunction(WorldPathfindingWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("init", new LuaCSFunction(WorldPathfindingWrap.get_init), new LuaCSFunction(WorldPathfindingWrap.set_init));
		L.RegVar("targetInfo", new LuaCSFunction(WorldPathfindingWrap.get_targetInfo), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInstance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			WorldPathfinding instance = WorldPathfinding.GetInstance();
			ToLua.Push(L, instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddWorldPathfindingInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 6);
			WorldPathfinding worldPathfinding = (WorldPathfinding)ToLua.CheckObject(L, 1, typeof(WorldPathfinding));
			int startMap = (int)LuaDLL.luaL_checknumber(L, 2);
			int endMap = (int)LuaDLL.luaL_checknumber(L, 3);
			int x = (int)LuaDLL.luaL_checknumber(L, 4);
			int z = (int)LuaDLL.luaL_checknumber(L, 5);
			float y = (float)LuaDLL.luaL_checknumber(L, 6);
			worldPathfinding.AddWorldPathfindingInfo(startMap, endMap, x, z, y);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindPath(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			WorldPathfinding worldPathfinding = (WorldPathfinding)ToLua.CheckObject(L, 1, typeof(WorldPathfinding));
			int startMap = (int)LuaDLL.luaL_checknumber(L, 2);
			int endMap = (int)LuaDLL.luaL_checknumber(L, 3);
			List<GraphNode<WorldPathfinding.MapPathInfo>> o = worldPathfinding.FindPath(startMap, endMap);
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
	private static int BeginWorldPathfinding(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 8);
			WorldPathfinding worldPathfinding = (WorldPathfinding)ToLua.CheckObject(L, 1, typeof(WorldPathfinding));
			int toMap = (int)LuaDLL.luaL_checknumber(L, 2);
			int x = (int)LuaDLL.luaL_checknumber(L, 3);
			float y = (float)LuaDLL.luaL_checknumber(L, 4);
			int z = (int)LuaDLL.luaL_checknumber(L, 5);
			float ra = (float)LuaDLL.luaL_checknumber(L, 6);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 7);
			Move.PathFinished callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Move.PathFinished)ToLua.CheckObject(L, 7, typeof(Move.PathFinished));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 7);
				callback = (DelegateFactory.CreateDelegate(typeof(Move.PathFinished), func) as Move.PathFinished);
			}
			bool midPoint = LuaDLL.luaL_checkboolean(L, 8);
			worldPathfinding.BeginWorldPathfinding(toMap, x, y, z, ra, callback, midPoint);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckWorldPathfinding(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			WorldPathfinding worldPathfinding = (WorldPathfinding)ToLua.CheckObject(L, 1, typeof(WorldPathfinding));
			bool value = worldPathfinding.CheckWorldPathfinding();
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
	private static int IsInWorldPathfinding(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			WorldPathfinding worldPathfinding = (WorldPathfinding)ToLua.CheckObject(L, 1, typeof(WorldPathfinding));
			bool value = worldPathfinding.IsInWorldPathfinding();
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
	private static int StopWorldPathfinding(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			WorldPathfinding worldPathfinding = (WorldPathfinding)ToLua.CheckObject(L, 1, typeof(WorldPathfinding));
			worldPathfinding.StopWorldPathfinding();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Dump(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			WorldPathfinding worldPathfinding = (WorldPathfinding)ToLua.CheckObject(L, 1, typeof(WorldPathfinding));
			worldPathfinding.Dump();
			result = 0;
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
			WorldPathfinding worldPathfinding = (WorldPathfinding)ToLua.CheckObject(L, 1, typeof(WorldPathfinding));
			worldPathfinding.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DoCallBack(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			WorldPathfinding worldPathfinding = (WorldPathfinding)ToLua.CheckObject(L, 1, typeof(WorldPathfinding));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Move.PathFinished callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Move.PathFinished)ToLua.CheckObject(L, 2, typeof(Move.PathFinished));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				callback = (DelegateFactory.CreateDelegate(typeof(Move.PathFinished), func) as Move.PathFinished);
			}
			worldPathfinding.DoCallBack(callback);
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
	private static int get_init(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldPathfinding worldPathfinding = (WorldPathfinding)obj;
			bool init = worldPathfinding.init;
			LuaDLL.lua_pushboolean(L, init);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index init on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetInfo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldPathfinding worldPathfinding = (WorldPathfinding)obj;
			WorldPathfinding.TargetInfo targetInfo = worldPathfinding.targetInfo;
			ToLua.PushObject(L, targetInfo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetInfo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_init(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldPathfinding worldPathfinding = (WorldPathfinding)obj;
			bool init = LuaDLL.luaL_checkboolean(L, 2);
			worldPathfinding.init = init;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index init on a nil value");
		}
		return result;
	}
}
