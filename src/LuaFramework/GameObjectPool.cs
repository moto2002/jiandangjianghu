using System;
using System.Collections.Generic;
using UnityEngine;

namespace LuaFramework
{
	public class GameObjectPool
	{
		private int maxSize;

		private int poolSize;

		private string poolName;

		private Transform poolRoot;

		private GameObject poolObjectPrefab;

		private Stack<GameObject> availableObjStack = new Stack<GameObject>();

		public GameObjectPool(string poolName, GameObject poolObjectPrefab, int initCount, int maxSize, Transform pool)
		{
			this.poolName = poolName;
			this.poolSize = initCount;
			this.maxSize = maxSize;
			this.poolRoot = pool;
			this.poolObjectPrefab = poolObjectPrefab;
			for (int i = 0; i < initCount; i++)
			{
				this.AddObjectToPool(this.NewObjectInstance());
			}
		}

		private void AddObjectToPool(GameObject go)
		{
			go.SetActive(false);
			this.availableObjStack.Push(go);
			go.transform.SetParent(this.poolRoot, false);
		}

		private GameObject NewObjectInstance()
		{
			return UnityEngine.Object.Instantiate<GameObject>(this.poolObjectPrefab);
		}

		public GameObject NextAvailableObject()
		{
			GameObject gameObject = null;
			if (this.availableObjStack.Count > 0)
			{
				gameObject = this.availableObjStack.Pop();
			}
			else
			{
				Debug.LogWarning("No object available & cannot grow pool: " + this.poolName);
			}
			gameObject.SetActive(true);
			return gameObject;
		}

		public void ReturnObjectToPool(string pool, GameObject po)
		{
			if (this.poolName.Equals(pool))
			{
				this.AddObjectToPool(po);
			}
			else
			{
				Debug.LogError(string.Format("Trying to add object to incorrect pool {0} ", this.poolName));
			}
		}
	}
}
