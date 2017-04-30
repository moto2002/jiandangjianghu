using System;
using System.Collections.Generic;

namespace GraphCollection
{
	public class GraphNode<T>
	{
		public struct Neighbour
		{
			public int Distance;

			public GraphNode<T> GraphNode;

			public Neighbour(GraphNode<T> graphNode, int distance)
			{
				this.GraphNode = graphNode;
				this.Distance = distance;
			}
		}

		public readonly List<GraphNode<T>.Neighbour> Neighbours;

		public bool Visited;

		public T Value;

		public int TentativeDistance;

		public GraphNode(T value)
		{
			this.Value = value;
			this.Neighbours = new List<GraphNode<T>.Neighbour>();
		}

		public void AddNeighbour(GraphNode<T> graphNode, int distance)
		{
			for (int i = 0; i < this.Neighbours.Count; i++)
			{
				if (this.Neighbours[i].GraphNode.Equals(graphNode))
				{
					return;
				}
			}
			this.Neighbours.Add(new GraphNode<T>.Neighbour(graphNode, distance));
			graphNode.Neighbours.Add(new GraphNode<T>.Neighbour(this, distance));
		}

		public bool Equals(GraphNode<T> compareNode)
		{
			return this.Value.Equals(compareNode.Value);
		}
	}
}
