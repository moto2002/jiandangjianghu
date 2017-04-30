using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UIPopupListWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UIPopupList), typeof(UIWidgetContainer), null);
		L.RegFunction("Clear", new LuaCSFunction(UIPopupListWrap.Clear));
		L.RegFunction("AddItem", new LuaCSFunction(UIPopupListWrap.AddItem));
		L.RegFunction("RemoveItem", new LuaCSFunction(UIPopupListWrap.RemoveItem));
		L.RegFunction("RemoveItemByData", new LuaCSFunction(UIPopupListWrap.RemoveItemByData));
		L.RegFunction("Close", new LuaCSFunction(UIPopupListWrap.Close));
		L.RegFunction("Show", new LuaCSFunction(UIPopupListWrap.Show));
		L.RegFunction("__eq", new LuaCSFunction(UIPopupListWrap.op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("current", new LuaCSFunction(UIPopupListWrap.get_current), new LuaCSFunction(UIPopupListWrap.set_current));
		L.RegVar("atlas", new LuaCSFunction(UIPopupListWrap.get_atlas), new LuaCSFunction(UIPopupListWrap.set_atlas));
		L.RegVar("bitmapFont", new LuaCSFunction(UIPopupListWrap.get_bitmapFont), new LuaCSFunction(UIPopupListWrap.set_bitmapFont));
		L.RegVar("trueTypeFont", new LuaCSFunction(UIPopupListWrap.get_trueTypeFont), new LuaCSFunction(UIPopupListWrap.set_trueTypeFont));
		L.RegVar("fontSize", new LuaCSFunction(UIPopupListWrap.get_fontSize), new LuaCSFunction(UIPopupListWrap.set_fontSize));
		L.RegVar("fontStyle", new LuaCSFunction(UIPopupListWrap.get_fontStyle), new LuaCSFunction(UIPopupListWrap.set_fontStyle));
		L.RegVar("backgroundSprite", new LuaCSFunction(UIPopupListWrap.get_backgroundSprite), new LuaCSFunction(UIPopupListWrap.set_backgroundSprite));
		L.RegVar("highlightSprite", new LuaCSFunction(UIPopupListWrap.get_highlightSprite), new LuaCSFunction(UIPopupListWrap.set_highlightSprite));
		L.RegVar("position", new LuaCSFunction(UIPopupListWrap.get_position), new LuaCSFunction(UIPopupListWrap.set_position));
		L.RegVar("alignment", new LuaCSFunction(UIPopupListWrap.get_alignment), new LuaCSFunction(UIPopupListWrap.set_alignment));
		L.RegVar("items", new LuaCSFunction(UIPopupListWrap.get_items), new LuaCSFunction(UIPopupListWrap.set_items));
		L.RegVar("itemData", new LuaCSFunction(UIPopupListWrap.get_itemData), new LuaCSFunction(UIPopupListWrap.set_itemData));
		L.RegVar("padding", new LuaCSFunction(UIPopupListWrap.get_padding), new LuaCSFunction(UIPopupListWrap.set_padding));
		L.RegVar("textColor", new LuaCSFunction(UIPopupListWrap.get_textColor), new LuaCSFunction(UIPopupListWrap.set_textColor));
		L.RegVar("backgroundColor", new LuaCSFunction(UIPopupListWrap.get_backgroundColor), new LuaCSFunction(UIPopupListWrap.set_backgroundColor));
		L.RegVar("highlightColor", new LuaCSFunction(UIPopupListWrap.get_highlightColor), new LuaCSFunction(UIPopupListWrap.set_highlightColor));
		L.RegVar("isAnimated", new LuaCSFunction(UIPopupListWrap.get_isAnimated), new LuaCSFunction(UIPopupListWrap.set_isAnimated));
		L.RegVar("isLocalized", new LuaCSFunction(UIPopupListWrap.get_isLocalized), new LuaCSFunction(UIPopupListWrap.set_isLocalized));
		L.RegVar("openOn", new LuaCSFunction(UIPopupListWrap.get_openOn), new LuaCSFunction(UIPopupListWrap.set_openOn));
		L.RegVar("onChange", new LuaCSFunction(UIPopupListWrap.get_onChange), new LuaCSFunction(UIPopupListWrap.set_onChange));
		L.RegVar("ambigiousFont", new LuaCSFunction(UIPopupListWrap.get_ambigiousFont), new LuaCSFunction(UIPopupListWrap.set_ambigiousFont));
		L.RegVar("isOpen", new LuaCSFunction(UIPopupListWrap.get_isOpen), null);
		L.RegVar("value", new LuaCSFunction(UIPopupListWrap.get_value), new LuaCSFunction(UIPopupListWrap.set_value));
		L.RegVar("data", new LuaCSFunction(UIPopupListWrap.get_data), null);
		L.EndClass();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Clear(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIPopupList uIPopupList = (UIPopupList)ToLua.CheckObject(L, 1, typeof(UIPopupList));
			uIPopupList.Clear();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int AddItem(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(UIPopupList), typeof(string)))
			{
				UIPopupList uIPopupList = (UIPopupList)ToLua.ToObject(L, 1);
				string text = ToLua.ToString(L, 2);
				uIPopupList.AddItem(text);
				result = 0;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(UIPopupList), typeof(string), typeof(object)))
			{
				UIPopupList uIPopupList2 = (UIPopupList)ToLua.ToObject(L, 1);
				string text2 = ToLua.ToString(L, 2);
				object data = ToLua.ToVarObject(L, 3);
				uIPopupList2.AddItem(text2, data);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: UIPopupList.AddItem");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveItem(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIPopupList uIPopupList = (UIPopupList)ToLua.CheckObject(L, 1, typeof(UIPopupList));
			string text = ToLua.CheckString(L, 2);
			uIPopupList.RemoveItem(text);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int RemoveItemByData(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UIPopupList uIPopupList = (UIPopupList)ToLua.CheckObject(L, 1, typeof(UIPopupList));
			object data = ToLua.ToVarObject(L, 2);
			uIPopupList.RemoveItemByData(data);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Close(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIPopupList uIPopupList = (UIPopupList)ToLua.CheckObject(L, 1, typeof(UIPopupList));
			uIPopupList.Close();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Show(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UIPopupList uIPopupList = (UIPopupList)ToLua.CheckObject(L, 1, typeof(UIPopupList));
			uIPopupList.Show();
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
	private static int get_current(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, UIPopupList.current);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_atlas(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			UIAtlas atlas = uIPopupList.atlas;
			ToLua.Push(L, atlas);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index atlas on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bitmapFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			UIFont bitmapFont = uIPopupList.bitmapFont;
			ToLua.Push(L, bitmapFont);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bitmapFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_trueTypeFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			Font trueTypeFont = uIPopupList.trueTypeFont;
			ToLua.Push(L, trueTypeFont);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index trueTypeFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fontSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			int fontSize = uIPopupList.fontSize;
			LuaDLL.lua_pushinteger(L, fontSize);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fontSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fontStyle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			FontStyle fontStyle = uIPopupList.fontStyle;
			ToLua.Push(L, fontStyle);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fontStyle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_backgroundSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			string backgroundSprite = uIPopupList.backgroundSprite;
			LuaDLL.lua_pushstring(L, backgroundSprite);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index backgroundSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_highlightSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			string highlightSprite = uIPopupList.highlightSprite;
			LuaDLL.lua_pushstring(L, highlightSprite);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index highlightSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_position(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			UIPopupList.Position position = uIPopupList.position;
			ToLua.Push(L, position);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index position on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_alignment(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			NGUIText.Alignment alignment = uIPopupList.alignment;
			ToLua.Push(L, alignment);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alignment on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_items(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			List<string> items = uIPopupList.items;
			ToLua.PushObject(L, items);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index items on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_itemData(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			List<object> itemData = uIPopupList.itemData;
			ToLua.PushObject(L, itemData);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index itemData on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_padding(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			Vector2 padding = uIPopupList.padding;
			ToLua.Push(L, padding);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index padding on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_textColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			Color textColor = uIPopupList.textColor;
			ToLua.Push(L, textColor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index textColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_backgroundColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			Color backgroundColor = uIPopupList.backgroundColor;
			ToLua.Push(L, backgroundColor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index backgroundColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_highlightColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			Color highlightColor = uIPopupList.highlightColor;
			ToLua.Push(L, highlightColor);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index highlightColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isAnimated(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			bool isAnimated = uIPopupList.isAnimated;
			LuaDLL.lua_pushboolean(L, isAnimated);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isAnimated on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isLocalized(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			bool isLocalized = uIPopupList.isLocalized;
			LuaDLL.lua_pushboolean(L, isLocalized);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isLocalized on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_openOn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			UIPopupList.OpenOn openOn = uIPopupList.openOn;
			ToLua.Push(L, openOn);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index openOn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_onChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			List<EventDelegate> onChange = uIPopupList.onChange;
			ToLua.PushObject(L, onChange);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_ambigiousFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			UnityEngine.Object ambigiousFont = uIPopupList.ambigiousFont;
			ToLua.Push(L, ambigiousFont);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ambigiousFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_isOpen(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			bool isOpen = uIPopupList.isOpen;
			LuaDLL.lua_pushboolean(L, isOpen);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isOpen on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_value(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			string value = uIPopupList.value;
			LuaDLL.lua_pushstring(L, value);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_data(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			object data = uIPopupList.data;
			ToLua.Push(L, data);
			result = 1;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index data on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_current(IntPtr L)
	{
		int result;
		try
		{
			UIPopupList current = (UIPopupList)ToLua.CheckUnityObject(L, 2, typeof(UIPopupList));
			UIPopupList.current = current;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_atlas(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			UIAtlas atlas = (UIAtlas)ToLua.CheckUnityObject(L, 2, typeof(UIAtlas));
			uIPopupList.atlas = atlas;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index atlas on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bitmapFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			UIFont bitmapFont = (UIFont)ToLua.CheckUnityObject(L, 2, typeof(UIFont));
			uIPopupList.bitmapFont = bitmapFont;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index bitmapFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_trueTypeFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			Font trueTypeFont = (Font)ToLua.CheckUnityObject(L, 2, typeof(Font));
			uIPopupList.trueTypeFont = trueTypeFont;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index trueTypeFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fontSize(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			int fontSize = (int)LuaDLL.luaL_checknumber(L, 2);
			uIPopupList.fontSize = fontSize;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fontSize on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fontStyle(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			FontStyle fontStyle = (FontStyle)((int)ToLua.CheckObject(L, 2, typeof(FontStyle)));
			uIPopupList.fontStyle = fontStyle;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index fontStyle on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_backgroundSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			string backgroundSprite = ToLua.CheckString(L, 2);
			uIPopupList.backgroundSprite = backgroundSprite;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index backgroundSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_highlightSprite(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			string highlightSprite = ToLua.CheckString(L, 2);
			uIPopupList.highlightSprite = highlightSprite;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index highlightSprite on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_position(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			UIPopupList.Position position = (UIPopupList.Position)((int)ToLua.CheckObject(L, 2, typeof(UIPopupList.Position)));
			uIPopupList.position = position;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index position on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_alignment(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			NGUIText.Alignment alignment = (NGUIText.Alignment)((int)ToLua.CheckObject(L, 2, typeof(NGUIText.Alignment)));
			uIPopupList.alignment = alignment;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index alignment on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_items(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			List<string> items = (List<string>)ToLua.CheckObject(L, 2, typeof(List<string>));
			uIPopupList.items = items;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index items on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_itemData(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			List<object> itemData = (List<object>)ToLua.CheckObject(L, 2, typeof(List<object>));
			uIPopupList.itemData = itemData;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index itemData on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_padding(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			Vector2 padding = ToLua.ToVector2(L, 2);
			uIPopupList.padding = padding;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index padding on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_textColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			Color textColor = ToLua.ToColor(L, 2);
			uIPopupList.textColor = textColor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index textColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_backgroundColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			Color backgroundColor = ToLua.ToColor(L, 2);
			uIPopupList.backgroundColor = backgroundColor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index backgroundColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_highlightColor(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			Color highlightColor = ToLua.ToColor(L, 2);
			uIPopupList.highlightColor = highlightColor;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index highlightColor on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isAnimated(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			bool isAnimated = LuaDLL.luaL_checkboolean(L, 2);
			uIPopupList.isAnimated = isAnimated;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isAnimated on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_isLocalized(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			bool isLocalized = LuaDLL.luaL_checkboolean(L, 2);
			uIPopupList.isLocalized = isLocalized;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index isLocalized on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_openOn(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			UIPopupList.OpenOn openOn = (UIPopupList.OpenOn)((int)ToLua.CheckObject(L, 2, typeof(UIPopupList.OpenOn)));
			uIPopupList.openOn = openOn;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index openOn on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_onChange(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			List<EventDelegate> onChange = (List<EventDelegate>)ToLua.CheckObject(L, 2, typeof(List<EventDelegate>));
			uIPopupList.onChange = onChange;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index onChange on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_ambigiousFont(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			UnityEngine.Object ambigiousFont = ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Object));
			uIPopupList.ambigiousFont = ambigiousFont;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index ambigiousFont on a nil value");
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_value(IntPtr L)
	{
		object obj = null;
		int result;
		try
		{
			obj = ToLua.ToObject(L, 1);
			UIPopupList uIPopupList = (UIPopupList)obj;
			string value = ToLua.CheckString(L, 2);
			uIPopupList.value = value;
			result = 0;
		}
		catch (Exception ex)
		{
			result = LuaDLL.toluaL_exception(L, ex, (obj != null) ? ex.Message : "attempt to index value on a nil value");
		}
		return result;
	}
}
