using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ThirdParty
{
	public class ObservableDictionary<TKey, TValue> : IEnumerable, IEnumerable<KeyValuePair<TKey, TValue>>
	{
		private Dictionary<TKey, TValue> m_data = new Dictionary<TKey, TValue>();

		public event EventHandler<EventArgs<KeyValuePair<TKey, TValue>>> ItemAdd
		{
			[MethodImpl(32)]
			add
			{
				this.ItemAdd = (EventHandler<EventArgs<KeyValuePair<TKey, TValue>>>)Delegate.Combine(this.ItemAdd, value);
			}
			[MethodImpl(32)]
			remove
			{
				this.ItemAdd = (EventHandler<EventArgs<KeyValuePair<TKey, TValue>>>)Delegate.Remove(this.ItemAdd, value);
			}
		}

		public event EventHandler<EventArgs<KeyValuePair<TKey, TValue>>> ItemRemove
		{
			[MethodImpl(32)]
			add
			{
				this.ItemRemove = (EventHandler<EventArgs<KeyValuePair<TKey, TValue>>>)Delegate.Combine(this.ItemRemove, value);
			}
			[MethodImpl(32)]
			remove
			{
				this.ItemRemove = (EventHandler<EventArgs<KeyValuePair<TKey, TValue>>>)Delegate.Remove(this.ItemRemove, value);
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				TValue result;
				if (this.m_data.TryGetValue(key, out result))
				{
					return result;
				}
				return default(TValue);
			}
			set
			{
				bool flag = this.m_data.ContainsKey(key);
				this.m_data[key] = value;
				if (!flag)
				{
					this.OnItemAdd(key, value);
				}
			}
		}

		public Dictionary<TKey, TValue>.KeyCollection Keys
		{
			get
			{
				return this.m_data.Keys;
			}
		}

		public Dictionary<TKey, TValue>.ValueCollection Values
		{
			get
			{
				return this.m_data.Values;
			}
		}

		public int Count
		{
			get
			{
				return this.m_data.Count;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return this.m_data.TryGetValue(key, out value);
		}

		public void Clear()
		{
			Dictionary<TKey, TValue> data = this.m_data;
			this.m_data = new Dictionary<TKey, TValue>();
			foreach (KeyValuePair<TKey, TValue> current in data)
			{
				this.OnItemRemove(current.Key, current.Value);
			}
		}

		public bool ContainsKey(TKey key)
		{
			return this.m_data.ContainsKey(key);
		}

		public bool Remove(TKey key)
		{
			if (!this.m_data.ContainsKey(key))
			{
				return false;
			}
			TValue value = this.m_data[key];
			this.m_data.Remove(key);
			this.OnItemRemove(key, value);
			return true;
		}

		private void OnItemAdd(TKey key, TValue value)
		{
			if (this.ItemAdd != null)
			{
				this.ItemAdd(this, new EventArgs<KeyValuePair<TKey, TValue>>
				{
					Data = new KeyValuePair<TKey, TValue>(key, value)
				});
			}
		}

		private void OnItemRemove(TKey key, TValue value)
		{
			if (this.ItemRemove != null)
			{
				this.ItemRemove(this, new EventArgs<KeyValuePair<TKey, TValue>>
				{
					Data = new KeyValuePair<TKey, TValue>(key, value)
				});
			}
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return this.m_data.GetEnumerator();
		}
	}
}
