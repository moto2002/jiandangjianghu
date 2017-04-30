using GraphCollection;
using LuaFramework;
using System;
using System.Collections.Generic;
using System.Text;
using ThirdParty;
using UnityEngine;

public class WorldPathfinding : Singleton<WorldPathfinding>
{
	public class TargetInfo
	{
		public int toMapId;

		public float radius;

		public Vector3 destination;

		public Move.PathFinished pathFinished;

		public TargetInfo(int _toMap, Vector3 _dest, float _ra, Move.PathFinished _arrived)
		{
			this.toMapId = _toMap;
			this.destination = _dest;
			this.radius = _ra;
			this.pathFinished = _arrived;
		}

		public bool IsInWorldPathfinding()
		{
			return this.toMapId != 0 && this.destination != Vector3.zero;
		}

		public void Clear()
		{
			this.toMapId = 0;
			this.destination = Vector3.zero;
			this.pathFinished = null;
		}
	}

	public class MapPathInfo
	{
		public int id
		{
			get;
			private set;
		}

		public string Name
		{
			get
			{
				return this.id.ToString();
			}
		}

		public Dictionary<int, Vector3> gates
		{
			get;
			private set;
		}

		public MapPathInfo(int id)
		{
			this.gates = new Dictionary<int, Vector3>();
			this.id = id;
		}

		public void Release()
		{
			this.gates.Clear();
		}

		public Vector3 FindPoint(int toMap)
		{
			Vector3 vector;
			if (!this.gates.TryGetValue(toMap, out vector))
			{
				Debug.LogError(string.Format("cross map pathfinding error! no path to {0} exists in mapId {1}", toMap, this.id));
				return Vector3.zero;
			}
			return Util.Convert2RealPosition((int)vector.x, vector.y, (int)vector.z);
		}

		public bool Equals(WorldPathfinding.MapPathInfo compareMap)
		{
			return this.id == compareMap.id;
		}
	}

	private Dictionary<int, GraphNode<WorldPathfinding.MapPathInfo>> worldmaps;

	private Dijkstra<WorldPathfinding.MapPathInfo> dijkstra;

	public bool init
	{
		get;
		set;
	}

	public WorldPathfinding.TargetInfo targetInfo
	{
		get;
		private set;
	}

	public WorldPathfinding()
	{
		this.worldmaps = new Dictionary<int, GraphNode<WorldPathfinding.MapPathInfo>>();
	}

	public static WorldPathfinding GetInstance()
	{
		return Singleton<WorldPathfinding>.Instance;
	}

	public void AddWorldPathfindingInfo(int startMap, int endMap, int x, int z, float y)
	{
		GraphNode<WorldPathfinding.MapPathInfo> graphNode;
		if (!this.worldmaps.TryGetValue(startMap, out graphNode))
		{
			graphNode = new GraphNode<WorldPathfinding.MapPathInfo>(new WorldPathfinding.MapPathInfo(startMap));
			this.worldmaps.Add(startMap, graphNode);
		}
		GraphNode<WorldPathfinding.MapPathInfo> graphNode2;
		if (!this.worldmaps.TryGetValue(endMap, out graphNode2))
		{
			graphNode2 = new GraphNode<WorldPathfinding.MapPathInfo>(new WorldPathfinding.MapPathInfo(endMap));
			this.worldmaps.Add(endMap, graphNode2);
		}
		if (!graphNode.Value.gates.ContainsKey(endMap))
		{
			graphNode.Value.gates.Add(endMap, new Vector3((float)x, y, (float)z));
			graphNode.AddNeighbour(graphNode2, 1);
		}
	}

	public List<GraphNode<WorldPathfinding.MapPathInfo>> FindPath(int startMap, int endMap)
	{
		if (this.dijkstra == null)
		{
			this.dijkstra = new Dijkstra<WorldPathfinding.MapPathInfo>(this.worldmaps.Values);
		}
		if (this.worldmaps.ContainsKey(startMap) && this.worldmaps.ContainsKey(endMap))
		{
			return this.dijkstra.FindShortestPathBetween(this.worldmaps[startMap], this.worldmaps[endMap]) as List<GraphNode<WorldPathfinding.MapPathInfo>>;
		}
		return null;
	}

	public void BeginWorldPathfinding(int toMap, int x, float y, int z, float ra = 0.1f, Move.PathFinished callback = null, bool midPoint = false)
	{
		if (Singleton<RoleManager>.Instance.mainRole != null)
		{
			if (Singleton<RoleManager>.Instance.mainRole.move.jumpMode != 0)
			{
				Util.CallMethod("CtrlManager", "CSPopUpNotifyText", new object[]
				{
					"PlotJumpTip"
				});
				return;
			}
			Vector3 vector = new Vector3((float)x, y, (float)z);
			if (toMap == 0 || vector == Vector3.zero)
			{
				return;
			}
			if (this.targetInfo == null || (this.targetInfo.toMapId != toMap && toMap != 0) || (this.targetInfo.destination != vector && vector != Vector3.zero))
			{
				this.targetInfo = new WorldPathfinding.TargetInfo(toMap, vector, ra, callback);
			}
			Singleton<RoleManager>.Instance.mainRole.roleState.AddState(16);
			Singleton<RoleManager>.Instance.mainRole.move.SearchPathInWorld(toMap, vector, ra, delegate
			{
				Singleton<RoleManager>.Instance.mainRole.roleState.RemoveState(16);
				if (callback != null)
				{
					callback();
				}
			});
			Util.CallMethod("HERO", "SetMidPointWalk", new object[]
			{
				midPoint
			});
		}
	}

	public bool CheckWorldPathfinding()
	{
		if (this.targetInfo != null && this.targetInfo.IsInWorldPathfinding())
		{
			this.BeginWorldPathfinding(this.targetInfo.toMapId, (int)this.targetInfo.destination.x, this.targetInfo.destination.y, (int)this.targetInfo.destination.z, this.targetInfo.radius, this.targetInfo.pathFinished, false);
			return true;
		}
		return false;
	}

	public bool IsInWorldPathfinding()
	{
		return this.targetInfo != null && this.targetInfo.IsInWorldPathfinding();
	}

	public void StopWorldPathfinding()
	{
		if (this.targetInfo != null && this.targetInfo.IsInWorldPathfinding())
		{
			this.targetInfo.Clear();
		}
	}

	public void Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (GraphNode<WorldPathfinding.MapPathInfo> current in this.worldmaps.Values)
		{
			stringBuilder.Append(string.Format("[{0}]:", current.Value.id));
			for (int i = 0; i < current.Neighbours.Count; i++)
			{
				stringBuilder.Append(string.Format("{0},", current.Neighbours[i].GraphNode.Value.id));
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			stringBuilder.Append("\n");
		}
		Debug.Log(stringBuilder.ToString());
	}

	public void Clear()
	{
		foreach (GraphNode<WorldPathfinding.MapPathInfo> current in this.worldmaps.Values)
		{
			current.Value.Release();
		}
		this.worldmaps.Clear();
		if (this.dijkstra != null)
		{
			this.dijkstra.Clear();
			this.dijkstra = null;
		}
	}

	public void DoCallBack(Move.PathFinished callback = null)
	{
		if (callback != null)
		{
			callback();
		}
	}
}
