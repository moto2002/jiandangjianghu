using LuaInterface;
using System;
using UnityEngine;

public class TestInstantiate2 : MonoBehaviour
{
	private void Awake()
	{
		try
		{
			throw new Exception("Instantiate exception 2");
		}
		catch (Exception e)
		{
			LuaState luaState = LuaState.Get(IntPtr.Zero);
			luaState.ThrowLuaException(e);
		}
	}
}
