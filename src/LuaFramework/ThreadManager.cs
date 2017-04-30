using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using UnityEngine;

namespace LuaFramework
{
	public class ThreadManager : Manager
	{
		private delegate void ThreadSyncEvent(NotiData data);

		private Thread thread;

		private Action<NotiData> func;

		private Stopwatch sw = new Stopwatch();

		private string currDownFile = string.Empty;

		private static readonly object m_lockObject = new object();

		private static Queue<ThreadEvent> events = new Queue<ThreadEvent>();

		private ThreadManager.ThreadSyncEvent m_SyncEvent;

		private FastZip fz;

		private FastZipEvents fzEvents;

		private new void Awake()
		{
			this.m_SyncEvent = new ThreadManager.ThreadSyncEvent(this.OnSyncEvent);
			this.thread = new Thread(new ThreadStart(this.OnUpdate));
		}

		private new void Start()
		{
			this.thread.Start();
		}

		public void AddEvent(ThreadEvent ev, Action<NotiData> func)
		{
			object lockObject = ThreadManager.m_lockObject;
			lock (lockObject)
			{
				this.func = func;
				ThreadManager.events.Enqueue(ev);
			}
		}

		private void OnSyncEvent(NotiData data)
		{
			if (this.func != null)
			{
				this.func(data);
			}
			base.facade.SendMessageCommand(data.evName, data.evParam);
		}

		private void OnUpdate()
		{
			while (true)
			{
				object lockObject = ThreadManager.m_lockObject;
				lock (lockObject)
				{
					if (ThreadManager.events.Count > 0)
					{
						ThreadEvent threadEvent = ThreadManager.events.Dequeue();
						try
						{
							string key = threadEvent.Key;
							if (key != null)
							{
								if (ThreadManager.<>f__switch$map7 == null)
								{
									ThreadManager.<>f__switch$map7 = new Dictionary<string, int>(2)
									{
										{
											"UpdateExtract",
											0
										},
										{
											"UpdateDownload",
											1
										}
									};
								}
								int num;
								if (ThreadManager.<>f__switch$map7.TryGetValue(key, out num))
								{
									if (num != 0)
									{
										if (num == 1)
										{
											this.OnDownloadFile(threadEvent.evParams);
										}
									}
									else
									{
										this.OnExtractFile(threadEvent.evParams);
									}
								}
							}
						}
						catch (Exception ex)
						{
							Debug.LogError(ex.Message);
						}
					}
				}
				Thread.Sleep(1);
			}
		}

		private void OnDownloadFile(List<object> evParams)
		{
			string uriString = evParams[0].ToString();
			this.currDownFile = evParams[1].ToString();
			try
			{
				using (WebClient webClient = new WebClient())
				{
					this.sw.Start();
					webClient.Proxy = null;
					if (ServicePointManager.DefaultConnectionLimit != 500)
					{
						ServicePointManager.DefaultConnectionLimit = 500;
					}
					webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.ProgressChanged);
					webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.FileDownloaded);
					webClient.DownloadFileAsync(new Uri(uriString), this.currDownFile);
				}
			}
			catch (Exception ex)
			{
				NotiData data = new NotiData("UpdateFailed", this.currDownFile, ex.Message);
				if (this.m_SyncEvent != null)
				{
					this.m_SyncEvent(data);
				}
				this.sw.Reset();
			}
		}

		private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			string param = string.Empty;
			double num = (double)e.BytesReceived / 1024.0 / this.sw.Elapsed.TotalSeconds;
			if (num > 1024.0)
			{
				param = string.Format("{0} mb/s", (num / 1024.0).ToString("0.00"));
			}
			else
			{
				param = string.Format("{0} kb/s", num.ToString("0.00"));
			}
			NotiData data = new NotiData("UpdateProgress", param, e.ProgressPercentage);
			if (this.m_SyncEvent != null)
			{
				this.m_SyncEvent(data);
			}
			if (e.ProgressPercentage == 100 && e.BytesReceived == e.TotalBytesToReceive)
			{
				this.sw.Reset();
				data = new NotiData("UpdateDownload", this.currDownFile, null);
				if (this.m_SyncEvent != null)
				{
					this.m_SyncEvent(data);
				}
			}
		}

		private void FileDownloaded(object sender, AsyncCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				NotiData data = new NotiData("UpdateFailed", this.currDownFile, e.Error.Message);
				if (this.m_SyncEvent != null)
				{
					this.m_SyncEvent(data);
				}
				this.sw.Reset();
			}
		}

		private void ExtractProgressChanged(long fileSize, long processSize, string outFile)
		{
			NotiData data = new NotiData("ExtractProgress", (double)processSize / (double)fileSize, null);
			if (this.m_SyncEvent != null)
			{
				this.m_SyncEvent(data);
			}
			if (fileSize == processSize)
			{
				data = new NotiData("UpdateExtract", outFile, null);
				if (this.m_SyncEvent != null)
				{
					this.m_SyncEvent(data);
				}
			}
		}

		private void OnExtractFile(List<object> evParams)
		{
			if (evParams.Count == 2)
			{
				try
				{
					string zipFileName = evParams[0] as string;
					string targetDirectory = evParams[1] as string;
					if (this.fzEvents == null)
					{
						this.fzEvents = new FastZipEvents();
						FastZipEvents expr_42 = this.fzEvents;
						expr_42.CompletedFile = (CompletedFileHandler)Delegate.Combine(expr_42.CompletedFile, new CompletedFileHandler(this.FileCompleteListener));
						FastZipEvents expr_69 = this.fzEvents;
						expr_69.Progress = (ProgressHandler)Delegate.Combine(expr_69.Progress, new ProgressHandler(this.ProgressChangeListener));
					}
					if (this.fz == null)
					{
						this.fz = new FastZip(this.fzEvents);
					}
					this.fz.ExtractZip(zipFileName, targetDirectory, null);
				}
				catch (Exception ex)
				{
					NotiData data = new NotiData("ExtractFailed", ex.Message, null);
					if (this.m_SyncEvent != null)
					{
						this.m_SyncEvent(data);
					}
				}
			}
			else
			{
				string text = "Invalid parameter count in extract zip file";
				NotiData data2 = new NotiData("ExtractFailed", text, null);
				if (this.m_SyncEvent != null)
				{
					this.m_SyncEvent(data2);
				}
				Debug.LogError(text);
			}
		}

		private void ProgressChangeListener(object sender, ProgressEventArgs e)
		{
			NotiData data = new NotiData("ExtractProgress", e.PercentComplete, null);
			if (this.m_SyncEvent != null)
			{
				this.m_SyncEvent(data);
			}
		}

		private void FileCompleteListener(object sender, ScanEventArgs e)
		{
			NotiData data = new NotiData("ExtractFinishedOne", e.Name, null);
			if (this.m_SyncEvent != null)
			{
				this.m_SyncEvent(data);
			}
		}

		private void OnDestroy()
		{
			this.thread.Abort();
		}
	}
}
