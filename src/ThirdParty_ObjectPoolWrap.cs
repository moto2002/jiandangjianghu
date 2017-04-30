using LuaInterface;
using System;
using System.Collections.Generic;
using ThirdParty;
using UnityEngine;

public class ThirdParty_ObjectPoolWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ObjectPool), typeof(MonoBehaviour), null);
		L.RegFunction("PopOld", new LuaCSFunction(ThirdParty_ObjectPoolWrap.PopOld));
		L.RegFunction("PushToPool", new LuaCSFunction(ThirdParty_ObjectPoolWrap.PushToPool));
		L.RegFunction("AsyncPushToPool", new LuaCSFunction(ThirdParty_ObjectPoolWrap.AsyncPushToPool));
		L.RegFunction("CreateStartupPools", new LuaCSFunction(ThirdParty_ObjectPoolWrap.CreateStartupPools));
		L.RegFunction("CreatePool", new LuaCSFunction(ThirdParty_ObjectPoolWrap.CreatePool));
		L.RegFunction("Spawn", new LuaCSFunction(ThirdParty_ObjectPoolWrap.Spawn));
		L.RegFunction("Recycle", new LuaCSFunction(ThirdParty_ObjectPoolWrap.Recycle));
		L.RegFunction("RecycleAll", new LuaCSFunction(ThirdParty_ObjectPoolWrap.RecycleAll));
		L.RegFunction("IsSpawned", new LuaCSFunction(ThirdParty_ObjectPoolWrap.IsSpawned));
		L.RegFunction("CountPooled", new LuaCSFunction(ThirdParty_ObjectPoolWrap.CountPooled));
		L.RegFunction("CountSpawned", new LuaCSFunction(ThirdParty_ObjectPoolWrap.CountSpawned));
		L.RegFunction("CountAllPooled", new LuaCSFunction(ThirdParty_ObjectPoolWrap.CountAllPooled));
		L.RegFunction("GetPooled", new LuaCSFunction(ThirdParty_ObjectPoolWrap.GetPooled));
		L.RegFunction("GetSpawned", new LuaCSFunction(ThirdParty_ObjectPoolWrap.GetSpawned));
		L.RegFunction("DestroyPooled", new LuaCSFunction(ThirdParty_ObjectPoolWrap.DestroyPooled));
		L.RegFunction("DestroyAll", new LuaCSFunction(ThirdParty_ObjectPoolWrap.DestroyAll));
		L.RegFunction("__eq", new LuaCSFunction(ThirdParty_ObjectPoolWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegConstant("POOL_INIT_SIZE", 15.0);
		L.RegVar("pooledObjNames", new LuaCSFunction(ThirdParty_ObjectPoolWrap.get_pooledObjNames), new LuaCSFunction(ThirdParty_ObjectPoolWrap.set_pooledObjNames));
		L.RegVar("startupPoolMode", new LuaCSFunction(ThirdParty_ObjectPoolWrap.get_startupPoolMode), new LuaCSFunction(ThirdParty_ObjectPoolWrap.set_startupPoolMode));
		L.RegVar("startupPools", new LuaCSFunction(ThirdParty_ObjectPoolWrap.get_startupPools), new LuaCSFunction(ThirdParty_ObjectPoolWrap.set_startupPools));
		L.RegVar("instance", new LuaCSFunction(ThirdParty_ObjectPoolWrap.get_instance), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PopOld(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			ObjectPool.PopOld();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PushToPool(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(ObjectPool), typeof(string), typeof(int), typeof(Transform)))
			{
				ObjectPool objectPool = (ObjectPool)ToLua.ToObject(L, 1);
				string prefabPath = ToLua.ToString(L, 2);
				int initSize = (int)LuaDLL.lua_tonumber(L, 3);
				Transform parent = (Transform)ToLua.ToObject(L, 4);
				GameObject obj = objectPool.PushToPool(prefabPath, initSize, parent);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(ObjectPool), typeof(string), typeof(int), typeof(Transform), typeof(float), typeof(float), typeof(float)))
			{
				ObjectPool objectPool2 = (ObjectPool)ToLua.ToObject(L, 1);
				string prefabPath2 = ToLua.ToString(L, 2);
				int initSize2 = (int)LuaDLL.lua_tonumber(L, 3);
				Transform parent2 = (Transform)ToLua.ToObject(L, 4);
				float x = (float)LuaDLL.lua_tonumber(L, 5);
				float y = (float)LuaDLL.lua_tonumber(L, 6);
				float z = (float)LuaDLL.lua_tonumber(L, 7);
				GameObject obj2 = objectPool2.PushToPool(prefabPath2, initSize2, parent2, x, y, z);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else if (num == 10 && TypeChecker.CheckTypes(L, 1, typeof(ObjectPool), typeof(string), typeof(int), typeof(Transform), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float), typeof(float)))
			{
				ObjectPool objectPool3 = (ObjectPool)ToLua.ToObject(L, 1);
				string prefabPath3 = ToLua.ToString(L, 2);
				int initSize3 = (int)LuaDLL.lua_tonumber(L, 3);
				Transform parent3 = (Transform)ToLua.ToObject(L, 4);
				float x2 = (float)LuaDLL.lua_tonumber(L, 5);
				float y2 = (float)LuaDLL.lua_tonumber(L, 6);
				float z2 = (float)LuaDLL.lua_tonumber(L, 7);
				float rx = (float)LuaDLL.lua_tonumber(L, 8);
				float ry = (float)LuaDLL.lua_tonumber(L, 9);
				float rz = (float)LuaDLL.lua_tonumber(L, 10);
				GameObject obj3 = objectPool3.PushToPool(prefabPath3, initSize3, parent3, x2, y2, z2, rx, ry, rz);
				ToLua.Push(L, obj3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: ThirdParty.ObjectPool.PushToPool");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AsyncPushToPool(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 8);
			ObjectPool objectPool = (ObjectPool)ToLua.CheckObject(L, 1, typeof(ObjectPool));
			string prefabPath = ToLua.CheckString(L, 2);
			int initSize = (int)LuaDLL.luaL_checknumber(L, 3);
			Transform parent = (Transform)ToLua.CheckUnityObject(L, 4, typeof(Transform));
			float x = (float)LuaDLL.luaL_checknumber(L, 5);
			float y = (float)LuaDLL.luaL_checknumber(L, 6);
			float z = (float)LuaDLL.luaL_checknumber(L, 7);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 8);
			Action<GameObject, string> callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Action<GameObject, string>)ToLua.CheckObject(L, 8, typeof(Action<GameObject, string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 8);
				callback = (DelegateFactory.CreateDelegate(typeof(Action<GameObject, string>), func) as Action<GameObject, string>);
			}
			objectPool.AsyncPushToPool(prefabPath, initSize, parent, x, y, z, callback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateStartupPools(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			ObjectPool.CreateStartupPools();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreatePool(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(int)))
			{
				GameObject prefab = (GameObject)ToLua.ToObject(L, 1);
				int initialPoolSize = (int)LuaDLL.lua_tonumber(L, 2);
				ObjectPool.CreatePool(prefab, initialPoolSize);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Component), typeof(int)))
			{
				Component prefab2 = (Component)ToLua.ToObject(L, 1);
				int initialPoolSize2 = (int)LuaDLL.lua_tonumber(L, 2);
				ObjectPool.CreatePool<Component>(prefab2, initialPoolSize2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: ThirdParty.ObjectPool.CreatePool");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Spawn(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Component)))
			{
				Component prefab = (Component)ToLua.ToObject(L, 1);
				Component obj = ObjectPool.Spawn<Component>(prefab);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GameObject)))
			{
				GameObject prefab2 = (GameObject)ToLua.ToObject(L, 1);
				GameObject obj2 = ObjectPool.Spawn(prefab2);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Component), typeof(Transform)))
			{
				Component prefab3 = (Component)ToLua.ToObject(L, 1);
				Transform parent = (Transform)ToLua.ToObject(L, 2);
				Component obj3 = ObjectPool.Spawn<Component>(prefab3, parent);
				ToLua.Push(L, obj3);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(Vector3)))
			{
				GameObject prefab4 = (GameObject)ToLua.ToObject(L, 1);
				Vector3 position = ToLua.ToVector3(L, 2);
				GameObject obj4 = ObjectPool.Spawn(prefab4, position);
				ToLua.Push(L, obj4);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(Transform)))
			{
				GameObject prefab5 = (GameObject)ToLua.ToObject(L, 1);
				Transform parent2 = (Transform)ToLua.ToObject(L, 2);
				GameObject obj5 = ObjectPool.Spawn(prefab5, parent2);
				ToLua.Push(L, obj5);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Component), typeof(Vector3)))
			{
				Component prefab6 = (Component)ToLua.ToObject(L, 1);
				Vector3 position2 = ToLua.ToVector3(L, 2);
				Component obj6 = ObjectPool.Spawn<Component>(prefab6, position2);
				ToLua.Push(L, obj6);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(Vector3), typeof(Quaternion)))
			{
				GameObject prefab7 = (GameObject)ToLua.ToObject(L, 1);
				Vector3 position3 = ToLua.ToVector3(L, 2);
				Quaternion rotation = ToLua.ToQuaternion(L, 3);
				GameObject obj7 = ObjectPool.Spawn(prefab7, position3, rotation);
				ToLua.Push(L, obj7);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(Transform), typeof(Vector3)))
			{
				GameObject prefab8 = (GameObject)ToLua.ToObject(L, 1);
				Transform parent3 = (Transform)ToLua.ToObject(L, 2);
				Vector3 position4 = ToLua.ToVector3(L, 3);
				GameObject obj8 = ObjectPool.Spawn(prefab8, parent3, position4);
				ToLua.Push(L, obj8);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Component), typeof(Transform), typeof(Vector3)))
			{
				Component prefab9 = (Component)ToLua.ToObject(L, 1);
				Transform parent4 = (Transform)ToLua.ToObject(L, 2);
				Vector3 position5 = ToLua.ToVector3(L, 3);
				Component obj9 = ObjectPool.Spawn<Component>(prefab9, parent4, position5);
				ToLua.Push(L, obj9);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Component), typeof(Vector3), typeof(Quaternion)))
			{
				Component prefab10 = (Component)ToLua.ToObject(L, 1);
				Vector3 position6 = ToLua.ToVector3(L, 2);
				Quaternion rotation2 = ToLua.ToQuaternion(L, 3);
				Component obj10 = ObjectPool.Spawn<Component>(prefab10, position6, rotation2);
				ToLua.Push(L, obj10);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Component), typeof(Transform), typeof(Vector3), typeof(Quaternion)))
			{
				Component prefab11 = (Component)ToLua.ToObject(L, 1);
				Transform parent5 = (Transform)ToLua.ToObject(L, 2);
				Vector3 position7 = ToLua.ToVector3(L, 3);
				Quaternion rotation3 = ToLua.ToQuaternion(L, 4);
				Component obj11 = ObjectPool.Spawn<Component>(prefab11, parent5, position7, rotation3);
				ToLua.Push(L, obj11);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(Transform), typeof(Vector3), typeof(Quaternion)))
			{
				GameObject prefab12 = (GameObject)ToLua.ToObject(L, 1);
				Transform parent6 = (Transform)ToLua.ToObject(L, 2);
				Vector3 position8 = ToLua.ToVector3(L, 3);
				Quaternion rotation4 = ToLua.ToQuaternion(L, 4);
				GameObject obj12 = ObjectPool.Spawn(prefab12, parent6, position8, rotation4);
				ToLua.Push(L, obj12);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: ThirdParty.ObjectPool.Spawn");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Recycle(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GameObject)))
			{
				GameObject obj = (GameObject)ToLua.ToObject(L, 1);
				ObjectPool.Recycle(obj);
				result = 0;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Component)))
			{
				Component obj2 = (Component)ToLua.ToObject(L, 1);
				ObjectPool.Recycle<Component>(obj2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: ThirdParty.ObjectPool.Recycle");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RecycleAll(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				ObjectPool.RecycleAll();
				result = 0;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GameObject)))
			{
				GameObject prefab = (GameObject)ToLua.ToObject(L, 1);
				ObjectPool.RecycleAll(prefab);
				result = 0;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Component)))
			{
				Component prefab2 = (Component)ToLua.ToObject(L, 1);
				ObjectPool.RecycleAll<Component>(prefab2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: ThirdParty.ObjectPool.RecycleAll");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsSpawned(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			bool value = ObjectPool.IsSpawned(obj);
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
	private static int CountPooled(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GameObject)))
			{
				GameObject prefab = (GameObject)ToLua.ToObject(L, 1);
				int n = ObjectPool.CountPooled(prefab);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Component)))
			{
				Component prefab2 = (Component)ToLua.ToObject(L, 1);
				int n2 = ObjectPool.CountPooled<Component>(prefab2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: ThirdParty.ObjectPool.CountPooled");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CountSpawned(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GameObject)))
			{
				GameObject prefab = (GameObject)ToLua.ToObject(L, 1);
				int n = ObjectPool.CountSpawned(prefab);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Component)))
			{
				Component prefab2 = (Component)ToLua.ToObject(L, 1);
				int n2 = ObjectPool.CountSpawned<Component>(prefab2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: ThirdParty.ObjectPool.CountSpawned");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CountAllPooled(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			int n = ObjectPool.CountAllPooled();
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPooled(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameObject prefab = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 2, typeof(List<GameObject>));
			bool appendList = LuaDLL.luaL_checkboolean(L, 3);
			List<GameObject> pooled = ObjectPool.GetPooled(prefab, list, appendList);
			ToLua.PushObject(L, pooled);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSpawned(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameObject prefab = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			List<GameObject> list = (List<GameObject>)ToLua.CheckObject(L, 2, typeof(List<GameObject>));
			bool appendList = LuaDLL.luaL_checkboolean(L, 3);
			List<GameObject> spawned = ObjectPool.GetSpawned(prefab, list, appendList);
			ToLua.PushObject(L, spawned);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DestroyPooled(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Component)))
			{
				Component prefab = (Component)ToLua.ToObject(L, 1);
				ObjectPool.DestroyPooled<Component>(prefab);
				result = 0;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GameObject)))
			{
				GameObject prefab2 = (GameObject)ToLua.ToObject(L, 1);
				ObjectPool.DestroyPooled(prefab2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: ThirdParty.ObjectPool.DestroyPooled");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DestroyAll(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Component)))
			{
				Component prefab = (Component)ToLua.ToObject(L, 1);
				ObjectPool.DestroyAll<Component>(prefab);
				result = 0;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(GameObject)))
			{
				GameObject prefab2 = (GameObject)ToLua.ToObject(L, 1);
				ObjectPool.DestroyAll(prefab2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: ThirdParty.ObjectPool.DestroyAll");
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
	private static int get_pooledObjNames(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ObjectPool objectPool = (ObjectPool)obj;
			Dictionary<string, GameObject> pooledObjNames = objectPool.pooledObjNames;
			ToLua.PushObject(L, pooledObjNames);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pooledObjNames on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_startupPoolMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ObjectPool objectPool = (ObjectPool)obj;
			ObjectPool.StartupPoolMode startupPoolMode = objectPool.startupPoolMode;
			ToLua.Push(L, startupPoolMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index startupPoolMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_startupPools(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ObjectPool objectPool = (ObjectPool)obj;
			ObjectPool.StartupPool[] startupPools = objectPool.startupPools;
			ToLua.Push(L, startupPools);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index startupPools on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_instance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, ObjectPool.instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pooledObjNames(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ObjectPool objectPool = (ObjectPool)obj;
			Dictionary<string, GameObject> pooledObjNames = (Dictionary<string, GameObject>)ToLua.CheckObject(L, 2, typeof(Dictionary<string, GameObject>));
			objectPool.pooledObjNames = pooledObjNames;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pooledObjNames on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_startupPoolMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ObjectPool objectPool = (ObjectPool)obj;
			ObjectPool.StartupPoolMode startupPoolMode = (ObjectPool.StartupPoolMode)((int)ToLua.CheckObject(L, 2, typeof(ObjectPool.StartupPoolMode)));
			objectPool.startupPoolMode = startupPoolMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index startupPoolMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_startupPools(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ObjectPool objectPool = (ObjectPool)obj;
			ObjectPool.StartupPool[] startupPools = ToLua.CheckObjectArray<ObjectPool.StartupPool>(L, 2);
			objectPool.startupPools = startupPools;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index startupPools on a nil value");
		}
		return result;
	}
}
