using DG.Tweening;
using LuaInterface;
using System;

public class DG_Tweening_AutoPlayWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(AutoPlay));
		L.RegVar("None", new LuaCSFunction(DG_Tweening_AutoPlayWrap.get_None), null);
		L.RegVar("AutoPlaySequences", new LuaCSFunction(DG_Tweening_AutoPlayWrap.get_AutoPlaySequences), null);
		L.RegVar("AutoPlayTweeners", new LuaCSFunction(DG_Tweening_AutoPlayWrap.get_AutoPlayTweeners), null);
		L.RegVar("All", new LuaCSFunction(DG_Tweening_AutoPlayWrap.get_All), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(DG_Tweening_AutoPlayWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_None(IntPtr L)
	{
		ToLua.Push(L, AutoPlay.None);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_AutoPlaySequences(IntPtr L)
	{
		ToLua.Push(L, AutoPlay.AutoPlaySequences);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_AutoPlayTweeners(IntPtr L)
	{
		ToLua.Push(L, AutoPlay.AutoPlayTweeners);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_All(IntPtr L)
	{
		ToLua.Push(L, AutoPlay.All);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		AutoPlay autoPlay = (AutoPlay)num;
		ToLua.Push(L, autoPlay);
		return 1;
	}
}
