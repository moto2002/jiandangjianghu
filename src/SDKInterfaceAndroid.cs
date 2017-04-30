using MiniJSON;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SDKInterfaceAndroid : SDKInterface
{
	private AndroidJavaObject jo;

	public SDKInterfaceAndroid()
	{
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityActivity"))
		{
			this.jo = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		}
	}

	private T SDKCall<T>(string method, params object[] param)
	{
		try
		{
			return this.jo.Call<T>(method, param);
		}
		catch (Exception message)
		{
			Debug.LogError(message);
		}
		return default(T);
	}

	private void SDKCall(string method, params object[] param)
	{
		try
		{
			this.jo.Call(method, param);
		}
		catch (Exception message)
		{
			Debug.LogError(message);
		}
	}

	public override void Init()
	{
	}

	public override void Login()
	{
		this.SDKCall("login", new object[0]);
	}

	public override void LoginCustom(string customData)
	{
		this.SDKCall("loginCustom", new object[]
		{
			customData
		});
	}

	public override void SwitchLogin()
	{
		this.SDKCall("switchLogin", new object[0]);
	}

	public override bool Logout()
	{
		if (!this.IsSupportLogout())
		{
			return false;
		}
		this.SDKCall("logout", new object[0]);
		return true;
	}

	public override bool ShowAccountCenter()
	{
		if (!this.IsSupportAccountCenter())
		{
			return false;
		}
		this.SDKCall("showAccountCenter", new object[0]);
		return true;
	}

	public override void SubmitGameData(ExtraGameData data)
	{
		string text = this.encodeGameData(data);
		this.SDKCall("submitExtraData", new object[]
		{
			text
		});
	}

	public override bool SDKExit()
	{
		if (!this.IsSupportExit())
		{
			return false;
		}
		this.SDKCall("exit", new object[0]);
		return true;
	}

	public override void Pay(PayParams data)
	{
		string text = this.encodePayParams(data);
		this.SDKCall("pay", new object[]
		{
			text
		});
	}

	public override bool IsSupportExit()
	{
		return this.SDKCall<bool>("isSupportExit", new object[0]);
	}

	public override bool IsSupportAccountCenter()
	{
		return this.SDKCall<bool>("isSupportAccountCenter", new object[0]);
	}

	public override bool IsSupportLogout()
	{
		return this.SDKCall<bool>("isSupportLogout", new object[0]);
	}

	public override string GetMacAddr()
	{
		return this.SDKCall<string>("getMacAddr", new object[0]);
	}

	public override string GetIpAddr()
	{
		return this.SDKCall<string>("getLocalIpAddress", new object[0]);
	}

	private string encodeGameData(ExtraGameData data)
	{
		return Json.Serialize(new Dictionary<string, object>
		{
			{
				"dataType",
				data.dataType
			},
			{
				"roleID",
				data.roleID
			},
			{
				"roleName",
				data.roleName
			},
			{
				"roleLevel",
				data.roleLevel
			},
			{
				"serverID",
				data.serverID
			},
			{
				"serverName",
				data.serverName
			},
			{
				"moneyNum",
				data.moneyNum
			},
			{
				"vipLv",
				data.vipLv
			},
			{
				"unionName",
				data.unionName
			},
			{
				"createTime",
				data.createTime
			}
		});
	}

	private string encodePayParams(PayParams data)
	{
		return Json.Serialize(new Dictionary<string, object>
		{
			{
				"productId",
				data.productId
			},
			{
				"productName",
				data.productName
			},
			{
				"productDesc",
				data.productDesc
			},
			{
				"price",
				data.price
			},
			{
				"buyNum",
				data.buyNum
			},
			{
				"coinNum",
				data.coinNum
			},
			{
				"serverId",
				data.serverId
			},
			{
				"serverName",
				data.serverName
			},
			{
				"roleId",
				data.roleId
			},
			{
				"roleName",
				data.roleName
			},
			{
				"roleLevel",
				data.roleLevel
			},
			{
				"vip",
				data.vip
			},
			{
				"orderID",
				data.orderID
			},
			{
				"extension",
				data.extension
			}
		});
	}
}
