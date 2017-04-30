using LuaInterface;
using System;
using System.Collections.Generic;

public class System_Collections_Generic_Dictionary_int_TestAccount_KeyCollectionWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Dictionary<int, TestAccount>.KeyCollection), typeof(object), "KeyCollection");
		L.RegFunction("CopyTo", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccount_KeyCollectionWrap.CopyTo));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccount_KeyCollectionWrap.GetEnumerator));
		L.RegFunction("New", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccount_KeyCollectionWrap._CreateSystem_Collections_Generic_Dictionary_int_TestAccount_KeyCollection));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Count", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccount_KeyCollectionWrap.get_Count), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSystem_Collections_Generic_Dictionary_int_TestAccount_KeyCollection(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1)
			{
				Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>));
				Dictionary<int, TestAccount>.KeyCollection o = new Dictionary<int, TestAccount>.KeyCollection(dictionary);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: System.Collections.Generic.Dictionary<int,TestAccount>.KeyCollection.New");
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
			Dictionary<int, TestAccount>.KeyCollection keyCollection = (Dictionary<int, TestAccount>.KeyCollection)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>.KeyCollection));
			int[] array = ToLua.CheckNumberArray<int>(L, 2);
			int index = (int)LuaDLL.luaL_checknumber(L, 3);
			keyCollection.CopyTo(array, index);
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
			Dictionary<int, TestAccount>.KeyCollection keyCollection = (Dictionary<int, TestAccount>.KeyCollection)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>.KeyCollection));
			Dictionary<int, TestAccount>.KeyCollection.Enumerator enumerator = keyCollection.GetEnumerator();
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
	private static int get_Count(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Dictionary<int, TestAccount>.KeyCollection keyCollection = (Dictionary<int, TestAccount>.KeyCollection)obj;
			int count = keyCollection.Count;
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
