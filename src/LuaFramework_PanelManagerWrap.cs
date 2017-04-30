using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_PanelManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(PanelManager), typeof(Manager), null);
		L.RegFunction("CreatePanel", new LuaCSFunction(LuaFramework_PanelManagerWrap.CreatePanel));
		L.RegFunction("ClosePanel", new LuaCSFunction(LuaFramework_PanelManagerWrap.ClosePanel));
		L.RegFunction("GetNotifyTrans", new LuaCSFunction(LuaFramework_PanelManagerWrap.GetNotifyTrans));
		L.RegFunction("Clear", new LuaCSFunction(LuaFramework_PanelManagerWrap.Clear));
		L.RegFunction("ModifyDontDestroyPanel", new LuaCSFunction(LuaFramework_PanelManagerWrap.ModifyDontDestroyPanel));
		L.RegFunction("CloseAllPopedPanels", new LuaCSFunction(LuaFramework_PanelManagerWrap.CloseAllPopedPanels));
		L.RegFunction("IsPanelVisible", new LuaCSFunction(LuaFramework_PanelManagerWrap.IsPanelVisible));
		L.RegFunction("__eq", new LuaCSFunction(LuaFramework_PanelManagerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Parent", new LuaCSFunction(LuaFramework_PanelManagerWrap.get_Parent), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreatePanel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 9);
			PanelManager panelManager = (PanelManager)ToLua.CheckObject(L, 1, typeof(PanelManager));
			string name = ToLua.CheckString(L, 2);
			LuaFunction func = ToLua.CheckLuaFunction(L, 3);
			bool closeMainCamera = LuaDLL.luaL_checkboolean(L, 4);
			float x = (float)LuaDLL.luaL_checknumber(L, 5);
			float y = (float)LuaDLL.luaL_checknumber(L, 6);
			float z = (float)LuaDLL.luaL_checknumber(L, 7);
			bool dontDestroy = LuaDLL.luaL_checkboolean(L, 8);
			bool hideWhenClose = LuaDLL.luaL_checkboolean(L, 9);
			panelManager.CreatePanel(name, func, closeMainCamera, x, y, z, dontDestroy, hideWhenClose);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClosePanel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PanelManager panelManager = (PanelManager)ToLua.CheckObject(L, 1, typeof(PanelManager));
			string name = ToLua.CheckString(L, 2);
			panelManager.ClosePanel(name);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetNotifyTrans(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PanelManager panelManager = (PanelManager)ToLua.CheckObject(L, 1, typeof(PanelManager));
			Transform notifyTrans = panelManager.GetNotifyTrans();
			ToLua.Push(L, notifyTrans);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PanelManager panelManager = (PanelManager)ToLua.CheckObject(L, 1, typeof(PanelManager));
			panelManager.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ModifyDontDestroyPanel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			PanelManager.ModifyDontDestroyPanel();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CloseAllPopedPanels(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			PanelManager panelManager = (PanelManager)ToLua.CheckObject(L, 1, typeof(PanelManager));
			panelManager.CloseAllPopedPanels();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsPanelVisible(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PanelManager panelManager = (PanelManager)ToLua.CheckObject(L, 1, typeof(PanelManager));
			string name = ToLua.CheckString(L, 2);
			bool value = panelManager.IsPanelVisible(name);
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
	private static int get_Parent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			PanelManager panelManager = (PanelManager)obj;
			Transform parent = panelManager.Parent;
			ToLua.Push(L, parent);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Parent on a nil value");
		}
		return result;
	}
}
