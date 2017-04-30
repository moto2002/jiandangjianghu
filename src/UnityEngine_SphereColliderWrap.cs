using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_SphereColliderWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SphereCollider), typeof(Collider), null);
		L.RegFunction("New", new LuaCSFunction(UnityEngine_SphereColliderWrap._CreateUnityEngine_SphereCollider));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_SphereColliderWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("center", new LuaCSFunction(UnityEngine_SphereColliderWrap.get_center), new LuaCSFunction(UnityEngine_SphereColliderWrap.set_center));
		L.RegVar("radius", new LuaCSFunction(UnityEngine_SphereColliderWrap.get_radius), new LuaCSFunction(UnityEngine_SphereColliderWrap.set_radius));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_SphereCollider(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				SphereCollider obj = new SphereCollider();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.SphereCollider.New");
			}
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
	private static int get_center(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SphereCollider sphereCollider = (SphereCollider)obj;
			Vector3 center = sphereCollider.center;
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
	private static int get_radius(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SphereCollider sphereCollider = (SphereCollider)obj;
			float radius = sphereCollider.radius;
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
	private static int set_center(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SphereCollider sphereCollider = (SphereCollider)obj;
			Vector3 center = ToLua.ToVector3(L, 2);
			sphereCollider.center = center;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index center on a nil value");
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
			SphereCollider sphereCollider = (SphereCollider)obj;
			float radius = (float)LuaDLL.luaL_checknumber(L, 2);
			sphereCollider.radius = radius;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index radius on a nil value");
		}
		return result;
	}
}
