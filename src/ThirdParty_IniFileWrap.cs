using LuaInterface;
using System;
using ThirdParty;

public class ThirdParty_IniFileWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(IniFile), typeof(object), null);
		L.RegFunction("Clear", new LuaCSFunction(ThirdParty_IniFileWrap.Clear));
		L.RegFunction("Read_From_String", new LuaCSFunction(ThirdParty_IniFileWrap.Read_From_String));
		L.RegFunction("Read_From_Resource", new LuaCSFunction(ThirdParty_IniFileWrap.Read_From_Resource));
		L.RegFunction("Read_From_File", new LuaCSFunction(ThirdParty_IniFileWrap.Read_From_File));
		L.RegFunction("goTo", new LuaCSFunction(ThirdParty_IniFileWrap.goTo));
		L.RegFunction("GetValue_String", new LuaCSFunction(ThirdParty_IniFileWrap.GetValue_String));
		L.RegFunction("GetValue_Int", new LuaCSFunction(ThirdParty_IniFileWrap.GetValue_Int));
		L.RegFunction("GetValue_Float", new LuaCSFunction(ThirdParty_IniFileWrap.GetValue_Float));
		L.RegFunction("IsContainsName", new LuaCSFunction(ThirdParty_IniFileWrap.IsContainsName));
		L.RegFunction("SetSelctor", new LuaCSFunction(ThirdParty_IniFileWrap.SetSelctor));
		L.RegFunction("SetString", new LuaCSFunction(ThirdParty_IniFileWrap.SetString));
		L.RegFunction("SetInt", new LuaCSFunction(ThirdParty_IniFileWrap.SetInt));
		L.RegFunction("SetFloat", new LuaCSFunction(ThirdParty_IniFileWrap.SetFloat));
		L.RegFunction("RemoveSelector", new LuaCSFunction(ThirdParty_IniFileWrap.RemoveSelector));
		L.RegFunction("ToString", new LuaCSFunction(ThirdParty_IniFileWrap.ToString));
		L.RegFunction("New", new LuaCSFunction(ThirdParty_IniFileWrap._CreateThirdParty_IniFile));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateThirdParty_IniFile(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1)
			{
				bool debug = LuaDLL.luaL_checkboolean(L, 1);
				IniFile o = new IniFile(debug);
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(bool)))
			{
				string fileString = ToLua.CheckString(L, 1);
				bool debug2 = LuaDLL.luaL_checkboolean(L, 2);
				IniFile o2 = new IniFile(fileString, debug2);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: ThirdParty.IniFile.New");
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
			IniFile iniFile = (IniFile)ToLua.CheckObject(L, 1, typeof(IniFile));
			iniFile.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Read_From_String(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			IniFile iniFile = (IniFile)ToLua.CheckObject(L, 1, typeof(IniFile));
			string data = ToLua.CheckString(L, 2);
			iniFile.Read_From_String(data);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Read_From_Resource(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			IniFile iniFile = (IniFile)ToLua.CheckObject(L, 1, typeof(IniFile));
			string fileName = ToLua.CheckString(L, 2);
			iniFile.Read_From_Resource(fileName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Read_From_File(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			IniFile iniFile = (IniFile)ToLua.CheckObject(L, 1, typeof(IniFile));
			string fileName = ToLua.CheckString(L, 2);
			iniFile.Read_From_File(fileName);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int goTo(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			IniFile iniFile = (IniFile)ToLua.CheckObject(L, 1, typeof(IniFile));
			string selctor = ToLua.CheckString(L, 2);
			bool value = iniFile.goTo(selctor);
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
	private static int GetValue_String(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			IniFile iniFile = (IniFile)ToLua.CheckObject(L, 1, typeof(IniFile));
			string name = ToLua.CheckString(L, 2);
			string defaultValue = ToLua.CheckString(L, 3);
			string value_String = iniFile.GetValue_String(name, defaultValue);
			LuaDLL.lua_pushstring(L, value_String);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetValue_Int(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			IniFile iniFile = (IniFile)ToLua.CheckObject(L, 1, typeof(IniFile));
			string name = ToLua.CheckString(L, 2);
			int defaultValue = (int)LuaDLL.luaL_checknumber(L, 3);
			int value_Int = iniFile.GetValue_Int(name, defaultValue);
			LuaDLL.lua_pushinteger(L, value_Int);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetValue_Float(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			IniFile iniFile = (IniFile)ToLua.CheckObject(L, 1, typeof(IniFile));
			string name = ToLua.CheckString(L, 2);
			float defaultValue = (float)LuaDLL.luaL_checknumber(L, 3);
			float value_Float = iniFile.GetValue_Float(name, defaultValue);
			LuaDLL.lua_pushnumber(L, (double)value_Float);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsContainsName(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			IniFile iniFile = (IniFile)ToLua.CheckObject(L, 1, typeof(IniFile));
			string name = ToLua.CheckString(L, 2);
			bool value = iniFile.IsContainsName(name);
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
	private static int SetSelctor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			IniFile iniFile = (IniFile)ToLua.CheckObject(L, 1, typeof(IniFile));
			string selctor = ToLua.CheckString(L, 2);
			iniFile.SetSelctor(selctor);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			IniFile iniFile = (IniFile)ToLua.CheckObject(L, 1, typeof(IniFile));
			string name = ToLua.CheckString(L, 2);
			string value = ToLua.CheckString(L, 3);
			iniFile.SetString(name, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetInt(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			IniFile iniFile = (IniFile)ToLua.CheckObject(L, 1, typeof(IniFile));
			string name = ToLua.CheckString(L, 2);
			int value = (int)LuaDLL.luaL_checknumber(L, 3);
			iniFile.SetInt(name, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetFloat(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			IniFile iniFile = (IniFile)ToLua.CheckObject(L, 1, typeof(IniFile));
			string name = ToLua.CheckString(L, 2);
			float value = (float)LuaDLL.luaL_checknumber(L, 3);
			iniFile.SetFloat(name, value);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveSelector(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			IniFile iniFile = (IniFile)ToLua.CheckObject(L, 1, typeof(IniFile));
			string name = ToLua.CheckString(L, 2);
			iniFile.RemoveSelector(name);
			result = 0;
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
			IniFile iniFile = (IniFile)ToLua.CheckObject(L, 1, typeof(IniFile));
			string str = iniFile.ToString();
			LuaDLL.lua_pushstring(L, str);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
