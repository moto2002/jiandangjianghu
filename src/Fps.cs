using System;
using System.Reflection;
using ThirdParty;
using UnityEngine;

[Obfuscation(Exclude = true)]
public class Fps : Singleton<Fps>
{
	private long mFrameCount;

	private long mLastFrameTime;

	public static long mLastFps;

	private GUIStyle style = new GUIStyle();

	public new void Init()
	{
		this.style.font = Resources.Load<Font>("Fonts/msyh.ttf");
		this.style.fontSize = 20;
	}

	private void Start()
	{
		this.mFrameCount = 0L;
		this.mLastFrameTime = 0L;
		Fps.mLastFps = 0L;
	}

	private void Update()
	{
		this.UpdateTick();
	}

	private void OnGUI()
	{
		this.DrawFps();
	}

	private void DrawFps()
	{
		if (this.style == null)
		{
			return;
		}
		if (Fps.mLastFps > 25L)
		{
			this.style.normal.textColor = new Color(0f, 1f, 0f);
		}
		else if (Fps.mLastFps > 15L)
		{
			this.style.normal.textColor = new Color(1f, 1f, 0f);
		}
		else
		{
			this.style.normal.textColor = new Color(1f, 0f, 0f);
		}
		GUI.Label(new Rect((float)(Screen.width - 180), 32f, 320f, 240f), "fps: " + Fps.mLastFps, this.style);
	}

	private void UpdateTick()
	{
		this.mFrameCount += 1L;
		long num = Fps.TickToMilliSec(DateTime.Now.Ticks);
		if (this.mLastFrameTime == 0L)
		{
			this.mLastFrameTime = Fps.TickToMilliSec(DateTime.Now.Ticks);
		}
		if (num - this.mLastFrameTime >= 1000L)
		{
			long num2 = (long)((float)this.mFrameCount * 1f / ((float)(num - this.mLastFrameTime) / 1000f));
			Fps.mLastFps = num2;
			this.mFrameCount = 0L;
			this.mLastFrameTime = num;
		}
	}

	public static long TickToMilliSec(long tick)
	{
		return tick / 10000L;
	}
}
