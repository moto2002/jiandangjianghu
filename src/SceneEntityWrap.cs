using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntityWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SceneEntity), typeof(MonoBehaviour), null);
		L.RegFunction("LoadParticle", new LuaCSFunction(SceneEntityWrap.LoadParticle));
		L.RegFunction("SetKeyValue", new LuaCSFunction(SceneEntityWrap.SetKeyValue));
		L.RegFunction("GetValueByKey", new LuaCSFunction(SceneEntityWrap.GetValueByKey));
		L.RegFunction("SetData", new LuaCSFunction(SceneEntityWrap.SetData));
		L.RegFunction("ShowHideEntityModel", new LuaCSFunction(SceneEntityWrap.ShowHideEntityModel));
		L.RegFunction("UpdateBlockSetting", new LuaCSFunction(SceneEntityWrap.UpdateBlockSetting));
		L.RegFunction("ChangeShader", new LuaCSFunction(SceneEntityWrap.ChangeShader));
		L.RegFunction("ChangeDir", new LuaCSFunction(SceneEntityWrap.ChangeDir));
		L.RegFunction("DelayRotateBackAfterSelected", new LuaCSFunction(SceneEntityWrap.DelayRotateBackAfterSelected));
		L.RegFunction("AddHeadTitle", new LuaCSFunction(SceneEntityWrap.AddHeadTitle));
		L.RegFunction("ResetHeadTitle", new LuaCSFunction(SceneEntityWrap.ResetHeadTitle));
		L.RegFunction("AddTeamMember", new LuaCSFunction(SceneEntityWrap.AddTeamMember));
		L.RegFunction("OnHurt", new LuaCSFunction(SceneEntityWrap.OnHurt));
		L.RegFunction("GetObjName", new LuaCSFunction(SceneEntityWrap.GetObjName));
		L.RegFunction("StartPlotJump", new LuaCSFunction(SceneEntityWrap.StartPlotJump));
		L.RegFunction("UpdateMood", new LuaCSFunction(SceneEntityWrap.UpdateMood));
		L.RegFunction("UpdateExtendInfo", new LuaCSFunction(SceneEntityWrap.UpdateExtendInfo));
		L.RegFunction("Recycle", new LuaCSFunction(SceneEntityWrap.Recycle));
		L.RegFunction("RecycleRoleModel", new LuaCSFunction(SceneEntityWrap.RecycleRoleModel));
		L.RegFunction("SetJumpTrailEffectParent", new LuaCSFunction(SceneEntityWrap.SetJumpTrailEffectParent));
		L.RegFunction("RecycleOtherModel", new LuaCSFunction(SceneEntityWrap.RecycleOtherModel));
		L.RegFunction("ChangeHusongTitle", new LuaCSFunction(SceneEntityWrap.ChangeHusongTitle));
		L.RegFunction("Say", new LuaCSFunction(SceneEntityWrap.Say));
		L.RegFunction("XunLuoNpcClick", new LuaCSFunction(SceneEntityWrap.XunLuoNpcClick));
		L.RegFunction("__eq", new LuaCSFunction(SceneEntityWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("selectable", new LuaCSFunction(SceneEntityWrap.get_selectable), new LuaCSFunction(SceneEntityWrap.set_selectable));
		L.RegVar("entityType", new LuaCSFunction(SceneEntityWrap.get_entityType), new LuaCSFunction(SceneEntityWrap.set_entityType));
		L.RegVar("move", new LuaCSFunction(SceneEntityWrap.get_move), new LuaCSFunction(SceneEntityWrap.set_move));
		L.RegVar("controller", new LuaCSFunction(SceneEntityWrap.get_controller), new LuaCSFunction(SceneEntityWrap.set_controller));
		L.RegVar("runToTarget", new LuaCSFunction(SceneEntityWrap.get_runToTarget), new LuaCSFunction(SceneEntityWrap.set_runToTarget));
		L.RegVar("selectTarget", new LuaCSFunction(SceneEntityWrap.get_selectTarget), new LuaCSFunction(SceneEntityWrap.set_selectTarget));
		L.RegVar("buffs", new LuaCSFunction(SceneEntityWrap.get_buffs), new LuaCSFunction(SceneEntityWrap.set_buffs));
		L.RegVar("deadCallBack", new LuaCSFunction(SceneEntityWrap.get_deadCallBack), new LuaCSFunction(SceneEntityWrap.set_deadCallBack));
		L.RegVar("roleAction", new LuaCSFunction(SceneEntityWrap.get_roleAction), new LuaCSFunction(SceneEntityWrap.set_roleAction));
		L.RegVar("title", new LuaCSFunction(SceneEntityWrap.get_title), new LuaCSFunction(SceneEntityWrap.set_title));
		L.RegVar("headTitle", new LuaCSFunction(SceneEntityWrap.get_headTitle), new LuaCSFunction(SceneEntityWrap.set_headTitle));
		L.RegVar("husongTitle", new LuaCSFunction(SceneEntityWrap.get_husongTitle), new LuaCSFunction(SceneEntityWrap.set_husongTitle));
		L.RegVar("castSkill", new LuaCSFunction(SceneEntityWrap.get_castSkill), new LuaCSFunction(SceneEntityWrap.set_castSkill));
		L.RegVar("horse", new LuaCSFunction(SceneEntityWrap.get_horse), new LuaCSFunction(SceneEntityWrap.set_horse));
		L.RegVar("roleState", new LuaCSFunction(SceneEntityWrap.get_roleState), new LuaCSFunction(SceneEntityWrap.set_roleState));
		L.RegVar("selectParticle", new LuaCSFunction(SceneEntityWrap.get_selectParticle), new LuaCSFunction(SceneEntityWrap.set_selectParticle));
		L.RegVar("chongCiParticle", new LuaCSFunction(SceneEntityWrap.get_chongCiParticle), new LuaCSFunction(SceneEntityWrap.set_chongCiParticle));
		L.RegVar("jumpChongCiParticle", new LuaCSFunction(SceneEntityWrap.get_jumpChongCiParticle), new LuaCSFunction(SceneEntityWrap.set_jumpChongCiParticle));
		L.RegVar("jumpTrailParticle", new LuaCSFunction(SceneEntityWrap.get_jumpTrailParticle), new LuaCSFunction(SceneEntityWrap.set_jumpTrailParticle));
		L.RegVar("daZuoParticle", new LuaCSFunction(SceneEntityWrap.get_daZuoParticle), new LuaCSFunction(SceneEntityWrap.set_daZuoParticle));
		L.RegVar("id", new LuaCSFunction(SceneEntityWrap.get_id), new LuaCSFunction(SceneEntityWrap.set_id));
		L.RegVar("selectEffectGo", new LuaCSFunction(SceneEntityWrap.get_selectEffectGo), null);
		L.RegVar("chongCiEffectGo", new LuaCSFunction(SceneEntityWrap.get_chongCiEffectGo), null);
		L.RegVar("jumpChongCiEffectGo", new LuaCSFunction(SceneEntityWrap.get_jumpChongCiEffectGo), null);
		L.RegVar("jumpTrailEffect1Go", new LuaCSFunction(SceneEntityWrap.get_jumpTrailEffect1Go), null);
		L.RegVar("jumpTrailEffect2Go", new LuaCSFunction(SceneEntityWrap.get_jumpTrailEffect2Go), null);
		L.RegVar("daZuoEffectGo", new LuaCSFunction(SceneEntityWrap.get_daZuoEffectGo), null);
		L.RegVar("char_id", new LuaCSFunction(SceneEntityWrap.get_char_id), new LuaCSFunction(SceneEntityWrap.set_char_id));
		L.RegVar("sex", new LuaCSFunction(SceneEntityWrap.get_sex), new LuaCSFunction(SceneEntityWrap.set_sex));
		L.RegVar("grade", new LuaCSFunction(SceneEntityWrap.get_grade), new LuaCSFunction(SceneEntityWrap.set_grade));
		L.RegVar("dir", new LuaCSFunction(SceneEntityWrap.get_dir), new LuaCSFunction(SceneEntityWrap.set_dir));
		L.RegVar("hp", new LuaCSFunction(SceneEntityWrap.get_hp), new LuaCSFunction(SceneEntityWrap.set_hp));
		L.RegVar("maxhp", new LuaCSFunction(SceneEntityWrap.get_maxhp), new LuaCSFunction(SceneEntityWrap.set_maxhp));
		L.RegVar("canAttack", new LuaCSFunction(SceneEntityWrap.get_canAttack), null);
		L.RegVar("comp", new LuaCSFunction(SceneEntityWrap.get_comp), new LuaCSFunction(SceneEntityWrap.set_comp));
		L.RegVar("isBoss", new LuaCSFunction(SceneEntityWrap.get_isBoss), new LuaCSFunction(SceneEntityWrap.set_isBoss));
		L.RegVar("hpType", new LuaCSFunction(SceneEntityWrap.get_hpType), new LuaCSFunction(SceneEntityWrap.set_hpType));
		L.RegVar("buffIdList", new LuaCSFunction(SceneEntityWrap.get_buffIdList), new LuaCSFunction(SceneEntityWrap.set_buffIdList));
		L.RegVar("bodyRadius", new LuaCSFunction(SceneEntityWrap.get_bodyRadius), new LuaCSFunction(SceneEntityWrap.set_bodyRadius));
		L.RegVar("ownerId", new LuaCSFunction(SceneEntityWrap.get_ownerId), new LuaCSFunction(SceneEntityWrap.set_ownerId));
		L.RegVar("npcBloodType", new LuaCSFunction(SceneEntityWrap.get_npcBloodType), new LuaCSFunction(SceneEntityWrap.set_npcBloodType));
		L.RegVar("scaleNum", new LuaCSFunction(SceneEntityWrap.get_scaleNum), new LuaCSFunction(SceneEntityWrap.set_scaleNum));
		L.RegVar("teamMemberIds", new LuaCSFunction(SceneEntityWrap.get_teamMemberIds), null);
		L.RegVar("partnerFollow", new LuaCSFunction(SceneEntityWrap.get_partnerFollow), new LuaCSFunction(SceneEntityWrap.set_partnerFollow));
		L.RegVar("headNameYoffset", new LuaCSFunction(SceneEntityWrap.get_headNameYoffset), new LuaCSFunction(SceneEntityWrap.set_headNameYoffset));
		L.RegVar("isRide", new LuaCSFunction(SceneEntityWrap.get_isRide), new LuaCSFunction(SceneEntityWrap.set_isRide));
		L.RegVar("pkInfo", new LuaCSFunction(SceneEntityWrap.get_pkInfo), new LuaCSFunction(SceneEntityWrap.set_pkInfo));
		L.RegVar("score", new LuaCSFunction(SceneEntityWrap.get_score), new LuaCSFunction(SceneEntityWrap.set_score));
		L.RegVar("attacker", new LuaCSFunction(SceneEntityWrap.get_attacker), new LuaCSFunction(SceneEntityWrap.set_attacker));
		L.RegVar("autoResetAttackerTimer", new LuaCSFunction(SceneEntityWrap.get_autoResetAttackerTimer), new LuaCSFunction(SceneEntityWrap.set_autoResetAttackerTimer));
		L.RegVar("daZuo", new LuaCSFunction(SceneEntityWrap.get_daZuo), new LuaCSFunction(SceneEntityWrap.set_daZuo));
		L.RegVar("shield_hp", new LuaCSFunction(SceneEntityWrap.get_shield_hp), new LuaCSFunction(SceneEntityWrap.set_shield_hp));
		L.RegVar("shield_hpmax", new LuaCSFunction(SceneEntityWrap.get_shield_hpmax), new LuaCSFunction(SceneEntityWrap.set_shield_hpmax));
		L.RegVar("fashion", new LuaCSFunction(SceneEntityWrap.get_fashion), new LuaCSFunction(SceneEntityWrap.set_fashion));
		L.RegVar("shape", new LuaCSFunction(SceneEntityWrap.get_shape), new LuaCSFunction(SceneEntityWrap.set_shape));
		L.RegVar("weapon", new LuaCSFunction(SceneEntityWrap.get_weapon), new LuaCSFunction(SceneEntityWrap.set_weapon));
		L.RegVar("lingqin", new LuaCSFunction(SceneEntityWrap.get_lingqin), new LuaCSFunction(SceneEntityWrap.set_lingqin));
		L.RegVar("lingyi", new LuaCSFunction(SceneEntityWrap.get_lingyi), new LuaCSFunction(SceneEntityWrap.set_lingyi));
		L.RegVar("partnerhorse", new LuaCSFunction(SceneEntityWrap.get_partnerhorse), new LuaCSFunction(SceneEntityWrap.set_partnerhorse));
		L.RegVar("pet", new LuaCSFunction(SceneEntityWrap.get_pet), new LuaCSFunction(SceneEntityWrap.set_pet));
		L.RegVar("shenjian", new LuaCSFunction(SceneEntityWrap.get_shenjian), new LuaCSFunction(SceneEntityWrap.set_shenjian));
		L.RegVar("shenyi", new LuaCSFunction(SceneEntityWrap.get_shenyi), new LuaCSFunction(SceneEntityWrap.set_shenyi));
		L.RegVar("jingmai", new LuaCSFunction(SceneEntityWrap.get_jingmai), new LuaCSFunction(SceneEntityWrap.set_jingmai));
		L.RegVar("up_mount", new LuaCSFunction(SceneEntityWrap.get_up_mount), new LuaCSFunction(SceneEntityWrap.set_up_mount));
		L.RegVar("up_horse", new LuaCSFunction(SceneEntityWrap.get_up_horse), new LuaCSFunction(SceneEntityWrap.set_up_horse));
		L.RegVar("model", new LuaCSFunction(SceneEntityWrap.get_model), new LuaCSFunction(SceneEntityWrap.set_model));
		L.RegVar("weapon_model", new LuaCSFunction(SceneEntityWrap.get_weapon_model), new LuaCSFunction(SceneEntityWrap.set_weapon_model));
		L.RegVar("lingqin_model", new LuaCSFunction(SceneEntityWrap.get_lingqin_model), new LuaCSFunction(SceneEntityWrap.set_lingqin_model));
		L.RegVar("lingyi_model", new LuaCSFunction(SceneEntityWrap.get_lingyi_model), new LuaCSFunction(SceneEntityWrap.set_lingyi_model));
		L.RegVar("partnerhorse_model", new LuaCSFunction(SceneEntityWrap.get_partnerhorse_model), new LuaCSFunction(SceneEntityWrap.set_partnerhorse_model));
		L.RegVar("pet_model", new LuaCSFunction(SceneEntityWrap.get_pet_model), new LuaCSFunction(SceneEntityWrap.set_pet_model));
		L.RegVar("shenjian_model", new LuaCSFunction(SceneEntityWrap.get_shenjian_model), new LuaCSFunction(SceneEntityWrap.set_shenjian_model));
		L.RegVar("shenyi_model", new LuaCSFunction(SceneEntityWrap.get_shenyi_model), new LuaCSFunction(SceneEntityWrap.set_shenyi_model));
		L.RegVar("jingmai_model", new LuaCSFunction(SceneEntityWrap.get_jingmai_model), new LuaCSFunction(SceneEntityWrap.set_jingmai_model));
		L.RegVar("lingqiObj", new LuaCSFunction(SceneEntityWrap.get_lingqiObj), new LuaCSFunction(SceneEntityWrap.set_lingqiObj));
		L.RegVar("lingqiStr", new LuaCSFunction(SceneEntityWrap.get_lingqiStr), new LuaCSFunction(SceneEntityWrap.set_lingqiStr));
		L.RegVar("partnerObj", new LuaCSFunction(SceneEntityWrap.get_partnerObj), new LuaCSFunction(SceneEntityWrap.set_partnerObj));
		L.RegVar("partnerStr", new LuaCSFunction(SceneEntityWrap.get_partnerStr), new LuaCSFunction(SceneEntityWrap.set_partnerStr));
		L.RegVar("petObj", new LuaCSFunction(SceneEntityWrap.get_petObj), new LuaCSFunction(SceneEntityWrap.set_petObj));
		L.RegVar("petStr", new LuaCSFunction(SceneEntityWrap.get_petStr), new LuaCSFunction(SceneEntityWrap.set_petStr));
		L.RegVar("beautyObj", new LuaCSFunction(SceneEntityWrap.get_beautyObj), new LuaCSFunction(SceneEntityWrap.set_beautyObj));
		L.RegVar("beautyRare", new LuaCSFunction(SceneEntityWrap.get_beautyRare), new LuaCSFunction(SceneEntityWrap.set_beautyRare));
		L.RegVar("isBucket", new LuaCSFunction(SceneEntityWrap.get_isBucket), new LuaCSFunction(SceneEntityWrap.set_isBucket));
		L.RegVar("extendInfo", new LuaCSFunction(SceneEntityWrap.get_extendInfo), new LuaCSFunction(SceneEntityWrap.set_extendInfo));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoadParticle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			GameObject particle = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			GameObject obj = sceneEntity.LoadParticle(particle);
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
	private static int SetKeyValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			string key = ToLua.CheckString(L, 2);
			object value = ToLua.ToVarObject(L, 3);
			sceneEntity.SetKeyValue(key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetValueByKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			string key = ToLua.CheckString(L, 2);
			object valueByKey = sceneEntity.GetValueByKey(key);
			ToLua.Push(L, valueByKey);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 22);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			string id = ToLua.CheckString(L, 2);
			int char_id = (int)LuaDLL.luaL_checknumber(L, 3);
			int sex = (int)LuaDLL.luaL_checknumber(L, 4);
			float speed = (float)LuaDLL.luaL_checknumber(L, 5);
			int weapon = (int)LuaDLL.luaL_checknumber(L, 6);
			int mount_model = (int)LuaDLL.luaL_checknumber(L, 7);
			int partnerhorse_model = (int)LuaDLL.luaL_checknumber(L, 8);
			int lingqin_model = (int)LuaDLL.luaL_checknumber(L, 9);
			int lingyi_model = (int)LuaDLL.luaL_checknumber(L, 10);
			int pet_model = (int)LuaDLL.luaL_checknumber(L, 11);
			int shenjian_model = (int)LuaDLL.luaL_checknumber(L, 12);
			int shenyi_model = (int)LuaDLL.luaL_checknumber(L, 13);
			int jingmai_model = (int)LuaDLL.luaL_checknumber(L, 14);
			int score = (int)LuaDLL.luaL_checknumber(L, 15);
			int up_mount = (int)LuaDLL.luaL_checknumber(L, 16);
			int up_horse = (int)LuaDLL.luaL_checknumber(L, 17);
			int fashion = (int)LuaDLL.luaL_checknumber(L, 18);
			int dazuo = (int)LuaDLL.luaL_checknumber(L, 19);
			int shield_hp = (int)LuaDLL.luaL_checknumber(L, 20);
			int shield_hpmax = (int)LuaDLL.luaL_checknumber(L, 21);
			int isyunbiao = (int)LuaDLL.luaL_checknumber(L, 22);
			sceneEntity.SetData(id, char_id, sex, speed, weapon, mount_model, partnerhorse_model, lingqin_model, lingyi_model, pet_model, shenjian_model, shenyi_model, jingmai_model, score, up_mount, up_horse, fashion, dazuo, shield_hp, shield_hpmax, isyunbiao);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ShowHideEntityModel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			bool show = LuaDLL.luaL_checkboolean(L, 2);
			sceneEntity.ShowHideEntityModel(show);
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
			ToLua.CheckArgsCount(L, 2);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			bool ignoreWhenChangeSetting = LuaDLL.luaL_checkboolean(L, 2);
			sceneEntity.UpdateBlockSetting(ignoreWhenChangeSetting);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangeShader(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			sceneEntity.ChangeShader(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangeDir(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			int dir = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.ChangeDir(dir);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DelayRotateBackAfterSelected(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			sceneEntity.DelayRotateBackAfterSelected();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddHeadTitle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			string objName = ToLua.CheckString(L, 2);
			sceneEntity.AddHeadTitle(objName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetHeadTitle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			sceneEntity.ResetHeadTitle();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddTeamMember(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			string ids = ToLua.CheckString(L, 2);
			sceneEntity.AddTeamMember(ids);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnHurt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			sceneEntity.OnHurt();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetObjName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			string objName = sceneEntity.GetObjName();
			LuaDLL.lua_pushstring(L, objName);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int StartPlotJump(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			int doorNo = (int)LuaDLL.luaL_checknumber(L, 2);
			int endMap = (int)LuaDLL.luaL_checknumber(L, 3);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 4);
			Action onJumpFinished;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onJumpFinished = (Action)ToLua.CheckObject(L, 4, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 4);
				onJumpFinished = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			sceneEntity.StartPlotJump(doorNo, endMap, onJumpFinished);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateMood(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			string pkInfo = ToLua.CheckString(L, 2);
			sceneEntity.UpdateMood(pkInfo);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UpdateExtendInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			sceneEntity.UpdateExtendInfo();
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
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			sceneEntity.Recycle();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RecycleRoleModel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			sceneEntity.RecycleRoleModel();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetJumpTrailEffectParent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			sceneEntity.SetJumpTrailEffectParent();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RecycleOtherModel(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			int modelType = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.RecycleOtherModel(modelType);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ChangeHusongTitle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			string husongTitle = ToLua.CheckString(L, 2);
			sceneEntity.ChangeHusongTitle(husongTitle);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Say(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			string msg = ToLua.CheckString(L, 2);
			sceneEntity.Say(msg);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int XunLuoNpcClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SceneEntity sceneEntity = (SceneEntity)ToLua.CheckObject(L, 1, typeof(SceneEntity));
			string msg = ToLua.CheckString(L, 2);
			sceneEntity.XunLuoNpcClick(msg);
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
	private static int get_selectable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			bool selectable = sceneEntity.selectable;
			LuaDLL.lua_pushboolean(L, selectable);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_entityType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			RoleManager.EntityType entityType = sceneEntity.entityType;
			ToLua.Push(L, entityType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index entityType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_move(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			Move move = sceneEntity.move;
			ToLua.Push(L, move);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index move on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_controller(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			MoveController controller = sceneEntity.controller;
			ToLua.Push(L, controller);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index controller on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_runToTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			RunToTarget runToTarget = sceneEntity.runToTarget;
			ToLua.Push(L, runToTarget);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index runToTarget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			SelectTarget selectTarget = sceneEntity.selectTarget;
			ToLua.Push(L, selectTarget);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectTarget on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			Buffs buffs = sceneEntity.buffs;
			ToLua.Push(L, buffs);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index buffs on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_deadCallBack(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			Action deadCallBack = sceneEntity.deadCallBack;
			ToLua.Push(L, deadCallBack);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index deadCallBack on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_roleAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			RoleAction roleAction = sceneEntity.roleAction;
			ToLua.Push(L, roleAction);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index roleAction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_title(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			HeadTitle title = sceneEntity.title;
			ToLua.Push(L, title);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index title on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_headTitle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			string headTitle = sceneEntity.headTitle;
			LuaDLL.lua_pushstring(L, headTitle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index headTitle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_husongTitle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			string husongTitle = sceneEntity.husongTitle;
			LuaDLL.lua_pushstring(L, husongTitle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index husongTitle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_castSkill(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			CastSkill castSkill = sceneEntity.castSkill;
			ToLua.Push(L, castSkill);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index castSkill on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_horse(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			Horse horse = sceneEntity.horse;
			ToLua.Push(L, horse);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horse on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_roleState(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			RoleStateTransition roleState = sceneEntity.roleState;
			ToLua.Push(L, roleState);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index roleState on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectParticle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject selectParticle = sceneEntity.selectParticle;
			ToLua.Push(L, selectParticle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectParticle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_chongCiParticle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject chongCiParticle = sceneEntity.chongCiParticle;
			ToLua.Push(L, chongCiParticle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index chongCiParticle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_jumpChongCiParticle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject jumpChongCiParticle = sceneEntity.jumpChongCiParticle;
			ToLua.Push(L, jumpChongCiParticle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jumpChongCiParticle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_jumpTrailParticle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject jumpTrailParticle = sceneEntity.jumpTrailParticle;
			ToLua.Push(L, jumpTrailParticle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jumpTrailParticle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_daZuoParticle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject daZuoParticle = sceneEntity.daZuoParticle;
			ToLua.Push(L, daZuoParticle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index daZuoParticle on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			string id = sceneEntity.id;
			LuaDLL.lua_pushstring(L, id);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index id on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_selectEffectGo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject selectEffectGo = sceneEntity.selectEffectGo;
			ToLua.Push(L, selectEffectGo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectEffectGo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_chongCiEffectGo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject chongCiEffectGo = sceneEntity.chongCiEffectGo;
			ToLua.Push(L, chongCiEffectGo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index chongCiEffectGo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_jumpChongCiEffectGo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject jumpChongCiEffectGo = sceneEntity.jumpChongCiEffectGo;
			ToLua.Push(L, jumpChongCiEffectGo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jumpChongCiEffectGo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_jumpTrailEffect1Go(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject jumpTrailEffect1Go = sceneEntity.jumpTrailEffect1Go;
			ToLua.Push(L, jumpTrailEffect1Go);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jumpTrailEffect1Go on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_jumpTrailEffect2Go(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject jumpTrailEffect2Go = sceneEntity.jumpTrailEffect2Go;
			ToLua.Push(L, jumpTrailEffect2Go);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jumpTrailEffect2Go on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_daZuoEffectGo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject daZuoEffectGo = sceneEntity.daZuoEffectGo;
			ToLua.Push(L, daZuoEffectGo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index daZuoEffectGo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_char_id(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int char_id = sceneEntity.char_id;
			LuaDLL.lua_pushinteger(L, char_id);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index char_id on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int sex = sceneEntity.sex;
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
	private static int get_grade(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int grade = sceneEntity.grade;
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
	private static int get_dir(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int dir = sceneEntity.dir;
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
	private static int get_hp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int hp = sceneEntity.hp;
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
	private static int get_maxhp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int maxhp = sceneEntity.maxhp;
			LuaDLL.lua_pushinteger(L, maxhp);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxhp on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_canAttack(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			bool canAttack = sceneEntity.canAttack;
			LuaDLL.lua_pushboolean(L, canAttack);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index canAttack on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int comp = sceneEntity.comp;
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
	private static int get_isBoss(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			bool isBoss = sceneEntity.isBoss;
			LuaDLL.lua_pushboolean(L, isBoss);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isBoss on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_hpType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int hpType = sceneEntity.hpType;
			LuaDLL.lua_pushinteger(L, hpType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hpType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_buffIdList(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			List<int> buffIdList = sceneEntity.buffIdList;
			ToLua.PushObject(L, buffIdList);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index buffIdList on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bodyRadius(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			float bodyRadius = sceneEntity.bodyRadius;
			LuaDLL.lua_pushnumber(L, (double)bodyRadius);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bodyRadius on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ownerId(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			string ownerId = sceneEntity.ownerId;
			LuaDLL.lua_pushstring(L, ownerId);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ownerId on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_npcBloodType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int npcBloodType = sceneEntity.npcBloodType;
			LuaDLL.lua_pushinteger(L, npcBloodType);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index npcBloodType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_scaleNum(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			float scaleNum = sceneEntity.scaleNum;
			LuaDLL.lua_pushnumber(L, (double)scaleNum);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scaleNum on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_teamMemberIds(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			List<string> teamMemberIds = sceneEntity.teamMemberIds;
			ToLua.PushObject(L, teamMemberIds);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index teamMemberIds on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_partnerFollow(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int partnerFollow = sceneEntity.partnerFollow;
			LuaDLL.lua_pushinteger(L, partnerFollow);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partnerFollow on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_headNameYoffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			float headNameYoffset = sceneEntity.headNameYoffset;
			LuaDLL.lua_pushnumber(L, (double)headNameYoffset);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index headNameYoffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isRide(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			bool isRide = sceneEntity.isRide;
			LuaDLL.lua_pushboolean(L, isRide);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isRide on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pkInfo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			string pkInfo = sceneEntity.pkInfo;
			LuaDLL.lua_pushstring(L, pkInfo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pkInfo on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int score = sceneEntity.score;
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
	private static int get_attacker(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			SceneEntity attacker = sceneEntity.attacker;
			ToLua.Push(L, attacker);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index attacker on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_autoResetAttackerTimer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			float autoResetAttackerTimer = sceneEntity.autoResetAttackerTimer;
			LuaDLL.lua_pushnumber(L, (double)autoResetAttackerTimer);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index autoResetAttackerTimer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_daZuo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int daZuo = sceneEntity.daZuo;
			LuaDLL.lua_pushinteger(L, daZuo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index daZuo on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int shield_hp = sceneEntity.shield_hp;
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int shield_hpmax = sceneEntity.shield_hpmax;
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
	private static int get_fashion(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int fashion = sceneEntity.fashion;
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
	private static int get_shape(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int shape = sceneEntity.shape;
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
	private static int get_weapon(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int weapon = sceneEntity.weapon;
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
	private static int get_lingqin(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int lingqin = sceneEntity.lingqin;
			LuaDLL.lua_pushinteger(L, lingqin);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingqin on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lingyi(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int lingyi = sceneEntity.lingyi;
			LuaDLL.lua_pushinteger(L, lingyi);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingyi on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_partnerhorse(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int partnerhorse = sceneEntity.partnerhorse;
			LuaDLL.lua_pushinteger(L, partnerhorse);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partnerhorse on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pet(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int pet = sceneEntity.pet;
			LuaDLL.lua_pushinteger(L, pet);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pet on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shenjian(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int shenjian = sceneEntity.shenjian;
			LuaDLL.lua_pushinteger(L, shenjian);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shenjian on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_shenyi(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int shenyi = sceneEntity.shenyi;
			LuaDLL.lua_pushinteger(L, shenyi);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shenyi on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_jingmai(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int jingmai = sceneEntity.jingmai;
			LuaDLL.lua_pushinteger(L, jingmai);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jingmai on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int up_mount = sceneEntity.up_mount;
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int up_horse = sceneEntity.up_horse;
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
	private static int get_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject model = sceneEntity.model;
			ToLua.Push(L, model);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_weapon_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject weapon_model = sceneEntity.weapon_model;
			ToLua.Push(L, weapon_model);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index weapon_model on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject lingqin_model = sceneEntity.lingqin_model;
			ToLua.Push(L, lingqin_model);
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject lingyi_model = sceneEntity.lingyi_model;
			ToLua.Push(L, lingyi_model);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingyi_model on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject partnerhorse_model = sceneEntity.partnerhorse_model;
			ToLua.Push(L, partnerhorse_model);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partnerhorse_model on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject pet_model = sceneEntity.pet_model;
			ToLua.Push(L, pet_model);
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject shenjian_model = sceneEntity.shenjian_model;
			ToLua.Push(L, shenjian_model);
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject shenyi_model = sceneEntity.shenyi_model;
			ToLua.Push(L, shenyi_model);
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject jingmai_model = sceneEntity.jingmai_model;
			ToLua.Push(L, jingmai_model);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jingmai_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lingqiObj(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			SceneEntity lingqiObj = sceneEntity.lingqiObj;
			ToLua.Push(L, lingqiObj);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingqiObj on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lingqiStr(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			string lingqiStr = sceneEntity.lingqiStr;
			LuaDLL.lua_pushstring(L, lingqiStr);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingqiStr on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_partnerObj(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			SceneEntity partnerObj = sceneEntity.partnerObj;
			ToLua.Push(L, partnerObj);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partnerObj on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_partnerStr(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			string partnerStr = sceneEntity.partnerStr;
			LuaDLL.lua_pushstring(L, partnerStr);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partnerStr on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_petObj(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			SceneEntity petObj = sceneEntity.petObj;
			ToLua.Push(L, petObj);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index petObj on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_petStr(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int petStr = sceneEntity.petStr;
			LuaDLL.lua_pushinteger(L, petStr);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index petStr on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_beautyObj(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			SceneEntity beautyObj = sceneEntity.beautyObj;
			ToLua.Push(L, beautyObj);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index beautyObj on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_beautyRare(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int beautyRare = sceneEntity.beautyRare;
			LuaDLL.lua_pushinteger(L, beautyRare);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index beautyRare on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isBucket(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			bool isBucket = sceneEntity.isBucket;
			LuaDLL.lua_pushboolean(L, isBucket);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isBucket on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_extendInfo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			Dictionary<string, object> extendInfo = sceneEntity.extendInfo;
			ToLua.PushObject(L, extendInfo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index extendInfo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectable(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			bool selectable = LuaDLL.luaL_checkboolean(L, 2);
			sceneEntity.selectable = selectable;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectable on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_entityType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			RoleManager.EntityType entityType = (RoleManager.EntityType)((int)ToLua.CheckObject(L, 2, typeof(RoleManager.EntityType)));
			sceneEntity.entityType = entityType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index entityType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_move(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			Move move = (Move)ToLua.CheckUnityObject(L, 2, typeof(Move));
			sceneEntity.move = move;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index move on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_controller(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			MoveController controller = (MoveController)ToLua.CheckUnityObject(L, 2, typeof(MoveController));
			sceneEntity.controller = controller;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index controller on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_runToTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			RunToTarget runToTarget = (RunToTarget)ToLua.CheckUnityObject(L, 2, typeof(RunToTarget));
			sceneEntity.runToTarget = runToTarget;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index runToTarget on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectTarget(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			SelectTarget selectTarget = (SelectTarget)ToLua.CheckUnityObject(L, 2, typeof(SelectTarget));
			sceneEntity.selectTarget = selectTarget;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectTarget on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			Buffs buffs = (Buffs)ToLua.CheckUnityObject(L, 2, typeof(Buffs));
			sceneEntity.buffs = buffs;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index buffs on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_deadCallBack(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action deadCallBack;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				deadCallBack = (Action)ToLua.CheckObject(L, 2, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				deadCallBack = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			sceneEntity.deadCallBack = deadCallBack;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index deadCallBack on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_roleAction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			RoleAction roleAction = (RoleAction)ToLua.CheckUnityObject(L, 2, typeof(RoleAction));
			sceneEntity.roleAction = roleAction;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index roleAction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_title(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			HeadTitle title = (HeadTitle)ToLua.CheckUnityObject(L, 2, typeof(HeadTitle));
			sceneEntity.title = title;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index title on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_headTitle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			string headTitle = ToLua.CheckString(L, 2);
			sceneEntity.headTitle = headTitle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index headTitle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_husongTitle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			string husongTitle = ToLua.CheckString(L, 2);
			sceneEntity.husongTitle = husongTitle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index husongTitle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_castSkill(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			CastSkill castSkill = (CastSkill)ToLua.CheckUnityObject(L, 2, typeof(CastSkill));
			sceneEntity.castSkill = castSkill;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index castSkill on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_horse(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			Horse horse = (Horse)ToLua.CheckUnityObject(L, 2, typeof(Horse));
			sceneEntity.horse = horse;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horse on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_roleState(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			RoleStateTransition roleState = (RoleStateTransition)ToLua.CheckUnityObject(L, 2, typeof(RoleStateTransition));
			sceneEntity.roleState = roleState;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index roleState on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_selectParticle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject selectParticle = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			sceneEntity.selectParticle = selectParticle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index selectParticle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_chongCiParticle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject chongCiParticle = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			sceneEntity.chongCiParticle = chongCiParticle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index chongCiParticle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_jumpChongCiParticle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject jumpChongCiParticle = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			sceneEntity.jumpChongCiParticle = jumpChongCiParticle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jumpChongCiParticle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_jumpTrailParticle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject jumpTrailParticle = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			sceneEntity.jumpTrailParticle = jumpTrailParticle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jumpTrailParticle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_daZuoParticle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject daZuoParticle = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			sceneEntity.daZuoParticle = daZuoParticle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index daZuoParticle on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			string id = ToLua.CheckString(L, 2);
			sceneEntity.id = id;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index id on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_char_id(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int char_id = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.char_id = char_id;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index char_id on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int sex = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.sex = sex;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sex on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int grade = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.grade = grade;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index grade on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int dir = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.dir = dir;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index dir on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int hp = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.hp = hp;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hp on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxhp(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int maxhp = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.maxhp = maxhp;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxhp on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int comp = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.comp = comp;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index comp on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isBoss(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			bool isBoss = LuaDLL.luaL_checkboolean(L, 2);
			sceneEntity.isBoss = isBoss;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isBoss on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_hpType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int hpType = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.hpType = hpType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index hpType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_buffIdList(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			List<int> buffIdList = (List<int>)ToLua.CheckObject(L, 2, typeof(List<int>));
			sceneEntity.buffIdList = buffIdList;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index buffIdList on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bodyRadius(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			float bodyRadius = (float)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.bodyRadius = bodyRadius;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bodyRadius on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ownerId(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			string ownerId = ToLua.CheckString(L, 2);
			sceneEntity.ownerId = ownerId;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ownerId on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_npcBloodType(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int npcBloodType = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.npcBloodType = npcBloodType;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index npcBloodType on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_scaleNum(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			float scaleNum = (float)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.scaleNum = scaleNum;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index scaleNum on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_partnerFollow(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int partnerFollow = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.partnerFollow = partnerFollow;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partnerFollow on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_headNameYoffset(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			float headNameYoffset = (float)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.headNameYoffset = headNameYoffset;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index headNameYoffset on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isRide(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			bool isRide = LuaDLL.luaL_checkboolean(L, 2);
			sceneEntity.isRide = isRide;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isRide on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pkInfo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			string pkInfo = ToLua.CheckString(L, 2);
			sceneEntity.pkInfo = pkInfo;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pkInfo on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int score = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.score = score;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index score on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_attacker(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			SceneEntity attacker = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			sceneEntity.attacker = attacker;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index attacker on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_autoResetAttackerTimer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			float autoResetAttackerTimer = (float)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.autoResetAttackerTimer = autoResetAttackerTimer;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index autoResetAttackerTimer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_daZuo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int daZuo = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.daZuo = daZuo;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index daZuo on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int shield_hp = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.shield_hp = shield_hp;
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int shield_hpmax = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.shield_hpmax = shield_hpmax;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shield_hpmax on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int fashion = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.fashion = fashion;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fashion on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int shape = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.shape = shape;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shape on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int weapon = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.weapon = weapon;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index weapon on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lingqin(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int lingqin = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.lingqin = lingqin;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingqin on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lingyi(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int lingyi = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.lingyi = lingyi;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingyi on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_partnerhorse(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int partnerhorse = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.partnerhorse = partnerhorse;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partnerhorse on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pet(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int pet = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.pet = pet;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index pet on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shenjian(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int shenjian = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.shenjian = shenjian;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shenjian on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_shenyi(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int shenyi = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.shenyi = shenyi;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index shenyi on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_jingmai(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int jingmai = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.jingmai = jingmai;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jingmai on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int up_mount = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.up_mount = up_mount;
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			int up_horse = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.up_horse = up_horse;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index up_horse on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject model = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			sceneEntity.model = model;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_weapon_model(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject weapon_model = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			sceneEntity.weapon_model = weapon_model;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index weapon_model on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject lingqin_model = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			sceneEntity.lingqin_model = lingqin_model;
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject lingyi_model = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			sceneEntity.lingyi_model = lingyi_model;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingyi_model on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject partnerhorse_model = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			sceneEntity.partnerhorse_model = partnerhorse_model;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partnerhorse_model on a nil value");
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject pet_model = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			sceneEntity.pet_model = pet_model;
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject shenjian_model = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			sceneEntity.shenjian_model = shenjian_model;
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject shenyi_model = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			sceneEntity.shenyi_model = shenyi_model;
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
			SceneEntity sceneEntity = (SceneEntity)obj;
			GameObject jingmai_model = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			sceneEntity.jingmai_model = jingmai_model;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index jingmai_model on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lingqiObj(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			SceneEntity lingqiObj = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			sceneEntity.lingqiObj = lingqiObj;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingqiObj on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lingqiStr(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			string lingqiStr = ToLua.CheckString(L, 2);
			sceneEntity.lingqiStr = lingqiStr;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingqiStr on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_partnerObj(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			SceneEntity partnerObj = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			sceneEntity.partnerObj = partnerObj;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partnerObj on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_partnerStr(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			string partnerStr = ToLua.CheckString(L, 2);
			sceneEntity.partnerStr = partnerStr;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index partnerStr on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_petObj(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			SceneEntity petObj = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			sceneEntity.petObj = petObj;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index petObj on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_petStr(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int petStr = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.petStr = petStr;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index petStr on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_beautyObj(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			SceneEntity beautyObj = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			sceneEntity.beautyObj = beautyObj;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index beautyObj on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_beautyRare(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			int beautyRare = (int)LuaDLL.luaL_checknumber(L, 2);
			sceneEntity.beautyRare = beautyRare;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index beautyRare on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isBucket(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			bool isBucket = LuaDLL.luaL_checkboolean(L, 2);
			sceneEntity.isBucket = isBucket;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isBucket on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_extendInfo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SceneEntity sceneEntity = (SceneEntity)obj;
			Dictionary<string, object> extendInfo = (Dictionary<string, object>)ToLua.CheckObject(L, 2, typeof(Dictionary<string, object>));
			sceneEntity.extendInfo = extendInfo;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index extendInfo on a nil value");
		}
		return result;
	}
}
