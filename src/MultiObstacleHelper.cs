using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MultiObstacleHelper : MonoBehaviour
{
	public float Interval = 1f;

	public int Num = 1;

	private float curInterval = 1f;

	private int curNum = 1;

	private Transform template;

	private void Awake()
	{
		this.template = base.gameObject.transform.Find("Obstacle");
	}

	private void Start()
	{
		this.Adjust();
	}

	private void Update()
	{
		if (this.Num <= 0)
		{
			this.Num = this.curNum;
		}
		this.Adjust();
	}

	private void Adjust()
	{
		if (this.template == null)
		{
			return;
		}
		this.AdjustInterval(this.AdjustNum());
	}

	private bool AdjustNum()
	{
		if (this.curNum == this.Num)
		{
			return false;
		}
		if (this.Num > this.curNum)
		{
			for (int i = 0; i < this.Num - this.curNum; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.template.gameObject);
				gameObject.transform.parent = this.template.parent;
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localRotation = Quaternion.identity;
			}
		}
		else if (this.Num < this.curNum)
		{
			int num = this.curNum - this.Num;
			List<Transform> list = new List<Transform>();
			for (int j = 0; j < this.template.parent.transform.childCount; j++)
			{
				if (num <= 0)
				{
					break;
				}
				if (this.template.parent.GetChild(j) != this.template)
				{
					list.Add(this.template.parent.GetChild(j));
					num--;
				}
			}
			while (list.Count > 0)
			{
				Transform transform = list[0];
				UnityEngine.Object.DestroyImmediate(transform.gameObject);
				list.RemoveAt(0);
			}
			list.Clear();
		}
		this.curNum = this.Num;
		return true;
	}

	private void AdjustInterval(bool numChange)
	{
		if (!numChange && this.curInterval == this.Interval)
		{
			return;
		}
		int num = this.Num / 2;
		int num2 = 0;
		foreach (Transform transform in this.template.parent.gameObject.transform)
		{
			if (this.Num % 2 == 1)
			{
				Vector3 localPosition = transform.localPosition;
				localPosition.x = (float)(num2 - num) * this.Interval;
				transform.localPosition = localPosition;
			}
			else
			{
				Vector3 localPosition2 = transform.localPosition;
				localPosition2.x = ((float)(num2 - num) + 0.5f) * this.Interval;
				transform.localPosition = localPosition2;
			}
			num2++;
		}
		this.curInterval = this.Interval;
	}
}
