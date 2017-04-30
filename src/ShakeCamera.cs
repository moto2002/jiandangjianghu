using System;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
	private Vector3 shakeAmount = Vector3.one;

	private float currentTime;

	private float totalTime;

	private float rate;

	private float frameTime;

	private bool isShake;

	private int frameCount;

	public void Shake(float time, Vector3 amount, float rate)
	{
		this.totalTime = time;
		this.currentTime = time;
		this.shakeAmount = amount;
		this.frameCount = 0;
		this.frameTime = 0f;
		this.rate = rate;
		this.isShake = true;
	}

	public void Stop()
	{
		this.currentTime = 0f;
		this.totalTime = 0f;
		this.frameCount = 0;
		this.frameTime = 0f;
		this.rate = 0f;
		this.shakeAmount = Vector3.one;
		this.isShake = false;
	}

	private void Update()
	{
		if (this.isShake)
		{
			if (this.currentTime > 0f && this.totalTime > 0f)
			{
				float d = this.currentTime / this.totalTime;
				this.frameTime += Time.deltaTime;
				if (this.frameTime > 1f / this.rate)
				{
					this.frameTime = 0f;
					Vector3 b = (this.frameCount % 2 != 0) ? (this.shakeAmount * d) : (-this.shakeAmount * d);
					Camera.main.transform.position += b;
					this.frameCount++;
				}
				this.currentTime -= Time.deltaTime;
			}
			else
			{
				this.Stop();
			}
		}
	}
}
