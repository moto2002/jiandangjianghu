using System;
using UnityEngine;

public abstract class MonoSingletion<T> : MonoBehaviour where T : MonoBehaviour
{
	private static string rootName = "MonoSingletionRoot";

	private static GameObject monoSingletionRoot;

	private static T instance;

	public static T Instance
	{
		get
		{
			if (MonoSingletion<T>.monoSingletionRoot == null)
			{
				MonoSingletion<T>.monoSingletionRoot = GameObject.Find(MonoSingletion<T>.rootName);
				if (MonoSingletion<T>.monoSingletionRoot == null)
				{
					Debug.Log("please create a gameobject named " + MonoSingletion<T>.rootName);
				}
			}
			if (MonoSingletion<T>.instance == null)
			{
				MonoSingletion<T>.instance = MonoSingletion<T>.monoSingletionRoot.GetComponent<T>();
				if (MonoSingletion<T>.instance == null)
				{
					MonoSingletion<T>.instance = MonoSingletion<T>.monoSingletionRoot.AddComponent<T>();
				}
			}
			return MonoSingletion<T>.instance;
		}
	}
}
