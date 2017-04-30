using System;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelManager : MonoSingletion<UIPanelManager>
{
	private const string UIROOT_NAME = "UI Root";

	private Transform rootTra;

	private Dictionary<string, UIPanelBase> namePanel = new Dictionary<string, UIPanelBase>();

	private int panelDepth;

	private void Awake()
	{
		new UIPanelConfigure();
	}

	private void Start()
	{
	}

	public void CreatePanel(string name, Action<GameObject> action)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>(name));
		if (this.rootTra == null)
		{
			this.rootTra = GameObject.Find("UI Root").transform;
		}
		gameObject.transform.SetParent(this.rootTra);
		gameObject.transform.localScale = Vector3.one;
		UIPanel component = gameObject.GetComponent<UIPanel>();
		if (component != null)
		{
			component.depth = this.panelDepth;
			this.panelDepth++;
		}
		action(gameObject);
	}

	public UIPanelBase GetPanel(string name)
	{
		return this.namePanel[name];
	}

	public void AddPanel(string name, UIPanelBase panel)
	{
		this.namePanel.Add(name, panel);
	}

	public void RemovePanel(string name, UIPanelBase panel)
	{
		this.namePanel.Remove(name);
	}

	public void RemovePanelAll()
	{
	}

	public void ClosePanelAll()
	{
	}
}
