using LuaInterface;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

public class System_Collections_Generic_Dictionary_int_TestAccountWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Dictionary<int, TestAccount>), typeof(object), "AccountMap");
		L.RegFunction(".geti", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.get_Item));
		L.RegFunction("get_Item", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.get_Item));
		L.RegFunction(".seti", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.set_Item));
		L.RegFunction("set_Item", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.set_Item));
		L.RegFunction("Add", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.Add));
		L.RegFunction("Clear", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.Clear));
		L.RegFunction("ContainsKey", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.ContainsKey));
		L.RegFunction("ContainsValue", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.ContainsValue));
		L.RegFunction("GetObjectData", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.GetObjectData));
		L.RegFunction("OnDeserialization", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.OnDeserialization));
		L.RegFunction("Remove", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.Remove));
		L.RegFunction("TryGetValue", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.TryGetValue));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.GetEnumerator));
		L.RegFunction("New", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap._CreateSystem_Collections_Generic_Dictionary_int_TestAccount));
		L.RegVar("this", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap._this), null);
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Count", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.get_Count), null);
		L.RegVar("Comparer", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.get_Comparer), null);
		L.RegVar("Keys", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.get_Keys), null);
		L.RegVar("Values", new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap.get_Values), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSystem_Collections_Generic_Dictionary_int_TestAccount(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				Dictionary<int, TestAccount> o = new Dictionary<int, TestAccount>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int capacity = (int)LuaDLL.luaL_checknumber(L, 1);
				Dictionary<int, TestAccount> o2 = new Dictionary<int, TestAccount>(capacity);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(IDictionary<int, TestAccount>)))
			{
				IDictionary<int, TestAccount> dictionary = (IDictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(IDictionary<int, TestAccount>));
				Dictionary<int, TestAccount> o3 = new Dictionary<int, TestAccount>(dictionary);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(IEqualityComparer<int>)))
			{
				IEqualityComparer<int> comparer = (IEqualityComparer<int>)ToLua.CheckObject(L, 1, typeof(IEqualityComparer<int>));
				Dictionary<int, TestAccount> o4 = new Dictionary<int, TestAccount>(comparer);
				ToLua.PushObject(L, o4);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(int), typeof(IEqualityComparer<int>)))
			{
				int capacity2 = (int)LuaDLL.luaL_checknumber(L, 1);
				IEqualityComparer<int> comparer2 = (IEqualityComparer<int>)ToLua.CheckObject(L, 2, typeof(IEqualityComparer<int>));
				Dictionary<int, TestAccount> o5 = new Dictionary<int, TestAccount>(capacity2, comparer2);
				ToLua.PushObject(L, o5);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(IDictionary<int, TestAccount>), typeof(IEqualityComparer<int>)))
			{
				IDictionary<int, TestAccount> dictionary2 = (IDictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(IDictionary<int, TestAccount>));
				IEqualityComparer<int> comparer3 = (IEqualityComparer<int>)ToLua.CheckObject(L, 2, typeof(IEqualityComparer<int>));
				Dictionary<int, TestAccount> o6 = new Dictionary<int, TestAccount>(dictionary2, comparer3);
				ToLua.PushObject(L, o6);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: System.Collections.Generic.Dictionary<int,TestAccount>.New");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _get_this(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>));
			int key = (int)LuaDLL.luaL_checknumber(L, 2);
			TestAccount o = dictionary[key];
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
	private static int _set_this(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>));
			int key = (int)LuaDLL.luaL_checknumber(L, 2);
			TestAccount value = (TestAccount)ToLua.CheckObject(L, 3, typeof(TestAccount));
			dictionary[key] = value;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _this(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushvalue(L, 1);
			LuaDLL.tolua_bindthis(L, new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap._get_this), new LuaCSFunction(System_Collections_Generic_Dictionary_int_TestAccountWrap._set_this));
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Item(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>));
			int key = (int)LuaDLL.luaL_checknumber(L, 2);
			TestAccount o = dictionary[key];
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
	private static int set_Item(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>));
			int key = (int)LuaDLL.luaL_checknumber(L, 2);
			TestAccount value = (TestAccount)ToLua.CheckObject(L, 3, typeof(TestAccount));
			dictionary[key] = value;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Add(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>));
			int key = (int)LuaDLL.luaL_checknumber(L, 2);
			TestAccount value = (TestAccount)ToLua.CheckObject(L, 3, typeof(TestAccount));
			dictionary.Add(key, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>));
			dictionary.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ContainsKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>));
			int key = (int)LuaDLL.luaL_checknumber(L, 2);
			bool value = dictionary.ContainsKey(key);
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
	private static int ContainsValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>));
			TestAccount value = (TestAccount)ToLua.CheckObject(L, 2, typeof(TestAccount));
			bool value2 = dictionary.ContainsValue(value);
			LuaDLL.lua_pushboolean(L, value2);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetObjectData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>));
			SerializationInfo info = (SerializationInfo)ToLua.CheckObject(L, 2, typeof(SerializationInfo));
			StreamingContext context = (StreamingContext)ToLua.CheckObject(L, 3, typeof(StreamingContext));
			dictionary.GetObjectData(info, context);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnDeserialization(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>));
			object sender = ToLua.ToVarObject(L, 2);
			dictionary.OnDeserialization(sender);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Remove(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>));
			int key = (int)LuaDLL.luaL_checknumber(L, 2);
			bool value = dictionary.Remove(key);
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
	private static int TryGetValue(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>));
			int key = (int)LuaDLL.luaL_checknumber(L, 2);
			TestAccount o = null;
			bool value = dictionary.TryGetValue(key, out o);
			LuaDLL.lua_pushboolean(L, value);
			ToLua.PushObject(L, o);
			result = 2;
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
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)ToLua.CheckObject(L, 1, typeof(Dictionary<int, TestAccount>));
			Dictionary<int, TestAccount>.Enumerator enumerator = dictionary.GetEnumerator();
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
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)obj;
			int count = dictionary.Count;
			LuaDLL.lua_pushinteger(L, count);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Count on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Comparer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)obj;
			IEqualityComparer<int> comparer = dictionary.Comparer;
			ToLua.PushObject(L, comparer);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Comparer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Keys(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)obj;
			Dictionary<int, TestAccount>.KeyCollection keys = dictionary.Keys;
			ToLua.PushObject(L, keys);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Keys on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Values(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			Dictionary<int, TestAccount> dictionary = (Dictionary<int, TestAccount>)obj;
			Dictionary<int, TestAccount>.ValueCollection values = dictionary.Values;
			ToLua.PushObject(L, values);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Values on a nil value");
		}
		return result;
	}
}
