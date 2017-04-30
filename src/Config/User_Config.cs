using LuaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ThirdParty;
using UnityEngine;

namespace Config
{
	public class User_Config
	{
		public static string web_url = string.Empty;

		private static IniFile config_file = null;

		public static string server_url = string.Empty;

		public static int default_server = 0;

		public static int internal_sdk = 0;

		public static string sdk_server_url = string.Empty;

		public static string cdn_server_url = string.Empty;

		public static string resource_server = string.Empty;

		public static string user_account = string.Empty;

		public static string user_password = string.Empty;

		public static string gm_url = string.Empty;

		public static List<ServerInfo> serverList;

		public static List<ServerInfo> lastServerList;

		public static int recieveSystemChannel = 1;

		public static int recieveWorldChannel = 1;

		public static int recieveNearChannel = 1;

		public static int recieveGangChannel = 1;

		public static int recieveTeamChannel = 1;

		public static int recieveStrangerChannel = 1;

		public static int autoVoiceToText = 0;

		public static int autoPlayWorldVoice = 0;

		public static int autoPlayNearVoice = 0;

		public static int autoPlayGangVoice = 0;

		public static int autoPlayTeamVoice = 0;

		public static int autoPlayPrivateChatVoice = 0;

		public static int blockAllianPlayer = 0;

		public static int blockOtherPartner = 0;

		public static int blockOtherPlayer = 0;

		public static int blockOtherLingqi = 0;

		public static int blockOtherPet = 0;

		public static int blockMonster = 0;

		public static float playerScreenCount = 1f;

		public static float volumn = 1f;

		public static int quality = 1;

		public static int isMusic = 1;

		public static int isAudio = 1;

		public static int useLuQi = 0;

		private static string curUid = string.Empty;

		public static string ip
		{
			get;
			set;
		}

		public static int fightStatus
		{
			get;
			set;
		}

		public static string noticesTime
		{
			get;
			set;
		}

		public static void Initilize(string configContent)
		{
			if (User_Config.config_file == null)
			{
				User_Config.config_file = new IniFile(configContent, false);
			}
		}

		public static void LoadConfig(string configContent)
		{
			User_Config.Initilize(configContent);
			if (User_Config.config_file != null && User_Config.config_file.goTo("appsetting"))
			{
				User_Config.internal_sdk = User_Config.config_file.GetValue_Int("internal_sdk", 0);
				AppConst.AppName = User_Config.config_file.GetValue_String("app_name", string.Empty);
			}
			if (User_Config.config_file != null && User_Config.config_file.goTo("download"))
			{
				User_Config.sdk_server_url = User_Config.config_file.GetValue_String("sdk_server_link", string.Empty);
				User_Config.cdn_server_url = User_Config.config_file.GetValue_String("cdn_server_link", string.Empty);
				User_Config.resource_server = User_Config.config_file.GetValue_String("resource_server", string.Empty);
			}
			if (User_Config.internal_sdk == 1)
			{
				return;
			}
			if (User_Config.config_file != null && User_Config.config_file.goTo("user"))
			{
				if (!string.IsNullOrEmpty(User_Config.config_file.GetValue_String("user_account", string.Empty)))
				{
					try
					{
						byte[] bytes = Convert.FromBase64String(User_Config.config_file.GetValue_String("user_account", string.Empty));
						User_Config.user_account = Encoding.GetString(bytes);
					}
					catch (Exception ex)
					{
						Debug.LogError("get user account error: " + ex.Message.ToString());
					}
				}
				if (!string.IsNullOrEmpty(User_Config.config_file.GetValue_String("user_password", string.Empty)))
				{
					try
					{
						byte[] bytes2 = Convert.FromBase64String(User_Config.config_file.GetValue_String("user_password", string.Empty));
						User_Config.user_password = Encoding.GetString(bytes2);
					}
					catch (Exception ex2)
					{
						Debug.LogError("get user password error: " + ex2.Message.ToString());
					}
				}
			}
			if (User_Config.config_file != null && User_Config.config_file.goTo("net"))
			{
				string value_String = User_Config.config_file.GetValue_String("server_ip", string.Empty);
				string value_String2 = User_Config.config_file.GetValue_String("server_port", string.Empty);
				User_Config.default_server = User_Config.config_file.GetValue_Int("default_serverno", 0);
				User_Config.ip = string.Format("{0}:{1}", value_String, value_String2);
				User_Config.gm_url = User_Config.config_file.GetValue_String("gm_url", string.Empty);
			}
			if (User_Config.config_file != null && User_Config.config_file.goTo("download"))
			{
				string text = User_Config.config_file.GetValue_String("server_link", string.Empty);
				if (text.IndexOf("http://") == -1 && text.IndexOf("https://") == -1)
				{
					text = "http://" + text;
				}
				User_Config.server_url = text;
			}
		}

