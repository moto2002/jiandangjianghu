using System;
using UnityEngine;

public class LineRenderControl : MonoBehaviour
{
	public Vector3[] speed;

	public float[] duration;

	public float delay;

	private Vector3[] currentPosition;

	private LineRenderer lineRenderer;

	private bool[] finished;

	private bool allFinished;

	private void Start()
	{
		this.lineRenderer = base.GetComponent<LineRenderer>();
		if (this.duration.Length > 0)
		{
			this.currentPosition = new Vector3[this.duration.Length];
			this.finished = new bool[this.duration.Length];
		}
		for (int i = 0; i < this.currentPosition.Length; i++)
		{
			this.currentPosition[i] = Vector3.zero;
		}
	}

	private void Update()
	{
		if (this.allFinished)
		{
			return;
		}
		if (this.delay > 0f)
		{
			this.delay -= Time.deltaTime;
		}
		if (this.delay <= 0f && this.lineRenderer != null)
		{
			for (int i = 0; i < this.speed.Length; i++)
			{
				Vector3 b = this.speed[i] * Time.deltaTime;
				this.duration[i] -= Time.deltaTime;
				if (this.duration[i] >= 0f)
				{
					this.currentPosition[i] += b;
				}
				this.lineRenderer.SetPosition(i, this.currentPosition[i]);
			}
			this.allFinished = true;
			for (int j = 0; j < this.duration.Length; j++)
			{
				if (this.duration[j] >= 0f)
				{
					this.allFinished = false;
					break;
				}
			}
		}
	}
}
