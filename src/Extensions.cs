using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ThirdParty;
using UnityEngine;

public static class Extensions
{
	private class ActionToEnumerator : IEnumerable
	{
		private Action action;

		public ActionToEnumerator(Action action)
		{
			this.action = action;
		}

		[DebuggerHidden]
		public IEnumerator GetEnumerator()
		{
			Extensions.ActionToEnumerator.<GetEnumerator>c__Iterator56 <GetEnumerator>c__Iterator = new Extensions.ActionToEnumerator.<GetEnumerator>c__Iterator56();
			<GetEnumerator>c__Iterator.<>f__this = this;
			return <GetEnumerator>c__Iterator;
		}
	}

	private static readonly System.Random random = new System.Random();

	private static readonly DateTime UnixBase = new DateTime(1970, 1, 1, 0, 0, 0);

	public static bool Next(this System.Random random, double successRate)
	{
		return successRate > random.NextDouble();
	}

	public static T Random<T>(this IList<T> list)
	{
		if (list == null || list.Count == 0)
		{
			return default(T);
		}
		return list[Extensions.random.Next(list.Count)];
	}

	[DebuggerHidden]
	public static IEnumerable<object> AsEnumerable(this IEnumerator it)
	{
		Extensions.<AsEnumerable>c__Iterator4F <AsEnumerable>c__Iterator4F = new Extensions.<AsEnumerable>c__Iterator4F();
		<AsEnumerable>c__Iterator4F.it = it;
		<AsEnumerable>c__Iterator4F.<$>it = it;
		Extensions.<AsEnumerable>c__Iterator4F expr_15 = <AsEnumerable>c__Iterator4F;
		expr_15.$PC = -2;
		return expr_15;
	}

	[DebuggerHidden]
	public static IEnumerable<T> AsEnumerable<T>(this IEnumerator<T> it)
	{
		Extensions.<AsEnumerable>c__Iterator50<T> <AsEnumerable>c__Iterator = new Extensions.<AsEnumerable>c__Iterator50<T>();
		<AsEnumerable>c__Iterator.it = it;
		<AsEnumerable>c__Iterator.<$>it = it;
		Extensions.<AsEnumerable>c__Iterator50<T> expr_15 = <AsEnumerable>c__Iterator;
		expr_15.$PC = -2;
		return expr_15;
	}

