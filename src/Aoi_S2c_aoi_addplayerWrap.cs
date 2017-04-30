using Aoi;
using LuaInterface;
using System;

public class Aoi_S2c_aoi_addplayerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(S2c_aoi_addplayer), typeof(object), null);
		L.RegFunction("New", new LuaCSFunction(Aoi_S2c_aoi_addplayerWrap._CreateAoi_S2c_aoi_addplayer));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("nmsg", new LuaCSFunction(Aoi_S2c_aoi_addplayerWrap.get_nmsg), new LuaCSFunction(Aoi_S2c_aoi_addplayerWrap.set_nmsg));
		L.RegVar("sync", new LuaCSFunction(Aoi_S2c_aoi_addplayerWrap.get_sync), new LuaCSFunction(Aoi_S2c_aoi_addplayerWrap.set_sync));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAoi_S2c_aoi_addplayer(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				S2c_aoi_addplayer o = new S2c_aoi_addplayer();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Aoi.S2c_aoi_addplayer.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_nmsg(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_addplayer s2c_aoi_addplayer = (S2c_aoi_addplayer)obj;
			Aoi_add_normalmsg nmsg = s2c_aoi_addplayer.nmsg;
			ToLua.PushObject(L, nmsg);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index nmsg on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sync(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_addplayer s2c_aoi_addplayer = (S2c_aoi_addplayer)obj;
			S2c_aoi_syncplayer sync = s2c_aoi_addplayer.sync;
			ToLua.PushObject(L, sync);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sync on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_nmsg(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_addplayer s2c_aoi_addplayer = (S2c_aoi_addplayer)obj;
			Aoi_add_normalmsg nmsg = (Aoi_add_normalmsg)ToLua.CheckObject(L, 2, typeof(Aoi_add_normalmsg));
			s2c_aoi_addplayer.nmsg = nmsg;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index nmsg on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sync(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_addplayer s2c_aoi_addplayer = (S2c_aoi_addplayer)obj;
			S2c_aoi_syncplayer sync = (S2c_aoi_syncplayer)ToLua.CheckObject(L, 2, typeof(S2c_aoi_syncplayer));
			s2c_aoi_addplayer.sync = sync;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sync on a nil value");
		}
		return result;
	}
}
