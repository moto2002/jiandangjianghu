using LuaInterface;
using System;
using UnityEngine;

public class HorseWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Horse), typeof(MonoBehaviour), null);
		L.RegFunction("SetHorseData", new LuaCSFunction(HorseWrap.SetHorseData));
		L.RegFunction("RideHorse", new LuaCSFunction(HorseWrap.RideHorse));
		L.RegFunction("ChangeHorse", new LuaCSFunction(HorseWrap.ChangeHorse));
		L.RegFunction("Recycle", new LuaCSFunction(HorseWrap.Recycle));
		L.RegFunction("__eq", new LuaCSFunction(HorseWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("horseParticle", new LuaCSFunction(HorseWrap.get_horseParticle), new LuaCSFunction(HorseWrap.set_horseParticle));
		L.RegVar("ridePosition", new LuaCSFunction(HorseWrap.get_ridePosition), new LuaCSFunction(HorseWrap.set_ridePosition));
		L.RegVar("id", new LuaCSFunction(HorseWrap.get_id), new LuaCSFunction(HorseWrap.set_id));
		L.RegVar("horseGo", new LuaCSFunction(HorseWrap.get_horseGo), new LuaCSFunction(HorseWrap.set_horseGo));
		L.RegVar("rideRunAudioName", new LuaCSFunction(HorseWrap.get_rideRunAudioName), new LuaCSFunction(HorseWrap.set_rideRunAudioName));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetHorseData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			Horse horse = (Horse)ToLua.CheckObject(L, 1, typeof(Horse));
			float x = (float)LuaDLL.luaL_checknumber(L, 2);
			float y = (float)LuaDLL.luaL_checknumber(L, 3);
			float z = (float)LuaDLL.luaL_checknumber(L, 4);
			string rideRunAudio = ToLua.CheckString(L, 5);
			horse.SetHorseData(x, y, z, rideRunAudio);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RideHorse(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Horse horse = (Horse)ToLua.CheckObject(L, 1, typeof(Horse));
			bool ride = LuaDLL.luaL_checkboolean(L, 2);
			horse.RideHorse(ride);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangeHorse(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Horse horse = (Horse)ToLua.CheckObject(L, 1, typeof(Horse));
			int horseId = (int)LuaDLL.luaL_checknumber(L, 2);
			horse.ChangeHorse(horseId);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Recycle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Horse horse = (Horse)ToLua.CheckObject(L, 1, typeof(Horse));
			horse.Recycle();
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
	private static int get_horseParticle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Horse horse = (Horse)obj;
			GameObject horseParticle = horse.horseParticle;
			ToLua.Push(L, horseParticle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horseParticle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ridePosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Horse horse = (Horse)obj;
			Vector3 ridePosition = horse.ridePosition;
			ToLua.Push(L, ridePosition);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ridePosition on a nil value");
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
			Horse horse = (Horse)obj;
			int id = horse.id;
			LuaDLL.lua_pushinteger(L, id);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index id on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_horseGo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Horse horse = (Horse)obj;
			GameObject horseGo = horse.horseGo;
			ToLua.Push(L, horseGo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horseGo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rideRunAudioName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Horse horse = (Horse)obj;
			string rideRunAudioName = horse.rideRunAudioName;
			LuaDLL.lua_pushstring(L, rideRunAudioName);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rideRunAudioName on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_horseParticle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Horse horse = (Horse)obj;
			GameObject horseParticle = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			horse.horseParticle = horseParticle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horseParticle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ridePosition(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Horse horse = (Horse)obj;
			Vector3 ridePosition = ToLua.ToVector3(L, 2);
			horse.ridePosition = ridePosition;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ridePosition on a nil value");
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
			Horse horse = (Horse)obj;
			int id = (int)LuaDLL.luaL_checknumber(L, 2);
			horse.id = id;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index id on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_horseGo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Horse horse = (Horse)obj;
			GameObject horseGo = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			horse.horseGo = horseGo;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horseGo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rideRunAudioName(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Horse horse = (Horse)obj;
			string rideRunAudioName = ToLua.CheckString(L, 2);
			horse.rideRunAudioName = rideRunAudioName;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rideRunAudioName on a nil value");
		}
		return result;
	}
}
