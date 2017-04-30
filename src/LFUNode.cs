using System;

public class LFUNode<K, V> : Node<K, V>, IComparable
{
	public int RefCount;

	public DateTime UserTime;

	public LFUNode(K key, V value) : base(key, value)
	{
	}

	public int CompareTo(object other)
	{
		LFUNode<K, V> lFUNode = other as LFUNode<K, V>;
		if (this.RefCount != lFUNode.RefCount)
		{
			return -this.RefCount.CompareTo(lFUNode.RefCount);
		}
		TimeSpan timeSpan = this.UserTime.Subtract(lFUNode.UserTime);
		if (timeSpan.Milliseconds == 0)
		{
			return 0;
		}
		return (timeSpan.Milliseconds <= 0) ? 1 : -1;
	}
}
