using LuaInterface;
using System;
using UnityEngine;

public class UIParticlesWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIParticles), typeof(MonoBehaviour), null);
		L.RegFunction("Play", new LuaCSFunction(UIParticlesWrap.Play));
		L.RegFunction("Pause", new LuaCSFunction(UIParticlesWrap.Pause));
		L.RegFunction("Stop", new LuaCSFunction(UIParticlesWrap.Stop));
		L.RegFunction("SetParticleRotation", new LuaCSFunction(UIParticlesWrap.SetParticleRotation));
		L.RegFunction("__eq", new LuaCSFunction(UIParticlesWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("RenderQueue", new LuaCSFunction(UIParticlesWrap.get_RenderQueue), new LuaCSFunction(UIParticlesWrap.set_RenderQueue));
		L.RegVar("parentWidget", new LuaCSFunction(UIParticlesWrap.get_parentWidget), new LuaCSFunction(UIParticlesWrap.set_parentWidget));
		L.RegVar("IsForward", new LuaCSFunction(UIParticlesWrap.get_IsForward), new LuaCSFunction(UIParticlesWrap.set_IsForward));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Play(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIParticles uIParticles = (UIParticles)ToLua.CheckObject(L, 1, typeof(UIParticles));
			uIParticles.Play();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Pause(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIParticles uIParticles = (UIParticles)ToLua.CheckObject(L, 1, typeof(UIParticles));
			uIParticles.Pause();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Stop(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIParticles uIParticles = (UIParticles)ToLua.CheckObject(L, 1, typeof(UIParticles));
			uIParticles.Stop();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetParticleRotation(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			UIParticles uIParticles = (UIParticles)ToLua.CheckObject(L, 1, typeof(UIParticles));
			float x = (float)LuaDLL.luaL_checknumber(L, 2);
			float y = (float)LuaDLL.luaL_checknumber(L, 3);
			float z = (float)LuaDLL.luaL_checknumber(L, 4);
			uIParticles.SetParticleRotation(x, y, z);
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
	private static int get_RenderQueue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIParticles uIParticles = (UIParticles)obj;
			int renderQueue = uIParticles.RenderQueue;
			LuaDLL.lua_pushinteger(L, renderQueue);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index RenderQueue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_parentWidget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIParticles uIParticles = (UIParticles)obj;
			UIWidget parentWidget = uIParticles.parentWidget;
			ToLua.Push(L, parentWidget);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index parentWidget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_IsForward(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIParticles uIParticles = (UIParticles)obj;
			bool isForward = uIParticles.IsForward;
			LuaDLL.lua_pushboolean(L, isForward);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsForward on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_RenderQueue(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIParticles uIParticles = (UIParticles)obj;
			int renderQueue = (int)LuaDLL.luaL_checknumber(L, 2);
			uIParticles.RenderQueue = renderQueue;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index RenderQueue on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_parentWidget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIParticles uIParticles = (UIParticles)obj;
			UIWidget parentWidget = (UIWidget)ToLua.CheckUnityObject(L, 2, typeof(UIWidget));
			uIParticles.parentWidget = parentWidget;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index parentWidget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_IsForward(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIParticles uIParticles = (UIParticles)obj;
			bool isForward = LuaDLL.luaL_checkboolean(L, 2);
			uIParticles.IsForward = isForward;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index IsForward on a nil value");
		}
		return result;
	}
}
