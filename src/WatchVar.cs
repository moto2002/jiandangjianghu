using System;

public class WatchVar<T> : WatchVarBase
{
	public T Value
	{
		get
		{
			return (T)((object)this._value);
		}
		set
		{
			this._value = value;
		}
	}

	public WatchVar(string name) : base(name)
	{
	}

	public WatchVar(string name, T val) : base(name, val)
	{
	}
}
