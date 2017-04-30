using LuaInterface;
using System;
using System.Collections.Generic;

public class UseList : LuaClient
{
	private string script = "\r\n            function Exist2(v)\r\n                return v == 2\r\n            end\r\n\r\n            function IsEven(v)\r\n                return v % 2 == 0\r\n            end\r\n\r\n            function NotExist(v)\r\n                return false\r\n            end\r\n\r\n            function Compare(a, b)\r\n                if a > b then \r\n                    return 1\r\n                elseif a == b then\r\n                    return 0\r\n                else\r\n                    return -1\r\n                end\r\n            end\r\n\r\n            function Test(list, list1)        \r\n                list:Add(123)\r\n                print('Add result: list[0] is '..list[0])\r\n                list:AddRange(list1)\r\n                print(string.format('AddRange result: list[1] is %d, list[2] is %d', list[1], list[2]))\r\n\r\n                local const = list:AsReadOnly()\r\n                print('AsReadOnley:'..const[0])    \r\n\r\n                index = const:IndexOf(123)\r\n                \r\n                if index == 0 then\r\n                    print('const IndexOf is ok')\r\n                end\r\n\r\n                local pos = list:BinarySearch(1)\r\n                print('BinarySearch 1 result is: '..pos)\r\n\r\n                if list:Contains(123) then\r\n                    print('list Contain 123')\r\n                else\r\n                    error('list Contains result fail')\r\n                end\r\n\r\n                if list:Exists(Exist2) then\r\n                    print('list exists 2')\r\n                else\r\n                    error('list exists result fail')\r\n                end                    \r\n                \r\n                if list:Find(Exist2) then\r\n                    print('list Find is ok')\r\n                else\r\n                    print('list Find error')\r\n                end\r\n\r\n                local fa = list:FindAll(IsEven)\r\n\r\n                if fa.Count == 2 then\r\n                    print('FindAll is ok')\r\n                end\r\n\r\n                --注意推导后的委托声明必须注册, 这里是System.Predicate<int>\r\n                local index = list:FindIndex(System.Predicate_int(Exist2))\r\n\r\n                if index == 2 then\r\n                    print('FindIndex is ok')\r\n                end\r\n\r\n                index = list:FindLastIndex(System.Predicate_int(Exist2))\r\n\r\n                if index == 2 then\r\n                    print('FindLastIndex is ok')\r\n                end                \r\n                \r\n                index = list:IndexOf(123)\r\n                \r\n                if index == 0 then\r\n                    print('IndexOf is ok')\r\n                end\r\n\r\n                index = list:LastIndexOf(123)\r\n                \r\n                if index == 0 then\r\n                    print('LastIndexOf is ok')\r\n                end\r\n\r\n                list:Remove(123)\r\n\r\n                if list[0] ~= 123 then\r\n                    print('Remove is ok')\r\n                end\r\n\r\n                list:Insert(0, 123)\r\n\r\n                if list[0] == 123 then\r\n                    print('Insert is ok')\r\n                end\r\n\r\n                list:RemoveAt(0)\r\n\r\n                if list[0] ~= 123 then\r\n                    print('RemoveAt is ok')\r\n                end\r\n\r\n                list:Insert(0, 123)\r\n                list:ForEach(function(v) print('foreach: '..v) end)\r\n                local count = list.Count      \r\n\r\n                list:Sort(System.Comparison_int(Compare))\r\n                print('--------------sort list over----------------------')\r\n                                \r\n                for i = 0, count - 1 do\r\n                    print('for:'..list[i])\r\n                end\r\n\r\n                list:Clear()\r\n                print('list Clear not count is '..list.Count)\r\n            end\r\n        ";

	protected override LuaFileUtils InitLoader()
	{
		return new LuaResLoader();
	}

	protected override void CallMain()
	{
	}

	protected override void OnLoadFinished()
	{
		base.OnLoadFinished();
		this.luaState.DoString(this.script, "UseList.cs");
		List<int> list = new List<int>();
		list.Add(1);
		list.Add(2);
		list.Add(4);
		LuaFunction function = this.luaState.GetFunction("Test", true);
		function.BeginPCall();
		function.Push(new List<int>());
		function.Push(list);
		function.PCall();
		function.EndPCall();
		function.Dispose();
	}
}
