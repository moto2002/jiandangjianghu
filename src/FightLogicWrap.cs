using LuaInterface;
using System;
using ThirdParty;
using UnityEngine;

public class FightLogicWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(FightLogic), typeof(Singleton<FightLogic>), null);
		L.RegFunction("GetInstance", new LuaCSFunction(FightLogicWrap.GetInstance));
		L.RegFunction("GetSkillTargetPos", new LuaCSFunction(FightLogicWrap.GetSkillTargetPos));
		L.RegFunction("SkillBtnClick", new LuaCSFunction(FightLogicWrap.SkillBtnClick));
		L.RegFunction("GetCanCastSkill", new LuaCSFunction(FightLogicWrap.GetCanCastSkill));
		L.RegFunction("CancelMove", new LuaCSFunction(FightLogicWrap.CancelMove));
		L.RegFunction("GetTargetHeadPos", new LuaCSFunction(FightLogicWrap.GetTargetHeadPos));
		L.RegFunction("GetTargetHurtPos", new LuaCSFunction(FightLogicWrap.GetTargetHurtPos));
		L.RegFunction("CastSkill", new LuaCSFunction(FightLogicWrap.CastSkill));
		L.RegFunction("SetSkillInfo", new LuaCSFunction(FightLogicWrap.SetSkillInfo));
		L.RegFunction("SkillRunToTarget", new LuaCSFunction(FightLogicWrap.SkillRunToTarget));
		L.RegFunction("__eq", new LuaCSFunction(FightLogicWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetInstance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			FightLogic instance = FightLogic.GetInstance();
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
	private static int GetSkillTargetPos(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			int tx = (int)LuaDLL.luaL_checknumber(L, 1);
			int ty = (int)LuaDLL.luaL_checknumber(L, 2);
			string axyz = ToLua.CheckString(L, 3);
			SceneEntity obj = (SceneEntity)ToLua.CheckUnityObject(L, 4, typeof(SceneEntity));
			Vector3 skillTargetPos = FightLogic.GetSkillTargetPos(tx, ty, axyz, obj);
			ToLua.Push(L, skillTargetPos);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SkillBtnClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			FightLogic fightLogic = (FightLogic)ToLua.CheckObject(L, 1, typeof(FightLogic));
			fightLogic.SkillBtnClick();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetCanCastSkill(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			bool canCastSkill = FightLogic.GetCanCastSkill();
			LuaDLL.lua_pushboolean(L, canCastSkill);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CancelMove(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FightLogic fightLogic = (FightLogic)ToLua.CheckObject(L, 1, typeof(FightLogic));
			SceneEntity obj = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			fightLogic.CancelMove(obj);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTargetHeadPos(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FightLogic fightLogic = (FightLogic)ToLua.CheckObject(L, 1, typeof(FightLogic));
			SceneEntity target = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			Vector3 targetHeadPos = fightLogic.GetTargetHeadPos(target);
			ToLua.Push(L, targetHeadPos);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetTargetHurtPos(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			FightLogic fightLogic = (FightLogic)ToLua.CheckObject(L, 1, typeof(FightLogic));
			SceneEntity target = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			Vector3 targetHurtPos = fightLogic.GetTargetHurtPos(target);
			ToLua.Push(L, targetHurtPos);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CastSkill(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 12);
			FightLogic fightLogic = (FightLogic)ToLua.CheckObject(L, 1, typeof(FightLogic));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			int skillId = (int)LuaDLL.luaL_checknumber(L, 3);
			int skillType = (int)LuaDLL.luaL_checknumber(L, 4);
			int stamp = (int)LuaDLL.luaL_checknumber(L, 5);
			string folderName = ToLua.CheckString(L, 6);
			string prefabName = ToLua.CheckString(L, 7);
			string target_id = ToLua.CheckString(L, 8);
			Vector3 targetPos = ToLua.ToVector3(L, 9);
			bool needneedFeedback = LuaDLL.luaL_checkboolean(L, 10);
			string[] targetIds = ToLua.CheckStringArray(L, 11);
			bool isAct = LuaDLL.luaL_checkboolean(L, 12);
			GameObject obj = fightLogic.CastSkill(go, skillId, skillType, stamp, folderName, prefabName, target_id, targetPos, needneedFeedback, targetIds, isAct);
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
	private static int SetSkillInfo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			FightLogic fightLogic = (FightLogic)ToLua.CheckObject(L, 1, typeof(FightLogic));
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			GameObject skill = (GameObject)ToLua.CheckUnityObject(L, 3, typeof(GameObject));
			int skillType = (int)LuaDLL.luaL_checknumber(L, 4);
			bool showEff = LuaDLL.luaL_checkboolean(L, 5);
			fightLogic.SetSkillInfo(obj, skill, skillType, showEff);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SkillRunToTarget(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			FightLogic fightLogic = (FightLogic)ToLua.CheckObject(L, 1, typeof(FightLogic));
			SceneEntity attacker = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			GameObject targetGo = (GameObject)ToLua.CheckUnityObject(L, 3, typeof(GameObject));
			float radius = (float)LuaDLL.luaL_checknumber(L, 4);
			bool needDash = LuaDLL.luaL_checkboolean(L, 5);
			fightLogic.SkillRunToTarget(attacker, targetGo, radius, needDash);
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
