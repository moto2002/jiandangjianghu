using LuaInterface;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TestEventListener : MonoBehaviour
{
	public delegate void VoidDelegate(GameObject go);

	public delegate void OnClick(GameObject go);

	public TestEventListener.OnClick onClick = delegate
	{
	};

	public Func<bool> TestFunc;

	public event TestEventListener.OnClick onClickEvent
	{
		[MethodImpl(32)]
		add
		{
			this.onClickEvent = (TestEventListener.OnClick)Delegate.Combine(this.onClickEvent, value);
		}
		[MethodImpl(32)]
		remove
		{
			this.onClickEvent = (TestEventListener.OnClick)Delegate.Remove(this.onClickEvent, value);
		}
	}

	public TestEventListener()
	{
		this.onClickEvent = delegate
		{
		};
		base..ctor();
	}

	public void SetOnFinished(TestEventListener.OnClick click)
	{
		Debugger.Log("SetOnFinished OnClick");
	}

	public void SetOnFinished(TestEventListener.VoidDelegate click)
	{
		Debugger.Log("SetOnFinished VoidDelegate");
	}

	[NoToLua]
	public void OnClickEvent(GameObject go)
	{
		this.onClickEvent(go);
	}
}
