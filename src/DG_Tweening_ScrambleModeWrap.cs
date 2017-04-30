using DG.Tweening;
using LuaInterface;
using System;

public class DG_Tweening_ScrambleModeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(ScrambleMode));
		L.RegVar("None", new LuaCSFunction(DG_Tweening_ScrambleModeWrap.get_None), null);
		L.RegVar("All", new LuaCSFunction(DG_Tweening_ScrambleModeWrap.get_All), null);
		L.RegVar("Uppercase", new LuaCSFunction(DG_Tweening_ScrambleModeWrap.get_Uppercase), null);
		L.RegVar("Lowercase", new LuaCSFunction(DG_Tweening_ScrambleModeWrap.get_Lowercase), null);
		L.RegVar("Numerals", new LuaCSFunction(DG_Tweening_ScrambleModeWrap.get_Numerals), null);
		L.RegVar("Custom", new LuaCSFunction(DG_Tweening_ScrambleModeWrap.get_Custom), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(DG_Tweening_ScrambleModeWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_None(IntPtr L)
	{
		ToLua.Push(L, ScrambleMode.None);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_All(IntPtr L)
	{
		ToLua.Push(L, ScrambleMode.All);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Uppercase(IntPtr L)
	{
		ToLua.Push(L, ScrambleMode.Uppercase);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Lowercase(IntPtr L)
	{
		ToLua.Push(L, ScrambleMode.Lowercase);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Numerals(IntPtr L)
	{
		ToLua.Push(L, ScrambleMode.Numerals);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Custom(IntPtr L)
	{
		ToLua.Push(L, ScrambleMode.Custom);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		ScrambleMode scrambleMode = (ScrambleMode)num;
		ToLua.Push(L, scrambleMode);
		return 1;
	}
}
