using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UseDictionary : MonoBehaviour
{
	private Dictionary<int, TestAccount> map = new Dictionary<int, TestAccount>();

	private string script = "              \r\n            function TestDict(map)                        \r\n                local iter = map:GetEnumerator() \r\n                \r\n                while iter:MoveNext() do\r\n                    local v = iter.Current.Value\r\n                    print('id: '..v.id ..' name: '..v.name..' sex: '..v.sex)                                \r\n                end\r\n\r\n                local flag, account = map:TryGetValue(1, nil)\r\n\r\n                if flag then\r\n                    print('TryGetValue result ok: '..account.name)\r\n                end\r\n\r\n                local keys = map.Keys\r\n                iter = keys:GetEnumerator()\r\n                print('------------print dictionary keys---------------')\r\n                while iter:MoveNext() do\r\n                    print(iter.Current)\r\n                end\r\n                print('----------------------over----------------------')\r\n\r\n                local values = map.Values\r\n                iter = values:GetEnumerator()\r\n                print('------------print dictionary values---------------')\r\n                while iter:MoveNext() do\r\n                    print(iter.Current.name)\r\n                end\r\n                print('----------------------over----------------------')                \r\n\r\n                print('kick '..map[2].name)\r\n                map:Remove(2)\r\n                iter = map:GetEnumerator() \r\n\r\n                while iter:MoveNext() do\r\n                    local v = iter.Current.Value\r\n                    print('id: '..v.id ..' name: '..v.name..' sex: '..v.sex)                                \r\n                end\r\n            end                        \r\n        ";

	private void Awake()
	{
		this.map.Add(1, new TestAccount(1, "水水", 0));
		this.map.Add(2, new TestAccount(2, "王伟", 1));
		this.map.Add(3, new TestAccount(3, "王芳", 0));
		LuaState luaState = new LuaState();
		luaState.Start();
		this.BindMap(luaState);
		luaState.DoString(this.script, "UseDictionary.cs");
		LuaFunction function = luaState.GetFunction("TestDict", true);
		function.BeginPCall();
		function.Push(this.map);
		function.PCall();
		function.EndPCall();
		function.Dispose();
		luaState.CheckTop();
		luaState.Dispose();
	}

	private void BindMap(LuaState L)
	{
		L.BeginModule(null);
		TestAccountWrap.Register(L);
		L.BeginModule("System");
		L.BeginModule("Collections");
		L.BeginModule("Generic");
		System_Collections_Generic_Dictionary_int_TestAccountWrap.Register(L);
		System_Collections_Generic_KeyValuePair_int_TestAccountWrap.Register(L);
		L.BeginModule("Dictionary");
		System_Collections_Generic_Dictionary_int_TestAccount_KeyCollectionWrap.Register(L);
		System_Collections_Generic_Dictionary_int_TestAccount_ValueCollectionWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.EndModule();
		L.EndModule();
		L.EndModule();
	}
}
