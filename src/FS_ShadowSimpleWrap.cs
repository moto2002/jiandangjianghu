using LuaInterface;
using System;
using UnityEngine;

public class FS_ShadowSimpleWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(FS_ShadowSimple), typeof(MonoBehaviour), null);
		L.RegFunction("__eq", new LuaCSFunction(FS_ShadowSimpleWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("maxProjectionDistance", new LuaCSFunction(FS_ShadowSimpleWrap.get_maxProjectionDistance), new LuaCSFunction(FS_ShadowSimpleWrap.set_maxProjectionDistance));
		L.RegVar("girth", new LuaCSFunction(FS_ShadowSimpleWrap.get_girth), new LuaCSFunction(FS_ShadowSimpleWrap.set_girth));
		L.RegVar("shadowHoverHeight", new LuaCSFunction(FS_ShadowSimpleWrap.get_shadowHoverHeight), new LuaCSFunction(FS_ShadowSimpleWrap.set_shadowHoverHeight));
		L.RegVar("layerMask", new LuaCSFunction(FS_ShadowSimpleWrap.get_layerMask), new LuaCSFunction(FS_ShadowSimpleWrap.set_layerMask));
		L.RegVar("shadowMaterial", new LuaCSFunction(FS_ShadowSimpleWrap.get_shadowMaterial), new LuaCSFunction(FS_ShadowSimpleWrap.set_shadowMaterial));
		L.RegVar("isStatic", new LuaCSFunction(FS_ShadowSimpleWrap.get_isStatic), new LuaCSFunction(FS_ShadowSimpleWrap.set_isStatic));
		L.RegVar("useLightSource", new LuaCSFunction(FS_ShadowSimpleWrap.get_useLightSource), new LuaCSFunction(FS_ShadowSimpleWrap.set_useLightSource));
		L.RegVar("lightSource", new LuaCSFunction(FS_ShadowSimpleWrap.get_lightSource), new LuaCSFunction(FS_ShadowSimpleWrap.set_lightSource));
		L.RegVar("lightDirection", new LuaCSFunction(FS_ShadowSimpleWrap.get_lightDirection), new LuaCSFunction(FS_ShadowSimpleWrap.set_lightDirection));
		L.RegVar("isPerspectiveProjection", new LuaCSFunction(FS_ShadowSimpleWrap.get_isPerspectiveProjection), new LuaCSFunction(FS_ShadowSimpleWrap.set_isPerspectiveProjection));
		L.RegVar("doVisibilityCulling", new LuaCSFunction(FS_ShadowSimpleWrap.get_doVisibilityCulling), new LuaCSFunction(FS_ShadowSimpleWrap.set_doVisibilityCulling));
		L.RegVar("uvs", new LuaCSFunction(FS_ShadowSimpleWrap.get_uvs), new LuaCSFunction(FS_ShadowSimpleWrap.set_uvs));
		L.RegVar("corners", new LuaCSFunction(FS_ShadowSimpleWrap.get_corners), null);
		L.RegVar("color", new LuaCSFunction(FS_ShadowSimpleWrap.get_color), null);
		L.RegVar("normal", new LuaCSFunction(FS_ShadowSimpleWrap.get_normal), null);
		L.EndClass();
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
	private static int get_maxProjectionDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			float maxProjectionDistance = fS_ShadowSimple.maxProjectionDistance;
			LuaDLL.lua_pushnumber(L, (double)maxProjectionDistance);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxProjectionDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_girth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			float girth = fS_ShadowSimple.girth;
			LuaDLL.lua_pushnumber(L, (double)girth);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index girth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shadowHoverHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			float shadowHoverHeight = fS_ShadowSimple.shadowHoverHeight;
			LuaDLL.lua_pushnumber(L, (double)shadowHoverHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadowHoverHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_layerMask(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			LayerMask layerMask = fS_ShadowSimple.layerMask;
			ToLua.PushLayerMask(L, layerMask);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index layerMask on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shadowMaterial(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			Material shadowMaterial = fS_ShadowSimple.shadowMaterial;
			ToLua.Push(L, shadowMaterial);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadowMaterial on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isStatic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			bool isStatic = fS_ShadowSimple.isStatic;
			LuaDLL.lua_pushboolean(L, isStatic);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isStatic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useLightSource(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			bool useLightSource = fS_ShadowSimple.useLightSource;
			LuaDLL.lua_pushboolean(L, useLightSource);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useLightSource on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lightSource(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			GameObject lightSource = fS_ShadowSimple.lightSource;
			ToLua.Push(L, lightSource);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lightSource on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lightDirection(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			Vector3 lightDirection = fS_ShadowSimple.lightDirection;
			ToLua.Push(L, lightDirection);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lightDirection on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isPerspectiveProjection(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			bool isPerspectiveProjection = fS_ShadowSimple.isPerspectiveProjection;
			LuaDLL.lua_pushboolean(L, isPerspectiveProjection);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isPerspectiveProjection on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_doVisibilityCulling(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			bool doVisibilityCulling = fS_ShadowSimple.doVisibilityCulling;
			LuaDLL.lua_pushboolean(L, doVisibilityCulling);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index doVisibilityCulling on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_uvs(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			Rect uvs = fS_ShadowSimple.uvs;
			ToLua.PushValue(L, uvs);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index uvs on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_corners(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			Vector3[] corners = fS_ShadowSimple.corners;
			ToLua.Push(L, corners);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index corners on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_color(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			Color color = fS_ShadowSimple.color;
			ToLua.Push(L, color);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index color on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_normal(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			Vector3 normal = fS_ShadowSimple.normal;
			ToLua.Push(L, normal);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index normal on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxProjectionDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			float maxProjectionDistance = (float)LuaDLL.luaL_checknumber(L, 2);
			fS_ShadowSimple.maxProjectionDistance = maxProjectionDistance;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxProjectionDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_girth(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			float girth = (float)LuaDLL.luaL_checknumber(L, 2);
			fS_ShadowSimple.girth = girth;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index girth on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shadowHoverHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			float shadowHoverHeight = (float)LuaDLL.luaL_checknumber(L, 2);
			fS_ShadowSimple.shadowHoverHeight = shadowHoverHeight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadowHoverHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_layerMask(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			LayerMask layerMask = ToLua.ToLayerMask(L, 2);
			fS_ShadowSimple.layerMask = layerMask;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index layerMask on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shadowMaterial(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			Material shadowMaterial = (Material)ToLua.CheckUnityObject(L, 2, typeof(Material));
			fS_ShadowSimple.shadowMaterial = shadowMaterial;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadowMaterial on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isStatic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			bool isStatic = LuaDLL.luaL_checkboolean(L, 2);
			fS_ShadowSimple.isStatic = isStatic;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isStatic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useLightSource(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			bool useLightSource = LuaDLL.luaL_checkboolean(L, 2);
			fS_ShadowSimple.useLightSource = useLightSource;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useLightSource on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lightSource(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			GameObject lightSource = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			fS_ShadowSimple.lightSource = lightSource;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lightSource on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lightDirection(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			Vector3 lightDirection = ToLua.ToVector3(L, 2);
			fS_ShadowSimple.lightDirection = lightDirection;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lightDirection on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isPerspectiveProjection(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			bool isPerspectiveProjection = LuaDLL.luaL_checkboolean(L, 2);
			fS_ShadowSimple.isPerspectiveProjection = isPerspectiveProjection;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isPerspectiveProjection on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_doVisibilityCulling(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			bool doVisibilityCulling = LuaDLL.luaL_checkboolean(L, 2);
			fS_ShadowSimple.doVisibilityCulling = doVisibilityCulling;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index doVisibilityCulling on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_uvs(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			FS_ShadowSimple fS_ShadowSimple = (FS_ShadowSimple)obj;
			Rect uvs = (Rect)ToLua.CheckObject(L, 2, typeof(Rect));
			fS_ShadowSimple.uvs = uvs;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index uvs on a nil value");
		}
		return result;
	}
}
