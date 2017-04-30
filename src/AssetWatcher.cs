using System;
using ThirdParty;
using UnityEngine;

public class AssetWatcher : MonoBehaviour
{
	public string assetName;

	private void Start()
	{
		Singleton<AssetBundleManager>.Instance.LoadAsset(this.assetName, base.gameObject);
	}

	private void OnDestroy()
	{
		if (Singleton<AssetBundleManager>.Instance != null)
		{
			Singleton<AssetBundleManager>.Instance.UnloadAsset(this.assetName, base.gameObject);
		}
	}
}
