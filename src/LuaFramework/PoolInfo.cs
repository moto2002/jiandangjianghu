using System;
using UnityEngine;

namespace LuaFramework
{
	[Serializable]
	public class PoolInfo
	{
		public string poolName;

		public GameObject prefab;

		public int poolSize;

		public bool fixedSize;
	}
}
