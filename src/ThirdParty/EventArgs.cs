using System;

namespace ThirdParty
{
	public class EventArgs<T> : EventArgs
	{
		public T Data
		{
			get;
			set;
		}
	}
}
