using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_RandomWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.Random), typeof(object), null);
		L.RegFunction("Range", new LuaCSFunction(UnityEngine_RandomWrap.Range));
		L.RegFunction("ColorHSV", new LuaCSFunction(UnityEngine_RandomWrap.ColorHSV));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_RandomWrap._CreateUnityEngine_Random));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("seed", new LuaCSFunction(UnityEngine_RandomWrap.get_seed), new LuaCSFunction(UnityEngine_RandomWrap.set_seed));
		L.RegVar("value", new LuaCSFunction(UnityEngine_RandomWrap.get_value), null);
		L.RegVar("insideUnitSphere", new LuaCSFunction(UnityEngine_RandomWrap.get_insideUnitSphere), null);
		L.RegVar("insideUnitCircle", new LuaCSFunction(UnityEngine_RandomWrap.get_insideUnitCircle), null);
		L.RegVar("onUnitSphere", new LuaCSFunction(UnityEngine_RandomWrap.get_onUnitSphere), null);
		L.RegVar("rotation", new LuaCSFunction(UnityEngine_RandomWrap.get_rotation), null);
		L.RegVar("rotationUniform", new LuaCSFunction(UnityEngine_RandomWrap.get_rotationUniform), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_Random(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				UnityEngine.Random o = new UnityEngine.Random();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Random.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Range(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int)))
			{
				int min = (int)LuaDLL.lua_tonumber(L, 1);
				int max = (int)LuaDLL.lua_tonumber(L, 2);
				int n = UnityEngine.Random.Range(min, max);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float)))
			{
				float min2 = (float)LuaDLL.lua_tonumber(L, 1);
				float max2 = (float)LuaDLL.lua_tonumber(L, 2);
				float num2 = UnityEngine.Random.Range(min2, max2);
				LuaDLL.lua_pushnumber(L, (double)num2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Random.Range");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ColorHSV(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				Color clr = UnityEngine.Random.ColorHSV();
				ToLua.Push(L, clr);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float)))
			{
				float hueMin = (float)LuaDLL.lua_tonumber(L, 1);
				float hueMax = (float)LuaDLL.lua_tonumber(L, 2);
				Color clr2 = UnityEngine.Random.ColorHSV(hueMin, hueMax);
				ToLua.Push(L, clr2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(float)))
			{
				float hueMin2 = (float)LuaDLL.lua_tonumber(L, 1);
				float hueMax2 = (float)LuaDLL.lua_tonumber(L, 2);
				float saturationMin = (float)LuaDLL.lua_tonumber(L, 3);
				float saturationMax = (float)LuaDLL.lua_tonumber(L, 4);
				Color clr3 = UnityEngine.Random.ColorHSV(hueMin2, hueMax2, saturationMin, saturationMax);
				ToLua.Push(L, clr3);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float)))
			{
				float hueMin3 = (float)LuaDLL.lua_tonumber(L, 1);
				float hueMax3 = (float)LuaDLL.lua_tonumber(L, 2);
				float saturationMin2 = (float)LuaDLL.lua_tonumber(L, 3);
				float saturationMax2 = (float)LuaDLL.lua_tonumber(L, 4);
				float valueMin = (float)LuaDLL.lua_tonumber(L, 5);
				float valueMax = (float)LuaDLL.lua_tonumber(L, 6);
				Color clr4 = UnityEngine.Random.ColorHSV(hueMin3, hueMax3, saturationMin2, saturationMax2, valueMin, valueMax);
				ToLua.Push(L, clr4);
				result = 1;
			}
			else if (num == 8 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float)))
			{
				float hueMin4 = (float)LuaDLL.lua_tonumber(L, 1);
				float hueMax4 = (float)LuaDLL.lua_tonumber(L, 2);
				float saturationMin3 = (float)LuaDLL.lua_tonumber(L, 3);
				float saturationMax3 = (float)LuaDLL.lua_tonumber(L, 4);
				float valueMin2 = (float)LuaDLL.lua_tonumber(L, 5);
				float valueMax2 = (float)LuaDLL.lua_tonumber(L, 6);
				float alphaMin = (float)LuaDLL.lua_tonumber(L, 7);
				float alphaMax = (float)LuaDLL.lua_tonumber(L, 8);
				Color clr5 = UnityEngine.Random.ColorHSV(hueMin4, hueMax4, saturationMin3, saturationMax3, valueMin2, valueMax2, alphaMin, alphaMax);
				ToLua.Push(L, clr5);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Random.ColorHSV");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_seed(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.Random.seed);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_value(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)UnityEngine.Random.value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_insideUnitSphere(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UnityEngine.Random.insideUnitSphere);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_insideUnitCircle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UnityEngine.Random.insideUnitCircle);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onUnitSphere(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UnityEngine.Random.onUnitSphere);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rotation(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UnityEngine.Random.rotation);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rotationUniform(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UnityEngine.Random.rotationUniform);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_seed(IntPtr L)
	{
		int result;
		try
		{
			int seed = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Random.seed = seed;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
