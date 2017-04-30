using LuaInterface;
using System;
using System.Text;
using UnityEngine;

public class NGUITextWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("NGUIText");
		L.RegFunction("Update", new LuaCSFunction(NGUITextWrap.Update));
		L.RegFunction("Prepare", new LuaCSFunction(NGUITextWrap.Prepare));
		L.RegFunction("GetSymbol", new LuaCSFunction(NGUITextWrap.GetSymbol));
		L.RegFunction("GetGlyphWidth", new LuaCSFunction(NGUITextWrap.GetGlyphWidth));
		L.RegFunction("GetGlyph", new LuaCSFunction(NGUITextWrap.GetGlyph));
		L.RegFunction("ParseAlpha", new LuaCSFunction(NGUITextWrap.ParseAlpha));
		L.RegFunction("ParseColor", new LuaCSFunction(NGUITextWrap.ParseColor));
		L.RegFunction("ParseColor24", new LuaCSFunction(NGUITextWrap.ParseColor24));
		L.RegFunction("ParseColor32", new LuaCSFunction(NGUITextWrap.ParseColor32));
		L.RegFunction("EncodeColor", new LuaCSFunction(NGUITextWrap.EncodeColor));
		L.RegFunction("EncodeAlpha", new LuaCSFunction(NGUITextWrap.EncodeAlpha));
		L.RegFunction("EncodeColor24", new LuaCSFunction(NGUITextWrap.EncodeColor24));
		L.RegFunction("EncodeColor32", new LuaCSFunction(NGUITextWrap.EncodeColor32));
		L.RegFunction("ParseSymbol", new LuaCSFunction(NGUITextWrap.ParseSymbol));
		L.RegFunction("IsHex", new LuaCSFunction(NGUITextWrap.IsHex));
		L.RegFunction("StripSymbols", new LuaCSFunction(NGUITextWrap.StripSymbols));
		L.RegFunction("Align", new LuaCSFunction(NGUITextWrap.Align));
		L.RegFunction("GetExactCharacterIndex", new LuaCSFunction(NGUITextWrap.GetExactCharacterIndex));
		L.RegFunction("GetApproximateCharacterIndex", new LuaCSFunction(NGUITextWrap.GetApproximateCharacterIndex));
		L.RegFunction("EndLine", new LuaCSFunction(NGUITextWrap.EndLine));
		L.RegFunction("CalculatePrintedSize", new LuaCSFunction(NGUITextWrap.CalculatePrintedSize));
		L.RegFunction("CalculateOffsetToFit", new LuaCSFunction(NGUITextWrap.CalculateOffsetToFit));
		L.RegFunction("GetEndOfLineThatFits", new LuaCSFunction(NGUITextWrap.GetEndOfLineThatFits));
		L.RegFunction("WrapText", new LuaCSFunction(NGUITextWrap.WrapText));
		L.RegFunction("Print", new LuaCSFunction(NGUITextWrap.Print));
		L.RegFunction("PrintApproximateCharacterPositions", new LuaCSFunction(NGUITextWrap.PrintApproximateCharacterPositions));
		L.RegFunction("PrintExactCharacterPositions", new LuaCSFunction(NGUITextWrap.PrintExactCharacterPositions));
		L.RegFunction("PrintCaretAndSelection", new LuaCSFunction(NGUITextWrap.PrintCaretAndSelection));
		L.RegVar("bitmapFont", new LuaCSFunction(NGUITextWrap.get_bitmapFont), new LuaCSFunction(NGUITextWrap.set_bitmapFont));
		L.RegVar("dynamicFont", new LuaCSFunction(NGUITextWrap.get_dynamicFont), new LuaCSFunction(NGUITextWrap.set_dynamicFont));
		L.RegVar("glyph", new LuaCSFunction(NGUITextWrap.get_glyph), new LuaCSFunction(NGUITextWrap.set_glyph));
		L.RegVar("fontSize", new LuaCSFunction(NGUITextWrap.get_fontSize), new LuaCSFunction(NGUITextWrap.set_fontSize));
		L.RegVar("fontScale", new LuaCSFunction(NGUITextWrap.get_fontScale), new LuaCSFunction(NGUITextWrap.set_fontScale));
		L.RegVar("pixelDensity", new LuaCSFunction(NGUITextWrap.get_pixelDensity), new LuaCSFunction(NGUITextWrap.set_pixelDensity));
		L.RegVar("fontStyle", new LuaCSFunction(NGUITextWrap.get_fontStyle), new LuaCSFunction(NGUITextWrap.set_fontStyle));
		L.RegVar("alignment", new LuaCSFunction(NGUITextWrap.get_alignment), new LuaCSFunction(NGUITextWrap.set_alignment));
		L.RegVar("tint", new LuaCSFunction(NGUITextWrap.get_tint), new LuaCSFunction(NGUITextWrap.set_tint));
		L.RegVar("rectWidth", new LuaCSFunction(NGUITextWrap.get_rectWidth), new LuaCSFunction(NGUITextWrap.set_rectWidth));
		L.RegVar("rectHeight", new LuaCSFunction(NGUITextWrap.get_rectHeight), new LuaCSFunction(NGUITextWrap.set_rectHeight));
		L.RegVar("regionWidth", new LuaCSFunction(NGUITextWrap.get_regionWidth), new LuaCSFunction(NGUITextWrap.set_regionWidth));
		L.RegVar("regionHeight", new LuaCSFunction(NGUITextWrap.get_regionHeight), new LuaCSFunction(NGUITextWrap.set_regionHeight));
		L.RegVar("maxLines", new LuaCSFunction(NGUITextWrap.get_maxLines), new LuaCSFunction(NGUITextWrap.set_maxLines));
		L.RegVar("gradient", new LuaCSFunction(NGUITextWrap.get_gradient), new LuaCSFunction(NGUITextWrap.set_gradient));
		L.RegVar("gradientBottom", new LuaCSFunction(NGUITextWrap.get_gradientBottom), new LuaCSFunction(NGUITextWrap.set_gradientBottom));
		L.RegVar("gradientTop", new LuaCSFunction(NGUITextWrap.get_gradientTop), new LuaCSFunction(NGUITextWrap.set_gradientTop));
		L.RegVar("encoding", new LuaCSFunction(NGUITextWrap.get_encoding), new LuaCSFunction(NGUITextWrap.set_encoding));
		L.RegVar("spacingX", new LuaCSFunction(NGUITextWrap.get_spacingX), new LuaCSFunction(NGUITextWrap.set_spacingX));
		L.RegVar("spacingY", new LuaCSFunction(NGUITextWrap.get_spacingY), new LuaCSFunction(NGUITextWrap.set_spacingY));
		L.RegVar("premultiply", new LuaCSFunction(NGUITextWrap.get_premultiply), new LuaCSFunction(NGUITextWrap.set_premultiply));
		L.RegVar("symbolStyle", new LuaCSFunction(NGUITextWrap.get_symbolStyle), new LuaCSFunction(NGUITextWrap.set_symbolStyle));
		L.RegVar("finalSize", new LuaCSFunction(NGUITextWrap.get_finalSize), new LuaCSFunction(NGUITextWrap.set_finalSize));
		L.RegVar("finalSpacingX", new LuaCSFunction(NGUITextWrap.get_finalSpacingX), new LuaCSFunction(NGUITextWrap.set_finalSpacingX));
		L.RegVar("finalLineHeight", new LuaCSFunction(NGUITextWrap.get_finalLineHeight), new LuaCSFunction(NGUITextWrap.set_finalLineHeight));
		L.RegVar("baseline", new LuaCSFunction(NGUITextWrap.get_baseline), new LuaCSFunction(NGUITextWrap.set_baseline));
		L.RegVar("useSymbols", new LuaCSFunction(NGUITextWrap.get_useSymbols), new LuaCSFunction(NGUITextWrap.set_useSymbols));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Update(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 0)
			{
				NGUIText.Update();
				result = 0;
			}
			else if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(bool)))
			{
				bool request = LuaDLL.lua_toboolean(L, 1);
				NGUIText.Update(request);
				result = 0;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUIText.Update");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Prepare(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string text = ToLua.CheckString(L, 1);
			NGUIText.Prepare(text);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetSymbol(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			string text = ToLua.CheckString(L, 1);
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			int textLength = (int)LuaDLL.luaL_checknumber(L, 3);
			BMSymbol symbol = NGUIText.GetSymbol(text, index, textLength);
			ToLua.PushObject(L, symbol);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetGlyphWidth(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			int ch = (int)LuaDLL.luaL_checknumber(L, 1);
			int prev = (int)LuaDLL.luaL_checknumber(L, 2);
			float glyphWidth = NGUIText.GetGlyphWidth(ch, prev);
			LuaDLL.lua_pushnumber(L, (double)glyphWidth);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetGlyph(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			int ch = (int)LuaDLL.luaL_checknumber(L, 1);
			int prev = (int)LuaDLL.luaL_checknumber(L, 2);
			NGUIText.GlyphInfo glyph = NGUIText.GetGlyph(ch, prev);
			ToLua.PushObject(L, glyph);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ParseAlpha(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string text = ToLua.CheckString(L, 1);
			int index = (int)LuaDLL.luaL_checknumber(L, 2);
			float num = NGUIText.ParseAlpha(text, index);
			LuaDLL.lua_pushnumber(L, (double)num);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ParseColor(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string text = ToLua.CheckString(L, 1);
			int offset = (int)LuaDLL.luaL_checknumber(L, 2);
			Color clr = NGUIText.ParseColor(text, offset);
			ToLua.Push(L, clr);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ParseColor24(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string text = ToLua.CheckString(L, 1);
			int offset = (int)LuaDLL.luaL_checknumber(L, 2);
			Color clr = NGUIText.ParseColor24(text, offset);
			ToLua.Push(L, clr);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int ParseColor32(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string text = ToLua.CheckString(L, 1);
			int offset = (int)LuaDLL.luaL_checknumber(L, 2);
			Color clr = NGUIText.ParseColor32(text, offset);
			ToLua.Push(L, clr);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EncodeColor(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(Color)))
			{
				Color c = ToLua.ToColor(L, 1);
				string str = NGUIText.EncodeColor(c);
				LuaDLL.lua_pushstring(L, str);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(Color)))
			{
				string text = ToLua.ToString(L, 1);
				Color c2 = ToLua.ToColor(L, 2);
				string str2 = NGUIText.EncodeColor(text, c2);
				LuaDLL.lua_pushstring(L, str2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUIText.EncodeColor");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EncodeAlpha(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			float a = (float)LuaDLL.luaL_checknumber(L, 1);
			string str = NGUIText.EncodeAlpha(a);
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
	private static int EncodeColor24(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Color c = ToLua.ToColor(L, 1);
			string str = NGUIText.EncodeColor24(c);
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
	private static int EncodeColor32(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Color c = ToLua.ToColor(L, 1);
			string str = NGUIText.EncodeColor32(c);
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
	private static int ParseSymbol(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int)))
			{
				string text = ToLua.ToString(L, 1);
				int n = (int)LuaDLL.lua_tonumber(L, 2);
				bool value = NGUIText.ParseSymbol(text, ref n);
				LuaDLL.lua_pushboolean(L, value);
				LuaDLL.lua_pushinteger(L, n);
				result = 2;
			}
			else if (num == 10 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int), typeof(BetterList<Color>), typeof(bool), typeof(int), typeof(bool), typeof(bool), typeof(bool), typeof(bool), typeof(bool)))
			{
				string text2 = ToLua.ToString(L, 1);
				int n2 = (int)LuaDLL.lua_tonumber(L, 2);
				BetterList<Color> colors = (BetterList<Color>)ToLua.ToObject(L, 3);
				bool premultiply = LuaDLL.lua_toboolean(L, 4);
				int n3 = (int)LuaDLL.lua_tonumber(L, 5);
				bool value2 = LuaDLL.lua_toboolean(L, 6);
				bool value3 = LuaDLL.lua_toboolean(L, 7);
				bool value4 = LuaDLL.lua_toboolean(L, 8);
				bool value5 = LuaDLL.lua_toboolean(L, 9);
				bool value6 = LuaDLL.lua_toboolean(L, 10);
				bool value7 = NGUIText.ParseSymbol(text2, ref n2, colors, premultiply, ref n3, ref value2, ref value3, ref value4, ref value5, ref value6);
				LuaDLL.lua_pushboolean(L, value7);
				LuaDLL.lua_pushinteger(L, n2);
				LuaDLL.lua_pushinteger(L, n3);
				LuaDLL.lua_pushboolean(L, value2);
				LuaDLL.lua_pushboolean(L, value3);
				LuaDLL.lua_pushboolean(L, value4);
				LuaDLL.lua_pushboolean(L, value5);
				LuaDLL.lua_pushboolean(L, value6);
				result = 8;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUIText.ParseSymbol");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int IsHex(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			char ch = (char)LuaDLL.luaL_checknumber(L, 1);
			bool value = NGUIText.IsHex(ch);
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
	private static int StripSymbols(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string text = ToLua.CheckString(L, 1);
			string str = NGUIText.StripSymbols(text);
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
	private static int Align(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.CheckObject(L, 1, typeof(BetterList<Vector3>));
			int indexOffset = (int)LuaDLL.luaL_checknumber(L, 2);
			float printedWidth = (float)LuaDLL.luaL_checknumber(L, 3);
			NGUIText.Align(verts, indexOffset, printedWidth);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetExactCharacterIndex(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.CheckObject(L, 1, typeof(BetterList<Vector3>));
			BetterList<int> indices = (BetterList<int>)ToLua.CheckObject(L, 2, typeof(BetterList<int>));
			Vector2 pos = ToLua.ToVector2(L, 3);
			int exactCharacterIndex = NGUIText.GetExactCharacterIndex(verts, indices, pos);
			LuaDLL.lua_pushinteger(L, exactCharacterIndex);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int GetApproximateCharacterIndex(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.CheckObject(L, 1, typeof(BetterList<Vector3>));
			BetterList<int> indices = (BetterList<int>)ToLua.CheckObject(L, 2, typeof(BetterList<int>));
			Vector2 pos = ToLua.ToVector2(L, 3);
			int approximateCharacterIndex = NGUIText.GetApproximateCharacterIndex(verts, indices, pos);
			LuaDLL.lua_pushinteger(L, approximateCharacterIndex);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EndLine(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			StringBuilder o = (StringBuilder)ToLua.CheckObject(L, 1, typeof(StringBuilder));
			NGUIText.EndLine(ref o);
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
	private static int CalculatePrintedSize(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 1 && TypeChecker.CheckTypes(L, 1, typeof(string)))
			{
				string text = ToLua.ToString(L, 1);
				Vector2 v = NGUIText.CalculatePrintedSize(text);
				ToLua.Push(L, v);
				result = 1;
			}
			else if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(int)))
			{
				string text2 = ToLua.ToString(L, 1);
				int maxW = (int)LuaDLL.lua_tonumber(L, 2);
				Vector2 v2 = NGUIText.CalculatePrintedSize(text2, maxW);
				ToLua.Push(L, v2);
				result = 1;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUIText.CalculatePrintedSize");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int CalculateOffsetToFit(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string text = ToLua.CheckString(L, 1);
			int n = NGUIText.CalculateOffsetToFit(text);
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
	private static int GetEndOfLineThatFits(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string text = ToLua.CheckString(L, 1);
			string endOfLineThatFits = NGUIText.GetEndOfLineThatFits(text);
			LuaDLL.lua_pushstring(L, endOfLineThatFits);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int WrapText(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			if (num == 2 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(LuaOut<string>)))
			{
				string text = ToLua.ToString(L, 1);
				string str = null;
				bool value = NGUIText.WrapText(text, out str);
				LuaDLL.lua_pushboolean(L, value);
				LuaDLL.lua_pushstring(L, str);
				result = 2;
			}
			else if (num == 3 && TypeChecker.CheckTypes(L, 1, typeof(string), typeof(LuaOut<string>), typeof(bool)))
			{
				string text2 = ToLua.ToString(L, 1);
				string str2 = null;
				bool keepCharCount = LuaDLL.lua_toboolean(L, 3);
				bool value2 = NGUIText.WrapText(text2, out str2, keepCharCount);
				LuaDLL.lua_pushboolean(L, value2);
				LuaDLL.lua_pushstring(L, str2);
				result = 2;
			}
			else
			{
				result = LuaDLL.luaL_throw(L, "invalid arguments to method: NGUIText.WrapText");
			}
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Print(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 4);
			string text = ToLua.CheckString(L, 1);
			BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector3>));
			BetterList<Vector2> uvs = (BetterList<Vector2>)ToLua.CheckObject(L, 3, typeof(BetterList<Vector2>));
			BetterList<Color32> cols = (BetterList<Color32>)ToLua.CheckObject(L, 4, typeof(BetterList<Color32>));
			NGUIText.Print(text, verts, uvs, cols);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PrintApproximateCharacterPositions(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			string text = ToLua.CheckString(L, 1);
			BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector3>));
			BetterList<int> indices = (BetterList<int>)ToLua.CheckObject(L, 3, typeof(BetterList<int>));
			NGUIText.PrintApproximateCharacterPositions(text, verts, indices);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PrintExactCharacterPositions(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 3);
			string text = ToLua.CheckString(L, 1);
			BetterList<Vector3> verts = (BetterList<Vector3>)ToLua.CheckObject(L, 2, typeof(BetterList<Vector3>));
			BetterList<int> indices = (BetterList<int>)ToLua.CheckObject(L, 3, typeof(BetterList<int>));
			NGUIText.PrintExactCharacterPositions(text, verts, indices);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PrintCaretAndSelection(IntPtr L)
	{
		int result;
		try
		{
			ToLua.CheckArgsCount(L, 5);
			string text = ToLua.CheckString(L, 1);
			int start = (int)LuaDLL.luaL_checknumber(L, 2);
			int end = (int)LuaDLL.luaL_checknumber(L, 3);
			BetterList<Vector3> caret = (BetterList<Vector3>)ToLua.CheckObject(L, 4, typeof(BetterList<Vector3>));
			BetterList<Vector3> highlight = (BetterList<Vector3>)ToLua.CheckObject(L, 5, typeof(BetterList<Vector3>));
			NGUIText.PrintCaretAndSelection(text, start, end, caret, highlight);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_bitmapFont(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, NGUIText.bitmapFont);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_dynamicFont(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, NGUIText.dynamicFont);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_glyph(IntPtr L)
	{
		int result;
		try
		{
			ToLua.PushObject(L, NGUIText.glyph);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fontSize(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, NGUIText.fontSize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fontScale(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)NGUIText.fontScale);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_pixelDensity(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)NGUIText.pixelDensity);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_fontStyle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, NGUIText.fontStyle);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_alignment(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, NGUIText.alignment);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_tint(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, NGUIText.tint);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rectWidth(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, NGUIText.rectWidth);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_rectHeight(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, NGUIText.rectHeight);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_regionWidth(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, NGUIText.regionWidth);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_regionHeight(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, NGUIText.regionHeight);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_maxLines(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, NGUIText.maxLines);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gradient(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, NGUIText.gradient);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gradientBottom(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, NGUIText.gradientBottom);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_gradientTop(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, NGUIText.gradientTop);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_encoding(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, NGUIText.encoding);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_spacingX(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)NGUIText.spacingX);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_spacingY(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)NGUIText.spacingY);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_premultiply(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, NGUIText.premultiply);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_symbolStyle(IntPtr L)
	{
		int result;
		try
		{
			ToLua.Push(L, NGUIText.symbolStyle);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_finalSize(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushinteger(L, NGUIText.finalSize);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_finalSpacingX(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)NGUIText.finalSpacingX);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_finalLineHeight(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)NGUIText.finalLineHeight);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_baseline(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushnumber(L, (double)NGUIText.baseline);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int get_useSymbols(IntPtr L)
	{
		int result;
		try
		{
			LuaDLL.lua_pushboolean(L, NGUIText.useSymbols);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_bitmapFont(IntPtr L)
	{
		int result;
		try
		{
			UIFont bitmapFont = (UIFont)ToLua.CheckUnityObject(L, 2, typeof(UIFont));
			NGUIText.bitmapFont = bitmapFont;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_dynamicFont(IntPtr L)
	{
		int result;
		try
		{
			Font dynamicFont = (Font)ToLua.CheckUnityObject(L, 2, typeof(Font));
			NGUIText.dynamicFont = dynamicFont;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_glyph(IntPtr L)
	{
		int result;
		try
		{
			NGUIText.GlyphInfo glyph = (NGUIText.GlyphInfo)ToLua.CheckObject(L, 2, typeof(NGUIText.GlyphInfo));
			NGUIText.glyph = glyph;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fontSize(IntPtr L)
	{
		int result;
		try
		{
			int fontSize = (int)LuaDLL.luaL_checknumber(L, 2);
			NGUIText.fontSize = fontSize;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fontScale(IntPtr L)
	{
		int result;
		try
		{
			float fontScale = (float)LuaDLL.luaL_checknumber(L, 2);
			NGUIText.fontScale = fontScale;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_pixelDensity(IntPtr L)
	{
		int result;
		try
		{
			float pixelDensity = (float)LuaDLL.luaL_checknumber(L, 2);
			NGUIText.pixelDensity = pixelDensity;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_fontStyle(IntPtr L)
	{
		int result;
		try
		{
			FontStyle fontStyle = (FontStyle)((int)ToLua.CheckObject(L, 2, typeof(FontStyle)));
			NGUIText.fontStyle = fontStyle;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_alignment(IntPtr L)
	{
		int result;
		try
		{
			NGUIText.Alignment alignment = (NGUIText.Alignment)((int)ToLua.CheckObject(L, 2, typeof(NGUIText.Alignment)));
			NGUIText.alignment = alignment;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_tint(IntPtr L)
	{
		int result;
		try
		{
			Color tint = ToLua.ToColor(L, 2);
			NGUIText.tint = tint;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rectWidth(IntPtr L)
	{
		int result;
		try
		{
			int rectWidth = (int)LuaDLL.luaL_checknumber(L, 2);
			NGUIText.rectWidth = rectWidth;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_rectHeight(IntPtr L)
	{
		int result;
		try
		{
			int rectHeight = (int)LuaDLL.luaL_checknumber(L, 2);
			NGUIText.rectHeight = rectHeight;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_regionWidth(IntPtr L)
	{
		int result;
		try
		{
			int regionWidth = (int)LuaDLL.luaL_checknumber(L, 2);
			NGUIText.regionWidth = regionWidth;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_regionHeight(IntPtr L)
	{
		int result;
		try
		{
			int regionHeight = (int)LuaDLL.luaL_checknumber(L, 2);
			NGUIText.regionHeight = regionHeight;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_maxLines(IntPtr L)
	{
		int result;
		try
		{
			int maxLines = (int)LuaDLL.luaL_checknumber(L, 2);
			NGUIText.maxLines = maxLines;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_gradient(IntPtr L)
	{
		int result;
		try
		{
			bool gradient = LuaDLL.luaL_checkboolean(L, 2);
			NGUIText.gradient = gradient;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_gradientBottom(IntPtr L)
	{
		int result;
		try
		{
			Color gradientBottom = ToLua.ToColor(L, 2);
			NGUIText.gradientBottom = gradientBottom;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_gradientTop(IntPtr L)
	{
		int result;
		try
		{
			Color gradientTop = ToLua.ToColor(L, 2);
			NGUIText.gradientTop = gradientTop;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_encoding(IntPtr L)
	{
		int result;
		try
		{
			bool encoding = LuaDLL.luaL_checkboolean(L, 2);
			NGUIText.encoding = encoding;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spacingX(IntPtr L)
	{
		int result;
		try
		{
			float spacingX = (float)LuaDLL.luaL_checknumber(L, 2);
			NGUIText.spacingX = spacingX;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_spacingY(IntPtr L)
	{
		int result;
		try
		{
			float spacingY = (float)LuaDLL.luaL_checknumber(L, 2);
			NGUIText.spacingY = spacingY;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_premultiply(IntPtr L)
	{
		int result;
		try
		{
			bool premultiply = LuaDLL.luaL_checkboolean(L, 2);
			NGUIText.premultiply = premultiply;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_symbolStyle(IntPtr L)
	{
		int result;
		try
		{
			NGUIText.SymbolStyle symbolStyle = (NGUIText.SymbolStyle)((int)ToLua.CheckObject(L, 2, typeof(NGUIText.SymbolStyle)));
			NGUIText.symbolStyle = symbolStyle;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_finalSize(IntPtr L)
	{
		int result;
		try
		{
			int finalSize = (int)LuaDLL.luaL_checknumber(L, 2);
			NGUIText.finalSize = finalSize;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_finalSpacingX(IntPtr L)
	{
		int result;
		try
		{
			float finalSpacingX = (float)LuaDLL.luaL_checknumber(L, 2);
			NGUIText.finalSpacingX = finalSpacingX;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_finalLineHeight(IntPtr L)
	{
		int result;
		try
		{
			float finalLineHeight = (float)LuaDLL.luaL_checknumber(L, 2);
			NGUIText.finalLineHeight = finalLineHeight;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_baseline(IntPtr L)
	{
		int result;
		try
		{
			float baseline = (float)LuaDLL.luaL_checknumber(L, 2);
			NGUIText.baseline = baseline;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int set_useSymbols(IntPtr L)
	{
		int result;
		try
		{
			bool useSymbols = LuaDLL.luaL_checkboolean(L, 2);
			NGUIText.useSymbols = useSymbols;
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
