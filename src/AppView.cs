using System;
using System.Collections.Generic;
using UnityEngine;

public class AppView : View
{
	private string message;

	private List<string> MessageList
	{
		get
		{
			return new List<string>
			{
				"UpdateMessage",
				"UpdateExtract",
				"UpdateDownload",
				"UpdateProgress"
			};
		}
	}

	private void Awake()
	{
		base.RemoveMessage(this, this.MessageList);
		base.RegisterMessage(this, this.MessageList);
	}

	public override void OnMessage(IMessage message)
	{
		string name = message.Name;
		object body = message.Body;
		string text = name;
		switch (text)
		{
		case "UpdateMessage":
			this.UpdateMessage(body.ToString());
			break;
		case "UpdateExtract":
			this.UpdateExtract(body.ToString());
			break;
		case "UpdateDownload":
			this.UpdateDownload(body.ToString());
			break;
		case "UpdateProgress":
			this.UpdateProgress(body.ToString());
			break;
		}
	}

	public void UpdateMessage(string data)
	{
		this.message = data;
	}

	public void UpdateExtract(string data)
	{
		this.message = data;
	}

	public void UpdateDownload(string data)
	{
		this.message = data;
	}

	public void UpdateProgress(string data)
	{
		this.message = data;
	}

	private void OnGUI()
	{
		GUI.Label(new Rect(10f, 120f, 960f, 50f), this.message);
		GUI.Label(new Rect(10f, 0f, 500f, 50f), "(1) 单击 \"Lua/Gen Lua Wrap Files\"。");
		GUI.Label(new Rect(10f, 20f, 500f, 50f), "(2) 运行Unity游戏");
		GUI.Label(new Rect(10f, 40f, 500f, 50f), "PS: 清除缓存，单击\"Lua/Clear LuaBinder File + Wrap Files\"。");
		GUI.Label(new Rect(10f, 60f, 900f, 50f), "PS: 若运行到真机，请设置Const.DebugMode=false，本地调试请设置Const.DebugMode=true");
		GUI.Label(new Rect(10f, 80f, 500f, 50f), "PS: 加Unity+ulua技术讨论群：>>341746602");
	}
}
