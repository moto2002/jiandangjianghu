using System;
using ThirdParty;
using UnityEngine;

public class JumpGateTitle : MonoBehaviour
{
	public UILabel nameLab;

	public Vector3 offset;

	private Camera uiCamera;

	public Transform point
	{
		get;
		set;
	}

	private void LateUpdate()
	{
		if (this.uiCamera == null)
		{
			this.uiCamera = GameObject.FindGameObjectWithTag("GuiCamera").GetComponent<Camera>();
		}
		base.transform.position = this.WorldToUI(this.point.position + this.offset);
	}

	public Vector3 WorldToUI(Vector3 point)
	{
		Vector3 position = Singleton<RoleManager>.Instance.mainCamera.WorldToScreenPoint(point);
		Vector3 result = this.uiCamera.ScreenToWorldPoint(position);
		result.z = 0f;
		return result;
	}
}
