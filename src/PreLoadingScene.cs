using Config;
using LuaFramework;
using System;
using System.Collections;
using System.Diagnostics;
using ThirdParty;
using UnityEngine;

public class PreLoadingScene : MonoBehaviour
{
	public static bool inPreloading;

	public static string next_scene;

	public GameObject loadingCanvas;

	public Camera loadingCamera;

	public UISlider loadingBar;

	public UILabel tipsLabel;

	public UITexture bg;

	public UITexture progressBg;

	private AssetBundleCreateRequest abcr;

	private static int curIndex;

	private void Start()
	{
		PreLoadingScene.inPreloading = true;
		this.progressBg.mainTexture = Resources.Load<Texture2D>("Other/loading/ui_loading_01");
		if (PreLoadingScene.curIndex == 0)
		{
			PreLoadingScene.curIndex = UnityEngine.Random.Range(1, 3);
		}
		if (PreLoadingScene.curIndex > 3)
		{
			PreLoadingScene.curIndex = 1;
		}
		this.bg.mainTexture = Resources.Load<Texture2D>(string.Format("Other/loading/loading{0}", PreLoadingScene.curIndex));
		PreLoadingScene.curIndex++;
		this.loadingCamera.gameObject.SetActive(true);
		Util.CallMethod("Game", "SetPreloadingTips", new object[]
		{
			this.tipsLabel
		});
		base.StartCoroutine(this.PreloadInMobile());
		UnityEngine.Object.DontDestroyOnLoad(this.loadingCanvas);
		if (User_Config.internal_sdk == 1)
		{
			CenterServerManager.Instance.StepLogRequest(5);
		}
	}

	[DebuggerHidden]
	private IEnumerator PreloadInPC()
	{
		return new PreLoadingScene.<PreloadInPC>c__Iterator43();
	}

	[DebuggerHidden]
	private IEnumerator PreloadInMobile()
	{
		PreLoadingScene.<PreloadInMobile>c__Iterator44 <PreloadInMobile>c__Iterator = new PreLoadingScene.<PreloadInMobile>c__Iterator44();
		<PreloadInMobile>c__Iterator.<>f__this = this;
		return <PreloadInMobile>c__Iterator;
	}

	private void Update()
	{
		if (this.loadingCamera != null && !this.loadingCamera.gameObject.activeSelf)
		{
			this.loadingCamera.gameObject.SetActive(true);
		}
		if (Singleton<RoleManager>.Instance.ao != null)
		{
			if (Singleton<RoleManager>.Instance.ao.progress > 0.85f)
			{
				Singleton<RoleManager>.Instance.ao.allowSceneActivation = true;
				this.loadingBar.value = 1f;
			}
			else
			{
				this.loadingBar.value = Singleton<RoleManager>.Instance.ao.progress;
			}
		}
	}

	private void OnDestroy()
	{
		if (this.abcr != null)
		{
			this.abcr = null;
		}
	}

	public static void DestroySelf()
	{
		PreLoadingScene.inPreloading = false;
		PreLoadingScene.next_scene = string.Empty;
		GameObject obj = GameObject.Find("PreLoading");
		if (Singleton<RoleManager>.Instance.sceneAsset != null)
		{
			Singleton<RoleManager>.Instance.sceneAsset.Unload(false);
			Singleton<RoleManager>.Instance.sceneAsset = null;
		}
		UnityEngine.Object.Destroy(obj);
	}
}
