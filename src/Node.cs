using System;

public class Node
{
	public int x;

	public int y;

	public float yCoord;

	public float xCoord;

	public float zCoord;

	public int ID;

	public int RID;

	public bool walkable = true;

	public Node parent;

	public Node yNext;

	public bool isOvergo;

	public int F;

	public int H;

	public int G;

	public int sortedIndex = -1;

	public Node(int indexX, int indexY, float height, int idValue, int ridValue, float xcoord, float zcoord, bool w, Node p = null, bool isovergo = false)
	{
		this.x = indexX;
		this.y = indexY;
		this.yCoord = height;
		this.ID = idValue;
		this.RID = ridValue;
		this.xCoord = xcoord;
		this.zCoord = zcoord;
		this.walkable = w;
		this.parent = p;
		this.F = 0;
		this.G = 0;
		this.H = 0;
		this.isOvergo = isovergo;
	}
}
public class Node<K, V>
{
	private K mKey;

	public V Value;

	public Node<K, V> Previous;

	public Node<K, V> Next;

	public K Key
	{
		get
		{
			return this.mKey;
		}
	}

	public Node()
	{
	}

	public Node(K key, V value)
	{
		this.mKey = key;
		this.Value = value;
	}
}
