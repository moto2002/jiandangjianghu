using System;
using ThirdParty;
using UnityEngine;

namespace LuaFramework
{
	public class LoadBundleAsync : ALoadOperation
	{
		private bool isDone;

		private UnityEngine.Object mainAsset;

		public LoadBundleAsync(string assetName)
		{
			Singleton<AssetBundleManager>.Instance.LoadPrefabAsync(assetName, new Action<GameObject, string>(this.loadFinishCallback));
		}

		private void loadFinishCallback(GameObject gameObject, string s)
		{
			this.mainAsset = gameObject;
			this.isDone = true;
		}

		public override bool IsDone()
		{
			return this.isDone;
		}

		public override T GetAsset<T>()
		{
			return this.mainAsset as T;
		}
	}
}
