using GraphCollection;
using LuaFramework;
using Pathfinding;
using Pathfinding.Util;
using System;
using System.Collections.Generic;
using ThirdParty;
using UnityEngine;

[RequireComponent(typeof(SceneEntity))]
public class Move : AIPath
{
	public enum TargetAction
	{
		None,
		Move,
		Skill
	}

	private class QueueItem
	{
		public int walkType;

		public float radius;

		public Vector3 target;

		public Move.TargetAction action;

		public Move.PathFinished callback;

		public QueueItem(int type, float ra, Vector3 vec, Move.TargetAction act, Move.PathFinished finished)
		{
			this.walkType = type;
			this.radius = ra;
			this.target = vec;
			this.action = act;
			this.callback = finished;
		}
	}

	public delegate void PathFinished();

	private const int MAXQUEUESIZE = 2;

	public Move.PathFinished pathFinished;

	public SceneEntity _self;

	public float speedFactor = 1f;

	public bool isAutoRunning;

	public bool isRunning;

	public float radius = 0.5f;

	public float sleepVelocity = 0.4f;

	public float stepReachDistance = 0.01f;

	public Vector3 destination;

	public Vector3 finalDestination;

	public int walkType;

	private List<Move.QueueItem> moveQueue = new List<Move.QueueItem>();

	private Move.QueueItem curQueueItem;

	private bool inProcess;

	private float defaultSpeed;

	public JumpBase jumpSystem;

	public JumpBase plotJumpSystem;

	private List<GraphNode<AreaPathfinding.AreaInfo>> areaNavPath;

	public Vector3[] vectorPath
	{
		get
		{
			if (this.path != null)
			{
				return this.path.vectorPath.ToArray();
			}
			return null;
		}
	}

	public Vector3[] vectorLeftPath
	{
		get
		{
			List<Vector3> list = new List<Vector3>();
			if (this.path != null && this.currentWaypointIndex < this.path.vectorPath.Count)
			{
				list.AddRange(this.path.vectorPath.GetRange(this.currentWaypointIndex, this.path.vectorPath.Count - this.currentWaypointIndex));
			}
			return list.ToArray();
		}
	}

	public int jumpMode
	{
		get
		{
			if (this.jumpSystem != null && this.jumpSystem.enabled)
			{
				return this.jumpSystem.jumpMode;
			}
			if (this.plotJumpSystem != null && this.plotJumpSystem.enabled)
			{
				return this.plotJumpSystem.jumpMode;
			}
			return 0;
		}
	}

	private new void Start()
	{
		base.OnEnable();
		this.repathRate = 0.5f;
		this.turningSpeed = 5f;
		this.slowdownDistance = 0f;
		this.endReachedDistance = 0.1f;
		this.radius = 0.5f;
	}

	private new void OnEnable()
	{
		this.Clear();
		this.lastRepath = Time.time;
		if (this.seeker.pathCallback == null)
		{
			Seeker expr_27 = this.seeker;
			expr_27.pathCallback = (OnPathDelegate)Delegate.Combine(expr_27.pathCallback, new OnPathDelegate(this.OnPathComplete));
		}
	}

	private new void OnDisable()
	{
		this.Clear();
		Seeker expr_0C = this.seeker;
		expr_0C.pathCallback = (OnPathDelegate)Delegate.Remove(expr_0C.pathCallback, new OnPathDelegate(this.OnPathComplete));
	}

	private void Clear()
	{
		if (this.seeker != null && !this.seeker.IsDone())
		{
			this.seeker.ReleaseClaimedPath();
		}
		if (this.path != null)
		{
			this.path.Release(this, false);
		}
		this.path = null;
		this.inProcess = false;
		this.curQueueItem = null;
		this.moveQueue.Clear();
	}

	public bool InFindingPath()
	{
		return this.path != null;
	}

	public bool InMoving()
	{
		return this._self.roleAction != null && (this._self.roleAction.curStatus == 2 || this._self.roleAction.curStatus == 20 || this._self.roleAction.curStatus == 25);
	}

	public bool InAreaPathFinding()
	{
		return this.areaNavPath != null && this.areaNavPath.Count > 0;
	}

