using LuaInterface;
using System;

public class ServerInfoWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ServerInfo), typeof(object), null);
		L.RegFunction("New", new LuaCSFunction(ServerInfoWrap._CreateServerInfo));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("serverNo", new LuaCSFunction(ServerInfoWrap.get_serverNo), new LuaCSFunction(ServerInfoWrap.set_serverNo));
		L.RegVar("serverName", new LuaCSFunction(ServerInfoWrap.get_serverName), new LuaCSFunction(ServerInfoWrap.set_serverName));
		L.RegVar("serverIp", new LuaCSFunction(ServerInfoWrap.get_serverIp), new LuaCSFunction(ServerInfoWrap.set_serverIp));
		L.RegVar("serverPort", new LuaCSFunction(ServerInfoWrap.get_serverPort), new LuaCSFunction(ServerInfoWrap.set_serverPort));
		L.RegVar("status", new LuaCSFunction(ServerInfoWrap.get_status), new LuaCSFunction(ServerInfoWrap.set_status));
		L.RegVar("isNew", new LuaCSFunction(ServerInfoWrap.get_isNew), new LuaCSFunction(ServerInfoWrap.set_isNew));
		L.RegVar("openTime", new LuaCSFunction(ServerInfoWrap.get_openTime), new LuaCSFunction(ServerInfoWrap.set_openTime));
		L.RegVar("playerLevel", new LuaCSFunction(ServerInfoWrap.get_playerLevel), new LuaCSFunction(ServerInfoWrap.set_playerLevel));
		L.RegVar("isOpen", new LuaCSFunction(ServerInfoWrap.get_isOpen), new LuaCSFunction(ServerInfoWrap.set_isOpen));
		L.RegVar("other", new LuaCSFunction(ServerInfoWrap.get_other), new LuaCSFunction(ServerInfoWrap.set_other));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateServerInfo(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				ServerInfo o = new ServerInfo();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: ServerInfo.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_serverNo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			int serverNo = serverInfo.serverNo;
			LuaDLL.lua_pushinteger(L, serverNo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index serverNo on a nil value");
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
			ServerInfo serverInfo = (ServerInfo)obj;
			string serverName = serverInfo.serverName;
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
	private static int get_serverIp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			string serverIp = serverInfo.serverIp;
			LuaDLL.lua_pushstring(L, serverIp);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index serverIp on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_serverPort(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			string serverPort = serverInfo.serverPort;
			LuaDLL.lua_pushstring(L, serverPort);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index serverPort on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_status(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			int status = serverInfo.status;
			LuaDLL.lua_pushinteger(L, status);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index status on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isNew(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			int isNew = serverInfo.isNew;
			LuaDLL.lua_pushinteger(L, isNew);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isNew on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_openTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			int openTime = serverInfo.openTime;
			LuaDLL.lua_pushinteger(L, openTime);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index openTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_playerLevel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			int playerLevel = serverInfo.playerLevel;
			LuaDLL.lua_pushinteger(L, playerLevel);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index playerLevel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isOpen(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			int isOpen = serverInfo.isOpen;
			LuaDLL.lua_pushinteger(L, isOpen);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isOpen on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_other(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			string other = serverInfo.other;
			LuaDLL.lua_pushstring(L, other);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index other on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_serverNo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			int serverNo = (int)LuaDLL.luaL_checknumber(L, 2);
			serverInfo.serverNo = serverNo;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index serverNo on a nil value");
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
			ServerInfo serverInfo = (ServerInfo)obj;
			string serverName = ToLua.CheckString(L, 2);
			serverInfo.serverName = serverName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index serverName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_serverIp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			string serverIp = ToLua.CheckString(L, 2);
			serverInfo.serverIp = serverIp;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index serverIp on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_serverPort(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			string serverPort = ToLua.CheckString(L, 2);
			serverInfo.serverPort = serverPort;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index serverPort on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_status(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			int status = (int)LuaDLL.luaL_checknumber(L, 2);
			serverInfo.status = status;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index status on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isNew(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			int isNew = (int)LuaDLL.luaL_checknumber(L, 2);
			serverInfo.isNew = isNew;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isNew on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_openTime(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			int openTime = (int)LuaDLL.luaL_checknumber(L, 2);
			serverInfo.openTime = openTime;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index openTime on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_playerLevel(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			int playerLevel = (int)LuaDLL.luaL_checknumber(L, 2);
			serverInfo.playerLevel = playerLevel;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index playerLevel on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isOpen(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			int isOpen = (int)LuaDLL.luaL_checknumber(L, 2);
			serverInfo.isOpen = isOpen;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isOpen on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_other(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ServerInfo serverInfo = (ServerInfo)obj;
			string other = ToLua.CheckString(L, 2);
			serverInfo.other = other;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index other on a nil value");
		}
		return result;
	}
}
