using LuaInterface;
using System;

public class SDKInterfaceWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SDKInterface), typeof(object), null);
		L.RegFunction("Init", new LuaCSFunction(SDKInterfaceWrap.Init));
		L.RegFunction("Login", new LuaCSFunction(SDKInterfaceWrap.Login));
		L.RegFunction("LoginCustom", new LuaCSFunction(SDKInterfaceWrap.LoginCustom));
		L.RegFunction("SwitchLogin", new LuaCSFunction(SDKInterfaceWrap.SwitchLogin));
		L.RegFunction("Logout", new LuaCSFunction(SDKInterfaceWrap.Logout));
		L.RegFunction("ShowAccountCenter", new LuaCSFunction(SDKInterfaceWrap.ShowAccountCenter));
		L.RegFunction("SubmitGameData", new LuaCSFunction(SDKInterfaceWrap.SubmitGameData));
		L.RegFunction("SDKExit", new LuaCSFunction(SDKInterfaceWrap.SDKExit));
		L.RegFunction("Pay", new LuaCSFunction(SDKInterfaceWrap.Pay));
		L.RegFunction("IsSupportExit", new LuaCSFunction(SDKInterfaceWrap.IsSupportExit));
		L.RegFunction("IsSupportAccountCenter", new LuaCSFunction(SDKInterfaceWrap.IsSupportAccountCenter));
		L.RegFunction("IsSupportLogout", new LuaCSFunction(SDKInterfaceWrap.IsSupportLogout));
		L.RegFunction("GetMacAddr", new LuaCSFunction(SDKInterfaceWrap.GetMacAddr));
		L.RegFunction("GetIpAddr", new LuaCSFunction(SDKInterfaceWrap.GetIpAddr));
		L.RegFunction("reqOrder", new LuaCSFunction(SDKInterfaceWrap.reqOrder));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("OnLoginSuc", new LuaCSFunction(SDKInterfaceWrap.get_OnLoginSuc), new LuaCSFunction(SDKInterfaceWrap.set_OnLoginSuc));
		L.RegVar("OnLogout", new LuaCSFunction(SDKInterfaceWrap.get_OnLogout), new LuaCSFunction(SDKInterfaceWrap.set_OnLogout));
		L.RegVar("Instance", new LuaCSFunction(SDKInterfaceWrap.get_Instance), null);
		L.RegFunction("LogoutHandler", new LuaCSFunction(SDKInterfaceWrap.SDKInterface_LogoutHandler));
		L.RegFunction("LoginSucHandler", new LuaCSFunction(SDKInterfaceWrap.SDKInterface_LoginSucHandler));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Init(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SDKInterface sDKInterface = (SDKInterface)ToLua.CheckObject(L, 1, typeof(SDKInterface));
			sDKInterface.Init();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Login(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SDKInterface sDKInterface = (SDKInterface)ToLua.CheckObject(L, 1, typeof(SDKInterface));
			sDKInterface.Login();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LoginCustom(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SDKInterface sDKInterface = (SDKInterface)ToLua.CheckObject(L, 1, typeof(SDKInterface));
			string customData = ToLua.CheckString(L, 2);
			sDKInterface.LoginCustom(customData);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SwitchLogin(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SDKInterface sDKInterface = (SDKInterface)ToLua.CheckObject(L, 1, typeof(SDKInterface));
			sDKInterface.SwitchLogin();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Logout(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SDKInterface sDKInterface = (SDKInterface)ToLua.CheckObject(L, 1, typeof(SDKInterface));
			bool value = sDKInterface.Logout();
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
	private static int ShowAccountCenter(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SDKInterface sDKInterface = (SDKInterface)ToLua.CheckObject(L, 1, typeof(SDKInterface));
			bool value = sDKInterface.ShowAccountCenter();
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
	private static int SubmitGameData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SDKInterface sDKInterface = (SDKInterface)ToLua.CheckObject(L, 1, typeof(SDKInterface));
			ExtraGameData data = (ExtraGameData)ToLua.CheckObject(L, 2, typeof(ExtraGameData));
			sDKInterface.SubmitGameData(data);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SDKExit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SDKInterface sDKInterface = (SDKInterface)ToLua.CheckObject(L, 1, typeof(SDKInterface));
			bool value = sDKInterface.SDKExit();
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
	private static int Pay(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SDKInterface sDKInterface = (SDKInterface)ToLua.CheckObject(L, 1, typeof(SDKInterface));
			PayParams data = (PayParams)ToLua.CheckObject(L, 2, typeof(PayParams));
			sDKInterface.Pay(data);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsSupportExit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SDKInterface sDKInterface = (SDKInterface)ToLua.CheckObject(L, 1, typeof(SDKInterface));
			bool value = sDKInterface.IsSupportExit();
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
	private static int IsSupportAccountCenter(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SDKInterface sDKInterface = (SDKInterface)ToLua.CheckObject(L, 1, typeof(SDKInterface));
			bool value = sDKInterface.IsSupportAccountCenter();
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
	private static int IsSupportLogout(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SDKInterface sDKInterface = (SDKInterface)ToLua.CheckObject(L, 1, typeof(SDKInterface));
			bool value = sDKInterface.IsSupportLogout();
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
	private static int GetMacAddr(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SDKInterface sDKInterface = (SDKInterface)ToLua.CheckObject(L, 1, typeof(SDKInterface));
			string macAddr = sDKInterface.GetMacAddr();
			LuaDLL.lua_pushstring(L, macAddr);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetIpAddr(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			SDKInterface sDKInterface = (SDKInterface)ToLua.CheckObject(L, 1, typeof(SDKInterface));
			string ipAddr = sDKInterface.GetIpAddr();
			LuaDLL.lua_pushstring(L, ipAddr);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int reqOrder(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			SDKInterface sDKInterface = (SDKInterface)ToLua.CheckObject(L, 1, typeof(SDKInterface));
			PayParams data = (PayParams)ToLua.CheckObject(L, 2, typeof(PayParams));
			PayParams o = sDKInterface.reqOrder(data);
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
	private static int get_OnLoginSuc(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SDKInterface sDKInterface = (SDKInterface)obj;
			SDKInterface.LoginSucHandler onLoginSuc = sDKInterface.OnLoginSuc;
			ToLua.Push(L, onLoginSuc);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnLoginSuc on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnLogout(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SDKInterface sDKInterface = (SDKInterface)obj;
			SDKInterface.LogoutHandler onLogout = sDKInterface.OnLogout;
			ToLua.Push(L, onLogout);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnLogout on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Instance(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, SDKInterface.Instance);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnLoginSuc(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SDKInterface sDKInterface = (SDKInterface)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			SDKInterface.LoginSucHandler onLoginSuc;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onLoginSuc = (SDKInterface.LoginSucHandler)ToLua.CheckObject(L, 2, typeof(SDKInterface.LoginSucHandler));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onLoginSuc = (DelegateFactory.CreateDelegate(typeof(SDKInterface.LoginSucHandler), func) as SDKInterface.LoginSucHandler);
			}
			sDKInterface.OnLoginSuc = onLoginSuc;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnLoginSuc on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnLogout(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			SDKInterface sDKInterface = (SDKInterface)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			SDKInterface.LogoutHandler onLogout;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onLogout = (SDKInterface.LogoutHandler)ToLua.CheckObject(L, 2, typeof(SDKInterface.LogoutHandler));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onLogout = (DelegateFactory.CreateDelegate(typeof(SDKInterface.LogoutHandler), func) as SDKInterface.LogoutHandler);
			}
			sDKInterface.OnLogout = onLogout;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnLogout on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SDKInterface_LogoutHandler(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(SDKInterface.LogoutHandler), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(SDKInterface.LogoutHandler), func, self);
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
	private static int SDKInterface_LoginSucHandler(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(SDKInterface.LoginSucHandler), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(SDKInterface.LoginSucHandler), func, self);
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
