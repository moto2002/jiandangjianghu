using System;
using UnityEngine;

public class SecondPanel : UIPanelBase
{
	protected override void Awake()
	{
		base.Awake();
		MonoSingletion<UIPanelManager>.Instance.CreatePanel("SecondPanel", new Action<GameObject>(this.OnCreate));
	}

	protected override void OnCreate(GameObject go)
	{
		base.OnCreate(go);
		EventDelegate.Add(this.transform.FindChild("YesButton").GetComponent<UIButton>().onClick, delegate
		{
			this.Close();
			MonoSingletion<UIPanelManager>.Instance.GetPanel("FirstPanel").Close();
		});
		EventDelegate.Add(this.transform.FindChild("NoButton").GetComponent<UIButton>().onClick, delegate
		{
			this.Close();
		});
	}
}
