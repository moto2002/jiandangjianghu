using Config;
using LuaFramework;
using LuaInterface;
using MiniJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class CenterServerManager
{
	private static CenterServerManager instance;

	private string url = "http://xyfyapi.firedg.com/api.php";

	private string cdnUrl = "http://xyfyapi.firedg.com/cdnApi.php";

	private int appID = 74;

	private int channelID;

	private string userID = string.Empty;

	private string token = string.Empty;

	private string imeiOrIdfa = string.Empty;

	private string method = string.Empty;

	private int pid;

	private string sign = string.Empty;

	private string time = string.Empty;

	private string accountName = string.Empty;

	private ArrayList lastServer;

	private ArrayList serverList;

	private bool showAccount = true;

	private bool versionView = true;

	private string access_token = string.Empty;

	private string accName;

	private int channel_id;

	private int sid;

	private string serverName = string.Empty;

	private string mac;

	private string version = string.Empty;

	private string packageUrl = string.Empty;

	private string ip = string.Empty;

	public static CenterServerManager Instance
	{
		get
		{
			if (CenterServerManager.instance == null)
			{
				CenterServerManager.instance = new CenterServerManager();
				CenterServerManager.instance.Init();
			}
			return CenterServerManager.instance;
		}
	}

	private string os
	{
		get
		{
			string empty = string.Empty;
			return "android";
		}
	}

	public int AppID
	{
		get
		{
			return this.appID;
		}
	}

	public int ChannelID
	{
		get
		{
			return this.channelID;
		}
		set
		{
			this.channelID = value;
		}
	}

	public string UserID
	{
		get
		{
			return this.userID;
		}
		set
		{
			this.userID = value;
		}
	}

	public string Token
	{
		get
		{
			return this.token;
		}
		set
		{
			this.token = value;
		}
	}

	public string ImeiOrIdfa
	{
		get
		{
			return SystemInfo.deviceUniqueIdentifier;
		}
	}

	public string Method
	{
		get
		{
			return this.method;
		}
		set
		{
			this.method = value;
		}
	}

	public int Pid
	{
		get
		{
			return this.pid;
		}
		set
		{
			this.pid = value;
		}
	}

	public string Sign
	{
		get
		{
			return CenterServerManager.StringToMD5(this.Pid + this.Method + "firedg!@#51000-+Bylelong");
		}
	}

	public string Time
	{
		get
		{
			return this.time;
		}
		set
		{
			this.time = value;
		}
	}

	public string AccountName
	{
		get
		{
			return this.accountName;
		}
		set
		{
			this.accountName = value;
		}
	}

	public ArrayList LastServer
	{
		get
		{
			return this.lastServer;
		}
		set
		{
			this.lastServer = value;
		}
	}

	public ArrayList ServerList
	{
		get
		{
			return this.serverList;
		}
		set
		{
			this.serverList = value;
		}
	}

	public bool ShowAccount
	{
		get
		{
			return this.showAccount;
		}
		set
		{
			this.showAccount = value;
		}
	}

	public bool VersionView
	{
		get
		{
			return this.versionView;
		}
		set
		{
			this.versionView = value;
		}
	}

	public string Access_token
	{
		get
		{
			return this.access_token;
		}
		set
		{
			this.access_token = value;
		}
	}

	public string AccName
	{
		get
		{
			return this.accName;
		}
		set
		{
			this.accName = value;
		}
	}

	public int Channel_id
	{
		get
		{
			return this.channel_id;
		}
		set
		{
			this.channel_id = value;
		}
	}

	public int Sid
	{
		get
		{
			return this.sid;
		}
		set
		{
			this.sid = value;
		}
	}

	public string ServerName
	{
		get
		{
			return this.serverName;
		}
		set
		{
			this.serverName = value;
		}
	}

	public string Mac
	{
		get
		{
			return this.mac;
		}
		set
		{
			this.mac = value;
		}
	}

	public string Version
	{
		get
		{
			return this.version;
		}
		set
		{
			this.version = value;
		}
	}

	public string PackageUrl
	{
		get
		{
			return this.packageUrl;
		}
		set
		{
			this.packageUrl = value;
		}
	}

	public string Ip
	{
		get
		{
			return this.ip;
		}
		set
		{
			this.ip = value;
		}
	}

	private void Init()
	{
		if (!string.IsNullOrEmpty(User_Config.sdk_server_url))
		{
			CenterServerManager.instance.url = User_Config.sdk_server_url;
		}
		if (!string.IsNullOrEmpty(User_Config.cdn_server_url))
		{
			CenterServerManager.instance.cdnUrl = User_Config.cdn_server_url;
		}
	}

	private void HttpRequest(string data, Action<string> callback)
	{
		this.HttpPost(this.url, data, callback);
	}

	private void HttpPost(string Url, string postDataStr, Action<string> callBack)
	{
		PanelManager manager = AppFacade.Instance.GetManager<PanelManager>("PanelManager");
		manager.StartCoroutine(this.requestPost(Url, postDataStr, callBack));
	}

	[DebuggerHidden]
	private IEnumerator requestPost(string url, string postDataStr, Action<string> callBack)
	{
		CenterServerManager.<requestPost>c__Iterator41 <requestPost>c__Iterator = new CenterServerManager.<requestPost>c__Iterator41();
		<requestPost>c__Iterator.url = url;
		<requestPost>c__Iterator.postDataStr = postDataStr;
		<requestPost>c__Iterator.callBack = callBack;
		<requestPost>c__Iterator.<$>url = url;
		<requestPost>c__Iterator.<$>postDataStr = postDataStr;
		<requestPost>c__Iterator.<$>callBack = callBack;
		return <requestPost>c__Iterator;
	}

	private static string StringToMD5(string str)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(str);
		MD5 mD = new MD5CryptoServiceProvider();
		byte[] array = mD.ComputeHash(bytes);
		string text = string.Empty;
		for (int i = 0; i < array.Length; i++)
		{
			text += array[i].ToString("x2");
		}
		return text;
	}

	public void LoginRequest(Action callback)
	{
		string text = string.Join("&", new List<string>
		{
			"appID=" + this.appID.ToString(),
			"channelID=" + this.ChannelID.ToString(),
			"userID=" + this.UserID,
			"token=" + this.Token,
			"imeiOrIdfa=" + this.ImeiOrIdfa,
			"method=login",
			"pid=" + this.Pid.ToString(),
			"sign=" + this.Sign
		}.ToArray());
		Debug.Log("用户登录接口: " + text);
		this.HttpRequest(text, delegate(string result)
		{
			this.LoginCallback(result);
			callback();
		});
	}

	private void LoginCallback(string result)
	{
		Debug.Log("用户登录接口回调: " + result);
		object obj = Json.Deserialize(result);
		if (obj != null)
		{
			Hashtable hashtable = obj as Hashtable;
			if (hashtable.ContainsKey("errorCode"))
			{
				int num = int.Parse(hashtable["errorCode"].ToString());
				if (num != 0)
				{
					Debug.LogError("errorCode: " + num);
					MessageBox.DisplayMessageBox("中央服访问失败errorCode：" + num, 0, null, null);
					return;
				}
			}
			if (hashtable.ContainsKey("data"))
			{
				Hashtable hashtable2 = hashtable["data"] as Hashtable;
				if (hashtable2.ContainsKey("time"))
				{
					this.time = hashtable2["time"].ToString();
				}
				if (hashtable2.ContainsKey("token"))
				{
					this.token = hashtable2["token"].ToString();
				}
				if (hashtable2.ContainsKey("accountName"))
				{
					this.accountName = hashtable2["accountName"].ToString();
				}
				if (hashtable2.ContainsKey("lastServer"))
				{
					this.lastServer = (hashtable2["lastServer"] as ArrayList);
					User_Config.SetLastServerList(this.lastServer);
				}
				if (hashtable2.ContainsKey("serverList"))
				{
					this.serverList = (hashtable2["serverList"] as ArrayList);
					User_Config.SetServerList(this.serverList);
				}
				if (hashtable2.ContainsKey("showAccount"))
				{
					this.showAccount = bool.Parse(hashtable2["showAccount"].ToString());
				}
				if (hashtable2.ContainsKey("versionView"))
				{
					this.versionView = bool.Parse(hashtable2["versionView"].ToString());
				}
				if (hashtable2.ContainsKey("access_token"))
				{
					this.access_token = hashtable2["access_token"].ToString();
				}
			}
		}
	}

	public void StepLogRequest(int stepFlag)
	{
		string text = string.Join("&", new List<string>
		{
			"accName=" + this.UserID,
			"sid=" + this.Sid,
			"channel_id=" + this.Channel_id,
			"stepFlag=" + stepFlag,
			"method=clientStepLog",
			"pid=" + this.Pid,
			"sign=" + this.Sign
		}.ToArray());
		Debug.Log("登录打点接口: " + text);
		this.HttpRequest(text, delegate(string result)
		{
		});
	}

	public void LoginInfoLog(string nickname)
	{
		string text = string.Join("&", new List<string>
		{
			"accName=" + this.AccName,
			"sid=" + this.Sid.ToString(),
			"mac=" + this.Mac,
			"imeiOrIdfa=" + this.ImeiOrIdfa,
			"channel_id=" + this.Channel_id.ToString(),
			"nickname=" + nickname,
			"method=loginInfoLog",
			"pid=" + this.Pid.ToString(),
			"sign=" + this.Sign
		}.ToArray());
		Debug.Log("登录日志接口: " + text);
		this.HttpRequest(text, delegate(string result)
		{
		});
	}

	public void GetNoticeInfo(Action<string> callback)
	{
		string text = string.Join("&", new List<string>
		{
			"method=getNoticeInfo",
			"pid=" + this.Pid.ToString(),
			"sign=" + this.Sign
		}.ToArray());
		Debug.Log("公告参数：" + text);
		this.HttpRequest(text, delegate(string result)
		{
			Debug.Log("获取公告信息: " + result);
			object obj = Json.Deserialize(result);
			if (obj != null)
			{
				Hashtable hashtable = obj as Hashtable;
				if (hashtable.ContainsKey("errorCode"))
				{
					int num = int.Parse(hashtable["errorCode"].ToString());
					if (num != 0)
					{
						Debug.LogError("errorCode: " + num);
						callback(string.Empty);
						return;
					}
				}
				if (hashtable.ContainsKey("data"))
				{
					Hashtable hashtable2 = hashtable["data"] as Hashtable;
					if (hashtable2.ContainsKey("data"))
					{
						string obj2 = Json.Serialize(hashtable2["data"]);
						callback(obj2);
					}
				}
			}
		});
	}

	public void ChatMonitor(string nickName, string roleId, string msg)
	{
		try
		{
			string text = string.Join("&", new List<string>
			{
				"accName=" + this.AccName,
				"sid=" + this.Sid,
				"nickname=" + nickName,
				"roleid=" + roleId,
				"msg=" + msg,
				"method=chatMonitor",
				"pid=" + this.Pid,
				"sign=" + this.Sign
			}.ToArray());
			Debug.Log("聊天监控接口: " + text);
			this.HttpRequest(text, delegate(string result)
			{
			});
		}
		catch (Exception ex)
		{
			Debug.Log(ex.Message);
		}
	}

	public void SetLastServer()
	{
		string text = string.Join("&", new List<string>
		{
			"accName=" + this.AccName,
			"sid=" + this.Sid,
			"method=setLastServer",
			"pid=" + this.Pid,
			"sign=" + this.Sign
		}.ToArray());
		Debug.Log("设置最后登录服务器: " + text);
		this.HttpRequest(text, delegate(string result)
		{
		});
	}

	public void GetCdnData(string curVersion, Action<string, string> callback)
	{
		string text = string.Join("&", new List<string>
		{
			"version=" + curVersion,
			"os=" + this.os,
			"imei=" + this.ImeiOrIdfa
		}.ToArray());
		Debug.Log("获取cdn数据: " + text);
		this.HttpPost(this.cdnUrl, text, delegate(string result)
		{
			object obj = Json.Deserialize(result);
			if (obj != null)
			{
				Hashtable hashtable = obj as Hashtable;
				if (hashtable.ContainsKey("version"))
				{
					this.version = hashtable["version"].ToString();
				}
				if (hashtable.ContainsKey("packageUrl"))
				{
					this.packageUrl = hashtable["packageUrl"].ToString();
				}
			}
			callback(this.version, this.packageUrl);
		});
	}

	public void CreateRoleInfo(string name, int level, string roleId, int vip)
	{
		string text = string.Join("&", new List<string>
		{
			"regTime=" + DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss"),
			"accounts=" + this.ChannelID,
			"nickName=" + name,
			"roleLevel=" + level,
			"method=roleInfoLog",
			"pid=" + this.Pid,
			"role_id=" + roleId,
			"serverId=" + this.Sid,
			"ip=" + this.Ip,
			"vipLevel=" + vip,
			"sign=" + this.Sign
		}.ToArray());
		Debug.Log("创建角色信息接口: " + text);
		this.HttpRequest(text, delegate(string result)
		{
		});
	}

	public void UpgradeInfo(string name, int level)
	{
		string text = string.Join("&", new List<string>
		{
			"accounts=" + this.ChannelID,
			"nickName=" + name,
			"roleLevel=" + level,
			"serverId=" + this.Sid,
			"updateTime=" + DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss"),
			"method=upgradeInfoLog",
			"pid=" + this.Pid,
			"sign=" + this.Sign
		}.ToArray());
		Debug.Log("升级记录接口: " + text);
		this.HttpRequest(text, delegate(string result)
		{
		});
	}

	public void UpdateRoleInfo(string name, int level, int vip, string newName)
	{
		string text = string.Join("&", new List<string>
		{
			"accounts=" + this.ChannelID,
			"nickName=" + name,
			"roleLevel=" + level,
			"serverId=" + this.Sid,
			"vipLv=" + vip,
			"newNickName=" + newName,
			"pid=" + this.Pid,
			"sign=" + this.Sign
		}.ToArray());
		Debug.Log("更新角色信息接口: " + text);
		this.HttpRequest(text, delegate(string result)
		{
		});
	}

	[NoToLua]
	public void UpdateLogin()
	{
		string text = string.Join("&", new List<string>
		{
			"accounts=" + this.ChannelID,
			"serverId=" + this.Sid,
			"onlineSecs=" + Mathf.CeilToInt(UnityEngine.Time.realtimeSinceStartup),
			"method=updateLoginLog",
			"pid=" + this.Pid,
			"sign=" + this.Sign
		}.ToArray());
		Debug.Log("用户退出时记录在线时长接口: " + text);
		this.HttpRequest(text, delegate(string result)
		{
		});
	}

	public static string SignGM(string userId, int serverNo, int time)
	{
		return CenterServerManager.StringToMD5(string.Format("game={0}userid={1}serverno={2}time={3}key=8qld2rmd1d2zjc8u", new object[]
		{
			AppConst.AppName,
			userId,
			serverNo,
			time
		}));
	}
}
