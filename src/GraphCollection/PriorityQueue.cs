using System;
using System.Collections.Generic;

namespace GraphCollection
{
	public class PriorityQueue<T> : IPriorityQueue<T>
	{
		private readonly List<T> _innerList = new List<T>();

		private readonly IComparer<T> _comparer;

		public int Count
		{
			get
			{
				return this._innerList.Count;
			}
		}

		public PriorityQueue(IComparer<T> comparer = null)
		{
			this._comparer = (comparer ?? Comparer<T>.Default);
		}

		public void Push(T item)
		{
			this._innerList.Add(item);
		}

		public T Pop()
		{
			if (this._innerList.Count <= 0)
			{
				return default(T);
			}
			this.Sort();
			T result = this._innerList[0];
			this._innerList.RemoveAt(0);
			return result;
		}

		public bool Contains(T item)
		{
			return this._innerList.Contains(item);
		}

		private void Sort()
		{
			this._innerList.Sort(this._comparer);
		}

		public void Clear()
		{
			this._innerList.Clear();
		}
	}
}
