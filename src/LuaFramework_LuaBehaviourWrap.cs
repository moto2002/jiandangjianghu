using LuaFramework;
using LuaInterface;
using System;
using UnityEngine;

public class LuaFramework_LuaBehaviourWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaBehaviour), typeof(Base), null);
		L.RegFunction("OnInit", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.OnInit));
		L.RegFunction("OnClose", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.OnClose));
		L.RegFunction("OnChangeSceneHide", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.OnChangeSceneHide));
		L.RegFunction("AddSubmit", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddSubmit));
		L.RegFunction("AddValueChange", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddValueChange));
		L.RegFunction("RemoveSubmit", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.RemoveSubmit));
		L.RegFunction("RemoveValueChange", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.RemoveValueChange));
		L.RegFunction("AddWidgetContainerChangeEvent", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddWidgetContainerChangeEvent));
		L.RegFunction("AddPopupListChange", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddPopupListChange));
		L.RegFunction("AddProgressBarChange", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddProgressBarChange));
		L.RegFunction("AddToggleChange", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddToggleChange));
		L.RegFunction("RemoveWidgetContainerEvent", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.RemoveWidgetContainerEvent));
		L.RegFunction("AddClick", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddClick));
		L.RegFunction("AddDoubleClick", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddDoubleClick));
		L.RegFunction("AddHovor", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddHovor));
		L.RegFunction("AddPress", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddPress));
		L.RegFunction("AddSelect", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddSelect));
		L.RegFunction("AddScroll", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddScroll));
		L.RegFunction("AddDragStart", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddDragStart));
		L.RegFunction("AddDrag", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddDrag));
		L.RegFunction("AddDragOver", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddDragOver));
		L.RegFunction("AddDragOut", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddDragOut));
		L.RegFunction("AddDragEnd", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddDragEnd));
		L.RegFunction("AddDrop", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddDrop));
		L.RegFunction("AddKey", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddKey));
		L.RegFunction("AddTooltip", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddTooltip));
		L.RegFunction("RemoveClick", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.RemoveClick));
		L.RegFunction("RemoveHovor", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.RemoveHovor));
		L.RegFunction("RemoveUIEvent", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.RemoveUIEvent));
		L.RegFunction("AddUIPlayTweenEvent", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddUIPlayTweenEvent));
		L.RegFunction("RemoveUIPlayTweenEvent", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.RemoveUIPlayTweenEvent));
		L.RegFunction("ClearUIEvent", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.ClearUIEvent));
		L.RegFunction("ExtendEventDeal", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.ExtendEventDeal));
		L.RegFunction("AddExtendEvent", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.AddExtendEvent));
		L.RegFunction("RemoveExtendEvent", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.RemoveExtendEvent));
		L.RegFunction("__eq", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegFunction("UiExtendEventDeal", new LuaCSFunction(LuaFramework_LuaBehaviourWrap.LuaFramework_LuaBehaviour_UiExtendEventDeal));
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnInit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			luaBehaviour.OnInit();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnClose(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			luaBehaviour.OnClose();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int OnChangeSceneHide(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			luaBehaviour.OnChangeSceneHide();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddSubmit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddSubmit(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddValueChange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddValueChange(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveSubmit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			luaBehaviour.RemoveSubmit(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveValueChange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			luaBehaviour.RemoveValueChange(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddWidgetContainerChangeEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			UIWidgetContainer container = (UIWidgetContainer)ToLua.CheckUnityObject(L, 2, typeof(UIWidgetContainer));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddWidgetContainerChangeEvent(container, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddPopupListChange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddPopupListChange(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddProgressBarChange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddProgressBarChange(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddToggleChange(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddToggleChange(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveWidgetContainerEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			luaBehaviour.RemoveWidgetContainerEvent(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddClick(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddDoubleClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddDoubleClick(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddHovor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddHovor(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddPress(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddPress(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddSelect(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddSelect(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddScroll(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddScroll(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddDragStart(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddDragStart(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddDrag(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddDrag(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddDragOver(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddDragOver(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddDragOut(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddDragOut(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddDragEnd(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddDragEnd(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddDrop(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddDrop(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddKey(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddKey(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddTooltip(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddTooltip(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveClick(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			luaBehaviour.RemoveClick(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveHovor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			luaBehaviour.RemoveHovor(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveUIEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			string eventType = ToLua.CheckString(L, 3);
			luaBehaviour.RemoveUIEvent(go, eventType);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddUIPlayTweenEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			LuaFunction luafunc = ToLua.CheckLuaFunction(L, 3);
			luaBehaviour.AddUIPlayTweenEvent(go, luafunc);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveUIPlayTweenEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 2, typeof(GameObject));
			luaBehaviour.RemoveUIPlayTweenEvent(go);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ClearUIEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaBehaviour luaBehaviour = (LuaBehaviour)ToLua.CheckObject(L, 1, typeof(LuaBehaviour));
			luaBehaviour.ClearUIEvent();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ExtendEventDeal(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameObject go = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			string type = ToLua.CheckString(L, 2);
			LuaBehaviour.ExtendEventDeal(go, type);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddExtendEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			LuaBehaviour.UiExtendEventDeal func;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				func = (LuaBehaviour.UiExtendEventDeal)ToLua.CheckObject(L, 1, typeof(LuaBehaviour.UiExtendEventDeal));
			}
			else
			{
				LuaFunction func2 = ToLua.ToLuaFunction(L, 1);
				func = (DelegateFactory.CreateDelegate(typeof(LuaBehaviour.UiExtendEventDeal), func2) as LuaBehaviour.UiExtendEventDeal);
			}
			LuaBehaviour.AddExtendEvent(func);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveExtendEvent(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaTypes luaTypes = LuaDLL.lua_type(L, 1);
			LuaBehaviour.UiExtendEventDeal func;
			if (luaTypes != LuaTypes.LUA_TFUNCTION)
			{
				func = (LuaBehaviour.UiExtendEventDeal)ToLua.CheckObject(L, 1, typeof(LuaBehaviour.UiExtendEventDeal));
			}
			else
			{
				LuaFunction func2 = ToLua.ToLuaFunction(L, 1);
				func = (DelegateFactory.CreateDelegate(typeof(LuaBehaviour.UiExtendEventDeal), func2) as LuaBehaviour.UiExtendEventDeal);
			}
			LuaBehaviour.RemoveExtendEvent(func);
			result = 0;
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
	private static int LuaFramework_LuaBehaviour_UiExtendEventDeal(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(LuaBehaviour.UiExtendEventDeal), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(LuaBehaviour.UiExtendEventDeal), func, self);
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
