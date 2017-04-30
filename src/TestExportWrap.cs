using LuaInterface;
using System;
using UnityEngine;

public class TestExportWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TestExport), typeof(object), null);
		L.RegFunction(".geti", new LuaCSFunction(TestExportWrap.get_Item));
		L.RegFunction("get_Item", new LuaCSFunction(TestExportWrap.get_Item));
		L.RegFunction(".seti", new LuaCSFunction(TestExportWrap.set_Item));
		L.RegFunction("set_Item", new LuaCSFunction(TestExportWrap.set_Item));
		L.RegFunction("TestByteBuffer", new LuaCSFunction(TestExportWrap.TestByteBuffer));
		L.RegFunction("Test", new LuaCSFunction(TestExportWrap.Test));
		L.RegFunction("TestChar", new LuaCSFunction(TestExportWrap.TestChar));
		L.RegFunction("Test33", new LuaCSFunction(TestExportWrap.Test33));
		L.RegFunction("TestGeneric", new LuaCSFunction(TestExportWrap.TestGeneric));
		L.RegFunction("TestEnum", new LuaCSFunction(TestExportWrap.TestEnum));
		L.RegFunction("TestCheckParamNumber", new LuaCSFunction(TestExportWrap.TestCheckParamNumber));
		L.RegFunction("TestCheckParamString", new LuaCSFunction(TestExportWrap.TestCheckParamString));
		L.RegFunction("TestReflection", new LuaCSFunction(TestExportWrap.TestReflection));
		L.RegFunction("TestRefGameObject", new LuaCSFunction(TestExportWrap.TestRefGameObject));
		L.RegFunction("DoClick", new LuaCSFunction(TestExportWrap.DoClick));
		L.RegFunction("New", new LuaCSFunction(TestExportWrap._CreateTestExport));
		L.RegVar("this", new LuaCSFunction(TestExportWrap._this), null);
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("field", new LuaCSFunction(TestExportWrap.get_field), new LuaCSFunction(TestExportWrap.set_field));
		L.RegVar("OnClick", new LuaCSFunction(TestExportWrap.get_OnClick), new LuaCSFunction(TestExportWrap.set_OnClick));
		L.RegVar("OnRefEvent", new LuaCSFunction(TestExportWrap.get_OnRefEvent), new LuaCSFunction(TestExportWrap.set_OnRefEvent));
		L.RegVar("buffer", new LuaCSFunction(TestExportWrap.get_buffer), new LuaCSFunction(TestExportWrap.set_buffer));
		L.RegVar("Number", new LuaCSFunction(TestExportWrap.get_Number), new LuaCSFunction(TestExportWrap.set_Number));
		L.RegFunction("TestBuffer", new LuaCSFunction(TestExportWrap.TestExport_TestBuffer));
		L.RegFunction("TestRefEvent", new LuaCSFunction(TestExportWrap.TestExport_TestRefEvent));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int _CreateTestExport(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				TestExport o = new TestExport();
				ToLua.PushObject(L, o);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Vector3)))
			{
				Vector3 v = ToLua.ToVector3(L, 1);
				TestExport o2 = new TestExport(v);
				ToLua.PushObject(L, o2);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Vector3[])))
			{
				Vector3[] v2 = ToLua.CheckObjectArray<Vector3>(L, 1);
				TestExport o3 = new TestExport(v2);
				ToLua.PushObject(L, o3);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(Vector3), typeof(string)))
			{
				Vector3 v3 = ToLua.ToVector3(L, 1);
				string str = ToLua.CheckString(L, 2);
				TestExport o4 = new TestExport(v3, str);
				ToLua.PushObject(L, o4);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to ctor method: TestExport.New");
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
			TestExport testExport = (TestExport)ToLua.CheckObject(L, 1, typeof(TestExport));
			int pos = (int)LuaDLL.luaL_checknumber(L, 2);
			int n = testExport[pos];
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
	private static int _set_this(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			TestExport testExport = (TestExport)ToLua.CheckObject(L, 1, typeof(TestExport));
			int pos = (int)LuaDLL.luaL_checknumber(L, 2);
			int value = (int)LuaDLL.luaL_checknumber(L, 3);
			testExport[pos] = value;
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
			LuaDLL.tolua_bindthis(L, new LuaCSFunction(TestExportWrap._get_this), new LuaCSFunction(TestExportWrap._set_this));
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(double)))
			{
				double pos = LuaDLL.lua_tonumber(L, 1);
				int n = TestExport.get_Item(pos);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string pos2 = ToLua.ToString(L, 1);
				int n2 = TestExport.get_Item(pos2);
				LuaDLL.lua_pushinteger(L, n2);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(TestExport), typeof(int)))
			{
				TestExport testExport = (TestExport)ToLua.ToObject(L, 1);
				int pos3 = (int)LuaDLL.lua_tonumber(L, 2);
				int n3 = testExport[pos3];
				LuaDLL.lua_pushinteger(L, n3);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: TestExport.get_Item");
			}
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
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(double)))
			{
				double item = LuaDLL.lua_tonumber(L, 1);
				int n = TestExport.set_Item(item);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(TestExport), typeof(int), typeof(int)))
			{
				TestExport testExport = (TestExport)ToLua.ToObject(L, 1);
				int pos = (int)LuaDLL.lua_tonumber(L, 2);
				int value = (int)LuaDLL.lua_tonumber(L, 3);
				testExport[pos] = value;
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: TestExport.set_Item");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TestByteBuffer(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TestExport testExport = (TestExport)ToLua.CheckObject(L, 1, typeof(TestExport));
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			TestExport.TestBuffer tb;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				tb = (TestExport.TestBuffer)ToLua.CheckObject(L, 2, typeof(TestExport.TestBuffer));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				tb = (DelegateFactory.CreateDelegate(typeof(TestExport.TestBuffer), func) as TestExport.TestBuffer);
			}
			testExport.TestByteBuffer(tb);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Test(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(TestExport), typeof(string)))
			{
				TestExport testExport = (TestExport)ToLua.ToObject(L, 1);
				string str = ToLua.ToString(L, 2);
				int n = testExport.Test(str);
				LuaDLL.lua_pushinteger(L, n);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(TestExport), typeof(LuaOut<int>)))
			{
				TestExport testExport2 = (TestExport)ToLua.ToObject(L, 1);
				int n3;
				int n2 = testExport2.Test(out n3);
				LuaDLL.lua_pushinteger(L, n2);
				LuaDLL.lua_pushinteger(L, n3);
				result = 2;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(TestExport), typeof(TestExport.Space)))
			{
				TestExport testExport3 = (TestExport)ToLua.ToObject(L, 1);
				TestExport.Space e = (TestExport.Space)((int)ToLua.ToObject(L, 2));
				int n4 = testExport3.Test(e);
				LuaDLL.lua_pushinteger(L, n4);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(string)))
			{
				string str2 = ToLua.ToString(L, 1);
				string str3 = ToLua.ToString(L, 2);
				int n5 = TestExport.Test(str2, str3);
				LuaDLL.lua_pushinteger(L, n5);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(TestExport), typeof(int[,])))
			{
				TestExport testExport4 = (TestExport)ToLua.ToObject(L, 1);
				int[,] objs = (int[,])ToLua.ToObject(L, 2);
				int n6 = testExport4.Test(objs);
				LuaDLL.lua_pushinteger(L, n6);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(TestExport), typeof(bool)))
			{
				TestExport testExport5 = (TestExport)ToLua.ToObject(L, 1);
				bool b = LuaDLL.lua_toboolean(L, 2);
				int n7 = testExport5.Test(b);
				LuaDLL.lua_pushinteger(L, n7);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(TestExport), typeof(double)))
			{
				TestExport testExport6 = (TestExport)ToLua.ToObject(L, 1);
				double d = LuaDLL.lua_tonumber(L, 2);
				int n8 = testExport6.Test(d);
				LuaDLL.lua_pushinteger(L, n8);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(TestExport), typeof(object)))
			{
				TestExport testExport7 = (TestExport)ToLua.ToObject(L, 1);
				object o = ToLua.ToVarObject(L, 2);
				int n9 = testExport7.Test(o);
				LuaDLL.lua_pushinteger(L, n9);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(TestExport), typeof(int), typeof(int)))
			{
				TestExport testExport8 = (TestExport)ToLua.ToObject(L, 1);
				int i = (int)LuaDLL.lua_tonumber(L, 2);
				int j = (int)LuaDLL.lua_tonumber(L, 3);
				int n10 = testExport8.Test(i, j);
				LuaDLL.lua_pushinteger(L, n10);
				result = 1;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(TestExport), typeof(object), typeof(string)))
			{
				TestExport testExport9 = (TestExport)ToLua.ToObject(L, 1);
				object o2 = ToLua.ToVarObject(L, 2);
				string str4 = ToLua.ToString(L, 3);
				int n11 = testExport9.Test(o2, str4);
				LuaDLL.lua_pushinteger(L, n11);
				result = 1;
			}
			else if (TypeChecker.CheckParamsType(L, typeof(string), 2, num - 1))
			{
				TestExport testExport10 = (TestExport)ToLua.ToObject(L, 1);
				string[] objs2 = ToLua.ToParamsString(L, 2, num - 1);
				int n12 = testExport10.Test(objs2);
				LuaDLL.lua_pushinteger(L, n12);
				result = 1;
			}
			else if (TypeChecker.CheckParamsType(L, typeof(int), 2, num - 1))
			{
				TestExport testExport11 = (TestExport)ToLua.ToObject(L, 1);
				int[] objs3 = ToLua.ToParamsNumber<int>(L, 2, num - 1);
				int n13 = testExport11.Test(objs3);
				LuaDLL.lua_pushinteger(L, n13);
				result = 1;
			}
			else if (TypeChecker.CheckParamsType(L, typeof(object), 2, num - 1))
			{
				TestExport testExport12 = (TestExport)ToLua.ToObject(L, 1);
				object[] objs4 = ToLua.ToParamsObject(L, 2, num - 1);
				int n14 = testExport12.Test(objs4);
				LuaDLL.lua_pushinteger(L, n14);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: TestExport.Test");
			}
		}
		catch (Exception e2)
		{
			result = LuaDLL.toluaL_exception(L, e2, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TestChar(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TestExport testExport = (TestExport)ToLua.CheckObject(L, 1, typeof(TestExport));
			char c = (char)LuaDLL.luaL_checknumber(L, 2);
			int n = testExport.Test(c);
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
	private static int Test33(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TestExport testExport = (TestExport)ToLua.CheckObject(L, 1, typeof(TestExport));
			Action<int> ev = null;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				ev = (Action<int>)ToLua.CheckObject(L, 2, typeof(Action<int>));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				ev = (DelegateFactory.CreateDelegate(typeof(Action<int>), func) as Action<int>);
			}
			int n = testExport.Test33(ref ev);
			LuaDLL.lua_pushinteger(L, n);
			ToLua.Push(L, ev);
			result = 2;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TestGeneric(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TestExport testExport = (TestExport)ToLua.CheckObject(L, 1, typeof(TestExport));
			Component t = (Component)ToLua.CheckUnityObject(L, 2, typeof(Component));
			int n = testExport.TestGeneric<Component>(t);
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
	private static int TestEnum(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			TestExport testExport = (TestExport)ToLua.CheckObject(L, 1, typeof(TestExport));
			TestExport.Space e = (TestExport.Space)((int)ToLua.CheckObject(L, 2, typeof(TestExport.Space)));
			int n = testExport.TestEnum(e);
			LuaDLL.lua_pushinteger(L, n);
			result = 1;
		}
		catch (Exception e2)
		{
			result = LuaDLL.toluaL_exception(L, e2, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TestCheckParamNumber(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			TestExport testExport = (TestExport)ToLua.CheckObject(L, 1, typeof(TestExport));
			int[] ns = ToLua.CheckParamsNumber<int>(L, 2, num - 1);
			int n = testExport.TestCheckParamNumber(ns);
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
	private static int TestCheckParamString(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			TestExport testExport = (TestExport)ToLua.CheckObject(L, 1, typeof(TestExport));
			string[] ss = ToLua.CheckParamsString(L, 2, num - 1);
			string str = testExport.TestCheckParamString(ss);
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
	private static int TestReflection(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 0);
			TestExport.TestReflection();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TestRefGameObject(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameObject obj = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			TestExport.TestRefGameObject(ref obj);
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DoClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			TestExport testExport = (TestExport)ToLua.CheckObject(L, 1, typeof(TestExport));
			testExport.DoClick();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_field(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestExport testExport = (TestExport)obj;
			int field = testExport.field;
			LuaDLL.lua_pushinteger(L, field);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index field on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestExport testExport = (TestExport)obj;
			Action onClick = testExport.OnClick;
			ToLua.Push(L, onClick);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_OnRefEvent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestExport testExport = (TestExport)obj;
			TestExport.TestRefEvent onRefEvent = testExport.OnRefEvent;
			ToLua.Push(L, onRefEvent);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnRefEvent on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_buffer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestExport testExport = (TestExport)obj;
			byte[] buffer = testExport.buffer;
			LuaDLL.tolua_pushlstring(L, buffer, buffer.Length);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index buffer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Number(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestExport testExport = (TestExport)obj;
			int number = testExport.Number;
			LuaDLL.lua_pushinteger(L, number);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Number on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_field(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestExport testExport = (TestExport)obj;
			int field = (int)LuaDLL.luaL_checknumber(L, 2);
			testExport.field = field;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index field on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestExport testExport = (TestExport)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			Action onClick;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onClick = (Action)ToLua.CheckObject(L, 2, typeof(Action));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onClick = (DelegateFactory.CreateDelegate(typeof(Action), func) as Action);
			}
			testExport.OnClick = onClick;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_OnRefEvent(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestExport testExport = (TestExport)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			TestExport.TestRefEvent onRefEvent;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onRefEvent = (TestExport.TestRefEvent)ToLua.CheckObject(L, 2, typeof(TestExport.TestRefEvent));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onRefEvent = (DelegateFactory.CreateDelegate(typeof(TestExport.TestRefEvent), func) as TestExport.TestRefEvent);
			}
			testExport.OnRefEvent = onRefEvent;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index OnRefEvent on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_buffer(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestExport testExport = (TestExport)obj;
			byte[] buffer = ToLua.CheckByteBuffer(L, 2);
			testExport.buffer = buffer;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index buffer on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_Number(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestExport testExport = (TestExport)obj;
			int number = (int)LuaDLL.luaL_checknumber(L, 2);
			testExport.Number = number;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index Number on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TestExport_TestBuffer(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(TestExport.TestBuffer), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(TestExport.TestBuffer), func, self);
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
	private static int TestExport_TestRefEvent(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(TestExport.TestRefEvent), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(TestExport.TestRefEvent), func, self);
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
