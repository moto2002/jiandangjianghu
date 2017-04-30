using LuaInterface;
using System;

public class LoginResultWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LoginResult), typeof(object), null);
		L.RegFunction("New", new LuaCSFunction(LoginResultWrap._CreateLoginResult));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("isSuc", new LuaCSFunction(LoginResultWrap.get_isSuc), new LuaCSFunction(LoginResultWrap.set_isSuc));
		L.RegVar("isSwitchAccount", new LuaCSFunction(LoginResultWrap.get_isSwitchAccount), new LuaCSFunction(LoginResultWrap.set_isSwitchAccount));
		L.RegVar("userID", new LuaCSFunction(LoginResultWrap.get_userID), new LuaCSFunction(LoginResultWrap.set_userID));
		L.RegVar("sdkUserID", new LuaCSFunction(LoginResultWrap.get_sdkUserID), new LuaCSFunction(LoginResultWrap.set_sdkUserID));
		L.RegVar("username", new LuaCSFunction(LoginResultWrap.get_username), new LuaCSFunction(LoginResultWrap.set_username));
		L.RegVar("sdkUsername", new LuaCSFunction(LoginResultWrap.get_sdkUsername), new LuaCSFunction(LoginResultWrap.set_sdkUsername));
		L.RegVar("token", new LuaCSFunction(LoginResultWrap.get_token), new LuaCSFunction(LoginResultWrap.set_token));
		L.RegVar("extension", new LuaCSFunction(LoginResultWrap.get_extension), new LuaCSFunction(LoginResultWrap.set_extension));
		L.RegVar("pID", new LuaCSFunction(LoginResultWrap.get_pID), new LuaCSFunction(LoginResultWrap.set_pID));
		L.RegVar("channelID", new LuaCSFunction(LoginResultWrap.get_channelID), new LuaCSFunction(LoginResultWrap.set_channelID));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateLoginResult(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				LoginResult o = new LoginResult();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: LoginResult.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isSuc(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			bool isSuc = loginResult.isSuc;
			LuaDLL.lua_pushboolean(L, isSuc);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isSuc on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isSwitchAccount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			bool isSwitchAccount = loginResult.isSwitchAccount;
			LuaDLL.lua_pushboolean(L, isSwitchAccount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isSwitchAccount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_userID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			string userID = loginResult.userID;
			LuaDLL.lua_pushstring(L, userID);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index userID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sdkUserID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			string sdkUserID = loginResult.sdkUserID;
			LuaDLL.lua_pushstring(L, sdkUserID);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sdkUserID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_username(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			string username = loginResult.username;
			LuaDLL.lua_pushstring(L, username);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index username on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sdkUsername(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			string sdkUsername = loginResult.sdkUsername;
			LuaDLL.lua_pushstring(L, sdkUsername);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sdkUsername on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_token(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			string token = loginResult.token;
			LuaDLL.lua_pushstring(L, token);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index token on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_extension(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			string extension = loginResult.extension;
			LuaDLL.lua_pushstring(L, extension);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index extension on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			int pID = loginResult.pID;
			LuaDLL.lua_pushinteger(L, pID);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_channelID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			int channelID = loginResult.channelID;
			LuaDLL.lua_pushinteger(L, channelID);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index channelID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isSuc(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			bool isSuc = LuaDLL.luaL_checkboolean(L, 2);
			loginResult.isSuc = isSuc;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isSuc on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isSwitchAccount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			bool isSwitchAccount = LuaDLL.luaL_checkboolean(L, 2);
			loginResult.isSwitchAccount = isSwitchAccount;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isSwitchAccount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_userID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			string userID = ToLua.CheckString(L, 2);
			loginResult.userID = userID;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index userID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sdkUserID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			string sdkUserID = ToLua.CheckString(L, 2);
			loginResult.sdkUserID = sdkUserID;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sdkUserID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_username(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			string username = ToLua.CheckString(L, 2);
			loginResult.username = username;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index username on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sdkUsername(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			string sdkUsername = ToLua.CheckString(L, 2);
			loginResult.sdkUsername = sdkUsername;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sdkUsername on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_token(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			string token = ToLua.CheckString(L, 2);
			loginResult.token = token;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index token on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_extension(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			string extension = ToLua.CheckString(L, 2);
			loginResult.extension = extension;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index extension on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			int pID = (int)LuaDLL.luaL_checknumber(L, 2);
			loginResult.pID = pID;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pID on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_channelID(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			LoginResult loginResult = (LoginResult)obj;
			int channelID = (int)LuaDLL.luaL_checknumber(L, 2);
			loginResult.channelID = channelID;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index channelID on a nil value");
		}
		return result;
	}
}
