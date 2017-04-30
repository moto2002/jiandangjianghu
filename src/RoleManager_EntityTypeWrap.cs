using LuaInterface;
using System;

public class RoleManager_EntityTypeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(RoleManager.EntityType));
		L.RegVar("EntityType_None", new LuaCSFunction(RoleManager_EntityTypeWrap.get_EntityType_None), null);
		L.RegVar("EntityType_Self", new LuaCSFunction(RoleManager_EntityTypeWrap.get_EntityType_Self), null);
		L.RegVar("EntityType_Role", new LuaCSFunction(RoleManager_EntityTypeWrap.get_EntityType_Role), null);
		L.RegVar("EntityType_Npc", new LuaCSFunction(RoleManager_EntityTypeWrap.get_EntityType_Npc), null);
		L.RegVar("EntityType_Monster", new LuaCSFunction(RoleManager_EntityTypeWrap.get_EntityType_Monster), null);
		L.RegVar("EntityType_Lingqi", new LuaCSFunction(RoleManager_EntityTypeWrap.get_EntityType_Lingqi), null);
		L.RegVar("EntityType_Partner", new LuaCSFunction(RoleManager_EntityTypeWrap.get_EntityType_Partner), null);
		L.RegVar("EntityType_Aider", new LuaCSFunction(RoleManager_EntityTypeWrap.get_EntityType_Aider), null);
		L.RegVar("EntityType_Pet", new LuaCSFunction(RoleManager_EntityTypeWrap.get_EntityType_Pet), null);
		L.RegVar("EntityType_Beauty", new LuaCSFunction(RoleManager_EntityTypeWrap.get_EntityType_Beauty), null);
		L.RegVar("EntityType_XunLuo", new LuaCSFunction(RoleManager_EntityTypeWrap.get_EntityType_XunLuo), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(RoleManager_EntityTypeWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_EntityType_None(IntPtr L)
	{
		ToLua.Push(L, RoleManager.EntityType.EntityType_None);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_EntityType_Self(IntPtr L)
	{
		ToLua.Push(L, RoleManager.EntityType.EntityType_Self);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_EntityType_Role(IntPtr L)
	{
		ToLua.Push(L, RoleManager.EntityType.EntityType_Role);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_EntityType_Npc(IntPtr L)
	{
		ToLua.Push(L, RoleManager.EntityType.EntityType_Npc);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_EntityType_Monster(IntPtr L)
	{
		ToLua.Push(L, RoleManager.EntityType.EntityType_Monster);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_EntityType_Lingqi(IntPtr L)
	{
		ToLua.Push(L, RoleManager.EntityType.EntityType_Lingqi);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_EntityType_Partner(IntPtr L)
	{
		ToLua.Push(L, RoleManager.EntityType.EntityType_Partner);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_EntityType_Aider(IntPtr L)
	{
		ToLua.Push(L, RoleManager.EntityType.EntityType_Aider);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_EntityType_Pet(IntPtr L)
	{
		ToLua.Push(L, RoleManager.EntityType.EntityType_Pet);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_EntityType_Beauty(IntPtr L)
	{
		ToLua.Push(L, RoleManager.EntityType.EntityType_Beauty);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_EntityType_XunLuo(IntPtr L)
	{
		ToLua.Push(L, RoleManager.EntityType.EntityType_XunLuo);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		RoleManager.EntityType entityType = (RoleManager.EntityType)num;
		ToLua.Push(L, entityType);
		return 1;
	}
}
