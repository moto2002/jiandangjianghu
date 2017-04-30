using System;
using UnityEngine;

[RequireComponent(typeof(UICamera))]
public class UICameraAdjustor : MonoBehaviour
{
	public float standard_width = 1920f;

	public float standard_height = 1080f;

	private float device_width;

	private float device_height;

	private void Awake()
	{
		this.device_width = (float)Screen.width;
		this.device_height = (float)Screen.height;
		this.SetCameraSize();
	}

	private void SetCameraSize()
	{
		float num = this.standard_width / this.standard_height;
		float num2 = this.device_width / this.device_height;
		if (num2 < num)
		{
			float orthographicSize = num / num2;
			base.GetComponent<Camera>().orthographicSize = orthographicSize;
		}
	}
}
