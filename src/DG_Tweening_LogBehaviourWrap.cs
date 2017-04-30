using DG.Tweening;
using LuaInterface;
using System;

public class DG_Tweening_LogBehaviourWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(LogBehaviour));
		L.RegVar("Default", new LuaCSFunction(DG_Tweening_LogBehaviourWrap.get_Default), null);
		L.RegVar("Verbose", new LuaCSFunction(DG_Tweening_LogBehaviourWrap.get_Verbose), null);
		L.RegVar("ErrorsOnly", new LuaCSFunction(DG_Tweening_LogBehaviourWrap.get_ErrorsOnly), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(DG_Tweening_LogBehaviourWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Default(IntPtr L)
	{
		ToLua.Push(L, LogBehaviour.Default);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Verbose(IntPtr L)
	{
		ToLua.Push(L, LogBehaviour.Verbose);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ErrorsOnly(IntPtr L)
	{
		ToLua.Push(L, LogBehaviour.ErrorsOnly);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		LogBehaviour logBehaviour = (LogBehaviour)num;
		ToLua.Push(L, logBehaviour);
		return 1;
	}
}
