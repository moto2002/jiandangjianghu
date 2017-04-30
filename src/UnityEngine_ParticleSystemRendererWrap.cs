using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_ParticleSystemRendererWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ParticleSystemRenderer), typeof(Renderer), null);
		L.RegFunction("New", new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap._CreateUnityEngine_ParticleSystemRenderer));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("renderMode", new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.get_renderMode), new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.set_renderMode));
		L.RegVar("lengthScale", new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.get_lengthScale), new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.set_lengthScale));
		L.RegVar("velocityScale", new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.get_velocityScale), new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.set_velocityScale));
		L.RegVar("cameraVelocityScale", new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.get_cameraVelocityScale), new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.set_cameraVelocityScale));
		L.RegVar("normalDirection", new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.get_normalDirection), new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.set_normalDirection));
		L.RegVar("alignment", new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.get_alignment), new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.set_alignment));
		L.RegVar("pivot", new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.get_pivot), new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.set_pivot));
		L.RegVar("sortMode", new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.get_sortMode), new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.set_sortMode));
		L.RegVar("sortingFudge", new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.get_sortingFudge), new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.set_sortingFudge));
		L.RegVar("minParticleSize", new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.get_minParticleSize), new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.set_minParticleSize));
		L.RegVar("maxParticleSize", new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.get_maxParticleSize), new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.set_maxParticleSize));
		L.RegVar("mesh", new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.get_mesh), new LuaCSFunction(UnityEngine_ParticleSystemRendererWrap.set_mesh));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_ParticleSystemRenderer(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				ParticleSystemRenderer obj = new ParticleSystemRenderer();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.ParticleSystemRenderer.New");
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
	private static int get_renderMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			ParticleSystemRenderMode renderMode = particleSystemRenderer.renderMode;
			ToLua.Push(L, renderMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index renderMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lengthScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			float lengthScale = particleSystemRenderer.lengthScale;
			LuaDLL.lua_pushnumber(L, (double)lengthScale);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lengthScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_velocityScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			float velocityScale = particleSystemRenderer.velocityScale;
			LuaDLL.lua_pushnumber(L, (double)velocityScale);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index velocityScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cameraVelocityScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			float cameraVelocityScale = particleSystemRenderer.cameraVelocityScale;
			LuaDLL.lua_pushnumber(L, (double)cameraVelocityScale);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cameraVelocityScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_normalDirection(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			float normalDirection = particleSystemRenderer.normalDirection;
			LuaDLL.lua_pushnumber(L, (double)normalDirection);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index normalDirection on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_alignment(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			ParticleSystemRenderSpace alignment = particleSystemRenderer.alignment;
			ToLua.Push(L, alignment);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alignment on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pivot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			Vector3 pivot = particleSystemRenderer.pivot;
			ToLua.Push(L, pivot);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pivot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sortMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			ParticleSystemSortMode sortMode = particleSystemRenderer.sortMode;
			ToLua.Push(L, sortMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sortingFudge(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			float sortingFudge = particleSystemRenderer.sortingFudge;
			LuaDLL.lua_pushnumber(L, (double)sortingFudge);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortingFudge on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minParticleSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			float minParticleSize = particleSystemRenderer.minParticleSize;
			LuaDLL.lua_pushnumber(L, (double)minParticleSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minParticleSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxParticleSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			float maxParticleSize = particleSystemRenderer.maxParticleSize;
			LuaDLL.lua_pushnumber(L, (double)maxParticleSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxParticleSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mesh(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			Mesh mesh = particleSystemRenderer.mesh;
			ToLua.Push(L, mesh);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mesh on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_renderMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			ParticleSystemRenderMode renderMode = (ParticleSystemRenderMode)((int)ToLua.CheckObject(L, 2, typeof(ParticleSystemRenderMode)));
			particleSystemRenderer.renderMode = renderMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index renderMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lengthScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			float lengthScale = (float)LuaDLL.luaL_checknumber(L, 2);
			particleSystemRenderer.lengthScale = lengthScale;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lengthScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_velocityScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			float velocityScale = (float)LuaDLL.luaL_checknumber(L, 2);
			particleSystemRenderer.velocityScale = velocityScale;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index velocityScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cameraVelocityScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			float cameraVelocityScale = (float)LuaDLL.luaL_checknumber(L, 2);
			particleSystemRenderer.cameraVelocityScale = cameraVelocityScale;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cameraVelocityScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_normalDirection(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			float normalDirection = (float)LuaDLL.luaL_checknumber(L, 2);
			particleSystemRenderer.normalDirection = normalDirection;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index normalDirection on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_alignment(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			ParticleSystemRenderSpace alignment = (ParticleSystemRenderSpace)((int)ToLua.CheckObject(L, 2, typeof(ParticleSystemRenderSpace)));
			particleSystemRenderer.alignment = alignment;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alignment on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pivot(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			Vector3 pivot = ToLua.ToVector3(L, 2);
			particleSystemRenderer.pivot = pivot;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pivot on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sortMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			ParticleSystemSortMode sortMode = (ParticleSystemSortMode)((int)ToLua.CheckObject(L, 2, typeof(ParticleSystemSortMode)));
			particleSystemRenderer.sortMode = sortMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sortingFudge(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			float sortingFudge = (float)LuaDLL.luaL_checknumber(L, 2);
			particleSystemRenderer.sortingFudge = sortingFudge;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sortingFudge on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_minParticleSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			float minParticleSize = (float)LuaDLL.luaL_checknumber(L, 2);
			particleSystemRenderer.minParticleSize = minParticleSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minParticleSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxParticleSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			float maxParticleSize = (float)LuaDLL.luaL_checknumber(L, 2);
			particleSystemRenderer.maxParticleSize = maxParticleSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxParticleSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mesh(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleSystemRenderer particleSystemRenderer = (ParticleSystemRenderer)obj;
			Mesh mesh = (Mesh)ToLua.CheckUnityObject(L, 2, typeof(Mesh));
			particleSystemRenderer.mesh = mesh;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mesh on a nil value");
		}
		return result;
	}
}
