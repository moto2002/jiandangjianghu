using LuaInterface;
using Pathfinding;
using System;
using UnityEngine;

public class AIPathWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AIPath), typeof(MonoBehaviour), null);
		L.RegFunction("OnDisable", new LuaCSFunction(AIPathWrap.OnDisable));
		L.RegFunction("TrySearchPath", new LuaCSFunction(AIPathWrap.TrySearchPath));
		L.RegFunction("SearchPath", new LuaCSFunction(AIPathWrap.SearchPath));
		L.RegFunction("OnTargetReached", new LuaCSFunction(AIPathWrap.OnTargetReached));
		L.RegFunction("OnPathComplete", new LuaCSFunction(AIPathWrap.OnPathComplete));
		L.RegFunction("GetFeetPosition", new LuaCSFunction(AIPathWrap.GetFeetPosition));
		L.RegFunction("Update", new LuaCSFunction(AIPathWrap.Update));
		L.RegFunction("__eq", new LuaCSFunction(AIPathWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("repathRate", new LuaCSFunction(AIPathWrap.get_repathRate), new LuaCSFunction(AIPathWrap.set_repathRate));
		L.RegVar("target", new LuaCSFunction(AIPathWrap.get_target), new LuaCSFunction(AIPathWrap.set_target));
		L.RegVar("canSearch", new LuaCSFunction(AIPathWrap.get_canSearch), new LuaCSFunction(AIPathWrap.set_canSearch));
		L.RegVar("canMove", new LuaCSFunction(AIPathWrap.get_canMove), new LuaCSFunction(AIPathWrap.set_canMove));
		L.RegVar("speed", new LuaCSFunction(AIPathWrap.get_speed), new LuaCSFunction(AIPathWrap.set_speed));
		L.RegVar("turningSpeed", new LuaCSFunction(AIPathWrap.get_turningSpeed), new LuaCSFunction(AIPathWrap.set_turningSpeed));
		L.RegVar("slowdownDistance", new LuaCSFunction(AIPathWrap.get_slowdownDistance), new LuaCSFunction(AIPathWrap.set_slowdownDistance));
		L.RegVar("pickNextWaypointDist", new LuaCSFunction(AIPathWrap.get_pickNextWaypointDist), new LuaCSFunction(AIPathWrap.set_pickNextWaypointDist));
		L.RegVar("forwardLook", new LuaCSFunction(AIPathWrap.get_forwardLook), new LuaCSFunction(AIPathWrap.set_forwardLook));
		L.RegVar("endReachedDistance", new LuaCSFunction(AIPathWrap.get_endReachedDistance), new LuaCSFunction(AIPathWrap.set_endReachedDistance));
		L.RegVar("closestOnPathCheck", new LuaCSFunction(AIPathWrap.get_closestOnPathCheck), new LuaCSFunction(AIPathWrap.set_closestOnPathCheck));
		L.RegVar("TargetReached", new LuaCSFunction(AIPathWrap.get_TargetReached), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnDisable(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AIPath aIPath = (AIPath)ToLua.CheckObject(L, 1, typeof(AIPath));
			aIPath.OnDisable();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TrySearchPath(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AIPath aIPath = (AIPath)ToLua.CheckObject(L, 1, typeof(AIPath));
			float num = aIPath.TrySearchPath();
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SearchPath(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AIPath aIPath = (AIPath)ToLua.CheckObject(L, 1, typeof(AIPath));
			aIPath.SearchPath();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnTargetReached(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AIPath aIPath = (AIPath)ToLua.CheckObject(L, 1, typeof(AIPath));
			aIPath.OnTargetReached();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnPathComplete(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			AIPath aIPath = (AIPath)ToLua.CheckObject(L, 1, typeof(AIPath));
			Path p = (Path)ToLua.CheckObject(L, 2, typeof(Path));
			aIPath.OnPathComplete(p);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetFeetPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AIPath aIPath = (AIPath)ToLua.CheckObject(L, 1, typeof(AIPath));
			Vector3 feetPosition = aIPath.GetFeetPosition();
			ToLua.Push(L, feetPosition);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Update(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			AIPath aIPath = (AIPath)ToLua.CheckObject(L, 1, typeof(AIPath));
			aIPath.Update();
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
	private static int get_repathRate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			float repathRate = aIPath.repathRate;
			LuaDLL.lua_pushnumber(L, (double)repathRate);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index repathRate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_target(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			Transform target = aIPath.target;
			ToLua.Push(L, target);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index target on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_canSearch(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			bool canSearch = aIPath.canSearch;
			LuaDLL.lua_pushboolean(L, canSearch);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canSearch on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_canMove(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			bool canMove = aIPath.canMove;
			LuaDLL.lua_pushboolean(L, canMove);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canMove on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_speed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			float speed = aIPath.speed;
			LuaDLL.lua_pushnumber(L, (double)speed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index speed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_turningSpeed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			float turningSpeed = aIPath.turningSpeed;
			LuaDLL.lua_pushnumber(L, (double)turningSpeed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index turningSpeed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_slowdownDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			float slowdownDistance = aIPath.slowdownDistance;
			LuaDLL.lua_pushnumber(L, (double)slowdownDistance);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index slowdownDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pickNextWaypointDist(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			float pickNextWaypointDist = aIPath.pickNextWaypointDist;
			LuaDLL.lua_pushnumber(L, (double)pickNextWaypointDist);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pickNextWaypointDist on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_forwardLook(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			float forwardLook = aIPath.forwardLook;
			LuaDLL.lua_pushnumber(L, (double)forwardLook);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index forwardLook on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_endReachedDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			float endReachedDistance = aIPath.endReachedDistance;
			LuaDLL.lua_pushnumber(L, (double)endReachedDistance);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index endReachedDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_closestOnPathCheck(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			bool closestOnPathCheck = aIPath.closestOnPathCheck;
			LuaDLL.lua_pushboolean(L, closestOnPathCheck);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index closestOnPathCheck on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_TargetReached(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			bool targetReached = aIPath.TargetReached;
			LuaDLL.lua_pushboolean(L, targetReached);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index TargetReached on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_repathRate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			float repathRate = (float)LuaDLL.luaL_checknumber(L, 2);
			aIPath.repathRate = repathRate;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index repathRate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_target(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			Transform target = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			aIPath.target = target;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index target on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_canSearch(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			bool canSearch = LuaDLL.luaL_checkboolean(L, 2);
			aIPath.canSearch = canSearch;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canSearch on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_canMove(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			bool canMove = LuaDLL.luaL_checkboolean(L, 2);
			aIPath.canMove = canMove;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canMove on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_speed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			float speed = (float)LuaDLL.luaL_checknumber(L, 2);
			aIPath.speed = speed;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index speed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_turningSpeed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			float turningSpeed = (float)LuaDLL.luaL_checknumber(L, 2);
			aIPath.turningSpeed = turningSpeed;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index turningSpeed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_slowdownDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			float slowdownDistance = (float)LuaDLL.luaL_checknumber(L, 2);
			aIPath.slowdownDistance = slowdownDistance;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index slowdownDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pickNextWaypointDist(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			float pickNextWaypointDist = (float)LuaDLL.luaL_checknumber(L, 2);
			aIPath.pickNextWaypointDist = pickNextWaypointDist;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pickNextWaypointDist on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_forwardLook(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			float forwardLook = (float)LuaDLL.luaL_checknumber(L, 2);
			aIPath.forwardLook = forwardLook;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index forwardLook on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_endReachedDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			float endReachedDistance = (float)LuaDLL.luaL_checknumber(L, 2);
			aIPath.endReachedDistance = endReachedDistance;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index endReachedDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_closestOnPathCheck(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AIPath aIPath = (AIPath)obj;
			bool closestOnPathCheck = LuaDLL.luaL_checkboolean(L, 2);
			aIPath.closestOnPathCheck = closestOnPathCheck;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index closestOnPathCheck on a nil value");
		}
		return result;
	}
}