		public static void SetUserInfo(string name, string password)
		{
			User_Config.user_account = name;
			User_Config.user_password = password;
			User_Config.config_file.SetSelctor("user");
			if (User_Config.config_file != null && User_Config.config_file.goTo("appsetting"))
			{
				User_Config.config_file.SetInt("internal_sdk", User_Config.internal_sdk);
			}
			if (User_Config.config_file != null && User_Config.config_file.goTo("user"))
			{
				if (User_Config.internal_sdk == 1)
				{
					return;
				}
				User_Config.config_file.SetString("user_account", Convert.ToBase64String(Encoding.GetBytes(name)));
				User_Config.config_file.SetString("user_password", Convert.ToBase64String(Encoding.GetBytes(password)));
			}
		}

		public static void LoadGlobalSetting()
		{
			User_Config.curUid = "gameSetting";
			if (User_Config.config_file.goTo(User_Config.curUid))
			{
				User_Config.autoPlayGangVoice = User_Config.config_file.GetValue_Int("autoPlayGangVoice", 0);
				User_Config.autoPlayTeamVoice = User_Config.config_file.GetValue_Int("autoPlayTeamVoice", 0);
				User_Config.autoPlayPrivateChatVoice = User_Config.config_file.GetValue_Int("autoPlayPrivateChatVoice", 0);
				User_Config.blockAllianPlayer = User_Config.config_file.GetValue_Int("blockAllianPlayer", 0);
				User_Config.blockOtherPartner = User_Config.config_file.GetValue_Int("blockOtherPartner", 0);
				User_Config.blockOtherPlayer = User_Config.config_file.GetValue_Int("blockOtherPlayer", 0);
				User_Config.blockOtherLingqi = User_Config.config_file.GetValue_Int("blockOtherLingqi", 0);
				User_Config.blockOtherPet = User_Config.config_file.GetValue_Int("blockOtherPet", 0);
				User_Config.blockMonster = User_Config.config_file.GetValue_Int("blockMonster", 0);
				User_Config.useLuQi = User_Config.config_file.GetValue_Int("useLuQi", 0);
				User_Config.quality = User_Config.config_file.GetValue_Int("quality", 0);
				User_Config.isMusic = User_Config.config_file.GetValue_Int("isMusic", 0);
				User_Config.isAudio = User_Config.config_file.GetValue_Int("isAudio", 0);
				User_Config.playerScreenCount = User_Config.config_file.GetValue_Float("playerScreenCount", 0f);
				User_Config.volumn = User_Config.config_file.GetValue_Float("volumn", 0f);
				User_Config.noticesTime = User_Config.config_file.GetValue_String("noticesTime", string.Empty);
			}
			else
			{
				User_Config.config_file.SetSelctor(User_Config.curUid);
				User_Config.config_file.SetInt("autoPlayGangVoice", 0);
				User_Config.config_file.SetInt("autoPlayTeamVoice", 0);
				User_Config.config_file.SetInt("autoPlayPrivateChatVoice", 0);
				User_Config.config_file.SetInt("showJingjiWings", 1);
				User_Config.config_file.SetInt("blockAllianPlayer", 0);
				User_Config.config_file.SetInt("blockOtherPartner", 0);
				User_Config.config_file.SetInt("blockOtherPlayer", 0);
				User_Config.config_file.SetInt("blockOtherLingqi", 0);
				User_Config.config_file.SetInt("blockOtherPet", 0);
				User_Config.config_file.SetInt("blockMonster", 0);
				User_Config.config_file.SetInt("quality", 1);
				User_Config.config_file.SetInt("isMusic", 1);
				User_Config.config_file.SetInt("isAudio", 1);
				User_Config.config_file.SetFloat("playerScreenCount", 1f);
				User_Config.config_file.SetFloat("volumn", 1f);
				User_Config.config_file.SetInt("useLuQi", 0);
				User_Config.config_file.SetString("noticesTime", "0");
				User_Config.Save();
			}
		}

