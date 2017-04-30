using LuaInterface;
using System;
using UnityEngine;

public class UnityEngine_ParticleEmitterWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ParticleEmitter), typeof(Component), null);
		L.RegFunction("ClearParticles", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.ClearParticles));
		L.RegFunction("Emit", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.Emit));
		L.RegFunction("Simulate", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.Simulate));
		L.RegFunction("__eq", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("emit", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_emit), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_emit));
		L.RegVar("minSize", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_minSize), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_minSize));
		L.RegVar("maxSize", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_maxSize), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_maxSize));
		L.RegVar("minEnergy", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_minEnergy), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_minEnergy));
		L.RegVar("maxEnergy", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_maxEnergy), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_maxEnergy));
		L.RegVar("minEmission", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_minEmission), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_minEmission));
		L.RegVar("maxEmission", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_maxEmission), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_maxEmission));
		L.RegVar("emitterVelocityScale", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_emitterVelocityScale), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_emitterVelocityScale));
		L.RegVar("worldVelocity", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_worldVelocity), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_worldVelocity));
		L.RegVar("localVelocity", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_localVelocity), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_localVelocity));
		L.RegVar("rndVelocity", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_rndVelocity), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_rndVelocity));
		L.RegVar("useWorldSpace", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_useWorldSpace), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_useWorldSpace));
		L.RegVar("rndRotation", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_rndRotation), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_rndRotation));
		L.RegVar("angularVelocity", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_angularVelocity), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_angularVelocity));
		L.RegVar("rndAngularVelocity", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_rndAngularVelocity), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_rndAngularVelocity));
		L.RegVar("particles", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_particles), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_particles));
		L.RegVar("particleCount", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_particleCount), null);
		L.RegVar("enabled", new LuaCSFunction(UnityEngine_ParticleEmitterWrap.get_enabled), new LuaCSFunction(UnityEngine_ParticleEmitterWrap.set_enabled));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearParticles(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)ToLua.CheckObject(L, 1, typeof(ParticleEmitter));
			particleEmitter.ClearParticles();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Emit(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(ParticleEmitter)))
			{
				ParticleEmitter particleEmitter = (ParticleEmitter)ToLua.ToObject(L, 1);
				particleEmitter.Emit();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(ParticleEmitter), typeof(int)))
			{
				ParticleEmitter particleEmitter2 = (ParticleEmitter)ToLua.ToObject(L, 1);
				int count = (int)LuaDLL.lua_tonumber(L, 2);
				particleEmitter2.Emit(count);
				result = 0;
			}
			else if (num == 6 && TypeChecker.CheckTypes(L, 1, typeof(ParticleEmitter), typeof(Vector3), typeof(Vector3), typeof(float), typeof(float), typeof(Color)))
			{
				ParticleEmitter particleEmitter3 = (ParticleEmitter)ToLua.ToObject(L, 1);
				Vector3 pos = ToLua.ToVector3(L, 2);
				Vector3 velocity = ToLua.ToVector3(L, 3);
				float size = (float)LuaDLL.lua_tonumber(L, 4);
				float energy = (float)LuaDLL.lua_tonumber(L, 5);
				Color color = ToLua.ToColor(L, 6);
				particleEmitter3.Emit(pos, velocity, size, energy, color);
				result = 0;
			}
			else if (num == 8 && TypeChecker.CheckTypes(L, 1, typeof(ParticleEmitter), typeof(Vector3), typeof(Vector3), typeof(float), typeof(float), typeof(Color), typeof(float), typeof(float)))
			{
				ParticleEmitter particleEmitter4 = (ParticleEmitter)ToLua.ToObject(L, 1);
				Vector3 pos2 = ToLua.ToVector3(L, 2);
				Vector3 velocity2 = ToLua.ToVector3(L, 3);
				float size2 = (float)LuaDLL.lua_tonumber(L, 4);
				float energy2 = (float)LuaDLL.lua_tonumber(L, 5);
				Color color2 = ToLua.ToColor(L, 6);
				float rotation = (float)LuaDLL.lua_tonumber(L, 7);
				float angularVelocity = (float)LuaDLL.lua_tonumber(L, 8);
				particleEmitter4.Emit(pos2, velocity2, size2, energy2, color2, rotation, angularVelocity);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.ParticleEmitter.Emit");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Simulate(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ParticleEmitter particleEmitter = (ParticleEmitter)ToLua.CheckObject(L, 1, typeof(ParticleEmitter));
			float deltaTime = (float)LuaDLL.luaL_checknumber(L, 2);
			particleEmitter.Simulate(deltaTime);
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
	private static int get_emit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			bool emit = particleEmitter.emit;
			LuaDLL.lua_pushboolean(L, emit);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index emit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float minSize = particleEmitter.minSize;
			LuaDLL.lua_pushnumber(L, (double)minSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float maxSize = particleEmitter.maxSize;
			LuaDLL.lua_pushnumber(L, (double)maxSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minEnergy(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float minEnergy = particleEmitter.minEnergy;
			LuaDLL.lua_pushnumber(L, (double)minEnergy);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minEnergy on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxEnergy(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float maxEnergy = particleEmitter.maxEnergy;
			LuaDLL.lua_pushnumber(L, (double)maxEnergy);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxEnergy on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_minEmission(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float minEmission = particleEmitter.minEmission;
			LuaDLL.lua_pushnumber(L, (double)minEmission);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minEmission on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxEmission(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float maxEmission = particleEmitter.maxEmission;
			LuaDLL.lua_pushnumber(L, (double)maxEmission);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxEmission on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_emitterVelocityScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float emitterVelocityScale = particleEmitter.emitterVelocityScale;
			LuaDLL.lua_pushnumber(L, (double)emitterVelocityScale);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index emitterVelocityScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_worldVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			Vector3 worldVelocity = particleEmitter.worldVelocity;
			ToLua.Push(L, worldVelocity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_localVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			Vector3 localVelocity = particleEmitter.localVelocity;
			ToLua.Push(L, localVelocity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rndVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			Vector3 rndVelocity = particleEmitter.rndVelocity;
			ToLua.Push(L, rndVelocity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rndVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useWorldSpace(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			bool useWorldSpace = particleEmitter.useWorldSpace;
			LuaDLL.lua_pushboolean(L, useWorldSpace);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useWorldSpace on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rndRotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			bool rndRotation = particleEmitter.rndRotation;
			LuaDLL.lua_pushboolean(L, rndRotation);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rndRotation on a nil value");
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
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float angularVelocity = particleEmitter.angularVelocity;
			LuaDLL.lua_pushnumber(L, (double)angularVelocity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index angularVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rndAngularVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float rndAngularVelocity = particleEmitter.rndAngularVelocity;
			LuaDLL.lua_pushnumber(L, (double)rndAngularVelocity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rndAngularVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_particles(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			Particle[] particles = particleEmitter.particles;
			ToLua.Push(L, particles);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index particles on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_particleCount(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			int particleCount = particleEmitter.particleCount;
			LuaDLL.lua_pushinteger(L, particleCount);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index particleCount on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_enabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			bool enabled = particleEmitter.enabled;
			LuaDLL.lua_pushboolean(L, enabled);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index enabled on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_emit(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			bool emit = LuaDLL.luaL_checkboolean(L, 2);
			particleEmitter.emit = emit;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index emit on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_minSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float minSize = (float)LuaDLL.luaL_checknumber(L, 2);
			particleEmitter.minSize = minSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float maxSize = (float)LuaDLL.luaL_checknumber(L, 2);
			particleEmitter.maxSize = maxSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_minEnergy(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float minEnergy = (float)LuaDLL.luaL_checknumber(L, 2);
			particleEmitter.minEnergy = minEnergy;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minEnergy on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxEnergy(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float maxEnergy = (float)LuaDLL.luaL_checknumber(L, 2);
			particleEmitter.maxEnergy = maxEnergy;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxEnergy on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_minEmission(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float minEmission = (float)LuaDLL.luaL_checknumber(L, 2);
			particleEmitter.minEmission = minEmission;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index minEmission on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxEmission(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float maxEmission = (float)LuaDLL.luaL_checknumber(L, 2);
			particleEmitter.maxEmission = maxEmission;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index maxEmission on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_emitterVelocityScale(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float emitterVelocityScale = (float)LuaDLL.luaL_checknumber(L, 2);
			particleEmitter.emitterVelocityScale = emitterVelocityScale;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index emitterVelocityScale on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_worldVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			Vector3 worldVelocity = ToLua.ToVector3(L, 2);
			particleEmitter.worldVelocity = worldVelocity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index worldVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_localVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			Vector3 localVelocity = ToLua.ToVector3(L, 2);
			particleEmitter.localVelocity = localVelocity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index localVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rndVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			Vector3 rndVelocity = ToLua.ToVector3(L, 2);
			particleEmitter.rndVelocity = rndVelocity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rndVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useWorldSpace(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			bool useWorldSpace = LuaDLL.luaL_checkboolean(L, 2);
			particleEmitter.useWorldSpace = useWorldSpace;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index useWorldSpace on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rndRotation(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			bool rndRotation = LuaDLL.luaL_checkboolean(L, 2);
			particleEmitter.rndRotation = rndRotation;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rndRotation on a nil value");
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
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float angularVelocity = (float)LuaDLL.luaL_checknumber(L, 2);
			particleEmitter.angularVelocity = angularVelocity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index angularVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rndAngularVelocity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			float rndAngularVelocity = (float)LuaDLL.luaL_checknumber(L, 2);
			particleEmitter.rndAngularVelocity = rndAngularVelocity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index rndAngularVelocity on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_particles(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			Particle[] particles = ToLua.CheckObjectArray<Particle>(L, 2);
			particleEmitter.particles = particles;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index particles on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_enabled(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			ParticleEmitter particleEmitter = (ParticleEmitter)obj;
			bool enabled = LuaDLL.luaL_checkboolean(L, 2);
			particleEmitter.enabled = enabled;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index enabled on a nil value");
		}
		return result;
	}
}
