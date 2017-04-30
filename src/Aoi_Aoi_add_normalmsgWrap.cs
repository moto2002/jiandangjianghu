using Aoi;
using LuaInterface;
using System;

public class Aoi_Aoi_add_normalmsgWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Aoi_add_normalmsg), typeof(object), null);
		L.RegFunction("New", new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap._CreateAoi_Aoi_add_normalmsg));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("char_no", new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.get_char_no), new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.set_char_no));
		L.RegVar("hp", new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.get_hp), new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.set_hp));
		L.RegVar("hpmax", new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.get_hpmax), new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.set_hpmax));
		L.RegVar("map_id", new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.get_map_id), new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.set_map_id));
		L.RegVar("map_no", new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.get_map_no), new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.set_map_no));
		L.RegVar("rid", new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.get_rid), new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.set_rid));
		L.RegVar("x", new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.get_x), new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.set_x));
		L.RegVar("y", new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.get_y), new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.set_y));
		L.RegVar("z", new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.get_z), new LuaCSFunction(Aoi_Aoi_add_normalmsgWrap.set_z));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAoi_Aoi_add_normalmsg(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Aoi_add_normalmsg o = new Aoi_add_normalmsg();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Aoi.Aoi_add_normalmsg.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_char_no(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			int char_no = aoi_add_normalmsg.char_no;
			LuaDLL.lua_pushinteger(L, char_no);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index char_no on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			int hp = aoi_add_normalmsg.hp;
			LuaDLL.lua_pushinteger(L, hp);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hp on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hpmax(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			int hpmax = aoi_add_normalmsg.hpmax;
			LuaDLL.lua_pushinteger(L, hpmax);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hpmax on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_map_id(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			int map_id = aoi_add_normalmsg.map_id;
			LuaDLL.lua_pushinteger(L, map_id);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index map_id on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_map_no(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			int map_no = aoi_add_normalmsg.map_no;
			LuaDLL.lua_pushinteger(L, map_no);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index map_no on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rid(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			string rid = aoi_add_normalmsg.rid;
			LuaDLL.lua_pushstring(L, rid);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rid on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_x(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			int x = aoi_add_normalmsg.x;
			LuaDLL.lua_pushinteger(L, x);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index x on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_y(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			float y = aoi_add_normalmsg.y;
			LuaDLL.lua_pushnumber(L, (double)y);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index y on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_z(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			int z = aoi_add_normalmsg.z;
			LuaDLL.lua_pushinteger(L, z);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index z on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_char_no(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			int char_no = (int)LuaDLL.luaL_checknumber(L, 2);
			aoi_add_normalmsg.char_no = char_no;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index char_no on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			int hp = (int)LuaDLL.luaL_checknumber(L, 2);
			aoi_add_normalmsg.hp = hp;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hp on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hpmax(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			int hpmax = (int)LuaDLL.luaL_checknumber(L, 2);
			aoi_add_normalmsg.hpmax = hpmax;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hpmax on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_map_id(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			int map_id = (int)LuaDLL.luaL_checknumber(L, 2);
			aoi_add_normalmsg.map_id = map_id;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index map_id on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_map_no(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			int map_no = (int)LuaDLL.luaL_checknumber(L, 2);
			aoi_add_normalmsg.map_no = map_no;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index map_no on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rid(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			string rid = ToLua.CheckString(L, 2);
			aoi_add_normalmsg.rid = rid;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rid on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_x(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			int x = (int)LuaDLL.luaL_checknumber(L, 2);
			aoi_add_normalmsg.x = x;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index x on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_y(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			float y = (float)LuaDLL.luaL_checknumber(L, 2);
			aoi_add_normalmsg.y = y;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index y on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_z(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Aoi_add_normalmsg aoi_add_normalmsg = (Aoi_add_normalmsg)obj;
			int z = (int)LuaDLL.luaL_checknumber(L, 2);
			aoi_add_normalmsg.z = z;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index z on a nil value");
		}
		return result;
	}
}