	public override void OnPathComplete(Path _p)
	{
		if (this._self.roleAction != null && !_p.error)
		{
			this._self.roleAction.SetRoleMove(this.walkType);
		}
		ABPath aBPath = _p as ABPath;
		if (aBPath == null)
		{
			throw new Exception("This function only handles ABPaths, do not use special path types");
		}
		this.canSearchAgain = true;
		aBPath.Claim(this);
		if (aBPath.error)
		{
			aBPath.Release(this, false);
			return;
		}
		this.currentWaypointIndex = 0;
		this.targetReached = false;
		if (this.path != null)
		{
			this.currentWaypointIndex = 1;
			this.path.Release(this, false);
		}
		this.path = aBPath;
		if (this._self.entityType == RoleManager.EntityType.EntityType_Self)
		{
			this._self.roleState.AddState(256);
		}
		if (this.path.vectorPath.Count == 0)
		{
			Debug.LogError("find path error: path count is 0");
		}
	}

	public void ResearchPathAfterJump()
	{
		if (Vector3.Distance(this._self.transform.position, this.finalDestination) < this.endReachedDistance)
		{
			Move.PathFinished pathFinished = this.pathFinished;
			this.StopPath();
			if (pathFinished != null)
			{
				pathFinished();
			}
		}
		else
		{
			this.lastRepath = 0f;
			if (this._self.entityType != RoleManager.EntityType.EntityType_Self || this.IsPathPossible(this.finalDestination))
			{
				if (this.areaNavPath != null)
				{
					this.areaNavPath.Clear();
				}
				this.TrySearchPath(this.finalDestination, this.pathFinished);
			}
			else
			{
				this.endReachedDistance = 0.1f;
				this.SearchPathInArea(this.finalDestination, this.pathFinished);
			}
		}
	}

	public bool WalkTo(Vector3 _dst, float _radius = 0.1f, int type = 0, Move.PathFinished _arrived = null, bool searchImmediate = false)
	{
		if (_dst == this.destination || this._self == null)
		{
			return false;
		}
		if (this.jumpMode != 0)
		{
			return false;
		}
		if (this._self.entityType == RoleManager.EntityType.EntityType_Self)
		{
			Singleton<RoleManager>.Instance.cf.CameraTargetToSelf(false);
		}
		if (Vector3.Distance(this._self.transform.position, _dst) < _radius)
		{
			this.StopPath();
			if (_arrived != null)
			{
				_arrived();
			}
			return false;
		}
		this.walkType = type;
		if (_radius < 0.1f)
		{
			_radius = 0.1f;
		}
		if (searchImmediate)
		{
			this.lastRepath = 0f;
		}
		if (this._self.entityType != RoleManager.EntityType.EntityType_Self || this.IsPathPossible(_dst))
		{
			this.finalDestination = _dst;
			this.endReachedDistance = _radius;
			if (this.areaNavPath != null)
			{
				this.areaNavPath.Clear();
			}
			this.TrySearchPath(_dst, _arrived);
		}
		else
		{
			this.endReachedDistance = _radius;
			this.SearchPathInArea(_dst, _arrived);
		}
		return true;
	}

	private bool IsPathPossible(Vector3 dest)
	{
		NNInfo nearest = AstarPath.active.GetNearest(dest);
		NNInfo nearest2 = AstarPath.active.GetNearest(this._self.transform.position);
		return nearest2.node.Area == 0u || nearest.node.Area == 0u || nearest2.node.Area == nearest.node.Area;
	}

	private void SearchPathInArea(Vector3 _dst, Move.PathFinished _arrived)
	{
		NNInfo nearest = AstarPath.active.GetNearest(_dst);
		NNInfo nearest2 = AstarPath.active.GetNearest(this._self.transform.position);
		if (this.areaNavPath != null)
		{
			ListPool<GraphNode<AreaPathfinding.AreaInfo>>.Release(this.areaNavPath);
		}
		if (this.areaNavPath == null || this.areaNavPath.Count == 0)
		{
			this.areaNavPath = Singleton<AreaPathfinding>.Instance.FindPath((int)nearest2.node.Area, (int)nearest.node.Area);
		}
		if (this.areaNavPath != null)
		{
			if (this.areaNavPath.Count <= 1)
			{
				Debug.LogError("area path find error!");
				return;
			}
			this.finalDestination = _dst;
			this.TrySearchPath(this.areaNavPath[0].Value.FindPoint(this.areaNavPath[1].Value.id), _arrived);
		}
		else
		{
			Debug.LogError(string.Format("Target position cannot be arrived (area{0} to area{1}", (int)nearest2.node.Area, (int)nearest.node.Area));
			Singleton<WorldPathfinding>.Instance.StopWorldPathfinding();
			this.StopPath();
		}
	}

