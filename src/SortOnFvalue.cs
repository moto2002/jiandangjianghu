using System;
using System.Collections.Generic;

public class SortOnFvalue : IComparer<NodeSearch>
{
	public int Compare(NodeSearch a, NodeSearch b)
	{
		if (a.F > b.F)
		{
			return 1;
		}
		if (a.F < b.F)
		{
			return -1;
		}
		return 0;
	}
}
