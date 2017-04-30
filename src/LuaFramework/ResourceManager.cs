using System;
using System.IO;
using ThirdParty;
using UnityEngine;

namespace LuaFramework
{
	public class ResourceManager : Manager
	{
		private AssetBundle shared;

		private LFUCache<string, Texture> textureCache = new LFUCache<string, Texture>(20);

		public void initialize(Action func)
		{
			if (func != null)
			{
				func();
			}
			this.textureCache.SetDestroyStrategy(new TextureDestroyStrategy());
		}

		public AssetBundle LoadBundle(string name)
		{
			string path = Util.DataPath + name.ToLower() + ".unity3d";
			return AssetBundle.LoadFromFile(path);
		}

		public ALoadOperation LoadAssetAsync(string assetName)
		{
			return new LoadBundleAsync(assetName);
		}

		public T LoadAsset<T>(string assetName, bool isBundleMode) where T : UnityEngine.Object
		{
			if (isBundleMode)
			{
				return this.loadBundleAsset<T>(assetName);
			}
			string extension = Path.GetExtension(assetName);
			if (!string.IsNullOrEmpty(extension))
			{
				assetName = assetName.Replace(extension, string.Empty);
			}
			return Resources.Load<T>(assetName);
		}

		public Material LoadMaterial(string assetName, bool isBundleMode)
		{
			return this.LoadAsset<Material>(assetName, isBundleMode);
		}

		public Material LoadMaterial(string assetName)
		{
			return this.LoadAsset<Material>(assetName, true);
		}

		public Texture LoadTexture(string assetName, bool isBundleMode)
		{
			Texture texture;
			if (this.textureCache.ContainsKey(assetName))
			{
				texture = this.textureCache.GetValue(assetName);
			}
			else
			{
				string extension = Path.GetExtension(assetName);
				if (string.IsNullOrEmpty(extension))
				{
					Debug.LogError("开发人员注意：图片资源必须包括后缀名！！");
				}
				if (isBundleMode)
				{
					texture = Singleton<AssetBundleManager>.Instance.LoadTexture(assetName);
				}
				else
				{
					string path = assetName;
					if (!string.IsNullOrEmpty(extension))
					{
						path = assetName.Replace(extension, string.Empty);
					}
					texture = Resources.Load<Texture>(path);
				}
				if (texture == null)
				{
					Debug.LogError("Cant find texture :" + assetName);
				}
				else
				{
					this.textureCache.Put(assetName, texture, 1);
				}
			}
			return texture;
		}

		public Texture LoadTexture(string assetName)
		{
			return this.LoadTexture(assetName, true);
		}

		public GameObject LoadPrefab(string assetName, bool isBundleMode)
		{
			if (isBundleMode)
			{
				return Singleton<AssetBundleManager>.Instance.LoadPrefab(assetName);
			}
			return Resources.Load(assetName) as GameObject;
		}

		public GameObject LoadPrefab(string assetName)
		{
			return this.LoadPrefab(assetName, true);
		}

		private T loadBundleAsset<T>(string assetName) where T : UnityEngine.Object
		{
			GameObject gameObject = Singleton<AssetBundleManager>.Instance.LoadPrefab(assetName);
			return gameObject.GetComponent<T>();
		}

		private void OnDestroy()
		{
			if (this.shared != null)
			{
				this.shared.Unload(true);
			}
			Debug.Log("~ResourceManager was destroy!");
		}
	}
}