	public void SearchPathInWorld(int toMap, Vector3 _dst, float radius, Move.PathFinished _arrived)
	{
		if (Singleton<RoleManager>.Instance.curSceneNo != toMap)
		{
			List<GraphNode<WorldPathfinding.MapPathInfo>> list = Singleton<WorldPathfinding>.Instance.FindPath(Singleton<RoleManager>.Instance.curSceneNo, toMap);
			if (list != null && list.Count > 1)
			{
				bool flag = this.WalkTo(list[0].Value.FindPoint(list[1].Value.id), 0.1f, 0, null, true);
			}
			else if (Singleton<RoleManager>.Instance.sceneType != 2)
			{
				Debug.LogError(string.Format("world path finding error: {0}:{1}", toMap, _dst));
			}
		}
		else
		{
			_dst = Util.Convert2RealPosition((int)_dst.x, _dst.y, (int)_dst.z);
			Singleton<WorldPathfinding>.Instance.StopWorldPathfinding();
			bool flag = this.WalkTo(_dst, radius, 0, _arrived, true);
		}
	}

	public void WalkOnDirection(Vector3 vecDir)
	{
		if (this.jumpMode != 0)
		{
			return;
		}
		if (!this._self.roleState.CanWalkOnDirection())
		{
			return;
		}
		if (vecDir.Equals(Vector3.zero))
		{
			return;
		}
		if (this._self.roleAction.curStatus == 25 || this._self.roleAction.curStatus == 30)
		{
			return;
		}
		if (Singleton<RoleManager>.Instance.sceneType == 5)
		{
			return;
		}
		if (this.areaNavPath != null)
		{
			this.areaNavPath.Clear();
			this.finalDestination = Vector3.zero;
		}
		Singleton<WorldPathfinding>.Instance.StopWorldPathfinding();
		this._self.roleState.RemoveState(16);
		Singleton<RoleManager>.Instance.cf.CameraTargetToSelf(false);
		vecDir.Normalize();
		this.RotateTowards(vecDir);
		if (!this._self.controller.canMove)
		{
			if (this._self.roleAction.Stop())
			{
				return;
			}
			this._self.controller.canMove = true;
		}
		this._self.roleAction.SetRoleMove(0);
		NNInfo nearest = AstarPath.active.GetNearest(this._self.transform.position + vecDir);
		if (!nearest.node.Walkable)
		{
			return;
		}
		if (Math.Abs(nearest.clampedPosition.y - this._self.transform.position.y) > Singleton<RoleManager>.Instance.maxClimbHeight)
		{
			return;
		}
		float maxDistanceDelta = this.speed * this.speedFactor * Time.deltaTime;
		Vector3 position = Vector3.MoveTowards(this._self.transform.position, nearest.clampedPosition, maxDistanceDelta);
		this._self.transform.position = position;
		this.isRunning = true;
		this.isAutoRunning = false;
		if (this.InMoving() && this.InFindingPath())
		{
			this.Stop();
		}
	}

	protected override void RotateTowards(Vector3 dir)
	{
		if (dir == Vector3.zero)
		{
			return;
		}
		Quaternion quaternion = this._self.transform.rotation;
		Quaternion b = Quaternion.LookRotation(dir);
		Vector3 eulerAngles = Quaternion.Slerp(quaternion, b, 1f).eulerAngles;
		eulerAngles.z = 0f;
		eulerAngles.x = 0f;
		quaternion = Quaternion.Euler(eulerAngles);
		this._self.transform.rotation = quaternion;
	}

