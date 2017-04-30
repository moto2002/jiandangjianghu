using Config;
using LuaFramework;
using LuaInterface;
using MiniJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ThirdParty;
using UnityEngine;

public class UpdateScene : MonoBehaviour
{
	public delegate void ClickEvent();

	public static UpdateScene Instance;

	public UILabel showInfo;

	public UITexture progress;

	public UITexture bgTex;

	public UpdateScene.ClickEvent clickEvent;

	private string _serverInfo;

	private int _getCount;

	private bool beginFlash;

	private bool alphaInc;

	private void Awake()
	{
		UpdateScene.Instance = this;
		this.bgTex.mainTexture = Resources.Load<Texture2D>("Other/loginBg/ui_pic_denglu");
		this.progress.mainTexture = Resources.Load<Texture2D>("Other/loading/ui_loading_01");
		UIEventListener.Get(this.bgTex.gameObject).onClick = new UIEventListener.VoidDelegate(this.OnBackgroundClicked);
	}

	private void Start()
	{
		if (Debug.isDebugBuild)
		{
			Singleton<Fps>.Instance.Init();
		}
		Loom.Initialize();
		this.progress.fillAmount = 0f;
		base.gameObject.AddComponent<Main>();
	}

	private void Update()
	{
		if (this.beginFlash)
		{
			Color color = this.showInfo.color;
			if (!this.alphaInc)
			{
				color.a -= Time.deltaTime * 0.8f;
				this.showInfo.color = color;
				if ((double)color.a <= 0.2)
				{
					this.alphaInc = true;
				}
			}
			else
			{
				color.a += Time.deltaTime * 0.8f;
				this.showInfo.color = color;
				if (color.a >= 1f)
				{
					this.alphaInc = false;
				}
			}
		}
	}

	private void OnBackgroundClicked(GameObject go)
	{
		if (this.clickEvent != null)
		{
			this.clickEvent();
		}
		this.clickEvent = null;
		Debugger.Log("click background");
	}

	public void CheckServerInfo()
	{
		this.progress.fillAmount = 0f;
		this.showInfo.text = "正在连接服务器";
		if (User_Config.internal_sdk == 1)
		{
			base.StartCoroutine(this.StartSDK());
		}
		else
		{
			base.StartCoroutine(this.GetServerInfoByHttp());
		}
	}

	[DebuggerHidden]
	private IEnumerator StartSDK()
	{
		return new UpdateScene.<StartSDK>c__Iterator46();
	}

	[DebuggerHidden]
	private IEnumerator GetServerInfoByHttp()
	{
		UpdateScene.<GetServerInfoByHttp>c__Iterator47 <GetServerInfoByHttp>c__Iterator = new UpdateScene.<GetServerInfoByHttp>c__Iterator47();
		<GetServerInfoByHttp>c__Iterator.<>f__this = this;
		return <GetServerInfoByHttp>c__Iterator;
	}

	private bool SetServerInfo()
	{
		Hashtable hashtable = Json.Deserialize(this._serverInfo) as Hashtable;
		if (hashtable == null)
		{
			Debug.LogError("Get server list error: " + this._serverInfo);
			return false;
		}
		User_Config.SetWebServerUrl(hashtable["update_url"].ToString());
		User_Config.SetDefaultServer(Convert.ToInt32(hashtable["recommend_no"]));
		if (User_Config.serverList == null)
		{
			User_Config.serverList = new List<ServerInfo>();
		}
		ArrayList arrayList = hashtable["serverlist"] as ArrayList;
		int count = arrayList.Count;
		for (int i = 0; i < count; i++)
		{
			Hashtable hashtable2 = arrayList[i] as Hashtable;
			ServerInfo serverInfo = new ServerInfo();
			serverInfo.openTime = i;
			serverInfo.serverNo = Convert.ToInt32(hashtable2["server_no"].ToString());
			serverInfo.serverName = hashtable2["server_name"].ToString();
			serverInfo.serverIp = hashtable2["ip"].ToString();
			serverInfo.serverPort = hashtable2["port"].ToString();
			serverInfo.isOpen = Convert.ToInt32(hashtable2["is_open"].ToString());
			serverInfo.other = hashtable2["other"].ToString();
			User_Config.serverList.Add(serverInfo);
		}
		User_Config.serverList.Sort((ServerInfo x, ServerInfo y) => x.openTime.CompareTo(y.openTime) * -1);
		return true;
	}

	public void UpdateProgress(float value)
	{
		this.progress.fillAmount = value;
	}

	public void SetMessage(string message, bool flash = false)
	{
		this.showInfo.text = message;
		this.showInfo.color = new Color(1f, 1f, 1f, 1f);
		this.beginFlash = flash;
	}

	private void OnDestroy()
	{
		UpdateScene.Instance = null;
	}
}
