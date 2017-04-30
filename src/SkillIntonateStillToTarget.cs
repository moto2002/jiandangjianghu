using System;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillIntonateStillToTarget : SkillBase
{
	public float delay = 1f;

	private GameObject startGo;

	private Vector3 lastPosition;

	public override void StartSkill(float speed)
	{
		this.delay += this.delay - this.delay * speed;
		Skill component = base.gameObject.GetComponent<Skill>();
		this.startGo = component.startGo;
		this.lastPosition = this.startGo.transform.position;
	}

	private void Update()
	{
		this.delay -= Time.deltaTime;
		if (this.delay <= 0f)
		{
			this.Finish(true);
			return;
		}
		if (!this.startGo)
		{
			this.Finish(false);
			return;
		}
		if (this.lastPosition != this.startGo.transform.position)
		{
			this.Finish(false);
			return;
		}
		this.lastPosition = this.startGo.transform.position;
	}

	private void Finish(bool success)
	{
		if (success)
		{
			Debug.Log("Intonate success，send msg to server");
		}
		else
		{
			Debug.Log("Intonate fail");
		}
		UnityEngine.Object.Destroy(this);
	}
}
