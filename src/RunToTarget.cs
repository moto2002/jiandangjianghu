using System;
using ThirdParty;
using UnityEngine;

public class RunToTarget : MonoBehaviour
{
	public enum TargetType
	{
		Type_Null,
		Type_GameObject,
		Type_Position
	}

	public SceneEntity _self;

	public RunToTarget.TargetType targetType;

	public Move.PathFinished targetArrived;

	private GameObject goTarget;

	private float radius;

	private Vector3 posTarget;

	private int moveType;

	private bool isWalkTo;

	private void Start()
	{
	}

	private void OnDisable()
	{
		this.clear();
	}

	public void clear()
	{
		this.targetType = RunToTarget.TargetType.Type_Null;
		this.targetArrived = null;
		this.goTarget = null;
		this.moveType = 0;
	}

	public void Target(GameObject _go, float _radius = 0.6f, Move.PathFinished _delegate = null, int type = 0)
	{
		this.clear();
		if (_go == null)
		{
			return;
		}
		this.targetType = RunToTarget.TargetType.Type_GameObject;
		this.goTarget = _go;
		this.radius = _radius;
		this.moveType = type;
		this.targetArrived = _delegate;
	}

	public void Target(Vector3 pos, float _radius = 0.6f, Move.PathFinished _delegate = null, int type = 0)
	{
		this.clear();
		this.targetType = RunToTarget.TargetType.Type_Position;
		this.posTarget = pos;
		this.radius = _radius;
		this.moveType = type;
		this.targetArrived = _delegate;
		this.isWalkTo = false;
		this.Update();
	}

	private void Update()
	{
		if (this._self == null || Singleton<RoleManager>.Instance.mode != RoleManager.GameMode.Game)
		{
			return;
		}
		if (this._self.entityType == RoleManager.EntityType.EntityType_Self && !this._self.controller.canMove)
		{
			if (this._self.roleAction.Stop())
			{
				return;
			}
			this._self.controller.canMove = true;
		}
		switch (this.targetType)
		{
		case RunToTarget.TargetType.Type_Null:
			return;
		case RunToTarget.TargetType.Type_GameObject:
			if (this.goTarget == null)
			{
				this.clear();
				this._self.move.StopPath();
			}
			else
			{
				this._self.move.WalkTo(this.goTarget.transform.position, this.radius, this.moveType, this.targetArrived, false);
			}
			break;
		case RunToTarget.TargetType.Type_Position:
			if (!this.isWalkTo)
			{
				this._self.move.WalkTo(this.posTarget, this.radius, this.moveType, this.targetArrived, true);
				this.isWalkTo = true;
			}
			break;
		}
	}

	public bool HasMoveCmd()
	{
		return this.targetType != RunToTarget.TargetType.Type_Null;
	}
}
