using LuaInterface;
using System;
using UnityEngine;

public class AccessingArray : MonoBehaviour
{
	private string script = "\r\n            function TestArray(array)\r\n                local len = array.Length\r\n                \r\n                for i = 0, len - 1 do\r\n                    print('Array: '..tostring(array[i]))\r\n                end\r\n\r\n                local t = array:ToTable()                \r\n                \r\n                for i = 1, #t do\r\n                    print('table: '.. tostring(t[i]))\r\n                end\r\n\r\n                local iter = array:GetEnumerator()\r\n\r\n                while iter:MoveNext() do\r\n                    print('iter: '..iter.Current)\r\n                end\r\n\r\n                local pos = array:BinarySearch(3)\r\n                print('array BinarySearch: pos: '..pos..' value: '..array[pos])\r\n\r\n                pos = array:IndexOf(4)\r\n                print('array indexof bbb pos is: '..pos)\r\n                \r\n                return 1, '123', true\r\n            end            \r\n        ";

	private LuaState lua;

	private LuaFunction func;

	private void Start()
	{
		this.lua = new LuaState();
		this.lua.Start();
		this.lua.DoString(this.script, "AccessingArray.cs");
		int[] array = new int[]
		{
			1,
			2,
			3,
			4,
			5
		};
		this.func = this.lua.GetFunction("TestArray", true);
		this.func.BeginPCall();
		this.func.Push(array);
		this.func.PCall();
		double num = this.func.CheckNumber();
		string arg = this.func.CheckString();
		bool flag = this.func.CheckBoolean();
		Debugger.Log("return is {0} {1} {2}", num, arg, flag);
		this.func.EndPCall();
		object[] array2 = this.func.Call(new object[]
		{
			array
		});
		if (array2 != null)
		{
			Debugger.Log("return is {0} {1} {2}", array2[0], array2[1], array2[2]);
		}
		this.lua.CheckTop();
	}

	private void OnApplicationQuit()
	{
		this.func.Dispose();
		this.lua.Dispose();
	}
}
