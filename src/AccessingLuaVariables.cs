using LuaInterface;
using System;
using UnityEngine;

public class AccessingLuaVariables : MonoBehaviour
{
	private string script = "\r\n            print('Objs2Spawn is: '..Objs2Spawn)\r\n            var2read = 42\r\n            varTable = {1,2,3,4,5}\r\n            varTable.default = 1\r\n            varTable.map = {}\r\n            varTable.map.name = 'map'\r\n            \r\n            meta = {name = 'meta'}\r\n            setmetatable(varTable, meta)\r\n            \r\n            function TestFunc(strs)\r\n                print('get func by variable')\r\n            end\r\n        ";

	private void Start()
	{
		LuaState luaState = new LuaState();
		luaState.Start();
		luaState["Objs2Spawn"] = 5;
		luaState.DoString(this.script, "LuaState.cs");
		Debugger.Log("Read var from lua: {0}", luaState["var2read"]);
		Debugger.Log("Read table var from lua: {0}", luaState["varTable.default"]);
		LuaFunction luaFunction = luaState["TestFunc"] as LuaFunction;
		luaFunction.Call();
		luaFunction.Dispose();
		LuaTable table = luaState.GetTable("varTable", true);
		Debugger.Log("Read varTable from lua, default: {0} name: {1}", table["default"], table["map.name"]);
		table["map.name"] = "new";
		Debugger.Log("Modify varTable name: {0}", table["map.name"]);
		table.AddTable("newmap");
		LuaTable luaTable = (LuaTable)table["newmap"];
		luaTable["name"] = "table1";
		Debugger.Log("varTable.newmap name: {0}", luaTable["name"]);
		luaTable.Dispose();
		luaTable = table.GetMetaTable();
		if (luaTable != null)
		{
			Debugger.Log("varTable metatable name: {0}", luaTable["name"]);
		}
		object[] array = table.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			Debugger.Log("varTable[{0}], is {1}", i, array[i]);
		}
		table.Dispose();
		luaState.CheckTop();
		luaState.Dispose();
	}
}
