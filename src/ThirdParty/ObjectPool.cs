using LuaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace ThirdParty
{
	public sealed class ObjectPool : MonoBehaviour
	{
		public enum StartupPoolMode
		{
			Awake,
			Start,
			CallManually
		}

		[Serializable]
		public class StartupPool
		{
			public int size;

			public GameObject prefab;
		}

		public const int POOL_INIT_SIZE = 15;

		private static ObjectPool _instance;

		private static List<GameObject> tempList = new List<GameObject>();

		public Dictionary<string, GameObject> pooledObjNames = new Dictionary<string, GameObject>();

		private Dictionary<GameObject, List<GameObject>> pooledObjects = new Dictionary<GameObject, List<GameObject>>();

		private Dictionary<GameObject, GameObject> spawnedObjects = new Dictionary<GameObject, GameObject>();

		public ObjectPool.StartupPoolMode startupPoolMode;

		public ObjectPool.StartupPool[] startupPools;

		private bool startupPoolsCreated;

		public static ObjectPool instance
		{
			get
			{
				if (ObjectPool._instance != null)
				{
					return ObjectPool._instance;
				}
				ObjectPool._instance = new GameObject("ObjectPool")
				{
					transform = 
					{
						localPosition = Vector3.zero,
						localRotation = Quaternion.identity,
						localScale = Vector3.one
					}
				}.AddComponent<ObjectPool>();
				return ObjectPool._instance;
			}
		}

		private void Awake()
		{
			ObjectPool._instance = this;
			if (this.startupPoolMode == ObjectPool.StartupPoolMode.Awake)
			{
				ObjectPool.CreateStartupPools();
			}
		}

		private void Start()
		{
			if (this.startupPoolMode == ObjectPool.StartupPoolMode.Start)
			{
				ObjectPool.CreateStartupPools();
			}
		}

		public static void PopOld()
		{
			List<GameObject> list = new List<GameObject>();
			foreach (GameObject current in ObjectPool.instance.pooledObjects.Keys)
			{
				if (!ObjectPool.instance.spawnedObjects.ContainsValue(current))
				{
					list.Add(current);
				}
			}
			List<string> list2 = new List<string>();
			for (int i = 0; i < list.Count; i++)
			{
				if (ObjectPool.instance.pooledObjects.ContainsKey(list[i]))
				{
					ObjectPool.DestroyAll(list[i]);
				}
				foreach (KeyValuePair<string, GameObject> current2 in ObjectPool.instance.pooledObjNames)
				{
					if (current2.Value == list[i])
					{
						list2.Add(current2.Key);
					}
				}
			}
			for (int j = 0; j < list2.Count; j++)
			{
				if (ObjectPool.instance.pooledObjNames.ContainsKey(list2[j]))
				{
					ObjectPool.instance.pooledObjNames.Remove(list2[j]);
				}
			}
		}

		public GameObject PushToPool(string prefabPath, int initSize, Transform parent = null)
		{
			return this.PushToPool(prefabPath, initSize, parent, 0f, 0f, 0f, 0f, 0f, 0f);
		}

		public GameObject PushToPool(string prefabPath, int initSize, Transform parent, float x, float y, float z)
		{
			return this.PushToPool(prefabPath, initSize, parent, x, y, z, 0f, 0f, 0f);
		}

		public GameObject PushToPool(string prefabPath, int initSize, Transform parent, float x, float y, float z, float rx, float ry, float rz)
		{
			GameObject gameObject = null;
			if (!ObjectPool.instance.pooledObjNames.ContainsKey(prefabPath))
			{
				GameObject gameObject2 = Util.LoadPrefab(prefabPath);
				if (gameObject2 != null)
				{
					ObjectPool.CreatePool(gameObject2, initSize);
					ObjectPool.instance.pooledObjNames.Add(prefabPath, gameObject2);
					gameObject = gameObject2.Spawn(parent, new Vector3(x, y, z), Quaternion.Euler(rx, ry, rz));
				}
			}
			else
			{
				gameObject = ObjectPool.instance.pooledObjNames[prefabPath].Spawn(parent, new Vector3(x, y, z), Quaternion.Euler(rx, ry, rz));
			}
			if (gameObject != null)
			{
				this.SetPrefabLayer(prefabPath, gameObject);
			}
			return gameObject;
		}

		public void AsyncPushToPool(string prefabPath, int initSize, Transform parent, float x, float y, float z, Action<GameObject, string> callback)
		{
			GameObject prefab = null;
			if (!ObjectPool.instance.pooledObjNames.ContainsKey(prefabPath))
			{
				ObjectPool.instance.pooledObjNames.Add(prefabPath, null);
				base.StartCoroutine(Util.LoadPrefabAsync(prefabPath, delegate(GameObject go, string path)
				{
					if (go != null)
					{
						ObjectPool.CreatePool(go, initSize);
						ObjectPool.instance.pooledObjNames[prefabPath] = go;
						prefab = go.Spawn(parent, new Vector3(x, y, z));
						this.SetPrefabLayer(prefabPath, prefab);
					}
					else
					{
						ObjectPool.instance.pooledObjNames.Remove(prefabPath);
					}
					if (callback != null)
					{
						callback(prefab, path);
					}
				}));
			}
			else if (ObjectPool.instance.pooledObjNames[prefabPath] == null)
			{
				base.StartCoroutine(this.WaitForPoolComplete(prefabPath, parent, x, y, z, callback));
			}
			else
			{
				prefab = ObjectPool.instance.pooledObjNames[prefabPath].Spawn(parent, new Vector3(x, y, z));
				this.SetPrefabLayer(prefabPath, prefab);
				if (callback != null)
				{
					callback(prefab, prefabPath);
				}
			}
		}

		private void SetPrefabLayer(string path, GameObject prefab)
		{
			if (path.ToLower().Contains("model/"))
			{
				prefab.transform.localScale = Vector3.one;
				prefab.layer = LayerMask.NameToLayer("SceneEntity");
				Transform[] allChildren = Util.GetAllChildren(prefab.transform);
				for (int i = 0; i < allChildren.Length; i++)
				{
					allChildren[i].gameObject.layer = LayerMask.NameToLayer("SceneEntity");
				}
				string name = "BLSJ/Textured Add";
				string b = "Custom/Avatar Texture Area Clip";
				SkinnedMeshRenderer[] componentsInChildren = prefab.GetComponentsInChildren<SkinnedMeshRenderer>();
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					if (componentsInChildren[j].material.shader.name == b)
					{
						componentsInChildren[j].material.shader = Shader.Find(name);
					}
				}
				MeshRenderer[] componentsInChildren2 = prefab.GetComponentsInChildren<MeshRenderer>();
				for (int k = 0; k < componentsInChildren2.Length; k++)
				{
					if (componentsInChildren2[k].material.shader.name == b)
					{
						componentsInChildren2[k].material.shader = Shader.Find(name);
					}
				}
			}
		}

		[DebuggerHidden]
		private IEnumerator WaitForPoolComplete(string prefabPath, Transform parent, float x, float y, float z, Action<GameObject, string> callback)
		{
			ObjectPool.<WaitForPoolComplete>c__Iterator19 <WaitForPoolComplete>c__Iterator = new ObjectPool.<WaitForPoolComplete>c__Iterator19();
			<WaitForPoolComplete>c__Iterator.prefabPath = prefabPath;
			<WaitForPoolComplete>c__Iterator.parent = parent;
			<WaitForPoolComplete>c__Iterator.x = x;
			<WaitForPoolComplete>c__Iterator.y = y;
			<WaitForPoolComplete>c__Iterator.z = z;
			<WaitForPoolComplete>c__Iterator.callback = callback;
			<WaitForPoolComplete>c__Iterator.<$>prefabPath = prefabPath;
			<WaitForPoolComplete>c__Iterator.<$>parent = parent;
			<WaitForPoolComplete>c__Iterator.<$>x = x;
			<WaitForPoolComplete>c__Iterator.<$>y = y;
			<WaitForPoolComplete>c__Iterator.<$>z = z;
			<WaitForPoolComplete>c__Iterator.<$>callback = callback;
			<WaitForPoolComplete>c__Iterator.<>f__this = this;
			return <WaitForPoolComplete>c__Iterator;
		}

		public static void CreateStartupPools()
		{
			if (!ObjectPool.instance.startupPoolsCreated)
			{
				ObjectPool.instance.startupPoolsCreated = true;
				ObjectPool.StartupPool[] array = ObjectPool.instance.startupPools;
				if (array != null && array.Length > 0)
				{
					for (int i = 0; i < array.Length; i++)
					{
						ObjectPool.CreatePool(array[i].prefab, array[i].size);
					}
				}
			}
		}

		public static void CreatePool<T>(T prefab, int initialPoolSize) where T : Component
		{
			ObjectPool.CreatePool(prefab.gameObject, initialPoolSize);
		}

		public static void CreatePool(GameObject prefab, int initialPoolSize)
		{
			if (prefab != null && !ObjectPool.instance.pooledObjects.ContainsKey(prefab))
			{
				if (ObjectPool.instance.pooledObjects.Count > 100)
				{
					ObjectPool.PopOld();
				}
				List<GameObject> list = new List<GameObject>();
				ObjectPool.instance.pooledObjects.Add(prefab, list);
				if (initialPoolSize > 0)
				{
					bool activeSelf = prefab.activeSelf;
					prefab.SetActive(false);
					Transform transform = ObjectPool.instance.transform;
					while (list.Count < initialPoolSize)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(prefab);
						gameObject.transform.parent = transform;
						list.Add(gameObject);
					}
					prefab.SetActive(activeSelf);
				}
			}
		}

		public static T Spawn<T>(T prefab, Transform parent, Vector3 position, Quaternion rotation) where T : Component
		{
			return ObjectPool.Spawn(prefab.gameObject, parent, position, rotation).GetComponent<T>();
		}

		public static T Spawn<T>(T prefab, Vector3 position, Quaternion rotation) where T : Component
		{
			return ObjectPool.Spawn(prefab.gameObject, null, position, rotation).GetComponent<T>();
		}

		public static T Spawn<T>(T prefab, Transform parent, Vector3 position) where T : Component
		{
			return ObjectPool.Spawn(prefab.gameObject, parent, position, Quaternion.identity).GetComponent<T>();
		}

		public static T Spawn<T>(T prefab, Vector3 position) where T : Component
		{
			return ObjectPool.Spawn(prefab.gameObject, null, position, Quaternion.identity).GetComponent<T>();
		}

		public static T Spawn<T>(T prefab, Transform parent) where T : Component
		{
			return ObjectPool.Spawn(prefab.gameObject, parent, Vector3.zero, Quaternion.identity).GetComponent<T>();
		}

		public static T Spawn<T>(T prefab) where T : Component
		{
			return ObjectPool.Spawn(prefab.gameObject, null, Vector3.zero, Quaternion.identity).GetComponent<T>();
		}

		public static GameObject Spawn(GameObject prefab, Transform parent, Vector3 position, Quaternion rotation)
		{
			List<GameObject> list;
			GameObject gameObject;
			Transform transform;
			if (ObjectPool.instance.pooledObjects.TryGetValue(prefab, out list))
			{
				gameObject = null;
				if (list.Count > 0)
				{
					while (gameObject == null && list.Count > 0)
					{
						gameObject = list[0];
						list.RemoveAt(0);
					}
					if (gameObject != null)
					{
						transform = gameObject.transform;
						transform.parent = parent;
						transform.localPosition = position;
						transform.localRotation = rotation;
						gameObject.SetActive(true);
						ObjectPool.instance.spawnedObjects.Add(gameObject, prefab);
						return gameObject;
					}
				}
				gameObject = UnityEngine.Object.Instantiate<GameObject>(prefab);
				transform = gameObject.transform;
				transform.parent = parent;
				transform.localPosition = position;
				transform.localRotation = rotation;
				ObjectPool.instance.spawnedObjects.Add(gameObject, prefab);
				return gameObject;
			}
			gameObject = UnityEngine.Object.Instantiate<GameObject>(prefab);
			transform = gameObject.GetComponent<Transform>();
			transform.parent = parent;
			transform.localPosition = position;
			transform.localRotation = rotation;
			return gameObject;
		}

		public static GameObject Spawn(GameObject prefab, Transform parent, Vector3 position)
		{
			return ObjectPool.Spawn(prefab, parent, position, Quaternion.identity);
		}

		public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
		{
			return ObjectPool.Spawn(prefab, null, position, rotation);
		}

		public static GameObject Spawn(GameObject prefab, Transform parent)
		{
			return ObjectPool.Spawn(prefab, parent, Vector3.zero, Quaternion.identity);
		}

		public static GameObject Spawn(GameObject prefab, Vector3 position)
		{
			return ObjectPool.Spawn(prefab, null, position, Quaternion.identity);
		}

		public static GameObject Spawn(GameObject prefab)
		{
			return ObjectPool.Spawn(prefab, null, Vector3.zero, Quaternion.identity);
		}

		public static void Recycle<T>(T obj) where T : Component
		{
			ObjectPool.Recycle(obj.gameObject);
		}

		public static void Recycle(GameObject obj)
		{
			GameObject prefab;
			if (ObjectPool.instance.spawnedObjects.TryGetValue(obj, out prefab))
			{
				ObjectPool.Recycle(obj, prefab);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(obj);
			}
		}

		private static void Recycle(GameObject obj, GameObject prefab)
		{
			ObjectPool.instance.pooledObjects[prefab].Add(obj);
			ObjectPool.instance.spawnedObjects.Remove(obj);
			obj.transform.parent = ObjectPool.instance.transform;
			obj.SetActive(false);
		}

		public static void RecycleAll<T>(T prefab) where T : Component
		{
			ObjectPool.RecycleAll(prefab.gameObject);
		}

		public static void RecycleAll(GameObject prefab)
		{
			foreach (KeyValuePair<GameObject, GameObject> current in ObjectPool.instance.spawnedObjects)
			{
				if (current.Value == prefab)
				{
					ObjectPool.tempList.Add(current.Key);
				}
			}
			for (int i = 0; i < ObjectPool.tempList.Count; i++)
			{
				ObjectPool.Recycle(ObjectPool.tempList[i]);
			}
			ObjectPool.tempList.Clear();
		}

		public static void RecycleAll()
		{
			ObjectPool.tempList.AddRange(ObjectPool.instance.spawnedObjects.Keys);
			for (int i = 0; i < ObjectPool.tempList.Count; i++)
			{
				ObjectPool.Recycle(ObjectPool.tempList[i]);
			}
			ObjectPool.tempList.Clear();
		}

		public static bool IsSpawned(GameObject obj)
		{
			return ObjectPool.instance.spawnedObjects.ContainsKey(obj);
		}

		public static int CountPooled<T>(T prefab) where T : Component
		{
			return ObjectPool.CountPooled(prefab.gameObject);
		}

		public static int CountPooled(GameObject prefab)
		{
			List<GameObject> list;
			if (ObjectPool.instance.pooledObjects.TryGetValue(prefab, out list))
			{
				return list.Count;
			}
			return 0;
		}

		public static int CountSpawned<T>(T prefab) where T : Component
		{
			return ObjectPool.CountSpawned(prefab.gameObject);
		}

		public static int CountSpawned(GameObject prefab)
		{
			int num = 0;
			foreach (GameObject current in ObjectPool.instance.spawnedObjects.Values)
			{
				if (prefab == current)
				{
					num++;
				}
			}
			return num;
		}

		public static int CountAllPooled()
		{
			int num = 0;
			foreach (List<GameObject> current in ObjectPool.instance.pooledObjects.Values)
			{
				num += current.Count;
			}
			return num;
		}

		public static List<GameObject> GetPooled(GameObject prefab, List<GameObject> list, bool appendList)
		{
			if (list == null)
			{
				list = new List<GameObject>();
			}
			if (!appendList)
			{
				list.Clear();
			}
			List<GameObject> collection;
			if (ObjectPool.instance.pooledObjects.TryGetValue(prefab, out collection))
			{
				list.AddRange(collection);
			}
			return list;
		}

		public static List<T> GetPooled<T>(T prefab, List<T> list, bool appendList) where T : Component
		{
			if (list == null)
			{
				list = new List<T>();
			}
			if (!appendList)
			{
				list.Clear();
			}
			List<GameObject> list2;
			if (ObjectPool.instance.pooledObjects.TryGetValue(prefab.gameObject, out list2))
			{
				for (int i = 0; i < list2.Count; i++)
				{
					list.Add(list2[i].GetComponent<T>());
				}
			}
			return list;
		}

		public static List<GameObject> GetSpawned(GameObject prefab, List<GameObject> list, bool appendList)
		{
			if (list == null)
			{
				list = new List<GameObject>();
			}
			if (!appendList)
			{
				list.Clear();
			}
			foreach (KeyValuePair<GameObject, GameObject> current in ObjectPool.instance.spawnedObjects)
			{
				if (current.Value == prefab)
				{
					list.Add(current.Key);
				}
			}
			return list;
		}

		public static List<T> GetSpawned<T>(T prefab, List<T> list, bool appendList) where T : Component
		{
			if (list == null)
			{
				list = new List<T>();
			}
			if (!appendList)
			{
				list.Clear();
			}
			GameObject gameObject = prefab.gameObject;
			foreach (KeyValuePair<GameObject, GameObject> current in ObjectPool.instance.spawnedObjects)
			{
				if (current.Value == gameObject)
				{
					list.Add(current.Key.GetComponent<T>());
				}
			}
			return list;
		}

		public static void DestroyPooled(GameObject prefab)
		{
			List<GameObject> list;
			if (ObjectPool.instance.pooledObjects.TryGetValue(prefab, out list))
			{
				for (int i = 0; i < list.Count; i++)
				{
					UnityEngine.Object.Destroy(list[i]);
				}
				list.Clear();
			}
		}

		public static void DestroyPooled<T>(T prefab) where T : Component
		{
			ObjectPool.DestroyPooled(prefab.gameObject);
		}

		public static void DestroyAll(GameObject prefab)
		{
			ObjectPool.RecycleAll(prefab);
			ObjectPool.DestroyPooled(prefab);
		}

		public static void DestroyAll<T>(T prefab) where T : Component
		{
			ObjectPool.DestroyAll(prefab.gameObject);
		}
	}
}
