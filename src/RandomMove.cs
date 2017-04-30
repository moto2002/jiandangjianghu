using System;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
	public float duration;

	public float speedMax;

	private Vector3 defaultPosition;

	private Vector3 target;

	private Vector3 direction;

	private float lastTime;

	private void Start()
	{
		this.defaultPosition = base.transform.position;
		this.direction = Vector3.up;
		this.lastTime = this.duration;
	}

	private void Update()
	{
		this.lastTime -= Time.deltaTime;
		if (this.lastTime <= 0f)
		{
			this.direction = ((!(this.direction == Vector3.up)) ? Vector3.up : Vector3.down);
			this.lastTime = this.duration;
		}
		float num = UnityEngine.Random.Range(0f, this.speedMax);
		Vector3 position = Vector3.MoveTowards(base.transform.position, base.transform.position + this.direction * this.speedMax, num * Time.deltaTime);
		if (position.y < this.defaultPosition.y)
		{
			position.y = this.defaultPosition.y;
		}
		base.transform.position = position;
	}
}
