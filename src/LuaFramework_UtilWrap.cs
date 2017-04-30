using LuaFramework;
using LuaInterface;
using System;
using System.Collections;
using UnityEngine;

public class LuaFramework_UtilWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Util), typeof(object), null);
		L.RegFunction("Int", new LuaCSFunction(LuaFramework_UtilWrap.Int));
		L.RegFunction("Float", new LuaCSFunction(LuaFramework_UtilWrap.Float));
		L.RegFunction("Long", new LuaCSFunction(LuaFramework_UtilWrap.Long));
		L.RegFunction("Random", new LuaCSFunction(LuaFramework_UtilWrap.Random));
		L.RegFunction("Uid", new LuaCSFunction(LuaFramework_UtilWrap.Uid));
		L.RegFunction("GetTime", new LuaCSFunction(LuaFramework_UtilWrap.GetTime));
		L.RegFunction("SetWrapLabel", new LuaCSFunction(LuaFramework_UtilWrap.SetWrapLabel));
		L.RegFunction("Child", new LuaCSFunction(LuaFramework_UtilWrap.Child));
		L.RegFunction("Peer", new LuaCSFunction(LuaFramework_UtilWrap.Peer));
		L.RegFunction("md5", new LuaCSFunction(LuaFramework_UtilWrap.md5));
		L.RegFunction("md5file", new LuaCSFunction(LuaFramework_UtilWrap.md5file));
		L.RegFunction("ClearChild", new LuaCSFunction(LuaFramework_UtilWrap.ClearChild));
		L.RegFunction("ClearMemory", new LuaCSFunction(LuaFramework_UtilWrap.ClearMemory));
		L.RegFunction("AppContentPath", new LuaCSFunction(LuaFramework_UtilWrap.AppContentPath));
		L.RegFunction("AddClick", new LuaCSFunction(LuaFramework_UtilWrap.AddClick));
		L.RegFunction("Log", new LuaCSFunction(LuaFramework_UtilWrap.Log));
		L.RegFunction("LogWarning", new LuaCSFunction(LuaFramework_UtilWrap.LogWarning));
		L.RegFunction("LogError", new LuaCSFunction(LuaFramework_UtilWrap.LogError));
		L.RegFunction("AddComponent", new LuaCSFunction(LuaFramework_UtilWrap.AddComponent));
		L.RegFunction("LoadPrefab", new LuaCSFunction(LuaFramework_UtilWrap.LoadPrefab));
		L.RegFunction("LoadBucket", new LuaCSFunction(LuaFramework_UtilWrap.LoadBucket));
		L.RegFunction("LoadPrefabAsync", new LuaCSFunction(LuaFramework_UtilWrap.LoadPrefabAsync));
		L.RegFunction("loadAtlas", new LuaCSFunction(LuaFramework_UtilWrap.loadAtlas));
		L.RegFunction("LoadAudioClipAsync", new LuaCSFunction(LuaFramework_UtilWrap.LoadAudioClipAsync));
		L.RegFunction("LoadBGMAudioAsync", new LuaCSFunction(LuaFramework_UtilWrap.LoadBGMAudioAsync));
		L.RegFunction("CallMethod", new LuaCSFunction(LuaFramework_UtilWrap.CallMethod));
		L.RegFunction("CheckEnvironment", new LuaCSFunction(LuaFramework_UtilWrap.CheckEnvironment));
		L.RegFunction("LoadScene", new LuaCSFunction(LuaFramework_UtilWrap.LoadScene));
		L.RegFunction("LoadSceneViaPreloading", new LuaCSFunction(LuaFramework_UtilWrap.LoadSceneViaPreloading));
		L.RegFunction("OnSceneLoaded", new LuaCSFunction(LuaFramework_UtilWrap.OnSceneLoaded));
		L.RegFunction("GetDeviceIdentifierString", new LuaCSFunction(LuaFramework_UtilWrap.GetDeviceIdentifierString));
		L.RegFunction("SetUILabelFont", new LuaCSFunction(LuaFramework_UtilWrap.SetUILabelFont));
		L.RegFunction("SetUISprite", new LuaCSFunction(LuaFramework_UtilWrap.SetUISprite));
		L.RegFunction("WorldToUI", new LuaCSFunction(LuaFramework_UtilWrap.WorldToUI));
		L.RegFunction("GetEntityType", new LuaCSFunction(LuaFramework_UtilWrap.GetEntityType));
		L.RegFunction("Convert2RealPosition", new LuaCSFunction(LuaFramework_UtilWrap.Convert2RealPosition));
		L.RegFunction("Convert2MapPosition", new LuaCSFunction(LuaFramework_UtilWrap.Convert2MapPosition));
		L.RegFunction("OpenConsole", new LuaCSFunction(LuaFramework_UtilWrap.OpenConsole));
		L.RegFunction("CalculateGridDirection", new LuaCSFunction(LuaFramework_UtilWrap.CalculateGridDirection));
		L.RegFunction("Find", new LuaCSFunction(LuaFramework_UtilWrap.Find));
		L.RegFunction("GetAllChildren", new LuaCSFunction(LuaFramework_UtilWrap.GetAllChildren));
		L.RegFunction("SetRenderQueue", new LuaCSFunction(LuaFramework_UtilWrap.SetRenderQueue));
		L.RegFunction("ChangeToClipShader", new LuaCSFunction(LuaFramework_UtilWrap.ChangeToClipShader));
		L.RegFunction("ChangeToClipShader1", new LuaCSFunction(LuaFramework_UtilWrap.ChangeToClipShader1));
		L.RegFunction("IsDebugBuild", new LuaCSFunction(LuaFramework_UtilWrap.IsDebugBuild));
		L.RegFunction("GetCurrentSceneName", new LuaCSFunction(LuaFramework_UtilWrap.GetCurrentSceneName));
		L.RegFunction("CaptureCamera", new LuaCSFunction(LuaFramework_UtilWrap.CaptureCamera));
		L.RegFunction("AddAutoRecycleParticle", new LuaCSFunction(LuaFramework_UtilWrap.AddAutoRecycleParticle));
		L.RegFunction("SetGameObjectLayer", new LuaCSFunction(LuaFramework_UtilWrap.SetGameObjectLayer));
		L.RegFunction("ResetShader", new LuaCSFunction(LuaFramework_UtilWrap.ResetShader));
		L.RegFunction("New", new LuaCSFunction(LuaFramework_UtilWrap._CreateLuaFramework_Util));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("DataPath", new LuaCSFunction(LuaFramework_UtilWrap.get_DataPath), null);
		L.RegVar("LuaPath", new LuaCSFunction(LuaFramework_UtilWrap.get_LuaPath), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateLuaFramework_Util(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Util o = new Util();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: LuaFramework.Util.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Int(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object o = ToLua.ToVarObject(L, 1);
			int n = Util.Int(o);
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
	private static int Float(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object o = ToLua.ToVarObject(L, 1);
			float num = Util.Float(o);
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Long(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object o = ToLua.ToVarObject(L, 1);
			long n = Util.Long(o);
			LuaDLL.tolua_pushint64(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Random(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(float), typeof(float)))
			{
				float min = (float)LuaDLL.lua_tonumber(L, 1);
				float max = (float)LuaDLL.lua_tonumber(L, 2);
				float num2 = Util.Random(min, max);
				LuaDLL.lua_pushnumber(L, (double)num2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int)))
			{
				int min2 = (int)LuaDLL.lua_tonumber(L, 1);
				int max2 = (int)LuaDLL.lua_tonumber(L, 2);
				int n = Util.Random(min2, max2);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.Util.Random");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Uid(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string uid = ToLua.CheckString(L, 1);
			string str = Util.Uid(uid);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTime(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			long time = Util.GetTime();
			LuaDLL.tolua_pushint64(L, time);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetWrapLabel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UILabel lab = (UILabel)ToLua.CheckUnityObject(L, 1, typeof(UILabel));
			string text = ToLua.CheckString(L, 2);
			int height = (int)LuaDLL.luaL_checknumber(L, 3);
			Util.SetWrapLabel(lab, text, height);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Child(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(string)))
			{
				Transform go = (Transform)ToLua.ToObject(L, 1);
				string subnode = ToLua.ToString(L, 2);
				GameObject obj = Util.Child(go, subnode);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string)))
			{
				GameObject go2 = (GameObject)ToLua.ToObject(L, 1);
				string subnode2 = ToLua.ToString(L, 2);
				GameObject obj2 = Util.Child(go2, subnode2);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.Util.Child");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Peer(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Transform), typeof(string)))
			{
				Transform go = (Transform)ToLua.ToObject(L, 1);
				string subnode = ToLua.ToString(L, 2);
				GameObject obj = Util.Peer(go, subnode);
				ToLua.Push(L, obj);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(GameObject), typeof(string)))
			{
				GameObject go2 = (GameObject)ToLua.ToObject(L, 1);
				string subnode2 = ToLua.ToString(L, 2);
				GameObject obj2 = Util.Peer(go2, subnode2);
				ToLua.Push(L, obj2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.Util.Peer");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int md5(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string source = ToLua.CheckString(L, 1);
			string str = Util.md5(source);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int md5file(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string file = ToLua.CheckString(L, 1);
			string str = Util.md5file(file);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearChild(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Transform go = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			Util.ClearChild(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearMemory(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			Util.ClearMemory();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AppContentPath(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			string str = Util.AppContentPath();
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			object luafuc = ToLua.ToVarObject(L, 2);
			Util.AddClick(go, luafuc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Log(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string str = ToLua.CheckString(L, 1);
			Util.Log(str);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LogWarning(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string str = ToLua.CheckString(L, 1);
			Util.LogWarning(str);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LogError(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string str = ToLua.CheckString(L, 1);
			Util.LogError(str);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddComponent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			string assembly = ToLua.CheckString(L, 2);
			string classname = ToLua.CheckString(L, 3);
			Component obj = Util.AddComponent(go, assembly, classname);
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
	private static int LoadPrefab(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string name = ToLua.CheckString(L, 1);
			GameObject obj = Util.LoadPrefab(name);
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
	private static int LoadBucket(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Transform parent = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			GameObject obj = Util.LoadBucket(parent);
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
	private static int LoadPrefabAsync(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string name = ToLua.CheckString(L, 1);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<GameObject, string> callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Action<GameObject, string>)ToLua.CheckObject(L, 2, typeof(Action<GameObject, string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				callback = (DelegateFactory.CreateDelegate(typeof(Action<GameObject, string>), func) as Action<GameObject, string>);
			}
			IEnumerator iter = Util.LoadPrefabAsync(name, callback);
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
	private static int loadAtlas(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string name = ToLua.CheckString(L, 1);
			UIAtlas obj = Util.loadAtlas(name);
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
	private static int LoadAudioClipAsync(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			string name = ToLua.CheckString(L, 2);
			string extension = ToLua.CheckString(L, 3);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 4);
			Action<AudioClip, string> callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Action<AudioClip, string>)ToLua.CheckObject(L, 4, typeof(Action<AudioClip, string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 4);
				callback = (DelegateFactory.CreateDelegate(typeof(Action<AudioClip, string>), func) as Action<AudioClip, string>);
			}
			IEnumerator iter = Util.LoadAudioClipAsync(go, name, extension, callback);
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
	private static int LoadBGMAudioAsync(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			string name = ToLua.CheckString(L, 2);
			string extension = ToLua.CheckString(L, 3);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 4);
			Action<AudioClip, string> callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Action<AudioClip, string>)ToLua.CheckObject(L, 4, typeof(Action<AudioClip, string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 4);
				callback = (DelegateFactory.CreateDelegate(typeof(Action<AudioClip, string>), func) as Action<AudioClip, string>);
			}
			IEnumerator iter = Util.LoadBGMAudioAsync(go, name, extension, callback);
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
	private static int CallMethod(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			string module = ToLua.CheckString(L, 1);
			string func = ToLua.CheckString(L, 2);
			object[] args = ToLua.ToParamsObject(L, 3, num - 2);
			object[] array = Util.CallMethod(module, func, args);
			ToLua.Push(L, array);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckEnvironment(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			bool value = Util.CheckEnvironment();
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
	private static int LoadScene(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string name = ToLua.CheckString(L, 1);
			Util.LoadScene(name);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadSceneViaPreloading(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string name = ToLua.CheckString(L, 1);
			Util.LoadSceneViaPreloading(name);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnSceneLoaded(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			Util.OnSceneLoaded();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDeviceIdentifierString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			string deviceIdentifierString = Util.GetDeviceIdentifierString();
			LuaDLL.lua_pushstring(L, deviceIdentifierString);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetUILabelFont(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			UILabel label = (UILabel)ToLua.CheckUnityObject(L, 1, typeof(UILabel));
			string fontStr = ToLua.CheckString(L, 2);
			int fontsize = (int)LuaDLL.luaL_checknumber(L, 3);
			int overflow = (int)LuaDLL.luaL_checknumber(L, 4);
			Util.SetUILabelFont(label, fontStr, fontsize, overflow);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetUISprite(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UISprite spr = (UISprite)ToLua.CheckUnityObject(L, 1, typeof(UISprite));
			string atlas = ToLua.CheckString(L, 2);
			string name = ToLua.CheckString(L, 3);
			Util.SetUISprite(spr, atlas, name);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WorldToUI(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Vector3 point = ToLua.ToVector3(L, 1);
			Vector3 v = Util.WorldToUI(point);
			ToLua.Push(L, v);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetEntityType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SceneEntity obj = (SceneEntity)ToLua.CheckUnityObject(L, 1, typeof(SceneEntity));
			int entityType = Util.GetEntityType(obj);
			LuaDLL.lua_pushinteger(L, entityType);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Convert2RealPosition(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int)))
			{
				int x = (int)LuaDLL.lua_tonumber(L, 1);
				int z = (int)LuaDLL.lua_tonumber(L, 2);
				Vector3 v = Util.Convert2RealPosition(x, z);
				ToLua.Push(L, v);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(float), typeof(int)))
			{
				int x2 = (int)LuaDLL.lua_tonumber(L, 1);
				float height = (float)LuaDLL.lua_tonumber(L, 2);
				int z2 = (int)LuaDLL.lua_tonumber(L, 3);
				Vector3 v2 = Util.Convert2RealPosition(x2, height, z2);
				ToLua.Push(L, v2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.Util.Convert2RealPosition");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Convert2MapPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			float x = (float)LuaDLL.luaL_checknumber(L, 1);
			float z = (float)LuaDLL.luaL_checknumber(L, 2);
			float y = (float)LuaDLL.luaL_checknumber(L, 3);
			Vector3 v = Util.Convert2MapPosition(x, z, y);
			ToLua.Push(L, v);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OpenConsole(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			Util.OpenConsole();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateGridDirection(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Vector3 dir = ToLua.ToVector3(L, 1);
			int n = Util.CalculateGridDirection(dir);
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
	private static int Find(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform parent = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			string childname = ToLua.CheckString(L, 2);
			Transform obj = Util.Find(parent, childname);
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
	private static int GetAllChildren(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Transform root = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			Transform[] allChildren = Util.GetAllChildren(root);
			ToLua.Push(L, allChildren);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetRenderQueue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Transform parent = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			int renderQ = (int)LuaDLL.luaL_checknumber(L, 2);
			float scaleFactor = (float)LuaDLL.luaL_checknumber(L, 3);
			Util.SetRenderQueue(parent, renderQ, scaleFactor);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangeToClipShader(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Transform trans = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			Util.ChangeToClipShader(trans);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangeToClipShader1(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Transform trans = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			Util.ChangeToClipShader1(trans);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsDebugBuild(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			bool value = Util.IsDebugBuild();
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
	private static int GetCurrentSceneName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			string currentSceneName = Util.GetCurrentSceneName();
			LuaDLL.lua_pushstring(L, currentSceneName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CaptureCamera(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Camera camera = (Camera)ToLua.CheckUnityObject(L, 1, typeof(Camera));
			Rect rect = (Rect)ToLua.CheckObject(L, 2, typeof(Rect));
			Texture2D obj = Util.CaptureCamera(camera, rect);
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
	private static int AddAutoRecycleParticle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform parent = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			string particalPath = ToLua.CheckString(L, 2);
			Util.AddAutoRecycleParticle(parent, particalPath);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetGameObjectLayer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform trans = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			int layer = (int)LuaDLL.luaL_checknumber(L, 2);
			Util.SetGameObjectLayer(trans, layer);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetShader(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			Util.ResetShader(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_DataPath(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Util.DataPath);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LuaPath(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, Util.LuaPath);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
