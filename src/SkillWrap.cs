using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Skill), typeof(SkillBase), null);
		L.RegFunction("__eq", new LuaCSFunction(SkillWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("startGo", new LuaCSFunction(SkillWrap.get_startGo), new LuaCSFunction(SkillWrap.set_startGo));
		L.RegVar("targetGo", new LuaCSFunction(SkillWrap.get_targetGo), new LuaCSFunction(SkillWrap.set_targetGo));
		L.RegVar("targetGos", new LuaCSFunction(SkillWrap.get_targetGos), new LuaCSFunction(SkillWrap.set_targetGos));
		L.RegVar("onDestory", new LuaCSFunction(SkillWrap.get_onDestory), new LuaCSFunction(SkillWrap.set_onDestory));
		L.RegVar("targetPos", new LuaCSFunction(SkillWrap.get_targetPos), new LuaCSFunction(SkillWrap.set_targetPos));
		L.RegVar("needFeedback", new LuaCSFunction(SkillWrap.get_needFeedback), new LuaCSFunction(SkillWrap.set_needFeedback));
		L.RegVar("needDestoryCastSkill", new LuaCSFunction(SkillWrap.get_needDestoryCastSkill), new LuaCSFunction(SkillWrap.set_needDestoryCastSkill));
		L.EndClass();
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
	private static int get_startGo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Skill skill = (Skill)obj;
			GameObject startGo = skill.startGo;
			ToLua.Push(L, startGo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index startGo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetGo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Skill skill = (Skill)obj;
			GameObject targetGo = skill.targetGo;
			ToLua.Push(L, targetGo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetGo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetGos(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Skill skill = (Skill)obj;
			List<GameObject> targetGos = skill.targetGos;
			ToLua.PushObject(L, targetGos);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetGos on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onDestory(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Skill skill = (Skill)obj;
			Action<bool> onDestory = skill.onDestory;
			ToLua.Push(L, onDestory);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDestory on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_targetPos(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Skill skill = (Skill)obj;
			Vector3 targetPos = skill.targetPos;
			ToLua.Push(L, targetPos);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetPos on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_needFeedback(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Skill skill = (Skill)obj;
			bool needFeedback = skill.needFeedback;
			LuaDLL.lua_pushboolean(L, needFeedback);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index needFeedback on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_needDestoryCastSkill(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Skill skill = (Skill)obj;
			bool needDestoryCastSkill = skill.needDestoryCastSkill;
			LuaDLL.lua_pushboolean(L, needDestoryCastSkill);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index needDestoryCastSkill on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_startGo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Skill skill = (Skill)obj;
			GameObject startGo = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			skill.startGo = startGo;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index startGo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_targetGo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Skill skill = (Skill)obj;
			GameObject targetGo = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			skill.targetGo = targetGo;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetGo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_targetGos(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Skill skill = (Skill)obj;
			List<GameObject> targetGos = (List<GameObject>)ToLua.CheckObject(L, 2, typeof(List<GameObject>));
			skill.targetGos = targetGos;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetGos on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onDestory(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Skill skill = (Skill)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<bool> onDestory;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onDestory = (Action<bool>)ToLua.CheckObject(L, 2, typeof(Action<bool>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onDestory = (DelegateFactory.CreateDelegate(typeof(Action<bool>), func) as Action<bool>);
			}
			skill.onDestory = onDestory;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onDestory on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_targetPos(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Skill skill = (Skill)obj;
			Vector3 targetPos = ToLua.ToVector3(L, 2);
			skill.targetPos = targetPos;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index targetPos on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_needFeedback(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Skill skill = (Skill)obj;
			bool needFeedback = LuaDLL.luaL_checkboolean(L, 2);
			skill.needFeedback = needFeedback;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index needFeedback on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_needDestoryCastSkill(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Skill skill = (Skill)obj;
			bool needDestoryCastSkill = LuaDLL.luaL_checkboolean(L, 2);
			skill.needDestoryCastSkill = needDestoryCastSkill;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index needDestoryCastSkill on a nil value");
		}
		return result;
	}
}
