using System;
using System.Collections.Generic;
using System.Text;

public class LRUCache<K, V>
{
	private int capacityMaxCount;

	private Node<K, V> header;

	private Node<K, V> tail;

	private Dictionary<K, Node<K, V>> cacheDic = new Dictionary<K, Node<K, V>>();

	public Action<Node<K, V>> DestroyAction;

	public int Size
	{
		get
		{
			return this.cacheDic.Count;
		}
	}

	public int Capactity
	{
		get
		{
			return this.capacityMaxCount;
		}
		set
		{
			this.capacityMaxCount = value;
			this.clearCache();
		}
	}

	public bool Full
	{
		get
		{
			return this.cacheDic.Count >= this.capacityMaxCount;
		}
	}

	public LRUCache() : this(10)
	{
	}

	public LRUCache(int capacity)
	{
		this.capacityMaxCount = capacity;
		this.initizalie();
	}

	private void initizalie()
	{
		this.header = new Node<K, V>();
		this.tail = new Node<K, V>();
		this.header.Next = this.tail;
		this.tail.Previous = this.header;
	}

	public Node<K, V> GetNode(K key)
	{
		if (!this.cacheDic.ContainsKey(key))
		{
			return null;
		}
		Node<K, V> node = this.cacheDic[key];
		this.detach(node);
		this.attach(node);
		return node;
	}

	public V GetValue(K key)
	{
		Node<K, V> node = this.GetNode(key);
		return (node != null) ? node.Value : default(V);
	}

	public void Put(K key, V data)
	{
		Node<K, V> node;
		if (!this.cacheDic.ContainsKey(key))
		{
			node = new Node<K, V>(key, data);
			this.cacheDic[key] = node;
		}
		else
		{
			this.detach(this.cacheDic[key]);
		}
		node = this.cacheDic[key];
		this.attach(node);
		this.clearCache();
	}

	private void detach(Node<K, V> node)
	{
		node.Next.Previous = node.Previous;
		node.Previous.Next = node.Next;
	}

	private void attach(Node<K, V> node)
	{
		node.Previous = this.header;
		node.Next = this.header.Next;
		this.header.Next = node;
		node.Next.Previous = node;
	}

	private void clearCache()
	{
		if (this.Size <= this.capacityMaxCount)
		{
			return;
		}
		Node<K, V> previous = this.tail.Previous;
		this.cacheDic.Remove(previous.Key);
		this.detach(previous);
		if (this.DestroyAction != null)
		{
			this.DestroyAction(previous);
		}
		this.clearCache();
	}

	public void RemoveKey(K key)
	{
		if (!this.cacheDic.ContainsKey(key))
		{
			return;
		}
		Node<K, V> node = this.cacheDic[key];
		this.detach(node);
		this.cacheDic.Remove(key);
	}

	public void Destroy()
	{
		foreach (Node<K, V> current in this.cacheDic.Values)
		{
			if (this.DestroyAction != null)
			{
				this.DestroyAction(current);
			}
		}
		this.cacheDic.Clear();
	}

	public void Clear()
	{
		this.cacheDic.Clear();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		Node<K, V> next = this.header.Next;
		while (next != null && next != this.tail)
		{
			stringBuilder.AppendFormat("{0}:{1}\r\n", next.Key, next.Value);
			next = next.Next;
		}
		return stringBuilder.ToString();
	}
}
