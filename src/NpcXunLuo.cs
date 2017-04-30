using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class NpcXunLuo : MonoBehaviour
{
	public List<float> pointList;

	private float TIME_INTERVAL = 5f;

	private int curPoint;

	public SceneEntity self
	{
		get;
		set;
	}

	private void Start()
	{
		this.curPoint = 0;
		if (this.pointList == null && this.pointList.Count % 3 != 0)
		{
			return;
		}
		this.XunLuo();
	}

	public void SetWalkPoints(LuaTable table, float time)
	{
		if (table != null)
		{
			for (int i = 1; i <= table.Length; i++)
			{
				if (this.pointList == null)
				{
					this.pointList = new List<float>();
				}
				this.pointList.Add(Convert.ToSingle(table[i]));
			}
		}
		this.TIME_INTERVAL = time;
	}

	private void Update()
	{
	}

	private void XunLuo()
	{
		if (this.pointList == null && this.pointList.Count % 3 != 0)
		{
			return;
		}
		if (this.curPoint * 3 >= this.pointList.Count)
		{
			this.curPoint = 0;
		}
		Vector3 pos = new Vector3(this.pointList[this.curPoint * 3], this.pointList[this.curPoint * 3 + 1], this.pointList[this.curPoint * 3 + 2]);
		this.curPoint++;
		this.self.runToTarget.Target(pos, 0.6f, delegate
		{
			base.Invoke("XunLuo", this.TIME_INTERVAL);
		}, 0);
	}

	public void StartWaitingToGo()
	{
		this.self.move.StopPath();
		if (base.IsInvoking("XunLuo"))
		{
			base.CancelInvoke("XunLuo");
		}
		base.Invoke("XunLuo", this.TIME_INTERVAL);
	}
}
