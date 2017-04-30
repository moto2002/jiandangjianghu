using System;

public class CacheDestroy<K, V>
{
	public virtual bool CanDestroy(Node<K, V> node)
	{
		return true;
	}

	public virtual void DestroyNode(Node<K, V> node)
	{
	}
}
