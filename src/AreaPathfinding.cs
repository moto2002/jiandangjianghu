using GraphCollection;
using Pathfinding.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ThirdParty;
using UnityEngine;

public class AreaPathfinding : Singleton<AreaPathfinding>
{
	public class AreaInfo
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

		public List<JumpGate> gates
		{
			get;
			private set;
		}

		public AreaInfo(int id)
		{
			this.gates = ListPool<JumpGate>.Claim();
			this.id = id;
		}

		public void Release()
		{
			ListPool<JumpGate>.Release(this.gates);
		}

		public Vector3 FindPoint(int toArea)
		{
			for (int i = 0; i < this.gates.Count; i++)
			{
				if (this.gates[i].endArea == toArea && this.gates[i].endMap == Singleton<RoleManager>.Instance.curSceneNo)
				{
					return this.gates[i].transform.position;
				}
			}
			Debug.Log(string.Format("no entry to {0} exists in Area {1}", toArea, this.id));
			return Vector3.zero;
		}

		public bool Equals(AreaPathfinding.AreaInfo compareArea)
		{
			return this.id == compareArea.id;
		}
	}

	private Dictionary<int, GraphNode<AreaPathfinding.AreaInfo>> areas;

	private Dijkstra<AreaPathfinding.AreaInfo> dijkstra;

	public AreaPathfinding()
	{
		this.areas = new Dictionary<int, GraphNode<AreaPathfinding.AreaInfo>>();
	}

	public void CreateAreaInfo()
	{
		base.StartCoroutine(this._createAreaInfo());
	}

	[DebuggerHidden]
	private IEnumerator _createAreaInfo()
	{
		AreaPathfinding.<_createAreaInfo>c__Iterator30 <_createAreaInfo>c__Iterator = new AreaPathfinding.<_createAreaInfo>c__Iterator30();
		<_createAreaInfo>c__Iterator.<>f__this = this;
		return <_createAreaInfo>c__Iterator;
	}

	public void AddGateInfo(JumpGate gate)
	{
		GraphNode<AreaPathfinding.AreaInfo> graphNode;
		if (!this.areas.TryGetValue(gate.startArea, out graphNode))
		{
			Debug.LogError(string.Format("area {0} is not iniitilized!", gate.startArea));
			return;
		}
		GraphNode<AreaPathfinding.AreaInfo> graphNode2;
		if (!this.areas.TryGetValue(gate.endArea, out graphNode2) && gate.type == 2)
		{
			Debug.LogError(string.Format("neighbour area {0} is not iniitilized!", gate.endArea));
			return;
		}
		if (!graphNode.Value.gates.Contains(gate))
		{
			graphNode.Value.gates.Add(gate);
		}
		if (gate.type == 2)
		{
			graphNode.AddNeighbour(graphNode2, 1);
		}
	}

	public List<GraphNode<AreaPathfinding.AreaInfo>> FindPath(int startArea, int endArea)
	{
		if (this.dijkstra == null)
		{
			this.dijkstra = new Dijkstra<AreaPathfinding.AreaInfo>(this.areas.Values);
		}
		if (this.areas.ContainsKey(startArea) && this.areas.ContainsKey(endArea))
		{
			return this.dijkstra.FindShortestPathBetween(this.areas[startArea], this.areas[endArea]) as List<GraphNode<AreaPathfinding.AreaInfo>>;
		}
		return null;
	}

	public void Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (GraphNode<AreaPathfinding.AreaInfo> current in this.areas.Values)
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
		foreach (GraphNode<AreaPathfinding.AreaInfo> current in this.areas.Values)
		{
			current.Value.Release();
		}
		this.areas.Clear();
		if (this.dijkstra != null)
		{
			this.dijkstra.Clear();
			this.dijkstra = null;
		}
	}
}
