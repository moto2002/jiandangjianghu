using AnimationOrTween;
using System;
using UnityEngine;

public class ThirdPanel : UIPanelBase
{
	protected override void Awake()
	{
		base.Awake();
		MonoSingletion<UIPanelManager>.Instance.CreatePanel("ThirdPanel", new Action<GameObject>(this.OnCreate));
	}

	protected override void OnCreate(GameObject go)
	{
		base.OnCreate(go);
		TweenPosition tweenPosition = this.transform.GetComponent<TweenPosition>();
		this.SetOpenCloseTweener(tweenPosition, tweenPosition.onFinished, delegate
		{
			if (tweenPosition.direction == Direction.Reverse)
			{
				this.gameObject.SetActive(false);
			}
		});
		this.Open();
		UIButton component = this.transform.FindChild("CloseButton").GetComponent<UIButton>();
		EventDelegate.Add(component.onClick, delegate
		{
			this.Close();
		});
	}
}
