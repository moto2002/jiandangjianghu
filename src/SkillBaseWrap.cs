using LuaInterface;
using System;
using UnityEngine;

public class SkillBaseWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SkillBase), typeof(MonoBehaviour), null);
		L.RegFunction("StartSkill", new LuaCSFunction(SkillBaseWrap.StartSkill));
		L.RegFunction("Find", new LuaCSFunction(SkillBaseWrap.Find));
		L.RegFunction("__eq", new LuaCSFunction(SkillBaseWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("enableParticle", new LuaCSFunction(SkillBaseWrap.get_enableParticle), new LuaCSFunction(SkillBaseWrap.set_enableParticle));
		L.RegVar("timestamp", new LuaCSFunction(SkillBaseWrap.get_timestamp), new LuaCSFunction(SkillBaseWrap.set_timestamp));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartSkill(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SkillBase skillBase = (SkillBase)ToLua.CheckObject(L, 1, typeof(SkillBase));
			float speed = (float)LuaDLL.luaL_checknumber(L, 2);
			skillBase.StartSkill(speed);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Find(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Transform parent = (Transform)ToLua.CheckUnityObject(L, 1, typeof(Transform));
			string childname = ToLua.CheckString(L, 2);
			Transform obj = SkillBase.Find(parent, childname);
			ToLua.Push(L, obj);
			result = 1;
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

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_enableParticle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkillBase skillBase = (SkillBase)obj;
			bool enableParticle = skillBase.enableParticle;
			LuaDLL.lua_pushboolean(L, enableParticle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index enableParticle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_timestamp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkillBase skillBase = (SkillBase)obj;
			int timestamp = skillBase.timestamp;
			LuaDLL.lua_pushinteger(L, timestamp);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index timestamp on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_enableParticle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkillBase skillBase = (SkillBase)obj;
			bool enableParticle = LuaDLL.luaL_checkboolean(L, 2);
			skillBase.enableParticle = enableParticle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index enableParticle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_timestamp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SkillBase skillBase = (SkillBase)obj;
			int timestamp = (int)LuaDLL.luaL_checknumber(L, 2);
			skillBase.timestamp = timestamp;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index timestamp on a nil value");
		}
		return result;
	}
}
