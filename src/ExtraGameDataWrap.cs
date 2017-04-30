using LuaInterface;
using System;

public class ExtraGameDataWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ExtraGameData), typeof(object), null);
		L.RegFunction("New", new LuaCSFunction(ExtraGameDataWrap._CreateExtraGameData));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegConstant("TYPE_CREATE_ROLE", 2.0);
		L.RegConstant("TYPE_ENTER_GAME", 3.0);
		L.RegConstant("TYPE_LEVEL_UP", 4.0);
		L.RegConstant("TYPE_EXIT_GAME", 5.0);
		L.RegVar("dataType", new LuaCSFunction(ExtraGameDataWrap.get_dataType), new LuaCSFunction(ExtraGameDataWrap.set_dataType));
		L.RegVar("roleID", new LuaCSFunction(ExtraGameDataWrap.get_roleID), new LuaCSFunction(ExtraGameDataWrap.set_roleID));
		L.RegVar("roleName", new LuaCSFunction(ExtraGameDataWrap.get_roleName), new LuaCSFunction(ExtraGameDataWrap.set_roleName));
		L.RegVar("roleLevel", new LuaCSFunction(ExtraGameDataWrap.get_roleLevel), new LuaCSFunction(ExtraGameDataWrap.set_roleLevel));
		L.RegVar("serverID", new LuaCSFunction(ExtraGameDataWrap.get_serverID), new LuaCSFunction(ExtraGameDataWrap.set_serverID));
		L.RegVar("serverName", new LuaCSFunction(ExtraGameDataWrap.get_serverName), new LuaCSFunction(ExtraGameDataWrap.set_serverName));
		L.RegVar("moneyNum", new LuaCSFunction(ExtraGameDataWrap.get_moneyNum), new LuaCSFunction(ExtraGameDataWrap.set_moneyNum));
		L.RegVar("vipLv", new LuaCSFunction(ExtraGameDataWrap.get_vipLv), new LuaCSFunction(ExtraGameDataWrap.set_vipLv));
		L.RegVar("unionName", new LuaCSFunction(ExtraGameDataWrap.get_unionName), new LuaCSFunction(ExtraGameDataWrap.set_unionName));
		L.RegVar("createTime", new LuaCSFunction(ExtraGameDataWrap.get_createTime), new LuaCSFunction(ExtraGameDataWrap.set_createTime));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateExtraGameData(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				ExtraGameData o = new ExtraGameData();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: ExtraGameData.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dataType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			int dataType = extraGameData.dataType;
			LuaDLL.lua_pushinteger(L, dataType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dataType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_roleID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			string roleID = extraGameData.roleID;
			LuaDLL.lua_pushstring(L, roleID);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index roleID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_roleName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			string roleName = extraGameData.roleName;
			LuaDLL.lua_pushstring(L, roleName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index roleName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_roleLevel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			string roleLevel = extraGameData.roleLevel;
			LuaDLL.lua_pushstring(L, roleLevel);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index roleLevel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_serverID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			int serverID = extraGameData.serverID;
			LuaDLL.lua_pushinteger(L, serverID);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index serverID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_serverName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			string serverName = extraGameData.serverName;
			LuaDLL.lua_pushstring(L, serverName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index serverName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_moneyNum(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			int moneyNum = extraGameData.moneyNum;
			LuaDLL.lua_pushinteger(L, moneyNum);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index moneyNum on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_vipLv(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			int vipLv = extraGameData.vipLv;
			LuaDLL.lua_pushinteger(L, vipLv);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index vipLv on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_unionName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			string unionName = extraGameData.unionName;
			LuaDLL.lua_pushstring(L, unionName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index unionName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_createTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			int createTime = extraGameData.createTime;
			LuaDLL.lua_pushinteger(L, createTime);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index createTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_dataType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			int dataType = (int)LuaDLL.luaL_checknumber(L, 2);
			extraGameData.dataType = dataType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dataType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_roleID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			string roleID = ToLua.CheckString(L, 2);
			extraGameData.roleID = roleID;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index roleID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_roleName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			string roleName = ToLua.CheckString(L, 2);
			extraGameData.roleName = roleName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index roleName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_roleLevel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			string roleLevel = ToLua.CheckString(L, 2);
			extraGameData.roleLevel = roleLevel;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index roleLevel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_serverID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			int serverID = (int)LuaDLL.luaL_checknumber(L, 2);
			extraGameData.serverID = serverID;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index serverID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_serverName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			string serverName = ToLua.CheckString(L, 2);
			extraGameData.serverName = serverName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index serverName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_moneyNum(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			int moneyNum = (int)LuaDLL.luaL_checknumber(L, 2);
			extraGameData.moneyNum = moneyNum;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index moneyNum on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_vipLv(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			int vipLv = (int)LuaDLL.luaL_checknumber(L, 2);
			extraGameData.vipLv = vipLv;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index vipLv on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_unionName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			string unionName = ToLua.CheckString(L, 2);
			extraGameData.unionName = unionName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index unionName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_createTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ExtraGameData extraGameData = (ExtraGameData)obj;
			int createTime = (int)LuaDLL.luaL_checknumber(L, 2);
			extraGameData.createTime = createTime;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index createTime on a nil value");
		}
		return result;
	}
}
