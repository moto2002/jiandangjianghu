using DG.Tweening;
using LuaInterface;
using System;

public class DG_Tweening_UpdateTypeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(UpdateType));
		L.RegVar("Normal", new LuaCSFunction(DG_Tweening_UpdateTypeWrap.get_Normal), null);
		L.RegVar("Late", new LuaCSFunction(DG_Tweening_UpdateTypeWrap.get_Late), null);
		L.RegVar("Fixed", new LuaCSFunction(DG_Tweening_UpdateTypeWrap.get_Fixed), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(DG_Tweening_UpdateTypeWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Normal(IntPtr L)
	{
		ToLua.Push(L, UpdateType.Normal);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Late(IntPtr L)
	{
		ToLua.Push(L, UpdateType.Late);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Fixed(IntPtr L)
	{
		ToLua.Push(L, UpdateType.Fixed);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		UpdateType updateType = (UpdateType)num;
		ToLua.Push(L, updateType);
		return 1;
	}
}
