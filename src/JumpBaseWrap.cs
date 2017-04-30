using LuaInterface;
using System;
using UnityEngine;

public class JumpBaseWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(JumpBase), typeof(MonoBehaviour), null);
		L.RegFunction("UpdateJump", new LuaCSFunction(JumpBaseWrap.UpdateJump));
		L.RegFunction("RoleJump", new LuaCSFunction(JumpBaseWrap.RoleJump));
		L.RegFunction("SyncJump", new LuaCSFunction(JumpBaseWrap.SyncJump));
		L.RegFunction("OnJumpFinished", new LuaCSFunction(JumpBaseWrap.OnJumpFinished));
		L.RegFunction("StopJump", new LuaCSFunction(JumpBaseWrap.StopJump));
		L.RegFunction("__eq", new LuaCSFunction(JumpBaseWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("_self", new LuaCSFunction(JumpBaseWrap.get__self), new LuaCSFunction(JumpBaseWrap.set__self));
		L.RegVar("offsetY", new LuaCSFunction(JumpBaseWrap.get_offsetY), new LuaCSFunction(JumpBaseWrap.set_offsetY));
		L.RegVar("offsetX", new LuaCSFunction(JumpBaseWrap.get_offsetX), new LuaCSFunction(JumpBaseWrap.set_offsetX));
		L.RegVar("jumpMode", new LuaCSFunction(JumpBaseWrap.get_jumpMode), null);
		L.RegVar("startPos", new LuaCSFunction(JumpBaseWrap.get_startPos), null);
		L.RegVar("startVertSpeed", new LuaCSFunction(JumpBaseWrap.get_startVertSpeed), null);
		L.RegVar("curVertSpeed", new LuaCSFunction(JumpBaseWrap.get_curVertSpeed), null);
		L.RegVar("horizAcceleration", new LuaCSFunction(JumpBaseWrap.get_horizAcceleration), null);
		L.RegVar("startHorizSpeed", new LuaCSFunction(JumpBaseWrap.get_startHorizSpeed), null);
		L.RegVar("curHorizSpeed", new LuaCSFunction(JumpBaseWrap.get_curHorizSpeed), null);
		L.RegVar("endHorizSpeed", new LuaCSFunction(JumpBaseWrap.get_endHorizSpeed), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateJump(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			JumpBase jumpBase = (JumpBase)ToLua.CheckObject(L, 1, typeof(JumpBase));
			bool isGrounded = LuaDLL.luaL_checkboolean(L, 2);
			Vector3 finalPosition = ToLua.ToVector3(L, 3);
			bool shakeCamera = LuaDLL.luaL_checkboolean(L, 4);
			jumpBase.UpdateJump(isGrounded, finalPosition, shakeCamera);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RoleJump(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 6);
			JumpBase jumpBase = (JumpBase)ToLua.CheckObject(L, 1, typeof(JumpBase));
			float vertSpeed = (float)LuaDLL.luaL_checknumber(L, 2);
			float horizSpeed = (float)LuaDLL.luaL_checknumber(L, 3);
			float dashIncFactor = (float)LuaDLL.luaL_checknumber(L, 4);
			float horizAccSpeed = (float)LuaDLL.luaL_checknumber(L, 5);
			float horizEndSpeed = (float)LuaDLL.luaL_checknumber(L, 6);
			jumpBase.RoleJump(vertSpeed, horizSpeed, dashIncFactor, horizAccSpeed, horizEndSpeed);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SyncJump(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 11);
			JumpBase jumpBase = (JumpBase)ToLua.CheckObject(L, 1, typeof(JumpBase));
			int dir = (int)LuaDLL.luaL_checknumber(L, 2);
			int type = (int)LuaDLL.luaL_checknumber(L, 3);
			float vertSpeed = (float)LuaDLL.luaL_checknumber(L, 4);
			float horizSpeed = (float)LuaDLL.luaL_checknumber(L, 5);
			float horizAccSpeed = (float)LuaDLL.luaL_checknumber(L, 6);
			float endHorizSpeed = (float)LuaDLL.luaL_checknumber(L, 7);
			float curX = (float)LuaDLL.luaL_checknumber(L, 8);
			float curY = (float)LuaDLL.luaL_checknumber(L, 9);
			float curZ = (float)LuaDLL.luaL_checknumber(L, 10);
			float curTimer = (float)LuaDLL.luaL_checknumber(L, 11);
			jumpBase.SyncJump(dir, type, vertSpeed, horizSpeed, horizAccSpeed, endHorizSpeed, curX, curY, curZ, curTimer);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnJumpFinished(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 7);
			JumpBase jumpBase = (JumpBase)ToLua.CheckObject(L, 1, typeof(JumpBase));
			int x = (int)LuaDLL.luaL_checknumber(L, 2);
			int z = (int)LuaDLL.luaL_checknumber(L, 3);
			float realX = (float)LuaDLL.luaL_checknumber(L, 4);
			float realY = (float)LuaDLL.luaL_checknumber(L, 5);
			float realZ = (float)LuaDLL.luaL_checknumber(L, 6);
			float timer = (float)LuaDLL.luaL_checknumber(L, 7);
			jumpBase.OnJumpFinished(x, z, realX, realY, realZ, timer);
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
			JumpBase jumpBase = (JumpBase)ToLua.CheckObject(L, 1, typeof(JumpBase));
			jumpBase.StopJump();
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
	private static int get__self(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			JumpBase jumpBase = (JumpBase)obj;
			SceneEntity self = jumpBase._self;
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
	private static int get_offsetY(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			JumpBase jumpBase = (JumpBase)obj;
			float offsetY = jumpBase.offsetY;
			LuaDLL.lua_pushnumber(L, (double)offsetY);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index offsetY on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_offsetX(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			JumpBase jumpBase = (JumpBase)obj;
			float offsetX = jumpBase.offsetX;
			LuaDLL.lua_pushnumber(L, (double)offsetX);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index offsetX on a nil value");
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
			JumpBase jumpBase = (JumpBase)obj;
			int jumpMode = jumpBase.jumpMode;
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
	private static int get_startPos(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			JumpBase jumpBase = (JumpBase)obj;
			Vector3 startPos = jumpBase.startPos;
			ToLua.Push(L, startPos);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index startPos on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_startVertSpeed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			JumpBase jumpBase = (JumpBase)obj;
			float startVertSpeed = jumpBase.startVertSpeed;
			LuaDLL.lua_pushnumber(L, (double)startVertSpeed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index startVertSpeed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_curVertSpeed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			JumpBase jumpBase = (JumpBase)obj;
			float curVertSpeed = jumpBase.curVertSpeed;
			LuaDLL.lua_pushnumber(L, (double)curVertSpeed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index curVertSpeed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_horizAcceleration(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			JumpBase jumpBase = (JumpBase)obj;
			float horizAcceleration = jumpBase.horizAcceleration;
			LuaDLL.lua_pushnumber(L, (double)horizAcceleration);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horizAcceleration on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_startHorizSpeed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			JumpBase jumpBase = (JumpBase)obj;
			float startHorizSpeed = jumpBase.startHorizSpeed;
			LuaDLL.lua_pushnumber(L, (double)startHorizSpeed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index startHorizSpeed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_curHorizSpeed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			JumpBase jumpBase = (JumpBase)obj;
			float curHorizSpeed = jumpBase.curHorizSpeed;
			LuaDLL.lua_pushnumber(L, (double)curHorizSpeed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index curHorizSpeed on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_endHorizSpeed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			JumpBase jumpBase = (JumpBase)obj;
			float endHorizSpeed = jumpBase.endHorizSpeed;
			LuaDLL.lua_pushnumber(L, (double)endHorizSpeed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index endHorizSpeed on a nil value");
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
			JumpBase jumpBase = (JumpBase)obj;
			SceneEntity self = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			jumpBase._self = self;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index _self on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_offsetY(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			JumpBase jumpBase = (JumpBase)obj;
			float offsetY = (float)LuaDLL.luaL_checknumber(L, 2);
			jumpBase.offsetY = offsetY;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index offsetY on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_offsetX(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			JumpBase jumpBase = (JumpBase)obj;
			float offsetX = (float)LuaDLL.luaL_checknumber(L, 2);
			jumpBase.offsetX = offsetX;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index offsetX on a nil value");
		}
		return result;
	}
}
