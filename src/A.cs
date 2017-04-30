using System;

internal class A
{
	public static int X;

	static A()
	{
		A.X = B.Y + 1;
	}
}
