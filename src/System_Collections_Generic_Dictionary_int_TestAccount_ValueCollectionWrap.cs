using LuaInterface;
using System;
using System.Collections.Generic;

public class System_Collections_Generic_Dictionary_int_TestAccount_ValueCollectionWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Dictionary<int, TestAccount>.ValueCollection), typeof(object), "ValueCollection");
		L.RegFunction("CopyTo", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccount_ValueCollectionWrap.CopyTo));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccount_ValueCollectionWrap.GetEnumerator));
		L.RegFunction("New", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccount_ValueCollectionWrap._CreateSystem_Collections_Generic_Dictionary_int_TestAccount_ValueCollection));
		L.RegFunction("__tostring", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccount_ValueCollectionWrap.Lua_ToString));
		L.RegVar("Count", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccount_ValueCollectionWrap.get_Count), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSystem_Collections_Generic_Dictionary_int_TestAccount_ValueCollection(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1)
			{
				Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>));
				Dictionary<int, TestAccount>.ValueCollection o = new Dictionary<int, TestAccount>.ValueCollection(dictionary);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: System.Collections.Generic.Dictionary<int,TestAccount>.ValueCollection.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CopyTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Dictionary<int, TestAccount>.ValueCollection valueCollection = (Dictionary<int, TestAccount>.ValueCollection)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>.ValueCollection));
			TestAccount[] array = ToLua.CheckObjectArray<TestAccount>(L, 2);
			int index = (int)LuaDLL.luaL_checknumber(L, 3);
			valueCollection.CopyTo(array, index);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetEnumerator(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Dictionary<int, TestAccount>.ValueCollection valueCollection = (Dictionary<int, TestAccount>.ValueCollection)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>.ValueCollection));
			Dictionary<int, TestAccount>.ValueCollection.Enumerator enumerator = valueCollection.GetEnumerator();
			ToLua.Push(L, enumerator);
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
	private static int get_Count(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Dictionary<int, TestAccount>.ValueCollection valueCollection = (Dictionary<int, TestAccount>.ValueCollection)obj;
			int count = valueCollection.Count;
			LuaDLL.lua_pushinteger(L, count);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Count on a nil value");
		}
		return result;
	}
}
