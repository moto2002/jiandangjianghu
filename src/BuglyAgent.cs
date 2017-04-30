using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public sealed class BuglyAgent
{
	public delegate void LogCallbackDelegate(string condition, string stackTrace, LogType type);

	private static readonly string GAME_AGENT_CLASS = "com.tencent.bugly.agent.GameAgent";

	private static readonly int TYPE_U3D_CRASH = 4;

	private static readonly int GAME_TYPE_UNITY = 2;

	private static bool hasSetGameType;

	private static AndroidJavaClass _gameAgentClass;

	private static string _configChannel;

	private static string _configVersion;

	private static string _configUser;

	private static long _configDelayTime;

	private static bool _configCrashReporterPackage;

	private static bool _isInitialized;

	private static LogSeverity _autoReportLogLevel = LogSeverity.LogError;

	private static int _crashReporterType = 1;

	private static string _crashReporterPackage = "com.tencent.bugly";

	private static bool _debugMode;

	private static bool _autoQuitApplicationAfterReport;

	private static readonly int EXCEPTION_TYPE_UNCAUGHT = 1;

	private static readonly int EXCEPTION_TYPE_CAUGHT = 2;

	private static readonly string _pluginVersion = "1.5.1";

	private static Func<Dictionary<string, string>> _LogCallbackExtrasHandler;

	private static bool _uncaughtAutoReportOnce;

	private static event BuglyAgent.LogCallbackDelegate _LogCallbackEventHandler
	{
		[MethodImpl(32)]
		add
		{
			BuglyAgent._LogCallbackEventHandler = (BuglyAgent.LogCallbackDelegate)Delegate.Combine(BuglyAgent._LogCallbackEventHandler, value);
		}
		[MethodImpl(32)]
		remove
		{
			BuglyAgent._LogCallbackEventHandler = (BuglyAgent.LogCallbackDelegate)Delegate.Remove(BuglyAgent._LogCallbackEventHandler, value);
		}
	}

	public static AndroidJavaClass GameAgent
	{
		get
		{
			if (BuglyAgent._gameAgentClass == null)
			{
				BuglyAgent._gameAgentClass = new AndroidJavaClass(BuglyAgent.GAME_AGENT_CLASS);
			}
			if (!BuglyAgent.hasSetGameType)
			{
				BuglyAgent._gameAgentClass.CallStatic("setGameType", new object[]
				{
					BuglyAgent.GAME_TYPE_UNITY
				});
				BuglyAgent.hasSetGameType = true;
			}
			return BuglyAgent._gameAgentClass;
		}
	}

	public static string PluginVersion
	{
		get
		{
			return BuglyAgent._pluginVersion;
		}
	}

	public static bool IsInitialized
	{
		get
		{
			return BuglyAgent._isInitialized;
		}
	}

	public static bool AutoQuitApplicationAfterReport
	{
		get
		{
			return BuglyAgent._autoQuitApplicationAfterReport;
		}
	}

	public static void ConfigCrashReporter(int type, int logLevel)
	{
		BuglyAgent._SetCrashReporterType(type);
		BuglyAgent._SetCrashReporterLogLevel(logLevel);
	}

	public static void InitWithAppId(string appId)
	{
		if (BuglyAgent.IsInitialized)
		{
			BuglyAgent.DebugLog(null, "BuglyAgent has already been initialized.", new object[0]);
			return;
		}
		if (string.IsNullOrEmpty(appId))
		{
			return;
		}
		BuglyAgent.InitBuglyAgent(appId);
		BuglyAgent.DebugLog(null, "Initialized with app id: {0}", new object[]
		{
			appId
		});
		BuglyAgent._RegisterExceptionHandler();
	}

	public static void EnableExceptionHandler()
	{
		if (BuglyAgent.IsInitialized)
		{
			BuglyAgent.DebugLog(null, "BuglyAgent has already been initialized.", new object[0]);
			return;
		}
		BuglyAgent.DebugLog(null, "Only enable the exception handler, please make sure you has initialized the sdk in the native code in associated Android or iOS project.", new object[0]);
		BuglyAgent._RegisterExceptionHandler();
	}

	public static void RegisterLogCallback(BuglyAgent.LogCallbackDelegate handler)
	{
		if (handler != null)
		{
			BuglyAgent.DebugLog(null, "Add log callback handler: {0}", new object[]
			{
				handler
			});
			BuglyAgent._LogCallbackEventHandler = (BuglyAgent.LogCallbackDelegate)Delegate.Combine(BuglyAgent._LogCallbackEventHandler, handler);
		}
	}

	public static void SetLogCallbackExtrasHandler(Func<Dictionary<string, string>> handler)
	{
		if (handler != null)
		{
			BuglyAgent._LogCallbackExtrasHandler = handler;
			BuglyAgent.DebugLog(null, "Add log callback extra data handler : {0}", new object[]
			{
				handler
			});
		}
	}

	public static void ReportException(Exception e, string message)
	{
		if (!BuglyAgent.IsInitialized)
		{
			return;
		}
		BuglyAgent.DebugLog(null, "Report exception: {0}\n------------\n{1}\n------------", new object[]
		{
			message,
			e
		});
		BuglyAgent._HandleException(e, message, false);
	}

	public static void ReportException(string name, string message, string stackTrace)
	{
		if (!BuglyAgent.IsInitialized)
		{
			return;
		}
		BuglyAgent.DebugLog(null, "Report exception: {0} {1} \n{2}", new object[]
		{
			name,
			message,
			stackTrace
		});
		BuglyAgent._HandleException(LogSeverity.LogException, name, message, stackTrace, false);
	}

	public static void UnregisterLogCallback(BuglyAgent.LogCallbackDelegate handler)
	{
		if (handler != null)
		{
			BuglyAgent.DebugLog(null, "Remove log callback handler", new object[0]);
			BuglyAgent._LogCallbackEventHandler = (BuglyAgent.LogCallbackDelegate)Delegate.Remove(BuglyAgent._LogCallbackEventHandler, handler);
		}
	}

	public static void SetUserId(string userId)
	{
		if (!BuglyAgent.IsInitialized)
		{
			return;
		}
		BuglyAgent.DebugLog(null, "Set user id: {0}", new object[]
		{
			userId
		});
		BuglyAgent.SetUserInfo(userId);
	}

	public static void SetScene(int sceneId)
	{
		if (!BuglyAgent.IsInitialized)
		{
			return;
		}
		BuglyAgent.DebugLog(null, "Set scene: {0}", new object[]
		{
			sceneId
		});
		BuglyAgent.SetCurrentScene(sceneId);
	}

	public static void AddSceneData(string key, string value)
	{
		if (!BuglyAgent.IsInitialized)
		{
			return;
		}
		BuglyAgent.DebugLog(null, "Add scene data: [{0}, {1}]", new object[]
		{
			key,
			value
		});
		BuglyAgent.AddKeyAndValueInScene(key, value);
	}

	public static void ConfigDebugMode(bool enable)
	{
		BuglyAgent.EnableDebugMode(enable);
		BuglyAgent.DebugLog(null, "{0} the log message print to console", new object[]
		{
			(!enable) ? "Disable" : "Enable"
		});
	}

	public static void ConfigAutoQuitApplication(bool autoQuit)
	{
		BuglyAgent._autoQuitApplicationAfterReport = autoQuit;
	}

	public static void ConfigAutoReportLogLevel(LogSeverity level)
	{
		BuglyAgent._autoReportLogLevel = level;
	}

	public static void ConfigDefault(string channel, string version, string user, long delay)
	{
		BuglyAgent.DebugLog(null, "Config default channel:{0}, version:{1}, user:{2}, delay:{3}", new object[]
		{
			channel,
			version,
			user,
			delay
		});
		BuglyAgent.ConfigDefaultBeforeInit(channel, version, user, delay);
	}

	public static void DebugLog(string tag, string format, params object[] args)
	{
		if (!BuglyAgent._debugMode)
		{
			return;
		}
		if (string.IsNullOrEmpty(format))
		{
			return;
		}
		Console.WriteLine("[BuglyAgent] <Debug> - {0} : {1}", tag, string.Format(format, args));
	}

	public static void PrintLog(LogSeverity level, string format, params object[] args)
	{
		if (string.IsNullOrEmpty(format))
		{
			return;
		}
		BuglyAgent.LogRecord(level, string.Format(format, args));
	}

	private static void ConfigDefaultBeforeInit(string channel, string version, string user, long delay)
	{
		BuglyAgent._configChannel = channel;
		BuglyAgent._configVersion = version;
		BuglyAgent._configUser = user;
		BuglyAgent._configDelayTime = delay;
	}

	private static void ConfigCrashReporterPackage()
	{
		if (!BuglyAgent._configCrashReporterPackage)
		{
			try
			{
				BuglyAgent.GameAgent.CallStatic("setSdkPackageName", new object[]
				{
					BuglyAgent._crashReporterPackage
				});
				BuglyAgent._configCrashReporterPackage = true;
			}
			catch
			{
			}
		}
	}

	private static void InitBuglyAgent(string appId)
	{
		if (BuglyAgent.IsInitialized)
		{
			return;
		}
		BuglyAgent.ConfigCrashReporterPackage();
		try
		{
			BuglyAgent.GameAgent.CallStatic("initCrashReport", new object[]
			{
				appId,
				BuglyAgent._configChannel,
				BuglyAgent._configVersion,
				BuglyAgent._configUser,
				BuglyAgent._configDelayTime
			});
			BuglyAgent._isInitialized = true;
		}
		catch
		{
		}
	}

	private static void EnableDebugMode(bool enable)
	{
		BuglyAgent._debugMode = enable;
		BuglyAgent.ConfigCrashReporterPackage();
		try
		{
			BuglyAgent.GameAgent.CallStatic("setLogEnable", new object[]
			{
				enable
			});
		}
		catch
		{
		}
	}

	private static void SetUserInfo(string userInfo)
	{
		BuglyAgent.ConfigCrashReporterPackage();
		try
		{
			BuglyAgent.GameAgent.CallStatic("setUserId", new object[]
			{
				userInfo
			});
		}
		catch
		{
		}
	}

	private static void ReportException(int type, string name, string reason, string stackTrace, bool quitProgram)
	{
		BuglyAgent.ConfigCrashReporterPackage();
		try
		{
			BuglyAgent.GameAgent.CallStatic("postException", new object[]
			{
				BuglyAgent.TYPE_U3D_CRASH,
				name,
				reason,
				stackTrace,
				quitProgram
			});
		}
		catch
		{
		}
	}

	private static void SetCurrentScene(int sceneId)
	{
		BuglyAgent.ConfigCrashReporterPackage();
		try
		{
			BuglyAgent.GameAgent.CallStatic("setUserSceneTag", new object[]
			{
				sceneId
			});
		}
		catch
		{
		}
	}

	private static void SetUnityVersion()
	{
		BuglyAgent.ConfigCrashReporterPackage();
		try
		{
			BuglyAgent.GameAgent.CallStatic("setSdkConfig", new object[]
			{
				"UnityVersion",
				Application.unityVersion
			});
		}
		catch
		{
		}
	}

	private static void AddKeyAndValueInScene(string key, string value)
	{
		BuglyAgent.ConfigCrashReporterPackage();
		try
		{
			BuglyAgent.GameAgent.CallStatic("putUserData", new object[]
			{
				key,
				value
			});
		}
		catch
		{
		}
	}

	private static void AddExtraDataWithException(string key, string value)
	{
	}

	private static void LogRecord(LogSeverity level, string message)
	{
		if (level < LogSeverity.LogWarning)
		{
			BuglyAgent.DebugLog(level.ToString(), message, new object[0]);
		}
		BuglyAgent.ConfigCrashReporterPackage();
		try
		{
			BuglyAgent.GameAgent.CallStatic("printLog", new object[]
			{
				string.Format("<{0}> - {1}", level.ToString(), message)
			});
		}
		catch
		{
		}
	}

	private static void _SetCrashReporterType(int type)
	{
		BuglyAgent._crashReporterType = type;
		if (BuglyAgent._crashReporterType == 2)
		{
			BuglyAgent._crashReporterPackage = "com.tencent.bugly.msdk";
		}
	}

	private static void _SetCrashReporterLogLevel(int logLevel)
	{
	}

	private static void _RegisterExceptionHandler()
	{
		try
		{
			Application.logMessageReceived += new Application.LogCallback(BuglyAgent._OnLogCallbackHandler);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(BuglyAgent._OnUncaughtExceptionHandler);
			BuglyAgent._isInitialized = true;
			BuglyAgent.DebugLog(null, "Register the log callback in Unity {0}", new object[]
			{
				Application.unityVersion
			});
		}
		catch
		{
		}
		BuglyAgent.SetUnityVersion();
	}

	private static void _UnregisterExceptionHandler()
	{
		try
		{
			Application.logMessageReceived -= new Application.LogCallback(BuglyAgent._OnLogCallbackHandler);
			AppDomain.CurrentDomain.UnhandledException -= new UnhandledExceptionEventHandler(BuglyAgent._OnUncaughtExceptionHandler);
			BuglyAgent.DebugLog(null, "Unregister the log callback in unity {0}", new object[]
			{
				Application.unityVersion
			});
		}
		catch
		{
		}
	}

	private static void _OnLogCallbackHandler(string condition, string stackTrace, LogType type)
	{
		if (BuglyAgent._LogCallbackEventHandler != null)
		{
			BuglyAgent._LogCallbackEventHandler(condition, stackTrace, type);
		}
		if (!BuglyAgent.IsInitialized)
		{
			return;
		}
		if (!string.IsNullOrEmpty(condition) && condition.Contains("[BuglyAgent] <Log>"))
		{
			return;
		}
		if (BuglyAgent._uncaughtAutoReportOnce)
		{
			return;
		}
		LogSeverity logSeverity = LogSeverity.Log;
		switch (type)
		{
		case LogType.Error:
			logSeverity = LogSeverity.LogError;
			break;
		case LogType.Assert:
			logSeverity = LogSeverity.LogAssert;
			break;
		case LogType.Warning:
			logSeverity = LogSeverity.LogWarning;
			break;
		case LogType.Log:
			logSeverity = LogSeverity.LogDebug;
			break;
		case LogType.Exception:
			logSeverity = LogSeverity.LogException;
			break;
		}
		if (logSeverity == LogSeverity.Log)
		{
			return;
		}
		BuglyAgent._HandleException(logSeverity, null, condition, stackTrace, true);
	}

	private static void _OnUncaughtExceptionHandler(object sender, UnhandledExceptionEventArgs args)
	{
		if (args == null || args.ExceptionObject == null)
		{
			return;
		}
		try
		{
			if (args.ExceptionObject.GetType() != typeof(Exception))
			{
				return;
			}
		}
		catch
		{
			if (Debug.isDebugBuild)
			{
				Debug.Log("BuglyAgent: Failed to report uncaught exception");
			}
			return;
		}
		if (!BuglyAgent.IsInitialized)
		{
			return;
		}
		if (BuglyAgent._uncaughtAutoReportOnce)
		{
			return;
		}
		BuglyAgent._HandleException((Exception)args.ExceptionObject, null, true);
	}

	private static void _HandleException(Exception e, string message, bool uncaught)
	{
		if (e == null)
		{
			return;
		}
		if (!BuglyAgent.IsInitialized)
		{
			return;
		}
		string name = e.GetType().Name;
		string text = e.Message;
		if (!string.IsNullOrEmpty(message))
		{
			text = string.Format("{0}{1}***{2}", text, Environment.NewLine, message);
		}
		StringBuilder stringBuilder = new StringBuilder(string.Empty);
		StackTrace stackTrace = new StackTrace(e, true);
		int frameCount = stackTrace.FrameCount;
		for (int i = 0; i < frameCount; i++)
		{
			StackFrame frame = stackTrace.GetFrame(i);
			stringBuilder.AppendFormat("{0}.{1}", frame.GetMethod().DeclaringType.Name, frame.GetMethod().Name);
			ParameterInfo[] parameters = frame.GetMethod().GetParameters();
			if (parameters == null || parameters.Length == 0)
			{
				stringBuilder.Append(" () ");
			}
			else
			{
				stringBuilder.Append(" (");
				int num = parameters.Length;
				for (int j = 0; j < num; j++)
				{
					ParameterInfo parameterInfo = parameters[j];
					stringBuilder.AppendFormat("{0} {1}", parameterInfo.ParameterType.Name, parameterInfo.Name);
					if (j != num - 1)
					{
						stringBuilder.Append(", ");
					}
				}
				stringBuilder.Append(") ");
			}
			string text2 = frame.GetFileName();
			if (!string.IsNullOrEmpty(text2) && !text2.ToLower().Equals("unknown"))
			{
				text2 = text2.Replace("\\", "/");
				int num2 = text2.ToLower().IndexOf("/assets/");
				if (num2 < 0)
				{
					num2 = text2.ToLower().IndexOf("assets/");
				}
				if (num2 > 0)
				{
					text2 = text2.Substring(num2);
				}
				stringBuilder.AppendFormat("(at {0}:{1})", text2, frame.GetFileLineNumber());
			}
			stringBuilder.AppendLine();
		}
		BuglyAgent._reportException(uncaught, name, text, stringBuilder.ToString());
	}

	private static void _reportException(bool uncaught, string name, string reason, string stackTrace)
	{
		if (string.IsNullOrEmpty(name))
		{
			return;
		}
		if (string.IsNullOrEmpty(stackTrace))
		{
			stackTrace = StackTraceUtility.ExtractStackTrace();
		}
		if (string.IsNullOrEmpty(stackTrace))
		{
			stackTrace = "Empty";
		}
		else
		{
			try
			{
				string[] array = stackTrace.Split(new char[]
				{
					'\n'
				});
				if (array != null && array.Length > 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					int num = array.Length;
					for (int i = 0; i < num; i++)
					{
						string text = array[i];
						if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text.Trim()))
						{
							text = text.Trim();
							if (!text.StartsWith("System.Collections.Generic.") && !text.StartsWith("ShimEnumerator"))
							{
								if (!text.StartsWith("Bugly"))
								{
									if (!text.Contains("..ctor"))
									{
										int num2 = text.ToLower().IndexOf("(at");
										int num3 = text.ToLower().IndexOf("/assets/");
										if (num2 > 0 && num3 > 0)
										{
											stringBuilder.AppendFormat("{0}(at {1}", text.Substring(0, num2).Replace(":", "."), text.Substring(num3));
										}
										else
										{
											stringBuilder.Append(text.Replace(":", "."));
										}
										stringBuilder.AppendLine();
									}
								}
							}
						}
					}
					stackTrace = stringBuilder.ToString();
				}
			}
			catch
			{
				BuglyAgent.PrintLog(LogSeverity.LogWarning, "{0}", new object[]
				{
					"Error to parse the stack trace"
				});
			}
		}
		BuglyAgent.PrintLog(LogSeverity.LogError, "ReportException: {0} {1}\n*********\n{2}\n*********", new object[]
		{
			name,
			reason,
			stackTrace
		});
		BuglyAgent._uncaughtAutoReportOnce = (uncaught && BuglyAgent._autoQuitApplicationAfterReport);
		BuglyAgent.ReportException((!uncaught) ? BuglyAgent.EXCEPTION_TYPE_CAUGHT : BuglyAgent.EXCEPTION_TYPE_UNCAUGHT, name, reason, stackTrace, uncaught && BuglyAgent._autoQuitApplicationAfterReport);
	}

	private static void _HandleException(LogSeverity logLevel, string name, string message, string stackTrace, bool uncaught)
	{
		if (!BuglyAgent.IsInitialized)
		{
			BuglyAgent.DebugLog(null, "It has not been initialized.", new object[0]);
			return;
		}
		if (logLevel == LogSeverity.Log)
		{
			return;
		}
		if (uncaught && logLevel < BuglyAgent._autoReportLogLevel)
		{
			BuglyAgent.DebugLog(null, "Not report exception for level {0}", new object[]
			{
				logLevel.ToString()
			});
			return;
		}
		string text = null;
		string text2 = null;
		if (!string.IsNullOrEmpty(message))
		{
			try
			{
				if (logLevel == LogSeverity.LogException && message.Contains("Exception"))
				{
					Match match = new Regex("^(?<errorType>\\S+):\\s*(?<errorMessage>.*)", RegexOptions.Singleline).Match(message);
					if (match.Success)
					{
						text = match.Groups["errorType"].Value.Trim();
						text2 = match.Groups["errorMessage"].Value.Trim();
					}
				}
				else if (logLevel == LogSeverity.LogError && message.StartsWith("Unhandled Exception:"))
				{
					Match match2 = new Regex("^Unhandled\\s+Exception:\\s*(?<exceptionName>\\S+):\\s*(?<exceptionDetail>.*)", RegexOptions.Singleline).Match(message);
					if (match2.Success)
					{
						string text3 = match2.Groups["exceptionName"].Value.Trim();
						string text4 = match2.Groups["exceptionDetail"].Value.Trim();
						int num = text3.LastIndexOf(".");
						if (num > 0 && num != text3.Length)
						{
							text = text3.Substring(num + 1);
						}
						else
						{
							text = text3;
						}
						int num2 = text4.IndexOf(" at ");
						if (num2 > 0)
						{
							text2 = text4.Substring(0, num2);
							string text5 = text4.Substring(num2 + 3).Replace(" at ", "\n").Replace("in <filename unknown>:0", string.Empty).Replace("[0x00000]", string.Empty);
							stackTrace = string.Format("{0}\n{1}", stackTrace, text5.Trim());
						}
						else
						{
							text2 = text4;
						}
						if (text.Equals("LuaScriptException") && text4.Contains(".lua") && text4.Contains("stack traceback:"))
						{
							num2 = text4.IndexOf("stack traceback:");
							if (num2 > 0)
							{
								text2 = text4.Substring(0, num2);
								string text6 = text4.Substring(num2 + 16).Replace(" [", " \n[");
								stackTrace = string.Format("{0}\n{1}", stackTrace, text6.Trim());
							}
						}
					}
				}
			}
			catch
			{
			}
			if (string.IsNullOrEmpty(text2))
			{
				text2 = message;
			}
		}
		if (string.IsNullOrEmpty(name))
		{
			if (string.IsNullOrEmpty(text))
			{
				text = string.Format("Unity{0}", logLevel.ToString());
			}
		}
		else
		{
			text = name;
		}
		BuglyAgent._reportException(uncaught, text, text2, stackTrace);
	}
}
