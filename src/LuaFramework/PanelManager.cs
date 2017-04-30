using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ThirdParty;
using UnityEngine;

namespace LuaFramework
{
	public class PanelManager : Manager
	{
		private class PanelDestoryStrategy : CacheDestroy<string, GameObject>
		{
			public override bool CanDestroy(Node<string, GameObject> node)
			{
				return node.Value == null || !node.Value.activeSelf;
			}

			public override void DestroyNode(Node<string, GameObject> node)
			{
				UnityEngine.Object.Destroy(node.Value);
				Util.ClearMemory();
			}
		}

		private Transform parent;

		private List<string> fullScreenPanel = new List<string>();

		private Camera mainCamera;

		private LFUCache<string, GameObject> allPanel = new LFUCache<string, GameObject>(11);

		private static Dictionary<string, GameObject> dontDestroyPanel = new Dictionary<string, GameObject>();

		private Queue<string> panelQueue = new Queue<string>();

		private List<string> showPanels = new List<string>();

		private GameObject npcTalkPanel;

		public Transform Parent
		{
			get
			{
				if (this.parent == null)
				{
					GameObject gameObject = GameObject.FindWithTag("GuiCamera");
					if (gameObject != null)
					{
						this.parent = gameObject.transform;
					}
				}
				return this.parent;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			this.allPanel.SetDestroyStrategy(new PanelManager.PanelDestoryStrategy());
		}

		public void CreatePanel(string name, LuaFunction func = null, bool closeMainCamera = false, float x = 0f, float y = 0f, float z = 0f, bool dontDestroy = false, bool hideWhenClose = true)
		{
			base.StartCoroutine(this.StartCreatePanel(name, new Vector3(x, y, z), func, closeMainCamera, dontDestroy, hideWhenClose));
		}

		[DebuggerHidden]
		private IEnumerator StartCreatePanel(string name, Vector3 pos, LuaFunction func = null, bool closeMainCamera = false, bool dontDestroy = false, bool hideWhenClose = true)
		{
			PanelManager.<StartCreatePanel>c__Iterator22 <StartCreatePanel>c__Iterator = new PanelManager.<StartCreatePanel>c__Iterator22();
			<StartCreatePanel>c__Iterator.name = name;
			<StartCreatePanel>c__Iterator.func = func;
			<StartCreatePanel>c__Iterator.dontDestroy = dontDestroy;
			<StartCreatePanel>c__Iterator.hideWhenClose = hideWhenClose;
			<StartCreatePanel>c__Iterator.pos = pos;
			<StartCreatePanel>c__Iterator.closeMainCamera = closeMainCamera;
			<StartCreatePanel>c__Iterator.<$>name = name;
			<StartCreatePanel>c__Iterator.<$>func = func;
			<StartCreatePanel>c__Iterator.<$>dontDestroy = dontDestroy;
			<StartCreatePanel>c__Iterator.<$>hideWhenClose = hideWhenClose;
			<StartCreatePanel>c__Iterator.<$>pos = pos;
			<StartCreatePanel>c__Iterator.<$>closeMainCamera = closeMainCamera;
			<StartCreatePanel>c__Iterator.<>f__this = this;
			return <StartCreatePanel>c__Iterator;
		}

		private void AfterPanelLoaded(GameObject go, string prefabName, bool closeMainCamera, bool dontDestroy)
		{
			go.transform.GetOrAddComponent<LuaBehaviour>().OnInit();
			go.transform.GetOrAddComponent<UIBackgroundAdjustor>();
			if (closeMainCamera)
			{
				if (this.mainCamera == null)
				{
					this.mainCamera = Singleton<RoleManager>.Instance.mainCamera;
				}
				this.mainCamera.gameObject.SetActive(false);
				this.fullScreenPanel.Add(prefabName);
			}
			if (Singleton<RoleManager>.Instance.mainRole != null && !prefabName.Equals("MainPanel") && !prefabName.Equals("ChatPanel") && !prefabName.Equals("NpcTalkPanel") && !prefabName.Equals("DetailMapPanel") && closeMainCamera && Singleton<RoleManager>.Instance.mainRole.grade < 50)
			{
				Singleton<RoleManager>.Instance.mainRole.roleState.AddState(128);
			}
			this.panelQueue.Dequeue();
			if (!dontDestroy && prefabName != "NpcTalkPanel")
			{
				if (!this.showPanels.Contains(prefabName))
				{
					this.showPanels.Add(prefabName);
				}
				else
				{
					Debug.LogError(string.Format("{0} doesn't call 'panelMgr:ClosePanel' method when close, please check your code", prefabName));
				}
			}
			if (prefabName.Equals("NpcTalkPanel"))
			{
				this.npcTalkPanel = go;
			}
			else if (this.npcTalkPanel != null)
			{
				this.ClosePanel("NpcTalkPanel");
			}
		}

		private void SetUILayerMask(string prefabName, GameObject go)
		{
			Camera component = this.Parent.GetComponent<Camera>();
			if (go == null)
			{
				Debugger.LogError("load ui " + prefabName + " is null");
				return;
			}
			if (prefabName == "NpcTalkPanel")
			{
				go.layer = LayerMask.NameToLayer("Plot");
				component.cullingMask = 6144;
				this.CloseAllShowPanels();
			}
			else
			{
				go.layer = LayerMask.NameToLayer("UI");
				component.cullingMask = 2080;
			}
			go.SetActive(true);
		}

		private void CloseAllShowPanels()
		{
			int count = this.showPanels.Count;
			for (int i = count - 1; i >= 0; i--)
			{
				string text = this.showPanels[i];
				string text2 = text.Substring(0, text.Length - 5);
				Util.CallMethod("CtrlManager", "ClosePanel", new object[]
				{
					text2
				});
			}
		}

		public void ClosePanel(string name)
		{
			string text = name + "Panel";
			Transform transform = this.Parent.FindChild(text);
			if (transform == null)
			{
				this.showPanels.Remove(name);
				if (this.mainCamera && !this.mainCamera.gameObject.activeSelf)
				{
					Debug.LogError("main Camera not opened");
					this.UpdateFullScreenState(text);
				}
				return;
			}
			if (this.allPanel.ContainsKey(text))
			{
				GameObject gameObject = this.allPanel.Peek(text);
				if (gameObject != null)
				{
					gameObject.transform.GetOrAddComponent<LuaBehaviour>().OnClose();
					gameObject.SetActive(false);
				}
				else
				{
					Debug.LogError(string.Format("UIPanel {0} has been destroyed", text));
				}
			}
			else if (PanelManager.dontDestroyPanel.ContainsKey(text))
			{
				if (PanelManager.dontDestroyPanel[text] != null)
				{
					PanelManager.dontDestroyPanel[text].transform.localPosition = new Vector3(10000f, 0f, 0f);
					PanelManager.dontDestroyPanel[text].transform.GetOrAddComponent<LuaBehaviour>().OnClose();
				}
				else
				{
					Debug.LogError(string.Format("UIPanel {0} has been destroyed", text));
				}
			}
			else
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
			if (name == "NpcTalk")
			{
				Camera component = this.Parent.GetComponent<Camera>();
				component.cullingMask = 2080;
				this.npcTalkPanel = null;
			}
			else
			{
				this.showPanels.Remove(text);
			}
			this.UpdateFullScreenState(text);
		}

		private void UpdateFullScreenState(string panelName)
		{
			bool flag = false;
			if (this.mainCamera && !this.mainCamera.gameObject.activeSelf)
			{
				if (this.fullScreenPanel.Contains(panelName))
				{
					this.fullScreenPanel.Remove(panelName);
				}
				if (this.fullScreenPanel.Count == 0)
				{
					this.mainCamera.gameObject.SetActive(true);
				}
				flag = (this.fullScreenPanel.Count > 0);
			}
			if (Singleton<RoleManager>.Instance != null)
			{
				SceneEntity mainRole = Singleton<RoleManager>.Instance.mainRole;
				if (mainRole != null && mainRole.roleState.IsInState(128) && !flag)
				{
					mainRole.roleState.RemoveState(128);
				}
			}
		}

		public Transform GetNotifyTrans()
		{
			string name = "MainPanel";
			if (this.Parent == null)
			{
				return null;
			}
			Transform transform = this.Parent.FindChild(name);
			if (transform == null)
			{
				return null;
			}
			return transform.transform.FindChild("notifyPanel");
		}

		public void Clear()
		{
			this.fullScreenPanel.Clear();
			this.allPanel.Clear();
			this.showPanels.Clear();
		}

		public static void ModifyDontDestroyPanel()
		{
			foreach (string current in PanelManager.dontDestroyPanel.Keys)
			{
				GameObject gameObject = PanelManager.dontDestroyPanel[current];
				gameObject.transform.parent = null;
				gameObject.transform.localPosition = new Vector3(10000f, 0f, 0f);
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localRotation = Quaternion.identity;
				gameObject.transform.GetOrAddComponent<LuaBehaviour>().OnChangeSceneHide();
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
			}
		}

		public void CloseAllPopedPanels()
		{
			if (this.npcTalkPanel != null)
			{
				this.ClosePanel("NpcTalk");
			}
			else
			{
				this.CloseAllShowPanelsAfterRelive();
			}
		}

		private void CloseAllShowPanelsAfterRelive()
		{
			int count = this.showPanels.Count;
			for (int i = count - 1; i >= 0; i--)
			{
				string text = this.showPanels[i];
				string text2 = text.Substring(0, text.Length - 5);
				if (text2 != "ReliveUi" || text2 != "HusongResult")
				{
					Util.CallMethod("CtrlManager", "ClosePanel", new object[]
					{
						text2
					});
				}
			}
		}

		public bool IsPanelVisible(string name)
		{
			return this.showPanels.Contains(name);
		}
	}
}
