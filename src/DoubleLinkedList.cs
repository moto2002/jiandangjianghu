using System;
using System.Collections.Generic;

public class DoubleLinkedList<K, V>
{
	private Node<K, V> mHead;

	private Node<K, V> mTail;

	private Dictionary<K, Node<K, V>> linkedLog = new Dictionary<K, Node<K, V>>();

	public Node<K, V> this[K key]
	{
		get
		{
			if (!this.linkedLog.ContainsKey(key))
			{
				return null;
			}
			return this.linkedLog[key];
		}
	}

	public int Size
	{
		get
		{
			return this.linkedLog.Count;
		}
	}

	public DoubleLinkedList()
	{
		this.mHead = new Node<K, V>();
		this.mTail = new Node<K, V>();
		this.mHead.Next = this.mTail;
		this.mHead.Next.Previous = this.mHead;
	}

	public void AddTail(Node<K, V> node)
	{
		if (this.linkedLog.ContainsKey(node.Key))
		{
			this.detach(node);
		}
		this.linkedLog[node.Key] = node;
		node.Next = this.mTail;
		node.Previous = this.mTail.Previous;
		this.mTail.Previous = node;
		node.Previous.Next = node;
	}

	public void AddHead(Node<K, V> node)
	{
		if (this.linkedLog.ContainsKey(node.Key))
		{
			this.detach(node);
		}
		this.linkedLog[node.Key] = node;
		node.Previous = this.mHead;
		node.Next = this.mHead.Next;
		this.mHead.Next = node;
		node.Next.Previous = node;
	}

	private void detach(Node<K, V> node)
	{
		if (node == null)
		{
			return;
		}
		node.Next.Previous = node.Previous;
		node.Previous.Next = node.Next;
	}

	public void RemoveKey(K key)
	{
		if (!this.linkedLog.ContainsKey(key))
		{
			return;
		}
		Node<K, V> node = this.linkedLog[key];
		this.detach(node);
	}

	public void RemoveNode(Node<K, V> node)
	{
		if (node == null)
		{
			return;
		}
		this.RemoveKey(node.Key);
	}
}
