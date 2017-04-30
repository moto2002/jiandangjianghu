using AnimationOrTween;
using System;
using UnityEngine;

public class FirstPanel : UIPanelBase
{
	private MainPanel mainPanel;

	protected override void Awake()
	{
		base.Awake();
		MonoSingletion<UIPanelManager>.Instance.CreatePanel("FirstPanel", new Action<GameObject>(this.OnCreate));
	}

	protected override void OnCreate(GameObject go)
	{
		base.OnCreate(go);
		this.mainPanel = (MonoSingletion<UIPanelManager>.Instance.GetPanel("MainPanel") as MainPanel);
		TweenScale tweenScale = this.transform.GetComponent<TweenScale>();
		this.SetOpenCloseTweener(tweenScale, tweenScale.onFinished, delegate
		{
			if (tweenScale.direction == Direction.Reverse)
			{
				this.gameObject.SetActive(false);
			}
		});
		this.Open();
		UISlider slider = this.transform.FindChild("Slider").GetComponent<UISlider>();
		UILabel sliderLabel = slider.transform.FindChild("Label").GetComponent<UILabel>();
		EventDelegate.Add(slider.onChange, delegate
		{
			string text = (int)(slider.value * 100f) + string.Empty;
			sliderLabel.text = text;
			this.mainPanel.hpLabel.text = text;
		});
		UIPopupList popupList = this.transform.FindChild("Popup List").GetComponent<UIPopupList>();
		EventDelegate.Add(popupList.onChange, delegate
		{
			this.mainPanel.mpLabel.text = popupList.value;
		});
		UIEventListener.Get(this.transform.FindChild("CloseButton").gameObject).onClick = delegate(GameObject a)
		{
			this.Close();
		};
		UIEventListener.Get(this.transform.FindChild("EnsureButton").gameObject).onClick = delegate(GameObject a)
		{
			MonoSingletion<UIPanelManager>.Instance.GetPanel("SecondPanel").Open();
		};
	}
}
