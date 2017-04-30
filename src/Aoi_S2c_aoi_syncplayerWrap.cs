using Aoi;
using LuaInterface;
using System;

public class Aoi_S2c_aoi_syncplayerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(S2c_aoi_syncplayer), typeof(object), null);
		L.RegFunction("New", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap._CreateAoi_S2c_aoi_syncplayer));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("adname", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_adname), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_adname));
		L.RegVar("speed", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_speed), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_speed));
		L.RegVar("buff", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_buff), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_buff));
		L.RegVar("comp", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_comp), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_comp));
		L.RegVar("extend", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_extend), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_extend));
		L.RegVar("fashion", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_fashion), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_fashion));
		L.RegVar("dir360", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_dir360), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_dir360));
		L.RegVar("grade", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_grade), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_grade));
		L.RegVar("name", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_name), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_name));
		L.RegVar("rid", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_rid), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_rid));
		L.RegVar("setno", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_setno), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_setno));
		L.RegVar("shape", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_shape), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_shape));
		L.RegVar("teamids", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_teamids), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_teamids));
		L.RegVar("weapon", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_weapon), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_weapon));
		L.RegVar("magic", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_magic), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_magic));
		L.RegVar("partner", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_partner), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_partner));
		L.RegVar("pkinfo", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_pkinfo), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_pkinfo));
		L.RegVar("sex", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_sex), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_sex));
		L.RegVar("up_mount", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_up_mount), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_up_mount));
		L.RegVar("up_horse", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_up_horse), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_up_horse));
		L.RegVar("mount_model", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_mount_model), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_mount_model));
		L.RegVar("partnerhorse_model", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_partnerhorse_model), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_partnerhorse_model));
		L.RegVar("lingqin_model", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_lingqin_model), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_lingqin_model));
		L.RegVar("lingyi_model", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_lingyi_model), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_lingyi_model));
		L.RegVar("pet_model", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_pet_model), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_pet_model));
		L.RegVar("shenjian_model", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_shenjian_model), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_shenjian_model));
		L.RegVar("shenyi_model", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_shenyi_model), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_shenyi_model));
		L.RegVar("jingmai_model", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_jingmai_model), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_jingmai_model));
		L.RegVar("score", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_score), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_score));
		L.RegVar("dazuo", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_dazuo), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_dazuo));
		L.RegVar("isyunbiao", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_isyunbiao), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_isyunbiao));
		L.RegVar("clubname", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_clubname), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_clubname));
		L.RegVar("clubpost", new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.get_clubpost), new LuaCSFunction(Aoi_S2c_aoi_syncplayerWrap.set_clubpost));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateAoi_S2c_aoi_syncplayer(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				S2c_aoi_syncplayer o = new S2c_aoi_syncplayer();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Aoi.S2c_aoi_syncplayer.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_adname(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string adname = s2c_aoi_syncplayer.adname;
			LuaDLL.lua_pushstring(L, adname);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index adname on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_speed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			float speed = s2c_aoi_syncplayer.speed;
			LuaDLL.lua_pushnumber(L, (double)speed);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index speed on a nil value");
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
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			LuaTable buff = s2c_aoi_syncplayer.buff;
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
	private static int get_comp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int comp = s2c_aoi_syncplayer.comp;
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
	private static int get_extend(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string extend = s2c_aoi_syncplayer.extend;
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
	private static int get_fashion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int fashion = s2c_aoi_syncplayer.fashion;
			LuaDLL.lua_pushinteger(L, fashion);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fashion on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dir360(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int dir = s2c_aoi_syncplayer.dir360;
			LuaDLL.lua_pushinteger(L, dir);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dir360 on a nil value");
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
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int grade = s2c_aoi_syncplayer.grade;
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
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string name = s2c_aoi_syncplayer.name;
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
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string rid = s2c_aoi_syncplayer.rid;
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
	private static int get_setno(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int setno = s2c_aoi_syncplayer.setno;
			LuaDLL.lua_pushinteger(L, setno);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index setno on a nil value");
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
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int shape = s2c_aoi_syncplayer.shape;
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
	private static int get_teamids(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string teamids = s2c_aoi_syncplayer.teamids;
			LuaDLL.lua_pushstring(L, teamids);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index teamids on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_weapon(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int weapon = s2c_aoi_syncplayer.weapon;
			LuaDLL.lua_pushinteger(L, weapon);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index weapon on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_magic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string magic = s2c_aoi_syncplayer.magic;
			LuaDLL.lua_pushstring(L, magic);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index magic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_partner(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string partner = s2c_aoi_syncplayer.partner;
			LuaDLL.lua_pushstring(L, partner);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partner on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pkinfo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string pkinfo = s2c_aoi_syncplayer.pkinfo;
			LuaDLL.lua_pushstring(L, pkinfo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pkinfo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int sex = s2c_aoi_syncplayer.sex;
			LuaDLL.lua_pushinteger(L, sex);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_up_mount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int up_mount = s2c_aoi_syncplayer.up_mount;
			LuaDLL.lua_pushinteger(L, up_mount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index up_mount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_up_horse(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int up_horse = s2c_aoi_syncplayer.up_horse;
			LuaDLL.lua_pushinteger(L, up_horse);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index up_horse on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mount_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int mount_model = s2c_aoi_syncplayer.mount_model;
			LuaDLL.lua_pushinteger(L, mount_model);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mount_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_partnerhorse_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int partnerhorse_model = s2c_aoi_syncplayer.partnerhorse_model;
			LuaDLL.lua_pushinteger(L, partnerhorse_model);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partnerhorse_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lingqin_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int lingqin_model = s2c_aoi_syncplayer.lingqin_model;
			LuaDLL.lua_pushinteger(L, lingqin_model);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingqin_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lingyi_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int lingyi_model = s2c_aoi_syncplayer.lingyi_model;
			LuaDLL.lua_pushinteger(L, lingyi_model);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingyi_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pet_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int pet_model = s2c_aoi_syncplayer.pet_model;
			LuaDLL.lua_pushinteger(L, pet_model);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pet_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shenjian_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int shenjian_model = s2c_aoi_syncplayer.shenjian_model;
			LuaDLL.lua_pushinteger(L, shenjian_model);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shenjian_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shenyi_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int shenyi_model = s2c_aoi_syncplayer.shenyi_model;
			LuaDLL.lua_pushinteger(L, shenyi_model);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shenyi_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_jingmai_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int jingmai_model = s2c_aoi_syncplayer.jingmai_model;
			LuaDLL.lua_pushinteger(L, jingmai_model);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jingmai_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_score(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int score = s2c_aoi_syncplayer.score;
			LuaDLL.lua_pushinteger(L, score);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index score on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dazuo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int dazuo = s2c_aoi_syncplayer.dazuo;
			LuaDLL.lua_pushinteger(L, dazuo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dazuo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isyunbiao(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int isyunbiao = s2c_aoi_syncplayer.isyunbiao;
			LuaDLL.lua_pushinteger(L, isyunbiao);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isyunbiao on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clubname(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string clubname = s2c_aoi_syncplayer.clubname;
			LuaDLL.lua_pushstring(L, clubname);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clubname on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clubpost(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string clubpost = s2c_aoi_syncplayer.clubpost;
			LuaDLL.lua_pushstring(L, clubpost);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clubpost on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_adname(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string adname = ToLua.CheckString(L, 2);
			s2c_aoi_syncplayer.adname = adname;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index adname on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_speed(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			float speed = (float)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.speed = speed;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index speed on a nil value");
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
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			LuaTable buff = ToLua.CheckLuaTable(L, 2);
			s2c_aoi_syncplayer.buff = buff;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index buff on a nil value");
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
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int comp = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.comp = comp;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index comp on a nil value");
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
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string extend = ToLua.CheckString(L, 2);
			s2c_aoi_syncplayer.extend = extend;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index extend on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fashion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int fashion = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.fashion = fashion;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fashion on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_dir360(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int dir = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.dir360 = dir;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dir360 on a nil value");
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
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int grade = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.grade = grade;
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
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string name = ToLua.CheckString(L, 2);
			s2c_aoi_syncplayer.name = name;
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
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string rid = ToLua.CheckString(L, 2);
			s2c_aoi_syncplayer.rid = rid;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rid on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_setno(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int setno = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.setno = setno;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index setno on a nil value");
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
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int shape = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.shape = shape;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shape on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_teamids(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string teamids = ToLua.CheckString(L, 2);
			s2c_aoi_syncplayer.teamids = teamids;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index teamids on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_weapon(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int weapon = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.weapon = weapon;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index weapon on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_magic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string magic = ToLua.CheckString(L, 2);
			s2c_aoi_syncplayer.magic = magic;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index magic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_partner(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string partner = ToLua.CheckString(L, 2);
			s2c_aoi_syncplayer.partner = partner;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partner on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pkinfo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string pkinfo = ToLua.CheckString(L, 2);
			s2c_aoi_syncplayer.pkinfo = pkinfo;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pkinfo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int sex = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.sex = sex;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_up_mount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int up_mount = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.up_mount = up_mount;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index up_mount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_up_horse(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int up_horse = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.up_horse = up_horse;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index up_horse on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mount_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int mount_model = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.mount_model = mount_model;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mount_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_partnerhorse_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int partnerhorse_model = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.partnerhorse_model = partnerhorse_model;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partnerhorse_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lingqin_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int lingqin_model = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.lingqin_model = lingqin_model;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingqin_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lingyi_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int lingyi_model = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.lingyi_model = lingyi_model;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingyi_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pet_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int pet_model = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.pet_model = pet_model;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pet_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shenjian_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int shenjian_model = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.shenjian_model = shenjian_model;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shenjian_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shenyi_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int shenyi_model = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.shenyi_model = shenyi_model;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shenyi_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_jingmai_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int jingmai_model = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.jingmai_model = jingmai_model;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jingmai_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_score(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int score = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.score = score;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index score on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_dazuo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int dazuo = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.dazuo = dazuo;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dazuo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isyunbiao(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			int isyunbiao = (int)LuaDLL.luaL_checknumber(L, 2);
			s2c_aoi_syncplayer.isyunbiao = isyunbiao;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isyunbiao on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clubname(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string clubname = ToLua.CheckString(L, 2);
			s2c_aoi_syncplayer.clubname = clubname;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clubname on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clubpost(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			S2c_aoi_syncplayer s2c_aoi_syncplayer = (S2c_aoi_syncplayer)obj;
			string clubpost = ToLua.CheckString(L, 2);
			s2c_aoi_syncplayer.clubpost = clubpost;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clubpost on a nil value");
		}
		return result;
	}
}
