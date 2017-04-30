using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_ResourceManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ResourceManager), typeof(Manager), null);
		L.RegFunction("initialize", new LuaCSFunction(LuaFramework_ResourceManagerWrap.initialize));
		L.RegFunction("LoadBundle", new LuaCSFunction(LuaFramework_ResourceManagerWrap.LoadBundle));
		L.RegFunction("LoadAssetAsync", new LuaCSFunction(LuaFramework_ResourceManagerWrap.LoadAssetAsync));
		L.RegFunction("LoadMaterial", new LuaCSFunction(LuaFramework_ResourceManagerWrap.LoadMaterial));
		L.RegFunction("LoadTexture", new LuaCSFunction(LuaFramework_ResourceManagerWrap.LoadTexture));
		L.RegFunction("LoadPrefab", new LuaCSFunction(LuaFramework_ResourceManagerWrap.LoadPrefab));
		L.RegFunction("__eq", new LuaCSFunction(LuaFramework_ResourceManagerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int initialize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ResourceManager resourceManager = (ResourceManager)ToLua.CheckObject(L, 1, typeof(ResourceManager));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action func;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				func = (Action)ToLua.CheckObject(L, 2, typeof(Action));
			}
			else
			{
				LuaFunction func2 = ToLua.ToLuaFunction(L, 2);
				func = (DelegateFactory.CreateDelegate(typeof(Action), func2) as Action);
			}
			resourceManager.initialize(func);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadBundle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ResourceManager resourceManager = (ResourceManager)ToLua.CheckObject(L, 1, typeof(ResourceManager));
			string name = ToLua.CheckString(L, 2);
			AssetBundle obj = resourceManager.LoadBundle(name);
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadAssetAsync(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ResourceManager resourceManager = (ResourceManager)ToLua.CheckObject(L, 1, typeof(ResourceManager));
			string assetName = ToLua.CheckString(L, 2);
			ALoadOperation iter = resourceManager.LoadAssetAsync(assetName);
			ToLua.Push(L, iter);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadMaterial(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(ResourceManager), typeof(string)))
			{
				ResourceManager resourceManager = (ResourceManager)ToLua.ToObject(L, 1);
				string assetName = ToLua.ToString(L, 2);
				Material obj = resourceManager.LoadMaterial(assetName);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(ResourceManager), typeof(string), typeof(bool)))
			{
				ResourceManager resourceManager2 = (ResourceManager)ToLua.ToObject(L, 1);
				string assetName2 = ToLua.ToString(L, 2);
				bool isBundleMode = LuaDLL.lua_toboolean(L, 3);
				Material obj2 = resourceManager2.LoadMaterial(assetName2, isBundleMode);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.ResourceManager.LoadMaterial");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadTexture(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(ResourceManager), typeof(string)))
			{
				ResourceManager resourceManager = (ResourceManager)ToLua.ToObject(L, 1);
				string assetName = ToLua.ToString(L, 2);
				Texture obj = resourceManager.LoadTexture(assetName);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(ResourceManager), typeof(string), typeof(bool)))
			{
				ResourceManager resourceManager2 = (ResourceManager)ToLua.ToObject(L, 1);
				string assetName2 = ToLua.ToString(L, 2);
				bool isBundleMode = LuaDLL.lua_toboolean(L, 3);
				Texture obj2 = resourceManager2.LoadTexture(assetName2, isBundleMode);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.ResourceManager.LoadTexture");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadPrefab(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(ResourceManager), typeof(string)))
			{
				ResourceManager resourceManager = (ResourceManager)ToLua.ToObject(L, 1);
				string assetName = ToLua.ToString(L, 2);
				GameObject obj = resourceManager.LoadPrefab(assetName);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(ResourceManager), typeof(string), typeof(bool)))
			{
				ResourceManager resourceManager2 = (ResourceManager)ToLua.ToObject(L, 1);
				string assetName2 = ToLua.ToString(L, 2);
				bool isBundleMode = LuaDLL.lua_toboolean(L, 3);
				GameObject obj2 = resourceManager2.LoadPrefab(assetName2, isBundleMode);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.ResourceManager.LoadPrefab");
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
}
