using System;

public class NotiData
{
	public string evName;

	public object evParam;

	public object extParam;

	public NotiData(string name, object param, object extParam = null)
	{
		this.evName = name;
		this.evParam = param;
		this.extParam = extParam;
	}
}
