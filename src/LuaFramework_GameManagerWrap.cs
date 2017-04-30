using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_GameManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GameManager), typeof(Manager), null);
		L.RegFunction("InitGui", new LuaCSFunction(LuaFramework_GameManagerWrap.InitGui));
		L.RegFunction("CheckExtractResource", new LuaCSFunction(LuaFramework_GameManagerWrap.CheckExtractResource));
		L.RegFunction("BeginUpdate", new LuaCSFunction(LuaFramework_GameManagerWrap.BeginUpdate));
		L.RegFunction("OnResourceInited", new LuaCSFunction(LuaFramework_GameManagerWrap.OnResourceInited));
		L.RegFunction("RegisterHandlers", new LuaCSFunction(LuaFramework_GameManagerWrap.RegisterHandlers));
		L.RegFunction("GetSceneFileList", new LuaCSFunction(LuaFramework_GameManagerWrap.GetSceneFileList));
		L.RegFunction("StartDownloadPackFiles", new LuaCSFunction(LuaFramework_GameManagerWrap.StartDownloadPackFiles));
		L.RegFunction("GetDownloadPackProgress", new LuaCSFunction(LuaFramework_GameManagerWrap.GetDownloadPackProgress));
		L.RegFunction("GetTotalDownloadedPackSize", new LuaCSFunction(LuaFramework_GameManagerWrap.GetTotalDownloadedPackSize));
		L.RegFunction("AddDownloadPackProgressListener", new LuaCSFunction(LuaFramework_GameManagerWrap.AddDownloadPackProgressListener));
		L.RegFunction("RemoveDownloadPackProgressListener", new LuaCSFunction(LuaFramework_GameManagerWrap.RemoveDownloadPackProgressListener));
		L.RegFunction("IsStopped", new LuaCSFunction(LuaFramework_GameManagerWrap.IsStopped));
		L.RegFunction("__eq", new LuaCSFunction(LuaFramework_GameManagerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("progressChanged", new LuaCSFunction(LuaFramework_GameManagerWrap.get_progressChanged), new LuaCSFunction(LuaFramework_GameManagerWrap.set_progressChanged));
		L.RegVar("finishedBackgroundDownloading", new LuaCSFunction(LuaFramework_GameManagerWrap.get_finishedBackgroundDownloading), new LuaCSFunction(LuaFramework_GameManagerWrap.set_finishedBackgroundDownloading));
		L.RegVar("localVersion", new LuaCSFunction(LuaFramework_GameManagerWrap.get_localVersion), new LuaCSFunction(LuaFramework_GameManagerWrap.set_localVersion));
		L.RegVar("packVersion", new LuaCSFunction(LuaFramework_GameManagerWrap.get_packVersion), new LuaCSFunction(LuaFramework_GameManagerWrap.set_packVersion));
		L.RegVar("pauseDownloading", new LuaCSFunction(LuaFramework_GameManagerWrap.get_pauseDownloading), new LuaCSFunction(LuaFramework_GameManagerWrap.set_pauseDownloading));
		L.RegFunction("DownloadPackProgressChanged", new LuaCSFunction(LuaFramework_GameManagerWrap.LuaFramework_GameManager_DownloadPackProgressChanged));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InitGui(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameManager gameManager = (GameManager)ToLua.CheckObject(L, 1, typeof(GameManager));
			gameManager.InitGui();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckExtractResource(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameManager gameManager = (GameManager)ToLua.CheckObject(L, 1, typeof(GameManager));
			gameManager.CheckExtractResource();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int BeginUpdate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameManager gameManager = (GameManager)ToLua.CheckObject(L, 1, typeof(GameManager));
			string version = ToLua.CheckString(L, 2);
			bool alwaysUpdate = LuaDLL.luaL_checkboolean(L, 3);
			gameManager.BeginUpdate(version, alwaysUpdate);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnResourceInited(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameManager gameManager = (GameManager)ToLua.CheckObject(L, 1, typeof(GameManager));
			gameManager.OnResourceInited();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RegisterHandlers(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameManager gameManager = (GameManager)ToLua.CheckObject(L, 1, typeof(GameManager));
			gameManager.RegisterHandlers();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSceneFileList(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameManager gameManager = (GameManager)ToLua.CheckObject(L, 1, typeof(GameManager));
			string[] sceneFileList = gameManager.GetSceneFileList();
			ToLua.Push(L, sceneFileList);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartDownloadPackFiles(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameManager gameManager = (GameManager)ToLua.CheckObject(L, 1, typeof(GameManager));
			gameManager.StartDownloadPackFiles();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetDownloadPackProgress(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameManager gameManager = (GameManager)ToLua.CheckObject(L, 1, typeof(GameManager));
			float downloadPackProgress = gameManager.GetDownloadPackProgress();
			LuaDLL.lua_pushnumber(L, (double)downloadPackProgress);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTotalDownloadedPackSize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameManager gameManager = (GameManager)ToLua.CheckObject(L, 1, typeof(GameManager));
			string totalDownloadedPackSize = gameManager.GetTotalDownloadedPackSize();
			LuaDLL.lua_pushstring(L, totalDownloadedPackSize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddDownloadPackProgressListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameManager gameManager = (GameManager)ToLua.CheckObject(L, 1, typeof(GameManager));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			GameManager.DownloadPackProgressChanged listener;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				listener = (GameManager.DownloadPackProgressChanged)ToLua.CheckObject(L, 2, typeof(GameManager.DownloadPackProgressChanged));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				listener = (DelegateFactory.CreateDelegate(typeof(GameManager.DownloadPackProgressChanged), func) as GameManager.DownloadPackProgressChanged);
			}
			gameManager.AddDownloadPackProgressListener(listener);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveDownloadPackProgressListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameManager gameManager = (GameManager)ToLua.CheckObject(L, 1, typeof(GameManager));
			gameManager.RemoveDownloadPackProgressListener();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsStopped(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameManager gameManager = (GameManager)ToLua.CheckObject(L, 1, typeof(GameManager));
			bool value = gameManager.IsStopped();
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
	private static int get_progressChanged(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameManager gameManager = (GameManager)obj;
			GameManager.DownloadPackProgressChanged progressChanged = gameManager.progressChanged;
			ToLua.Push(L, progressChanged);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index progressChanged on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_finishedBackgroundDownloading(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameManager gameManager = (GameManager)obj;
			bool finishedBackgroundDownloading = gameManager.finishedBackgroundDownloading;
			LuaDLL.lua_pushboolean(L, finishedBackgroundDownloading);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index finishedBackgroundDownloading on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localVersion(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, GameManager.localVersion);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_packVersion(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, GameManager.packVersion);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pauseDownloading(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameManager gameManager = (GameManager)obj;
			bool pauseDownloading = gameManager.pauseDownloading;
			LuaDLL.lua_pushboolean(L, pauseDownloading);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pauseDownloading on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_progressChanged(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameManager gameManager = (GameManager)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			GameManager.DownloadPackProgressChanged progressChanged;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				progressChanged = (GameManager.DownloadPackProgressChanged)ToLua.CheckObject(L, 2, typeof(GameManager.DownloadPackProgressChanged));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				progressChanged = (DelegateFactory.CreateDelegate(typeof(GameManager.DownloadPackProgressChanged), func) as GameManager.DownloadPackProgressChanged);
			}
			gameManager.progressChanged = progressChanged;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index progressChanged on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_finishedBackgroundDownloading(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameManager gameManager = (GameManager)obj;
			bool finishedBackgroundDownloading = LuaDLL.luaL_checkboolean(L, 2);
			gameManager.finishedBackgroundDownloading = finishedBackgroundDownloading;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index finishedBackgroundDownloading on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_localVersion(IntPtr L)
	{
		int result;
		try
		{
			GameVersion localVersion = (GameVersion)ToLua.CheckObject(L, 2, typeof(GameVersion));
			GameManager.localVersion = localVersion;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_packVersion(IntPtr L)
	{
		int result;
		try
		{
			GameVersion packVersion = (GameVersion)ToLua.CheckObject(L, 2, typeof(GameVersion));
			GameManager.packVersion = packVersion;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pauseDownloading(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			GameManager gameManager = (GameManager)obj;
			bool pauseDownloading = LuaDLL.luaL_checkboolean(L, 2);
			gameManager.pauseDownloading = pauseDownloading;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pauseDownloading on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaFramework_GameManager_DownloadPackProgressChanged(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(GameManager.DownloadPackProgressChanged), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(GameManager.DownloadPackProgressChanged), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
