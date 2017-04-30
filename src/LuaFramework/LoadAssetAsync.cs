using System;
using UnityEngine;

namespace LuaFramework
{
	public class LoadAssetAsync : ALoadOperation
	{
		private ResourceRequest resReq;

		public LoadAssetAsync(string assetPath)
		{
			this.resReq = Resources.LoadAsync(assetPath);
		}

		public override bool IsDone()
		{
			return this.resReq != null && this.resReq.isDone;
		}

		public override T GetAsset<T>()
		{
			return (T)((object)this.resReq.asset);
		}
	}
}
