using LuaInterface;
using System;
using UnityEngine;

public class PositionSyncWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(PositionSync), typeof(MonoBehaviour), null);
		L.RegFunction("SetProtoInterval", new LuaCSFunction(PositionSyncWrap.SetProtoInterval));
		L.RegFunction("AddObjectPosition", new LuaCSFunction(PositionSyncWrap.AddObjectPosition));
		L.RegFunction("DeleteObjectPosition", new LuaCSFunction(PositionSyncWrap.DeleteObjectPosition));
		L.RegFunction("ResetObjectPosition", new LuaCSFunction(PositionSyncWrap.ResetObjectPosition));
		L.RegFunction("Clear", new LuaCSFunction(PositionSyncWrap.Clear));
		L.RegFunction("SyncSelfPosition", new LuaCSFunction(PositionSyncWrap.SyncSelfPosition));
		L.RegFunction("__eq", new LuaCSFunction(PositionSyncWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetProtoInterval(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PositionSync positionSync = (PositionSync)ToLua.CheckObject(L, 1, typeof(PositionSync));
			int protoInterval = (int)LuaDLL.luaL_checknumber(L, 2);
			positionSync.SetProtoInterval(protoInterval);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddObjectPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			PositionSync positionSync = (PositionSync)ToLua.CheckObject(L, 1, typeof(PositionSync));
			string id = ToLua.CheckString(L, 2);
			Vector3 pos = ToLua.ToVector3(L, 3);
			positionSync.AddObjectPosition(id, pos);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DeleteObjectPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			PositionSync positionSync = (PositionSync)ToLua.CheckObject(L, 1, typeof(PositionSync));
			string id = ToLua.CheckString(L, 2);
			positionSync.DeleteObjectPosition(id);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetObjectPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			PositionSync positionSync = (PositionSync)ToLua.CheckObject(L, 1, typeof(PositionSync));
			string id = ToLua.CheckString(L, 2);
			Vector3 pos = ToLua.ToVector3(L, 3);
			positionSync.ResetObjectPosition(id, pos);
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
			PositionSync positionSync = (PositionSync)ToLua.CheckObject(L, 1, typeof(PositionSync));
			positionSync.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SyncSelfPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			PositionSync.SyncSelfPosition();
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
