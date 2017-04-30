using System;
using UnityEngine;

public class MessageBox : MonoBehaviour
{
	public enum Style
	{
		OkOnly,
		OkCancel
	}

	public delegate void onButtonClicked(GameObject go);

	public UISprite okBtn;

	public UISprite cancelBtn;

	public UISprite centerBtn;

	public UILabel message;

	private static GameObject curGo;

	private MessageBox.Style style;

	private MessageBox.onButtonClicked onOkBtnClicked;

	private MessageBox.onButtonClicked onCancelBtnClicked;

	private void Register(string text)
	{
		this.message.text = text;
		if (this.style == MessageBox.Style.OkOnly)
		{
			this.okBtn.gameObject.SetActive(false);
			this.cancelBtn.gameObject.SetActive(false);
			this.centerBtn.gameObject.SetActive(true);
			UIEventListener.Get(this.centerBtn.gameObject).onClick = delegate(GameObject o)
			{
				if (this.onOkBtnClicked != null)
				{
					this.onOkBtnClicked(o);
				}
				UnityEngine.Object.Destroy(MessageBox.curGo);
			};
		}
		else if (this.style == MessageBox.Style.OkCancel)
		{
			this.okBtn.gameObject.SetActive(true);
			this.cancelBtn.gameObject.SetActive(true);
			this.centerBtn.gameObject.SetActive(false);
			UIEventListener.Get(this.okBtn.gameObject).onClick = delegate(GameObject o)
			{
				if (this.onOkBtnClicked != null)
				{
					this.onOkBtnClicked(o);
				}
				UnityEngine.Object.Destroy(MessageBox.curGo);
			};
			UIEventListener.Get(this.cancelBtn.gameObject).onClick = delegate(GameObject o)
			{
				if (this.onCancelBtnClicked != null)
				{
					this.onCancelBtnClicked(o);
				}
				UnityEngine.Object.Destroy(MessageBox.curGo);
			};
		}
	}

	public static GameObject DisplayMessageBox(string text, int style = 0, MessageBox.onButtonClicked okFunc = null, MessageBox.onButtonClicked cancelFunc = null)
	{
		if (MessageBox.curGo != null)
		{
			UnityEngine.Object.DestroyImmediate(MessageBox.curGo);
		}
		MessageBox.curGo = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Other/MessageBox"));
		GameObject gameObject = GameObject.FindWithTag("GuiCamera");
		MessageBox.curGo.transform.SetParent(gameObject.transform);
		MessageBox.curGo.transform.localScale = Vector3.one;
		MessageBox.curGo.transform.localPosition = Vector3.one;
		UnityEngine.Object.DontDestroyOnLoad(MessageBox.curGo);
		MessageBox component = MessageBox.curGo.GetComponent<MessageBox>();
		component.style = (MessageBox.Style)style;
		component.onOkBtnClicked = okFunc;
		component.onCancelBtnClicked = cancelFunc;
		component.Register(text);
		return MessageBox.curGo;
	}
}
