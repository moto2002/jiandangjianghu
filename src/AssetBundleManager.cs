using LuaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ThirdParty;
using UnityEngine;

public class AssetBundleManager : Singleton<AssetBundleManager>
{
	public delegate void OnProgressChanged(float value);

	private const float MAXDELAY_CLEAR_TIME = 300f;

	public List<string> bundleInDownload = new List<string>();

	public Dictionary<string, BundleInfo> bundleLoaded = new Dictionary<string, BundleInfo>();

	public Dictionary<string, string> assetbundleMap = new Dictionary<string, string>();

	private Dictionary<string, List<GameObject>> assetIntances = new Dictionary<string, List<GameObject>>();

	public AssetBundleManager.OnProgressChanged onProgressChange;

	private List<string> preloadAssets;

	private AssetBundleCreateRequest preloadAbcr;

	private int curIndex;

	private float delayClearTime;

	public AssetBundleManifest allBundleManifest
	{
		get;
		private set;
	}

	public void AssetBundleInit(Action callback)
	{
		this.ResetClearTime();
		this.LoadAssetbundleMap();
		this.LoadManifest();
		base.StartCoroutine(this.PreloadAsset(callback));
	}

	private void LoadAssetbundleMap()
	{
		byte[] buf = File.ReadAllBytes(Util.DataPath + "/bundlemap.ab");
		string[] array = Encoding.GetString(Crypto.Decode(buf)).Split(new char[]
		{
			'\n'
		});
		this.preloadAssets = new List<string>();
		for (int i = 0; i < array.Length; i++)
		{
			if (!string.IsNullOrEmpty(array[i]))
			{
				string[] array2 = array[i].Split(new char[]
				{
					'|'
				});
				if (this.assetbundleMap.ContainsKey(array2[0]))
				{
					Debug.LogError(string.Format("{0} is already exists", array2[0]));
					throw new ArgumentException();
				}
				this.assetbundleMap.Add(array2[0], array2[1]);
				if (array2[2] == "1" && !this.preloadAssets.Contains(array2[1]))
				{
					this.preloadAssets.Add(array2[1]);
				}
			}
		}
	}

	private void LoadManifest()
	{
		string text = string.Format("{0}/{1}.ab", Util.DataPath, LuaConst.osDir);
		if (!File.Exists(text))
		{
			Debug.LogError("no manifest file exists in " + text);
			return;
		}
		AssetBundle assetBundle = AssetBundle.LoadFromFile(text);
		if (assetBundle)
		{
			this.allBundleManifest = (assetBundle.LoadAsset("AssetBundleManifest") as AssetBundleManifest);
			assetBundle.Unload(false);
			string[] allAssetBundles = this.allBundleManifest.GetAllAssetBundles();
			for (int i = 0; i < allAssetBundles.Length; i++)
			{
				if (this.preloadAssets.Contains(allAssetBundles[i]))
				{
					string[] allDependencies = this.allBundleManifest.GetAllDependencies(allAssetBundles[i]);
					for (int j = 0; j < allDependencies.Length; j++)
					{
						if (!this.preloadAssets.Contains(allDependencies[j]))
						{
							this.preloadAssets.Add(allDependencies[j]);
						}
					}
					if (!this.preloadAssets.Contains(allAssetBundles[i]))
					{
						this.preloadAssets.Add(allAssetBundles[i]);
					}
				}
			}
		}
	}

	[DebuggerHidden]
	public IEnumerator PreloadAsset(Action callback)
	{
		AssetBundleManager.<PreloadAsset>c__Iterator31 <PreloadAsset>c__Iterator = new AssetBundleManager.<PreloadAsset>c__Iterator31();
		<PreloadAsset>c__Iterator.callback = callback;
		<PreloadAsset>c__Iterator.<$>callback = callback;
		<PreloadAsset>c__Iterator.<>f__this = this;
		return <PreloadAsset>c__Iterator;
	}

	private void Update()
	{
		if (this.preloadAbcr != null && this.onProgressChange != null)
		{
			this.onProgressChange(((float)(this.curIndex + 1) + this.preloadAbcr.progress) / (float)this.preloadAssets.Count);
		}
		this.delayClearTime -= Time.deltaTime;
		if (Input.GetMouseButton(0) || Input.touchCount > 0)
		{
			this.ResetClearTime();
		}
		if (this.delayClearTime <= 0f)
		{
			Debug.Log("Auto clear bundle");
			this.Clear();
		}
	}

