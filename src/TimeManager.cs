using System;
using ThirdParty;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
	private ulong serverSecSinceStarted;

	private float beginAppStartup;

	private static DateTime mStartTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

	public static TimeManager instance
	{
		get
		{
			return Singleton<TimeManager>.Instance;
		}
	}

	public DateTime CurServerTime
	{
		get
		{
			ulong num = this.serverSecSinceStarted + (ulong)(Time.realtimeSinceStartup - this.beginAppStartup);
			return TimeManager.mStartTime.AddSeconds(num);
		}
	}

	public ulong CurServerTotalSeconds
	{
		get
		{
			return this.serverSecSinceStarted + (ulong)(Time.realtimeSinceStartup - this.beginAppStartup);
		}
	}

	public void SetServerTime(string millisec, uint usec)
	{
		this.beginAppStartup = Time.realtimeSinceStartup;
		try
		{
			if (string.IsNullOrEmpty(millisec))
			{
				millisec = "0";
			}
			this.serverSecSinceStarted = Convert.ToUInt64(millisec) / 1000uL + (ulong)(usec / 1000000f);
		}
		catch (Exception ex)
		{
			Debug.LogError("set servettime error: " + ex.Message + "\nstack trace:" + ex.StackTrace);
		}
	}

	public static string FormatDateTime(DateTime time, string format)
	{
		return time.ToString(format);
	}

	public static double TotalSecondsToCurrentTime()
	{
		DateTime curServerTime = Singleton<TimeManager>.Instance.CurServerTime;
		return (curServerTime - TimeManager.mStartTime).TotalSeconds;
	}
}
