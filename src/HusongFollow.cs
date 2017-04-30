using LuaFramework;
using System;
using ThirdParty;
using UnityEngine;

public class HusongFollow : MonoBehaviour
{
	public SceneEntity self;

	public string targetId;

	public SceneEntity targetEntity;

	private int FOLLOW_DISTANCE = 2;

	private int SEND_INTERVAL = 3;

	private float _lastSendTime;

	private void Start()
	{
	}

	private void Update()
	{
		if (!this.self.roleState.IsInState(4096))
		{
			return;
		}
		if (this.targetEntity == null)
		{
			this.targetEntity = Singleton<RoleManager>.Instance.GetSceneEntityById(this.targetId, 0);
			if (this.targetEntity == null && (this._lastSendTime == 0f || this._lastSendTime + (float)this.SEND_INTERVAL <= Time.time))
			{
				Util.CallMethod("HusongLogic", "RequestTargetPos", new object[0]);
				this._lastSendTime = Time.time;
			}
			return;
		}
		if (Vector3.Distance(this.targetEntity.transform.position, this.self.transform.position) > (float)this.FOLLOW_DISTANCE)
		{
			this.self.runToTarget.Target(this.targetEntity.gameObject, 0.6f, null, 0);
			return;
		}
	}
}
