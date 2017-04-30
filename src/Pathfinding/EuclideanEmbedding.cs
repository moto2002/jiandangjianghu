using Pathfinding.Util;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	public class EuclideanEmbedding
	{
		private const uint ra = 12820163u;

		private const uint rc = 1140671485u;

		public HeuristicOptimizationMode mode;

		public int seed;

		public Transform pivotPointRoot;

		public int spreadOutCount = 1;

		[NonSerialized]
		public bool dirty;

		private uint[] costs = new uint[8];

		private int maxNodeIndex;

		private int pivotCount;

		private GraphNode[] pivots;

		private uint rval;

		private object lockObj = new object();

		private uint GetRandom()
		{
			this.rval = 12820163u * this.rval + 1140671485u;
			return this.rval;
		}

		private void EnsureCapacity(int index)
		{
			if (index > this.maxNodeIndex)
			{
				object obj = this.lockObj;
				lock (obj)
				{
					if (index > this.maxNodeIndex)
					{
						if (index >= this.costs.Length)
						{
							uint[] array = new uint[Math.Max(index * 2, this.pivots.Length * 2)];
							for (int i = 0; i < this.costs.Length; i++)
							{
								array[i] = this.costs[i];
							}
							this.costs = array;
						}
						this.maxNodeIndex = index;
					}
				}
			}
		}

		public uint GetHeuristic(int nodeIndex1, int nodeIndex2)
		{
			nodeIndex1 *= this.pivotCount;
			nodeIndex2 *= this.pivotCount;
			if (nodeIndex1 >= this.costs.Length || nodeIndex2 >= this.costs.Length)
			{
				this.EnsureCapacity((nodeIndex1 <= nodeIndex2) ? nodeIndex2 : nodeIndex1);
			}
			uint num = 0u;
			for (int i = 0; i < this.pivotCount; i++)
			{
				uint num2 = (uint)Math.Abs((int)(this.costs[nodeIndex1 + i] - this.costs[nodeIndex2 + i]));
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		private void GetClosestWalkableNodesToChildrenRecursively(Transform tr, List<GraphNode> nodes)
		{
			foreach (Transform transform in tr)
			{
				NNInfo nearest = AstarPath.active.GetNearest(transform.position, NNConstraint.Default);
				if (nearest.node != null && nearest.node.Walkable)
				{
					nodes.Add(nearest.node);
				}
				this.GetClosestWalkableNodesToChildrenRecursively(transform, nodes);
			}
		}

		private void PickNRandomNodes(int count, List<GraphNode> buffer)
		{
			int n = 0;
			NavGraph[] graphs = AstarPath.active.graphs;
			for (int i = 0; i < graphs.Length; i++)
			{
				graphs[i].GetNodes(delegate(GraphNode node)
				{
					if (!node.Destroyed && node.Walkable)
					{
						n++;
						if ((ulong)this.GetRandom() % (ulong)((long)n) < (ulong)((long)count))
						{
							if (buffer.Count < count)
							{
								buffer.Add(node);
							}
							else
							{
								buffer[(int)((ulong)this.GetRandom() % (ulong)((long)buffer.Count))] = node;
							}
						}
					}
					return true;
				});
			}
		}

		private GraphNode PickAnyWalkableNode()
		{
			NavGraph[] graphs = AstarPath.active.graphs;
			GraphNode first = null;
			for (int i = 0; i < graphs.Length; i++)
			{
				graphs[i].GetNodes(delegate(GraphNode node)
				{
					if (node != null && node.Walkable)
					{
						first = node;
						return false;
					}
					return true;
				});
			}
			return first;
		}

		public void RecalculatePivots()
		{
			if (this.mode == HeuristicOptimizationMode.None)
			{
				this.pivotCount = 0;
				this.pivots = null;
				return;
			}
			this.rval = (uint)this.seed;
			List<GraphNode> list = ListPool<GraphNode>.Claim();
			switch (this.mode)
			{
			case HeuristicOptimizationMode.Random:
				this.PickNRandomNodes(this.spreadOutCount, list);
				break;
			case HeuristicOptimizationMode.RandomSpreadOut:
			{
				if (this.pivotPointRoot != null)
				{
					this.GetClosestWalkableNodesToChildrenRecursively(this.pivotPointRoot, list);
				}
				if (list.Count == 0)
				{
					GraphNode graphNode = this.PickAnyWalkableNode();
					if (graphNode == null)
					{
						Debug.LogError("Could not find any walkable node in any of the graphs.");
						ListPool<GraphNode>.Release(list);
						return;
					}
					list.Add(graphNode);
				}
				int num = this.spreadOutCount - list.Count;
				for (int i = 0; i < num; i++)
				{
					list.Add(null);
				}
				break;
			}
			case HeuristicOptimizationMode.Custom:
				if (this.pivotPointRoot == null)
				{
					throw new Exception("heuristicOptimizationMode is HeuristicOptimizationMode.Custom, but no 'customHeuristicOptimizationPivotsRoot' is set");
				}
				this.GetClosestWalkableNodesToChildrenRecursively(this.pivotPointRoot, list);
				break;
			default:
				throw new Exception("Invalid HeuristicOptimizationMode: " + this.mode);
			}
			this.pivots = list.ToArray();
			ListPool<GraphNode>.Release(list);
		}

		public void RecalculateCosts()
		{
			if (this.pivots == null)
			{
				this.RecalculatePivots();
			}
			if (this.mode == HeuristicOptimizationMode.None)
			{
				return;
			}
			this.pivotCount = 0;
			for (int i = 0; i < this.pivots.Length; i++)
			{
				if (this.pivots[i] != null && (this.pivots[i].Destroyed || !this.pivots[i].Walkable))
				{
					throw new Exception("Invalid pivot nodes (destroyed or unwalkable)");
				}
			}
			if (this.mode != HeuristicOptimizationMode.RandomSpreadOut)
			{
				for (int j = 0; j < this.pivots.Length; j++)
				{
					if (this.pivots[j] == null)
					{
						throw new Exception("Invalid pivot nodes (null)");
					}
				}
			}
			Debug.Log("Recalculating costs...");
			this.pivotCount = this.pivots.Length;
			Action<int> startCostCalculation = null;
			int numComplete = 0;
			OnPathDelegate onComplete = delegate(Path path)
			{
				numComplete++;
				if (numComplete == this.pivotCount)
				{
					Debug.Log("Grid graph special case!");
					this.ApplyGridGraphEndpointSpecialCase();
				}
			};
			startCostCalculation = delegate(int k)
			{
				GraphNode pivot = this.pivots[k];
				FloodPath fp = null;
				fp = FloodPath.Construct(pivot, onComplete);
				fp.immediateCallback = delegate(Path _p)
				{
					_p.Claim(this);
					MeshNode meshNode = pivot as MeshNode;
					uint costOffset = 0u;
					int k;
					if (meshNode != null && meshNode.connectionCosts != null)
					{
						for (k = 0; k < meshNode.connectionCosts.Length; k++)
						{
							costOffset = Math.Max(costOffset, meshNode.connectionCosts[k]);
						}
					}
					NavGraph[] graphs = AstarPath.active.graphs;
					for (int m = graphs.Length - 1; m >= 0; m--)
					{
						graphs[m].GetNodes(delegate(GraphNode node)
						{
							int num6 = node.NodeIndex * this.pivotCount + k;
							this.EnsureCapacity(num6);
							PathNode pathNode = fp.pathHandler.GetPathNode(node);
							if (costOffset > 0u)
							{
								this.costs[num6] = ((pathNode.pathID != fp.pathID || pathNode.parent == null) ? 0u : Math.Max(pathNode.parent.G - costOffset, 0u));
							}
							else
							{
								this.costs[num6] = ((pathNode.pathID != fp.pathID) ? 0u : pathNode.G);
							}
							return true;
						});
					}
					if (this.mode == HeuristicOptimizationMode.RandomSpreadOut && k < this.pivots.Length - 1)
					{
						if (this.pivots[k + 1] == null)
						{
							int num = -1;
							uint num2 = 0u;
							int num3 = this.maxNodeIndex / this.pivotCount;
							for (int n = 1; n < num3; n++)
							{
								uint num4 = 1073741824u;
								for (int num5 = 0; num5 <= k; num5++)
								{
									num4 = Math.Min(num4, this.costs[n * this.pivotCount + num5]);
								}
								GraphNode node2 = fp.pathHandler.GetPathNode(n).node;
								if ((num4 > num2 || num == -1) && node2 != null && !node2.Destroyed && node2.Walkable)
								{
									num = n;
									num2 = num4;
								}
							}
							if (num == -1)
							{
								Debug.LogError("Failed generating random pivot points for heuristic optimizations");
								return;
							}
							this.pivots[k + 1] = fp.pathHandler.GetPathNode(num).node;
						}
						startCostCalculation(k + 1);
					}
					_p.Release(this, false);
				};
				AstarPath.StartPath(fp, true);
			};
			if (this.mode != HeuristicOptimizationMode.RandomSpreadOut)
			{
				for (int l = 0; l < this.pivots.Length; l++)
				{
					startCostCalculation(l);
				}
			}
			else
			{
				startCostCalculation(0);
			}
			this.dirty = false;
		}

		private void ApplyGridGraphEndpointSpecialCase()
		{
			NavGraph[] graphs = AstarPath.active.graphs;
			for (int i = 0; i < graphs.Length; i++)
			{
				GridGraph gridGraph = graphs[i] as GridGraph;
				if (gridGraph != null)
				{
					GridNode[] nodes = gridGraph.nodes;
					int num = (gridGraph.neighbours != NumNeighbours.Four) ? ((gridGraph.neighbours != NumNeighbours.Eight) ? 6 : 8) : 4;
					for (int j = 0; j < gridGraph.depth; j++)
					{
						for (int k = 0; k < gridGraph.width; k++)
						{
							GridNode gridNode = nodes[j * gridGraph.width + k];
							if (!gridNode.Walkable)
							{
								int num2 = gridNode.NodeIndex * this.pivotCount;
								for (int l = 0; l < this.pivotCount; l++)
								{
									this.costs[num2 + l] = 4294967295u;
								}
								for (int m = 0; m < num; m++)
								{
									int num3;
									int num4;
									if (gridGraph.neighbours == NumNeighbours.Six)
									{
										num3 = k + gridGraph.neighbourXOffsets[GridGraph.hexagonNeighbourIndices[m]];
										num4 = j + gridGraph.neighbourZOffsets[GridGraph.hexagonNeighbourIndices[m]];
									}
									else
									{
										num3 = k + gridGraph.neighbourXOffsets[m];
										num4 = j + gridGraph.neighbourZOffsets[m];
									}
									if (num3 >= 0 && num4 >= 0 && num3 < gridGraph.width && num4 < gridGraph.depth)
									{
										GridNode gridNode2 = gridGraph.nodes[num4 * gridGraph.width + num3];
										if (gridNode2.Walkable)
										{
											for (int n = 0; n < this.pivotCount; n++)
											{
												uint val = this.costs[gridNode2.NodeIndex * this.pivotCount + n] + gridGraph.neighbourCosts[m];
												this.costs[num2 + n] = Math.Min(this.costs[num2 + n], val);
												Debug.DrawLine((Vector3)gridNode.position, (Vector3)gridNode2.position, Color.blue, 1f);
											}
										}
									}
								}
								for (int num5 = 0; num5 < this.pivotCount; num5++)
								{
									if (this.costs[num2 + num5] == 4294967295u)
									{
										this.costs[num2 + num5] = 0u;
									}
								}
							}
						}
					}
				}
			}
		}

		public void OnDrawGizmos()
		{
			if (this.pivots != null)
			{
				for (int i = 0; i < this.pivots.Length; i++)
				{
					Gizmos.color = new Color(0.623529434f, 0.368627459f, 0.7607843f, 0.8f);
					if (this.pivots[i] != null && !this.pivots[i].Destroyed)
					{
						Gizmos.DrawCube((Vector3)this.pivots[i].position, Vector3.one);
					}
				}
			}
		}
	}
}
