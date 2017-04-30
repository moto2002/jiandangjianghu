using LuaFramework;
using System;
using UnityEngine;

public class FakeJumpGate : JumpGate
{
	private float lastTriggerTime;

	private float TRIGGER_OFFSET = 0.2f;

	public string extend
	{
		get;
		set;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (Time.realtimeSinceStartup - this.lastTriggerTime <= this.TRIGGER_OFFSET)
		{
			return;
		}
		this.lastTriggerTime = Time.time;
		SceneEntity component = other.transform.GetComponent<SceneEntity>();
		if (component && component.entityType == RoleManager.EntityType.EntityType_Self)
		{
			component.move.ClearFinalDestination();
			if (component.move.finalDestination == base.transform.position && component.move.pathFinished != null)
			{
				component.move.pathFinished();
			}
			base.Invoke("DealFakeJump", this.JUMP_DELAY);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		SceneEntity component = other.transform.GetComponent<SceneEntity>();
		if (component && component.entityType == RoleManager.EntityType.EntityType_Self && Time.realtimeSinceStartup - this.lastTriggerTime > this.TRIGGER_OFFSET && base.IsInvoking("DealFakeJump"))
		{
			base.CancelInvoke("DealFakeJump");
		}
	}

	private void DealFakeJump()
	{
		Util.CallMethod("MAPLOGIC", "DealFakeJump", new object[]
		{
			this.extend
		});
	}

	private void Start()
	{
		if (this.model)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.model);
			gameObject.transform.parent = base.transform;
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			if (base.particleRotation != Vector3.zero)
			{
				ParticleSystem[] componentsInChildren = gameObject.transform.GetComponentsInChildren<ParticleSystem>();
				ParticleSystem[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					ParticleSystem particleSystem = array[i];
					if (particleSystem.gameObject.name.Equals("renwu"))
					{
						particleSystem.startRotation3D = base.particleRotation * 0.0174532924f;
						break;
					}
				}
			}
		}
	}
}
