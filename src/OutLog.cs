using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class OutLog : MonoBehaviour
{
	private static List<string> mLines = new List<string>();

	private static List<string> mWriteTxt = new List<string>();

	private string outpath;

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		this.outpath = Application.persistentDataPath + "/outLog.txt";
		if (File.Exists(this.outpath))
		{
			File.Delete(this.outpath);
		}
		BuglyAgent.RegisterLogCallback(new BuglyAgent.LogCallbackDelegate(this.HandleLog));
	}

	private void Update()
	{
		if (OutLog.mWriteTxt.Count > 0)
		{
			string[] array = OutLog.mWriteTxt.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				FileStream fileStream = null;
				try
				{
					fileStream = new FileStream(this.outpath, FileMode.OpenOrCreate);
					using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
					{
						streamWriter.WriteLine(array[i]);
					}
					OutLog.mWriteTxt.Remove(array[i]);
				}
				finally
				{
					if (fileStream != null)
					{
						fileStream.Dispose();
					}
				}
			}
		}
	}

	private void HandleLog(string logString, string stackTrace, LogType type)
	{
		if (type == LogType.Log || type == LogType.Warning)
		{
			OutLog.mWriteTxt.Add(logString);
			if (base.GetComponent<DebugConsole>() != null)
			{
				DebugConsole.Log(logString);
			}
		}
		if (type == LogType.Error || type == LogType.Exception)
		{
			OutLog.mWriteTxt.Add(logString);
			OutLog.mWriteTxt.Add(stackTrace);
			if (base.GetComponent<DebugConsole>() != null)
			{
				DebugConsole.Log(logString);
				DebugConsole.Log(stackTrace);
			}
		}
	}

	public static void Log(params object[] objs)
	{
		string text = string.Empty;
		for (int i = 0; i < objs.Length; i++)
		{
			if (i == 0)
			{
				text = string.Format("{0}{1}", text, objs[i]);
			}
			else
			{
				text = string.Format("{0}, {1}", text, objs[i]);
			}
		}
		if (Application.isPlaying)
		{
			if (OutLog.mLines.Count > 5)
			{
				OutLog.mLines.RemoveAt(0);
			}
			OutLog.mLines.Add(text);
		}
	}
}
