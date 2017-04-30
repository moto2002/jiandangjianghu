using LuaInterface;
using Pathfinding;
using System;
using UnityEngine;

public class MoveWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Move), typeof(AIPath), null);
		L.RegFunction("InFindingPath", new LuaCSFunction(MoveWrap.InFindingPath));
		L.RegFunction("InMoving", new LuaCSFunction(MoveWrap.InMoving));
		L.RegFunction("InAreaPathFinding", new LuaCSFunction(MoveWrap.InAreaPathFinding));
		L.RegFunction("OnPathComplete", new LuaCSFunction(MoveWrap.OnPathComplete));
		L.RegFunction("ResearchPathAfterJump", new LuaCSFunction(MoveWrap.ResearchPathAfterJump));
		L.RegFunction("WalkTo", new LuaCSFunction(MoveWrap.WalkTo));
		L.RegFunction("SearchPathInWorld", new LuaCSFunction(MoveWrap.SearchPathInWorld));
		L.RegFunction("WalkOnDirection", new LuaCSFunction(MoveWrap.WalkOnDirection));
		L.RegFunction("StopPath", new LuaCSFunction(MoveWrap.StopPath));
		L.RegFunction("ClearFinalDestination", new LuaCSFunction(MoveWrap.ClearFinalDestination));
		L.RegFunction("SetServerPos", new LuaCSFunction(MoveWrap.SetServerPos));
		L.RegFunction("MoveEnqueue", new LuaCSFunction(MoveWrap.MoveEnqueue));
		L.RegFunction("OnTargetReached", new LuaCSFunction(MoveWrap.OnTargetReached));
		L.RegFunction("TrySearchPath", new LuaCSFunction(MoveWrap.TrySearchPath));
		L.RegFunction("SearchPath", new LuaCSFunction(MoveWrap.SearchPath));
		L.RegFunction("Jump", new LuaCSFunction(MoveWrap.Jump));
		L.RegFunction("JumpError", new LuaCSFunction(MoveWrap.JumpError));
		L.RegFunction("StopJump", new LuaCSFunction(MoveWrap.StopJump));
		L.RegFunction("__eq", new LuaCSFunction(MoveWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("pathFinished", new LuaCSFunction(MoveWrap.get_pathFinished), new LuaCSFunction(MoveWrap.set_pathFinished));
		L.RegVar("_self", new LuaCSFunction(MoveWrap.get__self), new LuaCSFunction(MoveWrap.set__self));
		L.RegVar("speedFactor", new LuaCSFunction(MoveWrap.get_speedFactor), new LuaCSFunction(MoveWrap.set_speedFactor));
		L.RegVar("isAutoRunning", new LuaCSFunction(MoveWrap.get_isAutoRunning), new LuaCSFunction(MoveWrap.set_isAutoRunning));
		L.RegVar("isRunning", new LuaCSFunction(MoveWrap.get_isRunning), new LuaCSFunction(MoveWrap.set_isRunning));
		L.RegVar("radius", new LuaCSFunction(MoveWrap.get_radius), new LuaCSFunction(MoveWrap.set_radius));
		L.RegVar("sleepVelocity", new LuaCSFunction(MoveWrap.get_sleepVelocity), new LuaCSFunction(MoveWrap.set_sleepVelocity));
		L.RegVar("stepReachDistance", new LuaCSFunction(MoveWrap.get_stepReachDistance), new LuaCSFunction(MoveWrap.set_stepReachDistance));
		L.RegVar("destination", new LuaCSFunction(MoveWrap.get_destination), new LuaCSFunction(MoveWrap.set_destination));
		L.RegVar("finalDestination", new LuaCSFunction(MoveWrap.get_finalDestination), new LuaCSFunction(MoveWrap.set_finalDestination));
		L.RegVar("walkType", new LuaCSFunction(MoveWrap.get_walkType), new LuaCSFunction(MoveWrap.set_walkType));
		L.RegVar("jumpSystem", new LuaCSFunction(MoveWrap.get_jumpSystem), new LuaCSFunction(MoveWrap.set_jumpSystem));
		L.RegVar("plotJumpSystem", new LuaCSFunction(MoveWrap.get_plotJumpSystem), new LuaCSFunction(MoveWrap.set_plotJumpSystem));
		L.RegVar("vectorPath", new LuaCSFunction(MoveWrap.get_vectorPath), null);
		L.RegVar("vectorLeftPath", new LuaCSFunction(MoveWrap.get_vectorLeftPath), null);
		L.RegVar("jumpMode", new LuaCSFunction(MoveWrap.get_jumpMode), null);
		L.RegFunction("PathFinished", new LuaCSFunction(MoveWrap.Move_PathFinished));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InFindingPath(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			bool value = move.InFindingPath();
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
	private static int InMoving(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			bool value = move.InMoving();
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
	private static int InAreaPathFinding(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			bool value = move.InAreaPathFinding();
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
	private static int OnPathComplete(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			Path p = (Path)ToLua.CheckObject(L, 2, typeof(Path));
			move.OnPathComplete(p);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResearchPathAfterJump(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			move.ResearchPathAfterJump();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WalkTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 6);
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			Vector3 dst = ToLua.ToVector3(L, 2);
			float radius = (float)LuaDLL.luaL_checknumber(L, 3);
			int type = (int)LuaDLL.luaL_checknumber(L, 4);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 5);
			Move.PathFinished arrived;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				arrived = (Move.PathFinished)ToLua.CheckObject(L, 5, typeof(Move.PathFinished));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 5);
				arrived = (DelegateFactory.CreateDelegate(typeof(Move.PathFinished), func) as Move.PathFinished);
			}
			bool searchImmediate = LuaDLL.luaL_checkboolean(L, 6);
			bool value = move.WalkTo(dst, radius, type, arrived, searchImmediate);
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
	private static int SearchPathInWorld(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			int toMap = (int)LuaDLL.luaL_checknumber(L, 2);
			Vector3 dst = ToLua.ToVector3(L, 3);
			float radius = (float)LuaDLL.luaL_checknumber(L, 4);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 5);
			Move.PathFinished arrived;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				arrived = (Move.PathFinished)ToLua.CheckObject(L, 5, typeof(Move.PathFinished));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 5);
				arrived = (DelegateFactory.CreateDelegate(typeof(Move.PathFinished), func) as Move.PathFinished);
			}
			move.SearchPathInWorld(toMap, dst, radius, arrived);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WalkOnDirection(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			Vector3 vecDir = ToLua.ToVector3(L, 2);
			move.WalkOnDirection(vecDir);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopPath(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			move.StopPath();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearFinalDestination(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			move.ClearFinalDestination();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetServerPos(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 8);
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			Vector3 pos = ToLua.ToVector3(L, 2);
			float sSpeed = (float)LuaDLL.luaL_checknumber(L, 3);
			int type = (int)LuaDLL.luaL_checknumber(L, 4);
			int walkType = (int)LuaDLL.luaL_checknumber(L, 5);
			float radius = (float)LuaDLL.luaL_checknumber(L, 6);
			bool correctNow = LuaDLL.luaL_checkboolean(L, 7);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 8);
			Move.PathFinished callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Move.PathFinished)ToLua.CheckObject(L, 8, typeof(Move.PathFinished));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 8);
				callback = (DelegateFactory.CreateDelegate(typeof(Move.PathFinished), func) as Move.PathFinished);
			}
			move.SetServerPos(pos, sSpeed, type, walkType, radius, correctNow, callback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MoveEnqueue(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (TypeChecker.CheckTypes(L, 1, typeof(Move), typeof(Vector3), typeof(int), typeof(int), typeof(float), typeof(Move.PathFinished), typeof(string), typeof(string)) && TypeChecker.CheckParamsType(L, typeof(object), 9, num - 8))
			{
				Move move = (Move)ToLua.ToObject(L, 1);
				Vector3 position = ToLua.ToVector3(L, 2);
				int type = (int)LuaDLL.lua_tonumber(L, 3);
				int walkType = (int)LuaDLL.lua_tonumber(L, 4);
				float radius = (float)LuaDLL.lua_tonumber(L, 5);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 6);
				Move.PathFinished callback;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					callback = (Move.PathFinished)ToLua.ToObject(L, 6);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 6);
					callback = (DelegateFactory.CreateDelegate(typeof(Move.PathFinished), func) as Move.PathFinished);
				}
				string module = ToLua.ToString(L, 7);
				string func2 = ToLua.ToString(L, 8);
				object[] param = ToLua.ToParamsObject(L, 9, num - 8);
				move.MoveEnqueue(position, type, walkType, radius, callback, module, func2, param);
				result = 0;
			}
			else if (TypeChecker.CheckTypes(L, 1, typeof(Move), typeof(int), typeof(float), typeof(int), typeof(int), typeof(string), typeof(string)) && TypeChecker.CheckParamsType(L, typeof(object), 8, num - 7))
			{
				Move move2 = (Move)ToLua.ToObject(L, 1);
				int x = (int)LuaDLL.lua_tonumber(L, 2);
				float y = (float)LuaDLL.lua_tonumber(L, 3);
				int z = (int)LuaDLL.lua_tonumber(L, 4);
				int type2 = (int)LuaDLL.lua_tonumber(L, 5);
				string module2 = ToLua.ToString(L, 6);
				string func3 = ToLua.ToString(L, 7);
				object[] param2 = ToLua.ToParamsObject(L, 8, num - 7);
				move2.MoveEnqueue(x, y, z, type2, module2, func3, param2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: Move.MoveEnqueue");
			}
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
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			move.OnTargetReached();
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Move)))
			{
				Move move = (Move)ToLua.ToObject(L, 1);
				float num2 = move.TrySearchPath();
				LuaDLL.lua_pushnumber(L, (double)num2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Move), typeof(Vector3), typeof(Move.PathFinished)))
			{
				Move move2 = (Move)ToLua.ToObject(L, 1);
				Vector3 dst = ToLua.ToVector3(L, 2);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
				Move.PathFinished arrived;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					arrived = (Move.PathFinished)ToLua.ToObject(L, 3);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 3);
					arrived = (DelegateFactory.CreateDelegate(typeof(Move.PathFinished), func) as Move.PathFinished);
				}
				float num3 = move2.TrySearchPath(dst, arrived);
				LuaDLL.lua_pushnumber(L, (double)num3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: Move.TrySearchPath");
			}
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
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			move.SearchPath();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Jump(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 6);
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			float vertSpeed = (float)LuaDLL.luaL_checknumber(L, 2);
			float horizSpeed = (float)LuaDLL.luaL_checknumber(L, 3);
			float dashIncFactor = (float)LuaDLL.luaL_checknumber(L, 4);
			float horizAccSpeed = (float)LuaDLL.luaL_checknumber(L, 5);
			float horizEndSpeed = (float)LuaDLL.luaL_checknumber(L, 6);
			move.Jump(vertSpeed, horizSpeed, dashIncFactor, horizAccSpeed, horizEndSpeed);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int JumpError(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			int x = (int)LuaDLL.luaL_checknumber(L, 2);
			int z = (int)LuaDLL.luaL_checknumber(L, 3);
			float y = (float)LuaDLL.luaL_checknumber(L, 4);
			move.JumpError(x, z, y);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopJump(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Move move = (Move)ToLua.CheckObject(L, 1, typeof(Move));
			move.StopJump();
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
	private static int get_pathFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			Move.PathFinished pathFinished = move.pathFinished;
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
	private static int get__self(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			SceneEntity self = move._self;
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
	private static int get_speedFactor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			float speedFactor = move.speedFactor;
			LuaDLL.lua_pushnumber(L, (double)speedFactor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index speedFactor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isAutoRunning(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			bool isAutoRunning = move.isAutoRunning;
			LuaDLL.lua_pushboolean(L, isAutoRunning);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isAutoRunning on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isRunning(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			bool isRunning = move.isRunning;
			LuaDLL.lua_pushboolean(L, isRunning);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isRunning on a nil value");
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
			Move move = (Move)obj;
			float radius = move.radius;
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
	private static int get_sleepVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			float sleepVelocity = move.sleepVelocity;
			LuaDLL.lua_pushnumber(L, (double)sleepVelocity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sleepVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_stepReachDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			float stepReachDistance = move.stepReachDistance;
			LuaDLL.lua_pushnumber(L, (double)stepReachDistance);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stepReachDistance on a nil value");
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
			Move move = (Move)obj;
			Vector3 destination = move.destination;
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
	private static int get_finalDestination(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			Vector3 finalDestination = move.finalDestination;
			ToLua.Push(L, finalDestination);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index finalDestination on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_walkType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			int walkType = move.walkType;
			LuaDLL.lua_pushinteger(L, walkType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index walkType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_jumpSystem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			JumpBase jumpSystem = move.jumpSystem;
			ToLua.Push(L, jumpSystem);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jumpSystem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_plotJumpSystem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			JumpBase plotJumpSystem = move.plotJumpSystem;
			ToLua.Push(L, plotJumpSystem);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index plotJumpSystem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_vectorPath(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			Vector3[] vectorPath = move.vectorPath;
			ToLua.Push(L, vectorPath);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index vectorPath on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_vectorLeftPath(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			Vector3[] vectorLeftPath = move.vectorLeftPath;
			ToLua.Push(L, vectorLeftPath);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index vectorLeftPath on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_jumpMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			int jumpMode = move.jumpMode;
			LuaDLL.lua_pushinteger(L, jumpMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jumpMode on a nil value");
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
			Move move = (Move)obj;
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
			move.pathFinished = pathFinished;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pathFinished on a nil value");
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
			Move move = (Move)obj;
			SceneEntity self = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			move._self = self;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index _self on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_speedFactor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			float speedFactor = (float)LuaDLL.luaL_checknumber(L, 2);
			move.speedFactor = speedFactor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index speedFactor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isAutoRunning(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			bool isAutoRunning = LuaDLL.luaL_checkboolean(L, 2);
			move.isAutoRunning = isAutoRunning;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isAutoRunning on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isRunning(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			bool isRunning = LuaDLL.luaL_checkboolean(L, 2);
			move.isRunning = isRunning;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isRunning on a nil value");
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
			Move move = (Move)obj;
			float radius = (float)LuaDLL.luaL_checknumber(L, 2);
			move.radius = radius;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index radius on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sleepVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			float sleepVelocity = (float)LuaDLL.luaL_checknumber(L, 2);
			move.sleepVelocity = sleepVelocity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sleepVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_stepReachDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			float stepReachDistance = (float)LuaDLL.luaL_checknumber(L, 2);
			move.stepReachDistance = stepReachDistance;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stepReachDistance on a nil value");
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
			Move move = (Move)obj;
			Vector3 destination = ToLua.ToVector3(L, 2);
			move.destination = destination;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index destination on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_finalDestination(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			Vector3 finalDestination = ToLua.ToVector3(L, 2);
			move.finalDestination = finalDestination;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index finalDestination on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_walkType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			int walkType = (int)LuaDLL.luaL_checknumber(L, 2);
			move.walkType = walkType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index walkType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_jumpSystem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			JumpBase jumpSystem = (JumpBase)ToLua.CheckUnityObject(L, 2, typeof(JumpBase));
			move.jumpSystem = jumpSystem;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jumpSystem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_plotJumpSystem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Move move = (Move)obj;
			JumpBase plotJumpSystem = (JumpBase)ToLua.CheckUnityObject(L, 2, typeof(JumpBase));
			move.plotJumpSystem = plotJumpSystem;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index plotJumpSystem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Move_PathFinished(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Move.PathFinished), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Move.PathFinished), func, self);
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
