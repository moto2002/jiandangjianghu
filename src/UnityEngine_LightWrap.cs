using DG.Tweening;
using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.Rendering;

public class UnityEngine_LightWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Light), typeof(Behaviour), null);
		L.RegFunction("AddCommandBuffer", new LuaCSFunction(UnityEngine_LightWrap.AddCommandBuffer));
		L.RegFunction("RemoveCommandBuffer", new LuaCSFunction(UnityEngine_LightWrap.RemoveCommandBuffer));
		L.RegFunction("RemoveCommandBuffers", new LuaCSFunction(UnityEngine_LightWrap.RemoveCommandBuffers));
		L.RegFunction("RemoveAllCommandBuffers", new LuaCSFunction(UnityEngine_LightWrap.RemoveAllCommandBuffers));
		L.RegFunction("GetCommandBuffers", new LuaCSFunction(UnityEngine_LightWrap.GetCommandBuffers));
		L.RegFunction("GetLights", new LuaCSFunction(UnityEngine_LightWrap.GetLights));
		L.RegFunction("DOBlendableColor", new LuaCSFunction(UnityEngine_LightWrap.DOBlendableColor));
		L.RegFunction("DOShadowStrength", new LuaCSFunction(UnityEngine_LightWrap.DOShadowStrength));
		L.RegFunction("DOIntensity", new LuaCSFunction(UnityEngine_LightWrap.DOIntensity));
		L.RegFunction("DOColor", new LuaCSFunction(UnityEngine_LightWrap.DOColor));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_LightWrap._CreateUnityEngine_Light));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_LightWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("type", new LuaCSFunction(UnityEngine_LightWrap.get_type), new LuaCSFunction(UnityEngine_LightWrap.set_type));
		L.RegVar("color", new LuaCSFunction(UnityEngine_LightWrap.get_color), new LuaCSFunction(UnityEngine_LightWrap.set_color));
		L.RegVar("intensity", new LuaCSFunction(UnityEngine_LightWrap.get_intensity), new LuaCSFunction(UnityEngine_LightWrap.set_intensity));
		L.RegVar("bounceIntensity", new LuaCSFunction(UnityEngine_LightWrap.get_bounceIntensity), new LuaCSFunction(UnityEngine_LightWrap.set_bounceIntensity));
		L.RegVar("shadows", new LuaCSFunction(UnityEngine_LightWrap.get_shadows), new LuaCSFunction(UnityEngine_LightWrap.set_shadows));
		L.RegVar("shadowStrength", new LuaCSFunction(UnityEngine_LightWrap.get_shadowStrength), new LuaCSFunction(UnityEngine_LightWrap.set_shadowStrength));
		L.RegVar("shadowBias", new LuaCSFunction(UnityEngine_LightWrap.get_shadowBias), new LuaCSFunction(UnityEngine_LightWrap.set_shadowBias));
		L.RegVar("shadowNormalBias", new LuaCSFunction(UnityEngine_LightWrap.get_shadowNormalBias), new LuaCSFunction(UnityEngine_LightWrap.set_shadowNormalBias));
		L.RegVar("shadowNearPlane", new LuaCSFunction(UnityEngine_LightWrap.get_shadowNearPlane), new LuaCSFunction(UnityEngine_LightWrap.set_shadowNearPlane));
		L.RegVar("range", new LuaCSFunction(UnityEngine_LightWrap.get_range), new LuaCSFunction(UnityEngine_LightWrap.set_range));
		L.RegVar("spotAngle", new LuaCSFunction(UnityEngine_LightWrap.get_spotAngle), new LuaCSFunction(UnityEngine_LightWrap.set_spotAngle));
		L.RegVar("cookieSize", new LuaCSFunction(UnityEngine_LightWrap.get_cookieSize), new LuaCSFunction(UnityEngine_LightWrap.set_cookieSize));
		L.RegVar("cookie", new LuaCSFunction(UnityEngine_LightWrap.get_cookie), new LuaCSFunction(UnityEngine_LightWrap.set_cookie));
		L.RegVar("flare", new LuaCSFunction(UnityEngine_LightWrap.get_flare), new LuaCSFunction(UnityEngine_LightWrap.set_flare));
		L.RegVar("renderMode", new LuaCSFunction(UnityEngine_LightWrap.get_renderMode), new LuaCSFunction(UnityEngine_LightWrap.set_renderMode));
		L.RegVar("alreadyLightmapped", new LuaCSFunction(UnityEngine_LightWrap.get_alreadyLightmapped), new LuaCSFunction(UnityEngine_LightWrap.set_alreadyLightmapped));
		L.RegVar("cullingMask", new LuaCSFunction(UnityEngine_LightWrap.get_cullingMask), new LuaCSFunction(UnityEngine_LightWrap.set_cullingMask));
		L.RegVar("commandBufferCount", new LuaCSFunction(UnityEngine_LightWrap.get_commandBufferCount), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_Light(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Light obj = new Light();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Light.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddCommandBuffer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Light light = (Light)ToLua.CheckObject(L, 1, typeof(Light));
			LightEvent evt = (LightEvent)((int)ToLua.CheckObject(L, 2, typeof(LightEvent)));
			CommandBuffer buffer = (CommandBuffer)ToLua.CheckObject(L, 3, typeof(CommandBuffer));
			light.AddCommandBuffer(evt, buffer);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveCommandBuffer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Light light = (Light)ToLua.CheckObject(L, 1, typeof(Light));
			LightEvent evt = (LightEvent)((int)ToLua.CheckObject(L, 2, typeof(LightEvent)));
			CommandBuffer buffer = (CommandBuffer)ToLua.CheckObject(L, 3, typeof(CommandBuffer));
			light.RemoveCommandBuffer(evt, buffer);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveCommandBuffers(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Light light = (Light)ToLua.CheckObject(L, 1, typeof(Light));
			LightEvent evt = (LightEvent)((int)ToLua.CheckObject(L, 2, typeof(LightEvent)));
			light.RemoveCommandBuffers(evt);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveAllCommandBuffers(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Light light = (Light)ToLua.CheckObject(L, 1, typeof(Light));
			light.RemoveAllCommandBuffers();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCommandBuffers(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Light light = (Light)ToLua.CheckObject(L, 1, typeof(Light));
			LightEvent evt = (LightEvent)((int)ToLua.CheckObject(L, 2, typeof(LightEvent)));
			CommandBuffer[] commandBuffers = light.GetCommandBuffers(evt);
			ToLua.Push(L, commandBuffers);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetLights(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LightType type = (LightType)((int)ToLua.CheckObject(L, 1, typeof(LightType)));
			int layer = (int)LuaDLL.luaL_checknumber(L, 2);
			Light[] lights = Light.GetLights(type, layer);
			ToLua.Push(L, lights);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DOBlendableColor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Light target = (Light)ToLua.CheckObject(L, 1, typeof(Light));
			Color endValue = ToLua.ToColor(L, 2);
			float duration = (float)LuaDLL.luaL_checknumber(L, 3);
			Tweener o = target.DOBlendableColor(endValue, duration);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DOShadowStrength(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Light target = (Light)ToLua.CheckObject(L, 1, typeof(Light));
			float endValue = (float)LuaDLL.luaL_checknumber(L, 2);
			float duration = (float)LuaDLL.luaL_checknumber(L, 3);
			Tweener o = target.DOShadowStrength(endValue, duration);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DOIntensity(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Light target = (Light)ToLua.CheckObject(L, 1, typeof(Light));
			float endValue = (float)LuaDLL.luaL_checknumber(L, 2);
			float duration = (float)LuaDLL.luaL_checknumber(L, 3);
			Tweener o = target.DOIntensity(endValue, duration);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DOColor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Light target = (Light)ToLua.CheckObject(L, 1, typeof(Light));
			Color endValue = ToLua.ToColor(L, 2);
			float duration = (float)LuaDLL.luaL_checknumber(L, 3);
			Tweener o = target.DOColor(endValue, duration);
			ToLua.PushObject(L, o);
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
	private static int get_type(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			LightType type = light.type;
			ToLua.Push(L, type);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index type on a nil value");
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
			Light light = (Light)obj;
			Color color = light.color;
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
	private static int get_intensity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float intensity = light.intensity;
			LuaDLL.lua_pushnumber(L, (double)intensity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index intensity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bounceIntensity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float bounceIntensity = light.bounceIntensity;
			LuaDLL.lua_pushnumber(L, (double)bounceIntensity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bounceIntensity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shadows(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			LightShadows shadows = light.shadows;
			ToLua.Push(L, shadows);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadows on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shadowStrength(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float shadowStrength = light.shadowStrength;
			LuaDLL.lua_pushnumber(L, (double)shadowStrength);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadowStrength on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shadowBias(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float shadowBias = light.shadowBias;
			LuaDLL.lua_pushnumber(L, (double)shadowBias);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadowBias on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shadowNormalBias(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float shadowNormalBias = light.shadowNormalBias;
			LuaDLL.lua_pushnumber(L, (double)shadowNormalBias);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadowNormalBias on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shadowNearPlane(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float shadowNearPlane = light.shadowNearPlane;
			LuaDLL.lua_pushnumber(L, (double)shadowNearPlane);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadowNearPlane on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_range(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float range = light.range;
			LuaDLL.lua_pushnumber(L, (double)range);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index range on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_spotAngle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float spotAngle = light.spotAngle;
			LuaDLL.lua_pushnumber(L, (double)spotAngle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spotAngle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cookieSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float cookieSize = light.cookieSize;
			LuaDLL.lua_pushnumber(L, (double)cookieSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cookieSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cookie(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			Texture cookie = light.cookie;
			ToLua.Push(L, cookie);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cookie on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_flare(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			Flare flare = light.flare;
			ToLua.Push(L, flare);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index flare on a nil value");
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
			Light light = (Light)obj;
			LightRenderMode renderMode = light.renderMode;
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
	private static int get_alreadyLightmapped(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			bool alreadyLightmapped = light.alreadyLightmapped;
			LuaDLL.lua_pushboolean(L, alreadyLightmapped);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alreadyLightmapped on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cullingMask(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			int cullingMask = light.cullingMask;
			LuaDLL.lua_pushinteger(L, cullingMask);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cullingMask on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_commandBufferCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			int commandBufferCount = light.commandBufferCount;
			LuaDLL.lua_pushinteger(L, commandBufferCount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index commandBufferCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_type(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			LightType type = (LightType)((int)ToLua.CheckObject(L, 2, typeof(LightType)));
			light.type = type;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index type on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_color(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			Color color = ToLua.ToColor(L, 2);
			light.color = color;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index color on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_intensity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float intensity = (float)LuaDLL.luaL_checknumber(L, 2);
			light.intensity = intensity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index intensity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bounceIntensity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float bounceIntensity = (float)LuaDLL.luaL_checknumber(L, 2);
			light.bounceIntensity = bounceIntensity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bounceIntensity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shadows(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			LightShadows shadows = (LightShadows)((int)ToLua.CheckObject(L, 2, typeof(LightShadows)));
			light.shadows = shadows;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadows on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shadowStrength(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float shadowStrength = (float)LuaDLL.luaL_checknumber(L, 2);
			light.shadowStrength = shadowStrength;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadowStrength on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shadowBias(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float shadowBias = (float)LuaDLL.luaL_checknumber(L, 2);
			light.shadowBias = shadowBias;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadowBias on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shadowNormalBias(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float shadowNormalBias = (float)LuaDLL.luaL_checknumber(L, 2);
			light.shadowNormalBias = shadowNormalBias;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadowNormalBias on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shadowNearPlane(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float shadowNearPlane = (float)LuaDLL.luaL_checknumber(L, 2);
			light.shadowNearPlane = shadowNearPlane;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shadowNearPlane on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_range(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float range = (float)LuaDLL.luaL_checknumber(L, 2);
			light.range = range;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index range on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spotAngle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float spotAngle = (float)LuaDLL.luaL_checknumber(L, 2);
			light.spotAngle = spotAngle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index spotAngle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cookieSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			float cookieSize = (float)LuaDLL.luaL_checknumber(L, 2);
			light.cookieSize = cookieSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cookieSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cookie(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			Texture cookie = (Texture)ToLua.CheckUnityObject(L, 2, typeof(Texture));
			light.cookie = cookie;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cookie on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_flare(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			Flare flare = (Flare)ToLua.CheckUnityObject(L, 2, typeof(Flare));
			light.flare = flare;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index flare on a nil value");
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
			Light light = (Light)obj;
			LightRenderMode renderMode = (LightRenderMode)((int)ToLua.CheckObject(L, 2, typeof(LightRenderMode)));
			light.renderMode = renderMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index renderMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_alreadyLightmapped(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			bool alreadyLightmapped = LuaDLL.luaL_checkboolean(L, 2);
			light.alreadyLightmapped = alreadyLightmapped;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alreadyLightmapped on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cullingMask(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Light light = (Light)obj;
			int cullingMask = (int)LuaDLL.luaL_checknumber(L, 2);
			light.cullingMask = cullingMask;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cullingMask on a nil value");
		}
		return result;
	}
}
