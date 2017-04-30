using System;
using System.Collections;
using UnityEngine;

namespace LuaFramework
{
	public abstract class ALoadOperation : IEnumerator
	{
		public object Current
		{
			get
			{
				return null;
			}
		}

		public bool MoveNext()
		{
			return !this.IsDone();
		}

		public virtual void Reset()
		{
		}

		public abstract bool IsDone();

		public abstract T GetAsset<T>() where T : UnityEngine.Object;
	}
}
