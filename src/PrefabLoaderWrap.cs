using LuaInterface;
using System;
using UnityEngine;

public class PrefabLoaderWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(PrefabLoader), typeof(MonoBehaviour), null);
		L.RegFunction("ResetRenderQ", new LuaCSFunction(PrefabLoaderWrap.ResetRenderQ));
		L.RegFunction("__eq", new LuaCSFunction(PrefabLoaderWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("prefabs", new LuaCSFunction(PrefabLoaderWrap.get_prefabs), new LuaCSFunction(PrefabLoaderWrap.set_prefabs));
		L.RegVar("scale", new LuaCSFunction(PrefabLoaderWrap.get_scale), new LuaCSFunction(PrefabLoaderWrap.set_scale));
		L.RegVar("position", new LuaCSFunction(PrefabLoaderWrap.get_position), new LuaCSFunction(PrefabLoaderWrap.set_position));
		L.RegVar("rotation", new LuaCSFunction(PrefabLoaderWrap.get_rotation), new LuaCSFunction(PrefabLoaderWrap.set_rotation));
		L.RegVar("renderQ", new LuaCSFunction(PrefabLoaderWrap.get_renderQ), new LuaCSFunction(PrefabLoaderWrap.set_renderQ));
		L.RegVar("scaleFactor", new LuaCSFunction(PrefabLoaderWrap.get_scaleFactor), new LuaCSFunction(PrefabLoaderWrap.set_scaleFactor));
		L.RegVar("changeToClipShader", new LuaCSFunction(PrefabLoaderWrap.get_changeToClipShader), new LuaCSFunction(PrefabLoaderWrap.set_changeToClipShader));
		L.RegVar("Done", new LuaCSFunction(PrefabLoaderWrap.get_Done), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetRenderQ(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)ToLua.CheckObject(L, 1, typeof(PrefabLoader));
			prefabLoader.ResetRenderQ();
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
	private static int get_prefabs(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			GameObject[] prefabs = prefabLoader.prefabs;
			ToLua.Push(L, prefabs);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index prefabs on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_scale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			Vector3[] scale = prefabLoader.scale;
			ToLua.Push(L, scale);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_position(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			Vector3[] position = prefabLoader.position;
			ToLua.Push(L, position);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index position on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			Vector3[] rotation = prefabLoader.rotation;
			ToLua.Push(L, rotation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_renderQ(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			int renderQ = prefabLoader.renderQ;
			LuaDLL.lua_pushinteger(L, renderQ);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index renderQ on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_scaleFactor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			float scaleFactor = prefabLoader.scaleFactor;
			LuaDLL.lua_pushnumber(L, (double)scaleFactor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scaleFactor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_changeToClipShader(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			bool changeToClipShader = prefabLoader.changeToClipShader;
			LuaDLL.lua_pushboolean(L, changeToClipShader);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index changeToClipShader on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Done(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			bool done = prefabLoader.Done;
			LuaDLL.lua_pushboolean(L, done);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Done on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_prefabs(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			GameObject[] prefabs = ToLua.CheckObjectArray<GameObject>(L, 2);
			prefabLoader.prefabs = prefabs;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index prefabs on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_scale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			Vector3[] scale = ToLua.CheckObjectArray<Vector3>(L, 2);
			prefabLoader.scale = scale;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_position(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			Vector3[] position = ToLua.CheckObjectArray<Vector3>(L, 2);
			prefabLoader.position = position;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index position on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			Vector3[] rotation = ToLua.CheckObjectArray<Vector3>(L, 2);
			prefabLoader.rotation = rotation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_renderQ(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			int renderQ = (int)LuaDLL.luaL_checknumber(L, 2);
			prefabLoader.renderQ = renderQ;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index renderQ on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_scaleFactor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			float scaleFactor = (float)LuaDLL.luaL_checknumber(L, 2);
			prefabLoader.scaleFactor = scaleFactor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scaleFactor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_changeToClipShader(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PrefabLoader prefabLoader = (PrefabLoader)obj;
			bool changeToClipShader = LuaDLL.luaL_checkboolean(L, 2);
			prefabLoader.changeToClipShader = changeToClipShader;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index changeToClipShader on a nil value");
		}
		return result;
	}
}
