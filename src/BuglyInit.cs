using System;
using System.Collections.Generic;
using UnityEngine;

public class BuglyInit : MonoBehaviour
{
	private const string BuglyAppID = "YOUR APP ID GOES HERE";

	private void Awake()
	{
		BuglyAgent.ConfigDebugMode(false);
		BuglyAgent.ConfigDefault(null, null, null, 0L);
		BuglyAgent.ConfigAutoReportLogLevel(LogSeverity.LogError);
		BuglyAgent.ConfigAutoQuitApplication(false);
		BuglyAgent.RegisterLogCallback(null);
		BuglyAgent.InitWithAppId("YOUR APP ID GOES HERE");
		BuglyAgent.EnableExceptionHandler();
		BuglyAgent.SetLogCallbackExtrasHandler(new Func<Dictionary<string, string>>(BuglyInit.MyLogCallbackExtrasHandler));
		UnityEngine.Object.Destroy(this);
	}

	private static Dictionary<string, string> MyLogCallbackExtrasHandler()
	{
		BuglyAgent.PrintLog(LogSeverity.Log, "extra handler", new object[0]);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("ScreenSolution", string.Format("{0}x{1}", Screen.width, Screen.height));
		dictionary.Add("deviceModel", SystemInfo.deviceModel);
		dictionary.Add("deviceName", SystemInfo.deviceName);
		dictionary.Add("deviceType", SystemInfo.deviceType.ToString());
		dictionary.Add("deviceUId", SystemInfo.deviceUniqueIdentifier);
		dictionary.Add("gDId", string.Format("{0}", SystemInfo.graphicsDeviceID));
		dictionary.Add("gDName", SystemInfo.graphicsDeviceName);
		dictionary.Add("gDVdr", SystemInfo.graphicsDeviceVendor);
		dictionary.Add("gDVer", SystemInfo.graphicsDeviceVersion);
		dictionary.Add("gDVdrID", string.Format("{0}", SystemInfo.graphicsDeviceVendorID));
		dictionary.Add("graphicsMemorySize", string.Format("{0}", SystemInfo.graphicsMemorySize));
		dictionary.Add("systemMemorySize", string.Format("{0}", SystemInfo.systemMemorySize));
		dictionary.Add("UnityVersion", Application.unityVersion);
		BuglyAgent.PrintLog(LogSeverity.LogInfo, "Package extra data", new object[0]);
		return dictionary;
	}
}
