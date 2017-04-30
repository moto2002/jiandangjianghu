using Pathfinding;
using System;
using UnityEngine;

public class PunchAway : MonoBehaviour
{
	private enum Status
	{
		None,
		Up,
		Down,
		Ground
	}

	public float upSpeed;

	public float horizStartSpeed;

	public float horizDeceleration;

	public float gravity = 9.80665f;

	private float curUpSpeed;

	private float curHorizStartSpeed;

	private float curHorizDeceleration;

	private Vector3 direction;

	private PunchAway.Status status;

	private SceneEntity self;

	private void Start()
	{
		this.self = base.GetComponent<SceneEntity>();
	}

	private void OnEnable()
	{
		this.curUpSpeed = this.upSpeed;
		this.curHorizStartSpeed = this.horizStartSpeed;
		this.curHorizDeceleration = this.horizDeceleration;
	}

	private void OnDisable()
	{
		this.status = PunchAway.Status.None;
	}

	public void StartPunch()
	{
		this.status = PunchAway.Status.Up;
	}

	private void Update()
	{
		if (this.status == PunchAway.Status.None)
		{
			return;
		}
		if (this.status != PunchAway.Status.Ground)
		{
			this.curUpSpeed -= this.gravity * Time.fixedDeltaTime;
		}
		else
		{
			this.curHorizStartSpeed -= this.curHorizDeceleration * Time.fixedDeltaTime;
		}
		if (this.curUpSpeed <= 0f && this.status == PunchAway.Status.Up)
		{
			this.status = PunchAway.Status.Down;
		}
		float num = this.curUpSpeed * Time.fixedDeltaTime;
		Vector3 vector2;
		if (this.curHorizStartSpeed >= 0f)
		{
			Vector3 a = (!(this.self.attacker != null)) ? (-this.self.transform.forward) : (this.self.transform.position - this.self.attacker.transform.position).normalized;
			Vector3 vector = a * this.curHorizStartSpeed * Time.fixedDeltaTime;
			vector2 = new Vector3(vector.x + this.self.transform.position.x, num + this.self.transform.position.y, vector.z + this.self.transform.position.z);
		}
		else
		{
			vector2 = new Vector3(this.self.transform.position.x, num + this.self.transform.position.y, this.self.transform.position.z);
		}
		bool flag = false;
		RaycastHit[] array = Physics.RaycastAll(vector2, Vector3.down, 200f);
		for (int i = 0; i < array.Length; i++)
		{
			NNInfo nearest = AstarPath.active.GetNearest(array[i].point);
			if (array[i].transform.gameObject.layer == LayerMask.NameToLayer("Ground") && nearest.node.Walkable)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			this.ClearSpeed();
		}
		else
		{
			this.self.transform.position = vector2;
		}
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (this.status != PunchAway.Status.None)
		{
			if (collider.gameObject.layer == LayerMask.NameToLayer("Ground") && this.status == PunchAway.Status.Down)
			{
				this.status = PunchAway.Status.Ground;
				this.curUpSpeed = 0f;
			}
			else if (collider.gameObject.CompareTag("Wall"))
			{
				this.ClearSpeed();
			}
		}
	}

	private void ClearSpeed()
	{
		this.curHorizStartSpeed = 0f;
		this.curHorizDeceleration = 0f;
		if (this.curUpSpeed > 0f)
		{
			this.curUpSpeed = 0f;
		}
	}
}
