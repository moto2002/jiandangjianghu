using LuaInterface;
using System;
using UnityEngine;

public class MessageBoxWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(MessageBox), typeof(MonoBehaviour), null);
		L.RegFunction("DisplayMessageBox", new LuaCSFunction(MessageBoxWrap.DisplayMessageBox));
		L.RegFunction("__eq", new LuaCSFunction(MessageBoxWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("okBtn", new LuaCSFunction(MessageBoxWrap.get_okBtn), new LuaCSFunction(MessageBoxWrap.set_okBtn));
		L.RegVar("cancelBtn", new LuaCSFunction(MessageBoxWrap.get_cancelBtn), new LuaCSFunction(MessageBoxWrap.set_cancelBtn));
		L.RegVar("centerBtn", new LuaCSFunction(MessageBoxWrap.get_centerBtn), new LuaCSFunction(MessageBoxWrap.set_centerBtn));
		L.RegVar("message", new LuaCSFunction(MessageBoxWrap.get_message), new LuaCSFunction(MessageBoxWrap.set_message));
		L.RegFunction("onButtonClicked", new LuaCSFunction(MessageBoxWrap.MessageBox_onButtonClicked));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int DisplayMessageBox(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			string text = ToLua.CheckString(L, 1);
			int style = (int)LuaDLL.luaL_checknumber(L, 2);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 3);
			MessageBox.onButtonClicked okFunc;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				okFunc = (MessageBox.onButtonClicked)ToLua.CheckObject(L, 3, typeof(MessageBox.onButtonClicked));
			}
			else
			{
				LuaFunction func = ToLua.ToLuaFunction(L, 3);
				okFunc = (DelegateFactory.CreateDelegate(typeof(MessageBox.onButtonClicked), func) as MessageBox.onButtonClicked);
			}
			LuaTypes luaTypes2 = LuaDLL.lua_type(L, 4);
			MessageBox.onButtonClicked cancelFunc;
			if (luaTypes2 != LuaTypes.LUA_TFUNCTION)
			{
				cancelFunc = (MessageBox.onButtonClicked)ToLua.CheckObject(L, 4, typeof(MessageBox.onButtonClicked));
			}
			else
			{
				LuaFunction func2 = ToLua.ToLuaFunction(L, 4);
				cancelFunc = (DelegateFactory.CreateDelegate(typeof(MessageBox.onButtonClicked), func2) as MessageBox.onButtonClicked);
			}
			GameObject obj = MessageBox.DisplayMessageBox(text, style, okFunc, cancelFunc);
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
	private static int get_okBtn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MessageBox messageBox = (MessageBox)obj;
			UISprite okBtn = messageBox.okBtn;
			ToLua.Push(L, okBtn);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index okBtn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_cancelBtn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MessageBox messageBox = (MessageBox)obj;
			UISprite cancelBtn = messageBox.cancelBtn;
			ToLua.Push(L, cancelBtn);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cancelBtn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_centerBtn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MessageBox messageBox = (MessageBox)obj;
			UISprite centerBtn = messageBox.centerBtn;
			ToLua.Push(L, centerBtn);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index centerBtn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_message(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MessageBox messageBox = (MessageBox)obj;
			UILabel message = messageBox.message;
			ToLua.Push(L, message);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index message on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_okBtn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MessageBox messageBox = (MessageBox)obj;
			UISprite okBtn = (UISprite)ToLua.CheckUnityObject(L, 2, typeof(UISprite));
			messageBox.okBtn = okBtn;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index okBtn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_cancelBtn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MessageBox messageBox = (MessageBox)obj;
			UISprite cancelBtn = (UISprite)ToLua.CheckUnityObject(L, 2, typeof(UISprite));
			messageBox.cancelBtn = cancelBtn;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index cancelBtn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_centerBtn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MessageBox messageBox = (MessageBox)obj;
			UISprite centerBtn = (UISprite)ToLua.CheckUnityObject(L, 2, typeof(UISprite));
			messageBox.centerBtn = centerBtn;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index centerBtn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_message(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			MessageBox messageBox = (MessageBox)obj;
			UILabel message = (UILabel)ToLua.CheckUnityObject(L, 2, typeof(UILabel));
			messageBox.message = message;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index message on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int MessageBox_onButtonClicked(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(MessageBox.onButtonClicked), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(MessageBox.onButtonClicked), func, self);
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
