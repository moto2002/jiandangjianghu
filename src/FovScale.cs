using System;
using UnityEngine;

public class FovScale : MonoBehaviour
{
	public float delay;

	public float fov;

	public float toTime;

	public float resetTime;

	public float stayTime;

	private float defaultFov;

	private float currentFov;

	private float speed;

	private bool reset;

	private bool start;

	public void SetFovValue(float delay, float fov, float toTime, float resetTime, float stayTime, GameObject go)
	{
		SceneEntity component = go.GetComponent<SceneEntity>();
		if (component == null || component.entityType != RoleManager.EntityType.EntityType_Self)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		this.delay = delay;
		this.fov = fov;
		this.toTime = toTime;
		this.resetTime = resetTime;
		this.stayTime = stayTime;
		this.start = true;
		this.defaultFov = Camera.main.fieldOfView;
		this.currentFov = this.defaultFov;
		this.speed = (fov - this.defaultFov) / toTime;
	}

	private void Update()
	{
		if (!this.start)
		{
			return;
		}
		if (this.reset)
		{
			this.stayTime -= Time.deltaTime;
			if (this.stayTime > 0f)
			{
				return;
			}
		}
		this.delay -= Time.deltaTime;
		if (this.delay <= 0f)
		{
			this.currentFov += this.speed * Time.deltaTime;
			if (((this.currentFov <= this.fov && this.speed < 0f) || (this.currentFov >= this.fov && this.speed > 0f)) && !this.reset)
			{
				this.reset = true;
				this.speed = (this.defaultFov - this.fov) / this.resetTime;
				Camera.main.fieldOfView = this.fov;
			}
			else if (((this.currentFov >= this.defaultFov && this.speed > 0f) || (this.currentFov <= this.defaultFov && this.speed < 0f)) && this.reset)
			{
				Camera.main.fieldOfView = this.defaultFov;
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				Camera.main.fieldOfView = this.currentFov;
			}
		}
	}
}
