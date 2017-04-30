using LuaInterface;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugConsole : MonoBehaviour
{
	public enum MessageType
	{
		NORMAL,
		WARNING,
		ERROR,
		SYSTEM,
		INPUT,
		OUTPUT
	}

	private struct Message
	{
		private string text;

		private string formatted;

		public int sameMsgCount;

		private DebugConsole.MessageType type;

		public static Color defaultColor = Color.white;

		public static Color warningColor = Color.yellow;

		public static Color errorColor = Color.red;

		public static Color systemColor = Color.green;

		public static Color inputColor = Color.green;

		public static Color outputColor = Color.cyan;

		public Color color
		{
			get;
			private set;
		}

		public Message(object messageObject)
		{
			this = new DebugConsole.Message(messageObject, DebugConsole.MessageType.NORMAL, DebugConsole.Message.defaultColor);
		}

		public Message(object messageObject, Color displayColor)
		{
			this = new DebugConsole.Message(messageObject, DebugConsole.MessageType.NORMAL, displayColor);
		}

		public Message(object messageObject, DebugConsole.MessageType messageType)
		{
			this = new DebugConsole.Message(messageObject, messageType, DebugConsole.Message.defaultColor);
			switch (messageType)
			{
			case DebugConsole.MessageType.WARNING:
				this.color = DebugConsole.Message.warningColor;
				break;
			case DebugConsole.MessageType.ERROR:
				this.color = DebugConsole.Message.errorColor;
				break;
			case DebugConsole.MessageType.SYSTEM:
				this.color = DebugConsole.Message.systemColor;
				break;
			case DebugConsole.MessageType.INPUT:
				this.color = DebugConsole.Message.inputColor;
				break;
			case DebugConsole.MessageType.OUTPUT:
				this.color = DebugConsole.Message.outputColor;
				break;
			}
		}

		public Message(object messageObject, DebugConsole.MessageType messageType, Color displayColor)
		{
			if (messageObject == null)
			{
				this.text = "<null>";
			}
			else
			{
				this.text = messageObject.ToString();
			}
			this.formatted = string.Empty;
			this.type = messageType;
			this.color = displayColor;
		}

		public void MsgCountAdd()
		{
			this.sameMsgCount++;
			Debug.Log("Count=" + this.sameMsgCount);
		}

		public static DebugConsole.Message Log(object message)
		{
			return new DebugConsole.Message(message, DebugConsole.MessageType.NORMAL, DebugConsole.Message.defaultColor);
		}

		public static DebugConsole.Message System(object message)
		{
			return new DebugConsole.Message(message, DebugConsole.MessageType.SYSTEM, DebugConsole.Message.systemColor);
		}

		public static DebugConsole.Message Warning(object message)
		{
			return new DebugConsole.Message(message, DebugConsole.MessageType.WARNING, DebugConsole.Message.warningColor);
		}

		public static DebugConsole.Message Error(object message)
		{
			return new DebugConsole.Message(message, DebugConsole.MessageType.ERROR, DebugConsole.Message.errorColor);
		}

		public static DebugConsole.Message Output(object message)
		{
			return new DebugConsole.Message(message, DebugConsole.MessageType.OUTPUT, DebugConsole.Message.outputColor);
		}

		public static DebugConsole.Message Input(object message)
		{
			return new DebugConsole.Message(message, DebugConsole.MessageType.INPUT, DebugConsole.Message.inputColor);
		}

		public override string ToString()
		{
			DebugConsole.MessageType messageType = this.type;
			if (messageType == DebugConsole.MessageType.WARNING)
			{
				return string.Format("[{0}] {1}", this.type, this.text);
			}
			if (messageType != DebugConsole.MessageType.ERROR)
			{
				return this.ToGUIString();
			}
			return string.Format("[{0}] {1}", this.type, this.text);
		}

		public string ToGUIString()
		{
			if (!string.IsNullOrEmpty(this.formatted))
			{
				return this.formatted;
			}
			switch (this.type)
			{
			case DebugConsole.MessageType.WARNING:
				this.formatted = "* " + this.text;
				break;
			case DebugConsole.MessageType.ERROR:
				this.formatted = "** " + this.text;
				break;
			case DebugConsole.MessageType.SYSTEM:
				this.formatted = "# " + this.text;
				break;
			case DebugConsole.MessageType.INPUT:
				this.formatted = ">>> " + this.text;
				break;
			case DebugConsole.MessageType.OUTPUT:
			{
				string[] array = this.text.Trim(new char[]
				{
					'\n'
				}).Split(new char[]
				{
					'\n'
				});
				StringBuilder stringBuilder = new StringBuilder();
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string str = array2[i];
					stringBuilder.AppendLine("= " + str);
				}
				this.formatted = stringBuilder.ToString();
				break;
			}
			default:
				this.formatted = this.text;
				break;
			}
			return this.formatted;
		}
	}

	private class History
	{
		private List<string> history = new List<string>();

		private int index;

		private string current;

		public void Add(string item)
		{
			this.history.Add(item);
			this.index = 0;
		}

		public string Fetch(string current, bool next)
		{
			if (this.index == 0)
			{
				this.current = current;
			}
			if (this.history.Count == 0)
			{
				return current;
			}
			this.index += ((!next) ? 1 : -1);
			if (this.history.Count + this.index < 0 || this.history.Count + this.index > this.history.Count - 1)
			{
				this.index = 0;
				return this.current;
			}
			return this.history[this.history.Count + this.index];
		}
	}

	public delegate object DebugCommand(params string[] args);

	private readonly Version VERSION = new Version("3.0");

	private readonly string ENTRYFIELD = "DebugConsoleEntryField";

	public int maxLinesForDisplay = 500;

	public Color defaultColor = DebugConsole.Message.defaultColor;

	public Color warningColor = DebugConsole.Message.warningColor;

	public Color errorColor = DebugConsole.Message.errorColor;

	public Color systemColor = DebugConsole.Message.systemColor;

	public Color inputColor = DebugConsole.Message.inputColor;

	public Color outputColor = DebugConsole.Message.outputColor;

	public bool IsDebug = true;

	public static KeyCode toggleKey = KeyCode.BackQuote;

	private static DebugConsole _instance;

	private Dictionary<string, DebugConsole.DebugCommand> _cmdTable = new Dictionary<string, DebugConsole.DebugCommand>();

	private Dictionary<string, string> _cmdTableDiscribes = new Dictionary<string, string>();

	private Dictionary<string, WatchVarBase> _watchVarTable = new Dictionary<string, WatchVarBase>();

	private string _inputString = string.Empty;

	public Rect _windowRect;

	private Vector2 _logScrollPos = Vector2.zero;

	private Vector2 _rawLogScrollPos = Vector2.zero;

	private Vector2 _watchVarsScrollPos = Vector2.zero;

	public bool _isOpen;

	private StringBuilder _displayString = new StringBuilder();

	private FPSCounter fps;

	private bool dirty;

	private Rect scrollRect = new Rect(10f, 20f, 940f, 560f);

	private Rect inputRect = new Rect(10f, 608f, 940f, 40f);

	private Rect toolbarRect = new Rect(16f, 658f, 725f, 55f);

	private Rect enterButtonRect = new Rect(745f, 658f, 199f, 55f);

	private Rect messageLine = new Rect(4f, 0f, 900f, 20f);

	private int lineOffset = -4;

	private string[] tabs = new string[]
	{
		"Log",
		"Copy Log",
		"Watch Vars"
	};

	private Rect nameRect;

	private Rect valueRect;

	private Rect innerRect = new Rect(0f, 0f, 0f, 0f);

	private int innerHeight;

	private int toolbarIndex;

	private GUIContent guiContent = new GUIContent();

	private GUI.WindowFunction[] windowMethods;

	private GUIStyle labelStyle;

	private List<DebugConsole.Message> _messages = new List<DebugConsole.Message>();

	private DebugConsole.History _history = new DebugConsole.History();

	public static bool IsOpen
	{
		get
		{
			return DebugConsole.Instance._isOpen;
		}
		set
		{
			DebugConsole.Instance._isOpen = value;
		}
	}

	public static DebugConsole Instance
	{
		get
		{
			if (DebugConsole._instance == null)
			{
				DebugConsole._instance = (UnityEngine.Object.FindObjectOfType(typeof(DebugConsole)) as DebugConsole);
			}
			return DebugConsole._instance;
		}
	}

	private void Awake()
	{
		if (DebugConsole._instance != null && DebugConsole._instance != this)
		{
			UnityEngine.Object.DestroyImmediate(this, true);
			return;
		}
		DebugConsole._instance = this;
		UnityEngine.Object.DontDestroyOnLoad(DebugConsole._instance);
	}

	public void InitPosition()
	{
		this._windowRect = new Rect((float)(Screen.width / 2 - 300), 30f, 960f, 720f);
	}

	private void OnEnable()
	{
		this.windowMethods = new GUI.WindowFunction[]
		{
			new GUI.WindowFunction(this.LogWindow),
			new GUI.WindowFunction(this.CopyLogWindow),
			new GUI.WindowFunction(this.WatchVarWindow)
		};
		this.fps = new FPSCounter();
		base.StartCoroutine(this.fps.Update());
		this.nameRect = this.messageLine;
		this.valueRect = this.messageLine;
		DebugConsole.Message.defaultColor = this.defaultColor;
		DebugConsole.Message.warningColor = this.warningColor;
		DebugConsole.Message.errorColor = this.errorColor;
		DebugConsole.Message.systemColor = this.systemColor;
		DebugConsole.Message.inputColor = this.inputColor;
		DebugConsole.Message.outputColor = this.outputColor;
		this._windowRect = new Rect((float)(Screen.width / 2 - 300), 30f, 960f, 720f);
		this.LogMessage(DebugConsole.Message.System("输入 '/?' 显示帮助"));
		this.LogMessage(DebugConsole.Message.Log(string.Empty));
		this.RegisterCommandCallback("close", new DebugConsole.DebugCommand(this.CMDClose), "关闭调试窗口");
		this.RegisterCommandCallback("clear", new DebugConsole.DebugCommand(this.CMDClear), "清除调试信息");
		this.RegisterCommandCallback("sys", new DebugConsole.DebugCommand(this.CMDSystemInfo), "显示系统信息");
		this.RegisterCommandCallback("/?", new DebugConsole.DebugCommand(this.CMDHelp), "显示可用命令");
		this.RegisterCommandCallback("openlog", new DebugConsole.DebugCommand(this.CMDOpenLog), "打来Log显示");
		this.RegisterCommandCallback("closelog", new DebugConsole.DebugCommand(this.CMDCloseLog), "关闭Log显示");
	}

	private void OnGUI()
	{
		if (!this.IsDebug)
		{
			return;
		}
		while (this._messages.Count > this.maxLinesForDisplay)
		{
			this._messages.RemoveAt(0);
		}
		if (Event.current.keyCode == DebugConsole.toggleKey && Event.current.type == EventType.KeyUp)
		{
			this._isOpen = !this._isOpen;
		}
		if (Input.touchCount == 3)
		{
			this._isOpen = !this._isOpen;
		}
		if (!this._isOpen)
		{
			return;
		}
		this.labelStyle = GUI.skin.label;
		this.innerRect.width = this.messageLine.width;
		this._windowRect = GUI.Window(-1111, this._windowRect, this.windowMethods[this.toolbarIndex], string.Format("Debug Console v{0}\tfps: {1:00.0}", this.VERSION, this.fps.current));
		GUI.BringWindowToFront(-1111);
		if (GUI.GetNameOfFocusedControl() == this.ENTRYFIELD)
		{
			Event current = Event.current;
			if (current.isKey && current.type == EventType.KeyUp)
			{
				if (current.keyCode == KeyCode.Return)
				{
					this.EvalInputString(this._inputString);
					this._inputString = string.Empty;
				}
				else if (current.keyCode == KeyCode.UpArrow)
				{
					this._inputString = this._history.Fetch(this._inputString, true);
				}
				else if (current.keyCode == KeyCode.DownArrow)
				{
					this._inputString = this._history.Fetch(this._inputString, false);
				}
			}
		}
	}

	private void OnDestroy()
	{
		base.StopAllCoroutines();
	}

	public static object Log(object message)
	{
		if (!DebugConsole.Instance.IsDebug)
		{
			return null;
		}
		DebugConsole.Instance.LogMessage(DebugConsole.Message.Log(message));
		return message;
	}

	public static object Log(object message, DebugConsole.MessageType messageType)
	{
		if (!DebugConsole.Instance.IsDebug)
		{
			return null;
		}
		DebugConsole.Instance.LogMessage(new DebugConsole.Message(message, messageType));
		return message;
	}

	public static object Log(object message, Color displayColor)
	{
		if (!DebugConsole.Instance.IsDebug)
		{
			return null;
		}
		DebugConsole.Instance.LogMessage(new DebugConsole.Message(message, displayColor));
		return message;
	}

	public static object Log(object message, DebugConsole.MessageType messageType, Color displayColor)
	{
		if (!DebugConsole.Instance.IsDebug)
		{
			return null;
		}
		DebugConsole.Instance.LogMessage(new DebugConsole.Message(message, messageType, displayColor));
		return message;
	}

	public static object LogWarning(object message)
	{
		if (!DebugConsole.Instance.IsDebug)
		{
			return null;
		}
		DebugConsole.Instance.LogMessage(DebugConsole.Message.Warning(message));
		return message;
	}

	public static object LogError(object message)
	{
		if (!DebugConsole.Instance.IsDebug)
		{
			return null;
		}
		DebugConsole.Instance.LogMessage(DebugConsole.Message.Error(message));
		return message;
	}

	public static void Clear()
	{
		DebugConsole.Instance.ClearLog();
	}

	public static void RegisterCommand(string commandString, DebugConsole.DebugCommand commandCallback, string CMD_Discribes)
	{
		DebugConsole.Instance.RegisterCommandCallback(commandString, commandCallback, CMD_Discribes);
	}

	public static void UnRegisterCommand(string commandString)
	{
		DebugConsole.Instance.UnRegisterCommandCallback(commandString);
	}

	public static void RegisterWatchVar(WatchVarBase watchVar)
	{
		DebugConsole.Instance.AddWatchVarToTable(watchVar);
	}

	public static void UnRegisterWatchVar(string name)
	{
		DebugConsole.Instance.RemoveWatchVarFromTable(name);
	}

	private object CMDClose(params string[] args)
	{
		this._isOpen = false;
		base.enabled = false;
		return "closed";
	}

	private object CMDClear(params string[] args)
	{
		this.ClearLog();
		return "clear";
	}

	private object CMDHelp(params string[] args)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("可用命令列表: ");
		stringBuilder.AppendLine("--------------------------");
		foreach (string current in this._cmdTable.Keys)
		{
			stringBuilder.AppendLine(this._cmdTableDiscribes[current] + "  " + current);
		}
		stringBuilder.Append("--------------------------");
		return stringBuilder.ToString();
	}

	private object CMDSystemInfo(params string[] args)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Unity Ver: " + Application.unityVersion);
		stringBuilder.AppendLine("Platform: " + Application.platform);
		stringBuilder.AppendLine("Language: " + Application.systemLanguage);
		stringBuilder.AppendLine(string.Format("Level: {0} [{1}]", SceneManager.GetActiveScene().name, SceneManager.GetActiveScene().buildIndex));
		stringBuilder.AppendLine("Data Path: " + Application.dataPath);
		stringBuilder.AppendLine("Persistent Path: " + Application.persistentDataPath);
		stringBuilder.AppendLine("SystemMemorySize: " + SystemInfo.systemMemorySize);
		stringBuilder.AppendLine("DeviceModel: " + SystemInfo.deviceModel);
		stringBuilder.AppendLine("DeviceType: " + SystemInfo.deviceType);
		stringBuilder.AppendLine("GraphicsDeviceName: " + SystemInfo.graphicsDeviceName);
		stringBuilder.AppendLine("GraphicsMemorySize: " + SystemInfo.graphicsMemorySize);
		stringBuilder.AppendLine("GraphicsShaderLevel: " + SystemInfo.graphicsShaderLevel);
		stringBuilder.AppendLine("MaxTextureSize: " + SystemInfo.maxTextureSize);
		stringBuilder.AppendLine("OperatingSystem: " + SystemInfo.operatingSystem);
		stringBuilder.AppendLine("ProcessorCount: " + SystemInfo.processorCount);
		stringBuilder.AppendLine("Profiler.enabled = : " + Profiler.enabled.ToString());
		GC.Collect();
		stringBuilder.AppendLine(string.Format("Total memory: {0:###,###,###,##0} kb", (float)GC.GetTotalMemory(true) / 1024f));
		return stringBuilder.ToString();
	}

	private object CMDOpenLog(params string[] args)
	{
		Debugger.useLog = true;
		return "Debug.Log() - Open";
	}

	private object CMDCloseLog(params string[] args)
	{
		Debugger.useLog = false;
		return "Debug.Log() - Close";
	}

	private void DrawBottomControls()
	{
		GUI.SetNextControlName(this.ENTRYFIELD);
		this._inputString = GUI.TextField(this.inputRect, this._inputString);
		int num = GUI.Toolbar(this.toolbarRect, this.toolbarIndex, this.tabs);
		if (num != this.toolbarIndex)
		{
			this.toolbarIndex = num;
		}
		if (GUI.Button(this.enterButtonRect, "Enter"))
		{
			this.EvalInputString(this._inputString);
			this._inputString = string.Empty;
		}
		GUI.DragWindow();
	}

	private void LogWindow(int windowID)
	{
		GUI.Box(this.scrollRect, string.Empty);
		this.innerRect.height = (((float)this.innerHeight >= this.scrollRect.height) ? ((float)this.innerHeight) : this.scrollRect.height);
		this._logScrollPos = GUI.BeginScrollView(this.scrollRect, this._logScrollPos, this.innerRect, false, true);
		if (this._messages != null || this._messages.Count > 0)
		{
			Color contentColor = GUI.contentColor;
			this.messageLine.y = 0f;
			foreach (DebugConsole.Message current in this._messages)
			{
				GUI.contentColor = current.color;
				this.guiContent.text = current.ToGUIString();
				this.messageLine.height = this.labelStyle.CalcHeight(this.guiContent, this.messageLine.width);
				GUI.Label(this.messageLine, this.guiContent);
				this.messageLine.y = this.messageLine.y + (this.messageLine.height + (float)this.lineOffset);
				this.innerHeight = ((this.messageLine.y <= this.scrollRect.height) ? ((int)this.scrollRect.height) : ((int)this.messageLine.y));
			}
			GUI.contentColor = contentColor;
		}
		GUI.EndScrollView();
		this.DrawBottomControls();
	}

	private string BuildDisplayString()
	{
		if (this._messages == null)
		{
			return string.Empty;
		}
		if (!this.dirty)
		{
			return this._displayString.ToString();
		}
		this.dirty = false;
		this._displayString.Length = 0;
		for (int i = 0; i < this._messages.Count; i++)
		{
			if (i <= 0 || !(this._messages[i].ToString() == this._messages[i - 1].ToString()))
			{
				this._displayString.AppendLine(this._messages[i].ToString());
			}
		}
		return this._displayString.ToString();
	}

	private void CopyLogWindow(int windowID)
	{
		this.guiContent.text = this.BuildDisplayString();
		float num = GUI.skin.textArea.CalcHeight(this.guiContent, this.messageLine.width);
		this.innerRect.height = ((num >= this.scrollRect.height) ? num : this.scrollRect.height);
		this._rawLogScrollPos = GUI.BeginScrollView(this.scrollRect, this._rawLogScrollPos, this.innerRect, false, true);
		GUI.TextArea(this.innerRect, this.guiContent.text);
		GUI.EndScrollView();
		this.DrawBottomControls();
	}

	private void WatchVarWindow(int windowID)
	{
		GUI.Box(this.scrollRect, string.Empty);
		this.innerRect.height = (((float)this.innerHeight >= this.scrollRect.height) ? ((float)this.innerHeight) : this.scrollRect.height);
		this._watchVarsScrollPos = GUI.BeginScrollView(this.scrollRect, this._watchVarsScrollPos, this.innerRect, false, true);
		int num = 0;
		float y = 0f;
		this.valueRect.y = y;
		this.nameRect.y = y;
		this.nameRect.x = this.messageLine.x;
		float num2 = this.messageLine.width - this.messageLine.x;
		GUIStyle textArea = GUI.skin.textArea;
		foreach (KeyValuePair<string, WatchVarBase> current in this._watchVarTable)
		{
			GUIContent content = new GUIContent(string.Format("{0}:", current.Value.Name));
			GUIContent gUIContent = new GUIContent(current.Value.ToString());
			float num3;
			float num4;
			this.labelStyle.CalcMinMaxWidth(content, out num3, out num4);
			float num5;
			float num6;
			textArea.CalcMinMaxWidth(gUIContent, out num5, out num6);
			if (num4 > num2)
			{
				this.nameRect.width = num2 - num5;
				this.valueRect.width = num5;
			}
			else if (num6 + num4 > num2)
			{
				this.valueRect.width = num2 - num3;
				this.nameRect.width = num3;
			}
			else
			{
				this.valueRect.width = num6;
				this.nameRect.width = num4;
			}
			this.nameRect.height = this.labelStyle.CalcHeight(content, this.nameRect.width);
			this.valueRect.height = textArea.CalcHeight(gUIContent, this.valueRect.width);
			this.valueRect.x = num2 - this.valueRect.width + this.nameRect.x;
			GUI.Label(this.nameRect, content);
			GUI.TextArea(this.valueRect, gUIContent.text);
			float num7 = Mathf.Max(this.nameRect.height, this.valueRect.height) + 4f;
			this.nameRect.y = this.nameRect.y + num7;
			this.valueRect.y = this.valueRect.y + num7;
			this.innerHeight = ((this.valueRect.y <= this.scrollRect.height) ? ((int)this.scrollRect.height) : ((int)this.valueRect.y));
			num++;
		}
		GUI.EndScrollView();
		this.DrawBottomControls();
	}

	private void LogMessage(DebugConsole.Message msg)
	{
		this._messages.Add(msg);
		this._logScrollPos.y = 50000f;
		this._rawLogScrollPos.y = 50000f;
		this.dirty = true;
	}

	private void ClearLog()
	{
		this._messages.Clear();
	}

	private void RegisterCommandCallback(string commandString, DebugConsole.DebugCommand commandCallback, string CMD_Discribes)
	{
		try
		{
			this._cmdTable[commandString] = new DebugConsole.DebugCommand(commandCallback.Invoke);
			this._cmdTableDiscribes.Add(commandString, CMD_Discribes);
		}
		catch (Exception ex)
		{
			Debug.Log(ex.Message);
		}
	}

	private void UnRegisterCommandCallback(string commandString)
	{
		try
		{
			this._cmdTable.Remove(commandString);
			this._cmdTableDiscribes.Remove(commandString);
		}
		catch (Exception ex)
		{
			Debug.Log(ex.Message);
		}
	}

	private void AddWatchVarToTable(WatchVarBase watchVar)
	{
		this._watchVarTable[watchVar.Name] = watchVar;
	}

	private void RemoveWatchVarFromTable(string name)
	{
		this._watchVarTable.Remove(name);
	}

	private void EvalInputString(string inputString)
	{
		string[] array = inputString.Split(new char[]
		{
			' '
		}, StringSplitOptions.RemoveEmptyEntries);
		this._history.Add(inputString);
		if (array.Length == 0)
		{
			this.LogMessage(DebugConsole.Message.Input(string.Empty));
			return;
		}
		this.LogMessage(DebugConsole.Message.Input(inputString));
		string text = array[0];
		if (this._cmdTable.ContainsKey(text))
		{
			DebugConsole.Log(this._cmdTable[text](array), DebugConsole.MessageType.OUTPUT);
		}
		else
		{
			this.LogMessage(DebugConsole.Message.Output(string.Format("*** Unknown Command: {0} ***", text)));
		}
	}

	public void ExecCMDInputString(string inputCMD)
	{
		this.EvalInputString(inputCMD);
	}
}
