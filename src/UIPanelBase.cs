using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIPanelBase
{
	public GameObject gameObject;

	public Transform transform;

	protected UITweener tweener;

	protected virtual void Awake()
	{
	}

	protected virtual void OnCreate(GameObject go)
	{
		this.gameObject = go;
		this.transform = this.gameObject.transform;
	}

	protected virtual void OnDestroy()
	{
	}

	public virtual void Open()
	{
		if (this.gameObject == null)
		{
			this.Awake();
		}
		else
		{
			this.gameObject.SetActive(true);
			if (this.tweener != null)
			{
				this.tweener.PlayForward();
			}
		}
	}

	public virtual void Close()
	{
		if (this.tweener != null)
		{
			this.tweener.PlayReverse();
		}
		else
		{
			this.gameObject.SetActive(false);
		}
	}

	protected virtual void SetOpenCloseTweener(UITweener tweener, List<EventDelegate> list, EventDelegate.Callback callBack)
	{
		this.tweener = tweener;
		if (list != null && callBack != null)
		{
			EventDelegate.Add(list, callBack);
		}
	}

	public virtual void Refresh()
	{
	}
}
