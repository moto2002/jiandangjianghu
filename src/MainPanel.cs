using System;
using UnityEngine;

public class MainPanel : UIPanelBase
{
	public UILabel hpLabel;

	public UILabel mpLabel;

	protected override void Awake()
	{
		base.Awake();
		MonoSingletion<UIPanelManager>.Instance.CreatePanel("MainPanel", new Action<GameObject>(this.OnCreate));
	}

	protected override void OnCreate(GameObject go)
	{
		base.OnCreate(go);
		this.hpLabel = this.transform.FindChild("HpLabel").GetComponent<UILabel>();
		this.mpLabel = this.transform.FindChild("MpLabel").GetComponent<UILabel>();
		UIEventListener.Get(this.transform.FindChild("Button1").gameObject).onClick = delegate(GameObject a)
		{
			MonoSingletion<UIPanelManager>.Instance.GetPanel("FirstPanel").Open();
		};
		UIEventListener.Get(this.transform.FindChild("Button2").gameObject).onClick = delegate(GameObject a)
		{
			MonoSingletion<UIPanelManager>.Instance.GetPanel("ThirdPanel").Open();
		};
	}
}
