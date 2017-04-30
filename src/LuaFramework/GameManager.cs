using Config;
using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ThirdParty;
using UnityEngine;

namespace LuaFramework
{
	public class GameManager : Manager
	{
		public delegate void DownloadPackProgressChanged(float progress);

		protected static bool initialize;

		private List<string> downloadFiles = new List<string>();

		private List<string> extractFiles = new List<string>();

		private Dictionary<string, string> needDownloadPackFiles = new Dictionary<string, string>();

		private long totalSize;

		private long downloadedSize;

		private long curFileSize;

		private int curExtractIndex;

		private int totalExtractCount;

		private WWW extractWWW;

		private WWW zipWWW;

		private bool isExtractFile;

		private float totalZippedFileCount;

		private float curExtractZipIndex;

		private float zipPercent;

		private bool downloadFailed;

		private int curDownloadIndex;

		public GameManager.DownloadPackProgressChanged progressChanged;

		private int pausedIndex;

		private bool _pauseDownloading;

		private bool allowCarrierDataDownload;

		private bool beginPackDownload;

		public bool finishedBackgroundDownloading;

		private WWW updateWWW;

		private Stopwatch sw = new Stopwatch();

		public static GameVersion localVersion
		{
			get;
			set;
		}

		public static GameVersion packVersion
		{
			get;
			set;
		}

		public bool pauseDownloading
		{
			get
			{
				return this._pauseDownloading;
			}
			set
			{
				if (!value)
				{
					if (Application.internetReachability != NetworkReachability.ReachableViaLocalAreaNetwork)
					{
						MessageBox.DisplayMessageBox("您当前处于非WiFi环境下, 继续下载将产生手机流量, 确定继续？", 1, delegate(GameObject go)
						{
							this.allowCarrierDataDownload = true;
						}, delegate(GameObject go)
						{
							this.allowCarrierDataDownload = false;
						});
					}
				}
				else
				{
					this.pausedIndex = this.curDownloadIndex;
					this.allowCarrierDataDownload = false;
				}
				this._pauseDownloading = value;
			}
		}

		private new void Start()
		{
			this.Init();
		}

		private void Init()
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			this.CheckExtractResource();
			Screen.sleepTimeout = -1;
			Application.targetFrameRate = 30;
		}

