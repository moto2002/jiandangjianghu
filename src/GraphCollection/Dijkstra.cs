using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphCollection
{
	public class Dijkstra<T>
	{
		private readonly List<GraphNode<T>> _graph;

		private IPriorityQueue<GraphNode<T>> _unvistedNodes;

		public Dijkstra(IEnumerable<GraphNode<T>> graph)
		{
			this._graph = graph.ToList<GraphNode<T>>();
		}

		public IList<GraphNode<T>> FindShortestPathBetween(GraphNode<T> start, GraphNode<T> finish)
		{
			this.PrepareGraphForDijkstra();
			start.TentativeDistance = 0;
			GraphNode<T> graphNode = start;
			while (true)
			{
				foreach (GraphNode<T>.Neighbour current in from x in graphNode.Neighbours
				where !x.GraphNode.Visited
				select x)
				{
					int num = graphNode.TentativeDistance + current.Distance;
					if (num < current.GraphNode.TentativeDistance)
					{
						current.GraphNode.TentativeDistance = num;
					}
				}
				graphNode.Visited = true;
				GraphNode<T> graphNode2 = this._unvistedNodes.Pop();
				if (graphNode2 == null || graphNode2.TentativeDistance == 2147483647)
				{
					break;
				}
				GraphNode<T> graphNode3 = graphNode2;
				graphNode = graphNode3;
			}
			if (finish.TentativeDistance == 2147483647)
			{
				return new List<GraphNode<T>>();
			}
			finish.Visited = true;
			return Dijkstra<T>.DeterminePathFromWeightedGraph(start, finish);
		}

		private static List<GraphNode<T>> DeterminePathFromWeightedGraph(GraphNode<T> start, GraphNode<T> finish)
		{
			GraphNode<T> graphNode = finish;
			List<GraphNode<T>> list = new List<GraphNode<T>>
			{
				graphNode
			};
			int num = finish.TentativeDistance;
			while (graphNode != start)
			{
				foreach (GraphNode<T>.Neighbour current in from x in graphNode.Neighbours
				where x.GraphNode.Visited
				select x)
				{
					if (num - current.Distance == current.GraphNode.TentativeDistance)
					{
						graphNode = current.GraphNode;
						list.Add(graphNode);
						num -= current.Distance;
						break;
					}
				}
			}
			list.Reverse();
			return list;
		}

		private void PrepareGraphForDijkstra()
		{
			this._unvistedNodes = new PriorityQueue<GraphNode<T>>(new CompareNeighbour<T>());
			this._graph.ForEach(delegate(GraphNode<T> x)
			{
				x.Visited = false;
				x.TentativeDistance = 2147483647;
				this._unvistedNodes.Push(x);
			});
		}

		public void Clear()
		{
			if (this._graph != null)
			{
				this._graph.Clear();
			}
			if (this._unvistedNodes != null)
			{
				this._unvistedNodes.Clear();
			}
		}
	}
}
