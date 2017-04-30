using LuaInterface;
using System;
using System.Collections.Generic;

public class System_Collections_Generic_KeyValuePair_int_TestAccountWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(KeyValuePair<int, TestAccount>), null, "KeyValuePair_int_TestAccount");
		L.RegFunction("ToString", new LuaCSFunction(System_Collections_Generic_KeyValuePair_int_TestAccountWrap.ToString));
		L.RegFunction("New", new LuaCSFunction(System_Collections_Generic_KeyValuePair_int_TestAccountWrap._CreateSystem_Collections_Generic_KeyValuePair_int_TestAccount));
		L.RegFunction("__tostring", new LuaCSFunction(System_Collections_Generic_KeyValuePair_int_TestAccountWrap.Lua_ToString));
		L.RegVar("Key", new LuaCSFunction(System_Collections_Generic_KeyValuePair_int_TestAccountWrap.get_Key), null);
		L.RegVar("Value", new LuaCSFunction(System_Collections_Generic_KeyValuePair_int_TestAccountWrap.get_Value), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSystem_Collections_Generic_KeyValuePair_int_TestAccount(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2)
			{
				int key = (int)LuaDLL.luaL_checknumber(L, 1);
				TestAccount value = (TestAccount)ToLua.CheckObject(L, 2, typeof(TestAccount));
				KeyValuePair<int, TestAccount> keyValuePair = new KeyValuePair<int, TestAccount>(key, value);
				ToLua.PushValue(L, keyValuePair);
				result = 1;
			}
			else if (num == 0)
			{
				ToLua.PushValue(L, default(KeyValuePair<int, TestAccount>));
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: System.Collections.Generic.KeyValuePair<int,TestAccount>.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			KeyValuePair<int, TestAccount> keyValuePair = (KeyValuePair<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(KeyValuePair<int, TestAccount>));
			string str = keyValuePair.ToString();
			LuaDLL.lua_pushstring(L, str);
			ToLua.SetBack(L, 1, keyValuePair);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Lua_ToString(IntPtr L)
	{
		object obj = ToLua.ToObject(L, 1);
		if (obj != null)
		{
			LuaDLL.lua_pushstring(L, obj.ToString());
		}
		else
		{
			LuaDLL.lua_pushnil(L);
		}
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Key(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			int key = ((KeyValuePair<int, TestAccount>)obj).Key;
			LuaDLL.lua_pushinteger(L, key);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Key on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Value(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestAccount value = ((KeyValuePair<int, TestAccount>)obj).Value;
			ToLua.PushObject(L, value);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Value on a nil value");
		}
		return result;
	}
}
