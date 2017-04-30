using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DG_Tweening_DOTweenWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(DOTween), typeof(object), null);
		L.RegFunction("Init", new LuaCSFunction(DG_Tweening_DOTweenWrap.Init));
		L.RegFunction("SetTweensCapacity", new LuaCSFunction(DG_Tweening_DOTweenWrap.SetTweensCapacity));
		L.RegFunction("Clear", new LuaCSFunction(DG_Tweening_DOTweenWrap.Clear));
		L.RegFunction("ClearCachedTweens", new LuaCSFunction(DG_Tweening_DOTweenWrap.ClearCachedTweens));
		L.RegFunction("Validate", new LuaCSFunction(DG_Tweening_DOTweenWrap.Validate));
		L.RegFunction("To", new LuaCSFunction(DG_Tweening_DOTweenWrap.To));
		L.RegFunction("ToAxis", new LuaCSFunction(DG_Tweening_DOTweenWrap.ToAxis));
		L.RegFunction("ToAlpha", new LuaCSFunction(DG_Tweening_DOTweenWrap.ToAlpha));
		L.RegFunction("Punch", new LuaCSFunction(DG_Tweening_DOTweenWrap.Punch));
		L.RegFunction("Shake", new LuaCSFunction(DG_Tweening_DOTweenWrap.Shake));
		L.RegFunction("ToArray", new LuaCSFunction(DG_Tweening_DOTweenWrap.ToArray));
		L.RegFunction("Sequence", new LuaCSFunction(DG_Tweening_DOTweenWrap.Sequence));
		L.RegFunction("CompleteAll", new LuaCSFunction(DG_Tweening_DOTweenWrap.CompleteAll));
		L.RegFunction("Complete", new LuaCSFunction(DG_Tweening_DOTweenWrap.Complete));
		L.RegFunction("FlipAll", new LuaCSFunction(DG_Tweening_DOTweenWrap.FlipAll));
		L.RegFunction("Flip", new LuaCSFunction(DG_Tweening_DOTweenWrap.Flip));
		L.RegFunction("GotoAll", new LuaCSFunction(DG_Tweening_DOTweenWrap.GotoAll));
		L.RegFunction("Goto", new LuaCSFunction(DG_Tweening_DOTweenWrap.Goto));
		L.RegFunction("KillAll", new LuaCSFunction(DG_Tweening_DOTweenWrap.KillAll));
		L.RegFunction("Kill", new LuaCSFunction(DG_Tweening_DOTweenWrap.Kill));
		L.RegFunction("PauseAll", new LuaCSFunction(DG_Tweening_DOTweenWrap.PauseAll));
		L.RegFunction("Pause", new LuaCSFunction(DG_Tweening_DOTweenWrap.Pause));
		L.RegFunction("PlayAll", new LuaCSFunction(DG_Tweening_DOTweenWrap.PlayAll));
		L.RegFunction("Play", new LuaCSFunction(DG_Tweening_DOTweenWrap.Play));
		L.RegFunction("PlayBackwardsAll", new LuaCSFunction(DG_Tweening_DOTweenWrap.PlayBackwardsAll));
		L.RegFunction("PlayBackwards", new LuaCSFunction(DG_Tweening_DOTweenWrap.PlayBackwards));
		L.RegFunction("PlayForwardAll", new LuaCSFunction(DG_Tweening_DOTweenWrap.PlayForwardAll));
		L.RegFunction("PlayForward", new LuaCSFunction(DG_Tweening_DOTweenWrap.PlayForward));
		L.RegFunction("RestartAll", new LuaCSFunction(DG_Tweening_DOTweenWrap.RestartAll));
		L.RegFunction("Restart", new LuaCSFunction(DG_Tweening_DOTweenWrap.Restart));
		L.RegFunction("RewindAll", new LuaCSFunction(DG_Tweening_DOTweenWrap.RewindAll));
		L.RegFunction("Rewind", new LuaCSFunction(DG_Tweening_DOTweenWrap.Rewind));
		L.RegFunction("SmoothRewindAll", new LuaCSFunction(DG_Tweening_DOTweenWrap.SmoothRewindAll));
		L.RegFunction("SmoothRewind", new LuaCSFunction(DG_Tweening_DOTweenWrap.SmoothRewind));
		L.RegFunction("TogglePauseAll", new LuaCSFunction(DG_Tweening_DOTweenWrap.TogglePauseAll));
		L.RegFunction("TogglePause", new LuaCSFunction(DG_Tweening_DOTweenWrap.TogglePause));
		L.RegFunction("IsTweening", new LuaCSFunction(DG_Tweening_DOTweenWrap.IsTweening));
		L.RegFunction("TotalPlayingTweens", new LuaCSFunction(DG_Tweening_DOTweenWrap.TotalPlayingTweens));
		L.RegFunction("PlayingTweens", new LuaCSFunction(DG_Tweening_DOTweenWrap.PlayingTweens));
		L.RegFunction("PausedTweens", new LuaCSFunction(DG_Tweening_DOTweenWrap.PausedTweens));
		L.RegFunction("TweensById", new LuaCSFunction(DG_Tweening_DOTweenWrap.TweensById));
		L.RegFunction("TweensByTarget", new LuaCSFunction(DG_Tweening_DOTweenWrap.TweensByTarget));
		L.RegFunction("New", new LuaCSFunction(DG_Tweening_DOTweenWrap._CreateDG_Tweening_DOTween));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Version", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_Version), null);
		L.RegVar("useSafeMode", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_useSafeMode), new LuaCSFunction(DG_Tweening_DOTweenWrap.set_useSafeMode));
		L.RegVar("showUnityEditorReport", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_showUnityEditorReport), new LuaCSFunction(DG_Tweening_DOTweenWrap.set_showUnityEditorReport));
		L.RegVar("timeScale", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_timeScale), new LuaCSFunction(DG_Tweening_DOTweenWrap.set_timeScale));
		L.RegVar("useSmoothDeltaTime", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_useSmoothDeltaTime), new LuaCSFunction(DG_Tweening_DOTweenWrap.set_useSmoothDeltaTime));
		L.RegVar("drawGizmos", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_drawGizmos), new LuaCSFunction(DG_Tweening_DOTweenWrap.set_drawGizmos));
		L.RegVar("defaultUpdateType", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_defaultUpdateType), new LuaCSFunction(DG_Tweening_DOTweenWrap.set_defaultUpdateType));
		L.RegVar("defaultTimeScaleIndependent", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_defaultTimeScaleIndependent), new LuaCSFunction(DG_Tweening_DOTweenWrap.set_defaultTimeScaleIndependent));
		L.RegVar("defaultAutoPlay", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_defaultAutoPlay), new LuaCSFunction(DG_Tweening_DOTweenWrap.set_defaultAutoPlay));
		L.RegVar("defaultAutoKill", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_defaultAutoKill), new LuaCSFunction(DG_Tweening_DOTweenWrap.set_defaultAutoKill));
		L.RegVar("defaultLoopType", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_defaultLoopType), new LuaCSFunction(DG_Tweening_DOTweenWrap.set_defaultLoopType));
		L.RegVar("defaultRecyclable", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_defaultRecyclable), new LuaCSFunction(DG_Tweening_DOTweenWrap.set_defaultRecyclable));
		L.RegVar("defaultEaseType", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_defaultEaseType), new LuaCSFunction(DG_Tweening_DOTweenWrap.set_defaultEaseType));
		L.RegVar("defaultEaseOvershootOrAmplitude", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_defaultEaseOvershootOrAmplitude), new LuaCSFunction(DG_Tweening_DOTweenWrap.set_defaultEaseOvershootOrAmplitude));
		L.RegVar("defaultEasePeriod", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_defaultEasePeriod), new LuaCSFunction(DG_Tweening_DOTweenWrap.set_defaultEasePeriod));
		L.RegVar("logBehaviour", new LuaCSFunction(DG_Tweening_DOTweenWrap.get_logBehaviour), new LuaCSFunction(DG_Tweening_DOTweenWrap.set_logBehaviour));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateDG_Tweening_DOTween(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				DOTween o = new DOTween();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: DG.Tweening.DOTween.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Init(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			bool? recycleAllByDefault = (bool?)ToLua.CheckVarObject(L, 1, typeof(bool?));
			bool? useSafeMode = (bool?)ToLua.CheckVarObject(L, 2, typeof(bool?));
			LogBehaviour? logBehaviour = (LogBehaviour?)ToLua.CheckVarObject(L, 3, typeof(LogBehaviour?));
			IDOTweenInit o = DOTween.Init(recycleAllByDefault, useSafeMode, logBehaviour);
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
	private static int SetTweensCapacity(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			int tweenersCapacity = (int)LuaDLL.luaL_checknumber(L, 1);
			int sequencesCapacity = (int)LuaDLL.luaL_checknumber(L, 2);
			DOTween.SetTweensCapacity(tweenersCapacity, sequencesCapacity);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			bool destroy = LuaDLL.luaL_checkboolean(L, 1);
			DOTween.Clear(destroy);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearCachedTweens(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			DOTween.ClearCachedTweens();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Validate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			int n = DOTween.Validate();
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
	private static int To(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<Quaternion>), typeof(DOSetter<Quaternion>), typeof(Vector3), typeof(float)))
			{
				LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
				DOGetter<Quaternion> getter;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					getter = (DOGetter<Quaternion>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 1);
					getter = (DelegateFactory.CreateDelegate(typeof(DOGetter<Quaternion>), func) as DOGetter<Quaternion>);
				}
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 2);
				DOSetter<Quaternion> setter;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					setter = (DOSetter<Quaternion>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 2);
					setter = (DelegateFactory.CreateDelegate(typeof(DOSetter<Quaternion>), func2) as DOSetter<Quaternion>);
				}
				Vector3 endValue = ToLua.ToVector3(L, 3);
				float duration = (float)LuaDLL.lua_tonumber(L, 4);
				TweenerCore<Quaternion, Vector3, QuaternionOptions> o = DOTween.To(getter, setter, endValue, duration);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<Vector4>), typeof(DOSetter<Vector4>), typeof(Vector4), typeof(float)))
			{
				LuaTypes luaTypes3 = LuaDLL.lua_type(L, 1);
				DOGetter<Vector4> getter2;
				if (luaTypes3 != LuaTypes.LUA_TFUNCTION)
				{
					getter2 = (DOGetter<Vector4>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func3 = ToLua.ToLuaFunction(L, 1);
					getter2 = (DelegateFactory.CreateDelegate(typeof(DOGetter<Vector4>), func3) as DOGetter<Vector4>);
				}
				LuaTypes luaTypes4 = LuaDLL.lua_type(L, 2);
				DOSetter<Vector4> setter2;
				if (luaTypes4 != LuaTypes.LUA_TFUNCTION)
				{
					setter2 = (DOSetter<Vector4>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func4 = ToLua.ToLuaFunction(L, 2);
					setter2 = (DelegateFactory.CreateDelegate(typeof(DOSetter<Vector4>), func4) as DOSetter<Vector4>);
				}
				Vector4 endValue2 = ToLua.ToVector4(L, 3);
				float duration2 = (float)LuaDLL.lua_tonumber(L, 4);
				TweenerCore<Vector4, Vector4, VectorOptions> o2 = DOTween.To(getter2, setter2, endValue2, duration2);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<Vector3>), typeof(DOSetter<Vector3>), typeof(Vector3), typeof(float)))
			{
				LuaTypes luaTypes5 = LuaDLL.lua_type(L, 1);
				DOGetter<Vector3> getter3;
				if (luaTypes5 != LuaTypes.LUA_TFUNCTION)
				{
					getter3 = (DOGetter<Vector3>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func5 = ToLua.ToLuaFunction(L, 1);
					getter3 = (DelegateFactory.CreateDelegate(typeof(DOGetter<Vector3>), func5) as DOGetter<Vector3>);
				}
				LuaTypes luaTypes6 = LuaDLL.lua_type(L, 2);
				DOSetter<Vector3> setter3;
				if (luaTypes6 != LuaTypes.LUA_TFUNCTION)
				{
					setter3 = (DOSetter<Vector3>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func6 = ToLua.ToLuaFunction(L, 2);
					setter3 = (DelegateFactory.CreateDelegate(typeof(DOSetter<Vector3>), func6) as DOSetter<Vector3>);
				}
				Vector3 endValue3 = ToLua.ToVector3(L, 3);
				float duration3 = (float)LuaDLL.lua_tonumber(L, 4);
				TweenerCore<Vector3, Vector3, VectorOptions> o3 = DOTween.To(getter3, setter3, endValue3, duration3);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<Color>), typeof(DOSetter<Color>), typeof(Color), typeof(float)))
			{
				LuaTypes luaTypes7 = LuaDLL.lua_type(L, 1);
				DOGetter<Color> getter4;
				if (luaTypes7 != LuaTypes.LUA_TFUNCTION)
				{
					getter4 = (DOGetter<Color>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func7 = ToLua.ToLuaFunction(L, 1);
					getter4 = (DelegateFactory.CreateDelegate(typeof(DOGetter<Color>), func7) as DOGetter<Color>);
				}
				LuaTypes luaTypes8 = LuaDLL.lua_type(L, 2);
				DOSetter<Color> setter4;
				if (luaTypes8 != LuaTypes.LUA_TFUNCTION)
				{
					setter4 = (DOSetter<Color>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func8 = ToLua.ToLuaFunction(L, 2);
					setter4 = (DelegateFactory.CreateDelegate(typeof(DOSetter<Color>), func8) as DOSetter<Color>);
				}
				Color endValue4 = ToLua.ToColor(L, 3);
				float duration4 = (float)LuaDLL.lua_tonumber(L, 4);
				TweenerCore<Color, Color, ColorOptions> o4 = DOTween.To(getter4, setter4, endValue4, duration4);
				ToLua.PushObject(L, o4);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(DOSetter<float>), typeof(float), typeof(float), typeof(float)))
			{
				LuaTypes luaTypes9 = LuaDLL.lua_type(L, 1);
				DOSetter<float> setter5;
				if (luaTypes9 != LuaTypes.LUA_TFUNCTION)
				{
					setter5 = (DOSetter<float>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func9 = ToLua.ToLuaFunction(L, 1);
					setter5 = (DelegateFactory.CreateDelegate(typeof(DOSetter<float>), func9) as DOSetter<float>);
				}
				float startValue = (float)LuaDLL.lua_tonumber(L, 2);
				float endValue5 = (float)LuaDLL.lua_tonumber(L, 3);
				float duration5 = (float)LuaDLL.lua_tonumber(L, 4);
				Tweener o5 = DOTween.To(setter5, startValue, endValue5, duration5);
				ToLua.PushObject(L, o5);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<RectOffset>), typeof(DOSetter<RectOffset>), typeof(RectOffset), typeof(float)))
			{
				LuaTypes luaTypes10 = LuaDLL.lua_type(L, 1);
				DOGetter<RectOffset> getter5;
				if (luaTypes10 != LuaTypes.LUA_TFUNCTION)
				{
					getter5 = (DOGetter<RectOffset>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func10 = ToLua.ToLuaFunction(L, 1);
					getter5 = (DelegateFactory.CreateDelegate(typeof(DOGetter<RectOffset>), func10) as DOGetter<RectOffset>);
				}
				LuaTypes luaTypes11 = LuaDLL.lua_type(L, 2);
				DOSetter<RectOffset> setter6;
				if (luaTypes11 != LuaTypes.LUA_TFUNCTION)
				{
					setter6 = (DOSetter<RectOffset>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func11 = ToLua.ToLuaFunction(L, 2);
					setter6 = (DelegateFactory.CreateDelegate(typeof(DOSetter<RectOffset>), func11) as DOSetter<RectOffset>);
				}
				RectOffset endValue6 = (RectOffset)ToLua.ToObject(L, 3);
				float duration6 = (float)LuaDLL.lua_tonumber(L, 4);
				Tweener o6 = DOTween.To(getter5, setter6, endValue6, duration6);
				ToLua.PushObject(L, o6);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<Rect>), typeof(DOSetter<Rect>), typeof(Rect), typeof(float)))
			{
				LuaTypes luaTypes12 = LuaDLL.lua_type(L, 1);
				DOGetter<Rect> getter6;
				if (luaTypes12 != LuaTypes.LUA_TFUNCTION)
				{
					getter6 = (DOGetter<Rect>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func12 = ToLua.ToLuaFunction(L, 1);
					getter6 = (DelegateFactory.CreateDelegate(typeof(DOGetter<Rect>), func12) as DOGetter<Rect>);
				}
				LuaTypes luaTypes13 = LuaDLL.lua_type(L, 2);
				DOSetter<Rect> setter7;
				if (luaTypes13 != LuaTypes.LUA_TFUNCTION)
				{
					setter7 = (DOSetter<Rect>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func13 = ToLua.ToLuaFunction(L, 2);
					setter7 = (DelegateFactory.CreateDelegate(typeof(DOSetter<Rect>), func13) as DOSetter<Rect>);
				}
				Rect endValue7 = (Rect)ToLua.ToObject(L, 3);
				float duration7 = (float)LuaDLL.lua_tonumber(L, 4);
				TweenerCore<Rect, Rect, RectOptions> o7 = DOTween.To(getter6, setter7, endValue7, duration7);
				ToLua.PushObject(L, o7);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<Vector2>), typeof(DOSetter<Vector2>), typeof(Vector2), typeof(float)))
			{
				LuaTypes luaTypes14 = LuaDLL.lua_type(L, 1);
				DOGetter<Vector2> getter7;
				if (luaTypes14 != LuaTypes.LUA_TFUNCTION)
				{
					getter7 = (DOGetter<Vector2>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func14 = ToLua.ToLuaFunction(L, 1);
					getter7 = (DelegateFactory.CreateDelegate(typeof(DOGetter<Vector2>), func14) as DOGetter<Vector2>);
				}
				LuaTypes luaTypes15 = LuaDLL.lua_type(L, 2);
				DOSetter<Vector2> setter8;
				if (luaTypes15 != LuaTypes.LUA_TFUNCTION)
				{
					setter8 = (DOSetter<Vector2>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func15 = ToLua.ToLuaFunction(L, 2);
					setter8 = (DelegateFactory.CreateDelegate(typeof(DOSetter<Vector2>), func15) as DOSetter<Vector2>);
				}
				Vector2 endValue8 = ToLua.ToVector2(L, 3);
				float duration8 = (float)LuaDLL.lua_tonumber(L, 4);
				TweenerCore<Vector2, Vector2, VectorOptions> o8 = DOTween.To(getter7, setter8, endValue8, duration8);
				ToLua.PushObject(L, o8);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<int>), typeof(DOSetter<int>), typeof(int), typeof(float)))
			{
				LuaTypes luaTypes16 = LuaDLL.lua_type(L, 1);
				DOGetter<int> getter8;
				if (luaTypes16 != LuaTypes.LUA_TFUNCTION)
				{
					getter8 = (DOGetter<int>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func16 = ToLua.ToLuaFunction(L, 1);
					getter8 = (DelegateFactory.CreateDelegate(typeof(DOGetter<int>), func16) as DOGetter<int>);
				}
				LuaTypes luaTypes17 = LuaDLL.lua_type(L, 2);
				DOSetter<int> setter9;
				if (luaTypes17 != LuaTypes.LUA_TFUNCTION)
				{
					setter9 = (DOSetter<int>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func17 = ToLua.ToLuaFunction(L, 2);
					setter9 = (DelegateFactory.CreateDelegate(typeof(DOSetter<int>), func17) as DOSetter<int>);
				}
				int endValue9 = (int)LuaDLL.lua_tonumber(L, 3);
				float duration9 = (float)LuaDLL.lua_tonumber(L, 4);
				Tweener o9 = DOTween.To(getter8, setter9, endValue9, duration9);
				ToLua.PushObject(L, o9);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<double>), typeof(DOSetter<double>), typeof(double), typeof(float)))
			{
				LuaTypes luaTypes18 = LuaDLL.lua_type(L, 1);
				DOGetter<double> getter9;
				if (luaTypes18 != LuaTypes.LUA_TFUNCTION)
				{
					getter9 = (DOGetter<double>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func18 = ToLua.ToLuaFunction(L, 1);
					getter9 = (DelegateFactory.CreateDelegate(typeof(DOGetter<double>), func18) as DOGetter<double>);
				}
				LuaTypes luaTypes19 = LuaDLL.lua_type(L, 2);
				DOSetter<double> setter10;
				if (luaTypes19 != LuaTypes.LUA_TFUNCTION)
				{
					setter10 = (DOSetter<double>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func19 = ToLua.ToLuaFunction(L, 2);
					setter10 = (DelegateFactory.CreateDelegate(typeof(DOSetter<double>), func19) as DOSetter<double>);
				}
				double endValue10 = LuaDLL.lua_tonumber(L, 3);
				float duration10 = (float)LuaDLL.lua_tonumber(L, 4);
				TweenerCore<double, double, NoOptions> o10 = DOTween.To(getter9, setter10, endValue10, duration10);
				ToLua.PushObject(L, o10);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<float>), typeof(DOSetter<float>), typeof(float), typeof(float)))
			{
				LuaTypes luaTypes20 = LuaDLL.lua_type(L, 1);
				DOGetter<float> getter10;
				if (luaTypes20 != LuaTypes.LUA_TFUNCTION)
				{
					getter10 = (DOGetter<float>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func20 = ToLua.ToLuaFunction(L, 1);
					getter10 = (DelegateFactory.CreateDelegate(typeof(DOGetter<float>), func20) as DOGetter<float>);
				}
				LuaTypes luaTypes21 = LuaDLL.lua_type(L, 2);
				DOSetter<float> setter11;
				if (luaTypes21 != LuaTypes.LUA_TFUNCTION)
				{
					setter11 = (DOSetter<float>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func21 = ToLua.ToLuaFunction(L, 2);
					setter11 = (DelegateFactory.CreateDelegate(typeof(DOSetter<float>), func21) as DOSetter<float>);
				}
				float endValue11 = (float)LuaDLL.lua_tonumber(L, 3);
				float duration11 = (float)LuaDLL.lua_tonumber(L, 4);
				TweenerCore<float, float, FloatOptions> o11 = DOTween.To(getter10, setter11, endValue11, duration11);
				ToLua.PushObject(L, o11);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<uint>), typeof(DOSetter<uint>), typeof(uint), typeof(float)))
			{
				LuaTypes luaTypes22 = LuaDLL.lua_type(L, 1);
				DOGetter<uint> getter11;
				if (luaTypes22 != LuaTypes.LUA_TFUNCTION)
				{
					getter11 = (DOGetter<uint>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func22 = ToLua.ToLuaFunction(L, 1);
					getter11 = (DelegateFactory.CreateDelegate(typeof(DOGetter<uint>), func22) as DOGetter<uint>);
				}
				LuaTypes luaTypes23 = LuaDLL.lua_type(L, 2);
				DOSetter<uint> setter12;
				if (luaTypes23 != LuaTypes.LUA_TFUNCTION)
				{
					setter12 = (DOSetter<uint>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func23 = ToLua.ToLuaFunction(L, 2);
					setter12 = (DelegateFactory.CreateDelegate(typeof(DOSetter<uint>), func23) as DOSetter<uint>);
				}
				uint endValue12 = (uint)LuaDLL.lua_tonumber(L, 3);
				float duration12 = (float)LuaDLL.lua_tonumber(L, 4);
				Tweener o12 = DOTween.To(getter11, setter12, endValue12, duration12);
				ToLua.PushObject(L, o12);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<string>), typeof(DOSetter<string>), typeof(string), typeof(float)))
			{
				LuaTypes luaTypes24 = LuaDLL.lua_type(L, 1);
				DOGetter<string> getter12;
				if (luaTypes24 != LuaTypes.LUA_TFUNCTION)
				{
					getter12 = (DOGetter<string>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func24 = ToLua.ToLuaFunction(L, 1);
					getter12 = (DelegateFactory.CreateDelegate(typeof(DOGetter<string>), func24) as DOGetter<string>);
				}
				LuaTypes luaTypes25 = LuaDLL.lua_type(L, 2);
				DOSetter<string> setter13;
				if (luaTypes25 != LuaTypes.LUA_TFUNCTION)
				{
					setter13 = (DOSetter<string>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func25 = ToLua.ToLuaFunction(L, 2);
					setter13 = (DelegateFactory.CreateDelegate(typeof(DOSetter<string>), func25) as DOSetter<string>);
				}
				string endValue13 = ToLua.ToString(L, 3);
				float duration13 = (float)LuaDLL.lua_tonumber(L, 4);
				TweenerCore<string, string, StringOptions> o13 = DOTween.To(getter12, setter13, endValue13, duration13);
				ToLua.PushObject(L, o13);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<ulong>), typeof(DOSetter<ulong>), typeof(ulong), typeof(float)))
			{
				LuaTypes luaTypes26 = LuaDLL.lua_type(L, 1);
				DOGetter<ulong> getter13;
				if (luaTypes26 != LuaTypes.LUA_TFUNCTION)
				{
					getter13 = (DOGetter<ulong>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func26 = ToLua.ToLuaFunction(L, 1);
					getter13 = (DelegateFactory.CreateDelegate(typeof(DOGetter<ulong>), func26) as DOGetter<ulong>);
				}
				LuaTypes luaTypes27 = LuaDLL.lua_type(L, 2);
				DOSetter<ulong> setter14;
				if (luaTypes27 != LuaTypes.LUA_TFUNCTION)
				{
					setter14 = (DOSetter<ulong>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func27 = ToLua.ToLuaFunction(L, 2);
					setter14 = (DelegateFactory.CreateDelegate(typeof(DOSetter<ulong>), func27) as DOSetter<ulong>);
				}
				ulong endValue14 = LuaDLL.tolua_touint64(L, 3);
				float duration14 = (float)LuaDLL.lua_tonumber(L, 4);
				Tweener o14 = DOTween.To(getter13, setter14, endValue14, duration14);
				ToLua.PushObject(L, o14);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<long>), typeof(DOSetter<long>), typeof(long), typeof(float)))
			{
				LuaTypes luaTypes28 = LuaDLL.lua_type(L, 1);
				DOGetter<long> getter14;
				if (luaTypes28 != LuaTypes.LUA_TFUNCTION)
				{
					getter14 = (DOGetter<long>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func28 = ToLua.ToLuaFunction(L, 1);
					getter14 = (DelegateFactory.CreateDelegate(typeof(DOGetter<long>), func28) as DOGetter<long>);
				}
				LuaTypes luaTypes29 = LuaDLL.lua_type(L, 2);
				DOSetter<long> setter15;
				if (luaTypes29 != LuaTypes.LUA_TFUNCTION)
				{
					setter15 = (DOSetter<long>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func29 = ToLua.ToLuaFunction(L, 2);
					setter15 = (DelegateFactory.CreateDelegate(typeof(DOSetter<long>), func29) as DOSetter<long>);
				}
				long endValue15 = LuaDLL.tolua_toint64(L, 3);
				float duration15 = (float)LuaDLL.lua_tonumber(L, 4);
				Tweener o15 = DOTween.To(getter14, setter15, endValue15, duration15);
				ToLua.PushObject(L, o15);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.DOTween.To");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToAxis(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			DOGetter<Vector3> getter;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				getter = (DOGetter<Vector3>)ToLua.CheckObject(L, 1, typeof(DOGetter<Vector3>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 1);
				getter = (DelegateFactory.CreateDelegate(typeof(DOGetter<Vector3>), func) as DOGetter<Vector3>);
			}
			LuaTypes luaTypes2 = LuaDLL.lua_type(L, 2);
			DOSetter<Vector3> setter;
			if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
			{
				setter = (DOSetter<Vector3>)ToLua.CheckObject(L, 2, typeof(DOSetter<Vector3>));
			}
			else
			{
				LuaFunction func2 = ToLua.ToLuaFunction(L, 2);
				setter = (DelegateFactory.CreateDelegate(typeof(DOSetter<Vector3>), func2) as DOSetter<Vector3>);
			}
			float endValue = (float)LuaDLL.luaL_checknumber(L, 3);
			float duration = (float)LuaDLL.luaL_checknumber(L, 4);
			AxisConstraint axisConstraint = (AxisConstraint)((int)ToLua.CheckObject(L, 5, typeof(AxisConstraint)));
			TweenerCore<Vector3, Vector3, VectorOptions> o = DOTween.ToAxis(getter, setter, endValue, duration, axisConstraint);
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
	private static int ToAlpha(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			DOGetter<Color> getter;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				getter = (DOGetter<Color>)ToLua.CheckObject(L, 1, typeof(DOGetter<Color>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 1);
				getter = (DelegateFactory.CreateDelegate(typeof(DOGetter<Color>), func) as DOGetter<Color>);
			}
			LuaTypes luaTypes2 = LuaDLL.lua_type(L, 2);
			DOSetter<Color> setter;
			if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
			{
				setter = (DOSetter<Color>)ToLua.CheckObject(L, 2, typeof(DOSetter<Color>));
			}
			else
			{
				LuaFunction func2 = ToLua.ToLuaFunction(L, 2);
				setter = (DelegateFactory.CreateDelegate(typeof(DOSetter<Color>), func2) as DOSetter<Color>);
			}
			float endValue = (float)LuaDLL.luaL_checknumber(L, 3);
			float duration = (float)LuaDLL.luaL_checknumber(L, 4);
			Tweener o = DOTween.ToAlpha(getter, setter, endValue, duration);
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
	private static int Punch(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 6);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			DOGetter<Vector3> getter;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				getter = (DOGetter<Vector3>)ToLua.CheckObject(L, 1, typeof(DOGetter<Vector3>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 1);
				getter = (DelegateFactory.CreateDelegate(typeof(DOGetter<Vector3>), func) as DOGetter<Vector3>);
			}
			LuaTypes luaTypes2 = LuaDLL.lua_type(L, 2);
			DOSetter<Vector3> setter;
			if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
			{
				setter = (DOSetter<Vector3>)ToLua.CheckObject(L, 2, typeof(DOSetter<Vector3>));
			}
			else
			{
				LuaFunction func2 = ToLua.ToLuaFunction(L, 2);
				setter = (DelegateFactory.CreateDelegate(typeof(DOSetter<Vector3>), func2) as DOSetter<Vector3>);
			}
			Vector3 direction = ToLua.ToVector3(L, 3);
			float duration = (float)LuaDLL.luaL_checknumber(L, 4);
			int vibrato = (int)LuaDLL.luaL_checknumber(L, 5);
			float elasticity = (float)LuaDLL.luaL_checknumber(L, 6);
			TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o = DOTween.Punch(getter, setter, direction, duration, vibrato, elasticity);
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
	private static int Shake(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<Vector3>), typeof(DOSetter<Vector3>), typeof(float), typeof(Vector3), typeof(int), typeof(float), typeof(bool)))
			{
				LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
				DOGetter<Vector3> getter;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					getter = (DOGetter<Vector3>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 1);
					getter = (DelegateFactory.CreateDelegate(typeof(DOGetter<Vector3>), func) as DOGetter<Vector3>);
				}
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 2);
				DOSetter<Vector3> setter;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					setter = (DOSetter<Vector3>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 2);
					setter = (DelegateFactory.CreateDelegate(typeof(DOSetter<Vector3>), func2) as DOSetter<Vector3>);
				}
				float duration = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 strength = ToLua.ToVector3(L, 4);
				int vibrato = (int)LuaDLL.lua_tonumber(L, 5);
				float randomness = (float)LuaDLL.lua_tonumber(L, 6);
				bool fadeOut = LuaDLL.lua_toboolean(L, 7);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o = DOTween.Shake(getter, setter, duration, strength, vibrato, randomness, fadeOut);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 8 && TypeChecker.CheckTypes(L, 1, typeof(DOGetter<Vector3>), typeof(DOSetter<Vector3>), typeof(float), typeof(float), typeof(int), typeof(float), typeof(bool), typeof(bool)))
			{
				LuaTypes luaTypes3 = LuaDLL.lua_type(L, 1);
				DOGetter<Vector3> getter2;
				if (luaTypes3 != LuaTypes.LUA_TFUNCTION)
				{
					getter2 = (DOGetter<Vector3>)ToLua.ToObject(L, 1);
				}
				else
				{
					LuaFunction func3 = ToLua.ToLuaFunction(L, 1);
					getter2 = (DelegateFactory.CreateDelegate(typeof(DOGetter<Vector3>), func3) as DOGetter<Vector3>);
				}
				LuaTypes luaTypes4 = LuaDLL.lua_type(L, 2);
				DOSetter<Vector3> setter2;
				if (luaTypes4 != LuaTypes.LUA_TFUNCTION)
				{
					setter2 = (DOSetter<Vector3>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func4 = ToLua.ToLuaFunction(L, 2);
					setter2 = (DelegateFactory.CreateDelegate(typeof(DOSetter<Vector3>), func4) as DOSetter<Vector3>);
				}
				float duration2 = (float)LuaDLL.lua_tonumber(L, 3);
				float strength2 = (float)LuaDLL.lua_tonumber(L, 4);
				int vibrato2 = (int)LuaDLL.lua_tonumber(L, 5);
				float randomness2 = (float)LuaDLL.lua_tonumber(L, 6);
				bool ignoreZAxis = LuaDLL.lua_toboolean(L, 7);
				bool fadeOut2 = LuaDLL.lua_toboolean(L, 8);
				TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o2 = DOTween.Shake(getter2, setter2, duration2, strength2, vibrato2, randomness2, ignoreZAxis, fadeOut2);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.DOTween.Shake");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToArray(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			DOGetter<Vector3> getter;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				getter = (DOGetter<Vector3>)ToLua.CheckObject(L, 1, typeof(DOGetter<Vector3>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 1);
				getter = (DelegateFactory.CreateDelegate(typeof(DOGetter<Vector3>), func) as DOGetter<Vector3>);
			}
			LuaTypes luaTypes2 = LuaDLL.lua_type(L, 2);
			DOSetter<Vector3> setter;
			if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
			{
				setter = (DOSetter<Vector3>)ToLua.CheckObject(L, 2, typeof(DOSetter<Vector3>));
			}
			else
			{
				LuaFunction func2 = ToLua.ToLuaFunction(L, 2);
				setter = (DelegateFactory.CreateDelegate(typeof(DOSetter<Vector3>), func2) as DOSetter<Vector3>);
			}
			Vector3[] endValues = ToLua.CheckObjectArray<Vector3>(L, 3);
			float[] durations = ToLua.CheckNumberArray<float>(L, 4);
			TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> o = DOTween.ToArray(getter, setter, endValues, durations);
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
	private static int Sequence(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			Sequence o = DOTween.Sequence();
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
	private static int CompleteAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			bool withCallbacks = LuaDLL.luaL_checkboolean(L, 1);
			int n = DOTween.CompleteAll(withCallbacks);
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
	private static int Complete(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			object targetOrId = ToLua.ToVarObject(L, 1);
			bool withCallbacks = LuaDLL.luaL_checkboolean(L, 2);
			int n = DOTween.Complete(targetOrId, withCallbacks);
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
	private static int FlipAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			int n = DOTween.FlipAll();
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
	private static int Flip(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object targetOrId = ToLua.ToVarObject(L, 1);
			int n = DOTween.Flip(targetOrId);
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
	private static int GotoAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			float to = (float)LuaDLL.luaL_checknumber(L, 1);
			bool andPlay = LuaDLL.luaL_checkboolean(L, 2);
			int n = DOTween.GotoAll(to, andPlay);
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
	private static int Goto(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			object targetOrId = ToLua.ToVarObject(L, 1);
			float to = (float)LuaDLL.luaL_checknumber(L, 2);
			bool andPlay = LuaDLL.luaL_checkboolean(L, 3);
			int n = DOTween.Goto(targetOrId, to, andPlay);
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
	private static int KillAll(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(bool)))
			{
				bool complete = LuaDLL.lua_toboolean(L, 1);
				int n = DOTween.KillAll(complete);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (TypeChecker.CheckTypes(L, 1, typeof(bool)) && TypeChecker.CheckParamsType(L, typeof(object), 2, num - 1))
			{
				bool complete2 = LuaDLL.lua_toboolean(L, 1);
				object[] idsOrTargetsToExclude = ToLua.ToParamsObject(L, 2, num - 1);
				int n2 = DOTween.KillAll(complete2, idsOrTargetsToExclude);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.DOTween.KillAll");
			}
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
			object targetOrId = ToLua.ToVarObject(L, 1);
			bool complete = LuaDLL.luaL_checkboolean(L, 2);
			int n = DOTween.Kill(targetOrId, complete);
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
	private static int PauseAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			int n = DOTween.PauseAll();
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
	private static int Pause(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object targetOrId = ToLua.ToVarObject(L, 1);
			int n = DOTween.Pause(targetOrId);
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
	private static int PlayAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			int n = DOTween.PlayAll();
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
	private static int Play(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(object)))
			{
				object targetOrId = ToLua.ToVarObject(L, 1);
				int n = DOTween.Play(targetOrId);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(object), typeof(object)))
			{
				object target = ToLua.ToVarObject(L, 1);
				object id = ToLua.ToVarObject(L, 2);
				int n2 = DOTween.Play(target, id);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.DOTween.Play");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayBackwardsAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			int n = DOTween.PlayBackwardsAll();
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
	private static int PlayBackwards(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(object)))
			{
				object targetOrId = ToLua.ToVarObject(L, 1);
				int n = DOTween.PlayBackwards(targetOrId);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(object), typeof(object)))
			{
				object target = ToLua.ToVarObject(L, 1);
				object id = ToLua.ToVarObject(L, 2);
				int n2 = DOTween.PlayBackwards(target, id);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.DOTween.PlayBackwards");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayForwardAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			int n = DOTween.PlayForwardAll();
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
	private static int PlayForward(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(object)))
			{
				object targetOrId = ToLua.ToVarObject(L, 1);
				int n = DOTween.PlayForward(targetOrId);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(object), typeof(object)))
			{
				object target = ToLua.ToVarObject(L, 1);
				object id = ToLua.ToVarObject(L, 2);
				int n2 = DOTween.PlayForward(target, id);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.DOTween.PlayForward");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RestartAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			bool includeDelay = LuaDLL.luaL_checkboolean(L, 1);
			int n = DOTween.RestartAll(includeDelay);
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
	private static int Restart(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(object), typeof(bool)))
			{
				object targetOrId = ToLua.ToVarObject(L, 1);
				bool includeDelay = LuaDLL.lua_toboolean(L, 2);
				int n = DOTween.Restart(targetOrId, includeDelay);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(object), typeof(object), typeof(bool)))
			{
				object target = ToLua.ToVarObject(L, 1);
				object id = ToLua.ToVarObject(L, 2);
				bool includeDelay2 = LuaDLL.lua_toboolean(L, 3);
				int n2 = DOTween.Restart(target, id, includeDelay2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: DG.Tweening.DOTween.Restart");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RewindAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			bool includeDelay = LuaDLL.luaL_checkboolean(L, 1);
			int n = DOTween.RewindAll(includeDelay);
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
	private static int Rewind(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			object targetOrId = ToLua.ToVarObject(L, 1);
			bool includeDelay = LuaDLL.luaL_checkboolean(L, 2);
			int n = DOTween.Rewind(targetOrId, includeDelay);
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
	private static int SmoothRewindAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			int n = DOTween.SmoothRewindAll();
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
	private static int SmoothRewind(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object targetOrId = ToLua.ToVarObject(L, 1);
			int n = DOTween.SmoothRewind(targetOrId);
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
	private static int TogglePauseAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			int n = DOTween.TogglePauseAll();
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
	private static int TogglePause(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object targetOrId = ToLua.ToVarObject(L, 1);
			int n = DOTween.TogglePause(targetOrId);
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
	private static int IsTweening(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			object targetOrId = ToLua.ToVarObject(L, 1);
			bool value = DOTween.IsTweening(targetOrId);
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
	private static int TotalPlayingTweens(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			int n = DOTween.TotalPlayingTweens();
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
	private static int PlayingTweens(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			List<Tween> o = DOTween.PlayingTweens();
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
	private static int PausedTweens(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			List<Tween> o = DOTween.PausedTweens();
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
	private static int TweensById(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			object id = ToLua.ToVarObject(L, 1);
			bool playingOnly = LuaDLL.luaL_checkboolean(L, 2);
			List<Tween> o = DOTween.TweensById(id, playingOnly);
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
	private static int TweensByTarget(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			object target = ToLua.ToVarObject(L, 1);
			bool playingOnly = LuaDLL.luaL_checkboolean(L, 2);
			List<Tween> o = DOTween.TweensByTarget(target, playingOnly);
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
	private static int get_Version(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushstring(L, DOTween.Version);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useSafeMode(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, DOTween.useSafeMode);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_showUnityEditorReport(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, DOTween.showUnityEditorReport);
			result = 1;
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
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)DOTween.timeScale);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useSmoothDeltaTime(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, DOTween.useSmoothDeltaTime);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drawGizmos(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, DOTween.drawGizmos);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultUpdateType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, DOTween.defaultUpdateType);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultTimeScaleIndependent(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, DOTween.defaultTimeScaleIndependent);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultAutoPlay(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, DOTween.defaultAutoPlay);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultAutoKill(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, DOTween.defaultAutoKill);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultLoopType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, DOTween.defaultLoopType);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultRecyclable(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, DOTween.defaultRecyclable);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultEaseType(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, DOTween.defaultEaseType);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultEaseOvershootOrAmplitude(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)DOTween.defaultEaseOvershootOrAmplitude);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultEasePeriod(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)DOTween.defaultEasePeriod);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_logBehaviour(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, DOTween.logBehaviour);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useSafeMode(IntPtr L)
	{
		int result;
		try
		{
			bool useSafeMode = LuaDLL.luaL_checkboolean(L, 2);
			DOTween.useSafeMode = useSafeMode;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_showUnityEditorReport(IntPtr L)
	{
		int result;
		try
		{
			bool showUnityEditorReport = LuaDLL.luaL_checkboolean(L, 2);
			DOTween.showUnityEditorReport = showUnityEditorReport;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_timeScale(IntPtr L)
	{
		int result;
		try
		{
			float timeScale = (float)LuaDLL.luaL_checknumber(L, 2);
			DOTween.timeScale = timeScale;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useSmoothDeltaTime(IntPtr L)
	{
		int result;
		try
		{
			bool useSmoothDeltaTime = LuaDLL.luaL_checkboolean(L, 2);
			DOTween.useSmoothDeltaTime = useSmoothDeltaTime;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_drawGizmos(IntPtr L)
	{
		int result;
		try
		{
			bool drawGizmos = LuaDLL.luaL_checkboolean(L, 2);
			DOTween.drawGizmos = drawGizmos;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultUpdateType(IntPtr L)
	{
		int result;
		try
		{
			UpdateType defaultUpdateType = (UpdateType)((int)ToLua.CheckObject(L, 2, typeof(UpdateType)));
			DOTween.defaultUpdateType = defaultUpdateType;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultTimeScaleIndependent(IntPtr L)
	{
		int result;
		try
		{
			bool defaultTimeScaleIndependent = LuaDLL.luaL_checkboolean(L, 2);
			DOTween.defaultTimeScaleIndependent = defaultTimeScaleIndependent;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultAutoPlay(IntPtr L)
	{
		int result;
		try
		{
			AutoPlay defaultAutoPlay = (AutoPlay)((int)ToLua.CheckObject(L, 2, typeof(AutoPlay)));
			DOTween.defaultAutoPlay = defaultAutoPlay;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultAutoKill(IntPtr L)
	{
		int result;
		try
		{
			bool defaultAutoKill = LuaDLL.luaL_checkboolean(L, 2);
			DOTween.defaultAutoKill = defaultAutoKill;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultLoopType(IntPtr L)
	{
		int result;
		try
		{
			LoopType defaultLoopType = (LoopType)((int)ToLua.CheckObject(L, 2, typeof(LoopType)));
			DOTween.defaultLoopType = defaultLoopType;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultRecyclable(IntPtr L)
	{
		int result;
		try
		{
			bool defaultRecyclable = LuaDLL.luaL_checkboolean(L, 2);
			DOTween.defaultRecyclable = defaultRecyclable;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultEaseType(IntPtr L)
	{
		int result;
		try
		{
			Ease defaultEaseType = (Ease)((int)ToLua.CheckObject(L, 2, typeof(Ease)));
			DOTween.defaultEaseType = defaultEaseType;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultEaseOvershootOrAmplitude(IntPtr L)
	{
		int result;
		try
		{
			float defaultEaseOvershootOrAmplitude = (float)LuaDLL.luaL_checknumber(L, 2);
			DOTween.defaultEaseOvershootOrAmplitude = defaultEaseOvershootOrAmplitude;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultEasePeriod(IntPtr L)
	{
		int result;
		try
		{
			float defaultEasePeriod = (float)LuaDLL.luaL_checknumber(L, 2);
			DOTween.defaultEasePeriod = defaultEasePeriod;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_logBehaviour(IntPtr L)
	{
		int result;
		try
		{
			LogBehaviour logBehaviour = (LogBehaviour)((int)ToLua.CheckObject(L, 2, typeof(LogBehaviour)));
			DOTween.logBehaviour = logBehaviour;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
