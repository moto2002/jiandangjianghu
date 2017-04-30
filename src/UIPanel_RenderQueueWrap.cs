using LuaInterface;
using System;

public class UIPanel_RenderQueueWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(UIPanel.RenderQueue));
		L.RegVar("Automatic", new LuaCSFunction(UIPanel_RenderQueueWrap.get_Automatic), null);
		L.RegVar("StartAt", new LuaCSFunction(UIPanel_RenderQueueWrap.get_StartAt), null);
		L.RegVar("Explicit", new LuaCSFunction(UIPanel_RenderQueueWrap.get_Explicit), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(UIPanel_RenderQueueWrap.IntToEnum));
		L.EndEnum();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Automatic(IntPtr L)
	{
		ToLua.Push(L, UIPanel.RenderQueue.Automatic);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_StartAt(IntPtr L)
	{
		ToLua.Push(L, UIPanel.RenderQueue.StartAt);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_Explicit(IntPtr L)
	{
		ToLua.Push(L, UIPanel.RenderQueue.Explicit);
		return 1;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IntToEnum(IntPtr L)
	{
		int num = (int)LuaDLL.lua_tonumber(L, 1);
		UIPanel.RenderQueue renderQueue = (UIPanel.RenderQueue)num;
		ToLua.Push(L, renderQueue);
		return 1;
	}
}