	public void StopPath()
	{
		this.Stop();
		if (this._self.roleAction != null && this._self.hp > 0 && this.jumpMode == 0)
		{
			this._self.roleAction.ResetToIdleImmediate();
		}
	}

	private void Stop()
	{
		if (this.path != null)
		{
			this.path.Release(this, false);
			this.path = null;
		}
		this.pathFinished = null;
		this.ClearFinalDestination();
		this.destination = Vector3.zero;
		this.isAutoRunning = false;
		this._self.runToTarget.clear();
	}

	public void ClearFinalDestination()
	{
		if (this.destination == this.finalDestination)
		{
			this.finalDestination = Vector3.zero;
		}
	}

	public void SetServerPos(Vector3 pos, float sSpeed = 0f, int type = 0, int walkType = 0, float radius = 0.1f, bool correctNow = true, Move.PathFinished callback = null)
	{
		if (this._self == null)
		{
			return;
		}
		if (correctNow)
		{
			this._self.transform.position = pos;
		}
		else
		{
			if (this._self.entityType != RoleManager.EntityType.EntityType_Self && this._self.entityType != RoleManager.EntityType.EntityType_Role)
			{
				this.speed = sSpeed;
			}
			if (this.defaultSpeed != this.speed && this.speed != 0f)
			{
				this.defaultSpeed = this.speed;
			}
			if (this._self.entityType != RoleManager.EntityType.EntityType_Self)
			{
				this.MoveEnqueue(pos, 1, walkType, radius, callback, string.Empty, string.Empty, new object[0]);
			}
			else
			{
				this.WalkTo(pos, 0.1f, type, null, true);
			}
		}
	}

	public void MoveEnqueue(int x, float y, int z, int type, string module = "", string func = "", params object[] param)
	{
		Vector3 position = Util.Convert2RealPosition(x, z);
		this.MoveEnqueue(position, type, 0, 0.1f, null, module, func, param);
	}

	public void MoveEnqueue(Vector3 position, int type, int walkType = 0, float radius = 0.1f, Move.PathFinished callback = null, string module = "", string func = "", params object[] param)
	{
		if (this._self == null)
		{
			return;
		}
		if (this.moveQueue.Count >= 2)
		{
			this.speed = this.defaultSpeed * 1.5f;
		}
		else if (this.speed != this.defaultSpeed && this.defaultSpeed != 0f)
		{
			this.speed = this.defaultSpeed;
		}
		if ((float)this.moveQueue.Count >= 3f && this.inProcess)
		{
			this.moveQueue.Clear();
			this.inProcess = false;
			this.speed = this.defaultSpeed;
		}
		if (this.inProcess && type == 1)
		{
			if (this.moveQueue.Count > 0)
			{
				Move.QueueItem queueItem = this.moveQueue[this.moveQueue.Count - 1];
				if (queueItem.action == Move.TargetAction.Skill)
				{
					if (Vector3.Distance(queueItem.target, position) < 0.5f)
					{
						return;
					}
				}
				else if (queueItem.action == Move.TargetAction.Move)
				{
					walkType = queueItem.walkType;
					this.moveQueue.RemoveAt(this.moveQueue.Count - 1);
					this.inProcess = false;
				}
			}
			else if (this.curQueueItem != null)
			{
				if (this.curQueueItem.action == Move.TargetAction.Skill)
				{
					if (Vector3.Distance(this.curQueueItem.target, position) < 0.5f)
					{
						return;
					}
				}
				else if (this.curQueueItem.action == Move.TargetAction.Move && this.curQueueItem.walkType != 1)
				{
					this.inProcess = false;
				}
			}
		}
		this.moveQueue.Add(new Move.QueueItem(walkType, radius, position, (Move.TargetAction)type, delegate
		{
			this.inProcess = false;
			if (!string.IsNullOrEmpty(module) && !string.IsNullOrEmpty(func))
			{
				Util.CallMethod(module, func, param);
			}
			else if (callback != null)
			{
				callback();
			}
		}));
	}

