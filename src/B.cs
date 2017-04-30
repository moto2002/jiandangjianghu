using System;
using UnityEngine;

internal class B
{
	public static int Y;

	static B()
	{
		B.Y = A.X + 1;
	}

	public static void Main()
	{
		Debug.Log("==================");
		Debug.Log(string.Format("X={0}, Y={1}", A.X, B.Y));
	}
}