	public AssetBundle TryToGetBundle(string name)
	{
		AssetBundle assetBundle = null;
		try
		{
			name = name.ToLower();
			if (!this.assetbundleMap.ContainsKey(name))
			{
				Debug.LogWarning(string.Format("{0} has no assetbundle resource", name));
			}
			else
			{
				string text = this.assetbundleMap[name];
				if (this.bundleLoaded.ContainsKey(text))
				{
					assetBundle = this.bundleLoaded[text].bundle;
				}
				else
				{
					if (this.bundleInDownload.Contains(text))
					{
						throw new Exception(string.Format("资源正在异步加载中: {0}", text));
					}
					string[] allDependencies = this.allBundleManifest.GetAllDependencies(text);
					for (int i = 0; i < allDependencies.Length; i++)
					{
						if (this.bundleLoaded.ContainsKey(allDependencies[i]))
						{
							this.bundleLoaded[allDependencies[i]].refCount++;
						}
						else if (!this.bundleInDownload.Contains(allDependencies[i]))
						{
							AssetBundle bundle = AssetBundle.LoadFromFile(Util.DataPath + allDependencies[i]);
							this.bundleLoaded.Add(allDependencies[i], new BundleInfo(bundle, allDependencies[i]));
						}
					}
					string path = Util.DataPath + text;
					if (File.Exists(path))
					{
						assetBundle = AssetBundle.LoadFromFile(path);
						this.bundleLoaded.Add(text, new BundleInfo(assetBundle, text));
					}
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Format("Get Assetbundle Exception: {0}, Name: {1}", ex.Message, name));
		}
		return assetBundle;
	}

	[DebuggerHidden]
	public IEnumerator TryToGetBundleAsync(string name, Action<AssetBundle> callback)
	{
		AssetBundleManager.<TryToGetBundleAsync>c__Iterator32 <TryToGetBundleAsync>c__Iterator = new AssetBundleManager.<TryToGetBundleAsync>c__Iterator32();
		<TryToGetBundleAsync>c__Iterator.name = name;
		<TryToGetBundleAsync>c__Iterator.callback = callback;
		<TryToGetBundleAsync>c__Iterator.<$>name = name;
		<TryToGetBundleAsync>c__Iterator.<$>callback = callback;
		<TryToGetBundleAsync>c__Iterator.<>f__this = this;
		return <TryToGetBundleAsync>c__Iterator;
	}

	public GameObject LoadPrefab(string name)
	{
		AssetBundle assetBundle = this.TryToGetBundle(name);
		GameObject gameObject = null;
		if (assetBundle != null)
		{
			string text = string.Format("assets/resources/{0}.prefab", name).ToLower();
			UnityEngine.Object @object = assetBundle.LoadAsset(text);
			gameObject = (@object as GameObject);
			if (gameObject != null)
			{
				gameObject.transform.GetOrAddComponent<AssetWatcher>().assetName = name.ToLower();
			}
			else
			{
				Debug.LogError(string.Format("load prefab error: {1}, {2}", name, text));
			}
		}
		return gameObject;
	}

	public void LoadPrefabAsync(string name, Action<GameObject, string> callback)
	{
		base.StartCoroutine(this.TryToGetBundleAsync(name, delegate(AssetBundle bundle)
		{
			this.StartCoroutine(this._loadPrefabAsync(name, bundle, callback));
		}));
	}

	[DebuggerHidden]
	private IEnumerator _loadPrefabAsync(string name, AssetBundle bundle, Action<GameObject, string> callback)
	{
		AssetBundleManager.<_loadPrefabAsync>c__Iterator33 <_loadPrefabAsync>c__Iterator = new AssetBundleManager.<_loadPrefabAsync>c__Iterator33();
		<_loadPrefabAsync>c__Iterator.name = name;
		<_loadPrefabAsync>c__Iterator.bundle = bundle;
		<_loadPrefabAsync>c__Iterator.callback = callback;
		<_loadPrefabAsync>c__Iterator.<$>name = name;
		<_loadPrefabAsync>c__Iterator.<$>bundle = bundle;
		<_loadPrefabAsync>c__Iterator.<$>callback = callback;
		return <_loadPrefabAsync>c__Iterator;
	}

	public Texture LoadTexture(string name)
	{
		string text = name.ToLower();
		string extension = Path.GetExtension(text);
		if (!string.IsNullOrEmpty(extension))
		{
			text = text.Replace(extension, string.Empty);
		}
		AssetBundle assetBundle = this.TryToGetBundle(text);
		if (!text.StartsWith("assets/resources/"))
		{
			text = string.Format("assets/resources/{0}", name).ToLower();
		}
		Texture texture = assetBundle.LoadAsset(text) as Texture;
		if (texture == null)
		{
			Debug.LogWarning("Cant find texture ab:" + text);
		}
		return texture;
	}

	public UIAtlas LoadAtlas(string name)
	{
		GameObject gameObject = this.LoadPrefab(name);
		return gameObject.GetComponent<UIAtlas>();
	}

	public void LoadAudioClipAsync(GameObject go, string name, string extension, Action<AudioClip, string> callback)
	{
		base.StartCoroutine(this.TryToGetBundleAsync(name, delegate(AssetBundle bundle)
		{
			this.StartCoroutine(this._loadAudioClipAsync(go, name, extension, bundle, callback));
		}));
	}

	[DebuggerHidden]
	private IEnumerator _loadAudioClipAsync(GameObject go, string name, string extension, AssetBundle bundle, Action<AudioClip, string> callback)
	{
		AssetBundleManager.<_loadAudioClipAsync>c__Iterator34 <_loadAudioClipAsync>c__Iterator = new AssetBundleManager.<_loadAudioClipAsync>c__Iterator34();
		<_loadAudioClipAsync>c__Iterator.bundle = bundle;
		<_loadAudioClipAsync>c__Iterator.name = name;
		<_loadAudioClipAsync>c__Iterator.extension = extension;
		<_loadAudioClipAsync>c__Iterator.callback = callback;
		<_loadAudioClipAsync>c__Iterator.<$>bundle = bundle;
		<_loadAudioClipAsync>c__Iterator.<$>name = name;
		<_loadAudioClipAsync>c__Iterator.<$>extension = extension;
		<_loadAudioClipAsync>c__Iterator.<$>callback = callback;
		return <_loadAudioClipAsync>c__Iterator;
	}

	public void LoadBGMAudioAsync(GameObject go, string name, string extension, Action<AudioClip, string> callback)
	{
		base.StartCoroutine(this._loadBGMAudioAsync(go, name, extension, callback));
	}

	[DebuggerHidden]
	private IEnumerator _loadBGMAudioAsync(GameObject go, string name, string extension, Action<AudioClip, string> callback)
	{
		AssetBundleManager.<_loadBGMAudioAsync>c__Iterator35 <_loadBGMAudioAsync>c__Iterator = new AssetBundleManager.<_loadBGMAudioAsync>c__Iterator35();
		<_loadBGMAudioAsync>c__Iterator.name = name;
		<_loadBGMAudioAsync>c__Iterator.extension = extension;
		<_loadBGMAudioAsync>c__Iterator.callback = callback;
		<_loadBGMAudioAsync>c__Iterator.<$>name = name;
		<_loadBGMAudioAsync>c__Iterator.<$>extension = extension;
		<_loadBGMAudioAsync>c__Iterator.<$>callback = callback;
		<_loadBGMAudioAsync>c__Iterator.<>f__this = this;
		return <_loadBGMAudioAsync>c__Iterator;
	}

	public void LoadAsset(string name, GameObject go)
	{
		if (!this.assetIntances.ContainsKey(name))
		{
			List<GameObject> list = new List<GameObject>();
			list.Add(go);
			this.assetIntances.Add(name, list);
		}
		else if (!this.assetIntances[name].Contains(go))
		{
			this.assetIntances[name].Add(go);
		}
	}

	public void UnloadAsset(string assetName, GameObject go)
	{
		bool flag;
		if (this.assetIntances.ContainsKey(assetName))
		{
			this.assetIntances[assetName].Remove(go);
			flag = (this.assetIntances[assetName].Count == 0);
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			string text = this.assetbundleMap[assetName];
			string[] allDependencies = this.allBundleManifest.GetAllDependencies(text);
			for (int i = 0; i < allDependencies.Length; i++)
			{
				if (this.bundleLoaded.ContainsKey(allDependencies[i]))
				{
					this.bundleLoaded[allDependencies[i]].refCount--;
				}
			}
			if (this.bundleLoaded.ContainsKey(text))
			{
				this.bundleLoaded[text].refCount--;
			}
			if (this.assetIntances.ContainsKey(assetName))
			{
				this.assetIntances.Remove(assetName);
			}
		}
	}

	public void ResetClearTime()
	{
		this.delayClearTime = 300f;
	}

	public void Clear()
	{
		List<string> list = new List<string>();
		foreach (string current in this.bundleLoaded.Keys)
		{
			if (this.bundleLoaded[current].refCount <= 0)
			{
				this.bundleLoaded[current].Unload();
				list.Add(current);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			this.bundleLoaded.Remove(list[i]);
		}
		Util.ClearMemory();
		this.ResetClearTime();
	}
}
