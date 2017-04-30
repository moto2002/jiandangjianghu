using DG.Tweening;
using LuaInterface;
using System;

public class DG_Tweening_PathModeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(PathMode));
		L.RegVar("Ignore", new LuaCSFunction(DG_Tweening_PathModeWrap.get_Ignore), null);
		L.RegVar("Full3D", new LuaCSFunction(DG_Tweening_PathModeWrap.get_Full3D), null);
		L.RegVar("TopDown2D", new LuaCSFunction(DG_Tweening_PathModeWrap.get_TopDown2D), null);
		L.RegVar("Sidescroller2D", new LuaCSFunction(DG_Tweening_PathModeWrap.get_Sidescroller2D), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(DG_Tweening_PathModeWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Ignore(IntPtr L)
	{
		ToLua.Push(L, PathMode.Ignore);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Full3D(IntPtr L)
	{
		ToLua.Push(L, PathMode.Full3D);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_TopDown2D(IntPtr L)
	{
		ToLua.Push(L, PathMode.TopDown2D);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Sidescroller2D(IntPtr L)
	{
		ToLua.Push(L, PathMode.Sidescroller2D);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		PathMode pathMode = (PathMode)num;
		ToLua.Push(L, pathMode);
		return 1;
	}
}
