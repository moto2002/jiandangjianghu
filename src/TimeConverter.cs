using System;

public class TimeConverter
{
	public static DateTime ConvertIntDateTime(double d)
	{
		DateTime minValue = DateTime.MinValue;
		return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(d);
	}

	public static double ConvertDateTimeInt(DateTime time)
	{
		DateTime d = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
		return (time - d).TotalSeconds;
	}

	public static long ConvertDateTimeLong(DateTime time)
	{
		DateTime d = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
		return (time - d).Ticks;
	}

	public static string CovertToString(int seconds)
	{
		int num = seconds / 60;
		int num2 = seconds % 60;
		return string.Format("{0:D2}:{1:D2}", num, num2);
	}

	public static string ConvertToHoursString(int seconds)
	{
		int num = seconds / 3600;
		int num2 = seconds % 3600 / 60;
		int num3 = seconds % 3600 % 60;
		return string.Format("{0:D2}:{1:D2}:{2:D2}", num, num2, num3);
	}

	public static string ConvertToDateString(double d)
	{
		DateTime minValue = DateTime.MinValue;
		return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(d).ToString("yyyy年MM月dd号H时mm分ss秒");
	}

	public static string ConvertToLogDateString(double d)
	{
		DateTime minValue = DateTime.MinValue;
		return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(d).ToString("yyyy年MM月dd号HH:mm");
	}

	public static string ConvertToDateString1(double d)
	{
		DateTime minValue = DateTime.MinValue;
		return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(d).TimeOfDay.ToString();
	}

	public static DateTime Parse(string dateTime)
	{
		return DateTime.Parse(dateTime);
	}
}
