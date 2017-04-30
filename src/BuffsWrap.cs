using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BuffsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Buffs), typeof(MonoBehaviour), null);
		L.RegFunction("AddBuff", new LuaCSFunction(BuffsWrap.AddBuff));
		L.RegFunction("RemoveBuff", new LuaCSFunction(BuffsWrap.RemoveBuff));
		L.RegFunction("__eq", new LuaCSFunction(BuffsWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("buffs", new LuaCSFunction(BuffsWrap.get_buffs), new LuaCSFunction(BuffsWrap.set_buffs));
		L.RegVar("buff_ids", new LuaCSFunction(BuffsWrap.get_buff_ids), new LuaCSFunction(BuffsWrap.set_buff_ids));
		L.RegVar("lastStatusEff", new LuaCSFunction(BuffsWrap.get_lastStatusEff), new LuaCSFunction(BuffsWrap.set_lastStatusEff));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddBuff(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Buffs buffs = (Buffs)ToLua.CheckObject(L, 1, typeof(Buffs));
			int buff_id = (int)LuaDLL.luaL_checknumber(L, 2);
			int buffEffId = (int)LuaDLL.luaL_checknumber(L, 3);
			buffs.AddBuff(buff_id, buffEffId);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveBuff(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Buffs buffs = (Buffs)ToLua.CheckObject(L, 1, typeof(Buffs));
			int buff_id = (int)LuaDLL.luaL_checknumber(L, 2);
			buffs.RemoveBuff(buff_id);
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

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_buffs(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Buffs buffs = (Buffs)obj;
			Dictionary<int, GameObject> buffs2 = buffs.buffs;
			ToLua.PushObject(L, buffs2);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index buffs on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_buff_ids(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Buffs buffs = (Buffs)obj;
			List<int> buff_ids = buffs.buff_ids;
			ToLua.PushObject(L, buff_ids);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index buff_ids on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lastStatusEff(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Buffs buffs = (Buffs)obj;
			int lastStatusEff = buffs.lastStatusEff;
			LuaDLL.lua_pushinteger(L, lastStatusEff);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lastStatusEff on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_buffs(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Buffs buffs = (Buffs)obj;
			Dictionary<int, GameObject> buffs2 = (Dictionary<int, GameObject>)ToLua.CheckObject(L, 2, typeof(Dictionary<int, GameObject>));
			buffs.buffs = buffs2;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index buffs on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_buff_ids(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Buffs buffs = (Buffs)obj;
			List<int> buff_ids = (List<int>)ToLua.CheckObject(L, 2, typeof(List<int>));
			buffs.buff_ids = buff_ids;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index buff_ids on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lastStatusEff(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Buffs buffs = (Buffs)obj;
			int lastStatusEff = (int)LuaDLL.luaL_checknumber(L, 2);
			buffs.lastStatusEff = lastStatusEff;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lastStatusEff on a nil value");
		}
		return result;
	}
}
