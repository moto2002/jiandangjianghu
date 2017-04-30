using System;

public abstract class CSharpSingletion<T> where T : new()
{
	private static T instance;

	public static T Instance
	{
		get
		{
			if (CSharpSingletion<T>.instance == null)
			{
				CSharpSingletion<T>.instance = ((default(T) == null) ? Activator.CreateInstance<T>() : default(T));
			}
			return CSharpSingletion<T>.instance;
		}
	}
}
