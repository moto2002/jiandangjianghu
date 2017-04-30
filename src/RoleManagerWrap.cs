using Aoi;
using LuaInterface;
using System;
using ThirdParty;
using UnityEngine;

public class RoleManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(RoleManager), typeof(Singleton<RoleManager>), null);
		L.RegFunction("SetTimeScale", new LuaCSFunction(RoleManagerWrap.SetTimeScale));
		L.RegFunction("GetInstance", new LuaCSFunction(RoleManagerWrap.GetInstance));
		L.RegFunction("AddPlayer", new LuaCSFunction(RoleManagerWrap.AddPlayer));
		L.RegFunction("AddHero", new LuaCSFunction(RoleManagerWrap.AddHero));
		L.RegFunction("AddNpc", new LuaCSFunction(RoleManagerWrap.AddNpc));
		L.RegFunction("AddAider", new LuaCSFunction(RoleManagerWrap.AddAider));
		L.RegFunction("SyncTargetPosition", new LuaCSFunction(RoleManagerWrap.SyncTargetPosition));
		L.RegFunction("CorrectTargetPosition", new LuaCSFunction(RoleManagerWrap.CorrectTargetPosition));
		L.RegFunction("DeleteObjectsById", new LuaCSFunction(RoleManagerWrap.DeleteObjectsById));
		L.RegFunction("Clear", new LuaCSFunction(RoleManagerWrap.Clear));
		L.RegFunction("CreateJumpGate", new LuaCSFunction(RoleManagerWrap.CreateJumpGate));
		L.RegFunction("CreateFakeJumpGate", new LuaCSFunction(RoleManagerWrap.CreateFakeJumpGate));
		L.RegFunction("AddJumpGateTitle", new LuaCSFunction(RoleManagerWrap.AddJumpGateTitle));
		L.RegFunction("CreateXunLuoNpcs", new LuaCSFunction(RoleManagerWrap.CreateXunLuoNpcs));
		L.RegFunction("FirstBlockOtherPlayers", new LuaCSFunction(RoleManagerWrap.FirstBlockOtherPlayers));
		L.RegFunction("CreateLingqi", new LuaCSFunction(RoleManagerWrap.CreateLingqi));
		L.RegFunction("CreatePartner", new LuaCSFunction(RoleManagerWrap.CreatePartner));
		L.RegFunction("CreatePet", new LuaCSFunction(RoleManagerWrap.CreatePet));
		L.RegFunction("BackToScene", new LuaCSFunction(RoleManagerWrap.BackToScene));
		L.RegFunction("AfterLoading", new LuaCSFunction(RoleManagerWrap.AfterLoading));
		L.RegFunction("JumpSceneByEnterJumpgate", new LuaCSFunction(RoleManagerWrap.JumpSceneByEnterJumpgate));
		L.RegFunction("SetObjectHpById", new LuaCSFunction(RoleManagerWrap.SetObjectHpById));
		L.RegFunction("UpdateUninitPlayerInfo", new LuaCSFunction(RoleManagerWrap.UpdateUninitPlayerInfo));
		L.RegFunction("UpdateUninitNpcInfo", new LuaCSFunction(RoleManagerWrap.UpdateUninitNpcInfo));
		L.RegFunction("UpdateUninitSceneObjRepeatInt", new LuaCSFunction(RoleManagerWrap.UpdateUninitSceneObjRepeatInt));
		L.RegFunction("UpdateUninitSceneObjString", new LuaCSFunction(RoleManagerWrap.UpdateUninitSceneObjString));
		L.RegFunction("UpdateUninitSceneObjInt", new LuaCSFunction(RoleManagerWrap.UpdateUninitSceneObjInt));
		L.RegFunction("GetHeroInfo", new LuaCSFunction(RoleManagerWrap.GetHeroInfo));
		L.RegFunction("GetMonsterById", new LuaCSFunction(RoleManagerWrap.GetMonsterById));
		L.RegFunction("GetSceneEntityById", new LuaCSFunction(RoleManagerWrap.GetSceneEntityById));
		L.RegFunction("GetXunLuoNpc", new LuaCSFunction(RoleManagerWrap.GetXunLuoNpc));
		L.RegFunction("SetMainRoleTarget", new LuaCSFunction(RoleManagerWrap.SetMainRoleTarget));
		L.RegFunction("SyncPlayerDash", new LuaCSFunction(RoleManagerWrap.SyncPlayerDash));
		L.RegFunction("UpdateBlockSetting", new LuaCSFunction(RoleManagerWrap.UpdateBlockSetting));
		L.RegFunction("UpdateAllTitleBlood", new LuaCSFunction(RoleManagerWrap.UpdateAllTitleBlood));
		L.RegFunction("__eq", new LuaCSFunction(RoleManagerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("canMainRoleMove", new LuaCSFunction(RoleManagerWrap.get_canMainRoleMove), new LuaCSFunction(RoleManagerWrap.set_canMainRoleMove));
		L.RegVar("createNpcNeedAni", new LuaCSFunction(RoleManagerWrap.get_createNpcNeedAni), new LuaCSFunction(RoleManagerWrap.set_createNpcNeedAni));
		L.RegVar("clientServer", new LuaCSFunction(RoleManagerWrap.get_clientServer), new LuaCSFunction(RoleManagerWrap.set_clientServer));
		L.RegVar("mainCamera", new LuaCSFunction(RoleManagerWrap.get_mainCamera), new LuaCSFunction(RoleManagerWrap.set_mainCamera));
		L.RegVar("audioSource", new LuaCSFunction(RoleManagerWrap.get_audioSource), new LuaCSFunction(RoleManagerWrap.set_audioSource));
		L.RegVar("mode", new LuaCSFunction(RoleManagerWrap.get_mode), new LuaCSFunction(RoleManagerWrap.set_mode));
		L.RegVar("sceneType", new LuaCSFunction(RoleManagerWrap.get_sceneType), new LuaCSFunction(RoleManagerWrap.set_sceneType));
		L.RegVar("sceneEntities", new LuaCSFunction(RoleManagerWrap.get_sceneEntities), null);
		L.RegVar("partnerAndLingQiEntities", new LuaCSFunction(RoleManagerWrap.get_partnerAndLingQiEntities), null);
		L.RegVar("xunLuoEntities", new LuaCSFunction(RoleManagerWrap.get_xunLuoEntities), null);
		L.RegVar("roles", new LuaCSFunction(RoleManagerWrap.get_roles), null);
		L.RegVar("roleParts", new LuaCSFunction(RoleManagerWrap.get_roleParts), null);
		L.RegVar("monsters", new LuaCSFunction(RoleManagerWrap.get_monsters), null);
		L.RegVar("npcs", new LuaCSFunction(RoleManagerWrap.get_npcs), null);
		L.RegVar("jumpGates", new LuaCSFunction(RoleManagerWrap.get_jumpGates), null);
		L.RegVar("mainRole", new LuaCSFunction(RoleManagerWrap.get_mainRole), null);
		L.RegVar("curSceneNo", new LuaCSFunction(RoleManagerWrap.get_curSceneNo), new LuaCSFunction(RoleManagerWrap.set_curSceneNo));
		L.RegVar("curSceneId", new LuaCSFunction(RoleManagerWrap.get_curSceneId), new LuaCSFunction(RoleManagerWrap.set_curSceneId));
		L.RegVar("cameraOffsetY", new LuaCSFunction(RoleManagerWrap.get_cameraOffsetY), new LuaCSFunction(RoleManagerWrap.set_cameraOffsetY));
		L.RegVar("cameraDistance", new LuaCSFunction(RoleManagerWrap.get_cameraDistance), new LuaCSFunction(RoleManagerWrap.set_cameraDistance));
		L.RegVar("maxClimbHeight", new LuaCSFunction(RoleManagerWrap.get_maxClimbHeight), new LuaCSFunction(RoleManagerWrap.set_maxClimbHeight));
		L.RegVar("ao", new LuaCSFunction(RoleManagerWrap.get_ao), new LuaCSFunction(RoleManagerWrap.set_ao));
		L.RegVar("sceneAsset", new LuaCSFunction(RoleManagerWrap.get_sceneAsset), new LuaCSFunction(RoleManagerWrap.set_sceneAsset));
		L.RegVar("positionSync", new LuaCSFunction(RoleManagerWrap.get_positionSync), null);
		L.RegVar("newAoiMoveType", new LuaCSFunction(RoleManagerWrap.get_newAoiMoveType), new LuaCSFunction(RoleManagerWrap.set_newAoiMoveType));
		L.RegVar("entityCreate", new LuaCSFunction(RoleManagerWrap.get_entityCreate), null);
		L.RegVar("cf", new LuaCSFunction(RoleManagerWrap.get_cf), null);
		L.RegVar("loadingFinished", new LuaCSFunction(RoleManagerWrap.get_loadingFinished), null);
		L.RegVar("playerShowCount", new LuaCSFunction(RoleManagerWrap.get_playerShowCount), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetTimeScale(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			int timeScale = (int)LuaDLL.luaL_checknumber(L, 2);
			roleManager.SetTimeScale(timeScale);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInstance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			RoleManager instance = RoleManager.GetInstance();
			ToLua.Push(L, instance);
			result = 1;
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
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			S2c_aoi_addplayer cmd = (S2c_aoi_addplayer)ToLua.CheckObject(L, 2, typeof(S2c_aoi_addplayer));
			roleManager.AddPlayer(cmd);
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
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			S2c_aoi_addself cmd = (S2c_aoi_addself)ToLua.CheckObject(L, 2, typeof(S2c_aoi_addself));
			roleManager.AddHero(cmd);
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
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			S2c_aoi_addnpc cmd = (S2c_aoi_addnpc)ToLua.CheckObject(L, 2, typeof(S2c_aoi_addnpc));
			roleManager.AddNpc(cmd);
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
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			string model = ToLua.CheckString(L, 2);
			string posStr = ToLua.CheckString(L, 3);
			int dir = (int)LuaDLL.luaL_checknumber(L, 4);
			roleManager.AddAider(model, posStr, dir);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SyncTargetPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 7);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			string id = ToLua.CheckString(L, 2);
			int x = (int)LuaDLL.luaL_checknumber(L, 3);
			float y = (float)LuaDLL.luaL_checknumber(L, 4);
			int z = (int)LuaDLL.luaL_checknumber(L, 5);
			float speed = (float)LuaDLL.luaL_checknumber(L, 6);
			int type = (int)LuaDLL.luaL_checknumber(L, 7);
			roleManager.SyncTargetPosition(id, x, y, z, speed, type);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CorrectTargetPosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			int x = (int)LuaDLL.luaL_checknumber(L, 2);
			float y = (float)LuaDLL.luaL_checknumber(L, 3);
			int z = (int)LuaDLL.luaL_checknumber(L, 4);
			roleManager.CorrectTargetPosition(x, y, z);
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
			ToLua.CheckArgsCount(L, 3);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			string id = ToLua.CheckString(L, 2);
			bool deleteSelf = LuaDLL.luaL_checkboolean(L, 3);
			roleManager.DeleteObjectsById(id, deleteSelf);
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
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			roleManager.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateJumpGate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			LuaTable table = ToLua.CheckLuaTable(L, 2);
			roleManager.CreateJumpGate(table);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CreateFakeJumpGate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			LuaTable table = ToLua.CheckLuaTable(L, 2);
			roleManager.CreateFakeJumpGate(table);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddJumpGateTitle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			JumpGate gate = (JumpGate)ToLua.CheckUnityObject(L, 2, typeof(JumpGate));
			string name = ToLua.CheckString(L, 3);
			roleManager.AddJumpGateTitle(gate, name);
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
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			LuaTable table = ToLua.CheckLuaTable(L, 2);
			roleManager.CreateXunLuoNpcs(table);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FirstBlockOtherPlayers(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			bool show = LuaDLL.luaL_checkboolean(L, 2);
			roleManager.FirstBlockOtherPlayers(show);
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
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			SceneEntity obj = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			string magic = ToLua.CheckString(L, 3);
			roleManager.CreateLingqi(obj, magic);
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
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			SceneEntity obj = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			string partner = ToLua.CheckString(L, 3);
			roleManager.CreatePartner(obj, partner);
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
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			SceneEntity obj = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			int pet = (int)LuaDLL.luaL_checknumber(L, 3);
			roleManager.CreatePet(obj, pet);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int BackToScene(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			roleManager.BackToScene();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AfterLoading(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			roleManager.AfterLoading();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int JumpSceneByEnterJumpgate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			int targetMapNo = (int)LuaDLL.luaL_checknumber(L, 2);
			roleManager.JumpSceneByEnterJumpgate(targetMapNo);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetObjectHpById(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			string id = ToLua.CheckString(L, 2);
			int nhp = (int)LuaDLL.luaL_checknumber(L, 3);
			int hpmax = (int)LuaDLL.luaL_checknumber(L, 4);
			roleManager.SetObjectHpById(id, nhp, hpmax);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateUninitPlayerInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			S2c_aoi_syncplayer playerInfo = (S2c_aoi_syncplayer)ToLua.CheckObject(L, 2, typeof(S2c_aoi_syncplayer));
			roleManager.UpdateUninitPlayerInfo(playerInfo);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateUninitNpcInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			S2c_aoi_syncnpc npcInfo = (S2c_aoi_syncnpc)ToLua.CheckObject(L, 2, typeof(S2c_aoi_syncnpc));
			roleManager.UpdateUninitNpcInfo(npcInfo);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateUninitSceneObjRepeatInt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			string rid = ToLua.CheckString(L, 2);
			string key = ToLua.CheckString(L, 3);
			LuaTable tblInfo = ToLua.CheckLuaTable(L, 4);
			roleManager.UpdateUninitSceneObjRepeatInt(rid, key, tblInfo);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateUninitSceneObjString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			string rid = ToLua.CheckString(L, 2);
			string key = ToLua.CheckString(L, 3);
			string value = ToLua.CheckString(L, 4);
			roleManager.UpdateUninitSceneObjString(rid, key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateUninitSceneObjInt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			string rid = ToLua.CheckString(L, 2);
			string key = ToLua.CheckString(L, 3);
			int value = (int)LuaDLL.luaL_checknumber(L, 4);
			roleManager.UpdateUninitSceneObjInt(rid, key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetHeroInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			S2c_aoi_addself heroInfo = roleManager.GetHeroInfo();
			ToLua.PushObject(L, heroInfo);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetMonsterById(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			string id = ToLua.CheckString(L, 2);
			SceneEntity monsterById = roleManager.GetMonsterById(id);
			ToLua.Push(L, monsterById);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSceneEntityById(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			string id = ToLua.CheckString(L, 2);
			int type = (int)LuaDLL.luaL_checknumber(L, 3);
			SceneEntity sceneEntityById = roleManager.GetSceneEntityById(id, type);
			ToLua.Push(L, sceneEntityById);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetXunLuoNpc(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			int npcNo = (int)LuaDLL.luaL_checknumber(L, 2);
			SceneEntity xunLuoNpc = roleManager.GetXunLuoNpc(npcNo);
			ToLua.Push(L, xunLuoNpc);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetMainRoleTarget(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			SceneEntity mainRoleTarget = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			roleManager.SetMainRoleTarget(mainRoleTarget);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SyncPlayerDash(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			string rid = ToLua.CheckString(L, 2);
			float x = (float)LuaDLL.luaL_checknumber(L, 3);
			float y = (float)LuaDLL.luaL_checknumber(L, 4);
			float z = (float)LuaDLL.luaL_checknumber(L, 5);
			roleManager.SyncPlayerDash(rid, x, y, z);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateBlockSetting(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			roleManager.UpdateBlockSetting();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateAllTitleBlood(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleManager roleManager = (RoleManager)ToLua.CheckObject(L, 1, typeof(RoleManager));
			roleManager.UpdateAllTitleBlood();
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
	private static int get_canMainRoleMove(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			bool canMainRoleMove = roleManager.canMainRoleMove;
			LuaDLL.lua_pushboolean(L, canMainRoleMove);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canMainRoleMove on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_createNpcNeedAni(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			bool createNpcNeedAni = roleManager.createNpcNeedAni;
			LuaDLL.lua_pushboolean(L, createNpcNeedAni);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index createNpcNeedAni on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_clientServer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			bool clientServer = roleManager.clientServer;
			LuaDLL.lua_pushboolean(L, clientServer);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clientServer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mainCamera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			Camera mainCamera = roleManager.mainCamera;
			ToLua.Push(L, mainCamera);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mainCamera on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_audioSource(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			AudioSource audioSource = roleManager.audioSource;
			ToLua.Push(L, audioSource);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index audioSource on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			RoleManager.GameMode mode = roleManager.mode;
			ToLua.Push(L, mode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sceneType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			int sceneType = roleManager.sceneType;
			LuaDLL.lua_pushinteger(L, sceneType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sceneType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sceneEntities(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, RoleManager.sceneEntities);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_partnerAndLingQiEntities(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, RoleManager.partnerAndLingQiEntities);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_xunLuoEntities(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, RoleManager.xunLuoEntities);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_roles(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, RoleManager.roles);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_roleParts(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, RoleManager.roleParts);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_monsters(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, RoleManager.monsters);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_npcs(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, RoleManager.npcs);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_jumpGates(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, RoleManager.jumpGates);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mainRole(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			SceneEntity mainRole = roleManager.mainRole;
			ToLua.Push(L, mainRole);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mainRole on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_curSceneNo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			int curSceneNo = roleManager.curSceneNo;
			LuaDLL.lua_pushinteger(L, curSceneNo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index curSceneNo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_curSceneId(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			int curSceneId = roleManager.curSceneId;
			LuaDLL.lua_pushinteger(L, curSceneId);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index curSceneId on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cameraOffsetY(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			float cameraOffsetY = roleManager.cameraOffsetY;
			LuaDLL.lua_pushnumber(L, (double)cameraOffsetY);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cameraOffsetY on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cameraDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			float cameraDistance = roleManager.cameraDistance;
			LuaDLL.lua_pushnumber(L, (double)cameraDistance);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cameraDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxClimbHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			float maxClimbHeight = roleManager.maxClimbHeight;
			LuaDLL.lua_pushnumber(L, (double)maxClimbHeight);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxClimbHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ao(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			AsyncOperation ao = roleManager.ao;
			ToLua.PushObject(L, ao);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ao on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sceneAsset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			AssetBundle sceneAsset = roleManager.sceneAsset;
			ToLua.Push(L, sceneAsset);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sceneAsset on a nil value");
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
			RoleManager roleManager = (RoleManager)obj;
			PositionSync positionSync = roleManager.positionSync;
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
	private static int get_newAoiMoveType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			bool newAoiMoveType = roleManager.newAoiMoveType;
			LuaDLL.lua_pushboolean(L, newAoiMoveType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index newAoiMoveType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_entityCreate(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			EntityCreate entityCreate = roleManager.entityCreate;
			ToLua.Push(L, entityCreate);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index entityCreate on a nil value");
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
			RoleManager roleManager = (RoleManager)obj;
			CameraFollow cf = roleManager.cf;
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
	private static int get_loadingFinished(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			bool loadingFinished = roleManager.loadingFinished;
			LuaDLL.lua_pushboolean(L, loadingFinished);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index loadingFinished on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_playerShowCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			int playerShowCount = roleManager.playerShowCount;
			LuaDLL.lua_pushinteger(L, playerShowCount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index playerShowCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_canMainRoleMove(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			bool canMainRoleMove = LuaDLL.luaL_checkboolean(L, 2);
			roleManager.canMainRoleMove = canMainRoleMove;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canMainRoleMove on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_createNpcNeedAni(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			bool createNpcNeedAni = LuaDLL.luaL_checkboolean(L, 2);
			roleManager.createNpcNeedAni = createNpcNeedAni;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index createNpcNeedAni on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_clientServer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			bool clientServer = LuaDLL.luaL_checkboolean(L, 2);
			roleManager.clientServer = clientServer;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index clientServer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mainCamera(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			Camera mainCamera = (Camera)ToLua.CheckUnityObject(L, 2, typeof(Camera));
			roleManager.mainCamera = mainCamera;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mainCamera on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_audioSource(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			AudioSource audioSource = (AudioSource)ToLua.CheckUnityObject(L, 2, typeof(AudioSource));
			roleManager.audioSource = audioSource;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index audioSource on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			RoleManager.GameMode mode = (RoleManager.GameMode)((int)ToLua.CheckObject(L, 2, typeof(RoleManager.GameMode)));
			roleManager.mode = mode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sceneType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			int sceneType = (int)LuaDLL.luaL_checknumber(L, 2);
			roleManager.sceneType = sceneType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sceneType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_curSceneNo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			int curSceneNo = (int)LuaDLL.luaL_checknumber(L, 2);
			roleManager.curSceneNo = curSceneNo;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index curSceneNo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_curSceneId(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			int curSceneId = (int)LuaDLL.luaL_checknumber(L, 2);
			roleManager.curSceneId = curSceneId;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index curSceneId on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cameraOffsetY(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			float cameraOffsetY = (float)LuaDLL.luaL_checknumber(L, 2);
			roleManager.cameraOffsetY = cameraOffsetY;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cameraOffsetY on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cameraDistance(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			float cameraDistance = (float)LuaDLL.luaL_checknumber(L, 2);
			roleManager.cameraDistance = cameraDistance;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cameraDistance on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxClimbHeight(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			float maxClimbHeight = (float)LuaDLL.luaL_checknumber(L, 2);
			roleManager.maxClimbHeight = maxClimbHeight;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxClimbHeight on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ao(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			AsyncOperation ao = (AsyncOperation)ToLua.CheckObject(L, 2, typeof(AsyncOperation));
			roleManager.ao = ao;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ao on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sceneAsset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			AssetBundle sceneAsset = (AssetBundle)ToLua.CheckUnityObject(L, 2, typeof(AssetBundle));
			roleManager.sceneAsset = sceneAsset;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sceneAsset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_newAoiMoveType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleManager roleManager = (RoleManager)obj;
			bool newAoiMoveType = LuaDLL.luaL_checkboolean(L, 2);
			roleManager.newAoiMoveType = newAoiMoveType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index newAoiMoveType on a nil value");
		}
		return result;
	}
}
