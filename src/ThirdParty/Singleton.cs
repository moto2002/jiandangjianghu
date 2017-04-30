using System;
using UnityEngine;

namespace ThirdParty
{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _instance;

		private static object _lock = new object();

		private static bool applicationIsQuitting = false;

		public static T Instance
		{
			get
			{
				if (Singleton<T>.applicationIsQuitting)
				{
					Debug.LogWarning("[Singleton] Instance '" + typeof(T) + "' already destroyed on application quit. Won't create again - returning null.");
					return (T)((object)null);
				}
				object @lock = Singleton<T>._lock;
				T instance;
				lock (@lock)
				{
					if (Singleton<T>._instance == null)
					{
						Singleton<T>._instance = (T)((object)UnityEngine.Object.FindObjectOfType(typeof(T)));
						if (UnityEngine.Object.FindObjectsOfType(typeof(T)).Length > 1)
						{
							Debug.LogError("[Singleton] Something went really wrong  - there should never be more than 1 singleton! Reopenning the scene might fix it.");
							instance = Singleton<T>._instance;
							return instance;
						}
						if (Singleton<T>._instance == null)
						{
							GameObject gameObject = new GameObject("(singleton) " + typeof(T));
							Singleton<T>._instance = gameObject.AddComponent<T>();
							UnityEngine.Object.DontDestroyOnLoad(gameObject);
							GameObject gameObject2 = GameObject.Find("Global");
							if (!gameObject2)
							{
								gameObject2 = new GameObject("Global");
								UnityEngine.Object.DontDestroyOnLoad(gameObject2);
							}
							gameObject.transform.SetParent(gameObject2.transform);
							Debug.Log(string.Concat(new object[]
							{
								"[Singleton] An instance of ",
								typeof(T),
								" is needed in the scene, so '",
								gameObject,
								"' was created with DontDestroyOnLoad."
							}));
						}
						else
						{
							Debug.Log("[Singleton] Using instance already created: " + Singleton<T>._instance.gameObject.name);
						}
					}
					instance = Singleton<T>._instance;
				}
				return instance;
			}
		}

		public void Init()
		{
		}

		public static void DestroySelf()
		{
			UnityEngine.Object.Destroy(GameObject.Find("(singleton) " + typeof(T)));
		}

		protected virtual void OnDestroy()
		{
			Singleton<T>.applicationIsQuitting = true;
		}
	}
}
