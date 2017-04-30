using LuaInterface;
using System;

public class TestAccountWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TestAccount), typeof(object), null);
		L.RegFunction("New", new LuaCSFunction(TestAccountWrap._CreateTestAccount));
		L.RegFunction("__tostring", new LuaCSFunction(TestAccountWrap.Lua_ToString));
		L.RegVar("id", new LuaCSFunction(TestAccountWrap.get_id), new LuaCSFunction(TestAccountWrap.set_id));
		L.RegVar("name", new LuaCSFunction(TestAccountWrap.get_name), new LuaCSFunction(TestAccountWrap.set_name));
		L.RegVar("sex", new LuaCSFunction(TestAccountWrap.get_sex), new LuaCSFunction(TestAccountWrap.set_sex));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateTestAccount(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 3)
			{
				int id = (int)LuaDLL.luaL_checknumber(L, 1);
				string name = ToLua.CheckString(L, 2);
				int sex = (int)LuaDLL.luaL_checknumber(L, 3);
				TestAccount o = new TestAccount(id, name, sex);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: TestAccount.New");
			}
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
	private static int get_id(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestAccount testAccount = (TestAccount)obj;
			int id = testAccount.id;
			LuaDLL.lua_pushinteger(L, id);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index id on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_name(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestAccount testAccount = (TestAccount)obj;
			string name = testAccount.name;
			LuaDLL.lua_pushstring(L, name);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index name on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_sex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestAccount testAccount = (TestAccount)obj;
			int sex = testAccount.sex;
			LuaDLL.lua_pushinteger(L, sex);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sex on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_id(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestAccount testAccount = (TestAccount)obj;
			int id = (int)LuaDLL.luaL_checknumber(L, 2);
			testAccount.id = id;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index id on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_name(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestAccount testAccount = (TestAccount)obj;
			string name = ToLua.CheckString(L, 2);
			testAccount.name = name;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index name on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_sex(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestAccount testAccount = (TestAccount)obj;
			int sex = (int)LuaDLL.luaL_checknumber(L, 2);
			testAccount.sex = sex;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index sex on a nil value");
		}
		return result;
	}
}
