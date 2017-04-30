using LuaInterface;
using System;
using System.IO;
using UnityEngine;

namespace LuaFramework
{
	public class LuaLoader : LuaFileUtils
	{
		public LuaLoader()
		{
			LuaFileUtils.instance = this;
			this.beZip = true;
		}

		public void AddBundle(string bundleName)
		{
			string path = Util.DataPath + bundleName.ToLower();
			if (File.Exists(path))
			{
				AssetBundle assetBundle = AssetBundle.LoadFromFile(path);
				if (assetBundle != null)
				{
					bundleName = bundleName.Replace("lua/", string.Empty).Replace(".unity3d", string.Empty);
					base.AddSearchBundle(bundleName.ToLower(), assetBundle);
				}
			}
		}

		public override byte[] ReadFile(string fileName)
		{
			return base.ReadFile(fileName);
		}
	}
}
