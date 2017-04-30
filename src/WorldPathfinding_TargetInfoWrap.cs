using LuaInterface;
using System;
using UnityEngine;

public class WorldPathfinding_TargetInfoWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(WorldPathfinding.TargetInfo), typeof(object), null);
		L.RegFunction("IsInWorldPathfinding", new LuaCSFunction(WorldPathfinding_TargetInfoWrap.IsInWorldPathfinding));
		L.RegFunction("Clear", new LuaCSFunction(WorldPathfinding_TargetInfoWrap.Clear));
		L.RegFunction("New", new LuaCSFunction(WorldPathfinding_TargetInfoWrap._CreateWorldPathfinding_TargetInfo));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("toMapId", new LuaCSFunction(WorldPathfinding_TargetInfoWrap.get_toMapId), new LuaCSFunction(WorldPathfinding_TargetInfoWrap.set_toMapId));
		L.RegVar("radius", new LuaCSFunction(WorldPathfinding_TargetInfoWrap.get_radius), new LuaCSFunction(WorldPathfinding_TargetInfoWrap.set_radius));
		L.RegVar("destination", new LuaCSFunction(WorldPathfinding_TargetInfoWrap.get_destination), new LuaCSFunction(WorldPathfinding_TargetInfoWrap.set_destination));
		L.RegVar("pathFinished", new LuaCSFunction(WorldPathfinding_TargetInfoWrap.get_pathFinished), new LuaCSFunction(WorldPathfinding_TargetInfoWrap.set_pathFinished));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateWorldPathfinding_TargetInfo(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 4)
			{
				int toMap = (int)LuaDLL.luaL_checknumber(L, 1);
				Vector3 dest = ToLua.ToVector3(L, 2);
				float ra = (float)LuaDLL.luaL_checknumber(L, 3);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 4);
				Move.PathFinished arrived;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					arrived = (Move.PathFinished)ToLua.CheckObject(L, 4, typeof(Move.PathFinished));
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 4);
					arrived = (DelegateFactory.CreateDelegate(typeof(Move.PathFinished), func) as Move.PathFinished);
				}
				WorldPathfinding.TargetInfo o = new WorldPathfinding.TargetInfo(toMap, dest, ra, arrived);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: WorldPathfinding.TargetInfo.New");
			}
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
			WorldPathfinding.TargetInfo targetInfo = (WorldPathfinding.TargetInfo)ToLua.CheckObject(L, 1, typeof(WorldPathfinding.TargetInfo));
			bool value = targetInfo.IsInWorldPathfinding();
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
	private static int Clear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			WorldPathfinding.TargetInfo targetInfo = (WorldPathfinding.TargetInfo)ToLua.CheckObject(L, 1, typeof(WorldPathfinding.TargetInfo));
			targetInfo.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_toMapId(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldPathfinding.TargetInfo targetInfo = (WorldPathfinding.TargetInfo)obj;
			int toMapId = targetInfo.toMapId;
			LuaDLL.lua_pushinteger(L, toMapId);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index toMapId on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_radius(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldPathfinding.TargetInfo targetInfo = (WorldPathfinding.TargetInfo)obj;
			float radius = targetInfo.radius;
			LuaDLL.lua_pushnumber(L, (double)radius);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index radius on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_destination(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldPathfinding.TargetInfo targetInfo = (WorldPathfinding.TargetInfo)obj;
			Vector3 destination = targetInfo.destination;
			ToLua.Push(L, destination);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index destination on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pathFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldPathfinding.TargetInfo targetInfo = (WorldPathfinding.TargetInfo)obj;
			Move.PathFinished pathFinished = targetInfo.pathFinished;
			ToLua.Push(L, pathFinished);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pathFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_toMapId(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldPathfinding.TargetInfo targetInfo = (WorldPathfinding.TargetInfo)obj;
			int toMapId = (int)LuaDLL.luaL_checknumber(L, 2);
			targetInfo.toMapId = toMapId;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index toMapId on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_radius(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldPathfinding.TargetInfo targetInfo = (WorldPathfinding.TargetInfo)obj;
			float radius = (float)LuaDLL.luaL_checknumber(L, 2);
			targetInfo.radius = radius;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index radius on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_destination(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldPathfinding.TargetInfo targetInfo = (WorldPathfinding.TargetInfo)obj;
			Vector3 destination = ToLua.ToVector3(L, 2);
			targetInfo.destination = destination;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index destination on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pathFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			WorldPathfinding.TargetInfo targetInfo = (WorldPathfinding.TargetInfo)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Move.PathFinished pathFinished;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				pathFinished = (Move.PathFinished)ToLua.CheckObject(L, 2, typeof(Move.PathFinished));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				pathFinished = (DelegateFactory.CreateDelegate(typeof(Move.PathFinished), func) as Move.PathFinished);
			}
			targetInfo.pathFinished = pathFinished;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pathFinished on a nil value");
		}
		return result;
	}
}
