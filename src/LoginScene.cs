using LuaFramework;
using System;
using UnityEngine;

public class LoginScene : MonoBehaviour
{
	public UITexture bgTex;

	public UITexture titleTex;

	private void Awake()
	{
		this.bgTex.mainTexture = Resources.Load<Texture2D>("Other/loginBg/ui_pic_denglu");
		this.titleTex.mainTexture = Resources.Load<Texture2D>("Logo/" + AppConst.AppName);
		this.titleTex.MakePixelPerfect();
	}
}
