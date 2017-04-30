using LuaFramework;
using System;
using System.Collections.Generic;
using ThirdParty;
using UnityEngine;

public class PositionSync : MonoBehaviour
{
	private List<ObjectPosition> posList;

	private float sendProtoTime;

	private float PROTO_INTERVAL = 0.1f;

	private void Awake()
	{
		this.posList = new List<ObjectPosition>();
	}

	private void Start()
	{
	}

	private void Update()
	{
		if (Time.time - this.sendProtoTime >= this.PROTO_INTERVAL)
		{
			this.SyncPosToServer();
			this.sendProtoTime = Time.time;
		}
	}

	public void SetProtoInterval(int interval)
	{
		this.PROTO_INTERVAL = (float)interval / 1000f;
	}

	private void SyncPosToServer()
	{
		SceneEntity mainRole = Singleton<RoleManager>.Instance.mainRole;
		if (mainRole != null && (mainRole.move.jumpMode != 0 || mainRole.roleAction.curStatus == 25 || (mainRole.roleState != null && mainRole.roleState.IsInState(1024))))
		{
			return;
		}
		List<object> list = new List<object>();
		int count = this.posList.Count;
		bool flag = false;
		for (int i = 0; i < count; i++)
		{
			string objId = this.posList[i].objId;
			if (RoleManager.sceneEntities.ContainsKey(objId))
			{
				SceneEntity sceneEntity = RoleManager.sceneEntities[objId];
				Vector3 vector = Util.Convert2MapPosition(sceneEntity.transform.position.x, sceneEntity.transform.position.z, sceneEntity.transform.position.y);
				if (!(vector == this.posList[i].objPosition))
				{
					flag = true;
					this.posList[i].objPosition = vector;
					list.Add(Mathf.FloorToInt(vector.x));
					list.Add(Mathf.FloorToInt(vector.z));
					list.Add(Convert.ToInt32(sceneEntity.transform.rotation.eulerAngles.y));
					list.Add(0);
				}
			}
		}
		if (flag)
		{
			Util.CallMethod("Network", "sendMove", new object[]
			{
				list
			});
		}
	}

	public void AddObjectPosition(string id, Vector3 pos)
	{
		if (this.GetObjectPosition(id) != null)
		{
			return;
		}
		ObjectPosition objectPosition = new ObjectPosition();
		objectPosition.objId = id;
		Vector3 objPosition = Util.Convert2MapPosition(pos.x, pos.z, pos.y);
		objectPosition.objPosition = objPosition;
		this.posList.Add(objectPosition);
	}

	public void DeleteObjectPosition(string id)
	{
		ObjectPosition objectPosition = this.GetObjectPosition(id);
		if (objectPosition == null)
		{
			return;
		}
		this.posList.Remove(objectPosition);
	}

	public void ResetObjectPosition(string id, Vector3 pos)
	{
		ObjectPosition objectPosition = this.GetObjectPosition(id);
		if (objectPosition == null)
		{
			return;
		}
		objectPosition.objPosition = pos;
	}

	public void Clear()
	{
		this.posList.Clear();
	}

	private ObjectPosition GetObjectPosition(string id)
	{
		int count = this.posList.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.posList[i].objId == id)
			{
				return this.posList[i];
			}
		}
		return null;
	}

	public static void SyncSelfPosition()
	{
		SceneEntity mainRole = Singleton<RoleManager>.Instance.mainRole;
		if (mainRole != null && (mainRole.move.jumpMode != 0 || mainRole.roleAction.curStatus == 25))
		{
			return;
		}
		List<object> list = new List<object>();
		Vector3 pos = Util.Convert2MapPosition(mainRole.transform.position.x, mainRole.transform.position.z, mainRole.transform.position.y);
		list.Add(Mathf.FloorToInt(pos.x));
		list.Add(Mathf.FloorToInt(pos.z));
		list.Add(Convert.ToInt32(mainRole.transform.rotation.eulerAngles.y));
		list.Add(0);
		if (Singleton<RoleManager>.Instance.entityCreate)
		{
			Singleton<RoleManager>.Instance.entityCreate.positionSync.ResetObjectPosition(mainRole.id, pos);
		}
		Util.CallMethod("Network", "sendMove", new object[]
		{
			list
		});
	}
}
