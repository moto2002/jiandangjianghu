using System;

public abstract class WatchVarBase
{
	protected object _value;

	public string Name
	{
		get;
		private set;
	}

	public object ObjValue
	{
		get
		{
			return this._value;
		}
	}

	public WatchVarBase(string name, object val) : this(name)
	{
		this._value = val;
	}

	public WatchVarBase(string name)
	{
		this.Name = name;
		this.Register();
	}

	public void Register()
	{
		DebugConsole.RegisterWatchVar(this);
	}

	public void UnRegister()
	{
		DebugConsole.UnRegisterWatchVar(this.Name);
	}

	public override string ToString()
	{
		if (this._value == null)
		{
			return "<null>";
		}
		return this._value.ToString();
	}
}
