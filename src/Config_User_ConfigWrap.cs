using Config;
using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;

public class Config_User_ConfigWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("User_Config");
		L.RegFunction("Initilize", new LuaCSFunction(Config_User_ConfigWrap.Initilize));
		L.RegFunction("LoadConfig", new LuaCSFunction(Config_User_ConfigWrap.LoadConfig));
		L.RegFunction("SetUserInfo", new LuaCSFunction(Config_User_ConfigWrap.SetUserInfo));
		L.RegFunction("LoadGlobalSetting", new LuaCSFunction(Config_User_ConfigWrap.LoadGlobalSetting));
		L.RegFunction("Save", new LuaCSFunction(Config_User_ConfigWrap.Save));
		L.RegFunction("SetWebServerUrl", new LuaCSFunction(Config_User_ConfigWrap.SetWebServerUrl));
		L.RegFunction("SetLoginServerInfo", new LuaCSFunction(Config_User_ConfigWrap.SetLoginServerInfo));
		L.RegFunction("SetDefaultServer", new LuaCSFunction(Config_User_ConfigWrap.SetDefaultServer));
		L.RegFunction("LoadCharactorConfig", new LuaCSFunction(Config_User_ConfigWrap.LoadCharactorConfig));
		L.RegFunction("GetBoolean", new LuaCSFunction(Config_User_ConfigWrap.GetBoolean));
		L.RegFunction("GetInt", new LuaCSFunction(Config_User_ConfigWrap.GetInt));
		L.RegFunction("GetString", new LuaCSFunction(Config_User_ConfigWrap.GetString));
		L.RegFunction("GetFloat", new LuaCSFunction(Config_User_ConfigWrap.GetFloat));
		L.RegFunction("SetBoolean", new LuaCSFunction(Config_User_ConfigWrap.SetBoolean));
		L.RegFunction("SetInt", new LuaCSFunction(Config_User_ConfigWrap.SetInt));
		L.RegFunction("SetFloat", new LuaCSFunction(Config_User_ConfigWrap.SetFloat));
		L.RegFunction("SetString", new LuaCSFunction(Config_User_ConfigWrap.SetString));
		L.RegFunction("SetServerList", new LuaCSFunction(Config_User_ConfigWrap.SetServerList));
		L.RegFunction("SetLastServerList", new LuaCSFunction(Config_User_ConfigWrap.SetLastServerList));
		L.RegVar("web_url", new LuaCSFunction(Config_User_ConfigWrap.get_web_url), new LuaCSFunction(Config_User_ConfigWrap.set_web_url));
		L.RegVar("server_url", new LuaCSFunction(Config_User_ConfigWrap.get_server_url), new LuaCSFunction(Config_User_ConfigWrap.set_server_url));
		L.RegVar("default_server", new LuaCSFunction(Config_User_ConfigWrap.get_default_server), new LuaCSFunction(Config_User_ConfigWrap.set_default_server));
		L.RegVar("internal_sdk", new LuaCSFunction(Config_User_ConfigWrap.get_internal_sdk), new LuaCSFunction(Config_User_ConfigWrap.set_internal_sdk));
		L.RegVar("sdk_server_url", new LuaCSFunction(Config_User_ConfigWrap.get_sdk_server_url), new LuaCSFunction(Config_User_ConfigWrap.set_sdk_server_url));
		L.RegVar("cdn_server_url", new LuaCSFunction(Config_User_ConfigWrap.get_cdn_server_url), new LuaCSFunction(Config_User_ConfigWrap.set_cdn_server_url));
		L.RegVar("resource_server", new LuaCSFunction(Config_User_ConfigWrap.get_resource_server), new LuaCSFunction(Config_User_ConfigWrap.set_resource_server));
		L.RegVar("user_account", new LuaCSFunction(Config_User_ConfigWrap.get_user_account), new LuaCSFunction(Config_User_ConfigWrap.set_user_account));
		L.RegVar("user_password", new LuaCSFunction(Config_User_ConfigWrap.get_user_password), new LuaCSFunction(Config_User_ConfigWrap.set_user_password));
		L.RegVar("gm_url", new LuaCSFunction(Config_User_ConfigWrap.get_gm_url), new LuaCSFunction(Config_User_ConfigWrap.set_gm_url));
		L.RegVar("serverList", new LuaCSFunction(Config_User_ConfigWrap.get_serverList), new LuaCSFunction(Config_User_ConfigWrap.set_serverList));
		L.RegVar("lastServerList", new LuaCSFunction(Config_User_ConfigWrap.get_lastServerList), new LuaCSFunction(Config_User_ConfigWrap.set_lastServerList));
		L.RegVar("recieveSystemChannel", new LuaCSFunction(Config_User_ConfigWrap.get_recieveSystemChannel), new LuaCSFunction(Config_User_ConfigWrap.set_recieveSystemChannel));
		L.RegVar("recieveWorldChannel", new LuaCSFunction(Config_User_ConfigWrap.get_recieveWorldChannel), new LuaCSFunction(Config_User_ConfigWrap.set_recieveWorldChannel));
		L.RegVar("recieveNearChannel", new LuaCSFunction(Config_User_ConfigWrap.get_recieveNearChannel), new LuaCSFunction(Config_User_ConfigWrap.set_recieveNearChannel));
		L.RegVar("recieveGangChannel", new LuaCSFunction(Config_User_ConfigWrap.get_recieveGangChannel), new LuaCSFunction(Config_User_ConfigWrap.set_recieveGangChannel));
		L.RegVar("recieveTeamChannel", new LuaCSFunction(Config_User_ConfigWrap.get_recieveTeamChannel), new LuaCSFunction(Config_User_ConfigWrap.set_recieveTeamChannel));
		L.RegVar("recieveStrangerChannel", new LuaCSFunction(Config_User_ConfigWrap.get_recieveStrangerChannel), new LuaCSFunction(Config_User_ConfigWrap.set_recieveStrangerChannel));
		L.RegVar("autoVoiceToText", new LuaCSFunction(Config_User_ConfigWrap.get_autoVoiceToText), new LuaCSFunction(Config_User_ConfigWrap.set_autoVoiceToText));
		L.RegVar("autoPlayWorldVoice", new LuaCSFunction(Config_User_ConfigWrap.get_autoPlayWorldVoice), new LuaCSFunction(Config_User_ConfigWrap.set_autoPlayWorldVoice));
		L.RegVar("autoPlayNearVoice", new LuaCSFunction(Config_User_ConfigWrap.get_autoPlayNearVoice), new LuaCSFunction(Config_User_ConfigWrap.set_autoPlayNearVoice));
		L.RegVar("autoPlayGangVoice", new LuaCSFunction(Config_User_ConfigWrap.get_autoPlayGangVoice), new LuaCSFunction(Config_User_ConfigWrap.set_autoPlayGangVoice));
		L.RegVar("autoPlayTeamVoice", new LuaCSFunction(Config_User_ConfigWrap.get_autoPlayTeamVoice), new LuaCSFunction(Config_User_ConfigWrap.set_autoPlayTeamVoice));
		L.RegVar("autoPlayPrivateChatVoice", new LuaCSFunction(Config_User_ConfigWrap.get_autoPlayPrivateChatVoice), new LuaCSFunction(Config_User_ConfigWrap.set_autoPlayPrivateChatVoice));
		L.RegVar("blockAllianPlayer", new LuaCSFunction(Config_User_ConfigWrap.get_blockAllianPlayer), new LuaCSFunction(Config_User_ConfigWrap.set_blockAllianPlayer));
		L.RegVar("blockOtherPartner", new LuaCSFunction(Config_User_ConfigWrap.get_blockOtherPartner), new LuaCSFunction(Config_User_ConfigWrap.set_blockOtherPartner));
		L.RegVar("blockOtherPlayer", new LuaCSFunction(Config_User_ConfigWrap.get_blockOtherPlayer), new LuaCSFunction(Config_User_ConfigWrap.set_blockOtherPlayer));
		L.RegVar("blockOtherLingqi", new LuaCSFunction(Config_User_ConfigWrap.get_blockOtherLingqi), new LuaCSFunction(Config_User_ConfigWrap.set_blockOtherLingqi));
		L.RegVar("blockOtherPet", new LuaCSFunction(Config_User_ConfigWrap.get_blockOtherPet), new LuaCSFunction(Config_User_ConfigWrap.set_blockOtherPet));
		L.RegVar("blockMonster", new LuaCSFunction(Config_User_ConfigWrap.get_blockMonster), new LuaCSFunction(Config_User_ConfigWrap.set_blockMonster));
		L.RegVar("playerScreenCount", new LuaCSFunction(Config_User_ConfigWrap.get_playerScreenCount), new LuaCSFunction(Config_User_ConfigWrap.set_playerScreenCount));
		L.RegVar("volumn", new LuaCSFunction(Config_User_ConfigWrap.get_volumn), new LuaCSFunction(Config_User_ConfigWrap.set_volumn));
		L.RegVar("quality", new LuaCSFunction(Config_User_ConfigWrap.get_quality), new LuaCSFunction(Config_User_ConfigWrap.set_quality));
		L.RegVar("isMusic", new LuaCSFunction(Config_User_ConfigWrap.get_isMusic), new LuaCSFunction(Config_User_ConfigWrap.set_isMusic));
		L.RegVar("isAudio", new LuaCSFunction(Config_User_ConfigWrap.get_isAudio), new LuaCSFunction(Config_User_ConfigWrap.set_isAudio));
		L.RegVar("useLuQi", new LuaCSFunction(Config_User_ConfigWrap.get_useLuQi), new LuaCSFunction(Config_User_ConfigWrap.set_useLuQi));
		L.RegVar("ip", new LuaCSFunction(Config_User_ConfigWrap.get_ip), new LuaCSFunction(Config_User_ConfigWrap.set_ip));
		L.RegVar("fightStatus", new LuaCSFunction(Config_User_ConfigWrap.get_fightStatus), new LuaCSFunction(Config_User_ConfigWrap.set_fightStatus));
		L.RegVar("noticesTime", new LuaCSFunction(Config_User_ConfigWrap.get_noticesTime), new LuaCSFunction(Config_User_ConfigWrap.set_noticesTime));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Initilize(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string configContent = ToLua.CheckString(L, 1);
			User_Config.Initilize(configContent);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadConfig(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string configContent = ToLua.CheckString(L, 1);
			User_Config.LoadConfig(configContent);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetUserInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string name = ToLua.CheckString(L, 1);
			string password = ToLua.CheckString(L, 2);
			User_Config.SetUserInfo(name, password);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadGlobalSetting(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			User_Config.LoadGlobalSetting();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Save(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			User_Config.Save();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetWebServerUrl(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string webServerUrl = ToLua.CheckString(L, 1);
			User_Config.SetWebServerUrl(webServerUrl);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLoginServerInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ServerInfo loginServerInfo = (ServerInfo)ToLua.CheckObject(L, 1, typeof(ServerInfo));
			User_Config.SetLoginServerInfo(loginServerInfo);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetDefaultServer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int defaultServer = (int)LuaDLL.luaL_checknumber(L, 1);
			User_Config.SetDefaultServer(defaultServer);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadCharactorConfig(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string uid = ToLua.CheckString(L, 1);
			User_Config.LoadCharactorConfig(uid);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetBoolean(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string key = ToLua.CheckString(L, 1);
			bool boolean = User_Config.GetBoolean(key);
			LuaDLL.lua_pushboolean(L, boolean);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string key = ToLua.CheckString(L, 1);
			int @int = User_Config.GetInt(key);
			LuaDLL.lua_pushinteger(L, @int);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string key = ToLua.CheckString(L, 1);
			string @string = User_Config.GetString(key);
			LuaDLL.lua_pushstring(L, @string);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetFloat(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string key = ToLua.CheckString(L, 1);
			float @float = User_Config.GetFloat(key);
			LuaDLL.lua_pushnumber(L, (double)@float);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetBoolean(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string key = ToLua.CheckString(L, 1);
			bool value = LuaDLL.luaL_checkboolean(L, 2);
			User_Config.SetBoolean(key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetInt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string key = ToLua.CheckString(L, 1);
			int value = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.SetInt(key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetFloat(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string key = ToLua.CheckString(L, 1);
			float value = (float)LuaDLL.luaL_checknumber(L, 2);
			User_Config.SetFloat(key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string key = ToLua.CheckString(L, 1);
			string value = ToLua.CheckString(L, 2);
			User_Config.SetString(key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetServerList(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ArrayList serverList = (ArrayList)ToLua.CheckObject(L, 1, typeof(ArrayList));
			User_Config.SetServerList(serverList);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetLastServerList(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ArrayList lastServerList = (ArrayList)ToLua.CheckObject(L, 1, typeof(ArrayList));
			User_Config.SetLastServerList(lastServerList);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_web_url(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, User_Config.web_url);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_server_url(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, User_Config.server_url);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_default_server(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.default_server);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_internal_sdk(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.internal_sdk);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sdk_server_url(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, User_Config.sdk_server_url);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cdn_server_url(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, User_Config.cdn_server_url);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_resource_server(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, User_Config.resource_server);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_user_account(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, User_Config.user_account);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_user_password(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, User_Config.user_password);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gm_url(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, User_Config.gm_url);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_serverList(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, User_Config.serverList);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lastServerList(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, User_Config.lastServerList);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_recieveSystemChannel(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.recieveSystemChannel);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_recieveWorldChannel(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.recieveWorldChannel);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_recieveNearChannel(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.recieveNearChannel);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_recieveGangChannel(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.recieveGangChannel);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_recieveTeamChannel(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.recieveTeamChannel);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_recieveStrangerChannel(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.recieveStrangerChannel);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autoVoiceToText(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.autoVoiceToText);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autoPlayWorldVoice(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.autoPlayWorldVoice);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autoPlayNearVoice(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.autoPlayNearVoice);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autoPlayGangVoice(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.autoPlayGangVoice);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autoPlayTeamVoice(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.autoPlayTeamVoice);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autoPlayPrivateChatVoice(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.autoPlayPrivateChatVoice);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_blockAllianPlayer(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.blockAllianPlayer);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_blockOtherPartner(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.blockOtherPartner);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_blockOtherPlayer(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.blockOtherPlayer);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_blockOtherLingqi(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.blockOtherLingqi);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_blockOtherPet(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.blockOtherPet);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_blockMonster(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.blockMonster);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_playerScreenCount(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)User_Config.playerScreenCount);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_volumn(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)User_Config.volumn);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_quality(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.quality);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isMusic(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.isMusic);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isAudio(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.isAudio);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useLuQi(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.useLuQi);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ip(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, User_Config.ip);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fightStatus(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, User_Config.fightStatus);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_noticesTime(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, User_Config.noticesTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_web_url(IntPtr L)
	{
		int result;
		try
		{
			string web_url = ToLua.CheckString(L, 2);
			User_Config.web_url = web_url;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_server_url(IntPtr L)
	{
		int result;
		try
		{
			string server_url = ToLua.CheckString(L, 2);
			User_Config.server_url = server_url;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_default_server(IntPtr L)
	{
		int result;
		try
		{
			int default_server = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.default_server = default_server;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_internal_sdk(IntPtr L)
	{
		int result;
		try
		{
			int internal_sdk = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.internal_sdk = internal_sdk;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sdk_server_url(IntPtr L)
	{
		int result;
		try
		{
			string sdk_server_url = ToLua.CheckString(L, 2);
			User_Config.sdk_server_url = sdk_server_url;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cdn_server_url(IntPtr L)
	{
		int result;
		try
		{
			string cdn_server_url = ToLua.CheckString(L, 2);
			User_Config.cdn_server_url = cdn_server_url;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_resource_server(IntPtr L)
	{
		int result;
		try
		{
			string resource_server = ToLua.CheckString(L, 2);
			User_Config.resource_server = resource_server;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_user_account(IntPtr L)
	{
		int result;
		try
		{
			string user_account = ToLua.CheckString(L, 2);
			User_Config.user_account = user_account;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_user_password(IntPtr L)
	{
		int result;
		try
		{
			string user_password = ToLua.CheckString(L, 2);
			User_Config.user_password = user_password;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_gm_url(IntPtr L)
	{
		int result;
		try
		{
			string gm_url = ToLua.CheckString(L, 2);
			User_Config.gm_url = gm_url;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_serverList(IntPtr L)
	{
		int result;
		try
		{
			List<ServerInfo> serverList = (List<ServerInfo>)ToLua.CheckObject(L, 2, typeof(List<ServerInfo>));
			User_Config.serverList = serverList;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lastServerList(IntPtr L)
	{
		int result;
		try
		{
			List<ServerInfo> lastServerList = (List<ServerInfo>)ToLua.CheckObject(L, 2, typeof(List<ServerInfo>));
			User_Config.lastServerList = lastServerList;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_recieveSystemChannel(IntPtr L)
	{
		int result;
		try
		{
			int recieveSystemChannel = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.recieveSystemChannel = recieveSystemChannel;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_recieveWorldChannel(IntPtr L)
	{
		int result;
		try
		{
			int recieveWorldChannel = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.recieveWorldChannel = recieveWorldChannel;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_recieveNearChannel(IntPtr L)
	{
		int result;
		try
		{
			int recieveNearChannel = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.recieveNearChannel = recieveNearChannel;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_recieveGangChannel(IntPtr L)
	{
		int result;
		try
		{
			int recieveGangChannel = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.recieveGangChannel = recieveGangChannel;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_recieveTeamChannel(IntPtr L)
	{
		int result;
		try
		{
			int recieveTeamChannel = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.recieveTeamChannel = recieveTeamChannel;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_recieveStrangerChannel(IntPtr L)
	{
		int result;
		try
		{
			int recieveStrangerChannel = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.recieveStrangerChannel = recieveStrangerChannel;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autoVoiceToText(IntPtr L)
	{
		int result;
		try
		{
			int autoVoiceToText = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.autoVoiceToText = autoVoiceToText;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autoPlayWorldVoice(IntPtr L)
	{
		int result;
		try
		{
			int autoPlayWorldVoice = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.autoPlayWorldVoice = autoPlayWorldVoice;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autoPlayNearVoice(IntPtr L)
	{
		int result;
		try
		{
			int autoPlayNearVoice = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.autoPlayNearVoice = autoPlayNearVoice;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autoPlayGangVoice(IntPtr L)
	{
		int result;
		try
		{
			int autoPlayGangVoice = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.autoPlayGangVoice = autoPlayGangVoice;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autoPlayTeamVoice(IntPtr L)
	{
		int result;
		try
		{
			int autoPlayTeamVoice = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.autoPlayTeamVoice = autoPlayTeamVoice;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autoPlayPrivateChatVoice(IntPtr L)
	{
		int result;
		try
		{
			int autoPlayPrivateChatVoice = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.autoPlayPrivateChatVoice = autoPlayPrivateChatVoice;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_blockAllianPlayer(IntPtr L)
	{
		int result;
		try
		{
			int blockAllianPlayer = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.blockAllianPlayer = blockAllianPlayer;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_blockOtherPartner(IntPtr L)
	{
		int result;
		try
		{
			int blockOtherPartner = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.blockOtherPartner = blockOtherPartner;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_blockOtherPlayer(IntPtr L)
	{
		int result;
		try
		{
			int blockOtherPlayer = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.blockOtherPlayer = blockOtherPlayer;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_blockOtherLingqi(IntPtr L)
	{
		int result;
		try
		{
			int blockOtherLingqi = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.blockOtherLingqi = blockOtherLingqi;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_blockOtherPet(IntPtr L)
	{
		int result;
		try
		{
			int blockOtherPet = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.blockOtherPet = blockOtherPet;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_blockMonster(IntPtr L)
	{
		int result;
		try
		{
			int blockMonster = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.blockMonster = blockMonster;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_playerScreenCount(IntPtr L)
	{
		int result;
		try
		{
			float playerScreenCount = (float)LuaDLL.luaL_checknumber(L, 2);
			User_Config.playerScreenCount = playerScreenCount;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_volumn(IntPtr L)
	{
		int result;
		try
		{
			float volumn = (float)LuaDLL.luaL_checknumber(L, 2);
			User_Config.volumn = volumn;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_quality(IntPtr L)
	{
		int result;
		try
		{
			int quality = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.quality = quality;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isMusic(IntPtr L)
	{
		int result;
		try
		{
			int isMusic = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.isMusic = isMusic;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isAudio(IntPtr L)
	{
		int result;
		try
		{
			int isAudio = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.isAudio = isAudio;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useLuQi(IntPtr L)
	{
		int result;
		try
		{
			int useLuQi = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.useLuQi = useLuQi;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ip(IntPtr L)
	{
		int result;
		try
		{
			string ip = ToLua.CheckString(L, 2);
			User_Config.ip = ip;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fightStatus(IntPtr L)
	{
		int result;
		try
		{
			int fightStatus = (int)LuaDLL.luaL_checknumber(L, 2);
			User_Config.fightStatus = fightStatus;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_noticesTime(IntPtr L)
	{
		int result;
		try
		{
			string noticesTime = ToLua.CheckString(L, 2);
			User_Config.noticesTime = noticesTime;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
