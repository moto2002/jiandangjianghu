using MiniJSON;
using System;
using System.Collections;
using UnityEngine;

public class SDKCallback : MonoBehaviour
{
	private static SDKCallback _instance;

	private static object _lock = new object();

	public static SDKCallback InitCallback()
	{
		Debug.Log("Callback->InitCallback");
		object @lock = SDKCallback._lock;
		SDKCallback instance;
		lock (@lock)
		{
			if (SDKCallback._instance == null)
			{
				GameObject gameObject = GameObject.Find("(sdk_callback)");
				if (gameObject == null)
				{
					gameObject = new GameObject("(sdk_callback)");
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
					SDKCallback._instance = gameObject.AddComponent<SDKCallback>();
				}
				else
				{
					SDKCallback._instance = gameObject.GetComponent<SDKCallback>();
				}
			}
			instance = SDKCallback._instance;
		}
		return instance;
	}

	public void OnInitSuc()
	{
		Debug.Log("Callback->OnInitSuc");
	}

	public void OnLoginSuc(string jsonData)
	{
		Debug.Log("Callback->OnLoginSuc");
		LoginResult loginResult = this.parseLoginResult(jsonData);
		if (loginResult == null)
		{
			Debug.Log("The data parse error." + jsonData);
			return;
		}
		if (SDKInterface.Instance.OnLoginSuc != null)
		{
			SDKInterface.Instance.OnLoginSuc(loginResult);
		}
	}

	public void OnSwitchLogin()
	{
		Debug.Log("Callback->OnSwitchLogin");
		if (SDKInterface.Instance.OnLogout != null)
		{
			SDKInterface.Instance.OnLogout();
		}
	}

	public void OnLogout()
	{
		Debug.Log("Callback->OnLogout");
		if (SDKInterface.Instance.OnLogout != null)
		{
			SDKInterface.Instance.OnLogout();
		}
	}

	public void OnPaySuc(string jsonData)
	{
	}

	private LoginResult parseLoginResult(string str)
	{
		object obj = Json.Deserialize(str);
		if (obj != null)
		{
			Hashtable hashtable = obj as Hashtable;
			LoginResult loginResult = new LoginResult();
			if (hashtable.ContainsKey("isSuc"))
			{
				loginResult.isSuc = bool.Parse(hashtable["isSuc"].ToString());
			}
			if (hashtable.ContainsKey("isSwitchAccount"))
			{
				loginResult.isSwitchAccount = bool.Parse(hashtable["isSwitchAccount"].ToString());
			}
			if (hashtable.ContainsKey("userID"))
			{
				loginResult.userID = hashtable["userID"].ToString();
			}
			if (hashtable.ContainsKey("sdkUserID"))
			{
				loginResult.sdkUserID = hashtable["sdkUserID"].ToString();
			}
			if (hashtable.ContainsKey("username"))
			{
				loginResult.username = hashtable["username"].ToString();
			}
			if (hashtable.ContainsKey("sdkUsername"))
			{
				loginResult.sdkUsername = hashtable["sdkUsername"].ToString();
			}
			if (hashtable.ContainsKey("token"))
			{
				loginResult.token = hashtable["token"].ToString();
			}
			if (hashtable.ContainsKey("extension"))
			{
				loginResult.extension = hashtable["extension"].ToString();
			}
			if (hashtable.ContainsKey("pID"))
			{
				loginResult.pID = int.Parse(hashtable["pID"].ToString());
			}
			if (hashtable.ContainsKey("channelID"))
			{
				loginResult.channelID = int.Parse(hashtable["channelID"].ToString());
			}
			return loginResult;
		}
		return null;
	}
}
