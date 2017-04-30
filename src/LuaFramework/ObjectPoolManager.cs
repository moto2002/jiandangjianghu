using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LuaFramework
{
	public class ObjectPoolManager : Manager
	{
		private Transform m_PoolRootObject;

		private Dictionary<string, object> m_ObjectPools = new Dictionary<string, object>();

		private Dictionary<string, GameObjectPool> m_GameObjectPools = new Dictionary<string, GameObjectPool>();

		private Transform PoolRootObject
		{
			get
			{
				if (this.m_PoolRootObject == null)
				{
					GameObject gameObject = new GameObject("ObjectPool");
					gameObject.transform.SetParent(base.transform);
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = Vector3.zero;
					this.m_PoolRootObject = gameObject.transform;
				}
				return this.m_PoolRootObject;
			}
		}

		public GameObjectPool CreatePool(string poolName, int initSize, int maxSize, GameObject prefab)
		{
			GameObjectPool gameObjectPool = new GameObjectPool(poolName, prefab, initSize, maxSize, this.PoolRootObject);
			this.m_GameObjectPools[poolName] = gameObjectPool;
			return gameObjectPool;
		}

		public GameObjectPool GetPool(string poolName)
		{
			if (this.m_GameObjectPools.ContainsKey(poolName))
			{
				return this.m_GameObjectPools[poolName];
			}
			return null;
		}

		public GameObject Get(string poolName)
		{
			GameObject gameObject = null;
			if (this.m_GameObjectPools.ContainsKey(poolName))
			{
				GameObjectPool gameObjectPool = this.m_GameObjectPools[poolName];
				gameObject = gameObjectPool.NextAvailableObject();
				if (gameObject == null)
				{
					Debug.LogWarning("No object available in pool. Consider setting fixedSize to false.: " + poolName);
				}
			}
			else
			{
				Debug.LogError("Invalid pool name specified: " + poolName);
			}
			return gameObject;
		}

		public void Release(string poolName, GameObject go)
		{
			if (this.m_GameObjectPools.ContainsKey(poolName))
			{
				GameObjectPool gameObjectPool = this.m_GameObjectPools[poolName];
				gameObjectPool.ReturnObjectToPool(poolName, go);
			}
			else
			{
				Debug.LogWarning("No pool available with name: " + poolName);
			}
		}

		public ObjectPool<T> CreatePool<T>(UnityAction<T> actionOnGet, UnityAction<T> actionOnRelease) where T : class
		{
			Type typeFromHandle = typeof(T);
			ObjectPool<T> objectPool = new ObjectPool<T>(actionOnGet, actionOnRelease);
			this.m_ObjectPools[typeFromHandle.Name] = objectPool;
			return objectPool;
		}

		public ObjectPool<T> GetPool<T>() where T : class
		{
			Type typeFromHandle = typeof(T);
			ObjectPool<T> result = null;
			if (this.m_ObjectPools.ContainsKey(typeFromHandle.Name))
			{
				result = (this.m_ObjectPools[typeFromHandle.Name] as ObjectPool<T>);
			}
			return result;
		}

		public T Get<T>() where T : class
		{
			ObjectPool<T> pool = this.GetPool<T>();
			if (pool != null)
			{
				return pool.Get();
			}
			return (T)((object)null);
		}

		public void Release<T>(T obj) where T : class
		{
			ObjectPool<T> pool = this.GetPool<T>();
			if (pool != null)
			{
				pool.Release(obj);
			}
		}
	}
}
