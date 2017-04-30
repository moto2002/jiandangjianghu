using Aoi;
using LuaInterface;
using System;

public class Aoi_S2c_aoi_syncnpcWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(S2c_aoi_syncnpc), typeof(object), null);
		L.RegFunction("New", new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap._CreateAoi_S2c_aoi_syncnpc));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("buff", new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.get_buff), new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.set_buff));
		L.RegVar("canattk", new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.get_canattk), new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.set_canattk));
		L.RegVar("comp", new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.get_comp), new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.set_comp));
		L.RegVar("dir", new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.get_dir), new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.set_dir));
		L.RegVar("extend", new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.get_extend), new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.set_extend));
		L.RegVar("grade", new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.get_grade), new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.set_grade));
		L.RegVar("name", new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.get_name), new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.set_name));
		L.RegVar("rid", new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.get_rid), new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.set_rid));
		L.RegVar("shape", new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.get_shape), new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.set_shape));
		L.RegVar("shield_hp", new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.get_shield_hp), new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.set_shield_hp));
		L.RegVar("shield_hpmax", new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.get_shield_hpmax), new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.set_shield_hpmax));
		L.RegVar("shield_buffid", new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.get_shield_buffid), new LuaCSFunction(Aoi_S2c_aoi_syncnpcWrap.set_shield_buffid));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAoi_S2c_aoi_syncnpc(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				S2c_aoi_syncnpc o = new S2c_aoi_syncnpc();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Aoi.S2c_aoi_syncnpc.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_buff(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			LuaTable buff = s2c_aoi_syncnpc.buff;
			ToLua.Push(L, buff);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index buff on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_canattk(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int canattk = s2c_aoi_syncnpc.canattk;
			LuaDLL.lua_pushinteger(L, canattk);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canattk on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_comp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int comp = s2c_aoi_syncnpc.comp;
			LuaDLL.lua_pushinteger(L, comp);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index comp on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dir(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int dir = s2c_aoi_syncnpc.dir;
			LuaDLL.lua_pushinteger(L, dir);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dir on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_extend(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			string extend = s2c_aoi_syncnpc.extend;
			LuaDLL.lua_pushstring(L, extend);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index extend on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_grade(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int grade = s2c_aoi_syncnpc.grade;
			LuaDLL.lua_pushinteger(L, grade);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index grade on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_name(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			string name = s2c_aoi_syncnpc.name;
			LuaDLL.lua_pushstring(L, name);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index name on a nil value");
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
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			string rid = s2c_aoi_syncnpc.rid;
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
	private static int get_shape(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int shape = s2c_aoi_syncnpc.shape;
			LuaDLL.lua_pushinteger(L, shape);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shape on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shield_hp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int shield_hp = s2c_aoi_syncnpc.shield_hp;
			LuaDLL.lua_pushinteger(L, shield_hp);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shield_hp on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shield_hpmax(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int shield_hpmax = s2c_aoi_syncnpc.shield_hpmax;
			LuaDLL.lua_pushinteger(L, shield_hpmax);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shield_hpmax on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shield_buffid(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int shield_buffid = s2c_aoi_syncnpc.shield_buffid;
			LuaDLL.lua_pushinteger(L, shield_buffid);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shield_buffid on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_buff(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			LuaTable buff = ToLua.CheckLuaTable(L, 2);
			s2c_aoi_syncnpc.buff = buff;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index buff on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_canattk(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int canattk = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncnpc.canattk = canattk;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canattk on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_comp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int comp = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncnpc.comp = comp;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index comp on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_dir(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int dir = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncnpc.dir = dir;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dir on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_extend(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			string extend = ToLua.CheckString(L, 2);
			s2c_aoi_syncnpc.extend = extend;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index extend on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_grade(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int grade = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncnpc.grade = grade;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index grade on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_name(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			string name = ToLua.CheckString(L, 2);
			s2c_aoi_syncnpc.name = name;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index name on a nil value");
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
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			string rid = ToLua.CheckString(L, 2);
			s2c_aoi_syncnpc.rid = rid;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rid on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shape(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int shape = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncnpc.shape = shape;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shape on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shield_hp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int shield_hp = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncnpc.shield_hp = shield_hp;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shield_hp on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shield_hpmax(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int shield_hpmax = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncnpc.shield_hpmax = shield_hpmax;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shield_hpmax on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shield_buffid(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncnpc s2c_aoi_syncnpc = (S2c_aoi_syncnpc)obj;
			int shield_buffid = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncnpc.shield_buffid = shield_buffid;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shield_buffid on a nil value");
		}
		return result;
	}
}
