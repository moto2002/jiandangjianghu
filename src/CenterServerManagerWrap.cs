using LuaInterface;
using System;
using System.Collections;

public class CenterServerManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(CenterServerManager), typeof(object), null);
		L.RegFunction("LoginRequest", new LuaCSFunction(CenterServerManagerWrap.LoginRequest));
		L.RegFunction("StepLogRequest", new LuaCSFunction(CenterServerManagerWrap.StepLogRequest));
		L.RegFunction("LoginInfoLog", new LuaCSFunction(CenterServerManagerWrap.LoginInfoLog));
		L.RegFunction("GetNoticeInfo", new LuaCSFunction(CenterServerManagerWrap.GetNoticeInfo));
		L.RegFunction("ChatMonitor", new LuaCSFunction(CenterServerManagerWrap.ChatMonitor));
		L.RegFunction("SetLastServer", new LuaCSFunction(CenterServerManagerWrap.SetLastServer));
		L.RegFunction("GetCdnData", new LuaCSFunction(CenterServerManagerWrap.GetCdnData));
		L.RegFunction("CreateRoleInfo", new LuaCSFunction(CenterServerManagerWrap.CreateRoleInfo));
		L.RegFunction("UpgradeInfo", new LuaCSFunction(CenterServerManagerWrap.UpgradeInfo));
		L.RegFunction("UpdateRoleInfo", new LuaCSFunction(CenterServerManagerWrap.UpdateRoleInfo));
		L.RegFunction("SignGM", new LuaCSFunction(CenterServerManagerWrap.SignGM));
		L.RegFunction("New", new LuaCSFunction(CenterServerManagerWrap._CreateCenterServerManager));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Instance", new LuaCSFunction(CenterServerManagerWrap.get_Instance), null);
		L.RegVar("AppID", new LuaCSFunction(CenterServerManagerWrap.get_AppID), null);
		L.RegVar("ChannelID", new LuaCSFunction(CenterServerManagerWrap.get_ChannelID), new LuaCSFunction(CenterServerManagerWrap.set_ChannelID));
		L.RegVar("UserID", new LuaCSFunction(CenterServerManagerWrap.get_UserID), new LuaCSFunction(CenterServerManagerWrap.set_UserID));
		L.RegVar("Token", new LuaCSFunction(CenterServerManagerWrap.get_Token), new LuaCSFunction(CenterServerManagerWrap.set_Token));
		L.RegVar("ImeiOrIdfa", new LuaCSFunction(CenterServerManagerWrap.get_ImeiOrIdfa), null);
		L.RegVar("Method", new LuaCSFunction(CenterServerManagerWrap.get_Method), new LuaCSFunction(CenterServerManagerWrap.set_Method));
		L.RegVar("Pid", new LuaCSFunction(CenterServerManagerWrap.get_Pid), new LuaCSFunction(CenterServerManagerWrap.set_Pid));
		L.RegVar("Sign", new LuaCSFunction(CenterServerManagerWrap.get_Sign), null);
		L.RegVar("Time", new LuaCSFunction(CenterServerManagerWrap.get_Time), new LuaCSFunction(CenterServerManagerWrap.set_Time));
		L.RegVar("AccountName", new LuaCSFunction(CenterServerManagerWrap.get_AccountName), new LuaCSFunction(CenterServerManagerWrap.set_AccountName));
		L.RegVar("LastServer", new LuaCSFunction(CenterServerManagerWrap.get_LastServer), new LuaCSFunction(CenterServerManagerWrap.set_LastServer));
		L.RegVar("ServerList", new LuaCSFunction(CenterServerManagerWrap.get_ServerList), new LuaCSFunction(CenterServerManagerWrap.set_ServerList));
		L.RegVar("ShowAccount", new LuaCSFunction(CenterServerManagerWrap.get_ShowAccount), new LuaCSFunction(CenterServerManagerWrap.set_ShowAccount));
		L.RegVar("VersionView", new LuaCSFunction(CenterServerManagerWrap.get_VersionView), new LuaCSFunction(CenterServerManagerWrap.set_VersionView));
		L.RegVar("Access_token", new LuaCSFunction(CenterServerManagerWrap.get_Access_token), new LuaCSFunction(CenterServerManagerWrap.set_Access_token));
		L.RegVar("AccName", new LuaCSFunction(CenterServerManagerWrap.get_AccName), new LuaCSFunction(CenterServerManagerWrap.set_AccName));
		L.RegVar("Channel_id", new LuaCSFunction(CenterServerManagerWrap.get_Channel_id), new LuaCSFunction(CenterServerManagerWrap.set_Channel_id));
		L.RegVar("Sid", new LuaCSFunction(CenterServerManagerWrap.get_Sid), new LuaCSFunction(CenterServerManagerWrap.set_Sid));
		L.RegVar("ServerName", new LuaCSFunction(CenterServerManagerWrap.get_ServerName), new LuaCSFunction(CenterServerManagerWrap.set_ServerName));
		L.RegVar("Mac", new LuaCSFunction(CenterServerManagerWrap.get_Mac), new LuaCSFunction(CenterServerManagerWrap.set_Mac));
		L.RegVar("Version", new LuaCSFunction(CenterServerManagerWrap.get_Version), new LuaCSFunction(CenterServerManagerWrap.set_Version));
		L.RegVar("PackageUrl", new LuaCSFunction(CenterServerManagerWrap.get_PackageUrl), new LuaCSFunction(CenterServerManagerWrap.set_PackageUrl));
		L.RegVar("Ip", new LuaCSFunction(CenterServerManagerWrap.get_Ip), new LuaCSFunction(CenterServerManagerWrap.set_Ip));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateCenterServerManager(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				CenterServerManager o = new CenterServerManager();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: CenterServerManager.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoginRequest(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			CenterServerManager centerServerManager = (CenterServerManager)ToLua.CheckObject(L, 1, typeof(CenterServerManager));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Action)ToLua.CheckObject(L, 2, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				callback = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			centerServerManager.LoginRequest(callback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StepLogRequest(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			CenterServerManager centerServerManager = (CenterServerManager)ToLua.CheckObject(L, 1, typeof(CenterServerManager));
			int stepFlag = (int)LuaDLL.luaL_checknumber(L, 2);
			centerServerManager.StepLogRequest(stepFlag);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoginInfoLog(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			CenterServerManager centerServerManager = (CenterServerManager)ToLua.CheckObject(L, 1, typeof(CenterServerManager));
			string nickname = ToLua.CheckString(L, 2);
			centerServerManager.LoginInfoLog(nickname);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetNoticeInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			CenterServerManager centerServerManager = (CenterServerManager)ToLua.CheckObject(L, 1, typeof(CenterServerManager));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<string> callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Action<string>)ToLua.CheckObject(L, 2, typeof(Action<string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				callback = (DelegateFactory.CreateDelegate(typeof(Action<string>), func) as Action<string>);
			}
			centerServerManager.GetNoticeInfo(callback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChatMonitor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			CenterServerManager centerServerManager = (CenterServerManager)ToLua.CheckObject(L, 1, typeof(CenterServerManager));
			string nickName = ToLua.CheckString(L, 2);
			string roleId = ToLua.CheckString(L, 3);
			string msg = ToLua.CheckString(L, 4);
			centerServerManager.ChatMonitor(nickName, roleId, msg);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLastServer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)ToLua.CheckObject(L, 1, typeof(CenterServerManager));
			centerServerManager.SetLastServer();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCdnData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			CenterServerManager centerServerManager = (CenterServerManager)ToLua.CheckObject(L, 1, typeof(CenterServerManager));
			string curVersion = ToLua.CheckString(L, 2);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			Action<string, string> callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (Action<string, string>)ToLua.CheckObject(L, 3, typeof(Action<string, string>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				callback = (DelegateFactory.CreateDelegate(typeof(Action<string, string>), func) as Action<string, string>);
			}
			centerServerManager.GetCdnData(curVersion, callback);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateRoleInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			CenterServerManager centerServerManager = (CenterServerManager)ToLua.CheckObject(L, 1, typeof(CenterServerManager));
			string name = ToLua.CheckString(L, 2);
			int level = (int)LuaDLL.luaL_checknumber(L, 3);
			string roleId = ToLua.CheckString(L, 4);
			int vip = (int)LuaDLL.luaL_checknumber(L, 5);
			centerServerManager.CreateRoleInfo(name, level, roleId, vip);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpgradeInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			CenterServerManager centerServerManager = (CenterServerManager)ToLua.CheckObject(L, 1, typeof(CenterServerManager));
			string name = ToLua.CheckString(L, 2);
			int level = (int)LuaDLL.luaL_checknumber(L, 3);
			centerServerManager.UpgradeInfo(name, level);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateRoleInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			CenterServerManager centerServerManager = (CenterServerManager)ToLua.CheckObject(L, 1, typeof(CenterServerManager));
			string name = ToLua.CheckString(L, 2);
			int level = (int)LuaDLL.luaL_checknumber(L, 3);
			int vip = (int)LuaDLL.luaL_checknumber(L, 4);
			string newName = ToLua.CheckString(L, 5);
			centerServerManager.UpdateRoleInfo(name, level, vip, newName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SignGM(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			string userId = ToLua.CheckString(L, 1);
			int serverNo = (int)LuaDLL.luaL_checknumber(L, 2);
			int time = (int)LuaDLL.luaL_checknumber(L, 3);
			string str = CenterServerManager.SignGM(userId, serverNo, time);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Instance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, CenterServerManager.Instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_AppID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			int appID = centerServerManager.AppID;
			LuaDLL.lua_pushinteger(L, appID);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index AppID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ChannelID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			int channelID = centerServerManager.ChannelID;
			LuaDLL.lua_pushinteger(L, channelID);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ChannelID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_UserID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string userID = centerServerManager.UserID;
			LuaDLL.lua_pushstring(L, userID);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index UserID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Token(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string token = centerServerManager.Token;
			LuaDLL.lua_pushstring(L, token);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Token on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ImeiOrIdfa(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string imeiOrIdfa = centerServerManager.ImeiOrIdfa;
			LuaDLL.lua_pushstring(L, imeiOrIdfa);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ImeiOrIdfa on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Method(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string method = centerServerManager.Method;
			LuaDLL.lua_pushstring(L, method);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Method on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Pid(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			int pid = centerServerManager.Pid;
			LuaDLL.lua_pushinteger(L, pid);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Pid on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Sign(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string sign = centerServerManager.Sign;
			LuaDLL.lua_pushstring(L, sign);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Sign on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Time(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string time = centerServerManager.Time;
			LuaDLL.lua_pushstring(L, time);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Time on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_AccountName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string accountName = centerServerManager.AccountName;
			LuaDLL.lua_pushstring(L, accountName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index AccountName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_LastServer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			ArrayList lastServer = centerServerManager.LastServer;
			ToLua.PushObject(L, lastServer);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LastServer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ServerList(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			ArrayList serverList = centerServerManager.ServerList;
			ToLua.PushObject(L, serverList);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ServerList on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ShowAccount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			bool showAccount = centerServerManager.ShowAccount;
			LuaDLL.lua_pushboolean(L, showAccount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShowAccount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_VersionView(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			bool versionView = centerServerManager.VersionView;
			LuaDLL.lua_pushboolean(L, versionView);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index VersionView on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Access_token(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string access_token = centerServerManager.Access_token;
			LuaDLL.lua_pushstring(L, access_token);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Access_token on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_AccName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string accName = centerServerManager.AccName;
			LuaDLL.lua_pushstring(L, accName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index AccName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Channel_id(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			int channel_id = centerServerManager.Channel_id;
			LuaDLL.lua_pushinteger(L, channel_id);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Channel_id on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Sid(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			int sid = centerServerManager.Sid;
			LuaDLL.lua_pushinteger(L, sid);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Sid on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ServerName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string serverName = centerServerManager.ServerName;
			LuaDLL.lua_pushstring(L, serverName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ServerName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Mac(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string mac = centerServerManager.Mac;
			LuaDLL.lua_pushstring(L, mac);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Mac on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Version(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string version = centerServerManager.Version;
			LuaDLL.lua_pushstring(L, version);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Version on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_PackageUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string packageUrl = centerServerManager.PackageUrl;
			LuaDLL.lua_pushstring(L, packageUrl);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index PackageUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Ip(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string ip = centerServerManager.Ip;
			LuaDLL.lua_pushstring(L, ip);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Ip on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ChannelID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			int channelID = (int)LuaDLL.luaL_checknumber(L, 2);
			centerServerManager.ChannelID = channelID;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ChannelID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_UserID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string userID = ToLua.CheckString(L, 2);
			centerServerManager.UserID = userID;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index UserID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Token(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string token = ToLua.CheckString(L, 2);
			centerServerManager.Token = token;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Token on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Method(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string method = ToLua.CheckString(L, 2);
			centerServerManager.Method = method;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Method on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Pid(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			int pid = (int)LuaDLL.luaL_checknumber(L, 2);
			centerServerManager.Pid = pid;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Pid on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Time(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string time = ToLua.CheckString(L, 2);
			centerServerManager.Time = time;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Time on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_AccountName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string accountName = ToLua.CheckString(L, 2);
			centerServerManager.AccountName = accountName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index AccountName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_LastServer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			ArrayList lastServer = (ArrayList)ToLua.CheckObject(L, 2, typeof(ArrayList));
			centerServerManager.LastServer = lastServer;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index LastServer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ServerList(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			ArrayList serverList = (ArrayList)ToLua.CheckObject(L, 2, typeof(ArrayList));
			centerServerManager.ServerList = serverList;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ServerList on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ShowAccount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			bool showAccount = LuaDLL.luaL_checkboolean(L, 2);
			centerServerManager.ShowAccount = showAccount;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ShowAccount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_VersionView(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			bool versionView = LuaDLL.luaL_checkboolean(L, 2);
			centerServerManager.VersionView = versionView;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index VersionView on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Access_token(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string access_token = ToLua.CheckString(L, 2);
			centerServerManager.Access_token = access_token;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Access_token on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_AccName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string accName = ToLua.CheckString(L, 2);
			centerServerManager.AccName = accName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index AccName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Channel_id(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			int channel_id = (int)LuaDLL.luaL_checknumber(L, 2);
			centerServerManager.Channel_id = channel_id;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Channel_id on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Sid(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			int sid = (int)LuaDLL.luaL_checknumber(L, 2);
			centerServerManager.Sid = sid;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Sid on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ServerName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string serverName = ToLua.CheckString(L, 2);
			centerServerManager.ServerName = serverName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ServerName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Mac(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string mac = ToLua.CheckString(L, 2);
			centerServerManager.Mac = mac;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Mac on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Version(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string version = ToLua.CheckString(L, 2);
			centerServerManager.Version = version;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Version on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_PackageUrl(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string packageUrl = ToLua.CheckString(L, 2);
			centerServerManager.PackageUrl = packageUrl;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index PackageUrl on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Ip(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			CenterServerManager centerServerManager = (CenterServerManager)obj;
			string ip = ToLua.CheckString(L, 2);
			centerServerManager.Ip = ip;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Ip on a nil value");
		}
		return result;
	}
}
