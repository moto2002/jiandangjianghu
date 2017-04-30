using System;
using UnityEngine;

namespace LuaFramework
{
	internal class TextureDestroyStrategy : CacheDestroy<string, Texture>
	{
		public override bool CanDestroy(Node<string, Texture> node)
		{
			return !UITexture.HasActiveTexture(node.Key);
		}

		public override void DestroyNode(Node<string, Texture> node)
		{
			Resources.UnloadAsset(node.Value);
			node.Value = null;
			GC.Collect();
		}
	}
}
