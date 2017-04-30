using DG.Tweening;
using LuaInterface;
using System;

public class DG_Tweening_RotateModeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(RotateMode));
		L.RegVar("Fast", new LuaCSFunction(DG_Tweening_RotateModeWrap.get_Fast), null);
		L.RegVar("FastBeyond360", new LuaCSFunction(DG_Tweening_RotateModeWrap.get_FastBeyond360), null);
		L.RegVar("WorldAxisAdd", new LuaCSFunction(DG_Tweening_RotateModeWrap.get_WorldAxisAdd), null);
		L.RegVar("LocalAxisAdd", new LuaCSFunction(DG_Tweening_RotateModeWrap.get_LocalAxisAdd), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(DG_Tweening_RotateModeWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Fast(IntPtr L)
	{
		ToLua.Push(L, RotateMode.Fast);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_FastBeyond360(IntPtr L)
	{
		ToLua.Push(L, RotateMode.FastBeyond360);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_WorldAxisAdd(IntPtr L)
	{
		ToLua.Push(L, RotateMode.WorldAxisAdd);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LocalAxisAdd(IntPtr L)
	{
		ToLua.Push(L, RotateMode.LocalAxisAdd);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		RotateMode rotateMode = (RotateMode)num;
		ToLua.Push(L, rotateMode);
		return 1;
	}
}
