using System;
using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
	public int designWidth = 1280;

	public int designHeight = 720;

	private int scaleWidth;

	private int scaleHeight;

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	public void AdjustResolution()
	{
		if (SystemInfo.supportsStencil == 0 && !SystemInfo.supports3DTextures)
		{
			this.designWidth = ((Screen.currentResolution.width <= 1280) ? Screen.currentResolution.width : 1280);
			this.designHeight = ((Screen.currentResolution.height <= 720) ? Screen.currentResolution.height : 720);
		}
		else
		{
			this.designWidth = 1280;
			this.designHeight = 720;
		}
	}

	public void setDesignContentScale()
	{
		if (this.scaleWidth == 0 && this.scaleHeight == 0)
		{
			int width = Screen.currentResolution.width;
			int height = Screen.currentResolution.height;
			float num = (float)this.designWidth / (float)this.designHeight;
			float num2 = (float)width / (float)height;
			int num3 = (int)(num * 100f);
			int num4 = (int)(num2 * 100f);
			if (num3 < num4)
			{
				this.designWidth = Mathf.FloorToInt((float)this.designHeight * num2);
			}
			else if (num3 > num4)
			{
				this.designHeight = Mathf.FloorToInt((float)this.designWidth / num2);
			}
			this.scaleWidth = this.designWidth;
			this.scaleHeight = this.designHeight;
		}
		if (this.scaleWidth > 0 && this.scaleHeight > 0)
		{
			if (this.scaleWidth % 2 == 0)
			{
				this.scaleWidth++;
			}
			else
			{
				this.scaleWidth--;
			}
			Debug.Log(string.Format("Set Screen: {0}x{1}", this.scaleWidth, this.scaleHeight));
			Screen.SetResolution(this.scaleWidth, this.scaleHeight, Application.platform != RuntimePlatform.WindowsPlayer);
		}
	}

	private void OnApplicationPause(bool paused)
	{
		if (paused)
		{
			Application.targetFrameRate = 1;
		}
		else
		{
			Application.targetFrameRate = 30;
			this.setDesignContentScale();
		}
	}
}
