using LuaInterface;
using System;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
	private void Awake()
	{
		LuaState luaState = new LuaState();
		luaState.Start();
		string chunk = "                \r\n                print('hello tolua#')                                  \r\n            ";
		luaState.DoString(chunk, "HelloWorld.cs");
		luaState.CheckTop();
		luaState.Dispose();
	}
}