	public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dic, IEnumerable<KeyValuePair<TKey, TValue>> collection)
	{
		foreach (KeyValuePair<TKey, TValue> current in collection)
		{
			dic.Add(current.Key, current.Value);
		}
	}

	[DebuggerHidden]
	public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> data, int count, Func<T> valueFactory = null)
	{
		Extensions.<TakeWhile>c__Iterator51<T> <TakeWhile>c__Iterator = new Extensions.<TakeWhile>c__Iterator51<T>();
		<TakeWhile>c__Iterator.data = data;
		<TakeWhile>c__Iterator.count = count;
		<TakeWhile>c__Iterator.valueFactory = valueFactory;
		<TakeWhile>c__Iterator.<$>data = data;
		<TakeWhile>c__Iterator.<$>count = count;
		<TakeWhile>c__Iterator.<$>valueFactory = valueFactory;
		Extensions.<TakeWhile>c__Iterator51<T> expr_31 = <TakeWhile>c__Iterator;
		expr_31.$PC = -2;
		return expr_31;
	}

	public static List<T> Resize<T>(this List<T> data, int count, Func<T> valueFactory = null)
	{
		while (data.Count < count)
		{
			data.Add((valueFactory == null) ? default(T) : valueFactory());
		}
		if (data.Count > count)
		{
			data.RemoveRange(count, data.Count - count);
		}
		return data;
	}

	public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
	{
		return Extensions.ZipIterator<TFirst, TSecond, TResult>(first, second, resultSelector);
	}

	public static IEnumerable<Tuple<TFirst, TSecond>> Zip<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
	{
		return Extensions.ZipIterator<TFirst, TSecond, Tuple<TFirst, TSecond>>(first, second, (TFirst f, TSecond s) => Tuple.Create<TFirst, TSecond>(f, s));
	}

	[DebuggerHidden]
	private static IEnumerable<TResult> ZipIterator<TFirst, TSecond, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
	{
		Extensions.<ZipIterator>c__Iterator52<TFirst, TSecond, TResult> <ZipIterator>c__Iterator = new Extensions.<ZipIterator>c__Iterator52<TFirst, TSecond, TResult>();
		<ZipIterator>c__Iterator.first = first;
		<ZipIterator>c__Iterator.second = second;
		<ZipIterator>c__Iterator.resultSelector = resultSelector;
		<ZipIterator>c__Iterator.<$>first = first;
		<ZipIterator>c__Iterator.<$>second = second;
		<ZipIterator>c__Iterator.<$>resultSelector = resultSelector;
		Extensions.<ZipIterator>c__Iterator52<TFirst, TSecond, TResult> expr_31 = <ZipIterator>c__Iterator;
		expr_31.$PC = -2;
		return expr_31;
	}

	[DebuggerHidden]
	public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, TSource tail)
	{
		Extensions.<Concat>c__Iterator53<TSource> <Concat>c__Iterator = new Extensions.<Concat>c__Iterator53<TSource>();
		<Concat>c__Iterator.first = first;
		<Concat>c__Iterator.tail = tail;
		<Concat>c__Iterator.<$>first = first;
		<Concat>c__Iterator.<$>tail = tail;
		Extensions.<Concat>c__Iterator53<TSource> expr_23 = <Concat>c__Iterator;
		expr_23.$PC = -2;
		return expr_23;
	}

	public static byte[] ReadAllBytes(this Stream stream)
	{
		int num = 0;
		int i = (int)stream.Length;
		byte[] array = new byte[i];
		while (i > 0)
		{
			int num2 = stream.Read(array, num, i);
			if (num2 == 0)
			{
				throw new EndOfStreamException();
			}
			num += num2;
			i -= num2;
		}
		return array;
	}

	public static string Dump(this object obj)
	{
		return "{ " + string.Join(", ", (from f in obj.GetType().GetRuntimeFields()
		select f.Name + "=" + f.GetValue(obj)).ToArray<string>()) + " }";
	}

	public static string Dump(this Vector3[] data)
	{
		return "{" + string.Join(", ", Array.ConvertAll<Vector3, string>(data, (Vector3 i) => i.Dump())) + "}";
	}

	public static string Dump(this Vector2 data)
	{
		return string.Format("({0}, {1})", data.x, data.y);
	}

	public static string Dump(this Vector3 data)
	{
		return string.Format("({0}, {1}, {2})", data.x, data.y, data.z);
	}

	public static string Dump(this Vector4 data)
	{
		return string.Format("({0}, {1}, {2}, {3})", new object[]
		{
			data.x,
			data.y,
			data.z,
			data.w
		});
	}

	public static bool TryParse(this string value, out bool result)
	{
		return bool.TryParse(value, out result);
	}

	public static bool Parse(this string value, bool defaultValue)
	{
		bool flag;
		return (!bool.TryParse(value, out flag)) ? defaultValue : flag;
	}

	public static bool TryParse(this string value, out int result)
	{
		return int.TryParse(value, out result);
	}

	public static int Parse(this string value, int defaultValue)
	{
		int num;
		return (!int.TryParse(value, out num)) ? defaultValue : num;
	}

	public static bool TryParse(this string value, out uint result)
	{
		return uint.TryParse(value, out result);
	}

	public static uint Parse(this string value, uint defaultValue)
	{
		uint num;
		return (!uint.TryParse(value, out num)) ? defaultValue : num;
	}

	public static bool TryParse(this string value, out ulong result)
	{
		return ulong.TryParse(value, out result);
	}

	public static ulong Parse(this string value, ulong defaultValue)
	{
		ulong num;
		return (!ulong.TryParse(value, out num)) ? defaultValue : num;
	}

	public static bool TryParse(this string value, out float result)
	{
		return float.TryParse(value, out result);
	}

	public static float Parse(this string value, float defaultValue)
	{
		float num;
		return (!float.TryParse(value, out num)) ? defaultValue : num;
	}

	public static bool TryParse(this string value, out Color result)
	{
		if (string.IsNullOrEmpty(value))
		{
			result = Color.white;
			return false;
		}
		if (value.StartsWith("#"))
		{
			return Extensions.TryParseColorFromRGBA(value.Substring(1), out result);
		}
		return Extensions.TryParseColorFromName(value, out result);
	}

	public static Color Parse(this string value, Color defaultValue)
	{
		Color color;
		return (!value.TryParse(out color)) ? defaultValue : color;
	}

	public static string ToBitString(this byte value)
	{
		StringBuilder stringBuilder = new StringBuilder(8);
		for (int i = 7; i >= 0; i--)
		{
			stringBuilder.Append((((int)value & 1 << i) <= 0) ? '0' : '1');
		}
		return stringBuilder.ToString();
	}

	public static string ToBitString(this short value)
	{
		return string.Join(" ", Array.ConvertAll<byte, string>(BitConverter.GetBytes(value), (byte b) => b.ToBitString()));
	}

	public static string ToBitString(this ushort value)
	{
		return string.Join(" ", Array.ConvertAll<byte, string>(BitConverter.GetBytes(value), (byte b) => b.ToBitString()));
	}

	public static string ToBitString(this int value)
	{
		return string.Join(" ", Array.ConvertAll<byte, string>(BitConverter.GetBytes(value), (byte b) => b.ToBitString()));
	}

	public static string ToBitString(this uint value)
	{
		return string.Join(" ", Array.ConvertAll<byte, string>(BitConverter.GetBytes(value), (byte b) => b.ToBitString()));
	}

	public static string ToBitString(this long value)
	{
		return string.Join(" ", Array.ConvertAll<byte, string>(BitConverter.GetBytes(value), (byte b) => b.ToBitString()));
	}

	public static string ToBitString(this ulong value)
	{
		return string.Join(" ", Array.ConvertAll<byte, string>(BitConverter.GetBytes(value), (byte b) => b.ToBitString()));
	}

	public static T GetOrAddComponent<T>(this Component child) where T : Component
	{
		T t = child.GetComponent<T>();
		if (t == null)
		{
			t = child.gameObject.AddComponent<T>();
		}
		return t;
	}

	public static Coroutine StartCoroutine(this MonoBehaviour mb, Action action)
	{
		return mb.StartCoroutine(new Extensions.ActionToEnumerator(action).GetEnumerator());
	}

	public static IEnumerable<T> GetComponentsDescendant<T>(this GameObject go) where T : Component
	{
		if (go == null)
		{
			return Enumerable.Empty<T>();
		}
		return go.transform.GetComponentsDescendant<T>();
	}

	public static IEnumerable<T> GetComponentsDescendant<T>(this Component c) where T : Component
	{
		if (c == null)
		{
			return Enumerable.Empty<T>();
		}
		return c.transform.GetComponentsDescendant<T>();
	}

	[DebuggerHidden]
	public static IEnumerable<T> GetComponentsDescendant<T>(this Transform transform) where T : Component
	{
		Extensions.<GetComponentsDescendant>c__Iterator54<T> <GetComponentsDescendant>c__Iterator = new Extensions.<GetComponentsDescendant>c__Iterator54<T>();
		<GetComponentsDescendant>c__Iterator.transform = transform;
		<GetComponentsDescendant>c__Iterator.<$>transform = transform;
		Extensions.<GetComponentsDescendant>c__Iterator54<T> expr_15 = <GetComponentsDescendant>c__Iterator;
		expr_15.$PC = -2;
		return expr_15;
	}

	[DebuggerHidden]
	public static IEnumerable<Transform> GetAllChildren(this Transform transform)
	{
		Extensions.<GetAllChildren>c__Iterator55 <GetAllChildren>c__Iterator = new Extensions.<GetAllChildren>c__Iterator55();
		<GetAllChildren>c__Iterator.transform = transform;
		<GetAllChildren>c__Iterator.<$>transform = transform;
		Extensions.<GetAllChildren>c__Iterator55 expr_15 = <GetAllChildren>c__Iterator;
		expr_15.$PC = -2;
		return expr_15;
	}

	public static void DestroyAllChildren(this Transform transform)
	{
		if (transform == null)
		{
			return;
		}
		foreach (Transform transform2 in transform)
		{
			UnityEngine.Object.Destroy(transform2.gameObject);
		}
	}

	public static string GetPath(this Transform current)
	{
		if (current.parent == null)
		{
			return "/" + current.name;
		}
		return current.parent.GetPath() + "/" + current.name;
	}

	public static string GetPath(this Component component)
	{
		return component.transform.GetPath() + ":" + component.GetType().ToString();
	}

	private static bool TryParseColorFromRGBA(string rgba, out Color color)
	{
		color = Color.white;
		if (string.IsNullOrEmpty(rgba))
		{
			return false;
		}
		switch (rgba.Length)
		{
		case 3:
			rgba = new string(new char[]
			{
				rgba[0],
				rgba[0],
				rgba[1],
				rgba[1],
				rgba[2],
				rgba[2],
				'F',
				'F'
			});
			break;
		case 4:
		case 5:
		case 7:
			return false;
		case 6:
			rgba += "FF";
			break;
		case 8:
			break;
		default:
			return false;
		}
		uint val;
		if (uint.TryParse(rgba, NumberStyles.AllowHexSpecifier, null, out val))
		{
			color = Extensions.IntToColor((int)val);
			return true;
		}
		return false;
	}

	private static Color IntToColor(int val)
	{
		float num = 0.003921569f;
		Color black = Color.black;
		black.r = num * (float)(val >> 24 & 255);
		black.g = num * (float)(val >> 16 & 255);
		black.b = num * (float)(val >> 8 & 255);
		black.a = num * (float)(val & 255);
		return black;
	}

	private static bool TryParseColorFromName(string colorName, out Color color)
	{
		switch (colorName)
		{
		case "black":
			color = Color.black;
			return true;
		case "blue":
			color = Color.blue;
			return true;
		case "clear":
			color = Color.clear;
			return true;
		case "cyan":
			color = Color.cyan;
			return true;
		case "gray":
			color = Color.gray;
			return true;
		case "green":
			color = Color.green;
			return true;
		case "grey":
			color = Color.grey;
			return true;
		case "magenta":
			color = Color.magenta;
			return true;
		case "red":
			color = Color.red;
			return true;
		case "white":
			color = Color.white;
			return true;
		case "yellow":
			color = Color.yellow;
			return true;
		}
		color = Color.white;
		return false;
	}

	public static uint ToUnixTime(this DateTime time)
	{
		return (uint)(time - Extensions.UnixBase).TotalSeconds;
	}

	public static DateTime ToDateTime(this uint localGMTTime)
	{
		return Extensions.UnixBase + TimeSpan.FromSeconds(localGMTTime);
	}
}
