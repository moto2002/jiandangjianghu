using Aoi;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EntityCreateWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(EntityCreate), typeof(MonoBehaviour), null);
		L.RegFunction("InitilizeSelfEntity", new LuaCSFunction(EntityCreateWrap.InitilizeSelfEntity));
		L.RegFunction("AddFastShadow", new LuaCSFunction(EntityCreateWrap.AddFastShadow));
		L.RegFunction("CreateLingqi", new LuaCSFunction(EntityCreateWrap.CreateLingqi));
		L.RegFunction("CreatePartner", new LuaCSFunction(EntityCreateWrap.CreatePartner));
		L.RegFunction("CreatePet", new LuaCSFunction(EntityCreateWrap.CreatePet));
		L.RegFunction("CreateBeauty", new LuaCSFunction(EntityCreateWrap.CreateBeauty));
		L.RegFunction("CreateAider", new LuaCSFunction(EntityCreateWrap.CreateAider));
		L.RegFunction("CreateXunLuoNpcs", new LuaCSFunction(EntityCreateWrap.CreateXunLuoNpcs));
		L.RegFunction("DelayAddPlayerAndNpc", new LuaCSFunction(EntityCreateWrap.DelayAddPlayerAndNpc));
		L.RegFunction("DelayAddSelf", new LuaCSFunction(EntityCreateWrap.DelayAddSelf));
		L.RegFunction("AddEntityCreateEventListener", new LuaCSFunction(EntityCreateWrap.AddEntityCreateEventListener));
		L.RegFunction("RemoveEntityCreateEventListener", new LuaCSFunction(EntityCreateWrap.RemoveEntityCreateEventListener));
		L.RegFunction("AddPlayer", new LuaCSFunction(EntityCreateWrap.AddPlayer));
		L.RegFunction("AddHero", new LuaCSFunction(EntityCreateWrap.AddHero));
		L.RegFunction("AddNpc", new LuaCSFunction(EntityCreateWrap.AddNpc));
		L.RegFunction("AddAider", new LuaCSFunction(EntityCreateWrap.AddAider));
		L.RegFunction("ClearWhenChangeScene", new LuaCSFunction(EntityCreateWrap.ClearWhenChangeScene));
		L.RegFunction("Clear", new LuaCSFunction(EntityCreateWrap.Clear));
		L.RegFunction("DeleteObjectsById", new LuaCSFunction(EntityCreateWrap.DeleteObjectsById));
		L.RegFunction("__eq", new LuaCSFunction(EntityCreateWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("_mainRole", new LuaCSFunction(EntityCreateWrap.get__mainRole), null);
		L.RegVar("_needDeleteNpcs", new LuaCSFunction(EntityCreateWrap.get__needDeleteNpcs), null);
		L.RegVar("_players", new LuaCSFunction(EntityCreateWrap.get__players), null);
		L.RegVar("_npcs", new LuaCSFunction(EntityCreateWrap.get__npcs), null);
		L.RegVar("_heroInfo", new LuaCSFunction(EntityCreateWrap.get__heroInfo), null);
		L.RegVar("_aiderInfo", new LuaCSFunction(EntityCreateWrap.get__aiderInfo), null);
		L.RegVar("isInAsynceLoad", new LuaCSFunction(EntityCreateWrap.get_isInAsynceLoad), null);
		L.RegVar("hidePlayer", new LuaCSFunction(EntityCreateWrap.get_hidePlayer), new LuaCSFunction(EntityCreateWrap.set_hidePlayer));
		L.RegVar("positionSync", new LuaCSFunction(EntityCreateWrap.get_positionSync), new LuaCSFunction(EntityCreateWrap.set_positionSync));
		L.RegVar("cf", new LuaCSFunction(EntityCreateWrap.get_cf), null);
		L.RegFunction("OnRoleCreated", new LuaCSFunction(EntityCreateWrap.EntityCreate_OnRoleCreated));
		L.RegFunction("OnNpcCreated", new LuaCSFunction(EntityCreateWrap.EntityCreate_OnNpcCreated));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InitilizeSelfEntity(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			Aoi_add_normalmsg nmsg = (Aoi_add_normalmsg)ToLua.CheckObject(L, 2, typeof(Aoi_add_normalmsg));
			S2c_aoi_syncplayer sync = (S2c_aoi_syncplayer)ToLua.CheckObject(L, 3, typeof(S2c_aoi_syncplayer));
			string name = ToLua.CheckString(L, 4);
			GameObject obj = entityCreate.InitilizeSelfEntity(nmsg, sync, name);
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
	private static int AddFastShadow(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			GameObject model = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			RoleManager.EntityType type = (RoleManager.EntityType)((int)ToLua.CheckObject(L, 3, typeof(RoleManager.EntityType)));
			entityCreate.AddFastShadow(model, type);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateLingqi(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			SceneEntity playerObj = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			string lingqiStr = ToLua.CheckString(L, 3);
			entityCreate.CreateLingqi(playerObj, lingqiStr);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreatePartner(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			SceneEntity playerObj = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			string partnerStr = ToLua.CheckString(L, 3);
			entityCreate.CreatePartner(playerObj, partnerStr);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreatePet(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			SceneEntity playerObj = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			int pet = (int)LuaDLL.luaL_checknumber(L, 3);
			entityCreate.CreatePet(playerObj, pet);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateBeauty(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			SceneEntity playerObj = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			int yunbiao = (int)LuaDLL.luaL_checknumber(L, 3);
			entityCreate.CreateBeauty(playerObj, yunbiao);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateAider(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			string model = ToLua.CheckString(L, 2);
			string posStr = ToLua.CheckString(L, 3);
			int dir = (int)LuaDLL.luaL_checknumber(L, 4);
			entityCreate.CreateAider(model, posStr, dir);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateXunLuoNpcs(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			LuaTable table = ToLua.CheckLuaTable(L, 2);
			entityCreate.CreateXunLuoNpcs(table);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DelayAddPlayerAndNpc(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			entityCreate.DelayAddPlayerAndNpc();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DelayAddSelf(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			entityCreate.DelayAddSelf();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddEntityCreateEventListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			string name = ToLua.CheckString(L, 2);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			EntityCreate.OnRoleCreated callback;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				callback = (EntityCreate.OnRoleCreated)ToLua.CheckObject(L, 3, typeof(EntityCreate.OnRoleCreated));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				callback = (DelegateFactory.CreateDelegate(typeof(EntityCreate.OnRoleCreated), func) as EntityCreate.OnRoleCreated);
			}
			LuaTypes luaTypes2 = LuaDLL.lua_type(L, 4);
			EntityCreate.OnNpcCreated callback2;
			if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
			{
				callback2 = (EntityCreate.OnNpcCreated)ToLua.CheckObject(L, 4, typeof(EntityCreate.OnNpcCreated));
			}
			else
			{
				LuaFunction func2 = ToLua.ToLuaFunction(L, 4);
				callback2 = (DelegateFactory.CreateDelegate(typeof(EntityCreate.OnNpcCreated), func2) as EntityCreate.OnNpcCreated);
			}
			entityCreate.AddEntityCreateEventListener(name, callback, callback2);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveEntityCreateEventListener(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			string name = ToLua.CheckString(L, 2);
			entityCreate.RemoveEntityCreateEventListener(name);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddPlayer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			S2c_aoi_addplayer cmd = (S2c_aoi_addplayer)ToLua.CheckObject(L, 2, typeof(S2c_aoi_addplayer));
			entityCreate.AddPlayer(cmd);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddHero(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			S2c_aoi_addself cmd = (S2c_aoi_addself)ToLua.CheckObject(L, 2, typeof(S2c_aoi_addself));
			entityCreate.AddHero(cmd);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddNpc(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			S2c_aoi_addnpc cmd = (S2c_aoi_addnpc)ToLua.CheckObject(L, 2, typeof(S2c_aoi_addnpc));
			entityCreate.AddNpc(cmd);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddAider(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			string model = ToLua.CheckString(L, 2);
			string posStr = ToLua.CheckString(L, 3);
			int dir = (int)LuaDLL.luaL_checknumber(L, 4);
			entityCreate.AddAider(model, posStr, dir);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearWhenChangeScene(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			entityCreate.ClearWhenChangeScene();
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
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			entityCreate.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DeleteObjectsById(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			EntityCreate entityCreate = (EntityCreate)ToLua.CheckObject(L, 1, typeof(EntityCreate));
			string id = ToLua.CheckString(L, 2);
			bool value = entityCreate.DeleteObjectsById(id);
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
	private static int get__mainRole(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EntityCreate entityCreate = (EntityCreate)obj;
			SceneEntity mainRole = entityCreate._mainRole;
			ToLua.Push(L, mainRole);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index _mainRole on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get__needDeleteNpcs(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EntityCreate entityCreate = (EntityCreate)obj;
			List<string> needDeleteNpcs = entityCreate._needDeleteNpcs;
			ToLua.PushObject(L, needDeleteNpcs);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index _needDeleteNpcs on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get__players(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EntityCreate entityCreate = (EntityCreate)obj;
			List<S2c_aoi_addplayer> players = entityCreate._players;
			ToLua.PushObject(L, players);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index _players on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get__npcs(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EntityCreate entityCreate = (EntityCreate)obj;
			List<S2c_aoi_addnpc> npcs = entityCreate._npcs;
			ToLua.PushObject(L, npcs);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index _npcs on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get__heroInfo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EntityCreate entityCreate = (EntityCreate)obj;
			S2c_aoi_addself heroInfo = entityCreate._heroInfo;
			ToLua.PushObject(L, heroInfo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index _heroInfo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get__aiderInfo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EntityCreate entityCreate = (EntityCreate)obj;
			string[] aiderInfo = entityCreate._aiderInfo;
			ToLua.Push(L, aiderInfo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index _aiderInfo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isInAsynceLoad(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EntityCreate entityCreate = (EntityCreate)obj;
			bool isInAsynceLoad = entityCreate.isInAsynceLoad;
			LuaDLL.lua_pushboolean(L, isInAsynceLoad);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isInAsynceLoad on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hidePlayer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EntityCreate entityCreate = (EntityCreate)obj;
			bool hidePlayer = entityCreate.hidePlayer;
			LuaDLL.lua_pushboolean(L, hidePlayer);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hidePlayer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_positionSync(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EntityCreate entityCreate = (EntityCreate)obj;
			PositionSync positionSync = entityCreate.positionSync;
			ToLua.Push(L, positionSync);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index positionSync on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cf(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EntityCreate entityCreate = (EntityCreate)obj;
			CameraFollow cf = entityCreate.cf;
			ToLua.Push(L, cf);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cf on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hidePlayer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EntityCreate entityCreate = (EntityCreate)obj;
			bool hidePlayer = LuaDLL.luaL_checkboolean(L, 2);
			entityCreate.hidePlayer = hidePlayer;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hidePlayer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_positionSync(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			EntityCreate entityCreate = (EntityCreate)obj;
			PositionSync positionSync = (PositionSync)ToLua.CheckUnityObject(L, 2, typeof(PositionSync));
			entityCreate.positionSync = positionSync;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index positionSync on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EntityCreate_OnRoleCreated(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(EntityCreate.OnRoleCreated), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(EntityCreate.OnRoleCreated), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EntityCreate_OnNpcCreated(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(EntityCreate.OnNpcCreated), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(EntityCreate.OnNpcCreated), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
