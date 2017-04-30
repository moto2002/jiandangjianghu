using DG.Tweening;
using LuaInterface;
using System;
using UnityEngine;

public class DG_Tweening_EaseFactoryWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(EaseFactory), typeof(object), null);
		L.RegFunction("StopMotion", new LuaCSFunction(DG_Tweening_EaseFactoryWrap.StopMotion));
		L.RegFunction("New", new LuaCSFunction(DG_Tweening_EaseFactoryWrap._CreateDG_Tweening_EaseFactory));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateDG_Tweening_EaseFactory(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				EaseFactory o = new EaseFactory();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: DG.Tweening.EaseFactory.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopMotion(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(EaseFunction)))
			{
				int motionFps = (int)LuaDLL.lua_tonumber(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				EaseFunction customEase;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					customEase = (EaseFunction)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					customEase = (DelegateFactory.CreateDelegate(typeof(EaseFunction), func) as EaseFunction);
				}
				EaseFunction ev = EaseFactory.StopMotion(motionFps, customEase);
				ToLua.Push(L, ev);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(AnimationCurve)))
			{
				int motionFps2 = (int)LuaDLL.lua_tonumber(L, 1);
				AnimationCurve animCurve = (AnimationCurve)ToLua.ToObject(L, 2);
				EaseFunction ev2 = EaseFactory.StopMotion(motionFps2, animCurve);
				ToLua.Push(L, ev2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(Ease?)))
			{
				int motionFps3 = (int)LuaDLL.lua_tonumber(L, 1);
				Ease? ease = (Ease?)ToLua.ToObject(L, 2);
				EaseFunction ev3 = EaseFactory.StopMotion(motionFps3, ease);
				ToLua.Push(L, ev3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.EaseFactory.StopMotion");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
