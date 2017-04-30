using LuaInterface;
using System;
using UnityEngine;

public class TestExport
{
	public enum Space
	{
		World = 1
	}

	[LuaByteBuffer]
	public delegate void TestBuffer(byte[] buffer);

	public delegate void TestRefEvent(ref GameObject go);

	public int field = 1024;

	public Action OnClick = delegate
	{
	};

	public TestExport.TestRefEvent OnRefEvent;

	private int number = 123;

	[LuaByteBuffer]
	public byte[] buffer;

	public int Number
	{
		get
		{
			return this.number;
		}
		set
		{
			this.number = value;
		}
	}

	public int this[int pos]
	{
		get
		{
			return pos;
		}
		set
		{
			Debugger.Log(value);
		}
	}

	public TestExport()
	{
		Debugger.Log("call TestExport()");
	}

	public TestExport(Vector3[] v)
	{
		Debugger.Log("call TestExport(params Vector3[] v)");
	}

	public TestExport(Vector3 v, string str)
	{
		Debugger.Log("call TestExport(Vector3 v, string str)");
	}

	public TestExport(Vector3 v)
	{
		Debugger.Log("call TestExport(Vector3 v)");
	}

	public static int get_Item(string pos)
	{
		return 0;
	}

	public static int get_Item(double pos)
	{
		return 0;
	}

	public static int set_Item(double pos)
	{
		return 0;
	}

	public void TestByteBuffer(TestExport.TestBuffer tb)
	{
	}

	public int Test(object o, string str)
	{
		Debugger.Log("call Test(object o, string str)");
		return 1;
	}

	[LuaRename(Name = "TestChar")]
	public int Test(char c)
	{
		Debugger.Log("call Test(char c)");
		return 2;
	}

	public int Test(bool b)
	{
		Debugger.Log("call Test(bool b)");
		return 15;
	}

	public int Test(int[,] objs)
	{
		Debugger.Log("call Test(int[,] objs)");
		return 16;
	}

	public int Test(int i)
	{
		Debugger.Log("call Test(int i)");
		return 3;
	}

	public int Test(double d)
	{
		Debugger.Log("call Test(double d)");
		return 4;
	}

	public int Test(out int i)
	{
		i = 1024;
		Debugger.Log("call Test(ref int i)");
		return 3;
	}

	public int Test(int i, int j)
	{
		Debugger.Log("call Test(int i, int j)");
		return 5;
	}

	public int Test(string str)
	{
		Debugger.Log("call Test(string str)");
		return 6;
	}

	public static int Test(string str1, string str2)
	{
		Debugger.Log("call static Test(string str1, string str2)");
		return 7;
	}

	public int Test(object o)
	{
		Debugger.Log("call Test(object o)");
		return 8;
	}

	public int Test(params int[] objs)
	{
		Debugger.Log("call Test(params int[] objs)");
		return 12;
	}

	public int Test(params string[] objs)
	{
		Debugger.Log("call Test(params int[] objs)");
		return 13;
	}

	public int Test(params object[] objs)
	{
		Debugger.Log("call Test(params object[] objs)");
		return 9;
	}

	public int Test(TestExport.Space e)
	{
		Debugger.Log("call Test(Space e)");
		return 10;
	}

	public int Test33(ref Action<int> action)
	{
		Debugger.Log("ref System.Action action");
		return 14;
	}

	public int TestGeneric<T>(T t) where T : Component
	{
		Debugger.Log("TestGeneric(T t) Call");
		return 11;
	}

	public int TestEnum(TestExport.Space e)
	{
		Debugger.Log("call TestEnum(Space e)");
		return 10;
	}

	public int TestCheckParamNumber(params int[] ns)
	{
		Debugger.Log("call TestCheckParamNumber(params int[] ns)");
		int num = 0;
		for (int i = 0; i < ns.Length; i++)
		{
			num += ns[i];
		}
		return num;
	}

	public string TestCheckParamString(params string[] ss)
	{
		Debugger.Log("call TestCheckParamNumber(params string[] ss)");
		string text = null;
		for (int i = 0; i < ss.Length; i++)
		{
			text += ss[i];
		}
		return text;
	}

	public static void TestReflection()
	{
		Debugger.Log("call TestReflection()");
	}

	public static void TestRefGameObject(ref GameObject go)
	{
	}

	public void DoClick()
	{
		this.OnClick();
	}
}