	private new void Update()
	{
		if (this._self == null || this._self.roleAction == null)
		{
			return;
		}
		if (this._self.roleAction.curStatus == 15)
		{
			return;
		}
		if (this.jumpMode != 0)
		{
			if (this.jumpSystem.enabled)
			{
				this.jumpSystem.UpdateJump(false, Vector3.zero, false);
			}
			else if (this.plotJumpSystem.enabled)
			{
				this.plotJumpSystem.UpdateJump(false, Vector3.zero, false);
			}
			return;
		}
		if (this.canMove && this.InFindingPath())
		{
			if (!this.InMoving())
			{
				this._self.roleAction.SetRoleMove(this.walkType);
			}
			if (Vector3.Distance(this._self.transform.position, this.finalDestination) < this.endReachedDistance || this.currentWaypointIndex >= this.path.vectorPath.Count)
			{
				this.targetReached = true;
				this.OnTargetReached();
				return;
			}
			float maxDistanceDelta = this.speed * Time.deltaTime * this.speedFactor;
			Vector3 position = Vector3.MoveTowards(this._self.transform.position, this.path.vectorPath[this.currentWaypointIndex], maxDistanceDelta);
			this._self.transform.LookAt(new Vector3(position.x, this._self.transform.position.y, position.z));
			this._self.transform.position = position;
			if (Vector3.Distance(this._self.transform.position, this.path.vectorPath[this.currentWaypointIndex]) < this.stepReachDistance)
			{
				this.OnTargetReached();
			}
		}
		else if (this._self.entityType == RoleManager.EntityType.EntityType_Monster && (this._self.roleAction.curStatus == 2 || this._self.roleAction.curStatus == 20))
		{
			this._self.roleAction.SetRoleIdle();
		}
	}

	private void LateUpdate()
	{
		if (this.moveQueue.Count > 0 && !this.inProcess && this.canMove)
		{
			this.inProcess = true;
			this.curQueueItem = this.moveQueue[0];
			this.moveQueue.RemoveAt(0);
			float num = Vector3.Distance(this._self.transform.position, this.curQueueItem.target);
			if (num < 0.5f)
			{
				this.curQueueItem.callback();
			}
			else
			{
				this.WalkTo(this.curQueueItem.target, this.curQueueItem.radius, this.curQueueItem.walkType, this.curQueueItem.callback, true);
			}
		}
	}

	public override void OnTargetReached()
	{
		if (this.targetReached)
		{
			Move.PathFinished pathFinished = this.pathFinished;
			this.StopPath();
			if (pathFinished != null)
			{
				pathFinished();
			}
		}
		else
		{
			this.currentWaypointIndex++;
		}
	}

	public float TrySearchPath(Vector3 _dst, Move.PathFinished _arrived)
	{
		if (Time.time - this.lastRepath >= this.repathRate && this.canSearchAgain && this.canSearch)
		{
			this.pathFinished = _arrived;
			this.destination = _dst;
			this.isAutoRunning = true;
			this.SearchPath();
			return this.repathRate;
		}
		float num = this.repathRate - (Time.time - this.lastRepath);
		return (num >= 0f) ? num : 0f;
	}

	public override void SearchPath()
	{
		if (this.destination.Equals(Vector3.zero))
		{
			return;
		}
		this.lastRepath = Time.time;
		Vector3 end = this.destination;
		this.canSearchAgain = false;
		this.seeker.StartPath(this.GetFeetPosition(), end);
	}

	public void Jump(float vertSpeed, float horizSpeed, float dashIncFactor, float horizAccSpeed, float horizEndSpeed)
	{
		if (this.jumpSystem != null && this.jumpSystem.enabled)
		{
			this.jumpSystem.RoleJump(vertSpeed, horizSpeed, dashIncFactor, horizAccSpeed, horizEndSpeed);
		}
	}

	public void JumpError(int x, int z, float y)
	{
		if (this.jumpSystem != null)
		{
			((Jump)this.jumpSystem).JumpError(x, z, y);
		}
	}

	public void StopJump()
	{
		if (this.jumpSystem != null && this.jumpSystem.enabled)
		{
			this.jumpSystem.StopJump();
		}
		else if (this.plotJumpSystem != null && this.plotJumpSystem.enabled)
		{
			this.plotJumpSystem.StopJump();
		}
	}
}