		private void Update()
		{
			if (UpdateScene.Instance != null)
			{
				if (this.isExtractFile && this.extractWWW != null)
				{
					float num = ((float)this.curExtractIndex + this.extractWWW.progress) / (float)this.totalExtractCount;
					UpdateScene.Instance.SetMessage(string.Format("{0}: {1}%", "正在读取数据", (num * 100f).ToString("f0")), false);
					UpdateScene.Instance.UpdateProgress(num);
				}
				if (this.zipWWW != null)
				{
					float num2 = this.zipWWW.progress * this.zipPercent;
					UpdateScene.Instance.SetMessage(string.Format("{0}:{1}%", "正在解压文件", (int)(num2 * 100f)), false);
					UpdateScene.Instance.UpdateProgress(num2);
				}
			}
			if (this.updateWWW != null && UpdateScene.Instance != null)
			{
				long num3 = this.downloadedSize + (long)((float)this.curFileSize * this.updateWWW.progress);
				UpdateScene.Instance.SetMessage(string.Format("{0}（{1}/{2}）", "正在更新中, 请不要关闭游戏。", this.GetSizeString(num3), this.GetSizeString(this.totalSize)), false);
				UpdateScene.Instance.UpdateProgress((float)num3 / (float)this.totalSize);
			}
			if (User_Config.internal_sdk == 1 && Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
			{
				SDKInterface.Instance.SDKExit();
			}
		}

		private string GetSizeString(long size)
		{
			string arg = "MB";
			float num;
			if (size > 1048576L)
			{
				num = (float)size / 1048576f;
			}
			else if (this.totalSize > 1024L)
			{
				num = (float)size / 1024f;
				arg = "KB";
			}
			else
			{
				num = (float)size;
				arg = "B";
			}
			return string.Format("{0}{1}", num.ToString("f2"), arg);
		}

		public void InitGui()
		{
			string name = "GUI";
			GameObject gameObject = GameObject.Find(name);
			if (gameObject != null)
			{
				return;
			}
			GameObject original = Util.LoadPrefab(name);
			gameObject = UnityEngine.Object.Instantiate<GameObject>(original);
			gameObject.name = name;
		}

		public void CheckExtractResource()
		{
			base.StartCoroutine(this.GetPackageResourcesOnServer());
		}

		[DebuggerHidden]
		private IEnumerator GetPackageResourcesOnServer()
		{
			GameManager.<GetPackageResourcesOnServer>c__Iterator1E <GetPackageResourcesOnServer>c__Iterator1E = new GameManager.<GetPackageResourcesOnServer>c__Iterator1E();
			<GetPackageResourcesOnServer>c__Iterator1E.<>f__this = this;
			return <GetPackageResourcesOnServer>c__Iterator1E;
		}

		private void StartExtractAndUpdate()
		{
			bool flag = false;
			Debug.LogWarning(string.Format("Local Version:{0}, Pack Version:{1}", GameManager.localVersion.ToString(), GameManager.packVersion.ToString()));
			if (File.Exists(Util.DataPath + "extract.txt"))
			{
				flag = (GameManager.localVersion >= GameManager.packVersion);
			}
			if (flag || false)
			{
				UpdateScene.Instance.CheckServerInfo();
				return;
			}
			base.StartCoroutine(this.OnExtractResource());
		}

		public void BeginUpdate(string version, bool alwaysUpdate)
		{
			GameVersion rgv = GameVersion.CreateVersion(version);
			if (GameManager.localVersion < rgv || alwaysUpdate)
			{
				if (GameManager.localVersion < rgv)
				{
					Debug.LogWarning("检测到版本需要更新，启动更新程序");
				}
				base.StartCoroutine(this.OnUpdateResource());
			}
			else
			{
				Debug.LogWarning("版本不需要更新，直接进入登陆场景");
				base.ResManager.initialize(new Action(this.OnResourceInited));
			}
		}

		private void ExtractZipFile(string zipFile)
		{
			this.curExtractZipIndex = 0f;
			Debugger.Log("Extract " + zipFile + " to " + Util.DataPath);
			this.BeginExtract(zipFile, Util.DataPath);
		}

		[DebuggerHidden]
		private IEnumerator OnExtractResource()
		{
			GameManager.<OnExtractResource>c__Iterator1F <OnExtractResource>c__Iterator1F = new GameManager.<OnExtractResource>c__Iterator1F();
			<OnExtractResource>c__Iterator1F.<>f__this = this;
			return <OnExtractResource>c__Iterator1F;
		}

		private void CheckUpdateClick()
		{
			base.StopCoroutine(this.OnUpdateResource());
			base.StartCoroutine(this.OnUpdateResource());
		}

		[DebuggerHidden]
		private IEnumerator OnUpdateResource()
		{
			GameManager.<OnUpdateResource>c__Iterator20 <OnUpdateResource>c__Iterator = new GameManager.<OnUpdateResource>c__Iterator20();
			<OnUpdateResource>c__Iterator.<>f__this = this;
			return <OnUpdateResource>c__Iterator;
		}

		private void OnUpdateFailed(string errorMsg)
		{
			MessageBox.DisplayMessageBox(errorMsg, 0, delegate(GameObject go)
			{
				base.ResManager.initialize(new Action(this.OnResourceInited));
			}, null);
		}

		private long GetTotalDownloadSize(string[] files, List<string> needDownloadFiles)
		{
			if (needDownloadFiles == null)
			{
				needDownloadFiles = new List<string>();
			}
			string dataPath = Util.DataPath;
			long num = 0L;
			for (int i = 0; i < files.Length; i++)
			{
				if (!string.IsNullOrEmpty(files[i]))
				{
					string[] array = files[i].Split(new char[]
					{
						'|'
					});
					string text = array[0];
					string file = (dataPath + text).Trim();
					int fileStatus = this.GetFileStatus(file, files[i]);
					if (fileStatus == 1)
					{
						needDownloadFiles.Add(files[i]);
						num += Convert.ToInt64(array[2]);
					}
					if (this.needDownloadPackFiles.ContainsKey(text))
					{
						this.needDownloadPackFiles[text] = files[i];
					}
				}
			}
			return num;
		}

		private int GetFileStatus(string file, string value)
		{
			int num = 0;
			string[] array = value.TrimEnd(new char[]
			{
				'\r'
			}).Split(new char[]
			{
				'|'
			});
			int @int = PlayerPrefs.GetInt(array[0]);
			if (@int == 0)
			{
				num = 1;
				if (array.Length == 4 || array.Length == 5)
				{
					string[] array2 = Convert.ToString(array[3]).Split(new char[]
					{
						':'
					});
					int num2 = Convert.ToInt32(array2[1]);
					if (num2 == 1 && !File.Exists(file))
					{
						num = 0;
					}
					else if (num2 == 3)
					{
						num = 0;
					}
				}
			}
			else if (@int == 1)
			{
				string key = array[0] + "_md5";
				if (!File.Exists(file))
				{
					num = 1;
					PlayerPrefs.DeleteKey(key);
					PlayerPrefs.Save();
				}
				else
				{
					string @string = PlayerPrefs.GetString(array[0] + "_md5");
					string b = array[1];
					if (@string != b)
					{
						num = 1;
					}
				}
			}
			if (num == 1 && File.Exists(file))
			{
				File.Delete(file);
			}
			return num;
		}

		[DebuggerHidden]
		private IEnumerator UpdatePackResources()
		{
			GameManager.<UpdatePackResources>c__Iterator21 <UpdatePackResources>c__Iterator = new GameManager.<UpdatePackResources>c__Iterator21();
			<UpdatePackResources>c__Iterator.<>f__this = this;
			return <UpdatePackResources>c__Iterator;
		}

		private bool IsDownOK(string fileUrl, string file, string realMd5)
		{
			if (!this.downloadFiles.Contains(file))
			{
				return false;
			}
			if (MD5.ComputeHashString(file) != realMd5)
			{
				MessageBox.DisplayMessageBox(string.Format("{0}: {1}", "更新失败", "md5码不匹配"), 0, delegate(GameObject go)
				{
					this.downloadFailed = true;
				}, null);
				File.Delete(file);
				this.downloadFiles.Remove(file);
				return false;
			}
			return true;
		}

		private void BeginDownload(string url, string file)
		{
			object[] collection = new object[]
			{
				url,
				file
			};
			ThreadEvent threadEvent = new ThreadEvent();
			threadEvent.Key = "UpdateDownload";
			threadEvent.evParams.AddRange(collection);
			base.ThreadManager.AddEvent(threadEvent, new Action<NotiData>(this.OnThreadCompleted));
		}

		private void BeginExtract(string zipFile, string outPath)
		{
			object[] collection = new object[]
			{
				zipFile,
				outPath
			};
			ThreadEvent threadEvent = new ThreadEvent();
			threadEvent.Key = "UpdateExtract";
			threadEvent.evParams.AddRange(collection);
			base.ThreadManager.AddEvent(threadEvent, new Action<NotiData>(this.OnThreadCompleted));
		}

		private void OnExtractOneFile(string file)
		{
			string text = (Util.DataPath + file).Replace('\\', '/');
			Debugger.Log("Extract file: " + text);
			string value = MD5.ComputeHashString(text);
			PlayerPrefs.SetInt(file, 1);
			PlayerPrefs.SetString(file + "_md5", value);
		}

		private void OnThreadCompleted(NotiData data)
		{
			string evName = data.evName;
			switch (evName)
			{
			case "UpdateExtract":
				this.extractFiles.Add(data.evParam.ToString());
				break;
			case "UpdateDownload":
				if (UpdateScene.Instance != null)
				{
					Loom.QueueOnMainThread(delegate
					{
						this.downloadedSize += this.curFileSize;
						this.curFileSize = 0L;
						UpdateScene.Instance.UpdateProgress((float)this.downloadedSize / (float)this.totalSize);
						this.downloadFiles.Add(data.evParam.ToString());
					});
				}
				break;
			case "ExtractFinishedOne":
				Loom.QueueOnMainThread(delegate
				{
					this.OnExtractOneFile(data.evParam.ToString());
					this.curExtractZipIndex += 1f;
					if (this.curExtractZipIndex > this.totalZippedFileCount)
					{
						this.curExtractZipIndex = this.totalZippedFileCount;
					}
					float num2 = this.curExtractZipIndex / this.totalZippedFileCount;
					if (Application.platform == RuntimePlatform.Android)
					{
						num2 = this.zipPercent + this.curExtractZipIndex / this.totalZippedFileCount * (1f - this.zipPercent);
					}
					UpdateScene.Instance.SetMessage(string.Format("{0}:{1}%", "正在解压文件", (int)(num2 * 100f)), false);
					UpdateScene.Instance.UpdateProgress(num2);
				});
				break;
			case "UpdateProgress":
				if (UpdateScene.Instance != null)
				{
					Loom.QueueOnMainThread(delegate
					{
						UpdateScene.Instance.SetMessage(string.Format("{0}: {1}", "正在更新中, 请不要关闭游戏。", (string)data.evParam), false);
						UpdateScene.Instance.UpdateProgress((float)(this.downloadedSize + this.curFileSize * (long)((int)data.extParam) / 100L) / (float)this.totalSize);
					});
				}
				break;
			case "UpdateFailed":
				Loom.QueueOnMainThread(delegate
				{
					MessageBox.DisplayMessageBox(string.Format("{0}: {1}", "更新失败", data.extParam), 0, delegate(GameObject go)
					{
						this.downloadFailed = true;
					}, null);
				});
				break;
			case "ExtractFailed":
				Loom.QueueOnMainThread(delegate
				{
					MessageBox.DisplayMessageBox(string.Format("{1}: {2}", "解压失败", (string)data.evParam), 0, delegate(GameObject go)
					{
						Application.Quit();
					}, null);
				});
				break;
			}
		}

		public void OnResourceInited()
		{
			UpdateScene.Instance.UpdateProgress(0f);
			AssetBundleManager expr_14 = Singleton<AssetBundleManager>.Instance;
			expr_14.onProgressChange = (AssetBundleManager.OnProgressChanged)Delegate.Combine(expr_14.onProgressChange, new AssetBundleManager.OnProgressChanged(UpdateScene.Instance.UpdateProgress));
			UpdateScene.Instance.SetMessage("正在加载中", false);
			Singleton<AssetBundleManager>.Instance.AssetBundleInit(delegate
			{
				UpdateScene.Instance.SetMessage("加载完毕", false);
				AssetBundleManager expr_15 = Singleton<AssetBundleManager>.Instance;
				expr_15.onProgressChange = (AssetBundleManager.OnProgressChanged)Delegate.Remove(expr_15.onProgressChange, new AssetBundleManager.OnProgressChanged(UpdateScene.Instance.UpdateProgress));
				this.LuaStart();
				GameManager.initialize = true;
			});
		}

		private void LuaStart()
		{
			base.LuaManager.InitStart();
			base.LuaManager.DoFile("Logic/Network");
			base.LuaManager.DoFile("Common/define");
			base.LuaManager.DoFile("Logic/Game");
			base.NetManager.OnInit();
			Util.CallMethod("Game", "OnInitOK", new object[0]);
			this.RegisterHandlers();
		}

		private void OnPoolGetElement(TestObjectClass obj)
		{
			Debugger.Log("OnPoolGetElement--->>>" + obj);
		}

		private void OnPoolPushElement(TestObjectClass obj)
		{
			Debugger.Log("OnPoolPushElement--->>>" + obj);
		}

		private void OnDestroy()
		{
			if (base.NetManager != null)
			{
				base.NetManager.Unload();
			}
			if (base.LuaManager != null)
			{
				base.LuaManager.Close();
			}
			Debug.Log("~GameManager was destroyed");
		}

		public void RegisterHandlers()
		{
			string path = string.Empty;
			path = Util.DataPath + "lua/protocol/handlers.txt";
			string text = File.ReadAllText(path);
			string[] array = text.Split(new char[]
			{
				';'
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]))
				{
					string filename = string.Format("protocol/handler/{0}", array[i]);
					base.LuaManager.DoFile(filename);
				}
			}
		}

		public string[] GetSceneFileList()
		{
			List<string> list = new List<string>();
			string path = Path.Combine(Util.DataPath, "scenes");
			string[] files = Directory.GetFiles(path, "*.ab", SearchOption.TopDirectoryOnly);
			for (int i = 0; i < files.Length; i++)
			{
				list.Add(Path.GetFileNameWithoutExtension(files[i]));
			}
			return list.ToArray();
		}

		private bool IsAllPackResourcesDownloaded()
		{
			return this.needDownloadPackFiles.Count == 0;
		}

		public void StartDownloadPackFiles()
		{
			if (!this.IsAllPackResourcesDownloaded())
			{
				base.StartCoroutine(this.UpdatePackResources());
			}
		}

		public float GetDownloadPackProgress()
		{
			if (this.finishedBackgroundDownloading)
			{
				return 1f;
			}
			if (this.pauseDownloading)
			{
				return (float)this.pausedIndex / (float)this.needDownloadPackFiles.Count;
			}
			return (float)this.curDownloadIndex / (float)this.needDownloadPackFiles.Count;
		}

		public string GetTotalDownloadedPackSize()
		{
			long num = 0L;
			string empty = string.Empty;
			foreach (string current in this.needDownloadPackFiles.Keys)
			{
				string[] array = this.needDownloadPackFiles[current].Split(new char[]
				{
					'|'
				});
				string text = array[0];
				string path = (Util.DataPath + text).Trim();
				string b = array[1].Trim();
				if (!File.Exists(path) || !(PlayerPrefs.GetString(text + "_md5") == b))
				{
					num += Convert.ToInt64(array[2]);
				}
			}
			return this.GetSizeString(num);
		}

		public void AddDownloadPackProgressListener(GameManager.DownloadPackProgressChanged listener)
		{
			this.progressChanged = listener;
		}

		public void RemoveDownloadPackProgressListener()
		{
			this.progressChanged = null;
		}

		public bool IsStopped()
		{
			return (Application.internetReachability != NetworkReachability.ReachableViaLocalAreaNetwork && !this.allowCarrierDataDownload) || this.pauseDownloading;
		}

		private void OnApplicationQuit()
		{
			if (User_Config.internal_sdk == 1)
			{
				CenterServerManager.Instance.SetLastServer();
			}
		}
	}
}
