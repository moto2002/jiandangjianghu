using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using Xft;

public class RoleActionWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(RoleAction), typeof(MonoBehaviour), null);
		L.RegFunction("ResetRoleAnimation", new LuaCSFunction(RoleActionWrap.ResetRoleAnimation));
		L.RegFunction("ResetWingsAnimation", new LuaCSFunction(RoleActionWrap.ResetWingsAnimation));
		L.RegFunction("ResetLingQinAnimation", new LuaCSFunction(RoleActionWrap.ResetLingQinAnimation));
		L.RegFunction("SetActionStatus", new LuaCSFunction(RoleActionWrap.SetActionStatus));
		L.RegFunction("SetReliveStatus", new LuaCSFunction(RoleActionWrap.SetReliveStatus));
		L.RegFunction("SetRoleIdle", new LuaCSFunction(RoleActionWrap.SetRoleIdle));
		L.RegFunction("SetRoleMove", new LuaCSFunction(RoleActionWrap.SetRoleMove));
		L.RegFunction("SetRoleJump", new LuaCSFunction(RoleActionWrap.SetRoleJump));
		L.RegFunction("SetRoleFall", new LuaCSFunction(RoleActionWrap.SetRoleFall));
		L.RegFunction("SetAttackCombo", new LuaCSFunction(RoleActionWrap.SetAttackCombo));
		L.RegFunction("ResetToIdleImmediate", new LuaCSFunction(RoleActionWrap.ResetToIdleImmediate));
		L.RegFunction("Stop", new LuaCSFunction(RoleActionWrap.Stop));
		L.RegFunction("CanJump", new LuaCSFunction(RoleActionWrap.CanJump));
		L.RegFunction("CancelHurt", new LuaCSFunction(RoleActionWrap.CancelHurt));
		L.RegFunction("NeedWaitToIdle", new LuaCSFunction(RoleActionWrap.NeedWaitToIdle));
		L.RegFunction("IsLoopAction", new LuaCSFunction(RoleActionWrap.IsLoopAction));
		L.RegFunction("__eq", new LuaCSFunction(RoleActionWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("self", new LuaCSFunction(RoleActionWrap.get_self), new LuaCSFunction(RoleActionWrap.set_self));
		L.RegVar("weaponTrails", new LuaCSFunction(RoleActionWrap.get_weaponTrails), new LuaCSFunction(RoleActionWrap.set_weaponTrails));
		L.RegVar("animator", new LuaCSFunction(RoleActionWrap.get_animator), new LuaCSFunction(RoleActionWrap.set_animator));
		L.RegVar("horseAnimator", new LuaCSFunction(RoleActionWrap.get_horseAnimator), new LuaCSFunction(RoleActionWrap.set_horseAnimator));
		L.RegVar("wingAnimator", new LuaCSFunction(RoleActionWrap.get_wingAnimator), new LuaCSFunction(RoleActionWrap.set_wingAnimator));
		L.RegVar("lingyiAnimator", new LuaCSFunction(RoleActionWrap.get_lingyiAnimator), new LuaCSFunction(RoleActionWrap.set_lingyiAnimator));
		L.RegVar("lingqinAnimator", new LuaCSFunction(RoleActionWrap.get_lingqinAnimator), new LuaCSFunction(RoleActionWrap.set_lingqinAnimator));
		L.RegVar("curStatus", new LuaCSFunction(RoleActionWrap.get_curStatus), new LuaCSFunction(RoleActionWrap.set_curStatus));
		L.RegVar("curNextStatus", new LuaCSFunction(RoleActionWrap.get_curNextStatus), new LuaCSFunction(RoleActionWrap.set_curNextStatus));
		L.RegVar("inAttackCombo", new LuaCSFunction(RoleActionWrap.get_inAttackCombo), new LuaCSFunction(RoleActionWrap.set_inAttackCombo));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetRoleAnimation(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			GameObject model = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			roleAction.ResetRoleAnimation(model);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetWingsAnimation(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			GameObject model = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			roleAction.ResetWingsAnimation(model);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetLingQinAnimation(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			GameObject model = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			roleAction.ResetLingQinAnimation(model);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetActionStatus(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			int actionStatus = (int)LuaDLL.luaL_checknumber(L, 2);
			roleAction.SetActionStatus(actionStatus);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetReliveStatus(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			roleAction.SetReliveStatus();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetRoleIdle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			roleAction.SetRoleIdle();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetRoleMove(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			int roleMove = (int)LuaDLL.luaL_checknumber(L, 2);
			roleAction.SetRoleMove(roleMove);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetRoleJump(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			int roleJump = (int)LuaDLL.luaL_checknumber(L, 2);
			int n = roleAction.SetRoleJump(roleJump);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetRoleFall(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			int roleFall = (int)LuaDLL.luaL_checknumber(L, 2);
			roleAction.SetRoleFall(roleFall);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetAttackCombo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			roleAction.SetAttackCombo();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetToIdleImmediate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			roleAction.ResetToIdleImmediate();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Stop(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			bool value = roleAction.Stop();
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
	private static int CanJump(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			bool value = roleAction.CanJump();
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
	private static int CancelHurt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			bool value = roleAction.CancelHurt();
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
	private static int NeedWaitToIdle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			bool value = roleAction.NeedWaitToIdle();
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
	private static int IsLoopAction(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RoleAction roleAction = (RoleAction)ToLua.CheckObject(L, 1, typeof(RoleAction));
			bool value = roleAction.IsLoopAction();
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
	private static int get_self(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			SceneEntity self = roleAction.self;
			ToLua.Push(L, self);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index self on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_weaponTrails(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			List<XWeaponTrail> weaponTrails = roleAction.weaponTrails;
			ToLua.PushObject(L, weaponTrails);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index weaponTrails on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_animator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			Animator animator = roleAction.animator;
			ToLua.Push(L, animator);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index animator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_horseAnimator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			Animator horseAnimator = roleAction.horseAnimator;
			ToLua.Push(L, horseAnimator);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horseAnimator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_wingAnimator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			Animator wingAnimator = roleAction.wingAnimator;
			ToLua.Push(L, wingAnimator);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index wingAnimator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lingyiAnimator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			Animator lingyiAnimator = roleAction.lingyiAnimator;
			ToLua.Push(L, lingyiAnimator);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingyiAnimator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_lingqinAnimator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			Animator lingqinAnimator = roleAction.lingqinAnimator;
			ToLua.Push(L, lingqinAnimator);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingqinAnimator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_curStatus(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			int curStatus = roleAction.curStatus;
			LuaDLL.lua_pushinteger(L, curStatus);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index curStatus on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_curNextStatus(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			int curNextStatus = roleAction.curNextStatus;
			LuaDLL.lua_pushinteger(L, curNextStatus);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index curNextStatus on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_inAttackCombo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			bool inAttackCombo = roleAction.inAttackCombo;
			LuaDLL.lua_pushboolean(L, inAttackCombo);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index inAttackCombo on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_self(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			SceneEntity self = (SceneEntity)ToLua.CheckUnityObject(L, 2, typeof(SceneEntity));
			roleAction.self = self;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index self on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_weaponTrails(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			List<XWeaponTrail> weaponTrails = (List<XWeaponTrail>)ToLua.CheckObject(L, 2, typeof(List<XWeaponTrail>));
			roleAction.weaponTrails = weaponTrails;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index weaponTrails on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_animator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			Animator animator = (Animator)ToLua.CheckUnityObject(L, 2, typeof(Animator));
			roleAction.animator = animator;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index animator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_horseAnimator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			Animator horseAnimator = (Animator)ToLua.CheckUnityObject(L, 2, typeof(Animator));
			roleAction.horseAnimator = horseAnimator;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index horseAnimator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_wingAnimator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			Animator wingAnimator = (Animator)ToLua.CheckUnityObject(L, 2, typeof(Animator));
			roleAction.wingAnimator = wingAnimator;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index wingAnimator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lingyiAnimator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			Animator lingyiAnimator = (Animator)ToLua.CheckUnityObject(L, 2, typeof(Animator));
			roleAction.lingyiAnimator = lingyiAnimator;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingyiAnimator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_lingqinAnimator(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			Animator lingqinAnimator = (Animator)ToLua.CheckUnityObject(L, 2, typeof(Animator));
			roleAction.lingqinAnimator = lingqinAnimator;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index lingqinAnimator on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_curStatus(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			int curStatus = (int)LuaDLL.luaL_checknumber(L, 2);
			roleAction.curStatus = curStatus;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index curStatus on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_curNextStatus(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			int curNextStatus = (int)LuaDLL.luaL_checknumber(L, 2);
			roleAction.curNextStatus = curNextStatus;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index curNextStatus on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_inAttackCombo(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			RoleAction roleAction = (RoleAction)obj;
			bool inAttackCombo = LuaDLL.luaL_checkboolean(L, 2);
			roleAction.inAttackCombo = inAttackCombo;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index inAttackCombo on a nil value");
		}
		return result;
	}
}
