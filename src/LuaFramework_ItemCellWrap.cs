using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_ItemCellWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ItemCell), typeof(MonoBehaviour), null);
		L.RegFunction("IsPointOverItemCell", new LuaCSFunction(LuaFramework_ItemCellWrap.IsPointOverItemCell));
		L.RegFunction("__eq", new LuaCSFunction(LuaFramework_ItemCellWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("mParentTrans", new LuaCSFunction(LuaFramework_ItemCellWrap.get_mParentTrans), new LuaCSFunction(LuaFramework_ItemCellWrap.set_mParentTrans));
		L.RegVar("index", new LuaCSFunction(LuaFramework_ItemCellWrap.get_index), new LuaCSFunction(LuaFramework_ItemCellWrap.set_index));
		L.RegVar("itemId", new LuaCSFunction(LuaFramework_ItemCellWrap.get_itemId), new LuaCSFunction(LuaFramework_ItemCellWrap.set_itemId));
		L.RegVar("isChange", new LuaCSFunction(LuaFramework_ItemCellWrap.get_isChange), new LuaCSFunction(LuaFramework_ItemCellWrap.set_isChange));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsPointOverItemCell(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ItemCell itemCell = (ItemCell)ToLua.CheckObject(L, 1, typeof(ItemCell));
			Vector3 point = ToLua.ToVector3(L, 2);
			bool value = itemCell.IsPointOverItemCell(point);
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
	private static int get_mParentTrans(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ItemCell itemCell = (ItemCell)obj;
			Transform mParentTrans = itemCell.mParentTrans;
			ToLua.Push(L, mParentTrans);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mParentTrans on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_index(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, ItemCell.index);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_itemId(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ItemCell itemCell = (ItemCell)obj;
			int itemId = itemCell.itemId;
			LuaDLL.lua_pushinteger(L, itemId);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index itemId on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ItemCell itemCell = (ItemCell)obj;
			bool isChange = itemCell.isChange;
			LuaDLL.lua_pushboolean(L, isChange);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mParentTrans(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ItemCell itemCell = (ItemCell)obj;
			Transform mParentTrans = (Transform)ToLua.CheckUnityObject(L, 2, typeof(Transform));
			itemCell.mParentTrans = mParentTrans;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mParentTrans on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_index(IntPtr L)
	{
		int result;
		try
		{
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			ItemCell.index = index;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_itemId(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ItemCell itemCell = (ItemCell)obj;
			int itemId = (int)LuaDLL.luaL_checknumber(L, 2);
			itemCell.itemId = itemId;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index itemId on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ItemCell itemCell = (ItemCell)obj;
			bool isChange = LuaDLL.luaL_checkboolean(L, 2);
			itemCell.isChange = isChange;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isChange on a nil value");
		}
		return result;
	}
}
