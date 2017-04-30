using System;
using ThirdParty;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
	public float speed = 1f;

	public float minFov = 23f;

	public float maxFov = 30f;

	public float xAngleMin = 15f;

	public float xAngleMax = 26f;

	public float offsetYMin = -4f;

	public float offsetYMax;

	public Touch touch;

	public float lastDist;

	public float curDist;

	public static bool IS_MOVING;

	private Camera mainCamera;

	private float fovSensitivity;

	private float offsetYSensitivity;

	private float xAngleSensitivity;

	private void Start()
	{
		this.xAngleMax = Singleton<RoleManager>.Instance.mainCamera.transform.eulerAngles.x;
		this.offsetYMax = Singleton<RoleManager>.Instance.cf.target_offsety;
		this.mainCamera = Singleton<RoleManager>.Instance.mainCamera;
		this.fovSensitivity = this.maxFov - this.minFov;
		this.offsetYSensitivity = this.offsetYMax - this.offsetYMin;
		this.xAngleSensitivity = this.xAngleMax - this.xAngleMin;
	}

	private void Update()
	{
		if (Singleton<RoleManager>.Instance.mainCamera == null)
		{
			return;
		}
		if (Singleton<RoleManager>.Instance.mainRole == null || Singleton<RoleManager>.Instance.mainRole.controller.moveType == MoveController.MoveType.Joystick)
		{
			return;
		}
		if (Singleton<RoleManager>.Instance.mainRole.roleState.IsInState(1024))
		{
			return;
		}
		float num = Singleton<RoleManager>.Instance.mainCamera.fieldOfView;
		float num2 = Singleton<RoleManager>.Instance.cf.target_offsety;
		float num3 = this.mainCamera.transform.eulerAngles.x;
		bool flag = false;
		if (Input.touchCount > 1 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved))
		{
			Touch touch = Input.GetTouch(0);
			Touch touch2 = Input.GetTouch(1);
			if ((double)touch.position.x < (double)Screen.width * 0.25 || (double)touch.position.x > (double)Screen.width * 0.75)
			{
				return;
			}
			if ((double)touch2.position.x < (double)Screen.width * 0.25 || (double)touch2.position.x > (double)Screen.width * 0.75)
			{
				return;
			}
			if ((double)touch.position.y < (double)Screen.height * 0.2 || (double)touch.position.y > (double)Screen.width * 0.8)
			{
				return;
			}
			if ((double)touch2.position.y < (double)Screen.height * 0.2 || (double)touch2.position.y > (double)Screen.width * 0.8)
			{
				return;
			}
			this.curDist = Vector2.Distance(touch.position, touch2.position);
			if (this.curDist > this.lastDist)
			{
				num -= this.fovSensitivity * this.speed * 0.1f;
				num2 -= this.offsetYSensitivity * this.speed * 0.1f;
				num3 -= this.xAngleSensitivity * this.speed * 0.1f;
			}
			else
			{
				num += this.fovSensitivity * this.speed * 0.1f;
				num2 += this.offsetYSensitivity * this.speed * 0.1f;
				num3 += this.xAngleSensitivity * this.speed * 0.1f;
			}
			this.lastDist = this.curDist;
			flag = true;
		}
		else
		{
			float axis = Input.GetAxis("Mouse ScrollWheel");
			if (axis != 0f)
			{
				num -= axis * this.fovSensitivity * this.speed;
				num2 -= axis * this.offsetYSensitivity * this.speed;
				num3 -= axis * this.xAngleSensitivity * this.speed;
				flag = true;
			}
		}
		if (flag)
		{
			num = Mathf.Clamp(num, this.minFov, this.maxFov);
			this.mainCamera.fieldOfView = num;
			num2 = Mathf.Clamp(num2, this.offsetYMin, this.offsetYMax);
			Singleton<RoleManager>.Instance.cf.target_offsety = num2;
			num3 = Mathf.Clamp(num3, this.xAngleMin, this.xAngleMax);
			this.mainCamera.transform.eulerAngles = new Vector3(num3, this.mainCamera.transform.eulerAngles.y, this.mainCamera.transform.eulerAngles.z);
		}
	}
}
