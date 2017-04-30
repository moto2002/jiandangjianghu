using LuaInterface;
using System;
using UnityEngine;

public class AvatarBaseWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(AvatarBase), typeof(MonoBehaviour), null);
		L.RegFunction("SetAvatar", new LuaCSFunction(AvatarBaseWrap.SetAvatar));
		L.RegFunction("__eq", new LuaCSFunction(AvatarBaseWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("canClick", new LuaCSFunction(AvatarBaseWrap.get_canClick), new LuaCSFunction(AvatarBaseWrap.set_canClick));
		L.RegVar("canRotate", new LuaCSFunction(AvatarBaseWrap.get_canRotate), new LuaCSFunction(AvatarBaseWrap.set_canRotate));
		L.RegVar("clickAction", new LuaCSFunction(AvatarBaseWrap.get_clickAction), new LuaCSFunction(AvatarBaseWrap.set_clickAction));
		L.RegVar("showAction", new LuaCSFunction(AvatarBaseWrap.get_showAction), new LuaCSFunction(AvatarBaseWrap.set_showAction));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetAvatar(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			AvatarBase avatarBase = (AvatarBase)ToLua.CheckObject(L, 1, typeof(AvatarBase));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			bool click = LuaDLL.luaL_checkboolean(L, 3);
			bool rotate = LuaDLL.luaL_checkboolean(L, 4);
			avatarBase.SetAvatar(go, click, rotate);
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
	private static int get_canClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AvatarBase avatarBase = (AvatarBase)obj;
			bool canClick = avatarBase.canClick;
			LuaDLL.lua_pushboolean(L, canClick);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_canRotate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AvatarBase avatarBase = (AvatarBase)obj;
			bool canRotate = avatarBase.canRotate;
			LuaDLL.lua_pushboolean(L, canRotate);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canRotate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clickAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AvatarBase avatarBase = (AvatarBase)obj;
			int clickAction = avatarBase.clickAction;
			LuaDLL.lua_pushinteger(L, clickAction);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clickAction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_showAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AvatarBase avatarBase = (AvatarBase)obj;
			int showAction = avatarBase.showAction;
			LuaDLL.lua_pushinteger(L, showAction);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index showAction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_canClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AvatarBase avatarBase = (AvatarBase)obj;
			bool canClick = LuaDLL.luaL_checkboolean(L, 2);
			avatarBase.canClick = canClick;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_canRotate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AvatarBase avatarBase = (AvatarBase)obj;
			bool canRotate = LuaDLL.luaL_checkboolean(L, 2);
			avatarBase.canRotate = canRotate;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canRotate on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clickAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AvatarBase avatarBase = (AvatarBase)obj;
			int clickAction = (int)LuaDLL.luaL_checknumber(L, 2);
			avatarBase.clickAction = clickAction;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clickAction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_showAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			AvatarBase avatarBase = (AvatarBase)obj;
			int showAction = (int)LuaDLL.luaL_checknumber(L, 2);
			avatarBase.showAction = showAction;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index showAction on a nil value");
		}
		return result;
	}
}
