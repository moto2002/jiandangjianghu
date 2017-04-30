using DG.Tweening;
using LuaInterface;
using System;

public class DG_Tweening_AxisConstraintWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(AxisConstraint));
		L.RegVar("None", new LuaCSFunction(DG_Tweening_AxisConstraintWrap.get_None), null);
		L.RegVar("X", new LuaCSFunction(DG_Tweening_AxisConstraintWrap.get_X), null);
		L.RegVar("Y", new LuaCSFunction(DG_Tweening_AxisConstraintWrap.get_Y), null);
		L.RegVar("Z", new LuaCSFunction(DG_Tweening_AxisConstraintWrap.get_Z), null);
		L.RegVar("W", new LuaCSFunction(DG_Tweening_AxisConstraintWrap.get_W), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(DG_Tweening_AxisConstraintWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_None(IntPtr L)
	{
		ToLua.Push(L, AxisConstraint.None);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_X(IntPtr L)
	{
		ToLua.Push(L, AxisConstraint.X);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Y(IntPtr L)
	{
		ToLua.Push(L, AxisConstraint.Y);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Z(IntPtr L)
	{
		ToLua.Push(L, AxisConstraint.Z);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_W(IntPtr L)
	{
		ToLua.Push(L, AxisConstraint.W);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		AxisConstraint axisConstraint = (AxisConstraint)num;
		ToLua.Push(L, axisConstraint);
		return 1;
	}
}
