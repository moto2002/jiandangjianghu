using LuaInterface;
using System;
using UnityEngine;

public class UIWrapContentWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIWrapContent), typeof(MonoBehaviour), null);
		L.RegFunction("SortBasedOnScrollMovement", new LuaCSFunction(UIWrapContentWrap.SortBasedOnScrollMovement));
		L.RegFunction("SortAlphabetically", new LuaCSFunction(UIWrapContentWrap.SortAlphabetically));
		L.RegFunction("WrapContent", new LuaCSFunction(UIWrapContentWrap.WrapContent));
		L.RegFunction("__eq", new LuaCSFunction(UIWrapContentWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("itemSize", new LuaCSFunction(UIWrapContentWrap.get_itemSize), new LuaCSFunction(UIWrapContentWrap.set_itemSize));
		L.RegVar("cullContent", new LuaCSFunction(UIWrapContentWrap.get_cullContent), new LuaCSFunction(UIWrapContentWrap.set_cullContent));
		L.RegVar("minIndex", new LuaCSFunction(UIWrapContentWrap.get_minIndex), new LuaCSFunction(UIWrapContentWrap.set_minIndex));
		L.RegVar("maxIndex", new LuaCSFunction(UIWrapContentWrap.get_maxIndex), new LuaCSFunction(UIWrapContentWrap.set_maxIndex));
		L.RegVar("onInitializeItem", new LuaCSFunction(UIWrapContentWrap.get_onInitializeItem), new LuaCSFunction(UIWrapContentWrap.set_onInitializeItem));
		L.RegFunction("OnInitializeItem", new LuaCSFunction(UIWrapContentWrap.UIWrapContent_OnInitializeItem));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SortBasedOnScrollMovement(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIWrapContent uIWrapContent = (UIWrapContent)ToLua.CheckObject(L, 1, typeof(UIWrapContent));
			uIWrapContent.SortBasedOnScrollMovement();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SortAlphabetically(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIWrapContent uIWrapContent = (UIWrapContent)ToLua.CheckObject(L, 1, typeof(UIWrapContent));
			uIWrapContent.SortAlphabetically();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WrapContent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIWrapContent uIWrapContent = (UIWrapContent)ToLua.CheckObject(L, 1, typeof(UIWrapContent));
			uIWrapContent.WrapContent();
			result = 0;
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
	private static int get_itemSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWrapContent uIWrapContent = (UIWrapContent)obj;
			int itemSize = uIWrapContent.itemSize;
			LuaDLL.lua_pushinteger(L, itemSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index itemSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cullContent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWrapContent uIWrapContent = (UIWrapContent)obj;
			bool cullContent = uIWrapContent.cullContent;
			LuaDLL.lua_pushboolean(L, cullContent);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cullContent on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minIndex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWrapContent uIWrapContent = (UIWrapContent)obj;
			int minIndex = uIWrapContent.minIndex;
			LuaDLL.lua_pushinteger(L, minIndex);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minIndex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxIndex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWrapContent uIWrapContent = (UIWrapContent)obj;
			int maxIndex = uIWrapContent.maxIndex;
			LuaDLL.lua_pushinteger(L, maxIndex);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxIndex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onInitializeItem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWrapContent uIWrapContent = (UIWrapContent)obj;
			UIWrapContent.OnInitializeItem onInitializeItem = uIWrapContent.onInitializeItem;
			ToLua.Push(L, onInitializeItem);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onInitializeItem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_itemSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWrapContent uIWrapContent = (UIWrapContent)obj;
			int itemSize = (int)LuaDLL.luaL_checknumber(L, 2);
			uIWrapContent.itemSize = itemSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index itemSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cullContent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWrapContent uIWrapContent = (UIWrapContent)obj;
			bool cullContent = LuaDLL.luaL_checkboolean(L, 2);
			uIWrapContent.cullContent = cullContent;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cullContent on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_minIndex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWrapContent uIWrapContent = (UIWrapContent)obj;
			int minIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			uIWrapContent.minIndex = minIndex;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minIndex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxIndex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWrapContent uIWrapContent = (UIWrapContent)obj;
			int maxIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			uIWrapContent.maxIndex = maxIndex;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxIndex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onInitializeItem(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIWrapContent uIWrapContent = (UIWrapContent)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			UIWrapContent.OnInitializeItem onInitializeItem;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onInitializeItem = (UIWrapContent.OnInitializeItem)ToLua.CheckObject(L, 2, typeof(UIWrapContent.OnInitializeItem));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onInitializeItem = (DelegateFactory.CreateDelegate(typeof(UIWrapContent.OnInitializeItem), func) as UIWrapContent.OnInitializeItem);
			}
			uIWrapContent.onInitializeItem = onInitializeItem;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onInitializeItem on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIWrapContent_OnInitializeItem(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIWrapContent.OnInitializeItem), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIWrapContent.OnInitializeItem), func, self);
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