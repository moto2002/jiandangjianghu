using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_EndlessScrollerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(EndlessScroller), typeof(MonoBehaviour), null);
		L.RegFunction("__eq", new LuaCSFunction(LuaFramework_EndlessScrollerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("mCheckTime", new LuaCSFunction(LuaFramework_EndlessScrollerWrap.get_mCheckTime), new LuaCSFunction(LuaFramework_EndlessScrollerWrap.set_mCheckTime));
		L.RegVar("mDeltaScrollY", new LuaCSFunction(LuaFramework_EndlessScrollerWrap.get_mDeltaScrollY), new LuaCSFunction(LuaFramework_EndlessScrollerWrap.set_mDeltaScrollY));
		L.RegVar("totalHeight", new LuaCSFunction(LuaFramework_EndlessScrollerWrap.get_totalHeight), new LuaCSFunction(LuaFramework_EndlessScrollerWrap.set_totalHeight));
		L.RegVar("cellHeight", new LuaCSFunction(LuaFramework_EndlessScrollerWrap.get_cellHeight), new LuaCSFunction(LuaFramework_EndlessScrollerWrap.set_cellHeight));
		L.RegVar("windowHeight", new LuaCSFunction(LuaFramework_EndlessScrollerWrap.get_windowHeight), new LuaCSFunction(LuaFramework_EndlessScrollerWrap.set_windowHeight));
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
	private static int get_mCheckTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EndlessScroller endlessScroller = (EndlessScroller)obj;
			float mCheckTime = endlessScroller.mCheckTime;
			LuaDLL.lua_pushnumber(L, (double)mCheckTime);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mCheckTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mDeltaScrollY(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EndlessScroller endlessScroller = (EndlessScroller)obj;
			float mDeltaScrollY = endlessScroller.mDeltaScrollY;
			LuaDLL.lua_pushnumber(L, (double)mDeltaScrollY);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mDeltaScrollY on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_totalHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EndlessScroller endlessScroller = (EndlessScroller)obj;
			float totalHeight = endlessScroller.totalHeight;
			LuaDLL.lua_pushnumber(L, (double)totalHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index totalHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cellHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EndlessScroller endlessScroller = (EndlessScroller)obj;
			float cellHeight = endlessScroller.cellHeight;
			LuaDLL.lua_pushnumber(L, (double)cellHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cellHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_windowHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EndlessScroller endlessScroller = (EndlessScroller)obj;
			float windowHeight = endlessScroller.windowHeight;
			LuaDLL.lua_pushnumber(L, (double)windowHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index windowHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mCheckTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EndlessScroller endlessScroller = (EndlessScroller)obj;
			float mCheckTime = (float)LuaDLL.luaL_checknumber(L, 2);
			endlessScroller.mCheckTime = mCheckTime;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mCheckTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mDeltaScrollY(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EndlessScroller endlessScroller = (EndlessScroller)obj;
			float mDeltaScrollY = (float)LuaDLL.luaL_checknumber(L, 2);
			endlessScroller.mDeltaScrollY = mDeltaScrollY;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mDeltaScrollY on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_totalHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EndlessScroller endlessScroller = (EndlessScroller)obj;
			float totalHeight = (float)LuaDLL.luaL_checknumber(L, 2);
			endlessScroller.totalHeight = totalHeight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index totalHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cellHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EndlessScroller endlessScroller = (EndlessScroller)obj;
			float cellHeight = (float)LuaDLL.luaL_checknumber(L, 2);
			endlessScroller.cellHeight = cellHeight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cellHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_windowHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EndlessScroller endlessScroller = (EndlessScroller)obj;
			float windowHeight = (float)LuaDLL.luaL_checknumber(L, 2);
			endlessScroller.windowHeight = windowHeight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index windowHeight on a nil value");
		}
		return result;
	}
}
