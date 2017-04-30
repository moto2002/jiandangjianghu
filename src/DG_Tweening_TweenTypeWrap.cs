using DG.Tweening;
using LuaInterface;
using System;

public class DG_Tweening_TweenTypeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(TweenType));
		L.RegVar("Tweener", new LuaCSFunction(DG_Tweening_TweenTypeWrap.get_Tweener), null);
		L.RegVar("Sequence", new LuaCSFunction(DG_Tweening_TweenTypeWrap.get_Sequence), null);
		L.RegVar("Callback", new LuaCSFunction(DG_Tweening_TweenTypeWrap.get_Callback), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(DG_Tweening_TweenTypeWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Tweener(IntPtr L)
	{
		ToLua.Push(L, TweenType.Tweener);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Sequence(IntPtr L)
	{
		ToLua.Push(L, TweenType.Sequence);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Callback(IntPtr L)
	{
		ToLua.Push(L, TweenType.Callback);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		TweenType tweenType = (TweenType)num;
		ToLua.Push(L, tweenType);
		return 1;
	}
}
