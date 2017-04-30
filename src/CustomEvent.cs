using System;
using System.Collections.Generic;

public class CustomEvent
{
	public int eventType;

	public Action<List<KeyValuePair<string, object>>> callBack;
}
