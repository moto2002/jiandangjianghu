using Config;
using DG.Tweening;
using LuaFramework;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
	public const string Name = "StartScene";

	public ScreenResolution sr;

	public UITexture bgTex;

	private int counter;

	private bool init;

	private void Awake()
	{
		this.bgTex.mainTexture = Resources.Load<Texture2D>("Other/loginBg/ui_pic_denglu");
		Debug.Log(GetSystemInfo.Dump());
		if (SystemInfo.supports3DTextures && SystemInfo.supportsStencil > 0)
		{
			Application.backgroundLoadingPriority = ThreadPriority.High;
		}
		this.init = false;
		base.StartCoroutine(this.InitVersionAndBugly());
		this.LoadConfig();
		this.AutoAjustQualitySetting();
		this.sr.AdjustResolution();
		Debug.Log("Resolution: " + Screen.currentResolution);
		DOTween.Init(null, null, null);
		DOTween.defaultEaseType = Ease.Linear;
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer("SceneEntity"), LayerMask.NameToLayer("SceneEntity"));
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer("SceneEntity"), LayerMask.NameToLayer("TransparentBuilding"));
		if (!Directory.Exists(Util.DataPath))
		{
			Directory.CreateDirectory(Util.DataPath);
		}
	}

	private void Start()
	{
		this.counter = 0;
	}

	private void Update()
	{
		this.counter++;
		if (this.counter == 2)
		{
			this.sr.setDesignContentScale();
		}
		else if (this.counter > 4 && this.init)
		{
			SceneManager.LoadScene("UpdateScene");
		}
	}

	[DebuggerHidden]
	private IEnumerator InitVersionAndBugly()
	{
		StartScene.<InitVersionAndBugly>c__Iterator45 <InitVersionAndBugly>c__Iterator = new StartScene.<InitVersionAndBugly>c__Iterator45();
		<InitVersionAndBugly>c__Iterator.<>f__this = this;
		return <InitVersionAndBugly>c__Iterator;
	}

	private void LoadConfig()
	{
		string text = string.Empty;
		if (!Directory.Exists(Util.DataPath))
		{
			Directory.CreateDirectory(Util.DataPath);
		}
		string filePath = Util.DataPath + "/config.txt";
		if (FileManager.FileExist(filePath))
		{
			text = FileManager.ReadFileString(filePath);
		}
		else
		{
			TextAsset textAsset = Resources.Load<TextAsset>("config");
			if (textAsset == null)
			{
				MessageBox.DisplayMessageBox("游戏配置文件丢失, 无法进入游戏, 请重新下载", 0, delegate(GameObject go)
				{
					Application.Quit();
				}, null);
			}
			text = textAsset.text;
			FileManager.WriteFile(filePath, text);
		}
		User_Config.LoadConfig(text);
		User_Config.LoadGlobalSetting();
	}

	private void AutoAjustQualitySetting()
	{
	}
}
