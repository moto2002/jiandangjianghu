using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_PhysicsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("Physics");
		L.RegFunction("Raycast", new LuaCSFunction(UnityEngine_PhysicsWrap.Raycast));
		L.RegFunction("RaycastAll", new LuaCSFunction(UnityEngine_PhysicsWrap.RaycastAll));
		L.RegFunction("RaycastNonAlloc", new LuaCSFunction(UnityEngine_PhysicsWrap.RaycastNonAlloc));
		L.RegFunction("Linecast", new LuaCSFunction(UnityEngine_PhysicsWrap.Linecast));
		L.RegFunction("OverlapSphere", new LuaCSFunction(UnityEngine_PhysicsWrap.OverlapSphere));
		L.RegFunction("OverlapSphereNonAlloc", new LuaCSFunction(UnityEngine_PhysicsWrap.OverlapSphereNonAlloc));
		L.RegFunction("CapsuleCast", new LuaCSFunction(UnityEngine_PhysicsWrap.CapsuleCast));
		L.RegFunction("SphereCast", new LuaCSFunction(UnityEngine_PhysicsWrap.SphereCast));
		L.RegFunction("CapsuleCastAll", new LuaCSFunction(UnityEngine_PhysicsWrap.CapsuleCastAll));
		L.RegFunction("CapsuleCastNonAlloc", new LuaCSFunction(UnityEngine_PhysicsWrap.CapsuleCastNonAlloc));
		L.RegFunction("SphereCastAll", new LuaCSFunction(UnityEngine_PhysicsWrap.SphereCastAll));
		L.RegFunction("SphereCastNonAlloc", new LuaCSFunction(UnityEngine_PhysicsWrap.SphereCastNonAlloc));
		L.RegFunction("CheckSphere", new LuaCSFunction(UnityEngine_PhysicsWrap.CheckSphere));
		L.RegFunction("CheckCapsule", new LuaCSFunction(UnityEngine_PhysicsWrap.CheckCapsule));
		L.RegFunction("CheckBox", new LuaCSFunction(UnityEngine_PhysicsWrap.CheckBox));
		L.RegFunction("OverlapBox", new LuaCSFunction(UnityEngine_PhysicsWrap.OverlapBox));
		L.RegFunction("OverlapBoxNonAlloc", new LuaCSFunction(UnityEngine_PhysicsWrap.OverlapBoxNonAlloc));
		L.RegFunction("BoxCastAll", new LuaCSFunction(UnityEngine_PhysicsWrap.BoxCastAll));
		L.RegFunction("BoxCastNonAlloc", new LuaCSFunction(UnityEngine_PhysicsWrap.BoxCastNonAlloc));
		L.RegFunction("BoxCast", new LuaCSFunction(UnityEngine_PhysicsWrap.BoxCast));
		L.RegFunction("IgnoreCollision", new LuaCSFunction(UnityEngine_PhysicsWrap.IgnoreCollision));
		L.RegFunction("IgnoreLayerCollision", new LuaCSFunction(UnityEngine_PhysicsWrap.IgnoreLayerCollision));
		L.RegFunction("GetIgnoreLayerCollision", new LuaCSFunction(UnityEngine_PhysicsWrap.GetIgnoreLayerCollision));
		L.RegConstant("IgnoreRaycastLayer", 4.0);
		L.RegConstant("DefaultRaycastLayers", -5.0);
		L.RegConstant("AllLayers", -1.0);
		L.RegVar("gravity", new LuaCSFunction(UnityEngine_PhysicsWrap.get_gravity), new LuaCSFunction(UnityEngine_PhysicsWrap.set_gravity));
		L.RegVar("defaultContactOffset", new LuaCSFunction(UnityEngine_PhysicsWrap.get_defaultContactOffset), new LuaCSFunction(UnityEngine_PhysicsWrap.set_defaultContactOffset));
		L.RegVar("bounceThreshold", new LuaCSFunction(UnityEngine_PhysicsWrap.get_bounceThreshold), new LuaCSFunction(UnityEngine_PhysicsWrap.set_bounceThreshold));
		L.RegVar("solverIterationCount", new LuaCSFunction(UnityEngine_PhysicsWrap.get_solverIterationCount), new LuaCSFunction(UnityEngine_PhysicsWrap.set_solverIterationCount));
		L.RegVar("sleepThreshold", new LuaCSFunction(UnityEngine_PhysicsWrap.get_sleepThreshold), new LuaCSFunction(UnityEngine_PhysicsWrap.set_sleepThreshold));
		L.RegVar("queriesHitTriggers", new LuaCSFunction(UnityEngine_PhysicsWrap.get_queriesHitTriggers), new LuaCSFunction(UnityEngine_PhysicsWrap.set_queriesHitTriggers));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Raycast(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Ray)))
			{
				Ray ray = ToLua.ToRay(L, 1);
				bool value = Physics.Raycast(ray);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(LuaOut<RaycastHit>)))
			{
				Ray ray2 = ToLua.ToRay(L, 1);
				RaycastHit hit;
				bool value2 = Physics.Raycast(ray2, out hit);
				LuaDLL.lua_pushboolean(L, value2);
				ToLua.Push(L, hit);
				result = 2;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3)))
			{
				Vector3 origin = ToLua.ToVector3(L, 1);
				Vector3 direction = ToLua.ToVector3(L, 2);
				bool value3 = Physics.Raycast(origin, direction);
				LuaDLL.lua_pushboolean(L, value3);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float)))
			{
				Ray ray3 = ToLua.ToRay(L, 1);
				float maxDistance = (float)LuaDLL.lua_tonumber(L, 2);
				bool value4 = Physics.Raycast(ray3, maxDistance);
				LuaDLL.lua_pushboolean(L, value4);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(int)))
			{
				Ray ray4 = ToLua.ToRay(L, 1);
				float maxDistance2 = (float)LuaDLL.lua_tonumber(L, 2);
				int layerMask = (int)LuaDLL.lua_tonumber(L, 3);
				bool value5 = Physics.Raycast(ray4, maxDistance2, layerMask);
				LuaDLL.lua_pushboolean(L, value5);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(LuaOut<RaycastHit>)))
			{
				Vector3 origin2 = ToLua.ToVector3(L, 1);
				Vector3 direction2 = ToLua.ToVector3(L, 2);
				RaycastHit hit2;
				bool value6 = Physics.Raycast(origin2, direction2, out hit2);
				LuaDLL.lua_pushboolean(L, value6);
				ToLua.Push(L, hit2);
				result = 2;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float)))
			{
				Vector3 origin3 = ToLua.ToVector3(L, 1);
				Vector3 direction3 = ToLua.ToVector3(L, 2);
				float maxDistance3 = (float)LuaDLL.lua_tonumber(L, 3);
				bool value7 = Physics.Raycast(origin3, direction3, maxDistance3);
				LuaDLL.lua_pushboolean(L, value7);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(LuaOut<RaycastHit>), typeof(float)))
			{
				Ray ray5 = ToLua.ToRay(L, 1);
				float maxDistance4 = (float)LuaDLL.lua_tonumber(L, 3);
				RaycastHit hit3;
				bool value8 = Physics.Raycast(ray5, out hit3, maxDistance4);
				LuaDLL.lua_pushboolean(L, value8);
				ToLua.Push(L, hit3);
				result = 2;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Ray ray6 = ToLua.ToRay(L, 1);
				float maxDistance5 = (float)LuaDLL.lua_tonumber(L, 2);
				int layerMask2 = (int)LuaDLL.lua_tonumber(L, 3);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 4));
				bool value9 = Physics.Raycast(ray6, maxDistance5, layerMask2, queryTriggerInteraction);
				LuaDLL.lua_pushboolean(L, value9);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(int)))
			{
				Vector3 origin4 = ToLua.ToVector3(L, 1);
				Vector3 direction4 = ToLua.ToVector3(L, 2);
				float maxDistance6 = (float)LuaDLL.lua_tonumber(L, 3);
				int layerMask3 = (int)LuaDLL.lua_tonumber(L, 4);
				bool value10 = Physics.Raycast(origin4, direction4, maxDistance6, layerMask3);
				LuaDLL.lua_pushboolean(L, value10);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(float)))
			{
				Vector3 origin5 = ToLua.ToVector3(L, 1);
				Vector3 direction5 = ToLua.ToVector3(L, 2);
				float maxDistance7 = (float)LuaDLL.lua_tonumber(L, 4);
				RaycastHit hit4;
				bool value11 = Physics.Raycast(origin5, direction5, out hit4, maxDistance7);
				LuaDLL.lua_pushboolean(L, value11);
				ToLua.Push(L, hit4);
				result = 2;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(LuaOut<RaycastHit>), typeof(float), typeof(int)))
			{
				Ray ray7 = ToLua.ToRay(L, 1);
				float maxDistance8 = (float)LuaDLL.lua_tonumber(L, 3);
				int layerMask4 = (int)LuaDLL.lua_tonumber(L, 4);
				RaycastHit hit5;
				bool value12 = Physics.Raycast(ray7, out hit5, maxDistance8, layerMask4);
				LuaDLL.lua_pushboolean(L, value12);
				ToLua.Push(L, hit5);
				result = 2;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 origin6 = ToLua.ToVector3(L, 1);
				Vector3 direction6 = ToLua.ToVector3(L, 2);
				float maxDistance9 = (float)LuaDLL.lua_tonumber(L, 3);
				int layerMask5 = (int)LuaDLL.lua_tonumber(L, 4);
				QueryTriggerInteraction queryTriggerInteraction2 = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 5));
				bool value13 = Physics.Raycast(origin6, direction6, maxDistance9, layerMask5, queryTriggerInteraction2);
				LuaDLL.lua_pushboolean(L, value13);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(float), typeof(int)))
			{
				Vector3 origin7 = ToLua.ToVector3(L, 1);
				Vector3 direction7 = ToLua.ToVector3(L, 2);
				float maxDistance10 = (float)LuaDLL.lua_tonumber(L, 4);
				int layerMask6 = (int)LuaDLL.lua_tonumber(L, 5);
				RaycastHit hit6;
				bool value14 = Physics.Raycast(origin7, direction7, out hit6, maxDistance10, layerMask6);
				LuaDLL.lua_pushboolean(L, value14);
				ToLua.Push(L, hit6);
				result = 2;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(LuaOut<RaycastHit>), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Ray ray8 = ToLua.ToRay(L, 1);
				float maxDistance11 = (float)LuaDLL.lua_tonumber(L, 3);
				int layerMask7 = (int)LuaDLL.lua_tonumber(L, 4);
				QueryTriggerInteraction queryTriggerInteraction3 = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 5));
				RaycastHit hit7;
				bool value15 = Physics.Raycast(ray8, out hit7, maxDistance11, layerMask7, queryTriggerInteraction3);
				LuaDLL.lua_pushboolean(L, value15);
				ToLua.Push(L, hit7);
				result = 2;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 origin8 = ToLua.ToVector3(L, 1);
				Vector3 direction8 = ToLua.ToVector3(L, 2);
				float maxDistance12 = (float)LuaDLL.lua_tonumber(L, 4);
				int layerMask8 = (int)LuaDLL.lua_tonumber(L, 5);
				QueryTriggerInteraction queryTriggerInteraction4 = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 6));
				RaycastHit hit8;
				bool value16 = Physics.Raycast(origin8, direction8, out hit8, maxDistance12, layerMask8, queryTriggerInteraction4);
				LuaDLL.lua_pushboolean(L, value16);
				ToLua.Push(L, hit8);
				result = 2;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.Raycast");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RaycastAll(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Ray)))
			{
				Ray ray = ToLua.ToRay(L, 1);
				RaycastHit[] array = Physics.RaycastAll(ray);
				ToLua.Push(L, array);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3)))
			{
				Vector3 origin = ToLua.ToVector3(L, 1);
				Vector3 direction = ToLua.ToVector3(L, 2);
				RaycastHit[] array2 = Physics.RaycastAll(origin, direction);
				ToLua.Push(L, array2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float)))
			{
				Ray ray2 = ToLua.ToRay(L, 1);
				float maxDistance = (float)LuaDLL.lua_tonumber(L, 2);
				RaycastHit[] array3 = Physics.RaycastAll(ray2, maxDistance);
				ToLua.Push(L, array3);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float)))
			{
				Vector3 origin2 = ToLua.ToVector3(L, 1);
				Vector3 direction2 = ToLua.ToVector3(L, 2);
				float maxDistance2 = (float)LuaDLL.lua_tonumber(L, 3);
				RaycastHit[] array4 = Physics.RaycastAll(origin2, direction2, maxDistance2);
				ToLua.Push(L, array4);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(int)))
			{
				Ray ray3 = ToLua.ToRay(L, 1);
				float maxDistance3 = (float)LuaDLL.lua_tonumber(L, 2);
				int layerMask = (int)LuaDLL.lua_tonumber(L, 3);
				RaycastHit[] array5 = Physics.RaycastAll(ray3, maxDistance3, layerMask);
				ToLua.Push(L, array5);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(int)))
			{
				Vector3 origin3 = ToLua.ToVector3(L, 1);
				Vector3 direction3 = ToLua.ToVector3(L, 2);
				float maxDistance4 = (float)LuaDLL.lua_tonumber(L, 3);
				int layermask = (int)LuaDLL.lua_tonumber(L, 4);
				RaycastHit[] array6 = Physics.RaycastAll(origin3, direction3, maxDistance4, layermask);
				ToLua.Push(L, array6);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Ray ray4 = ToLua.ToRay(L, 1);
				float maxDistance5 = (float)LuaDLL.lua_tonumber(L, 2);
				int layerMask2 = (int)LuaDLL.lua_tonumber(L, 3);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 4));
				RaycastHit[] array7 = Physics.RaycastAll(ray4, maxDistance5, layerMask2, queryTriggerInteraction);
				ToLua.Push(L, array7);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 origin4 = ToLua.ToVector3(L, 1);
				Vector3 direction4 = ToLua.ToVector3(L, 2);
				float maxDistance6 = (float)LuaDLL.lua_tonumber(L, 3);
				int layermask2 = (int)LuaDLL.lua_tonumber(L, 4);
				QueryTriggerInteraction queryTriggerInteraction2 = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 5));
				RaycastHit[] array8 = Physics.RaycastAll(origin4, direction4, maxDistance6, layermask2, queryTriggerInteraction2);
				ToLua.Push(L, array8);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.RaycastAll");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RaycastNonAlloc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(RaycastHit[])))
			{
				Ray ray = ToLua.ToRay(L, 1);
				RaycastHit[] results = ToLua.CheckObjectArray<RaycastHit>(L, 2);
				int n = Physics.RaycastNonAlloc(ray, results);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(RaycastHit[])))
			{
				Vector3 origin = ToLua.ToVector3(L, 1);
				Vector3 direction = ToLua.ToVector3(L, 2);
				RaycastHit[] results2 = ToLua.CheckObjectArray<RaycastHit>(L, 3);
				int n2 = Physics.RaycastNonAlloc(origin, direction, results2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(RaycastHit[]), typeof(float)))
			{
				Ray ray2 = ToLua.ToRay(L, 1);
				RaycastHit[] results3 = ToLua.CheckObjectArray<RaycastHit>(L, 2);
				float maxDistance = (float)LuaDLL.lua_tonumber(L, 3);
				int n3 = Physics.RaycastNonAlloc(ray2, results3, maxDistance);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(RaycastHit[]), typeof(float)))
			{
				Vector3 origin2 = ToLua.ToVector3(L, 1);
				Vector3 direction2 = ToLua.ToVector3(L, 2);
				RaycastHit[] results4 = ToLua.CheckObjectArray<RaycastHit>(L, 3);
				float maxDistance2 = (float)LuaDLL.lua_tonumber(L, 4);
				int n4 = Physics.RaycastNonAlloc(origin2, direction2, results4, maxDistance2);
				LuaDLL.lua_pushinteger(L, n4);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(RaycastHit[]), typeof(float), typeof(int)))
			{
				Ray ray3 = ToLua.ToRay(L, 1);
				RaycastHit[] results5 = ToLua.CheckObjectArray<RaycastHit>(L, 2);
				float maxDistance3 = (float)LuaDLL.lua_tonumber(L, 3);
				int layerMask = (int)LuaDLL.lua_tonumber(L, 4);
				int n5 = Physics.RaycastNonAlloc(ray3, results5, maxDistance3, layerMask);
				LuaDLL.lua_pushinteger(L, n5);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(RaycastHit[]), typeof(float), typeof(int)))
			{
				Vector3 origin3 = ToLua.ToVector3(L, 1);
				Vector3 direction3 = ToLua.ToVector3(L, 2);
				RaycastHit[] results6 = ToLua.CheckObjectArray<RaycastHit>(L, 3);
				float maxDistance4 = (float)LuaDLL.lua_tonumber(L, 4);
				int layermask = (int)LuaDLL.lua_tonumber(L, 5);
				int n6 = Physics.RaycastNonAlloc(origin3, direction3, results6, maxDistance4, layermask);
				LuaDLL.lua_pushinteger(L, n6);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(RaycastHit[]), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Ray ray4 = ToLua.ToRay(L, 1);
				RaycastHit[] results7 = ToLua.CheckObjectArray<RaycastHit>(L, 2);
				float maxDistance5 = (float)LuaDLL.lua_tonumber(L, 3);
				int layerMask2 = (int)LuaDLL.lua_tonumber(L, 4);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 5));
				int n7 = Physics.RaycastNonAlloc(ray4, results7, maxDistance5, layerMask2, queryTriggerInteraction);
				LuaDLL.lua_pushinteger(L, n7);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(RaycastHit[]), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 origin4 = ToLua.ToVector3(L, 1);
				Vector3 direction4 = ToLua.ToVector3(L, 2);
				RaycastHit[] results8 = ToLua.CheckObjectArray<RaycastHit>(L, 3);
				float maxDistance6 = (float)LuaDLL.lua_tonumber(L, 4);
				int layermask2 = (int)LuaDLL.lua_tonumber(L, 5);
				QueryTriggerInteraction queryTriggerInteraction2 = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 6));
				int n8 = Physics.RaycastNonAlloc(origin4, direction4, results8, maxDistance6, layermask2, queryTriggerInteraction2);
				LuaDLL.lua_pushinteger(L, n8);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.RaycastNonAlloc");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Linecast(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3)))
			{
				Vector3 start = ToLua.ToVector3(L, 1);
				Vector3 end = ToLua.ToVector3(L, 2);
				bool value = Physics.Linecast(start, end);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(LuaOut<RaycastHit>)))
			{
				Vector3 start2 = ToLua.ToVector3(L, 1);
				Vector3 end2 = ToLua.ToVector3(L, 2);
				RaycastHit hit;
				bool value2 = Physics.Linecast(start2, end2, out hit);
				LuaDLL.lua_pushboolean(L, value2);
				ToLua.Push(L, hit);
				result = 2;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(int)))
			{
				Vector3 start3 = ToLua.ToVector3(L, 1);
				Vector3 end3 = ToLua.ToVector3(L, 2);
				int layerMask = (int)LuaDLL.lua_tonumber(L, 3);
				bool value3 = Physics.Linecast(start3, end3, layerMask);
				LuaDLL.lua_pushboolean(L, value3);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(int)))
			{
				Vector3 start4 = ToLua.ToVector3(L, 1);
				Vector3 end4 = ToLua.ToVector3(L, 2);
				int layerMask2 = (int)LuaDLL.lua_tonumber(L, 4);
				RaycastHit hit2;
				bool value4 = Physics.Linecast(start4, end4, out hit2, layerMask2);
				LuaDLL.lua_pushboolean(L, value4);
				ToLua.Push(L, hit2);
				result = 2;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 start5 = ToLua.ToVector3(L, 1);
				Vector3 end5 = ToLua.ToVector3(L, 2);
				int layerMask3 = (int)LuaDLL.lua_tonumber(L, 3);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 4));
				bool value5 = Physics.Linecast(start5, end5, layerMask3, queryTriggerInteraction);
				LuaDLL.lua_pushboolean(L, value5);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 start6 = ToLua.ToVector3(L, 1);
				Vector3 end6 = ToLua.ToVector3(L, 2);
				int layerMask4 = (int)LuaDLL.lua_tonumber(L, 4);
				QueryTriggerInteraction queryTriggerInteraction2 = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 5));
				RaycastHit hit3;
				bool value6 = Physics.Linecast(start6, end6, out hit3, layerMask4, queryTriggerInteraction2);
				LuaDLL.lua_pushboolean(L, value6);
				ToLua.Push(L, hit3);
				result = 2;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.Linecast");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OverlapSphere(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float)))
			{
				Vector3 position = ToLua.ToVector3(L, 1);
				float radius = (float)LuaDLL.lua_tonumber(L, 2);
				Collider[] array = Physics.OverlapSphere(position, radius);
				ToLua.Push(L, array);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(int)))
			{
				Vector3 position2 = ToLua.ToVector3(L, 1);
				float radius2 = (float)LuaDLL.lua_tonumber(L, 2);
				int layerMask = (int)LuaDLL.lua_tonumber(L, 3);
				Collider[] array2 = Physics.OverlapSphere(position2, radius2, layerMask);
				ToLua.Push(L, array2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 position3 = ToLua.ToVector3(L, 1);
				float radius3 = (float)LuaDLL.lua_tonumber(L, 2);
				int layerMask2 = (int)LuaDLL.lua_tonumber(L, 3);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 4));
				Collider[] array3 = Physics.OverlapSphere(position3, radius3, layerMask2, queryTriggerInteraction);
				ToLua.Push(L, array3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.OverlapSphere");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OverlapSphereNonAlloc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(Collider[])))
			{
				Vector3 position = ToLua.ToVector3(L, 1);
				float radius = (float)LuaDLL.lua_tonumber(L, 2);
				Collider[] results = ToLua.CheckObjectArray<Collider>(L, 3);
				int n = Physics.OverlapSphereNonAlloc(position, radius, results);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(Collider[]), typeof(int)))
			{
				Vector3 position2 = ToLua.ToVector3(L, 1);
				float radius2 = (float)LuaDLL.lua_tonumber(L, 2);
				Collider[] results2 = ToLua.CheckObjectArray<Collider>(L, 3);
				int layerMask = (int)LuaDLL.lua_tonumber(L, 4);
				int n2 = Physics.OverlapSphereNonAlloc(position2, radius2, results2, layerMask);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(Collider[]), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 position3 = ToLua.ToVector3(L, 1);
				float radius3 = (float)LuaDLL.lua_tonumber(L, 2);
				Collider[] results3 = ToLua.CheckObjectArray<Collider>(L, 3);
				int layerMask2 = (int)LuaDLL.lua_tonumber(L, 4);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 5));
				int n3 = Physics.OverlapSphereNonAlloc(position3, radius3, results3, layerMask2, queryTriggerInteraction);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.OverlapSphereNonAlloc");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CapsuleCast(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3)))
			{
				Vector3 point = ToLua.ToVector3(L, 1);
				Vector3 point2 = ToLua.ToVector3(L, 2);
				float radius = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction = ToLua.ToVector3(L, 4);
				bool value = Physics.CapsuleCast(point, point2, radius, direction);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(LuaOut<RaycastHit>)))
			{
				Vector3 point3 = ToLua.ToVector3(L, 1);
				Vector3 point4 = ToLua.ToVector3(L, 2);
				float radius2 = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction2 = ToLua.ToVector3(L, 4);
				RaycastHit hit;
				bool value2 = Physics.CapsuleCast(point3, point4, radius2, direction2, out hit);
				LuaDLL.lua_pushboolean(L, value2);
				ToLua.Push(L, hit);
				result = 2;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(float)))
			{
				Vector3 point5 = ToLua.ToVector3(L, 1);
				Vector3 point6 = ToLua.ToVector3(L, 2);
				float radius3 = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction3 = ToLua.ToVector3(L, 4);
				float maxDistance = (float)LuaDLL.lua_tonumber(L, 5);
				bool value3 = Physics.CapsuleCast(point5, point6, radius3, direction3, maxDistance);
				LuaDLL.lua_pushboolean(L, value3);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(float)))
			{
				Vector3 point7 = ToLua.ToVector3(L, 1);
				Vector3 point8 = ToLua.ToVector3(L, 2);
				float radius4 = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction4 = ToLua.ToVector3(L, 4);
				float maxDistance2 = (float)LuaDLL.lua_tonumber(L, 6);
				RaycastHit hit2;
				bool value4 = Physics.CapsuleCast(point7, point8, radius4, direction4, out hit2, maxDistance2);
				LuaDLL.lua_pushboolean(L, value4);
				ToLua.Push(L, hit2);
				result = 2;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(float), typeof(int)))
			{
				Vector3 point9 = ToLua.ToVector3(L, 1);
				Vector3 point10 = ToLua.ToVector3(L, 2);
				float radius5 = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction5 = ToLua.ToVector3(L, 4);
				float maxDistance3 = (float)LuaDLL.lua_tonumber(L, 5);
				int layerMask = (int)LuaDLL.lua_tonumber(L, 6);
				bool value5 = Physics.CapsuleCast(point9, point10, radius5, direction5, maxDistance3, layerMask);
				LuaDLL.lua_pushboolean(L, value5);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 point11 = ToLua.ToVector3(L, 1);
				Vector3 point12 = ToLua.ToVector3(L, 2);
				float radius6 = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction6 = ToLua.ToVector3(L, 4);
				float maxDistance4 = (float)LuaDLL.lua_tonumber(L, 5);
				int layerMask2 = (int)LuaDLL.lua_tonumber(L, 6);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 7));
				bool value6 = Physics.CapsuleCast(point11, point12, radius6, direction6, maxDistance4, layerMask2, queryTriggerInteraction);
				LuaDLL.lua_pushboolean(L, value6);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(float), typeof(int)))
			{
				Vector3 point13 = ToLua.ToVector3(L, 1);
				Vector3 point14 = ToLua.ToVector3(L, 2);
				float radius7 = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction7 = ToLua.ToVector3(L, 4);
				float maxDistance5 = (float)LuaDLL.lua_tonumber(L, 6);
				int layerMask3 = (int)LuaDLL.lua_tonumber(L, 7);
				RaycastHit hit3;
				bool value7 = Physics.CapsuleCast(point13, point14, radius7, direction7, out hit3, maxDistance5, layerMask3);
				LuaDLL.lua_pushboolean(L, value7);
				ToLua.Push(L, hit3);
				result = 2;
			}
			else if (num == 8 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 point15 = ToLua.ToVector3(L, 1);
				Vector3 point16 = ToLua.ToVector3(L, 2);
				float radius8 = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction8 = ToLua.ToVector3(L, 4);
				float maxDistance6 = (float)LuaDLL.lua_tonumber(L, 6);
				int layerMask4 = (int)LuaDLL.lua_tonumber(L, 7);
				QueryTriggerInteraction queryTriggerInteraction2 = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 8));
				RaycastHit hit4;
				bool value8 = Physics.CapsuleCast(point15, point16, radius8, direction8, out hit4, maxDistance6, layerMask4, queryTriggerInteraction2);
				LuaDLL.lua_pushboolean(L, value8);
				ToLua.Push(L, hit4);
				result = 2;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.CapsuleCast");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SphereCast(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float)))
			{
				Ray ray = ToLua.ToRay(L, 1);
				float radius = (float)LuaDLL.lua_tonumber(L, 2);
				bool value = Physics.SphereCast(ray, radius);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(float)))
			{
				Ray ray2 = ToLua.ToRay(L, 1);
				float radius2 = (float)LuaDLL.lua_tonumber(L, 2);
				float maxDistance = (float)LuaDLL.lua_tonumber(L, 3);
				bool value2 = Physics.SphereCast(ray2, radius2, maxDistance);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(LuaOut<RaycastHit>)))
			{
				Ray ray3 = ToLua.ToRay(L, 1);
				float radius3 = (float)LuaDLL.lua_tonumber(L, 2);
				RaycastHit hit;
				bool value3 = Physics.SphereCast(ray3, radius3, out hit);
				LuaDLL.lua_pushboolean(L, value3);
				ToLua.Push(L, hit);
				result = 2;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(Vector3), typeof(LuaOut<RaycastHit>)))
			{
				Vector3 origin = ToLua.ToVector3(L, 1);
				float radius4 = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 direction = ToLua.ToVector3(L, 3);
				RaycastHit hit2;
				bool value4 = Physics.SphereCast(origin, radius4, direction, out hit2);
				LuaDLL.lua_pushboolean(L, value4);
				ToLua.Push(L, hit2);
				result = 2;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(float), typeof(int)))
			{
				Ray ray4 = ToLua.ToRay(L, 1);
				float radius5 = (float)LuaDLL.lua_tonumber(L, 2);
				float maxDistance2 = (float)LuaDLL.lua_tonumber(L, 3);
				int layerMask = (int)LuaDLL.lua_tonumber(L, 4);
				bool value5 = Physics.SphereCast(ray4, radius5, maxDistance2, layerMask);
				LuaDLL.lua_pushboolean(L, value5);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(LuaOut<RaycastHit>), typeof(float)))
			{
				Ray ray5 = ToLua.ToRay(L, 1);
				float radius6 = (float)LuaDLL.lua_tonumber(L, 2);
				float maxDistance3 = (float)LuaDLL.lua_tonumber(L, 4);
				RaycastHit hit3;
				bool value6 = Physics.SphereCast(ray5, radius6, out hit3, maxDistance3);
				LuaDLL.lua_pushboolean(L, value6);
				ToLua.Push(L, hit3);
				result = 2;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(LuaOut<RaycastHit>), typeof(float), typeof(int)))
			{
				Ray ray6 = ToLua.ToRay(L, 1);
				float radius7 = (float)LuaDLL.lua_tonumber(L, 2);
				float maxDistance4 = (float)LuaDLL.lua_tonumber(L, 4);
				int layerMask2 = (int)LuaDLL.lua_tonumber(L, 5);
				RaycastHit hit4;
				bool value7 = Physics.SphereCast(ray6, radius7, out hit4, maxDistance4, layerMask2);
				LuaDLL.lua_pushboolean(L, value7);
				ToLua.Push(L, hit4);
				result = 2;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Ray ray7 = ToLua.ToRay(L, 1);
				float radius8 = (float)LuaDLL.lua_tonumber(L, 2);
				float maxDistance5 = (float)LuaDLL.lua_tonumber(L, 3);
				int layerMask3 = (int)LuaDLL.lua_tonumber(L, 4);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 5));
				bool value8 = Physics.SphereCast(ray7, radius8, maxDistance5, layerMask3, queryTriggerInteraction);
				LuaDLL.lua_pushboolean(L, value8);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(float)))
			{
				Vector3 origin2 = ToLua.ToVector3(L, 1);
				float radius9 = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 direction2 = ToLua.ToVector3(L, 3);
				float maxDistance6 = (float)LuaDLL.lua_tonumber(L, 5);
				RaycastHit hit5;
				bool value9 = Physics.SphereCast(origin2, radius9, direction2, out hit5, maxDistance6);
				LuaDLL.lua_pushboolean(L, value9);
				ToLua.Push(L, hit5);
				result = 2;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(float), typeof(int)))
			{
				Vector3 origin3 = ToLua.ToVector3(L, 1);
				float radius10 = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 direction3 = ToLua.ToVector3(L, 3);
				float maxDistance7 = (float)LuaDLL.lua_tonumber(L, 5);
				int layerMask4 = (int)LuaDLL.lua_tonumber(L, 6);
				RaycastHit hit6;
				bool value10 = Physics.SphereCast(origin3, radius10, direction3, out hit6, maxDistance7, layerMask4);
				LuaDLL.lua_pushboolean(L, value10);
				ToLua.Push(L, hit6);
				result = 2;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(LuaOut<RaycastHit>), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Ray ray8 = ToLua.ToRay(L, 1);
				float radius11 = (float)LuaDLL.lua_tonumber(L, 2);
				float maxDistance8 = (float)LuaDLL.lua_tonumber(L, 4);
				int layerMask5 = (int)LuaDLL.lua_tonumber(L, 5);
				QueryTriggerInteraction queryTriggerInteraction2 = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 6));
				RaycastHit hit7;
				bool value11 = Physics.SphereCast(ray8, radius11, out hit7, maxDistance8, layerMask5, queryTriggerInteraction2);
				LuaDLL.lua_pushboolean(L, value11);
				ToLua.Push(L, hit7);
				result = 2;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 origin4 = ToLua.ToVector3(L, 1);
				float radius12 = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 direction4 = ToLua.ToVector3(L, 3);
				float maxDistance9 = (float)LuaDLL.lua_tonumber(L, 5);
				int layerMask6 = (int)LuaDLL.lua_tonumber(L, 6);
				QueryTriggerInteraction queryTriggerInteraction3 = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 7));
				RaycastHit hit8;
				bool value12 = Physics.SphereCast(origin4, radius12, direction4, out hit8, maxDistance9, layerMask6, queryTriggerInteraction3);
				LuaDLL.lua_pushboolean(L, value12);
				ToLua.Push(L, hit8);
				result = 2;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.SphereCast");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CapsuleCastAll(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3)))
			{
				Vector3 point = ToLua.ToVector3(L, 1);
				Vector3 point2 = ToLua.ToVector3(L, 2);
				float radius = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction = ToLua.ToVector3(L, 4);
				RaycastHit[] array = Physics.CapsuleCastAll(point, point2, radius, direction);
				ToLua.Push(L, array);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(float)))
			{
				Vector3 point3 = ToLua.ToVector3(L, 1);
				Vector3 point4 = ToLua.ToVector3(L, 2);
				float radius2 = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction2 = ToLua.ToVector3(L, 4);
				float maxDistance = (float)LuaDLL.lua_tonumber(L, 5);
				RaycastHit[] array2 = Physics.CapsuleCastAll(point3, point4, radius2, direction2, maxDistance);
				ToLua.Push(L, array2);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(float), typeof(int)))
			{
				Vector3 point5 = ToLua.ToVector3(L, 1);
				Vector3 point6 = ToLua.ToVector3(L, 2);
				float radius3 = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction3 = ToLua.ToVector3(L, 4);
				float maxDistance2 = (float)LuaDLL.lua_tonumber(L, 5);
				int layermask = (int)LuaDLL.lua_tonumber(L, 6);
				RaycastHit[] array3 = Physics.CapsuleCastAll(point5, point6, radius3, direction3, maxDistance2, layermask);
				ToLua.Push(L, array3);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 point7 = ToLua.ToVector3(L, 1);
				Vector3 point8 = ToLua.ToVector3(L, 2);
				float radius4 = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction4 = ToLua.ToVector3(L, 4);
				float maxDistance3 = (float)LuaDLL.lua_tonumber(L, 5);
				int layermask2 = (int)LuaDLL.lua_tonumber(L, 6);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 7));
				RaycastHit[] array4 = Physics.CapsuleCastAll(point7, point8, radius4, direction4, maxDistance3, layermask2, queryTriggerInteraction);
				ToLua.Push(L, array4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.CapsuleCastAll");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CapsuleCastNonAlloc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(RaycastHit[])))
			{
				Vector3 point = ToLua.ToVector3(L, 1);
				Vector3 point2 = ToLua.ToVector3(L, 2);
				float radius = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction = ToLua.ToVector3(L, 4);
				RaycastHit[] results = ToLua.CheckObjectArray<RaycastHit>(L, 5);
				int n = Physics.CapsuleCastNonAlloc(point, point2, radius, direction, results);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(RaycastHit[]), typeof(float)))
			{
				Vector3 point3 = ToLua.ToVector3(L, 1);
				Vector3 point4 = ToLua.ToVector3(L, 2);
				float radius2 = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction2 = ToLua.ToVector3(L, 4);
				RaycastHit[] results2 = ToLua.CheckObjectArray<RaycastHit>(L, 5);
				float maxDistance = (float)LuaDLL.lua_tonumber(L, 6);
				int n2 = Physics.CapsuleCastNonAlloc(point3, point4, radius2, direction2, results2, maxDistance);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(RaycastHit[]), typeof(float), typeof(int)))
			{
				Vector3 point5 = ToLua.ToVector3(L, 1);
				Vector3 point6 = ToLua.ToVector3(L, 2);
				float radius3 = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction3 = ToLua.ToVector3(L, 4);
				RaycastHit[] results3 = ToLua.CheckObjectArray<RaycastHit>(L, 5);
				float maxDistance2 = (float)LuaDLL.lua_tonumber(L, 6);
				int layermask = (int)LuaDLL.lua_tonumber(L, 7);
				int n3 = Physics.CapsuleCastNonAlloc(point5, point6, radius3, direction3, results3, maxDistance2, layermask);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else if (num == 8 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(RaycastHit[]), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 point7 = ToLua.ToVector3(L, 1);
				Vector3 point8 = ToLua.ToVector3(L, 2);
				float radius4 = (float)LuaDLL.lua_tonumber(L, 3);
				Vector3 direction4 = ToLua.ToVector3(L, 4);
				RaycastHit[] results4 = ToLua.CheckObjectArray<RaycastHit>(L, 5);
				float maxDistance3 = (float)LuaDLL.lua_tonumber(L, 6);
				int layermask2 = (int)LuaDLL.lua_tonumber(L, 7);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 8));
				int n4 = Physics.CapsuleCastNonAlloc(point7, point8, radius4, direction4, results4, maxDistance3, layermask2, queryTriggerInteraction);
				LuaDLL.lua_pushinteger(L, n4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.CapsuleCastNonAlloc");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SphereCastAll(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float)))
			{
				Ray ray = ToLua.ToRay(L, 1);
				float radius = (float)LuaDLL.lua_tonumber(L, 2);
				RaycastHit[] array = Physics.SphereCastAll(ray, radius);
				ToLua.Push(L, array);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(float)))
			{
				Ray ray2 = ToLua.ToRay(L, 1);
				float radius2 = (float)LuaDLL.lua_tonumber(L, 2);
				float maxDistance = (float)LuaDLL.lua_tonumber(L, 3);
				RaycastHit[] array2 = Physics.SphereCastAll(ray2, radius2, maxDistance);
				ToLua.Push(L, array2);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(Vector3)))
			{
				Vector3 origin = ToLua.ToVector3(L, 1);
				float radius3 = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 direction = ToLua.ToVector3(L, 3);
				RaycastHit[] array3 = Physics.SphereCastAll(origin, radius3, direction);
				ToLua.Push(L, array3);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(float), typeof(int)))
			{
				Ray ray3 = ToLua.ToRay(L, 1);
				float radius4 = (float)LuaDLL.lua_tonumber(L, 2);
				float maxDistance2 = (float)LuaDLL.lua_tonumber(L, 3);
				int layerMask = (int)LuaDLL.lua_tonumber(L, 4);
				RaycastHit[] array4 = Physics.SphereCastAll(ray3, radius4, maxDistance2, layerMask);
				ToLua.Push(L, array4);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(Vector3), typeof(float)))
			{
				Vector3 origin2 = ToLua.ToVector3(L, 1);
				float radius5 = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 direction2 = ToLua.ToVector3(L, 3);
				float maxDistance3 = (float)LuaDLL.lua_tonumber(L, 4);
				RaycastHit[] array5 = Physics.SphereCastAll(origin2, radius5, direction2, maxDistance3);
				ToLua.Push(L, array5);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(Vector3), typeof(float), typeof(int)))
			{
				Vector3 origin3 = ToLua.ToVector3(L, 1);
				float radius6 = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 direction3 = ToLua.ToVector3(L, 3);
				float maxDistance4 = (float)LuaDLL.lua_tonumber(L, 4);
				int layerMask2 = (int)LuaDLL.lua_tonumber(L, 5);
				RaycastHit[] array6 = Physics.SphereCastAll(origin3, radius6, direction3, maxDistance4, layerMask2);
				ToLua.Push(L, array6);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Ray ray4 = ToLua.ToRay(L, 1);
				float radius7 = (float)LuaDLL.lua_tonumber(L, 2);
				float maxDistance5 = (float)LuaDLL.lua_tonumber(L, 3);
				int layerMask3 = (int)LuaDLL.lua_tonumber(L, 4);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 5));
				RaycastHit[] array7 = Physics.SphereCastAll(ray4, radius7, maxDistance5, layerMask3, queryTriggerInteraction);
				ToLua.Push(L, array7);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(Vector3), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 origin4 = ToLua.ToVector3(L, 1);
				float radius8 = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 direction4 = ToLua.ToVector3(L, 3);
				float maxDistance6 = (float)LuaDLL.lua_tonumber(L, 4);
				int layerMask4 = (int)LuaDLL.lua_tonumber(L, 5);
				QueryTriggerInteraction queryTriggerInteraction2 = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 6));
				RaycastHit[] array8 = Physics.SphereCastAll(origin4, radius8, direction4, maxDistance6, layerMask4, queryTriggerInteraction2);
				ToLua.Push(L, array8);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.SphereCastAll");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SphereCastNonAlloc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(RaycastHit[])))
			{
				Ray ray = ToLua.ToRay(L, 1);
				float radius = (float)LuaDLL.lua_tonumber(L, 2);
				RaycastHit[] results = ToLua.CheckObjectArray<RaycastHit>(L, 3);
				int n = Physics.SphereCastNonAlloc(ray, radius, results);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(RaycastHit[]), typeof(float)))
			{
				Ray ray2 = ToLua.ToRay(L, 1);
				float radius2 = (float)LuaDLL.lua_tonumber(L, 2);
				RaycastHit[] results2 = ToLua.CheckObjectArray<RaycastHit>(L, 3);
				float maxDistance = (float)LuaDLL.lua_tonumber(L, 4);
				int n2 = Physics.SphereCastNonAlloc(ray2, radius2, results2, maxDistance);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(Vector3), typeof(RaycastHit[])))
			{
				Vector3 origin = ToLua.ToVector3(L, 1);
				float radius3 = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 direction = ToLua.ToVector3(L, 3);
				RaycastHit[] results3 = ToLua.CheckObjectArray<RaycastHit>(L, 4);
				int n3 = Physics.SphereCastNonAlloc(origin, radius3, direction, results3);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(RaycastHit[]), typeof(float), typeof(int)))
			{
				Ray ray3 = ToLua.ToRay(L, 1);
				float radius4 = (float)LuaDLL.lua_tonumber(L, 2);
				RaycastHit[] results4 = ToLua.CheckObjectArray<RaycastHit>(L, 3);
				float maxDistance2 = (float)LuaDLL.lua_tonumber(L, 4);
				int layerMask = (int)LuaDLL.lua_tonumber(L, 5);
				int n4 = Physics.SphereCastNonAlloc(ray3, radius4, results4, maxDistance2, layerMask);
				LuaDLL.lua_pushinteger(L, n4);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(Vector3), typeof(RaycastHit[]), typeof(float)))
			{
				Vector3 origin2 = ToLua.ToVector3(L, 1);
				float radius5 = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 direction2 = ToLua.ToVector3(L, 3);
				RaycastHit[] results5 = ToLua.CheckObjectArray<RaycastHit>(L, 4);
				float maxDistance3 = (float)LuaDLL.lua_tonumber(L, 5);
				int n5 = Physics.SphereCastNonAlloc(origin2, radius5, direction2, results5, maxDistance3);
				LuaDLL.lua_pushinteger(L, n5);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(Vector3), typeof(RaycastHit[]), typeof(float), typeof(int)))
			{
				Vector3 origin3 = ToLua.ToVector3(L, 1);
				float radius6 = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 direction3 = ToLua.ToVector3(L, 3);
				RaycastHit[] results6 = ToLua.CheckObjectArray<RaycastHit>(L, 4);
				float maxDistance4 = (float)LuaDLL.lua_tonumber(L, 5);
				int layerMask2 = (int)LuaDLL.lua_tonumber(L, 6);
				int n6 = Physics.SphereCastNonAlloc(origin3, radius6, direction3, results6, maxDistance4, layerMask2);
				LuaDLL.lua_pushinteger(L, n6);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Ray), typeof(float), typeof(RaycastHit[]), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Ray ray4 = ToLua.ToRay(L, 1);
				float radius7 = (float)LuaDLL.lua_tonumber(L, 2);
				RaycastHit[] results7 = ToLua.CheckObjectArray<RaycastHit>(L, 3);
				float maxDistance5 = (float)LuaDLL.lua_tonumber(L, 4);
				int layerMask3 = (int)LuaDLL.lua_tonumber(L, 5);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 6));
				int n7 = Physics.SphereCastNonAlloc(ray4, radius7, results7, maxDistance5, layerMask3, queryTriggerInteraction);
				LuaDLL.lua_pushinteger(L, n7);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(Vector3), typeof(RaycastHit[]), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 origin4 = ToLua.ToVector3(L, 1);
				float radius8 = (float)LuaDLL.lua_tonumber(L, 2);
				Vector3 direction4 = ToLua.ToVector3(L, 3);
				RaycastHit[] results8 = ToLua.CheckObjectArray<RaycastHit>(L, 4);
				float maxDistance6 = (float)LuaDLL.lua_tonumber(L, 5);
				int layerMask4 = (int)LuaDLL.lua_tonumber(L, 6);
				QueryTriggerInteraction queryTriggerInteraction2 = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 7));
				int n8 = Physics.SphereCastNonAlloc(origin4, radius8, direction4, results8, maxDistance6, layerMask4, queryTriggerInteraction2);
				LuaDLL.lua_pushinteger(L, n8);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.SphereCastNonAlloc");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckSphere(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float)))
			{
				Vector3 position = ToLua.ToVector3(L, 1);
				float radius = (float)LuaDLL.lua_tonumber(L, 2);
				bool value = Physics.CheckSphere(position, radius);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(int)))
			{
				Vector3 position2 = ToLua.ToVector3(L, 1);
				float radius2 = (float)LuaDLL.lua_tonumber(L, 2);
				int layerMask = (int)LuaDLL.lua_tonumber(L, 3);
				bool value2 = Physics.CheckSphere(position2, radius2, layerMask);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 position3 = ToLua.ToVector3(L, 1);
				float radius3 = (float)LuaDLL.lua_tonumber(L, 2);
				int layerMask2 = (int)LuaDLL.lua_tonumber(L, 3);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 4));
				bool value3 = Physics.CheckSphere(position3, radius3, layerMask2, queryTriggerInteraction);
				LuaDLL.lua_pushboolean(L, value3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.CheckSphere");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckCapsule(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float)))
			{
				Vector3 start = ToLua.ToVector3(L, 1);
				Vector3 end = ToLua.ToVector3(L, 2);
				float radius = (float)LuaDLL.lua_tonumber(L, 3);
				bool value = Physics.CheckCapsule(start, end, radius);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(int)))
			{
				Vector3 start2 = ToLua.ToVector3(L, 1);
				Vector3 end2 = ToLua.ToVector3(L, 2);
				float radius2 = (float)LuaDLL.lua_tonumber(L, 3);
				int layermask = (int)LuaDLL.lua_tonumber(L, 4);
				bool value2 = Physics.CheckCapsule(start2, end2, radius2, layermask);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 start3 = ToLua.ToVector3(L, 1);
				Vector3 end3 = ToLua.ToVector3(L, 2);
				float radius3 = (float)LuaDLL.lua_tonumber(L, 3);
				int layermask2 = (int)LuaDLL.lua_tonumber(L, 4);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 5));
				bool value3 = Physics.CheckCapsule(start3, end3, radius3, layermask2, queryTriggerInteraction);
				LuaDLL.lua_pushboolean(L, value3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.CheckCapsule");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CheckBox(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3)))
			{
				Vector3 center = ToLua.ToVector3(L, 1);
				Vector3 halfExtents = ToLua.ToVector3(L, 2);
				bool value = Physics.CheckBox(center, halfExtents);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Quaternion)))
			{
				Vector3 center2 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents2 = ToLua.ToVector3(L, 2);
				Quaternion orientation = ToLua.ToQuaternion(L, 3);
				bool value2 = Physics.CheckBox(center2, halfExtents2, orientation);
				LuaDLL.lua_pushboolean(L, value2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Quaternion), typeof(int)))
			{
				Vector3 center3 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents3 = ToLua.ToVector3(L, 2);
				Quaternion orientation2 = ToLua.ToQuaternion(L, 3);
				int layermask = (int)LuaDLL.lua_tonumber(L, 4);
				bool value3 = Physics.CheckBox(center3, halfExtents3, orientation2, layermask);
				LuaDLL.lua_pushboolean(L, value3);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Quaternion), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 center4 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents4 = ToLua.ToVector3(L, 2);
				Quaternion orientation3 = ToLua.ToQuaternion(L, 3);
				int layermask2 = (int)LuaDLL.lua_tonumber(L, 4);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 5));
				bool value4 = Physics.CheckBox(center4, halfExtents4, orientation3, layermask2, queryTriggerInteraction);
				LuaDLL.lua_pushboolean(L, value4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.CheckBox");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OverlapBox(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3)))
			{
				Vector3 center = ToLua.ToVector3(L, 1);
				Vector3 halfExtents = ToLua.ToVector3(L, 2);
				Collider[] array = Physics.OverlapBox(center, halfExtents);
				ToLua.Push(L, array);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Quaternion)))
			{
				Vector3 center2 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents2 = ToLua.ToVector3(L, 2);
				Quaternion orientation = ToLua.ToQuaternion(L, 3);
				Collider[] array2 = Physics.OverlapBox(center2, halfExtents2, orientation);
				ToLua.Push(L, array2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Quaternion), typeof(int)))
			{
				Vector3 center3 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents3 = ToLua.ToVector3(L, 2);
				Quaternion orientation2 = ToLua.ToQuaternion(L, 3);
				int layerMask = (int)LuaDLL.lua_tonumber(L, 4);
				Collider[] array3 = Physics.OverlapBox(center3, halfExtents3, orientation2, layerMask);
				ToLua.Push(L, array3);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Quaternion), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 center4 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents4 = ToLua.ToVector3(L, 2);
				Quaternion orientation3 = ToLua.ToQuaternion(L, 3);
				int layerMask2 = (int)LuaDLL.lua_tonumber(L, 4);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 5));
				Collider[] array4 = Physics.OverlapBox(center4, halfExtents4, orientation3, layerMask2, queryTriggerInteraction);
				ToLua.Push(L, array4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.OverlapBox");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OverlapBoxNonAlloc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Collider[])))
			{
				Vector3 center = ToLua.ToVector3(L, 1);
				Vector3 halfExtents = ToLua.ToVector3(L, 2);
				Collider[] results = ToLua.CheckObjectArray<Collider>(L, 3);
				int n = Physics.OverlapBoxNonAlloc(center, halfExtents, results);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Collider[]), typeof(Quaternion)))
			{
				Vector3 center2 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents2 = ToLua.ToVector3(L, 2);
				Collider[] results2 = ToLua.CheckObjectArray<Collider>(L, 3);
				Quaternion orientation = ToLua.ToQuaternion(L, 4);
				int n2 = Physics.OverlapBoxNonAlloc(center2, halfExtents2, results2, orientation);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Collider[]), typeof(Quaternion), typeof(int)))
			{
				Vector3 center3 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents3 = ToLua.ToVector3(L, 2);
				Collider[] results3 = ToLua.CheckObjectArray<Collider>(L, 3);
				Quaternion orientation2 = ToLua.ToQuaternion(L, 4);
				int layerMask = (int)LuaDLL.lua_tonumber(L, 5);
				int n3 = Physics.OverlapBoxNonAlloc(center3, halfExtents3, results3, orientation2, layerMask);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Collider[]), typeof(Quaternion), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 center4 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents4 = ToLua.ToVector3(L, 2);
				Collider[] results4 = ToLua.CheckObjectArray<Collider>(L, 3);
				Quaternion orientation3 = ToLua.ToQuaternion(L, 4);
				int layerMask2 = (int)LuaDLL.lua_tonumber(L, 5);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 6));
				int n4 = Physics.OverlapBoxNonAlloc(center4, halfExtents4, results4, orientation3, layerMask2, queryTriggerInteraction);
				LuaDLL.lua_pushinteger(L, n4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.OverlapBoxNonAlloc");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int BoxCastAll(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3)))
			{
				Vector3 center = ToLua.ToVector3(L, 1);
				Vector3 halfExtents = ToLua.ToVector3(L, 2);
				Vector3 direction = ToLua.ToVector3(L, 3);
				RaycastHit[] array = Physics.BoxCastAll(center, halfExtents, direction);
				ToLua.Push(L, array);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(Quaternion)))
			{
				Vector3 center2 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents2 = ToLua.ToVector3(L, 2);
				Vector3 direction2 = ToLua.ToVector3(L, 3);
				Quaternion orientation = ToLua.ToQuaternion(L, 4);
				RaycastHit[] array2 = Physics.BoxCastAll(center2, halfExtents2, direction2, orientation);
				ToLua.Push(L, array2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(Quaternion), typeof(float)))
			{
				Vector3 center3 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents3 = ToLua.ToVector3(L, 2);
				Vector3 direction3 = ToLua.ToVector3(L, 3);
				Quaternion orientation2 = ToLua.ToQuaternion(L, 4);
				float maxDistance = (float)LuaDLL.lua_tonumber(L, 5);
				RaycastHit[] array3 = Physics.BoxCastAll(center3, halfExtents3, direction3, orientation2, maxDistance);
				ToLua.Push(L, array3);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(Quaternion), typeof(float), typeof(int)))
			{
				Vector3 center4 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents4 = ToLua.ToVector3(L, 2);
				Vector3 direction4 = ToLua.ToVector3(L, 3);
				Quaternion orientation3 = ToLua.ToQuaternion(L, 4);
				float maxDistance2 = (float)LuaDLL.lua_tonumber(L, 5);
				int layermask = (int)LuaDLL.lua_tonumber(L, 6);
				RaycastHit[] array4 = Physics.BoxCastAll(center4, halfExtents4, direction4, orientation3, maxDistance2, layermask);
				ToLua.Push(L, array4);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(Quaternion), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 center5 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents5 = ToLua.ToVector3(L, 2);
				Vector3 direction5 = ToLua.ToVector3(L, 3);
				Quaternion orientation4 = ToLua.ToQuaternion(L, 4);
				float maxDistance3 = (float)LuaDLL.lua_tonumber(L, 5);
				int layermask2 = (int)LuaDLL.lua_tonumber(L, 6);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 7));
				RaycastHit[] array5 = Physics.BoxCastAll(center5, halfExtents5, direction5, orientation4, maxDistance3, layermask2, queryTriggerInteraction);
				ToLua.Push(L, array5);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.BoxCastAll");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int BoxCastNonAlloc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(RaycastHit[])))
			{
				Vector3 center = ToLua.ToVector3(L, 1);
				Vector3 halfExtents = ToLua.ToVector3(L, 2);
				Vector3 direction = ToLua.ToVector3(L, 3);
				RaycastHit[] results = ToLua.CheckObjectArray<RaycastHit>(L, 4);
				int n = Physics.BoxCastNonAlloc(center, halfExtents, direction, results);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(RaycastHit[]), typeof(Quaternion)))
			{
				Vector3 center2 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents2 = ToLua.ToVector3(L, 2);
				Vector3 direction2 = ToLua.ToVector3(L, 3);
				RaycastHit[] results2 = ToLua.CheckObjectArray<RaycastHit>(L, 4);
				Quaternion orientation = ToLua.ToQuaternion(L, 5);
				int n2 = Physics.BoxCastNonAlloc(center2, halfExtents2, direction2, results2, orientation);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(RaycastHit[]), typeof(Quaternion), typeof(float)))
			{
				Vector3 center3 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents3 = ToLua.ToVector3(L, 2);
				Vector3 direction3 = ToLua.ToVector3(L, 3);
				RaycastHit[] results3 = ToLua.CheckObjectArray<RaycastHit>(L, 4);
				Quaternion orientation2 = ToLua.ToQuaternion(L, 5);
				float maxDistance = (float)LuaDLL.lua_tonumber(L, 6);
				int n3 = Physics.BoxCastNonAlloc(center3, halfExtents3, direction3, results3, orientation2, maxDistance);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(RaycastHit[]), typeof(Quaternion), typeof(float), typeof(int)))
			{
				Vector3 center4 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents4 = ToLua.ToVector3(L, 2);
				Vector3 direction4 = ToLua.ToVector3(L, 3);
				RaycastHit[] results4 = ToLua.CheckObjectArray<RaycastHit>(L, 4);
				Quaternion orientation3 = ToLua.ToQuaternion(L, 5);
				float maxDistance2 = (float)LuaDLL.lua_tonumber(L, 6);
				int layermask = (int)LuaDLL.lua_tonumber(L, 7);
				int n4 = Physics.BoxCastNonAlloc(center4, halfExtents4, direction4, results4, orientation3, maxDistance2, layermask);
				LuaDLL.lua_pushinteger(L, n4);
				result = 1;
			}
			else if (num == 8 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(RaycastHit[]), typeof(Quaternion), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 center5 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents5 = ToLua.ToVector3(L, 2);
				Vector3 direction5 = ToLua.ToVector3(L, 3);
				RaycastHit[] results5 = ToLua.CheckObjectArray<RaycastHit>(L, 4);
				Quaternion orientation4 = ToLua.ToQuaternion(L, 5);
				float maxDistance3 = (float)LuaDLL.lua_tonumber(L, 6);
				int layermask2 = (int)LuaDLL.lua_tonumber(L, 7);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 8));
				int n5 = Physics.BoxCastNonAlloc(center5, halfExtents5, direction5, results5, orientation4, maxDistance3, layermask2, queryTriggerInteraction);
				LuaDLL.lua_pushinteger(L, n5);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.BoxCastNonAlloc");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int BoxCast(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3)))
			{
				Vector3 center = ToLua.ToVector3(L, 1);
				Vector3 halfExtents = ToLua.ToVector3(L, 2);
				Vector3 direction = ToLua.ToVector3(L, 3);
				bool value = Physics.BoxCast(center, halfExtents, direction);
				LuaDLL.lua_pushboolean(L, value);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(LuaOut<RaycastHit>)))
			{
				Vector3 center2 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents2 = ToLua.ToVector3(L, 2);
				Vector3 direction2 = ToLua.ToVector3(L, 3);
				RaycastHit hit;
				bool value2 = Physics.BoxCast(center2, halfExtents2, direction2, out hit);
				LuaDLL.lua_pushboolean(L, value2);
				ToLua.Push(L, hit);
				result = 2;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(Quaternion)))
			{
				Vector3 center3 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents3 = ToLua.ToVector3(L, 2);
				Vector3 direction3 = ToLua.ToVector3(L, 3);
				Quaternion orientation = ToLua.ToQuaternion(L, 4);
				bool value3 = Physics.BoxCast(center3, halfExtents3, direction3, orientation);
				LuaDLL.lua_pushboolean(L, value3);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(Quaternion), typeof(float)))
			{
				Vector3 center4 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents4 = ToLua.ToVector3(L, 2);
				Vector3 direction4 = ToLua.ToVector3(L, 3);
				Quaternion orientation2 = ToLua.ToQuaternion(L, 4);
				float maxDistance = (float)LuaDLL.lua_tonumber(L, 5);
				bool value4 = Physics.BoxCast(center4, halfExtents4, direction4, orientation2, maxDistance);
				LuaDLL.lua_pushboolean(L, value4);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(Quaternion)))
			{
				Vector3 center5 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents5 = ToLua.ToVector3(L, 2);
				Vector3 direction5 = ToLua.ToVector3(L, 3);
				Quaternion orientation3 = ToLua.ToQuaternion(L, 5);
				RaycastHit hit2;
				bool value5 = Physics.BoxCast(center5, halfExtents5, direction5, out hit2, orientation3);
				LuaDLL.lua_pushboolean(L, value5);
				ToLua.Push(L, hit2);
				result = 2;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(Quaternion), typeof(float)))
			{
				Vector3 center6 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents6 = ToLua.ToVector3(L, 2);
				Vector3 direction6 = ToLua.ToVector3(L, 3);
				Quaternion orientation4 = ToLua.ToQuaternion(L, 5);
				float maxDistance2 = (float)LuaDLL.lua_tonumber(L, 6);
				RaycastHit hit3;
				bool value6 = Physics.BoxCast(center6, halfExtents6, direction6, out hit3, orientation4, maxDistance2);
				LuaDLL.lua_pushboolean(L, value6);
				ToLua.Push(L, hit3);
				result = 2;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(Quaternion), typeof(float), typeof(int)))
			{
				Vector3 center7 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents7 = ToLua.ToVector3(L, 2);
				Vector3 direction7 = ToLua.ToVector3(L, 3);
				Quaternion orientation5 = ToLua.ToQuaternion(L, 4);
				float maxDistance3 = (float)LuaDLL.lua_tonumber(L, 5);
				int layerMask = (int)LuaDLL.lua_tonumber(L, 6);
				bool value7 = Physics.BoxCast(center7, halfExtents7, direction7, orientation5, maxDistance3, layerMask);
				LuaDLL.lua_pushboolean(L, value7);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(Quaternion), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 center8 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents8 = ToLua.ToVector3(L, 2);
				Vector3 direction8 = ToLua.ToVector3(L, 3);
				Quaternion orientation6 = ToLua.ToQuaternion(L, 4);
				float maxDistance4 = (float)LuaDLL.lua_tonumber(L, 5);
				int layerMask2 = (int)LuaDLL.lua_tonumber(L, 6);
				QueryTriggerInteraction queryTriggerInteraction = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 7));
				bool value8 = Physics.BoxCast(center8, halfExtents8, direction8, orientation6, maxDistance4, layerMask2, queryTriggerInteraction);
				LuaDLL.lua_pushboolean(L, value8);
				result = 1;
			}
			else if (num == 7 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(Quaternion), typeof(float), typeof(int)))
			{
				Vector3 center9 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents9 = ToLua.ToVector3(L, 2);
				Vector3 direction9 = ToLua.ToVector3(L, 3);
				Quaternion orientation7 = ToLua.ToQuaternion(L, 5);
				float maxDistance5 = (float)LuaDLL.lua_tonumber(L, 6);
				int layerMask3 = (int)LuaDLL.lua_tonumber(L, 7);
				RaycastHit hit4;
				bool value9 = Physics.BoxCast(center9, halfExtents9, direction9, out hit4, orientation7, maxDistance5, layerMask3);
				LuaDLL.lua_pushboolean(L, value9);
				ToLua.Push(L, hit4);
				result = 2;
			}
			else if (num == 8 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(Vector3), typeof(Vector3), typeof(LuaOut<RaycastHit>), typeof(Quaternion), typeof(float), typeof(int), typeof(QueryTriggerInteraction)))
			{
				Vector3 center10 = ToLua.ToVector3(L, 1);
				Vector3 halfExtents10 = ToLua.ToVector3(L, 2);
				Vector3 direction10 = ToLua.ToVector3(L, 3);
				Quaternion orientation8 = ToLua.ToQuaternion(L, 5);
				float maxDistance6 = (float)LuaDLL.lua_tonumber(L, 6);
				int layerMask4 = (int)LuaDLL.lua_tonumber(L, 7);
				QueryTriggerInteraction queryTriggerInteraction2 = (QueryTriggerInteraction)((int)ToLua.ToObject(L, 8));
				RaycastHit hit5;
				bool value10 = Physics.BoxCast(center10, halfExtents10, direction10, out hit5, orientation8, maxDistance6, layerMask4, queryTriggerInteraction2);
				LuaDLL.lua_pushboolean(L, value10);
				ToLua.Push(L, hit5);
				result = 2;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.BoxCast");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IgnoreCollision(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Collider), typeof(Collider)))
			{
				Collider collider = (Collider)ToLua.ToObject(L, 1);
				Collider collider2 = (Collider)ToLua.ToObject(L, 2);
				Physics.IgnoreCollision(collider, collider2);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(Collider), typeof(Collider), typeof(bool)))
			{
				Collider collider3 = (Collider)ToLua.ToObject(L, 1);
				Collider collider4 = (Collider)ToLua.ToObject(L, 2);
				bool ignore = LuaDLL.lua_toboolean(L, 3);
				Physics.IgnoreCollision(collider3, collider4, ignore);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.IgnoreCollision");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IgnoreLayerCollision(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int)))
			{
				int layer = (int)LuaDLL.lua_tonumber(L, 1);
				int layer2 = (int)LuaDLL.lua_tonumber(L, 2);
				Physics.IgnoreLayerCollision(layer, layer2);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(int), typeof(bool)))
			{
				int layer3 = (int)LuaDLL.lua_tonumber(L, 1);
				int layer4 = (int)LuaDLL.lua_tonumber(L, 2);
				bool ignore = LuaDLL.lua_toboolean(L, 3);
				Physics.IgnoreLayerCollision(layer3, layer4, ignore);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.Physics.IgnoreLayerCollision");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetIgnoreLayerCollision(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			int layer = (int)LuaDLL.luaL_checknumber(L, 1);
			int layer2 = (int)LuaDLL.luaL_checknumber(L, 2);
			bool ignoreLayerCollision = Physics.GetIgnoreLayerCollision(layer, layer2);
			LuaDLL.lua_pushboolean(L, ignoreLayerCollision);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gravity(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, Physics.gravity);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_defaultContactOffset(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)Physics.defaultContactOffset);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bounceThreshold(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)Physics.bounceThreshold);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_solverIterationCount(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, Physics.solverIterationCount);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sleepThreshold(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)Physics.sleepThreshold);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_queriesHitTriggers(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, Physics.queriesHitTriggers);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_gravity(IntPtr L)
	{
		int result;
		try
		{
			Vector3 gravity = ToLua.ToVector3(L, 2);
			Physics.gravity = gravity;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_defaultContactOffset(IntPtr L)
	{
		int result;
		try
		{
			float defaultContactOffset = (float)LuaDLL.luaL_checknumber(L, 2);
			Physics.defaultContactOffset = defaultContactOffset;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bounceThreshold(IntPtr L)
	{
		int result;
		try
		{
			float bounceThreshold = (float)LuaDLL.luaL_checknumber(L, 2);
			Physics.bounceThreshold = bounceThreshold;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_solverIterationCount(IntPtr L)
	{
		int result;
		try
		{
			int solverIterationCount = (int)LuaDLL.luaL_checknumber(L, 2);
			Physics.solverIterationCount = solverIterationCount;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sleepThreshold(IntPtr L)
	{
		int result;
		try
		{
			float sleepThreshold = (float)LuaDLL.luaL_checknumber(L, 2);
			Physics.sleepThreshold = sleepThreshold;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_queriesHitTriggers(IntPtr L)
	{
		int result;
		try
		{
			bool queriesHitTriggers = LuaDLL.luaL_checkboolean(L, 2);
			Physics.queriesHitTriggers = queriesHitTriggers;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
