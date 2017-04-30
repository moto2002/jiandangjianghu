using LuaInterface;
using System;
using ThirdParty;

public class ThirdParty_MD5Wrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("MD5");
		L.RegFunction("ComputeHashString", new LuaCSFunction(ThirdParty_MD5Wrap.ComputeHashString));
		L.RegFunction("ComputeHash", new LuaCSFunction(ThirdParty_MD5Wrap.ComputeHash));
		L.RegFunction("ComputeString", new LuaCSFunction(ThirdParty_MD5Wrap.ComputeString));
		L.RegFunction("ToString", new LuaCSFunction(ThirdParty_MD5Wrap.ToString));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ComputeHashString(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string filename = ToLua.ToString(L, 1);
				string str = MD5.ComputeHashString(filename);
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(byte[])))
			{
				byte[] data = ToLua.CheckByteBuffer(L, 1);
				string str2 = MD5.ComputeHashString(data);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: ThirdParty.MD5.ComputeHashString");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ComputeHash(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string filename = ToLua.ToString(L, 1);
				byte[] array = MD5.ComputeHash(filename);
				ToLua.Push(L, array);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(byte[])))
			{
				byte[] data = ToLua.CheckByteBuffer(L, 1);
				byte[] array2 = MD5.ComputeHash(data);
				ToLua.Push(L, array2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: ThirdParty.MD5.ComputeHash");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ComputeString(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string sDataIn = ToLua.CheckString(L, 1);
			string str = MD5.ComputeString(sDataIn);
			LuaDLL.lua_pushstring(L, str);
			result = 1;
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
			byte[] data = ToLua.CheckByteBuffer(L, 1);
			string str = MD5.ToString(data);
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
