using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
	private static Pathfinder instance;

	private Node[,] Map;

	public float Tilesize;

	public float MaxFalldownHeight;

	public float ClimbLimit;

	public Vector2 MapStartPosition;

	public Vector2 MapEndPosition;

	public bool DrawMapInEditor;

	public string MapName = string.Empty;

	private float updateinterval = 1f;

	private int frames;

	private float timeleft = 1f;

	private int FPS = 60;

	private int times;

	private int averageFPS;

	private static readonly float REALPOSITION_Y_OFFSET = 0.11f;

	private int TotleNodeCnt;

	private List<QueuePath> queue = new List<QueuePath>();

	private float overalltimer;

	private int iterations;

	public static Pathfinder Instance
	{
		get
		{
			return Pathfinder.instance;
		}
		private set
		{
		}
	}

	private void Awake()
	{
		Pathfinder.instance = this;
	}

	private void Start()
	{
		Pathfinder.Instance.CreateMap(this.MapName);
	}

	private void Update()
	{
		this.timeleft -= Time.deltaTime;
		this.frames++;
		if (this.timeleft <= 0f)
		{
			this.FPS = this.frames;
			this.averageFPS += this.frames;
			this.times++;
			this.timeleft = this.updateinterval;
			this.frames = 0;
		}
		float num = 0f;
		float num2 = (float)(1000 / this.FPS);
		while (this.queue.Count > 0 && num < num2)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			this.queue[0].storeRef(this.FindPath(this.queue[0].startPos, this.queue[0].endPos));
			this.queue.RemoveAt(0);
			stopwatch.Stop();
			num += (float)stopwatch.ElapsedMilliseconds;
			this.overalltimer += (float)stopwatch.ElapsedMilliseconds;
			this.iterations++;
		}
		this.DrawMapLines();
	}

	private Node ReadOneNode(BinaryReader br)
	{
		float height = br.ReadSingle();
		float xcoord = br.ReadSingle();
		float zcoord = br.ReadSingle();
		int indexX = br.ReadInt32();
		int indexY = br.ReadInt32();
		int ridValue = br.ReadInt32();
		bool w = br.ReadBoolean();
		return new Node(indexX, indexY, height, 0, ridValue, xcoord, zcoord, w, null, false);
	}

	public void CreateMap(string mapName)
	{
		TextAsset textAsset = Resources.Load<TextAsset>(string.Format("Map/{0}", mapName));
		using (MemoryStream memoryStream = new MemoryStream(textAsset.bytes))
		{
			using (BinaryReader binaryReader = new BinaryReader(memoryStream))
			{
				this.Tilesize = binaryReader.ReadSingle();
				this.MaxFalldownHeight = binaryReader.ReadSingle();
				this.ClimbLimit = binaryReader.ReadSingle();
				float x = binaryReader.ReadSingle();
				float y = binaryReader.ReadSingle();
				this.MapStartPosition = new Vector2(x, y);
				float x2 = binaryReader.ReadSingle();
				float y2 = binaryReader.ReadSingle();
				this.MapEndPosition = new Vector2(x2, y2);
				int num = binaryReader.ReadInt32();
				int num2 = binaryReader.ReadInt32();
				this.TotleNodeCnt = binaryReader.ReadInt32();
				this.Map = new Node[num2, num];
				for (int i = 0; i < this.TotleNodeCnt; i++)
				{
					Node node = this.ReadOneNode(binaryReader);
					if (this.Map[node.x, node.y] == null)
					{
						this.Map[node.x, node.y] = node;
					}
					else
					{
						Node node2 = this.Map[node.x, node.y];
						Node node3 = null;
						while (node2 != null)
						{
							node3 = node2;
							node2 = node2.yNext;
						}
						node3.yNext = node;
					}
				}
			}
		}
	}

	public Vector3 ConvertToRealPosition(int x, float y, int z)
	{
		if (this.Map == null)
		{
			return Vector3.zero;
		}
		if (x >= this.Map.GetLength(0) || z >= this.Map.GetLength(1) || x < 0 || z < 0)
		{
			return Vector3.zero;
		}
		for (Node node = this.Map[x, z]; node != null; node = node.yNext)
		{
			if (Mathf.Abs(node.yCoord - y) < Pathfinder.REALPOSITION_Y_OFFSET)
			{
				return new Vector3(node.xCoord, node.yCoord, node.zCoord);
			}
		}
		return Vector3.zero;
	}

	public Vector3 ConvertToRealPosition(float x, float y, float z)
	{
		float num = x * 100f % 100f;
		float num2 = z * 100f % 100f;
		Vector3 vector = this.ConvertToRealPosition((int)x, y, (int)z);
		if (!vector.Equals(Vector3.zero))
		{
			return new Vector3(vector.x + num / 100f, vector.y, vector.z + num2 / 100f);
		}
		return Vector3.zero;
	}

	public float GetPositionY(int x, int z)
	{
		if (this.Map == null)
		{
			return float.PositiveInfinity;
		}
		if (x >= this.Map.GetLength(0) || z >= this.Map.GetLength(1) || x < 0 || z < 0)
		{
			return float.PositiveInfinity;
		}
		for (Node node = this.Map[x, z]; node != null; node = node.yNext)
		{
			if (node.walkable)
			{
				return node.yCoord;
			}
		}
		return float.PositiveInfinity;
	}

	public float GetPositionY(float x, float z)
	{
		int num = (this.MapStartPosition.x >= 0f) ? Mathf.FloorToInt((x - this.MapStartPosition.x) / this.Tilesize) : Mathf.FloorToInt((x + Mathf.Abs(this.MapStartPosition.x)) / this.Tilesize);
		int num2 = (this.MapStartPosition.y >= 0f) ? Mathf.FloorToInt((z - this.MapStartPosition.y) / this.Tilesize) : Mathf.FloorToInt((z + Mathf.Abs(this.MapStartPosition.y)) / this.Tilesize);
		if (num >= this.Map.GetLength(0) || num2 >= this.Map.GetLength(1) || num < 0 || num2 < 0)
		{
			return float.PositiveInfinity;
		}
		return this.GetPositionY(num, num2);
	}

	public float GetPositionYByXZ(int x, int z)
	{
		if (this.Map == null)
		{
			return float.PositiveInfinity;
		}
		if (x >= this.Map.GetLength(0) || z >= this.Map.GetLength(1) || x < 0 || z < 0)
		{
			return float.PositiveInfinity;
		}
		if (this.Map[x, z].walkable)
		{
			return this.Map[x, z].yCoord;
		}
		return float.PositiveInfinity;
	}

	public float GetPositionYByXZ(float x, float z)
	{
		int num = (this.MapStartPosition.x >= 0f) ? Mathf.FloorToInt((x - this.MapStartPosition.x) / this.Tilesize) : Mathf.FloorToInt((x + Mathf.Abs(this.MapStartPosition.x)) / this.Tilesize);
		int num2 = (this.MapStartPosition.y >= 0f) ? Mathf.FloorToInt((z - this.MapStartPosition.y) / this.Tilesize) : Mathf.FloorToInt((z + Mathf.Abs(this.MapStartPosition.y)) / this.Tilesize);
		if (num >= this.Map.GetLength(0) || num2 >= this.Map.GetLength(1) || num < 0 || num2 < 0)
		{
			return float.PositiveInfinity;
		}
		return this.GetPositionY(num, num2);
	}

	public Vector3 ConvertToMapPosition(float x, float z, float y)
	{
		int num = (this.MapStartPosition.x >= 0f) ? Mathf.FloorToInt((x - this.MapStartPosition.x) / this.Tilesize) : Mathf.FloorToInt((x + Mathf.Abs(this.MapStartPosition.x)) / this.Tilesize);
		int num2 = (this.MapStartPosition.y >= 0f) ? Mathf.FloorToInt((z - this.MapStartPosition.y) / this.Tilesize) : Mathf.FloorToInt((z + Mathf.Abs(this.MapStartPosition.y)) / this.Tilesize);
		if (num >= this.Map.GetLength(0) || num2 >= this.Map.GetLength(1) || num < 0 || num2 < 0)
		{
			return Vector3.zero;
		}
		Node node = this.Map[num, num2];
		float num3 = 1000000f;
		float num4 = float.NegativeInfinity;
		Node node2 = null;
		while (node != null)
		{
			if (Mathf.Abs(node.yCoord - y) < num3)
			{
				num3 = Mathf.Abs(node.yCoord - y);
				num4 = node.yCoord;
				node2 = node;
			}
			node = node.yNext;
		}
		if (num4 == float.NegativeInfinity)
		{
			return Vector3.zero;
		}
		if (node2 != null && !node2.walkable)
		{
			return Vector3.zero;
		}
		return new Vector3((float)num, (float)num2, num4);
	}

	public void ChangeWalkableState(int startX, int startZ, int endX, int endZ, bool walkable)
	{
		if (startX >= this.Map.GetLength(0) || startZ >= this.Map.GetLength(1) || startX < 0 || startZ < 0)
		{
			return;
		}
		if (endX >= this.Map.GetLength(0) || endZ >= this.Map.GetLength(1) || endX < 0 || endZ < 0)
		{
			return;
		}
		if (startX > endX || startZ > endZ)
		{
			return;
		}
		for (int i = startX; i < endX; i++)
		{
			for (int j = startZ; j < endZ; j++)
			{
				if (this.Map[i, j] != null)
				{
					this.Map[i, j].walkable = walkable;
				}
			}
		}
	}

	public void InsertInQueue(Vector3 startPos, Vector3 endPos, Action<List<Vector3>> listMethod)
	{
		if (object.Equals(startPos, endPos))
		{
			return;
		}
		QueuePath item = new QueuePath(startPos, endPos, listMethod);
		this.queue.Add(item);
	}

	private void SetListsSize(int size, out Node[] openList, out Node[] closedList)
	{
		openList = new Node[size];
		closedList = new Node[size];
	}

	[DebuggerHidden]
	private IEnumerator PathHandler(Vector3 startPos, Vector3 endPos, Action<List<Vector3>> listMethod)
	{
		Pathfinder.<PathHandler>c__Iterator37 <PathHandler>c__Iterator = new Pathfinder.<PathHandler>c__Iterator37();
		<PathHandler>c__Iterator.startPos = startPos;
		<PathHandler>c__Iterator.endPos = endPos;
		<PathHandler>c__Iterator.listMethod = listMethod;
		<PathHandler>c__Iterator.<$>startPos = startPos;
		<PathHandler>c__Iterator.<$>endPos = endPos;
		<PathHandler>c__Iterator.<$>listMethod = listMethod;
		<PathHandler>c__Iterator.<>f__this = this;
		return <PathHandler>c__Iterator;
	}

	[DebuggerHidden]
	private IEnumerator SinglePath(Vector3 startPos, Vector3 endPos, Action<List<Vector3>> listMethod)
	{
		Pathfinder.<SinglePath>c__Iterator38 <SinglePath>c__Iterator = new Pathfinder.<SinglePath>c__Iterator38();
		<SinglePath>c__Iterator.startPos = startPos;
		<SinglePath>c__Iterator.endPos = endPos;
		<SinglePath>c__Iterator.listMethod = listMethod;
		<SinglePath>c__Iterator.<$>startPos = startPos;
		<SinglePath>c__Iterator.<$>endPos = endPos;
		<SinglePath>c__Iterator.<$>listMethod = listMethod;
		<SinglePath>c__Iterator.<>f__this = this;
		return <SinglePath>c__Iterator;
	}

	public List<Vector3> FindPath(Vector3 startPos, Vector3 endPos)
	{
		List<Vector3> list = new List<Vector3>();
		Node node;
		Node node2;
		this.SetStartAndEndNode(startPos, endPos, out node, out node2);
		bool flag = false;
		float num = (float)(node.x - node2.x);
		float num2 = (float)(node.y - node2.y);
		if (node.x == node2.x)
		{
			flag = true;
			int num3 = (node.y <= node2.y) ? 1 : -1;
			for (int num4 = node.y + num3; num4 != node2.y + num3; num4 += num3)
			{
				Node node3 = this.Map[node.x, num4];
				if (!node3.walkable)
				{
					break;
				}
				list.Add(new Vector3(node3.xCoord, node3.yCoord, node3.zCoord));
			}
		}
		else if (node.y == node2.y)
		{
			flag = true;
			int num5 = (node.x <= node2.x) ? 1 : -1;
			for (int num6 = node.x + num5; num6 != node2.x + num5; num6 += num5)
			{
				Node node4 = this.Map[num6, node.y];
				if (!node4.walkable)
				{
					break;
				}
				list.Add(new Vector3(node4.xCoord, node4.yCoord, node4.zCoord));
			}
		}
		else if (Math.Abs(num) == Math.Abs(num2))
		{
			flag = true;
			int num7 = Convert.ToInt32(num2 / num);
			int num8 = (node.x <= node2.x) ? 1 : -1;
			for (int num9 = node.x + num8; num9 != node2.x + num8; num9 += num8)
			{
				int num10 = (num9 - node2.x) * num7 + node2.y;
				Node node5 = this.Map[num9, num10];
				if (!node5.walkable)
				{
					break;
				}
				list.Add(new Vector3(node5.xCoord, node5.yCoord, node5.zCoord));
			}
		}
		if (!flag)
		{
			Node[] array;
			Node[] array2;
			this.SetListsSize(this.TotleNodeCnt, out array, out array2);
			Node node6 = null;
			List<NodeSearch> list2 = new List<NodeSearch>();
			int num11 = 0;
			bool flag2 = true;
			if (node != null)
			{
				if (node2 == null)
				{
					flag2 = false;
					this.FindEndNode(endPos, ref num11, ref node2);
					if (node2 == null)
					{
						num11 = 0;
						return new List<Vector3>();
					}
				}
				Array.Clear(array, 0, array.Length);
				Array.Clear(array2, 0, array.Length);
				if (list2.Count > 0)
				{
					list2.Clear();
				}
				array[node.RID] = node;
				this.BHInsertNode(new NodeSearch(node.RID, node.F), ref list2, ref array);
				bool flag3 = false;
				while (!flag3)
				{
					if (list2.Count == 0)
					{
						return new List<Vector3>();
					}
					int num12 = this.BHGetLowest(ref list2, ref array);
					node6 = array[num12];
					array2[node6.RID] = node6;
					array[num12] = null;
					if (node6.RID == node2.RID)
					{
						flag3 = true;
					}
					else
					{
						this.NeighbourCheck(ref node6, ref node2, ref array, ref array2, ref list2);
					}
				}
				while (node6.parent != null)
				{
					list.Add(new Vector3(node6.xCoord, node6.yCoord, node6.zCoord));
					node6 = node6.parent;
				}
				list.Reverse();
				if (flag2)
				{
				}
				if (list.Count > 2 && flag2)
				{
					if (Vector3.Distance(list[list.Count - 1], list[list.Count - 3]) < Vector3.Distance(list[list.Count - 3], list[list.Count - 2]))
					{
						list.RemoveAt(list.Count - 2);
					}
					if (Vector3.Distance(list[1], startPos) < Vector3.Distance(list[0], list[1]))
					{
						list.RemoveAt(0);
					}
				}
			}
			num11 = 0;
		}
		return list;
	}

	public void FindPath(Vector3 startPos, Vector3 endPos, Action<List<Vector3>> listMethod)
	{
		Loom.RunAsync(delegate
		{
			List<Vector3> returnPath = new List<Vector3>();
			Node node;
			Node node2;
			this.SetStartAndEndNode(startPos, endPos, out node, out node2);
			bool flag = false;
			float num = (float)(node.x - node2.x);
			float num2 = (float)(node.y - node2.y);
			if (node.x == node2.x)
			{
				flag = true;
				int num3 = (node.y <= node2.y) ? 1 : -1;
				for (int num4 = node.y + num3; num4 != node2.y + num3; num4 += num3)
				{
					Node node3 = this.Map[node.x, num4];
					if (!node3.walkable)
					{
						break;
					}
					returnPath.Add(new Vector3(node3.xCoord, node3.yCoord, node3.zCoord));
				}
			}
			else if (node.y == node2.y)
			{
				flag = true;
				int num5 = (node.x <= node2.x) ? 1 : -1;
				for (int num6 = node.x + num5; num6 != node2.x + num5; num6 += num5)
				{
					Node node4 = this.Map[num6, node.y];
					if (!node4.walkable)
					{
						break;
					}
					returnPath.Add(new Vector3(node4.xCoord, node4.yCoord, node4.zCoord));
				}
			}
			else if (Math.Abs(num) == Math.Abs(num2))
			{
				flag = true;
				int num7 = Convert.ToInt32(num2 / num);
				int num8 = (node.x <= node2.x) ? 1 : -1;
				for (int num9 = node.x + num8; num9 != node2.x + num8; num9 += num8)
				{
					int num10 = (num9 - node2.x) * num7 + node2.y;
					Node node5 = this.Map[num9, num10];
					if (!node5.walkable)
					{
						break;
					}
					returnPath.Add(new Vector3(node5.xCoord, node5.yCoord, node5.zCoord));
				}
			}
			if (!flag)
			{
				Node[] array;
				Node[] array2;
				this.SetListsSize(this.TotleNodeCnt, out array, out array2);
				Node node6 = null;
				List<NodeSearch> list = new List<NodeSearch>();
				int num11 = 0;
				bool flag2 = true;
				if (node != null)
				{
					if (node2 == null)
					{
						flag2 = false;
						this.FindEndNode(endPos, ref num11, ref node2);
						if (node2 == null)
						{
							num11 = 0;
							listMethod(new List<Vector3>());
							return;
						}
					}
					Array.Clear(array, 0, array.Length);
					Array.Clear(array2, 0, array.Length);
					if (list.Count > 0)
					{
						list.Clear();
					}
					array[node.RID] = node;
					this.BHInsertNode(new NodeSearch(node.RID, node.F), ref list, ref array);
					bool flag3 = false;
					while (!flag3)
					{
						if (list.Count == 0)
						{
							listMethod(new List<Vector3>());
							return;
						}
						int num12 = this.BHGetLowest(ref list, ref array);
						node6 = array[num12];
						array2[node6.RID] = node6;
						array[num12] = null;
						if (node6.RID == node2.RID)
						{
							flag3 = true;
						}
						else
						{
							this.NeighbourCheck(ref node6, ref node2, ref array, ref array2, ref list);
						}
					}
					while (node6.parent != null)
					{
						returnPath.Add(new Vector3(node6.xCoord, node6.yCoord, node6.zCoord));
						node6 = node6.parent;
					}
					returnPath.Reverse();
					if (flag2)
					{
					}
					if (returnPath.Count > 2 && flag2)
					{
						if (Vector3.Distance(returnPath[returnPath.Count - 1], returnPath[returnPath.Count - 3]) < Vector3.Distance(returnPath[returnPath.Count - 3], returnPath[returnPath.Count - 2]))
						{
							returnPath.RemoveAt(returnPath.Count - 2);
						}
						if (Vector3.Distance(returnPath[1], startPos) < Vector3.Distance(returnPath[0], returnPath[1]))
						{
							returnPath.RemoveAt(0);
						}
					}
				}
				num11 = 0;
			}
			Loom.QueueOnMainThread(delegate
			{
				listMethod(returnPath);
			});
		});
	}

	private void SetStartAndEndNode(Vector3 start, Vector3 end, out Node startNode, out Node endNode)
	{
		startNode = this.FindClosestNode(start);
		endNode = this.FindClosestNode(end);
	}

	private Node FindClosestNode(Vector3 pos)
	{
		int num = (this.MapStartPosition.x >= 0f) ? Mathf.FloorToInt((pos.x - this.MapStartPosition.x) / this.Tilesize) : Mathf.FloorToInt((pos.x + Mathf.Abs(this.MapStartPosition.x)) / this.Tilesize);
		int num2 = (this.MapStartPosition.y >= 0f) ? Mathf.FloorToInt((pos.z - this.MapStartPosition.y) / this.Tilesize) : Mathf.FloorToInt((pos.z + Mathf.Abs(this.MapStartPosition.y)) / this.Tilesize);
		if (num < 0 || num2 < 0 || num > this.Map.GetLength(0) || num2 > this.Map.GetLength(1))
		{
			return null;
		}
		Node node = this.Map[num, num2];
		Node node2 = node;
		float num3 = float.PositiveInfinity;
		while (node2 != null)
		{
			if (node2.walkable && Mathf.Abs(node2.yCoord - pos.y) < num3)
			{
				num3 = Mathf.Abs(node2.yCoord - pos.y);
				node = node2;
			}
			node2 = node2.yNext;
		}
		if (node.walkable)
		{
			return new Node(num, num2, node.yCoord, node.ID, node.RID, node.xCoord, node.zCoord, node.walkable, null, false);
		}
		for (int i = num2 - 1; i < num2 + 2; i++)
		{
			for (int j = num - 1; j < num + 2; j++)
			{
				if (i > -1 && i < this.Map.GetLength(1) && j > -1 && j < this.Map.GetLength(0))
				{
					for (Node node3 = this.Map[j, i]; node3 != null; node3 = node3.yNext)
					{
						if (node3.walkable)
						{
							return new Node(j, i, node3.yCoord, node3.ID, node3.RID, node3.xCoord, node3.zCoord, node3.walkable, null, false);
						}
					}
				}
			}
		}
		return null;
	}

	private void FindEndNode(Vector3 pos, ref int maxSearchRounds, ref Node endNode)
	{
		int num = (this.MapStartPosition.x >= 0f) ? Mathf.FloorToInt((pos.x - this.MapStartPosition.x) / this.Tilesize) : Mathf.FloorToInt((pos.x + Mathf.Abs(this.MapStartPosition.x)) / this.Tilesize);
		int num2 = (this.MapStartPosition.y >= 0f) ? Mathf.FloorToInt((pos.z - this.MapStartPosition.y) / this.Tilesize) : Mathf.FloorToInt((pos.z + Mathf.Abs(this.MapStartPosition.y)) / this.Tilesize);
		if (num < 0 || num2 < 0 || num > this.Map.GetLength(0) || num2 > this.Map.GetLength(1))
		{
			return;
		}
		Node a = this.Map[num, num2];
		List<Node> list = new List<Node>();
		int num3 = 1;
		while (list.Count < 1 && (float)maxSearchRounds < 10f / this.Tilesize)
		{
			list = this.EndNodeNeighbourCheck(num, num2, num3);
			num3++;
			maxSearchRounds++;
		}
		if (list.Count > 0)
		{
			int num4 = 99999999;
			Node node = null;
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				Node node2 = list[i];
				int heuristics = this.GetHeuristics(a, node2);
				if (heuristics < num4)
				{
					num4 = heuristics;
					node = node2;
				}
			}
			endNode = new Node(node.x, node.y, node.yCoord, node.ID, node.RID, node.xCoord, node.zCoord, node.walkable, null, false);
		}
	}

	private List<Node> EndNodeNeighbourCheck(int x, int z, int r)
	{
		List<Node> list = new List<Node>();
		for (int i = z - r; i < z + r + 1; i++)
		{
			for (int j = x - r; j < x + r + 1; j++)
			{
				if (i > -1 && j > -1 && i < this.Map.GetLength(0) && j < this.Map.GetLength(1) && (i < z - r + 1 || i > z + r - 1 || j < x - r + 1 || j > x + r - 1))
				{
					for (Node node = this.Map[j, i]; node != null; node = node.yNext)
					{
						if (node.walkable)
						{
							list.Add(node);
						}
					}
				}
			}
		}
		return list;
	}

	private void NeighbourCheck(ref Node currentNode, ref Node endNode, ref Node[] openList, ref Node[] closedList, ref List<NodeSearch> sortedOpenList)
	{
		int x = currentNode.x;
		int y = currentNode.y;
		for (int i = y - 1; i < y + 2; i++)
		{
			for (int j = x - 1; j < x + 2; j++)
			{
				if (i > -1 && i < this.Map.GetLength(1) && j > -1 && j < this.Map.GetLength(0) && (i != y || j != x))
				{
					for (Node node = this.Map[j, i]; node != null; node = node.yNext)
					{
						if (node.walkable && !this.OnClosedList(node.RID, ref closedList) && ((node.yCoord - currentNode.yCoord < this.ClimbLimit && node.yCoord - currentNode.yCoord >= 0f) || (currentNode.yCoord - node.yCoord < this.MaxFalldownHeight && currentNode.yCoord >= node.yCoord)))
						{
							if (!this.OnOpenList(node.RID, ref openList))
							{
								Node node2 = new Node(node.x, node.y, node.yCoord, node.ID, node.RID, node.xCoord, node.zCoord, node.walkable, currentNode, false);
								node2.H = this.GetHeuristics(node.x, node.y, ref endNode);
								node2.G = this.GetMovementCost(x, y, j, i) + currentNode.G;
								node2.F = node2.H + node2.G;
								openList[node2.RID] = node2;
								this.BHInsertNode(new NodeSearch(node2.RID, node2.F), ref sortedOpenList, ref openList);
							}
							else
							{
								Node nodeFromOpenList = this.GetNodeFromOpenList(node.RID, ref openList);
								if (currentNode.G + this.GetMovementCost(x, y, j, i) < openList[node.RID].G)
								{
									nodeFromOpenList.parent = currentNode;
									nodeFromOpenList.G = currentNode.G + this.GetMovementCost(x, y, j, i);
									nodeFromOpenList.F = nodeFromOpenList.G + nodeFromOpenList.H;
									this.BHSortNode(nodeFromOpenList.RID, nodeFromOpenList.F, ref sortedOpenList, ref openList);
								}
							}
						}
					}
				}
			}
		}
	}

	private bool OnOpenList(int rid, ref Node[] openList)
	{
		return openList[rid] != null;
	}

	private bool OnClosedList(int rid, ref Node[] closedList)
	{
		return closedList[rid] != null;
	}

	private int GetHeuristics(int x, int y, ref Node endNode)
	{
		return (int)((float)Mathf.Abs(x - endNode.x) * 10f) + (int)((float)Mathf.Abs(y - endNode.y) * 10f);
	}

	private int GetHeuristics(Node a, Node b)
	{
		return (int)((float)Mathf.Abs(a.x - b.x) * 10f) + (int)((float)Mathf.Abs(a.y - b.y) * 10f);
	}

	private int GetMovementCost(int x, int y, int j, int i)
	{
		return (x == j || y == i) ? 10 : 14;
	}

	private Node GetNodeFromOpenList(int rid, ref Node[] openList)
	{
		return (openList[rid] == null) ? null : openList[rid];
	}

	private void BHInsertNode(NodeSearch ns, ref List<NodeSearch> sortedOpenList, ref Node[] openList)
	{
		if (sortedOpenList.Count == 0)
		{
			sortedOpenList.Add(ns);
			openList[ns.RID].sortedIndex = 0;
			return;
		}
		sortedOpenList.Add(ns);
		bool flag = true;
		int num = sortedOpenList.Count - 1;
		openList[ns.RID].sortedIndex = num;
		while (flag)
		{
			int num2 = Mathf.FloorToInt((float)((num - 1) / 2));
			if (num == 0)
			{
				flag = false;
				openList[sortedOpenList[num].RID].sortedIndex = 0;
			}
			else if (sortedOpenList[num].F < sortedOpenList[num2].F)
			{
				NodeSearch value = sortedOpenList[num2];
				sortedOpenList[num2] = sortedOpenList[num];
				sortedOpenList[num] = value;
				openList[sortedOpenList[num].RID].sortedIndex = num;
				openList[sortedOpenList[num2].RID].sortedIndex = num2;
				num = num2;
			}
			else
			{
				flag = false;
			}
		}
	}

	private void BHSortNode(int rid, int F, ref List<NodeSearch> sortedOpenList, ref Node[] openList)
	{
		bool flag = true;
		int num = openList[rid].sortedIndex;
		sortedOpenList[num].F = F;
		while (flag)
		{
			int num2 = Mathf.FloorToInt((float)((num - 1) / 2));
			if (num == 0)
			{
				flag = false;
				openList[sortedOpenList[num].RID].sortedIndex = 0;
			}
			else if (sortedOpenList[num].F < sortedOpenList[num2].F)
			{
				NodeSearch value = sortedOpenList[num2];
				sortedOpenList[num2] = sortedOpenList[num];
				sortedOpenList[num] = value;
				openList[sortedOpenList[num].RID].sortedIndex = num;
				openList[sortedOpenList[num2].RID].sortedIndex = num2;
				num = num2;
			}
			else
			{
				flag = false;
			}
		}
	}

	private int BHGetLowest(ref List<NodeSearch> sortedOpenList, ref Node[] openList)
	{
		if (sortedOpenList.Count == 1)
		{
			int rID = sortedOpenList[0].RID;
			sortedOpenList.RemoveAt(0);
			return rID;
		}
		if (sortedOpenList.Count > 1)
		{
			int rID2 = sortedOpenList[0].RID;
			sortedOpenList[0] = sortedOpenList[sortedOpenList.Count - 1];
			sortedOpenList.RemoveAt(sortedOpenList.Count - 1);
			openList[sortedOpenList[0].RID].sortedIndex = 0;
			int num = 0;
			bool flag = true;
			while (flag)
			{
				int num2 = num * 2 + 1;
				int num3 = num * 2 + 2;
				if (num2 >= sortedOpenList.Count)
				{
					break;
				}
				int num4 = num2;
				if (num3 < sortedOpenList.Count && sortedOpenList[num3].F < sortedOpenList[num2].F)
				{
					num4 = num3;
				}
				if (sortedOpenList[num].F <= sortedOpenList[num4].F)
				{
					break;
				}
				NodeSearch value = sortedOpenList[num];
				sortedOpenList[num] = sortedOpenList[num4];
				sortedOpenList[num4] = value;
				openList[sortedOpenList[num].RID].sortedIndex = num;
				openList[sortedOpenList[num4].RID].sortedIndex = num4;
				num = num4;
			}
			return rID2;
		}
		return -1;
	}

	private void DrawMapLines()
	{
		if (this.DrawMapInEditor && this.Map != null)
		{
			for (int i = 0; i < this.Map.GetLength(1); i++)
			{
				for (int j = 0; j < this.Map.GetLength(0); j++)
				{
					Node node = this.Map[j, i];
					while (node != null)
					{
						if (!node.walkable)
						{
							node = node.yNext;
						}
						else
						{
							for (int k = i - 1; k < i + 2; k++)
							{
								for (int l = j - 1; l < j + 2; l++)
								{
									if (k >= 0 && l >= 0 && k < this.Map.GetLength(1) && l < this.Map.GetLength(0))
									{
										Node node2 = this.Map[l, k];
										while (node2 != null)
										{
											if (!node2.walkable)
											{
												node2 = node2.yNext;
											}
											else if (node.yCoord > node2.yCoord && Mathf.Abs(node.yCoord - node2.yCoord) > this.MaxFalldownHeight)
											{
												node2 = node2.yNext;
											}
											else if (node.yCoord < node2.yCoord && Mathf.Abs(node2.yCoord - node.yCoord) > this.ClimbLimit)
											{
												node2 = node2.yNext;
											}
											else
											{
												Vector3 start = new Vector3(node.xCoord, node.yCoord + 0.1f, node.zCoord);
												Vector3 end = new Vector3(node2.xCoord, node2.yCoord + 0.1f, node2.zCoord);
												Debug.DrawLine(start, end, Color.green);
												node2 = node2.yNext;
											}
										}
									}
								}
							}
							node = node.yNext;
						}
					}
				}
			}
		}
	}
}
