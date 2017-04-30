using System;
using System.Text;

public class ARCCache<K, V>
{
	private LRUCache<K, V> ruCache;

	private LRUCache<K, V> ruGhostCache;

	private LFUCache<K, V> fuCache;

	private LFUCache<K, V> fuGhostCache;

	private int initCapactity;

	public Action<Node<K, V>> DestroyCallback;

	public int Size
	{
		get
		{
			return this.ruCache.Size + this.fuCache.Size;
		}
	}

	public ARCCache(int initCacheCount)
	{
		this.initCapactity = initCacheCount;
		this.ruCache = new LRUCache<K, V>(initCacheCount);
		this.ruCache.DestroyAction = new Action<Node<K, V>>(this.addGhostLRUCache);
		this.ruGhostCache = new LRUCache<K, V>(initCacheCount);
		this.ruGhostCache.DestroyAction = this.DestroyCallback;
		this.fuCache = new LFUCache<K, V>(initCacheCount);
		this.fuCache.DestroyAction = new Action<Node<K, V>>(this.addGhostLFUCache);
		this.fuGhostCache = new LFUCache<K, V>(initCacheCount);
		this.fuGhostCache.DestroyAction = this.DestroyCallback;
	}

	public V Get(K key)
	{
		Node<K, V> node = this.fuCache.GetNode(key);
		if (node != null)
		{
			return node.Value;
		}
		node = this.ruCache.GetNode(key);
		if (node != null)
		{
			this.ruCache.RemoveKey(key);
			this.fuCache.Put(key, node.Value, 1);
			return node.Value;
		}
		return default(V);
	}

	public void Put(K key, V value)
	{
		Node<K, V> node = this.ruCache.GetNode(key);
		if (node != null)
		{
			this.ruCache.RemoveKey(key);
			this.fuCache.Put(key, value, 1);
			return;
		}
		node = this.fuCache.GetNode(key);
		if (node != null)
		{
			return;
		}
		int num = this.initCapactity + this.initCapactity / 2;
		node = this.ruGhostCache.GetNode(key);
		if (node != null)
		{
			if (this.ruCache.Full && this.ruCache.Capactity < num)
			{
				this.ruCache.Capactity++;
				this.fuCache.CapacityMax--;
			}
			this.ruCache.Put(key, value);
			this.ruGhostCache.RemoveKey(key);
			return;
		}
		node = this.fuGhostCache.GetNode(key);
		if (node != null)
		{
			if (this.fuCache.Full && this.fuCache.CapacityMax < num)
			{
				this.fuCache.CapacityMax++;
				this.ruCache.Capactity--;
			}
			LFUNode<K, V> lFUNode = node as LFUNode<K, V>;
			this.fuCache.Put(key, value, lFUNode.RefCount);
			this.fuGhostCache.RemoveKey(key);
			return;
		}
		this.ruCache.Put(key, value);
	}

	private void addGhostLRUCache(Node<K, V> node)
	{
		this.ruGhostCache.Put(node.Key, node.Value);
		if (this.DestroyCallback != null)
		{
			this.DestroyCallback(node);
		}
	}

	private void addGhostLFUCache(Node<K, V> node)
	{
		LFUNode<K, V> lFUNode = node as LFUNode<K, V>;
		this.fuGhostCache.Put(node.Key, node.Value, lFUNode.RefCount);
		if (this.DestroyCallback != null)
		{
			this.DestroyCallback(node);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(this.ruCache.ToString());
		stringBuilder.AppendLine(this.fuCache.ToString());
		return stringBuilder.ToString();
	}
}
