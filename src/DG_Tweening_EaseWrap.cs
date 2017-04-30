using DG.Tweening;
using LuaInterface;
using System;

public class DG_Tweening_EaseWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(Ease));
		L.RegVar("Unset", new LuaCSFunction(DG_Tweening_EaseWrap.get_Unset), null);
		L.RegVar("Linear", new LuaCSFunction(DG_Tweening_EaseWrap.get_Linear), null);
		L.RegVar("InSine", new LuaCSFunction(DG_Tweening_EaseWrap.get_InSine), null);
		L.RegVar("OutSine", new LuaCSFunction(DG_Tweening_EaseWrap.get_OutSine), null);
		L.RegVar("InOutSine", new LuaCSFunction(DG_Tweening_EaseWrap.get_InOutSine), null);
		L.RegVar("InQuad", new LuaCSFunction(DG_Tweening_EaseWrap.get_InQuad), null);
		L.RegVar("OutQuad", new LuaCSFunction(DG_Tweening_EaseWrap.get_OutQuad), null);
		L.RegVar("InOutQuad", new LuaCSFunction(DG_Tweening_EaseWrap.get_InOutQuad), null);
		L.RegVar("InCubic", new LuaCSFunction(DG_Tweening_EaseWrap.get_InCubic), null);
		L.RegVar("OutCubic", new LuaCSFunction(DG_Tweening_EaseWrap.get_OutCubic), null);
		L.RegVar("InOutCubic", new LuaCSFunction(DG_Tweening_EaseWrap.get_InOutCubic), null);
		L.RegVar("InQuart", new LuaCSFunction(DG_Tweening_EaseWrap.get_InQuart), null);
		L.RegVar("OutQuart", new LuaCSFunction(DG_Tweening_EaseWrap.get_OutQuart), null);
		L.RegVar("InOutQuart", new LuaCSFunction(DG_Tweening_EaseWrap.get_InOutQuart), null);
		L.RegVar("InQuint", new LuaCSFunction(DG_Tweening_EaseWrap.get_InQuint), null);
		L.RegVar("OutQuint", new LuaCSFunction(DG_Tweening_EaseWrap.get_OutQuint), null);
		L.RegVar("InOutQuint", new LuaCSFunction(DG_Tweening_EaseWrap.get_InOutQuint), null);
		L.RegVar("InExpo", new LuaCSFunction(DG_Tweening_EaseWrap.get_InExpo), null);
		L.RegVar("OutExpo", new LuaCSFunction(DG_Tweening_EaseWrap.get_OutExpo), null);
		L.RegVar("InOutExpo", new LuaCSFunction(DG_Tweening_EaseWrap.get_InOutExpo), null);
		L.RegVar("InCirc", new LuaCSFunction(DG_Tweening_EaseWrap.get_InCirc), null);
		L.RegVar("OutCirc", new LuaCSFunction(DG_Tweening_EaseWrap.get_OutCirc), null);
		L.RegVar("InOutCirc", new LuaCSFunction(DG_Tweening_EaseWrap.get_InOutCirc), null);
		L.RegVar("InElastic", new LuaCSFunction(DG_Tweening_EaseWrap.get_InElastic), null);
		L.RegVar("OutElastic", new LuaCSFunction(DG_Tweening_EaseWrap.get_OutElastic), null);
		L.RegVar("InOutElastic", new LuaCSFunction(DG_Tweening_EaseWrap.get_InOutElastic), null);
		L.RegVar("InBack", new LuaCSFunction(DG_Tweening_EaseWrap.get_InBack), null);
		L.RegVar("OutBack", new LuaCSFunction(DG_Tweening_EaseWrap.get_OutBack), null);
		L.RegVar("InOutBack", new LuaCSFunction(DG_Tweening_EaseWrap.get_InOutBack), null);
		L.RegVar("InBounce", new LuaCSFunction(DG_Tweening_EaseWrap.get_InBounce), null);
		L.RegVar("OutBounce", new LuaCSFunction(DG_Tweening_EaseWrap.get_OutBounce), null);
		L.RegVar("InOutBounce", new LuaCSFunction(DG_Tweening_EaseWrap.get_InOutBounce), null);
		L.RegVar("Flash", new LuaCSFunction(DG_Tweening_EaseWrap.get_Flash), null);
		L.RegVar("InFlash", new LuaCSFunction(DG_Tweening_EaseWrap.get_InFlash), null);
		L.RegVar("OutFlash", new LuaCSFunction(DG_Tweening_EaseWrap.get_OutFlash), null);
		L.RegVar("InOutFlash", new LuaCSFunction(DG_Tweening_EaseWrap.get_InOutFlash), null);
		L.RegVar("INTERNAL_Zero", new LuaCSFunction(DG_Tweening_EaseWrap.get_INTERNAL_Zero), null);
		L.RegVar("INTERNAL_Custom", new LuaCSFunction(DG_Tweening_EaseWrap.get_INTERNAL_Custom), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(DG_Tweening_EaseWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Unset(IntPtr L)
	{
		ToLua.Push(L, Ease.Unset);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Linear(IntPtr L)
	{
		ToLua.Push(L, Ease.Linear);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InSine(IntPtr L)
	{
		ToLua.Push(L, Ease.InSine);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OutSine(IntPtr L)
	{
		ToLua.Push(L, Ease.OutSine);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InOutSine(IntPtr L)
	{
		ToLua.Push(L, Ease.InOutSine);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InQuad(IntPtr L)
	{
		ToLua.Push(L, Ease.InQuad);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OutQuad(IntPtr L)
	{
		ToLua.Push(L, Ease.OutQuad);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InOutQuad(IntPtr L)
	{
		ToLua.Push(L, Ease.InOutQuad);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InCubic(IntPtr L)
	{
		ToLua.Push(L, Ease.InCubic);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OutCubic(IntPtr L)
	{
		ToLua.Push(L, Ease.OutCubic);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InOutCubic(IntPtr L)
	{
		ToLua.Push(L, Ease.InOutCubic);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InQuart(IntPtr L)
	{
		ToLua.Push(L, Ease.InQuart);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OutQuart(IntPtr L)
	{
		ToLua.Push(L, Ease.OutQuart);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InOutQuart(IntPtr L)
	{
		ToLua.Push(L, Ease.InOutQuart);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InQuint(IntPtr L)
	{
		ToLua.Push(L, Ease.InQuint);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OutQuint(IntPtr L)
	{
		ToLua.Push(L, Ease.OutQuint);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InOutQuint(IntPtr L)
	{
		ToLua.Push(L, Ease.InOutQuint);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InExpo(IntPtr L)
	{
		ToLua.Push(L, Ease.InExpo);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OutExpo(IntPtr L)
	{
		ToLua.Push(L, Ease.OutExpo);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InOutExpo(IntPtr L)
	{
		ToLua.Push(L, Ease.InOutExpo);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InCirc(IntPtr L)
	{
		ToLua.Push(L, Ease.InCirc);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OutCirc(IntPtr L)
	{
		ToLua.Push(L, Ease.OutCirc);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InOutCirc(IntPtr L)
	{
		ToLua.Push(L, Ease.InOutCirc);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InElastic(IntPtr L)
	{
		ToLua.Push(L, Ease.InElastic);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OutElastic(IntPtr L)
	{
		ToLua.Push(L, Ease.OutElastic);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InOutElastic(IntPtr L)
	{
		ToLua.Push(L, Ease.InOutElastic);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InBack(IntPtr L)
	{
		ToLua.Push(L, Ease.InBack);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OutBack(IntPtr L)
	{
		ToLua.Push(L, Ease.OutBack);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InOutBack(IntPtr L)
	{
		ToLua.Push(L, Ease.InOutBack);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InBounce(IntPtr L)
	{
		ToLua.Push(L, Ease.InBounce);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OutBounce(IntPtr L)
	{
		ToLua.Push(L, Ease.OutBounce);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InOutBounce(IntPtr L)
	{
		ToLua.Push(L, Ease.InOutBounce);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Flash(IntPtr L)
	{
		ToLua.Push(L, Ease.Flash);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InFlash(IntPtr L)
	{
		ToLua.Push(L, Ease.InFlash);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OutFlash(IntPtr L)
	{
		ToLua.Push(L, Ease.OutFlash);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_InOutFlash(IntPtr L)
	{
		ToLua.Push(L, Ease.InOutFlash);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_INTERNAL_Zero(IntPtr L)
	{
		ToLua.Push(L, Ease.INTERNAL_Zero);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_INTERNAL_Custom(IntPtr L)
	{
		ToLua.Push(L, Ease.INTERNAL_Custom);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		Ease ease = (Ease)num;
		ToLua.Push(L, ease);
		return 1;
	}
}
