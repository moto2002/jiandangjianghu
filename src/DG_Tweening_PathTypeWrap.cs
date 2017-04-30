using DG.Tweening;
using LuaInterface;
using System;

public class DG_Tweening_PathTypeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(PathType));
		L.RegVar("Linear", new LuaCSFunction(DG_Tweening_PathTypeWrap.get_Linear), null);
		L.RegVar("CatmullRom", new LuaCSFunction(DG_Tweening_PathTypeWrap.get_CatmullRom), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(DG_Tweening_PathTypeWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Linear(IntPtr L)
	{
		ToLua.Push(L, PathType.Linear);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_CatmullRom(IntPtr L)
	{
		ToLua.Push(L, PathType.CatmullRom);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		PathType pathType = (PathType)num;
		ToLua.Push(L, pathType);
		return 1;
	}
}
