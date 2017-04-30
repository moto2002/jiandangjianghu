using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_CharacterControllerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(CharacterController), typeof(Collider), null);
		L.RegFunction("SimpleMove", new LuaCSFunction(UnityEngine_CharacterControllerWrap.SimpleMove));
		L.RegFunction("Move", new LuaCSFunction(UnityEngine_CharacterControllerWrap.Move));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_CharacterControllerWrap._CreateUnityEngine_CharacterController));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_CharacterControllerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("isGrounded", new LuaCSFunction(UnityEngine_CharacterControllerWrap.get_isGrounded), null);
		L.RegVar("velocity", new LuaCSFunction(UnityEngine_CharacterControllerWrap.get_velocity), null);
		L.RegVar("collisionFlags", new LuaCSFunction(UnityEngine_CharacterControllerWrap.get_collisionFlags), null);
		L.RegVar("radius", new LuaCSFunction(UnityEngine_CharacterControllerWrap.get_radius), new LuaCSFunction(UnityEngine_CharacterControllerWrap.set_radius));
		L.RegVar("height", new LuaCSFunction(UnityEngine_CharacterControllerWrap.get_height), new LuaCSFunction(UnityEngine_CharacterControllerWrap.set_height));
		L.RegVar("center", new LuaCSFunction(UnityEngine_CharacterControllerWrap.get_center), new LuaCSFunction(UnityEngine_CharacterControllerWrap.set_center));
		L.RegVar("slopeLimit", new LuaCSFunction(UnityEngine_CharacterControllerWrap.get_slopeLimit), new LuaCSFunction(UnityEngine_CharacterControllerWrap.set_slopeLimit));
		L.RegVar("stepOffset", new LuaCSFunction(UnityEngine_CharacterControllerWrap.get_stepOffset), new LuaCSFunction(UnityEngine_CharacterControllerWrap.set_stepOffset));
		L.RegVar("skinWidth", new LuaCSFunction(UnityEngine_CharacterControllerWrap.get_skinWidth), new LuaCSFunction(UnityEngine_CharacterControllerWrap.set_skinWidth));
		L.RegVar("detectCollisions", new LuaCSFunction(UnityEngine_CharacterControllerWrap.get_detectCollisions), new LuaCSFunction(UnityEngine_CharacterControllerWrap.set_detectCollisions));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_CharacterController(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				CharacterController obj = new CharacterController();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.CharacterController.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SimpleMove(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			CharacterController characterController = (CharacterController)ToLua.CheckObject(L, 1, typeof(CharacterController));
			Vector3 speed = ToLua.ToVector3(L, 2);
			bool value = characterController.SimpleMove(speed);
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
	private static int Move(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			CharacterController characterController = (CharacterController)ToLua.CheckObject(L, 1, typeof(CharacterController));
			Vector3 motion = ToLua.ToVector3(L, 2);
			CollisionFlags collisionFlags = characterController.Move(motion);
			ToLua.Push(L, collisionFlags);
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
	private static int get_isGrounded(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CharacterController characterController = (CharacterController)obj;
			bool isGrounded = characterController.isGrounded;
			LuaDLL.lua_pushboolean(L, isGrounded);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isGrounded on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_velocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CharacterController characterController = (CharacterController)obj;
			Vector3 velocity = characterController.velocity;
			ToLua.Push(L, velocity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index velocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_collisionFlags(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CharacterController characterController = (CharacterController)obj;
			CollisionFlags collisionFlags = characterController.collisionFlags;
			ToLua.Push(L, collisionFlags);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index collisionFlags on a nil value");
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
			CharacterController characterController = (CharacterController)obj;
			float radius = characterController.radius;
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
	private static int get_height(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CharacterController characterController = (CharacterController)obj;
			float height = characterController.height;
			LuaDLL.lua_pushnumber(L, (double)height);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index height on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_center(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CharacterController characterController = (CharacterController)obj;
			Vector3 center = characterController.center;
			ToLua.Push(L, center);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index center on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_slopeLimit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CharacterController characterController = (CharacterController)obj;
			float slopeLimit = characterController.slopeLimit;
			LuaDLL.lua_pushnumber(L, (double)slopeLimit);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index slopeLimit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_stepOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CharacterController characterController = (CharacterController)obj;
			float stepOffset = characterController.stepOffset;
			LuaDLL.lua_pushnumber(L, (double)stepOffset);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stepOffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_skinWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CharacterController characterController = (CharacterController)obj;
			float skinWidth = characterController.skinWidth;
			LuaDLL.lua_pushnumber(L, (double)skinWidth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index skinWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_detectCollisions(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CharacterController characterController = (CharacterController)obj;
			bool detectCollisions = characterController.detectCollisions;
			LuaDLL.lua_pushboolean(L, detectCollisions);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index detectCollisions on a nil value");
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
			CharacterController characterController = (CharacterController)obj;
			float radius = (float)LuaDLL.luaL_checknumber(L, 2);
			characterController.radius = radius;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index radius on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_height(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CharacterController characterController = (CharacterController)obj;
			float height = (float)LuaDLL.luaL_checknumber(L, 2);
			characterController.height = height;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index height on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_center(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CharacterController characterController = (CharacterController)obj;
			Vector3 center = ToLua.ToVector3(L, 2);
			characterController.center = center;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index center on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_slopeLimit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CharacterController characterController = (CharacterController)obj;
			float slopeLimit = (float)LuaDLL.luaL_checknumber(L, 2);
			characterController.slopeLimit = slopeLimit;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index slopeLimit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_stepOffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CharacterController characterController = (CharacterController)obj;
			float stepOffset = (float)LuaDLL.luaL_checknumber(L, 2);
			characterController.stepOffset = stepOffset;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index stepOffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_skinWidth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CharacterController characterController = (CharacterController)obj;
			float skinWidth = (float)LuaDLL.luaL_checknumber(L, 2);
			characterController.skinWidth = skinWidth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index skinWidth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_detectCollisions(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CharacterController characterController = (CharacterController)obj;
			bool detectCollisions = LuaDLL.luaL_checkboolean(L, 2);
			characterController.detectCollisions = detectCollisions;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index detectCollisions on a nil value");
		}
		return result;
	}
}
