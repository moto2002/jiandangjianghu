using LuaFramework;
using System;
using System.Collections.Generic;
using ThirdParty;
using UnityEngine;

public class JumpGate : MonoBehaviour
{
	protected float JUMP_DELAY = 1f;

	public GameObject model;

	private float lastTime;

	public int doorNo
	{
		get;
		set;
	}

	public int startMap
	{
		get;
		set;
	}

	public int endMap
	{
		get;
		set;
	}

	public int startArea
	{
		get;
		set;
	}

	public int endArea
	{
		get;
		set;
	}

	public int type
	{
		get;
		set;
	}

	public Vector3 endPosition
	{
		get;
		set;
	}

	public Vector3 particleRotation
	{
		get;
		set;
	}

	public JumpGateTitle title
	{
		get;
		set;
	}

	private void OnTriggerEnter(Collider other)
	{
		SceneEntity component = other.transform.GetComponent<SceneEntity>();
		if (component && component.entityType == RoleManager.EntityType.EntityType_Self && Time.realtimeSinceStartup - this.lastTime > 0.2f)
		{
			if (component.move.finalDestination == base.transform.position && component.move.pathFinished != null)
			{
				component.move.pathFinished();
			}
			else
			{
				component.move.ClearFinalDestination();
			}
			if (this.type == 1)
			{
				object[] array = Util.CallMethod("MAPLOGIC", "JudgeLevelCanJump", new object[]
				{
					this.endMap
				});
				if (array == null || array.Length == 0)
				{
					Debug.LogError("获取能否跳转失败 ");
					return;
				}
				if (Convert.ToBoolean(array[0]))
				{
					base.Invoke("SendJumpGate", this.JUMP_DELAY);
				}
			}
			else
			{
				this.lastTime = Time.realtimeSinceStartup;
				this.StartPlotJump(component);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		SceneEntity component = other.transform.GetComponent<SceneEntity>();
		if (component && component.entityType == RoleManager.EntityType.EntityType_Self && Time.realtimeSinceStartup - this.lastTime > 0.2f && base.IsInvoking("SendJumpGate"))
		{
			base.CancelInvoke("SendJumpGate");
		}
	}

	private void SendJumpGate()
	{
		Util.CallMethod("Network", "SendJumpGate", new object[]
		{
			this.doorNo,
			this.endMap
		});
	}

	private void StartPlotJump(SceneEntity entity)
	{
		if (entity.move.InFindingPath())
		{
			Vector3 destination = entity.move.finalDestination;
			Move.PathFinished pathFinished = entity.move.pathFinished;
			float radius = entity.move.endReachedDistance;
			entity.StartPlotJump(this.doorNo, this.endMap, delegate
			{
				if (!Singleton<WorldPathfinding>.Instance.CheckWorldPathfinding())
				{
					entity.move.WalkTo(destination, radius, 0, pathFinished, false);
				}
			});
		}
		else
		{
			entity.StartPlotJump(this.doorNo, this.endMap, null);
		}
		Singleton<RoleManager>.Instance.cf.CameraTargetToSelf(true);
		this.SendPlotJumpStart(entity);
	}

	private void OnJumpFinished(SceneEntity entity, Vector3 destination, Move.PathFinished pathFinished)
	{
	}

	private void SendPlotJumpStart(SceneEntity entity)
	{
		List<object> list = new List<object>();
		list.Add(this.doorNo);
		list.Add(this.endMap);
		list.Add(1);
		Vector3 vector = Util.Convert2MapPosition(entity.transform.position.x, entity.transform.position.y, entity.transform.position.z);
		list.Add(vector.x);
		list.Add(vector.z);
		list.Add(entity.transform.position.x);
		list.Add(entity.transform.position.y);
		list.Add(entity.transform.position.z);
		Util.CallMethod("Network", "SendPlotJump", new object[]
		{
			list
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
			if (this.particleRotation != Vector3.zero)
			{
				ParticleSystem[] componentsInChildren = gameObject.transform.GetComponentsInChildren<ParticleSystem>();
				ParticleSystem[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					ParticleSystem particleSystem = array[i];
					if (particleSystem.gameObject.name.Equals("renwu"))
					{
						particleSystem.startRotation3D = this.particleRotation * 0.0174532924f;
						break;
					}
				}
			}
		}
	}
}
