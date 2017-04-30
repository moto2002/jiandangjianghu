using LuaFramework;
using System;
using ThirdParty;
using UnityEngine;

public class BundleInfo
{
	private AssetBundle _bundle;

	private int _refCount;

	public AssetBundle bundle
	{
		get
		{
			this._refCount++;
			this.lastTimeVisited = Time.realtimeSinceStartup;
			string[] allDependencies = Singleton<AssetBundleManager>.Instance.allBundleManifest.GetAllDependencies(this._bundleName);
			for (int i = 0; i < allDependencies.Length; i++)
			{
				if (Singleton<AssetBundleManager>.Instance.bundleLoaded.ContainsKey(allDependencies[i]))
				{
					Singleton<AssetBundleManager>.Instance.bundleLoaded[allDependencies[i]].refCount++;
				}
				else if (!Singleton<AssetBundleManager>.Instance.bundleInDownload.Contains(allDependencies[i]))
				{
					AssetBundle bundle = AssetBundle.LoadFromFile(Util.DataPath + allDependencies[i]);
					Singleton<AssetBundleManager>.Instance.bundleLoaded.Add(allDependencies[i], new BundleInfo(bundle, allDependencies[i]));
				}
			}
			return this._bundle;
		}
		private set
		{
			this._bundle = value;
		}
	}

	public int refCount
	{
		get
		{
			return this._refCount;
		}
		set
		{
			if (value > this._refCount)
			{
				this.lastTimeVisited = Time.realtimeSinceStartup;
			}
			this._refCount = value;
		}
	}

	public float timeCreated
	{
		get;
		private set;
	}

	public float lastTimeVisited
	{
		get;
		private set;
	}

	public string _bundleName
	{
		get;
		private set;
	}

	public BundleInfo(AssetBundle bundle, string name)
	{
		this._bundle = bundle;
		this._refCount = 1;
		this._bundleName = name;
		this.timeCreated = Time.realtimeSinceStartup;
		this.lastTimeVisited = Time.realtimeSinceStartup;
	}

	public void Unload()
	{
		Debug.LogWarning(string.Format("<color=green>assetbundle unload: {0}</color>", this._bundleName));
		this._bundle.Unload(false);
		this._bundle = null;
	}
}
