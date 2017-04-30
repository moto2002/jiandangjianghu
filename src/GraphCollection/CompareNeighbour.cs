using System;
using System.Collections.Generic;

namespace GraphCollection
{
	internal class CompareNeighbour<T> : IComparer<GraphNode<T>>
	{
		public int Compare(GraphNode<T> x, GraphNode<T> y)
		{
			if (x.TentativeDistance > y.TentativeDistance)
			{
				return 1;
			}
			if (x.TentativeDistance < y.TentativeDistance)
			{
				return -1;
			}
			return 0;
		}
	}
}
