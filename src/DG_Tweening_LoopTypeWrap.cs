using DG.Tweening;
using LuaInterface;
using System;

public class DG_Tweening_LoopTypeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(LoopType));
		L.RegVar("Restart", new LuaCSFunction(DG_Tweening_LoopTypeWrap.get_Restart), null);
		L.RegVar("Yoyo", new LuaCSFunction(DG_Tweening_LoopTypeWrap.get_Yoyo), null);
		L.RegVar("Incremental", new LuaCSFunction(DG_Tweening_LoopTypeWrap.get_Incremental), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(DG_Tweening_LoopTypeWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Restart(IntPtr L)
	{
		ToLua.Push(L, LoopType.Restart);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Yoyo(IntPtr L)
	{
		ToLua.Push(L, LoopType.Yoyo);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Incremental(IntPtr L)
	{
		ToLua.Push(L, LoopType.Incremental);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		LoopType loopType = (LoopType)num;
		ToLua.Push(L, loopType);
		return 1;
	}
}
