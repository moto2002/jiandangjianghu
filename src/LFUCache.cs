using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LFUCache<K, V>
{
	private int capacityMax;

	private Dictionary<K, LFUNode<K, V>> linked = new Dictionary<K, LFUNode<K, V>>();

	public Action<Node<K, V>> DestroyAction;

	private CacheDestroy<K, V> mDestroy;

	public V this[K key]
	{
		get
		{
			return this.GetValue(key);
		}
	}

	public int Size
	{
		get
		{
			return this.linked.Count;
		}
	}

	public int CapacityMax
	{
		get
		{
			return this.capacityMax;
		}
		set
		{
			this.capacityMax = value;
			LFUNode<K, V>[] array = new LFUNode<K, V>[this.linked.Count];
			this.linked.Values.CopyTo(array, 0);
			Array.Sort<LFUNode<K, V>>(array);
			List<LFUNode<K, V>> list = new List<LFUNode<K, V>>();
			list.AddRange(array);
			this.releaseMax(list);
		}
	}

	public bool Full
	{
		get
		{
			return this.linked.Count >= this.capacityMax;
		}
	}

	public LFUCache(int max)
	{
		this.capacityMax = max;
	}

	public void SetDestroyStrategy(CacheDestroy<K, V> cacheDestroy)
	{
		this.mDestroy = cacheDestroy;
	}

	public void Put(K key, V value, int refCount = 1)
	{
		LFUNode<K, V> lFUNode;
		if (!this.linked.ContainsKey(key))
		{
			lFUNode = new LFUNode<K, V>(key, value);
			this.linked.Add(key, lFUNode);
		}
		lFUNode = this.linked[key];
		lFUNode.Value = value;
		lFUNode.UserTime = DateTime.UtcNow;
		lFUNode.RefCount += refCount;
		if (this.linked.Count > this.capacityMax)
		{
			this.release(lFUNode);
		}
	}

	public Node<K, V> GetNode(K key)
	{
		if (!this.linked.ContainsKey(key))
		{
			return null;
		}
		this.Put(key, this.linked[key].Value, 1);
		return this.linked[key];
	}

	public V GetValue(K key)
	{
		Node<K, V> node = this.GetNode(key);
		return (node != null) ? node.Value : default(V);
	}

	public V Peek(K key)
	{
		Node<K, V> node = null;
		if (this.linked.ContainsKey(key))
		{
			node = this.linked[key];
		}
		return (node != null) ? node.Value : default(V);
	}

	public bool ContainsKey(K key)
	{
		return this.linked.ContainsKey(key);
	}

	private void release(LFUNode<K, V> lastNode)
	{
		LFUNode<K, V>[] array = new LFUNode<K, V>[this.linked.Count];
		this.linked.Values.CopyTo(array, 0);
		Array.Sort<LFUNode<K, V>>(array);
		for (int i = array.Length - 1; i >= 0; i--)
		{
			if (array[i] != lastNode)
			{
				if (this.mDestroy == null)
				{
					this.linked.Remove(array[i].Key);
					if (this.DestroyAction != null)
					{
						this.DestroyAction(array[i]);
					}
					break;
				}
				bool flag = this.mDestroy.CanDestroy(array[i]);
				if (flag)
				{
					this.linked.Remove(array[i].Key);
					this.mDestroy.DestroyNode(array[i]);
					break;
				}
			}
		}
	}

	private void releaseMax(List<LFUNode<K, V>> nodeArr)
	{
		if (this.Size <= this.capacityMax)
		{
			return;
		}
		LFUNode<K, V> lFUNode = nodeArr[nodeArr.Count - 1];
		this.linked.Remove(lFUNode.Key);
		nodeArr.RemoveAt(nodeArr.Count - 1);
		if (this.DestroyAction != null)
		{
			this.DestroyAction(lFUNode);
		}
		this.releaseMax(nodeArr);
	}

	public void RemoveKey(K key)
	{
		if (!this.linked.ContainsKey(key))
		{
			return;
		}
		this.linked.Remove(key);
	}

	public void Destroy()
	{
		foreach (LFUNode<K, V> current in this.linked.Values)
		{
			if (this.DestroyAction != null)
			{
				this.DestroyAction(current);
			}
		}
		this.linked.Clear();
	}

	public void Clear()
	{
		this.linked.Clear();
	}

	public IEnumerator GetEnumerator()
	{
		return this.linked.GetEnumerator();
	}

	public override string ToString()
	{
		LFUNode<K, V>[] array = new LFUNode<K, V>[this.linked.Count];
		this.linked.Values.CopyTo(array, 0);
		Array.Sort<LFUNode<K, V>>(array);
		StringBuilder stringBuilder = new StringBuilder();
		LFUNode<K, V>[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			LFUNode<K, V> lFUNode = array2[i];
			stringBuilder.AppendFormat("refCount:{1} , dataTime : {2} key :{0} / {3}\r\n", new object[]
			{
				lFUNode.Key,
				lFUNode.RefCount,
				lFUNode.UserTime.Millisecond,
				lFUNode.Value
			});
		}
		return stringBuilder.ToString();
	}
}
