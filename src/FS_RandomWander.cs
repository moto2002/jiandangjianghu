using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class FS_RandomWander : MonoBehaviour
{
	public float speed = 0.1f;

	public float directionChangeInterval = 1f;

	public float maxHeadingChange = 30f;

	public float dist;

	private float heading;

	private Vector3 targetRotation;

	private void Awake()
	{
		this.heading = (float)UnityEngine.Random.Range(0, 360);
		base.transform.eulerAngles = new Vector3(0f, this.heading, 0f);
		base.StartCoroutine(this.NewHeading());
	}

	private void FixedUpdate()
	{
		base.transform.eulerAngles = Vector3.Slerp(base.transform.eulerAngles, this.targetRotation, Time.deltaTime * this.directionChangeInterval);
		Vector3 a = base.transform.TransformDirection(Vector3.forward);
		base.transform.Translate(a * this.speed);
		if (base.transform.position.y < 1f)
		{
			this.NewHeadingRoutine();
		}
		this.dist = base.transform.position.magnitude;
		if (base.transform.position.magnitude > 70f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		Vector3 position = base.transform.position;
		position.y = 10f;
		base.transform.position = position;
	}

	[DebuggerHidden]
	private IEnumerator NewHeading()
	{
		FS_RandomWander.<NewHeading>c__Iterator16 <NewHeading>c__Iterator = new FS_RandomWander.<NewHeading>c__Iterator16();
		<NewHeading>c__Iterator.<>f__this = this;
		return <NewHeading>c__Iterator;
	}

	private void NewHeadingRoutine()
	{
		float min = Mathf.Clamp(this.heading - this.maxHeadingChange, 0f, 360f);
		float max = Mathf.Clamp(this.heading + this.maxHeadingChange, 0f, 360f);
		this.heading = UnityEngine.Random.Range(min, max);
		this.targetRotation = new Vector3(0f, this.heading, 0f);
	}
}