		public static void Save()
		{
			if (User_Config.config_file != null)
			{
				File.WriteAllText(Util.DataPath + "config.txt", User_Config.config_file.ToString());
			}
		}

		public static void SetWebServerUrl(string url)
		{
			User_Config.web_url = Path.Combine(url, LuaConst.osDir);
			if (User_Config.config_file != null && User_Config.config_file.goTo("download"))
			{
				User_Config.config_file.SetString("web_server", url);
			}
		}

		public static void SetLoginServerInfo(ServerInfo serverInfo)
		{
			if (User_Config.internal_sdk == 1)
			{
				return;
			}
			if (User_Config.config_file != null && User_Config.config_file.goTo("net"))
			{
				User_Config.config_file.SetString("server_ip", serverInfo.serverIp);
				User_Config.config_file.SetString("server_port", serverInfo.serverPort);
				User_Config.ip = string.Format("{0}:{1}", serverInfo.serverIp, serverInfo.serverPort);
				User_Config.default_server = serverInfo.serverNo;
				User_Config.config_file.SetString("default_serverno", serverInfo.serverNo.ToString());
			}
		}

		public static void SetDefaultServer(int serverNo)
		{
			if (User_Config.default_server > 0)
			{
				return;
			}
			User_Config.default_server = serverNo;
		}

		public static void LoadCharactorConfig(string uid)
		{
			User_Config.curUid = uid;
			if (User_Config.config_file.goTo(uid))
			{
				User_Config.recieveSystemChannel = User_Config.config_file.GetValue_Int("recieveSystemChannel", 0);
				User_Config.recieveWorldChannel = User_Config.config_file.GetValue_Int("recieveWorldChannel", 0);
				User_Config.recieveNearChannel = User_Config.config_file.GetValue_Int("recieveNearChannel", 0);
				User_Config.recieveGangChannel = User_Config.config_file.GetValue_Int("recieveGangChannel", 0);
				User_Config.recieveTeamChannel = User_Config.config_file.GetValue_Int("recieveTeamChannel", 0);
				User_Config.recieveStrangerChannel = User_Config.config_file.GetValue_Int("recieveStrangerChannel", 0);
				User_Config.autoVoiceToText = User_Config.config_file.GetValue_Int("autoVoiceToText", 0);
				User_Config.autoPlayWorldVoice = User_Config.config_file.GetValue_Int("autoPlayWorldVoice", 0);
				User_Config.autoPlayNearVoice = User_Config.config_file.GetValue_Int("autoPlayNearVoice", 0);
			}
			else
			{
				User_Config.config_file.SetSelctor(uid);
				User_Config.config_file.SetInt("recieveSystemChannel", 1);
				User_Config.config_file.SetInt("recieveWorldChannel", 1);
				User_Config.config_file.SetInt("recieveNearChannel", 1);
				User_Config.config_file.SetInt("recieveGangChannel", 1);
				User_Config.config_file.SetInt("recieveTeamChannel", 1);
				User_Config.config_file.SetInt("recieveStrangerChannel", 1);
				User_Config.config_file.SetInt("autoVoiceToText", 0);
				User_Config.config_file.SetInt("autoPlayWorldVoice", 0);
				User_Config.config_file.SetInt("autoPlayNearVoice", 0);
				User_Config.Save();
			}
		}

