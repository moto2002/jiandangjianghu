using DG.Tweening;
using System;
using UnityEngine;

public class LingQiAiScript : MonoBehaviour
{
	private static float FAQI_DISTANCE = 0.1f;

	private static float FAQI_SPEED_UP_DISTANCE = 2f;

	private static float FAQI_MAX_DISTANCE = 10f;

	private static float FAQI_AUTO_WALK_TIME = 10f;

	private float speedAdd = 8f;

	private float speed = 1.5f;

	private float curInterval;

	public SceneEntity owner
	{
		get;
		set;
	}

	public SceneEntity self
	{
		get;
		set;
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
		if (this.owner == null || this.self == null || this.self.roleAction == null)
		{
			return;
		}
		if (Vector3.Distance(this.owner.transform.position, this.self.transform.position) > LingQiAiScript.FAQI_MAX_DISTANCE)
		{
			this.self.transform.position = this.owner.transform.position;
			this.curInterval = Time.time;
			return;
		}
		if (Vector3.Distance(this.owner.transform.position, this.self.transform.position) > LingQiAiScript.FAQI_DISTANCE)
		{
			this.self.transform.position += (this.owner.transform.position - this.self.transform.position).normalized * this.GetCurSpeed() * Time.deltaTime;
			this.curInterval = Time.time;
			return;
		}
		if (Time.time - this.curInterval > LingQiAiScript.FAQI_AUTO_WALK_TIME)
		{
			this.self.transform.DOLocalRotate(new Vector3(0f, 360f, 0f), 3f, RotateMode.FastBeyond360);
			this.curInterval = Time.time;
			return;
		}
	}

	private float GetCurSpeed()
	{
		if (Vector3.Distance(this.owner.transform.position, this.self.transform.position) >= LingQiAiScript.FAQI_SPEED_UP_DISTANCE)
		{
			this.speed = ((this.speed < this.owner.move.speed) ? (this.speed + this.speedAdd * Time.deltaTime) : this.speed);
		}
		else
		{
			this.speed = ((this.speed >= 1.5f) ? (this.speed - this.speedAdd * Time.deltaTime) : 1.5f);
		}
		return this.speed;
	}

	private void LateUpdate()
	{
	}
}
