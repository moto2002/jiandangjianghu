using System;
using UnityEngine;

public class UIBackgroundAdjustor : MonoBehaviour
{
	public float standard_width = 1920f;

	public float standard_height = 1080f;

	private void Start()
	{
		this.SetBackgroundSize();
	}

	private void Update()
	{
	}

	private void SetBackgroundSize()
	{
		float num = (float)Screen.width;
		float num2 = (float)Screen.height;
		if (base.transform != null)
		{
			float num3 = this.standard_width / this.standard_height;
			float num4 = num / num2;
			if (num4 > num3)
			{
				float num5 = num4 / num3;
				base.transform.localScale = new Vector3(num5, 1f, 1f);
			}
			else
			{
				float num5 = num3 / num4;
				base.transform.localScale = new Vector3(1f, num5, 1f);
			}
		}
	}
}
