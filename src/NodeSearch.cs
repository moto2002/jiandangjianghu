using System;

public class NodeSearch : IComparable<NodeSearch>
{
	private int rid;

	public int F;

	public float Fv;

	public int RID
	{
		get
		{
			return this.rid;
		}
		private set
		{
			this.rid = value;
		}
	}

	public NodeSearch(int i, int f)
	{
		this.rid = i;
		this.F = f;
	}

	public NodeSearch(int i, float f)
	{
		this.rid = i;
		this.Fv = f;
	}

	public int CompareTo(NodeSearch b)
	{
		return this.F.CompareTo(b.F);
	}
}
