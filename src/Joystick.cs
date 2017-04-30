using System;
using ThirdParty;
using UnityEngine;

public class Joystick : MonoBehaviour
{
	public float radius;

	public Vector3 scale = Vector3.one;

	private Plane mPlane;

	private Vector3 mLastPos;

	private Vector3 center;

	[HideInInspector]
	public Vector2 position;

	[HideInInspector]
	public bool pressed;

	private void Start()
	{
		this.center = base.transform.localPosition;
	}

	private void OnPress(bool pressed)
	{
		if (base.enabled && base.gameObject.activeInHierarchy)
		{
			if (pressed)
			{
				Vector3 point = UICamera.lastHit.point;
				this.mPlane = new Plane(Vector3.back, point);
				this.CaculatePosition();
				this.mLastPos = point;
			}
			else
			{
				this.position = Vector2.zero;
				base.transform.localPosition = this.center;
			}
			this.pressed = pressed;
		}
	}

	private void OnDrag(Vector2 delta)
	{
		if (base.enabled && base.gameObject.activeInHierarchy)
		{
			UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
			this.CaculatePosition();
		}
	}

	private void CaculatePosition()
	{
		Ray ray = UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);
		float distance = 0f;
		if (!this.pressed)
		{
			Ray ray2 = UICamera.currentCamera.ScreenPointToRay(UICamera.currentCamera.WorldToScreenPoint(base.transform.position));
			if (this.mPlane.Raycast(ray2, out distance))
			{
				this.mLastPos = ray2.GetPoint(distance);
			}
		}
		if (this.mPlane.Raycast(ray, out distance))
		{
			Vector3 point = ray.GetPoint(distance);
			Vector3 vector = point - this.mLastPos;
			this.mLastPos = point;
			if (vector.x != 0f || vector.y != 0f)
			{
				vector = base.transform.InverseTransformDirection(vector);
				vector.Scale(this.scale);
				vector = base.transform.TransformDirection(vector);
			}
			vector.z = 0f;
			base.transform.position += vector;
			float magnitude = base.transform.localPosition.magnitude;
			if (magnitude > this.radius)
			{
				base.transform.localPosition = Vector3.ClampMagnitude(base.transform.localPosition, this.radius);
			}
			float x = (base.transform.localPosition.x - this.center.x) / this.radius;
			float y = (base.transform.localPosition.y - this.center.y) / this.radius;
			this.position = new Vector2(x, y);
		}
	}

	private void Update()
	{
		float num = Input.GetAxis("Horizontal");
		float num2 = Input.GetAxis("Vertical");
		if (num == 0f && num2 == 0f)
		{
			num = this.position.x;
			num2 = this.position.y;
		}
		if (Singleton<RoleManager>.Instance.mainRole && Singleton<RoleManager>.Instance.mainRole.hp > 0)
		{
			Singleton<RoleManager>.Instance.mainRole.controller.MoveByJoystick(num, num2, this.pressed);
		}
	}
}
