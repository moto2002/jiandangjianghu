using LuaFramework;
using System;
using UnityEngine;

public class TestScript : MonoBehaviour
{
	public int state;

	public bool needLoop;

	private Animator ani;

	private float Fomat;

	private int mAnimIndex;

	private void Start()
	{
		B.Main();
	}

	private void Update()
	{
		if (this.ani == null)
		{
			return;
		}
		this.ani.SetInteger("status", this.state);
		AnimatorStateInfo currentAnimatorStateInfo = this.ani.GetCurrentAnimatorStateInfo(0);
		if (!currentAnimatorStateInfo.loop && currentAnimatorStateInfo.normalizedTime >= 1f && this.needLoop)
		{
			this.ani.Play(Enum.Parse(typeof(RoleAction.state), this.state.ToString()).ToString(), 0, 0f);
		}
	}

	public void BtnClick()
	{
		GameObject gameObject = GameObject.Find("girl_02");
		Animator componentInChildren = gameObject.GetComponentInChildren<Animator>();
		if (componentInChildren)
		{
		}
		this.mAnimIndex++;
		AnimatorStateInfo currentAnimatorStateInfo = componentInChildren.GetCurrentAnimatorStateInfo(0);
		componentInChildren.CrossFade("run", 0.2f);
		componentInChildren.CrossFade("attcked", 0.2f);
		if (currentAnimatorStateInfo.IsName("warwait"))
		{
			componentInChildren.speed = 2f;
		}
		else
		{
			componentInChildren.speed = 1f;
		}
	}

	public static Vector3 WorldToUI(Vector3 point)
	{
		Vector3 position = Camera.main.WorldToScreenPoint(point);
		Vector3 result = UICamera.currentCamera.ScreenToWorldPoint(position);
		result.z = 0f;
		return result;
	}

	private void LoomTest()
	{
		string str = "我是一个bug!";
		Loom.RunAsync(delegate
		{
			str = "好了";
			Loom.QueueOnMainThread(delegate
			{
				Debug.LogWarning(str);
			});
		});
	}

	public void CallLuaTest()
	{
		object message = Util.CallMethod("CtrlManager", "GetCtrlGo", new object[]
		{
			"MainCtrl"
		});
		Debug.Log(message);
	}

	public void CallLuaTest1()
	{
		object message = Util.CallMethod("HEROSKILLMGR", "Test", new object[0]);
		Debug.Log(message);
		object message2 = Util.CallMethod("HERO", "GetHeroAttr", new object[]
		{
			"Id"
		});
		Debug.Log(message2);
	}

	public void OnSubmitTest()
	{
		MonoBehaviour.print("-------------------");
	}

	public void TestSpriteNumbers()
	{
		GameObject gameObject = new GameObject("Sprite");
		UISprite orAddComponent = gameObject.transform.GetOrAddComponent<UISprite>();
		orAddComponent.spriteName = "fight";
		gameObject.transform.SetParent(base.transform);
	}
}
