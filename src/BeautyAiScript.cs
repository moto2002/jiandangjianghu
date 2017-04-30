using System;
using UnityEngine;

public class BeautyAiScript : MonoBehaviour
{
	private int BEAUTY_DISTANCE = 2;

	private int BEAUTY_MAX_DISTANCE = 10;

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
		if (this.owner == null || this.self == null || this.self.roleAction == null || this.owner.move.jumpMode != 0)
		{
			return;
		}
		if (Vector3.Distance(this.owner.transform.position, this.self.transform.position) > (float)this.BEAUTY_MAX_DISTANCE)
		{
			this.self.transform.position = this.owner.transform.position;
			return;
		}
		if (this.self.roleAction.curNextStatus == 2)
		{
			return;
		}
		if (Vector3.Distance(this.owner.transform.position, this.self.transform.position) > (float)this.BEAUTY_DISTANCE)
		{
			this.self.runToTarget.Target(this.owner.gameObject, (float)(this.BEAUTY_DISTANCE - 1), null, 0);
			return;
		}
	}
}
