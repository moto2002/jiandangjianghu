using System;
using System.Collections.Generic;
using UnityEngine;

public class MyPathfinding : MonoBehaviour
{
	private const int STEP = 2;

	public List<MyPath> Path = new List<MyPath>();

	public PathfinderType PathType;

	public bool stopFinding;

	public void FindPath(Vector3 startPosition, Vector3 endPosition)
	{
		this.stopFinding = false;
		if (this.PathType == PathfinderType.GridBased)
		{
			Pathfinder.Instance.InsertInQueue(startPosition, endPosition, new Action<List<Vector3>>(this.SetList));
		}
		else if (this.PathType == PathfinderType.WaypointBased)
		{
		}
	}

	private void SetList(List<Vector3> path)
	{
		if (path == null || this.stopFinding)
		{
			return;
		}
		this.Path.Clear();
		if (path.Count > 0)
		{
			for (int i = 0; i < path.Count; i++)
			{
				MyPath myPath = new MyPath();
				myPath.pos = path[i];
				if (i % 2 == 0)
				{
					myPath.isSend = true;
				}
				this.Path.Add(myPath);
			}
			this.Path[this.Path.Count - 1].isSend = true;
		}
	}
}
