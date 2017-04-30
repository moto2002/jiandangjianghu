using LuaInterface;
using System;
using UnityEngine;

public class TestEventListenerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(TestEventListener), typeof(MonoBehaviour), null);
		L.RegFunction("SetOnFinished", new LuaCSFunction(TestEventListenerWrap.SetOnFinished));
		L.RegFunction("__eq", new LuaCSFunction(TestEventListenerWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(TestEventListenerWrap.Lua_ToString));
		L.RegVar("onClick", new LuaCSFunction(TestEventListenerWrap.get_onClick), new LuaCSFunction(TestEventListenerWrap.set_onClick));
		L.RegVar("onClickEvent", new LuaCSFunction(TestEventListenerWrap.get_onClickEvent), new LuaCSFunction(TestEventListenerWrap.set_onClickEvent));
		L.RegFunction("OnClick", new LuaCSFunction(TestEventListenerWrap.TestEventListener_OnClick));
		L.RegFunction("VoidDelegate", new LuaCSFunction(TestEventListenerWrap.TestEventListener_VoidDelegate));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SetOnFinished(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(TestEventListener), typeof(TestEventListener.VoidDelegate)))
			{
				TestEventListener testEventListener = (TestEventListener)ToLua.ToObject(L, 1);
				LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
				TestEventListener.VoidDelegate onFinished;
				if (luaTypes != LuaTypes.LUA_TFUNCTION)
				{
					onFinished = (TestEventListener.VoidDelegate)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func = ToLua.ToLuaFunction(L, 2);
					onFinished = (DelegateFactory.CreateDelegate(typeof(TestEventListener.VoidDelegate), func) as TestEventListener.VoidDelegate);
				}
				testEventListener.SetOnFinished(onFinished);
				result = 0;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(TestEventListener), typeof(TestEventListener.OnClick)))
			{
				TestEventListener testEventListener2 = (TestEventListener)ToLua.ToObject(L, 1);
				LuaTypes luaTypes2 = LuaDLL.lua_type(L, 2);
				TestEventListener.OnClick onFinished2;
				if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
				{
					onFinished2 = (TestEventListener.OnClick)ToLua.ToObject(L, 2);
				}
				else
				{
					LuaFunction func2 = ToLua.ToLuaFunction(L, 2);
					onFinished2 = (DelegateFactory.CreateDelegate(typeof(TestEventListener.OnClick), func2) as TestEventListener.OnClick);
				}
				testEventListener2.SetOnFinished(onFinished2);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: TestEventListener.SetOnFinished");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int op_Equality(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object x = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object y = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool value = x == y;
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
	private static int get_onClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestEventListener testEventListener = (TestEventListener)obj;
			TestEventListener.OnClick onClick = testEventListener.onClick;
			ToLua.Push(L, onClick);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onClickEvent(IntPtr L)
	{
		ToLua.Push(L, new EventObject("TestEventListener.onClickEvent"));
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onClick(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			TestEventListener testEventListener = (TestEventListener)obj;
			LuaTypes luaTypes = LuaDLL.lua_type(L, 2);
			TestEventListener.OnClick onClick;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				onClick = (TestEventListener.OnClick)ToLua.CheckObject(L, 2, typeof(TestEventListener.OnClick));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 2);
				onClick = (DelegateFactory.CreateDelegate(typeof(TestEventListener.OnClick), func) as TestEventListener.OnClick);
			}
			testEventListener.onClick = onClick;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onClick on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onClickEvent(IntPtr L)
	{
		int result;
		try
		{
			TestEventListener testEventListener = (TestEventListener)ToLua.CheckObject(L, 1, typeof(TestEventListener));
			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				EventObject eventObject = (EventObject)ToLua.ToObject(L, 2);
				if (eventObject.op == EventOp.Add)
				{
					TestEventListener.OnClick value = (TestEventListener.OnClick)DelegateFactory.CreateDelegate(typeof(TestEventListener.OnClick), eventObject.func);
					testEventListener.onClickEvent += value;
				}
				else if (eventObject.op == EventOp.Sub)
				{
					TestEventListener.OnClick onClick = (TestEventListener.OnClick)LuaMisc.GetEventHandler(testEventListener, typeof(TestEventListener), "onClickEvent");
					Delegate[] invocationList = onClick.GetInvocationList();
					LuaState luaState = LuaState.Get(L);
					for (int i = 0; i < invocationList.Length; i++)
					{
						onClick = (TestEventListener.OnClick)invocationList[i];
						LuaDelegate luaDelegate = onClick.Target as LuaDelegate;
						if (luaDelegate != null && luaDelegate.func == eventObject.func)
						{
							testEventListener.onClickEvent -= onClick;
							luaState.DelayDispose(luaDelegate.func);
							break;
						}
					}
					eventObject.func.Dispose();
				}
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "The event 'TestEventListener.onClickEvent' can only appear on the left hand side of += or -= when used outside of the type 'TestEventListener'");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TestEventListener_OnClick(IntPtr L)
	{
		int result;
		try
		{
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			Delegate ev = DelegateFactory.CreateDelegate(typeof(TestEventListener.OnClick), func);
			ToLua.Push(L, ev);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TestEventListener_VoidDelegate(IntPtr L)
	{
		int result;
		try
		{
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			Delegate ev = DelegateFactory.CreateDelegate(typeof(TestEventListener.VoidDelegate), func);
			ToLua.Push(L, ev);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
