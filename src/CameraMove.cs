using System;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public float speed = 15f;

	private bool bUpState;

	private bool bDownState;

	private bool bLeftState;

	private bool bRightState;

	private void Start()
	{
	}

	private void Update()
	{
		this.MoveByKeyboard();
	}

	public void MoveByKeyboard()
	{
		this.bUpState = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));
		this.bDownState = (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow));
		this.bLeftState = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow));
		this.bRightState = (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow));
		if (!this.bUpState && !this.bDownState && !this.bLeftState && !this.bRightState)
		{
			return;
		}
		Vector3 v = Camera.main.transform.rotation * Vector3.forward;
		v.y = 0f;
		v.Normalize();
		float y = 0f;
		if (this.bUpState)
		{
			if (this.bLeftState)
			{
				y = -45f;
			}
			else if (this.bRightState)
			{
				y = 45f;
			}
		}
		else if (this.bDownState)
		{
			if (this.bLeftState)
			{
				y = -135f;
			}
			else if (this.bRightState)
			{
				y = 135f;
			}
			else
			{
				y = 180f;
			}
		}
		else if (this.bLeftState)
		{
			y = -90f;
		}
		else if (this.bRightState)
		{
			y = 90f;
		}
		this.WalkOnDirection(Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(new Vector3(0f, y, 0f)), Vector3.one).MultiplyVector(v));
	}

	public void WalkOnDirection(Vector3 vecDir)
	{
		if (vecDir.Equals(Vector3.zero))
		{
			return;
		}
		vecDir.Normalize();
		float maxDistanceDelta = this.speed * Time.deltaTime;
		Vector3 target = base.transform.position + vecDir;
		Vector3 position = Vector3.MoveTowards(base.transform.position, target, maxDistanceDelta);
		base.transform.position = position;
	}
}
