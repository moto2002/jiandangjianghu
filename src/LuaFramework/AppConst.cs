using System;
using UnityEngine;

namespace LuaFramework
{
	public class AppConst
	{
		public const bool DebugMode = false;

		public const bool ExampleMode = false;

		public const bool UpdateMode = true;

		public const bool LuaByteMode = true;

		public const bool AssetBundleMode = true;

		public const bool LuaBundleMode = true;

		public const int TimerInterval = 1;

		public const int GameFrameRate = 30;

		public const string LuaTempDir = "Lua/";

		public const string ExtName = ".unity3d";

		public static string AppName = "jdjh";

		public static string AppPrefix = AppConst.AppName + "_";

		public static string UserId = string.Empty;

		public static int SocketPort = 0;

		public static string SocketAddress = string.Empty;

		public static string FrameworkRoot
		{
			get
			{
				return Application.dataPath + "/LuaFramework";
			}
		}
	}
}
