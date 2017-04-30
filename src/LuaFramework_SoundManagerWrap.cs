using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_SoundManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SoundManager), typeof(Manager), null);
		L.RegFunction("CanPlayBackSound", new LuaCSFunction(LuaFramework_SoundManagerWrap.CanPlayBackSound));
		L.RegFunction("PlayBGM", new LuaCSFunction(LuaFramework_SoundManagerWrap.PlayBGM));
		L.RegFunction("CanPlaySoundEffect", new LuaCSFunction(LuaFramework_SoundManagerWrap.CanPlaySoundEffect));
		L.RegFunction("PlaySkillSound", new LuaCSFunction(LuaFramework_SoundManagerWrap.PlaySkillSound));
		L.RegFunction("PlayEffectSound", new LuaCSFunction(LuaFramework_SoundManagerWrap.PlayEffectSound));
		L.RegFunction("PlayTalkSound", new LuaCSFunction(LuaFramework_SoundManagerWrap.PlayTalkSound));
		L.RegFunction("PlayUISound", new LuaCSFunction(LuaFramework_SoundManagerWrap.PlayUISound));
		L.RegFunction("ChangeVolume", new LuaCSFunction(LuaFramework_SoundManagerWrap.ChangeVolume));
		L.RegFunction("StopBGM", new LuaCSFunction(LuaFramework_SoundManagerWrap.StopBGM));
		L.RegFunction("PauseMusic", new LuaCSFunction(LuaFramework_SoundManagerWrap.PauseMusic));
		L.RegFunction("ReplayMusic", new LuaCSFunction(LuaFramework_SoundManagerWrap.ReplayMusic));
		L.RegFunction("StopEffectSound", new LuaCSFunction(LuaFramework_SoundManagerWrap.StopEffectSound));
		L.RegFunction("Clear", new LuaCSFunction(LuaFramework_SoundManagerWrap.Clear));
		L.RegFunction("__eq", new LuaCSFunction(LuaFramework_SoundManagerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CanPlayBackSound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			bool value = soundManager.CanPlayBackSound();
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
	private static int PlayBGM(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			string name = ToLua.CheckString(L, 2);
			float volume = (float)LuaDLL.luaL_checknumber(L, 3);
			soundManager.PlayBGM(name, volume);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CanPlaySoundEffect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			bool value = soundManager.CanPlaySoundEffect();
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
	private static int PlaySkillSound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 10);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			string name = ToLua.CheckString(L, 2);
			float volume = (float)LuaDLL.luaL_checknumber(L, 3);
			float delay = (float)LuaDLL.luaL_checknumber(L, 4);
			Vector3 position = ToLua.ToVector3(L, 5);
			int priority = (int)LuaDLL.luaL_checknumber(L, 6);
			bool loop = LuaDLL.luaL_checkboolean(L, 7);
			float minPitch = (float)LuaDLL.luaL_checknumber(L, 8);
			float maxPitch = (float)LuaDLL.luaL_checknumber(L, 9);
			string extension = ToLua.CheckString(L, 10);
			soundManager.PlaySkillSound(name, volume, delay, position, priority, loop, minPitch, maxPitch, extension);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayEffectSound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			string name = ToLua.CheckString(L, 2);
			Vector3 position = ToLua.ToVector3(L, 3);
			bool loop = LuaDLL.luaL_checkboolean(L, 4);
			soundManager.PlayEffectSound(name, position, loop);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayTalkSound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			string name = ToLua.CheckString(L, 2);
			float volume = (float)LuaDLL.luaL_checknumber(L, 3);
			float delay = (float)LuaDLL.luaL_checknumber(L, 4);
			Vector3 position = ToLua.ToVector3(L, 5);
			soundManager.PlayTalkSound(name, volume, delay, position);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PlayUISound(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			string name = ToLua.CheckString(L, 2);
			float volume = (float)LuaDLL.luaL_checknumber(L, 3);
			float delay = (float)LuaDLL.luaL_checknumber(L, 4);
			string extension = ToLua.CheckString(L, 5);
			soundManager.PlayUISound(name, volume, delay, extension);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangeVolume(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			float volume = (float)LuaDLL.luaL_checknumber(L, 2);
			soundManager.ChangeVolume(volume);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopBGM(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			soundManager.StopBGM();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PauseMusic(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			soundManager.PauseMusic();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ReplayMusic(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			soundManager.ReplayMusic();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StopEffectSound(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(SoundManager)))
			{
				SoundManager soundManager = (SoundManager)ToLua.ToObject(L, 1);
				soundManager.StopEffectSound();
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(SoundManager), typeof(string), typeof(int)))
			{
				SoundManager soundManager2 = (SoundManager)ToLua.ToObject(L, 1);
				string name = ToLua.ToString(L, 2);
				int type = (int)LuaDLL.lua_tonumber(L, 3);
				soundManager2.StopEffectSound(name, type);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: LuaFramework.SoundManager.StopEffectSound");
			}
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
			SoundManager soundManager = (SoundManager)ToLua.CheckObject(L, 1, typeof(SoundManager));
			soundManager.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int op_Equality(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object x = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object y = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool value = x == y;
			LuaDLL.lua_pushboolean(L, value);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
