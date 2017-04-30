using DG.Tweening;
using LuaInterface;
using System;
using UnityEngine;

public class DG_Tweening_TweenWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Tween), typeof(object), null);
		L.RegFunction("PathLength", new LuaCSFunction(DG_Tweening_TweenWrap.PathLength));
		L.RegFunction("PathGetDrawPoints", new LuaCSFunction(DG_Tweening_TweenWrap.PathGetDrawPoints));
		L.RegFunction("PathGetPoint", new LuaCSFunction(DG_Tweening_TweenWrap.PathGetPoint));
		L.RegFunction("Loops", new LuaCSFunction(DG_Tweening_TweenWrap.Loops));
		L.RegFunction("IsPlaying", new LuaCSFunction(DG_Tweening_TweenWrap.IsPlaying));
		L.RegFunction("IsInitialized", new LuaCSFunction(DG_Tweening_TweenWrap.IsInitialized));
		L.RegFunction("IsComplete", new LuaCSFunction(DG_Tweening_TweenWrap.IsComplete));
		L.RegFunction("IsBackwards", new LuaCSFunction(DG_Tweening_TweenWrap.IsBackwards));
		L.RegFunction("IsActive", new LuaCSFunction(DG_Tweening_TweenWrap.IsActive));
		L.RegFunction("ElapsedDirectionalPercentage", new LuaCSFunction(DG_Tweening_TweenWrap.ElapsedDirectionalPercentage));
		L.RegFunction("ElapsedPercentage", new LuaCSFunction(DG_Tweening_TweenWrap.ElapsedPercentage));
		L.RegFunction("Elapsed", new LuaCSFunction(DG_Tweening_TweenWrap.Elapsed));
		L.RegFunction("Duration", new LuaCSFunction(DG_Tweening_TweenWrap.Duration));
		L.RegFunction("Delay", new LuaCSFunction(DG_Tweening_TweenWrap.Delay));
		L.RegFunction("CompletedLoops", new LuaCSFunction(DG_Tweening_TweenWrap.CompletedLoops));
		L.RegFunction("WaitForStart", new LuaCSFunction(DG_Tweening_TweenWrap.WaitForStart));
		L.RegFunction("WaitForPosition", new LuaCSFunction(DG_Tweening_TweenWrap.WaitForPosition));
		L.RegFunction("WaitForElapsedLoops", new LuaCSFunction(DG_Tweening_TweenWrap.WaitForElapsedLoops));
		L.RegFunction("WaitForKill", new LuaCSFunction(DG_Tweening_TweenWrap.WaitForKill));
		L.RegFunction("WaitForRewind", new LuaCSFunction(DG_Tweening_TweenWrap.WaitForRewind));
		L.RegFunction("WaitForCompletion", new LuaCSFunction(DG_Tweening_TweenWrap.WaitForCompletion));
		L.RegFunction("GotoWaypoint", new LuaCSFunction(DG_Tweening_TweenWrap.GotoWaypoint));
		L.RegFunction("TogglePause", new LuaCSFunction(DG_Tweening_TweenWrap.TogglePause));
		L.RegFunction("SmoothRewind", new LuaCSFunction(DG_Tweening_TweenWrap.SmoothRewind));
		L.RegFunction("Rewind", new LuaCSFunction(DG_Tweening_TweenWrap.Rewind));
		L.RegFunction("Restart", new LuaCSFunction(DG_Tweening_TweenWrap.Restart));
		L.RegFunction("PlayForward", new LuaCSFunction(DG_Tweening_TweenWrap.PlayForward));
		L.RegFunction("PlayBackwards", new LuaCSFunction(DG_Tweening_TweenWrap.PlayBackwards));
		L.RegFunction("Play", new LuaCSFunction(DG_Tweening_TweenWrap.Play));
		L.RegFunction("Pause", new LuaCSFunction(DG_Tweening_TweenWrap.Pause));
		L.RegFunction("Kill", new LuaCSFunction(DG_Tweening_TweenWrap.Kill));
		L.RegFunction("Goto", new LuaCSFunction(DG_Tweening_TweenWrap.Goto));
		L.RegFunction("ForceInit", new LuaCSFunction(DG_Tweening_TweenWrap.ForceInit));
		L.RegFunction("Flip", new LuaCSFunction(DG_Tweening_TweenWrap.Flip));
		L.RegFunction("Complete", new LuaCSFunction(DG_Tweening_TweenWrap.Complete));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("timeScale", new LuaCSFunction(DG_Tweening_TweenWrap.get_timeScale), new LuaCSFunction(DG_Tweening_TweenWrap.set_timeScale));
		L.RegVar("isBackwards", new LuaCSFunction(DG_Tweening_TweenWrap.get_isBackwards), new LuaCSFunction(DG_Tweening_TweenWrap.set_isBackwards));
		L.RegVar("id", new LuaCSFunction(DG_Tweening_TweenWrap.get_id), new LuaCSFunction(DG_Tweening_TweenWrap.set_id));
		L.RegVar("target", new LuaCSFunction(DG_Tweening_TweenWrap.get_target), new LuaCSFunction(DG_Tweening_TweenWrap.set_target));
		L.RegVar("easeOvershootOrAmplitude", new LuaCSFunction(DG_Tweening_TweenWrap.get_easeOvershootOrAmplitude), new LuaCSFunction(DG_Tweening_TweenWrap.set_easeOvershootOrAmplitude));
		L.RegVar("easePeriod", new LuaCSFunction(DG_Tweening_TweenWrap.get_easePeriod), new LuaCSFunction(DG_Tweening_TweenWrap.set_easePeriod));
		L.RegVar("fullPosition", new LuaCSFunction(DG_Tweening_TweenWrap.get_fullPosition), new LuaCSFunction(DG_Tweening_TweenWrap.set_fullPosition));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PathLength(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			float num = t.PathLength();
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PathGetDrawPoints(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			int subdivisionsXSegment = (int)LuaDLL.luaL_checknumber(L, 2);
			Vector3[] array = t.PathGetDrawPoints(subdivisionsXSegment);
			ToLua.Push(L, array);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PathGetPoint(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			float pathPercentage = (float)LuaDLL.luaL_checknumber(L, 2);
			Vector3 v = t.PathGetPoint(pathPercentage);
			ToLua.Push(L, v);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Loops(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			int n = t.Loops();
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsPlaying(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			bool value = t.IsPlaying();
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsInitialized(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			bool value = t.IsInitialized();
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsComplete(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			bool value = t.IsComplete();
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsBackwards(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			bool value = t.IsBackwards();
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsActive(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			bool value = t.IsActive();
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ElapsedDirectionalPercentage(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			float num = t.ElapsedDirectionalPercentage();
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ElapsedPercentage(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			bool includeLoops = LuaDLL.luaL_checkboolean(L, 2);
			float num = t.ElapsedPercentage(includeLoops);
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Elapsed(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			bool includeLoops = LuaDLL.luaL_checkboolean(L, 2);
			float num = t.Elapsed(includeLoops);
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Duration(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			bool includeLoops = LuaDLL.luaL_checkboolean(L, 2);
			float num = t.Duration(includeLoops);
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Delay(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			float num = t.Delay();
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CompletedLoops(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			int n = t.CompletedLoops();
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WaitForStart(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			Coroutine o = t.WaitForStart();
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WaitForPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			float position = (float)LuaDLL.luaL_checknumber(L, 2);
			YieldInstruction o = t.WaitForPosition(position);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WaitForElapsedLoops(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			int elapsedLoops = (int)LuaDLL.luaL_checknumber(L, 2);
			YieldInstruction o = t.WaitForElapsedLoops(elapsedLoops);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WaitForKill(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			YieldInstruction o = t.WaitForKill();
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WaitForRewind(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			YieldInstruction o = t.WaitForRewind();
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WaitForCompletion(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			YieldInstruction o = t.WaitForCompletion();
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GotoWaypoint(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			int waypointIndex = (int)LuaDLL.luaL_checknumber(L, 2);
			bool andPlay = LuaDLL.luaL_checkboolean(L, 3);
			t.GotoWaypoint(waypointIndex, andPlay);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TogglePause(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			t.TogglePause();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SmoothRewind(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			t.SmoothRewind();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Rewind(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			bool includeDelay = LuaDLL.luaL_checkboolean(L, 2);
			t.Rewind(includeDelay);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Restart(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			bool includeDelay = LuaDLL.luaL_checkboolean(L, 2);
			t.Restart(includeDelay);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayForward(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			t.PlayForward();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayBackwards(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			t.PlayBackwards();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Play(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			Tween o = t.Play<Tween>();
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Pause(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			Tween o = t.Pause<Tween>();
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Kill(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			bool complete = LuaDLL.luaL_checkboolean(L, 2);
			t.Kill(complete);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Goto(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			float to = (float)LuaDLL.luaL_checknumber(L, 2);
			bool andPlay = LuaDLL.luaL_checkboolean(L, 3);
			t.Goto(to, andPlay);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ForceInit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			t.ForceInit();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Flip(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Tween t = (Tween)ToLua.CheckObject(L, 1, typeof(Tween));
			t.Flip();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Complete(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Tween)))
			{
				Tween t = (Tween)ToLua.ToObject(L, 1);
				t.Complete();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Tween), typeof(bool)))
			{
				Tween t2 = (Tween)ToLua.ToObject(L, 1);
				bool withCallbacks = LuaDLL.lua_toboolean(L, 2);
				t2.Complete(withCallbacks);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.Tween.Complete");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_timeScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Tween tween = (Tween)obj;
			float timeScale = tween.timeScale;
			LuaDLL.lua_pushnumber(L, (double)timeScale);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index timeScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isBackwards(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Tween tween = (Tween)obj;
			bool isBackwards = tween.isBackwards;
			LuaDLL.lua_pushboolean(L, isBackwards);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isBackwards on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_id(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Tween tween = (Tween)obj;
			object id = tween.id;
			ToLua.Push(L, id);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index id on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_target(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Tween tween = (Tween)obj;
			object target = tween.target;
			ToLua.Push(L, target);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index target on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_easeOvershootOrAmplitude(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Tween tween = (Tween)obj;
			float easeOvershootOrAmplitude = tween.easeOvershootOrAmplitude;
			LuaDLL.lua_pushnumber(L, (double)easeOvershootOrAmplitude);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index easeOvershootOrAmplitude on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_easePeriod(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Tween tween = (Tween)obj;
			float easePeriod = tween.easePeriod;
			LuaDLL.lua_pushnumber(L, (double)easePeriod);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index easePeriod on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fullPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Tween tween = (Tween)obj;
			float fullPosition = tween.fullPosition;
			LuaDLL.lua_pushnumber(L, (double)fullPosition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fullPosition on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_timeScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Tween tween = (Tween)obj;
			float timeScale = (float)LuaDLL.luaL_checknumber(L, 2);
			tween.timeScale = timeScale;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index timeScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isBackwards(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Tween tween = (Tween)obj;
			bool isBackwards = LuaDLL.luaL_checkboolean(L, 2);
			tween.isBackwards = isBackwards;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isBackwards on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_id(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Tween tween = (Tween)obj;
			object id = ToLua.ToVarObject(L, 2);
			tween.id = id;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index id on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_target(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Tween tween = (Tween)obj;
			object target = ToLua.ToVarObject(L, 2);
			tween.target = target;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index target on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_easeOvershootOrAmplitude(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Tween tween = (Tween)obj;
			float easeOvershootOrAmplitude = (float)LuaDLL.luaL_checknumber(L, 2);
			tween.easeOvershootOrAmplitude = easeOvershootOrAmplitude;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index easeOvershootOrAmplitude on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_easePeriod(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Tween tween = (Tween)obj;
			float easePeriod = (float)LuaDLL.luaL_checknumber(L, 2);
			tween.easePeriod = easePeriod;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index easePeriod on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fullPosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Tween tween = (Tween)obj;
			float fullPosition = (float)LuaDLL.luaL_checknumber(L, 2);
			tween.fullPosition = fullPosition;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fullPosition on a nil value");
		}
		return result;
	}
}
