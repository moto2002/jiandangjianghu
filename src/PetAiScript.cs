using System;
using ThirdParty;
using UnityEngine;

public class PetAiScript : MonoBehaviour
{
	private int PET_DISTANCE = 3;

	private int PET_MAX_DISTANCE = 10;

	private int PET_AUTO_WALK_TIME = 3;

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
		this.curInterval = 0f;
	}

	private void Update()
	{
		if (Singleton<RoleManager>.Instance.sceneType == 5)
		{
			return;
		}
		if (this.owner == null || this.self == null || this.self.roleAction == null || this.owner.move.jumpMode != 0)
		{
			return;
		}
		if (Vector3.Distance(this.owner.transform.position, this.self.transform.position) > (float)this.PET_MAX_DISTANCE)
		{
			this.self.transform.position = this.owner.transform.position;
			this.curInterval = Time.time;
			this.self.move.StopPath();
			return;
		}
		if (this.self.roleAction.curNextStatus == 2 || this.self.roleAction.curNextStatus == 20)
		{
			this.curInterval = Time.time;
			return;
		}
		if (Vector3.Distance(this.owner.transform.position, this.self.transform.position) > (float)this.PET_DISTANCE)
		{
			this.self.runToTarget.Target(this.owner.gameObject, (float)(this.PET_DISTANCE - 1), null, 0);
			this.curInterval = Time.time;
			return;
		}
		if (Time.time - this.curInterval > (float)this.PET_AUTO_WALK_TIME)
		{
			float f = UnityEngine.Random.Range(0f, 6.28318548f);
			float num = (float)this.PET_DISTANCE * UnityEngine.Random.Range(0.5f, 0.8f);
			this.self.runToTarget.Target(this.owner.gameObject.transform.position + new Vector3(num * Mathf.Sin(f), 0f, num * Mathf.Cos(f)), 0.6f, null, 0);
			this.curInterval = Time.time;
			return;
		}
	}
}
