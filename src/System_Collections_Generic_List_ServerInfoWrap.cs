using LuaInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class System_Collections_Generic_List_ServerInfoWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(List<ServerInfo>), typeof(object), "List_ServerInfo");
		L.RegFunction("Add", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.Add));
		L.RegFunction("AddRange", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.AddRange));
		L.RegFunction("AsReadOnly", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.AsReadOnly));
		L.RegFunction("BinarySearch", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.BinarySearch));
		L.RegFunction("Clear", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.Clear));
		L.RegFunction("Contains", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.Contains));
		L.RegFunction("CopyTo", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.CopyTo));
		L.RegFunction("Exists", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.Exists));
		L.RegFunction("Find", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.Find));
		L.RegFunction("FindAll", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.FindAll));
		L.RegFunction("FindIndex", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.FindIndex));
		L.RegFunction("FindLast", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.FindLast));
		L.RegFunction("FindLastIndex", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.FindLastIndex));
		L.RegFunction("ForEach", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.ForEach));
		L.RegFunction("GetEnumerator", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.GetEnumerator));
		L.RegFunction("GetRange", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.GetRange));
		L.RegFunction("IndexOf", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.IndexOf));
		L.RegFunction("Insert", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.Insert));
		L.RegFunction("InsertRange", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.InsertRange));
		L.RegFunction("LastIndexOf", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.LastIndexOf));
		L.RegFunction("Remove", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.Remove));
		L.RegFunction("RemoveAll", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.RemoveAll));
		L.RegFunction("RemoveAt", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.RemoveAt));
		L.RegFunction("RemoveRange", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.RemoveRange));
		L.RegFunction("Reverse", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.Reverse));
		L.RegFunction("Sort", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.Sort));
		L.RegFunction("ToArray", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.ToArray));
		L.RegFunction("TrimExcess", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.TrimExcess));
		L.RegFunction("TrueForAll", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.TrueForAll));
		L.RegFunction(".geti", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.get_Item));
		L.RegFunction("get_Item", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.get_Item));
		L.RegFunction(".seti", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.set_Item));
		L.RegFunction("set_Item", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.set_Item));
		L.RegFunction("New", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap._CreateSystem_Collections_Generic_List_ServerInfo));
		L.RegVar("this", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap._this), null);
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("Capacity", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.get_Capacity), new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.set_Capacity));
		L.RegVar("Count", new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap.get_Count), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateSystem_Collections_Generic_List_ServerInfo(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				List<ServerInfo> o = new List<ServerInfo>();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(int)))
			{
				int capacity = (int)LuaDLL.luaL_checknumber(L, 1);
				List<ServerInfo> o2 = new List<ServerInfo>(capacity);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(IEnumerable<ServerInfo>)))
			{
				IEnumerable<ServerInfo> collection = (IEnumerable<ServerInfo>)ToLua.CheckObject(L, 1, typeof(IEnumerable<ServerInfo>));
				List<ServerInfo> o3 = new List<ServerInfo>(collection);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: System.Collections.Generic.List<ServerInfo>.New");
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
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			ServerInfo o = list[index];
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
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			ServerInfo value = (ServerInfo)ToLua.CheckObject(L, 3, typeof(ServerInfo));
			list[index] = value;
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
			LuaDLL.tolua_bindthis(L, new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap._get_this), new LuaCSFunction(System_Collections_Generic_List_ServerInfoWrap._set_this));
			result = 1;
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
			ToLua.CheckArgsCount(L, 2);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			ServerInfo item = (ServerInfo)ToLua.CheckObject(L, 2, typeof(ServerInfo));
			list.Add(item);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddRange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			IEnumerable<ServerInfo> collection = (IEnumerable<ServerInfo>)ToLua.CheckObject(L, 2, typeof(IEnumerable<ServerInfo>));
			list.AddRange(collection);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AsReadOnly(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			ReadOnlyCollection<ServerInfo> o = list.AsReadOnly();
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
	private static int BinarySearch(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(ServerInfo)))
			{
				List<ServerInfo> list = (List<ServerInfo>)ToLua.ToObject(L, 1);
				ServerInfo item = (ServerInfo)ToLua.ToObject(L, 2);
				int n = list.BinarySearch(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(ServerInfo), typeof(IComparer<ServerInfo>)))
			{
				List<ServerInfo> list2 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				ServerInfo item2 = (ServerInfo)ToLua.ToObject(L, 2);
				IComparer<ServerInfo> comparer = (IComparer<ServerInfo>)ToLua.ToObject(L, 3);
				int n2 = list2.BinarySearch(item2, comparer);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(int), typeof(int), typeof(ServerInfo), typeof(IComparer<ServerInfo>)))
			{
				List<ServerInfo> list3 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				ServerInfo item3 = (ServerInfo)ToLua.ToObject(L, 4);
				IComparer<ServerInfo> comparer2 = (IComparer<ServerInfo>)ToLua.ToObject(L, 5);
				int n3 = list3.BinarySearch(index, count, item3, comparer2);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<ServerInfo>.BinarySearch");
			}
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
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			list.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Contains(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			ServerInfo item = (ServerInfo)ToLua.CheckObject(L, 2, typeof(ServerInfo));
			bool value = list.Contains(item);
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
	private static int CopyTo(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(ServerInfo[])))
			{
				List<ServerInfo> list = (List<ServerInfo>)ToLua.ToObject(L, 1);
				ServerInfo[] array = ToLua.CheckObjectArray<ServerInfo>(L, 2);
				list.CopyTo(array);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(ServerInfo[]), typeof(int)))
			{
				List<ServerInfo> list2 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				ServerInfo[] array2 = ToLua.CheckObjectArray<ServerInfo>(L, 2);
				int arrayIndex = (int)LuaDLL.lua_tonumber(L, 3);
				list2.CopyTo(array2, arrayIndex);
				result = 0;
			}
			else if (num == 5 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(int), typeof(ServerInfo[]), typeof(int), typeof(int)))
			{
				List<ServerInfo> list3 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				ServerInfo[] array3 = ToLua.CheckObjectArray<ServerInfo>(L, 3);
				int arrayIndex2 = (int)LuaDLL.lua_tonumber(L, 4);
				int count = (int)LuaDLL.lua_tonumber(L, 5);
				list3.CopyTo(index, array3, arrayIndex2, count);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<ServerInfo>.CopyTo");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Exists(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<ServerInfo> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<ServerInfo>)ToLua.CheckObject(L, 2, typeof(Predicate<ServerInfo>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<ServerInfo>), func) as Predicate<ServerInfo>);
			}
			bool value = list.Exists(match);
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
	private static int Find(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<ServerInfo> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<ServerInfo>)ToLua.CheckObject(L, 2, typeof(Predicate<ServerInfo>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<ServerInfo>), func) as Predicate<ServerInfo>);
			}
			ServerInfo o = list.Find(match);
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
	private static int FindAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<ServerInfo> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<ServerInfo>)ToLua.CheckObject(L, 2, typeof(Predicate<ServerInfo>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<ServerInfo>), func) as Predicate<ServerInfo>);
			}
			List<ServerInfo> o = list.FindAll(match);
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
	private static int FindIndex(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(Predicate<ServerInfo>)))
			{
				List<ServerInfo> list = (List<ServerInfo>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Predicate<ServerInfo> match;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					match = (Predicate<ServerInfo>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					match = (DelegateFactory.CreateDelegate(typeof(Predicate<ServerInfo>), func) as Predicate<ServerInfo>);
				}
				int n = list.FindIndex(match);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(int), typeof(Predicate<ServerInfo>)))
			{
				List<ServerInfo> list2 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 2);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
				Predicate<ServerInfo> match2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					match2 = (Predicate<ServerInfo>)ToLua.ToObject(L, 3);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 3);
					match2 = (DelegateFactory.CreateDelegate(typeof(Predicate<ServerInfo>), func2) as Predicate<ServerInfo>);
				}
				int n2 = list2.FindIndex(startIndex, match2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(int), typeof(int), typeof(Predicate<ServerInfo>)))
			{
				List<ServerInfo> list3 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				LuaTypes luaTypes3 = LuaDLL.lua_type(L, 4);
				Predicate<ServerInfo> match3;
				if (luaTypes3 != LuaTypes.LUA_TFUNCTION)
				{
					match3 = (Predicate<ServerInfo>)ToLua.ToObject(L, 4);
				}
				else
				{
					LuaFunction func3 = ToLua.ToLuaFunction(L, 4);
					match3 = (DelegateFactory.CreateDelegate(typeof(Predicate<ServerInfo>), func3) as Predicate<ServerInfo>);
				}
				int n3 = list3.FindIndex(startIndex2, count, match3);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<ServerInfo>.FindIndex");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int FindLast(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<ServerInfo> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<ServerInfo>)ToLua.CheckObject(L, 2, typeof(Predicate<ServerInfo>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<ServerInfo>), func) as Predicate<ServerInfo>);
			}
			ServerInfo o = list.FindLast(match);
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
	private static int FindLastIndex(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(Predicate<ServerInfo>)))
			{
				List<ServerInfo> list = (List<ServerInfo>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Predicate<ServerInfo> match;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					match = (Predicate<ServerInfo>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					match = (DelegateFactory.CreateDelegate(typeof(Predicate<ServerInfo>), func) as Predicate<ServerInfo>);
				}
				int n = list.FindLastIndex(match);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(int), typeof(Predicate<ServerInfo>)))
			{
				List<ServerInfo> list2 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				int startIndex = (int)LuaDLL.lua_tonumber(L, 2);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 3);
				Predicate<ServerInfo> match2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					match2 = (Predicate<ServerInfo>)ToLua.ToObject(L, 3);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 3);
					match2 = (DelegateFactory.CreateDelegate(typeof(Predicate<ServerInfo>), func2) as Predicate<ServerInfo>);
				}
				int n2 = list2.FindLastIndex(startIndex, match2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(int), typeof(int), typeof(Predicate<ServerInfo>)))
			{
				List<ServerInfo> list3 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				int startIndex2 = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				LuaTypes luaTypes3 = LuaDLL.lua_type(L, 4);
				Predicate<ServerInfo> match3;
				if (luaTypes3 != LuaTypes.LUA_TFUNCTION)
				{
					match3 = (Predicate<ServerInfo>)ToLua.ToObject(L, 4);
				}
				else
				{
					LuaFunction func3 = ToLua.ToLuaFunction(L, 4);
					match3 = (DelegateFactory.CreateDelegate(typeof(Predicate<ServerInfo>), func3) as Predicate<ServerInfo>);
				}
				int n3 = list3.FindLastIndex(startIndex2, count, match3);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<ServerInfo>.FindLastIndex");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ForEach(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action<ServerInfo> action;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				action = (Action<ServerInfo>)ToLua.CheckObject(L, 2, typeof(Action<ServerInfo>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				action = (DelegateFactory.CreateDelegate(typeof(Action<ServerInfo>), func) as Action<ServerInfo>);
			}
			list.ForEach(action);
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
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			List<ServerInfo>.Enumerator enumerator = list.GetEnumerator();
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
	private static int GetRange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			int count = (int)LuaDLL.luaL_checknumber(L, 3);
			List<ServerInfo> range = list.GetRange(index, count);
			ToLua.PushObject(L, range);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IndexOf(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(ServerInfo)))
			{
				List<ServerInfo> list = (List<ServerInfo>)ToLua.ToObject(L, 1);
				ServerInfo item = (ServerInfo)ToLua.ToObject(L, 2);
				int n = list.IndexOf(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(ServerInfo), typeof(int)))
			{
				List<ServerInfo> list2 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				ServerInfo item2 = (ServerInfo)ToLua.ToObject(L, 2);
				int index = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = list2.IndexOf(item2, index);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(ServerInfo), typeof(int), typeof(int)))
			{
				List<ServerInfo> list3 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				ServerInfo item3 = (ServerInfo)ToLua.ToObject(L, 2);
				int index2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = list3.IndexOf(item3, index2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<ServerInfo>.IndexOf");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Insert(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			ServerInfo item = (ServerInfo)ToLua.CheckObject(L, 3, typeof(ServerInfo));
			list.Insert(index, item);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int InsertRange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			IEnumerable<ServerInfo> collection = (IEnumerable<ServerInfo>)ToLua.CheckObject(L, 3, typeof(IEnumerable<ServerInfo>));
			list.InsertRange(index, collection);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LastIndexOf(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(ServerInfo)))
			{
				List<ServerInfo> list = (List<ServerInfo>)ToLua.ToObject(L, 1);
				ServerInfo item = (ServerInfo)ToLua.ToObject(L, 2);
				int n = list.LastIndexOf(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(ServerInfo), typeof(int)))
			{
				List<ServerInfo> list2 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				ServerInfo item2 = (ServerInfo)ToLua.ToObject(L, 2);
				int index = (int)LuaDLL.lua_tonumber(L, 3);
				int n2 = list2.LastIndexOf(item2, index);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(ServerInfo), typeof(int), typeof(int)))
			{
				List<ServerInfo> list3 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				ServerInfo item3 = (ServerInfo)ToLua.ToObject(L, 2);
				int index2 = (int)LuaDLL.lua_tonumber(L, 3);
				int count = (int)LuaDLL.lua_tonumber(L, 4);
				int n3 = list3.LastIndexOf(item3, index2, count);
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<ServerInfo>.LastIndexOf");
			}
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
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			ServerInfo item = (ServerInfo)ToLua.CheckObject(L, 2, typeof(ServerInfo));
			bool value = list.Remove(item);
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
	private static int RemoveAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<ServerInfo> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<ServerInfo>)ToLua.CheckObject(L, 2, typeof(Predicate<ServerInfo>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<ServerInfo>), func) as Predicate<ServerInfo>);
			}
			int n = list.RemoveAll(match);
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
	private static int RemoveAt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			list.RemoveAt(index);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveRange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			int count = (int)LuaDLL.luaL_checknumber(L, 3);
			list.RemoveRange(index, count);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Reverse(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>)))
			{
				List<ServerInfo> list = (List<ServerInfo>)ToLua.ToObject(L, 1);
				list.Reverse();
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(int), typeof(int)))
			{
				List<ServerInfo> list2 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				list2.Reverse(index, count);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<ServerInfo>.Reverse");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Sort(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>)))
			{
				List<ServerInfo> list = (List<ServerInfo>)ToLua.ToObject(L, 1);
				list.Sort();
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(Comparison<ServerInfo>)))
			{
				List<ServerInfo> list2 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				Comparison<ServerInfo> comparison;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					comparison = (Comparison<ServerInfo>)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					comparison = (DelegateFactory.CreateDelegate(typeof(Comparison<ServerInfo>), func) as Comparison<ServerInfo>);
				}
				list2.Sort(comparison);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(IComparer<ServerInfo>)))
			{
				List<ServerInfo> list3 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				IComparer<ServerInfo> comparer = (IComparer<ServerInfo>)ToLua.ToObject(L, 2);
				list3.Sort(comparer);
				result = 0;
			}
			else if (num == 4 && TypeChecker.CheckTypes(L, 1, typeof(List<ServerInfo>), typeof(int), typeof(int), typeof(IComparer<ServerInfo>)))
			{
				List<ServerInfo> list4 = (List<ServerInfo>)ToLua.ToObject(L, 1);
				int index = (int)LuaDLL.lua_tonumber(L, 2);
				int count = (int)LuaDLL.lua_tonumber(L, 3);
				IComparer<ServerInfo> comparer2 = (IComparer<ServerInfo>)ToLua.ToObject(L, 4);
				list4.Sort(index, count, comparer2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: System.Collections.Generic.List<ServerInfo>.Sort");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ToArray(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			ServerInfo[] array = list.ToArray();
			ToLua.Push(L, array);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TrimExcess(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			list.TrimExcess();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TrueForAll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Predicate<ServerInfo> match;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				match = (Predicate<ServerInfo>)ToLua.CheckObject(L, 2, typeof(Predicate<ServerInfo>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				match = (DelegateFactory.CreateDelegate(typeof(Predicate<ServerInfo>), func) as Predicate<ServerInfo>);
			}
			bool value = list.TrueForAll(match);
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
	private static int get_Item(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			ServerInfo o = list[index];
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
			List<ServerInfo> list = (List<ServerInfo>)ToLua.CheckObject(L, 1, typeof(List<ServerInfo>));
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			ServerInfo value = (ServerInfo)ToLua.CheckObject(L, 3, typeof(ServerInfo));
			list[index] = value;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Capacity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			List<ServerInfo> list = (List<ServerInfo>)obj;
			int capacity = list.Capacity;
			LuaDLL.lua_pushinteger(L, capacity);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Capacity on a nil value");
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
			List<ServerInfo> list = (List<ServerInfo>)obj;
			int count = list.Count;
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
	private static int set_Capacity(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			List<ServerInfo> list = (List<ServerInfo>)obj;
			int capacity = (int)LuaDLL.luaL_checknumber(L, 2);
			list.Capacity = capacity;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Capacity on a nil value");
		}
		return result;
	}
}
