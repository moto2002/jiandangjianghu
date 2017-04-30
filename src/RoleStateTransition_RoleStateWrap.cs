using LuaInterface;
using System;

public class RoleStateTransition_RoleStateWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(RoleStateTransition.RoleState));
		L.RegVar("None", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_None), null);
		L.RegVar("Fight", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_Fight), null);
		L.RegVar("Jumping", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_Jumping), null);
		L.RegVar("HorseRiding", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_HorseRiding), null);
		L.RegVar("BeginAutoQuesting", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_BeginAutoQuesting), null);
		L.RegVar("AutoPathfinding", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_AutoPathfinding), null);
		L.RegVar("Dazuo", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_Dazuo), null);
		L.RegVar("Guaji", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_Guaji), null);
		L.RegVar("OpenUI", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_OpenUI), null);
		L.RegVar("PathComputeComplete", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_PathComputeComplete), null);
		L.RegVar("Dead", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_Dead), null);
		L.RegVar("FlyShoe", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_FlyShoe), null);
		L.RegVar("Husong", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_Husong), null);
		L.RegVar("ProtectFollow", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_ProtectFollow), null);
		L.RegVar("ShowGuide", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_ShowGuide), null);
		L.RegVar("Task", new LuaCSFunction(RoleStateTransition_RoleStateWrap.get_Task), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(RoleStateTransition_RoleStateWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_None(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.None);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Fight(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.Fight);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Jumping(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.Jumping);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_HorseRiding(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.HorseRiding);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_BeginAutoQuesting(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.BeginAutoQuesting);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_AutoPathfinding(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.AutoPathfinding);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Dazuo(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.Dazuo);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Guaji(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.Guaji);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OpenUI(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.OpenUI);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_PathComputeComplete(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.PathComputeComplete);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Dead(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.Dead);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_FlyShoe(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.FlyShoe);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Husong(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.Husong);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ProtectFollow(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.ProtectFollow);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ShowGuide(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.ShowGuide);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Task(IntPtr L)
	{
		ToLua.Push(L, RoleStateTransition.RoleState.Task);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		RoleStateTransition.RoleState roleState = (RoleStateTransition.RoleState)num;
		ToLua.Push(L, roleState);
		return 1;
	}
}
