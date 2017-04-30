using DG.Tweening;
using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_RigidbodyWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Rigidbody), typeof(Component), null);
		L.RegFunction("SetDensity", new LuaCSFunction(UnityEngine_RigidbodyWrap.SetDensity));
		L.RegFunction("AddForce", new LuaCSFunction(UnityEngine_RigidbodyWrap.AddForce));
		L.RegFunction("AddRelativeForce", new LuaCSFunction(UnityEngine_RigidbodyWrap.AddRelativeForce));
		L.RegFunction("AddTorque", new LuaCSFunction(UnityEngine_RigidbodyWrap.AddTorque));
		L.RegFunction("AddRelativeTorque", new LuaCSFunction(UnityEngine_RigidbodyWrap.AddRelativeTorque));
		L.RegFunction("AddForceAtPosition", new LuaCSFunction(UnityEngine_RigidbodyWrap.AddForceAtPosition));
		L.RegFunction("AddExplosionForce", new LuaCSFunction(UnityEngine_RigidbodyWrap.AddExplosionForce));
		L.RegFunction("ClosestPointOnBounds", new LuaCSFunction(UnityEngine_RigidbodyWrap.ClosestPointOnBounds));
		L.RegFunction("GetRelativePointVelocity", new LuaCSFunction(UnityEngine_RigidbodyWrap.GetRelativePointVelocity));
		L.RegFunction("GetPointVelocity", new LuaCSFunction(UnityEngine_RigidbodyWrap.GetPointVelocity));
		L.RegFunction("MovePosition", new LuaCSFunction(UnityEngine_RigidbodyWrap.MovePosition));
		L.RegFunction("MoveRotation", new LuaCSFunction(UnityEngine_RigidbodyWrap.MoveRotation));
		L.RegFunction("Sleep", new LuaCSFunction(UnityEngine_RigidbodyWrap.Sleep));
		L.RegFunction("IsSleeping", new LuaCSFunction(UnityEngine_RigidbodyWrap.IsSleeping));
		L.RegFunction("WakeUp", new LuaCSFunction(UnityEngine_RigidbodyWrap.WakeUp));
		L.RegFunction("ResetCenterOfMass", new LuaCSFunction(UnityEngine_RigidbodyWrap.ResetCenterOfMass));
		L.RegFunction("ResetInertiaTensor", new LuaCSFunction(UnityEngine_RigidbodyWrap.ResetInertiaTensor));
		L.RegFunction("SweepTest", new LuaCSFunction(UnityEngine_RigidbodyWrap.SweepTest));
		L.RegFunction("SweepTestAll", new LuaCSFunction(UnityEngine_RigidbodyWrap.SweepTestAll));
		L.RegFunction("DOJump", new LuaCSFunction(UnityEngine_RigidbodyWrap.DOJump));
		L.RegFunction("DOLookAt", new LuaCSFunction(UnityEngine_RigidbodyWrap.DOLookAt));
		L.RegFunction("DORotate", new LuaCSFunction(UnityEngine_RigidbodyWrap.DORotate));
		L.RegFunction("DOMoveZ", new LuaCSFunction(UnityEngine_RigidbodyWrap.DOMoveZ));
		L.RegFunction("DOMoveY", new LuaCSFunction(UnityEngine_RigidbodyWrap.DOMoveY));
		L.RegFunction("DOMoveX", new LuaCSFunction(UnityEngine_RigidbodyWrap.DOMoveX));
		L.RegFunction("DOMove", new LuaCSFunction(UnityEngine_RigidbodyWrap.DOMove));
		L.RegFunction("New", new LuaCSFunction(UnityEngine_RigidbodyWrap._CreateUnityEngine_Rigidbody));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_RigidbodyWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("velocity", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_velocity), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_velocity));
		L.RegVar("angularVelocity", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_angularVelocity), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_angularVelocity));
		L.RegVar("drag", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_drag), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_drag));
		L.RegVar("angularDrag", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_angularDrag), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_angularDrag));
		L.RegVar("mass", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_mass), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_mass));
		L.RegVar("useGravity", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_useGravity), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_useGravity));
		L.RegVar("maxDepenetrationVelocity", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_maxDepenetrationVelocity), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_maxDepenetrationVelocity));
		L.RegVar("isKinematic", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_isKinematic), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_isKinematic));
		L.RegVar("freezeRotation", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_freezeRotation), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_freezeRotation));
		L.RegVar("constraints", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_constraints), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_constraints));
		L.RegVar("collisionDetectionMode", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_collisionDetectionMode), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_collisionDetectionMode));
		L.RegVar("centerOfMass", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_centerOfMass), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_centerOfMass));
		L.RegVar("worldCenterOfMass", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_worldCenterOfMass), null);
		L.RegVar("inertiaTensorRotation", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_inertiaTensorRotation), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_inertiaTensorRotation));
		L.RegVar("inertiaTensor", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_inertiaTensor), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_inertiaTensor));
		L.RegVar("detectCollisions", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_detectCollisions), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_detectCollisions));
		L.RegVar("useConeFriction", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_useConeFriction), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_useConeFriction));
		L.RegVar("position", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_position), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_position));
		L.RegVar("rotation", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_rotation), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_rotation));
		L.RegVar("interpolation", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_interpolation), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_interpolation));
		L.RegVar("solverIterationCount", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_solverIterationCount), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_solverIterationCount));
		L.RegVar("sleepThreshold", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_sleepThreshold), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_sleepThreshold));
		L.RegVar("maxAngularVelocity", new LuaCSFunction(UnityEngine_RigidbodyWrap.get_maxAngularVelocity), new LuaCSFunction(UnityEngine_RigidbodyWrap.set_maxAngularVelocity));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateUnityEngine_Rigidbody(IntPtr L)
	{
		int result;
		try
		{
			if (LuaDLL.lua_gettop(L) == 0)
			{
				Rigidbody obj = new Rigidbody();
				ToLua.Push(L, obj);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.Rigidbody.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetDensity(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Rigidbody rigidbody = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			float density = (float)LuaDLL.luaL_checknumber(L, 2);
			rigidbody.SetDensity(density);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddForce(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3)))
			{
				Rigidbody rigidbody = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 force = ToLua.ToVector3(L, 2);
				rigidbody.AddForce(force);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3), typeof(ForceMode)))
			{
				Rigidbody rigidbody2 = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 force2 = ToLua.ToVector3(L, 2);
				ForceMode mode = (ForceMode)((int)ToLua.ToObject(L, 3));
				rigidbody2.AddForce(force2, mode);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(float), typeof(float), typeof(float)))
			{
				Rigidbody rigidbody3 = (Rigidbody)ToLua.ToObject(L, 1);
				float x = (float)LuaDLL.lua_tonumber(L, 2);
				float y = (float)LuaDLL.lua_tonumber(L, 3);
				float z = (float)LuaDLL.lua_tonumber(L, 4);
				rigidbody3.AddForce(x, y, z);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(float), typeof(float), typeof(float), typeof(ForceMode)))
			{
				Rigidbody rigidbody4 = (Rigidbody)ToLua.ToObject(L, 1);
				float x2 = (float)LuaDLL.lua_tonumber(L, 2);
				float y2 = (float)LuaDLL.lua_tonumber(L, 3);
				float z2 = (float)LuaDLL.lua_tonumber(L, 4);
				ForceMode mode2 = (ForceMode)((int)ToLua.ToObject(L, 5));
				rigidbody4.AddForce(x2, y2, z2, mode2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Rigidbody.AddForce");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddRelativeForce(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3)))
			{
				Rigidbody rigidbody = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 force = ToLua.ToVector3(L, 2);
				rigidbody.AddRelativeForce(force);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3), typeof(ForceMode)))
			{
				Rigidbody rigidbody2 = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 force2 = ToLua.ToVector3(L, 2);
				ForceMode mode = (ForceMode)((int)ToLua.ToObject(L, 3));
				rigidbody2.AddRelativeForce(force2, mode);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(float), typeof(float), typeof(float)))
			{
				Rigidbody rigidbody3 = (Rigidbody)ToLua.ToObject(L, 1);
				float x = (float)LuaDLL.lua_tonumber(L, 2);
				float y = (float)LuaDLL.lua_tonumber(L, 3);
				float z = (float)LuaDLL.lua_tonumber(L, 4);
				rigidbody3.AddRelativeForce(x, y, z);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(float), typeof(float), typeof(float), typeof(ForceMode)))
			{
				Rigidbody rigidbody4 = (Rigidbody)ToLua.ToObject(L, 1);
				float x2 = (float)LuaDLL.lua_tonumber(L, 2);
				float y2 = (float)LuaDLL.lua_tonumber(L, 3);
				float z2 = (float)LuaDLL.lua_tonumber(L, 4);
				ForceMode mode2 = (ForceMode)((int)ToLua.ToObject(L, 5));
				rigidbody4.AddRelativeForce(x2, y2, z2, mode2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Rigidbody.AddRelativeForce");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddTorque(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3)))
			{
				Rigidbody rigidbody = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 torque = ToLua.ToVector3(L, 2);
				rigidbody.AddTorque(torque);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3), typeof(ForceMode)))
			{
				Rigidbody rigidbody2 = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 torque2 = ToLua.ToVector3(L, 2);
				ForceMode mode = (ForceMode)((int)ToLua.ToObject(L, 3));
				rigidbody2.AddTorque(torque2, mode);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(float), typeof(float), typeof(float)))
			{
				Rigidbody rigidbody3 = (Rigidbody)ToLua.ToObject(L, 1);
				float x = (float)LuaDLL.lua_tonumber(L, 2);
				float y = (float)LuaDLL.lua_tonumber(L, 3);
				float z = (float)LuaDLL.lua_tonumber(L, 4);
				rigidbody3.AddTorque(x, y, z);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(float), typeof(float), typeof(float), typeof(ForceMode)))
			{
				Rigidbody rigidbody4 = (Rigidbody)ToLua.ToObject(L, 1);
				float x2 = (float)LuaDLL.lua_tonumber(L, 2);
				float y2 = (float)LuaDLL.lua_tonumber(L, 3);
				float z2 = (float)LuaDLL.lua_tonumber(L, 4);
				ForceMode mode2 = (ForceMode)((int)ToLua.ToObject(L, 5));
				rigidbody4.AddTorque(x2, y2, z2, mode2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Rigidbody.AddTorque");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddRelativeTorque(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3)))
			{
				Rigidbody rigidbody = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 torque = ToLua.ToVector3(L, 2);
				rigidbody.AddRelativeTorque(torque);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3), typeof(ForceMode)))
			{
				Rigidbody rigidbody2 = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 torque2 = ToLua.ToVector3(L, 2);
				ForceMode mode = (ForceMode)((int)ToLua.ToObject(L, 3));
				rigidbody2.AddRelativeTorque(torque2, mode);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(float), typeof(float), typeof(float)))
			{
				Rigidbody rigidbody3 = (Rigidbody)ToLua.ToObject(L, 1);
				float x = (float)LuaDLL.lua_tonumber(L, 2);
				float y = (float)LuaDLL.lua_tonumber(L, 3);
				float z = (float)LuaDLL.lua_tonumber(L, 4);
				rigidbody3.AddRelativeTorque(x, y, z);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(float), typeof(float), typeof(float), typeof(ForceMode)))
			{
				Rigidbody rigidbody4 = (Rigidbody)ToLua.ToObject(L, 1);
				float x2 = (float)LuaDLL.lua_tonumber(L, 2);
				float y2 = (float)LuaDLL.lua_tonumber(L, 3);
				float z2 = (float)LuaDLL.lua_tonumber(L, 4);
				ForceMode mode2 = (ForceMode)((int)ToLua.ToObject(L, 5));
				rigidbody4.AddRelativeTorque(x2, y2, z2, mode2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Rigidbody.AddRelativeTorque");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddForceAtPosition(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3), typeof(Vector3)))
			{
				Rigidbody rigidbody = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 force = ToLua.ToVector3(L, 2);
				Vector3 position = ToLua.ToVector3(L, 3);
				rigidbody.AddForceAtPosition(force, position);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3), typeof(Vector3), typeof(ForceMode)))
			{
				Rigidbody rigidbody2 = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 force2 = ToLua.ToVector3(L, 2);
				Vector3 position2 = ToLua.ToVector3(L, 3);
				ForceMode mode = (ForceMode)((int)ToLua.ToObject(L, 4));
				rigidbody2.AddForceAtPosition(force2, position2, mode);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Rigidbody.AddForceAtPosition");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddExplosionForce(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(float), typeof(Vector3), typeof(float)))
			{
				Rigidbody rigidbody = (Rigidbody)ToLua.ToObject(L, 1);
				float explosionForce = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 explosionPosition = ToLua.ToVector3(L, 3);
				float explosionRadius = (float)LuaDLL.lua_tonumber(L, 4);
				rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(float), typeof(Vector3), typeof(float), typeof(float)))
			{
				Rigidbody rigidbody2 = (Rigidbody)ToLua.ToObject(L, 1);
				float explosionForce2 = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 explosionPosition2 = ToLua.ToVector3(L, 3);
				float explosionRadius2 = (float)LuaDLL.lua_tonumber(L, 4);
				float upwardsModifier = (float)LuaDLL.lua_tonumber(L, 5);
				rigidbody2.AddExplosionForce(explosionForce2, explosionPosition2, explosionRadius2, upwardsModifier);
				result = 0;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(float), typeof(Vector3), typeof(float), typeof(float), typeof(ForceMode)))
			{
				Rigidbody rigidbody3 = (Rigidbody)ToLua.ToObject(L, 1);
				float explosionForce3 = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 explosionPosition3 = ToLua.ToVector3(L, 3);
				float explosionRadius3 = (float)LuaDLL.lua_tonumber(L, 4);
				float upwardsModifier2 = (float)LuaDLL.lua_tonumber(L, 5);
				ForceMode mode = (ForceMode)((int)ToLua.ToObject(L, 6));
				rigidbody3.AddExplosionForce(explosionForce3, explosionPosition3, explosionRadius3, upwardsModifier2, mode);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Rigidbody.AddExplosionForce");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClosestPointOnBounds(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Rigidbody rigidbody = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			Vector3 position = ToLua.ToVector3(L, 2);
			Vector3 v = rigidbody.ClosestPointOnBounds(position);
			ToLua.Push(L, v);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetRelativePointVelocity(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Rigidbody rigidbody = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			Vector3 relativePoint = ToLua.ToVector3(L, 2);
			Vector3 relativePointVelocity = rigidbody.GetRelativePointVelocity(relativePoint);
			ToLua.Push(L, relativePointVelocity);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetPointVelocity(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Rigidbody rigidbody = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			Vector3 worldPoint = ToLua.ToVector3(L, 2);
			Vector3 pointVelocity = rigidbody.GetPointVelocity(worldPoint);
			ToLua.Push(L, pointVelocity);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MovePosition(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Rigidbody rigidbody = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			Vector3 position = ToLua.ToVector3(L, 2);
			rigidbody.MovePosition(position);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MoveRotation(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Rigidbody rigidbody = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			Quaternion rot = ToLua.ToQuaternion(L, 2);
			rigidbody.MoveRotation(rot);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Sleep(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Rigidbody rigidbody = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			rigidbody.Sleep();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsSleeping(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Rigidbody rigidbody = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			bool value = rigidbody.IsSleeping();
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
	private static int WakeUp(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Rigidbody rigidbody = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			rigidbody.WakeUp();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetCenterOfMass(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Rigidbody rigidbody = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			rigidbody.ResetCenterOfMass();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ResetInertiaTensor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Rigidbody rigidbody = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			rigidbody.ResetInertiaTensor();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SweepTest(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3), typeof(LuaOut<RaycastHit>)))
			{
				Rigidbody rigidbody = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 direction = ToLua.ToVector3(L, 2);
				RaycastHit hit;
				bool value = rigidbody.SweepTest(direction, out hit);
				LuaDLL.lua_pushboolean(L, value);
				ToLua.Push(L, hit);
				result = 2;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(float)))
			{
				Rigidbody rigidbody2 = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 direction2 = ToLua.ToVector3(L, 2);
				float maxDistance = (float)LuaDLL.lua_tonumber(L, 4);
				RaycastHit hit2;
				bool value2 = rigidbody2.SweepTest(direction2, out hit2, maxDistance);
				LuaDLL.lua_pushboolean(L, value2);
				ToLua.Push(L, hit2);
				result = 2;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(float), typeof(QueryTriggerInteraction)))
			{
				Rigidbody rigidbody3 = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 direction3 = ToLua.ToVector3(L, 2);
				float maxDistance2 = (float)LuaDLL.lua_tonumber(L, 4);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 5));
				RaycastHit hit3;
				bool value3 = rigidbody3.SweepTest(direction3, out hit3, maxDistance2, queryTriggerInteraction);
				LuaDLL.lua_pushboolean(L, value3);
				ToLua.Push(L, hit3);
				result = 2;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Rigidbody.SweepTest");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SweepTestAll(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3)))
			{
				Rigidbody rigidbody = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 direction = ToLua.ToVector3(L, 2);
				RaycastHit[] array = rigidbody.SweepTestAll(direction);
				ToLua.Push(L, array);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3), typeof(float)))
			{
				Rigidbody rigidbody2 = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 direction2 = ToLua.ToVector3(L, 2);
				float maxDistance = (float)LuaDLL.lua_tonumber(L, 3);
				RaycastHit[] array2 = rigidbody2.SweepTestAll(direction2, maxDistance);
				ToLua.Push(L, array2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Rigidbody), typeof(Vector3), typeof(float), typeof(QueryTriggerInteraction)))
			{
				Rigidbody rigidbody3 = (Rigidbody)ToLua.ToObject(L, 1);
				Vector3 direction3 = ToLua.ToVector3(L, 2);
				float maxDistance2 = (float)LuaDLL.lua_tonumber(L, 3);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 4));
				RaycastHit[] array3 = rigidbody3.SweepTestAll(direction3, maxDistance2, queryTriggerInteraction);
				ToLua.Push(L, array3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Rigidbody.SweepTestAll");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DOJump(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 6);
			Rigidbody target = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			Vector3 endValue = ToLua.ToVector3(L, 2);
			float jumpPower = (float)LuaDLL.luaL_checknumber(L, 3);
			int numJumps = (int)LuaDLL.luaL_checknumber(L, 4);
			float duration = (float)LuaDLL.luaL_checknumber(L, 5);
			bool snapping = LuaDLL.luaL_checkboolean(L, 6);
			Sequence o = target.DOJump(endValue, jumpPower, numJumps, duration, snapping);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DOLookAt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			Rigidbody target = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			Vector3 towards = ToLua.ToVector3(L, 2);
			float duration = (float)LuaDLL.luaL_checknumber(L, 3);
			AxisConstraint axisConstraint = (AxisConstraint)((int)ToLua.CheckObject(L, 4, typeof(AxisConstraint)));
			Vector3? up = (Vector3?)ToLua.CheckVarObject(L, 5, typeof(Vector3?));
			Tweener o = target.DOLookAt(towards, duration, axisConstraint, up);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DORotate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			Rigidbody target = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			Vector3 endValue = ToLua.ToVector3(L, 2);
			float duration = (float)LuaDLL.luaL_checknumber(L, 3);
			RotateMode mode = (RotateMode)((int)ToLua.CheckObject(L, 4, typeof(RotateMode)));
			Tweener o = target.DORotate(endValue, duration, mode);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DOMoveZ(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			Rigidbody target = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			float endValue = (float)LuaDLL.luaL_checknumber(L, 2);
			float duration = (float)LuaDLL.luaL_checknumber(L, 3);
			bool snapping = LuaDLL.luaL_checkboolean(L, 4);
			Tweener o = target.DOMoveZ(endValue, duration, snapping);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DOMoveY(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			Rigidbody target = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			float endValue = (float)LuaDLL.luaL_checknumber(L, 2);
			float duration = (float)LuaDLL.luaL_checknumber(L, 3);
			bool snapping = LuaDLL.luaL_checkboolean(L, 4);
			Tweener o = target.DOMoveY(endValue, duration, snapping);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DOMoveX(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			Rigidbody target = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			float endValue = (float)LuaDLL.luaL_checknumber(L, 2);
			float duration = (float)LuaDLL.luaL_checknumber(L, 3);
			bool snapping = LuaDLL.luaL_checkboolean(L, 4);
			Tweener o = target.DOMoveX(endValue, duration, snapping);
			ToLua.PushObject(L, o);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DOMove(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			Rigidbody target = (Rigidbody)ToLua.CheckObject(L, 1, typeof(Rigidbody));
			Vector3 endValue = ToLua.ToVector3(L, 2);
			float duration = (float)LuaDLL.luaL_checknumber(L, 3);
			bool snapping = LuaDLL.luaL_checkboolean(L, 4);
			Tweener o = target.DOMove(endValue, duration, snapping);
			ToLua.PushObject(L, o);
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
	private static int get_velocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			Vector3 velocity = rigidbody.velocity;
			ToLua.Push(L, velocity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index velocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_angularVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			Vector3 angularVelocity = rigidbody.angularVelocity;
			ToLua.Push(L, angularVelocity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index angularVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_drag(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			float drag = rigidbody.drag;
			LuaDLL.lua_pushnumber(L, (double)drag);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index drag on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_angularDrag(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			float angularDrag = rigidbody.angularDrag;
			LuaDLL.lua_pushnumber(L, (double)angularDrag);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index angularDrag on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_mass(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			float mass = rigidbody.mass;
			LuaDLL.lua_pushnumber(L, (double)mass);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mass on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useGravity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			bool useGravity = rigidbody.useGravity;
			LuaDLL.lua_pushboolean(L, useGravity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useGravity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxDepenetrationVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			float maxDepenetrationVelocity = rigidbody.maxDepenetrationVelocity;
			LuaDLL.lua_pushnumber(L, (double)maxDepenetrationVelocity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxDepenetrationVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isKinematic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			bool isKinematic = rigidbody.isKinematic;
			LuaDLL.lua_pushboolean(L, isKinematic);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isKinematic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_freezeRotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			bool freezeRotation = rigidbody.freezeRotation;
			LuaDLL.lua_pushboolean(L, freezeRotation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index freezeRotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_constraints(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			RigidbodyConstraints constraints = rigidbody.constraints;
			ToLua.Push(L, constraints);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index constraints on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_collisionDetectionMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			CollisionDetectionMode collisionDetectionMode = rigidbody.collisionDetectionMode;
			ToLua.Push(L, collisionDetectionMode);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index collisionDetectionMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_centerOfMass(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			Vector3 centerOfMass = rigidbody.centerOfMass;
			ToLua.Push(L, centerOfMass);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index centerOfMass on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_worldCenterOfMass(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			Vector3 worldCenterOfMass = rigidbody.worldCenterOfMass;
			ToLua.Push(L, worldCenterOfMass);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldCenterOfMass on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_inertiaTensorRotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			Quaternion inertiaTensorRotation = rigidbody.inertiaTensorRotation;
			ToLua.Push(L, inertiaTensorRotation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index inertiaTensorRotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_inertiaTensor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			Vector3 inertiaTensor = rigidbody.inertiaTensor;
			ToLua.Push(L, inertiaTensor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index inertiaTensor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_detectCollisions(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			bool detectCollisions = rigidbody.detectCollisions;
			LuaDLL.lua_pushboolean(L, detectCollisions);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index detectCollisions on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useConeFriction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			bool useConeFriction = rigidbody.useConeFriction;
			LuaDLL.lua_pushboolean(L, useConeFriction);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useConeFriction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_position(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			Vector3 position = rigidbody.position;
			ToLua.Push(L, position);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index position on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			Quaternion rotation = rigidbody.rotation;
			ToLua.Push(L, rotation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_interpolation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			RigidbodyInterpolation interpolation = rigidbody.interpolation;
			ToLua.Push(L, interpolation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index interpolation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_solverIterationCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			int solverIterationCount = rigidbody.solverIterationCount;
			LuaDLL.lua_pushinteger(L, solverIterationCount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index solverIterationCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sleepThreshold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			float sleepThreshold = rigidbody.sleepThreshold;
			LuaDLL.lua_pushnumber(L, (double)sleepThreshold);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sleepThreshold on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxAngularVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			float maxAngularVelocity = rigidbody.maxAngularVelocity;
			LuaDLL.lua_pushnumber(L, (double)maxAngularVelocity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxAngularVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_velocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			Vector3 velocity = ToLua.ToVector3(L, 2);
			rigidbody.velocity = velocity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index velocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_angularVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			Vector3 angularVelocity = ToLua.ToVector3(L, 2);
			rigidbody.angularVelocity = angularVelocity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index angularVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_drag(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			float drag = (float)LuaDLL.luaL_checknumber(L, 2);
			rigidbody.drag = drag;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index drag on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_angularDrag(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			float angularDrag = (float)LuaDLL.luaL_checknumber(L, 2);
			rigidbody.angularDrag = angularDrag;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index angularDrag on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_mass(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			float mass = (float)LuaDLL.luaL_checknumber(L, 2);
			rigidbody.mass = mass;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index mass on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useGravity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			bool useGravity = LuaDLL.luaL_checkboolean(L, 2);
			rigidbody.useGravity = useGravity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useGravity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxDepenetrationVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			float maxDepenetrationVelocity = (float)LuaDLL.luaL_checknumber(L, 2);
			rigidbody.maxDepenetrationVelocity = maxDepenetrationVelocity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxDepenetrationVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isKinematic(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			bool isKinematic = LuaDLL.luaL_checkboolean(L, 2);
			rigidbody.isKinematic = isKinematic;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isKinematic on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_freezeRotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			bool freezeRotation = LuaDLL.luaL_checkboolean(L, 2);
			rigidbody.freezeRotation = freezeRotation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index freezeRotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_constraints(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			RigidbodyConstraints constraints = (RigidbodyConstraints)((int)ToLua.CheckObject(L, 2, typeof(RigidbodyConstraints)));
			rigidbody.constraints = constraints;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index constraints on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_collisionDetectionMode(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			CollisionDetectionMode collisionDetectionMode = (CollisionDetectionMode)((int)ToLua.CheckObject(L, 2, typeof(CollisionDetectionMode)));
			rigidbody.collisionDetectionMode = collisionDetectionMode;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index collisionDetectionMode on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_centerOfMass(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			Vector3 centerOfMass = ToLua.ToVector3(L, 2);
			rigidbody.centerOfMass = centerOfMass;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index centerOfMass on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_inertiaTensorRotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			Quaternion inertiaTensorRotation = ToLua.ToQuaternion(L, 2);
			rigidbody.inertiaTensorRotation = inertiaTensorRotation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index inertiaTensorRotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_inertiaTensor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			Vector3 inertiaTensor = ToLua.ToVector3(L, 2);
			rigidbody.inertiaTensor = inertiaTensor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index inertiaTensor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_detectCollisions(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			bool detectCollisions = LuaDLL.luaL_checkboolean(L, 2);
			rigidbody.detectCollisions = detectCollisions;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index detectCollisions on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useConeFriction(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			bool useConeFriction = LuaDLL.luaL_checkboolean(L, 2);
			rigidbody.useConeFriction = useConeFriction;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useConeFriction on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_position(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			Vector3 position = ToLua.ToVector3(L, 2);
			rigidbody.position = position;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index position on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			Quaternion rotation = ToLua.ToQuaternion(L, 2);
			rigidbody.rotation = rotation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rotation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_interpolation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			RigidbodyInterpolation interpolation = (RigidbodyInterpolation)((int)ToLua.CheckObject(L, 2, typeof(RigidbodyInterpolation)));
			rigidbody.interpolation = interpolation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index interpolation on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_solverIterationCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			int solverIterationCount = (int)LuaDLL.luaL_checknumber(L, 2);
			rigidbody.solverIterationCount = solverIterationCount;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index solverIterationCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sleepThreshold(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			float sleepThreshold = (float)LuaDLL.luaL_checknumber(L, 2);
			rigidbody.sleepThreshold = sleepThreshold;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sleepThreshold on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxAngularVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Rigidbody rigidbody = (Rigidbody)obj;
			float maxAngularVelocity = (float)LuaDLL.luaL_checknumber(L, 2);
			rigidbody.maxAngularVelocity = maxAngularVelocity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxAngularVelocity on a nil value");
		}
		return result;
	}
}