		public static bool GetBoolean(string key)
		{
			return User_Config.config_file.goTo(User_Config.curUid) && User_Config.config_file.GetValue_Int(key, 0) == 1;
		}

		public static int GetInt(string key)
		{
			if (User_Config.config_file.goTo(User_Config.curUid))
			{
				return User_Config.config_file.GetValue_Int(key, 0);
			}
			return 0;
		}

		public static string GetString(string key)
		{
			if (User_Config.config_file.goTo(User_Config.curUid))
			{
				return User_Config.config_file.GetValue_String(key, string.Empty);
			}
			return string.Empty;
		}

		public static float GetFloat(string key)
		{
			if (User_Config.config_file.goTo(User_Config.curUid))
			{
				return User_Config.config_file.GetValue_Float(key, 0f);
			}
			return 0f;
		}

		public static void SetBoolean(string key, bool value)
		{
			if (User_Config.config_file.goTo(User_Config.curUid))
			{
				User_Config.config_file.SetInt(key, (!value) ? 0 : 1);
			}
		}

		public static void SetInt(string key, int value)
		{
			if (User_Config.config_file.goTo(User_Config.curUid))
			{
				User_Config.config_file.SetInt(key, value);
			}
		}

		public static void SetFloat(string key, float value)
		{
			if (User_Config.config_file.goTo(User_Config.curUid))
			{
				User_Config.config_file.SetFloat(key, value);
			}
		}

		public static void SetString(string key, string value)
		{
			if (User_Config.config_file.goTo(User_Config.curUid))
			{
				User_Config.config_file.SetString(key, value);
			}
		}

		public static void SetServerList(ArrayList list)
		{
			if (User_Config.serverList == null)
			{
				User_Config.serverList = new List<ServerInfo>();
			}
			User_Config.serverList.AddRange(User_Config.GetServerList(list));
			User_Config.serverList.Sort((ServerInfo x, ServerInfo y) => x.openTime.CompareTo(y.openTime) * -1);
		}

		public static void SetLastServerList(ArrayList list)
		{
			if (User_Config.lastServerList == null)
			{
				User_Config.lastServerList = new List<ServerInfo>();
			}
			User_Config.lastServerList.AddRange(User_Config.GetServerList(list));
			User_Config.lastServerList.Sort((ServerInfo x, ServerInfo y) => x.openTime.CompareTo(y.openTime) * -1);
		}

		private static List<ServerInfo> GetServerList(ArrayList list)
		{
			List<ServerInfo> list2 = new List<ServerInfo>();
			for (int i = 0; i < list.Count; i++)
			{
				Hashtable hashtable = list[i] as Hashtable;
				ServerInfo serverInfo = new ServerInfo();
				if (hashtable.ContainsKey("sid"))
				{
					serverInfo.serverNo = int.Parse(hashtable["sid"].ToString());
				}
				if (hashtable.ContainsKey("name"))
				{
					serverInfo.serverName = hashtable["name"].ToString();
				}
				if (hashtable.ContainsKey("addr"))
				{
					serverInfo.serverIp = hashtable["addr"].ToString();
				}
				if (hashtable.ContainsKey("port"))
				{
					serverInfo.serverPort = hashtable["port"].ToString();
				}
				if (hashtable.ContainsKey("status"))
				{
					serverInfo.status = int.Parse(hashtable["status"].ToString());
				}
				if (hashtable.ContainsKey("isNew"))
				{
					serverInfo.isNew = int.Parse(hashtable["isNew"].ToString());
				}
				if (hashtable.ContainsKey("openTime"))
				{
					serverInfo.openTime = int.Parse(hashtable["openTime"].ToString());
				}
				if (hashtable.ContainsKey("playerLevel"))
				{
					serverInfo.playerLevel = int.Parse(hashtable["roleLv"].ToString());
				}
				list2.Add(serverInfo);
			}
			return list2;
		}
	}
}
