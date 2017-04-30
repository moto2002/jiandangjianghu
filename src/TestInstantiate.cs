using LuaInterface;
using System;
using UnityEngine;

public class TestInstantiate : MonoBehaviour
{
	private void Awake()
	{
		LuaState luaState = LuaState.Get(IntPtr.Zero);
		try
		{
			LuaFunction function = luaState.GetFunction("Show", true);
			function.BeginPCall();
			function.PCall();
			function.EndPCall();
			function.Dispose();
		}
		catch (Exception e)
		{
			luaState.ThrowLuaException(e);
		}
	}

	private void Start()
	{
		Debugger.Log("start");
	}
}
