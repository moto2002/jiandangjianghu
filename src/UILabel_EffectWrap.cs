using LuaInterface;
using System;

public class UILabel_EffectWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(UILabel.Effect));
		L.RegVar("None", new LuaCSFunction(UILabel_EffectWrap.get_None), null);
		L.RegVar("Shadow", new LuaCSFunction(UILabel_EffectWrap.get_Shadow), null);
		L.RegVar("Outline", new LuaCSFunction(UILabel_EffectWrap.get_Outline), null);
		L.RegVar("Outline8", new LuaCSFunction(UILabel_EffectWrap.get_Outline8), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(UILabel_EffectWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_None(IntPtr L)
	{
		ToLua.Push(L, UILabel.Effect.None);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Shadow(IntPtr L)
	{
		ToLua.Push(L, UILabel.Effect.Shadow);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Outline(IntPtr L)
	{
		ToLua.Push(L, UILabel.Effect.Outline);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Outline8(IntPtr L)
	{
		ToLua.Push(L, UILabel.Effect.Outline8);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		UILabel.Effect effect = (UILabel.Effect)num;
		ToLua.Push(L, effect);
		return 1;
	}
}
