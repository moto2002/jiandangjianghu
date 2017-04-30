using System;
using System.Collections.Generic;
using UnityEngine;

public class QueuePath
{
	public Vector3 startPos;

	public Vector3 endPos;

	public Action<List<Vector3>> storeRef;

	public QueuePath(Vector3 sPos, Vector3 ePos, Action<List<Vector3>> theRefMethod)
	{
		this.startPos = sPos;
		this.endPos = ePos;
		this.storeRef = theRefMethod;
	}
}
