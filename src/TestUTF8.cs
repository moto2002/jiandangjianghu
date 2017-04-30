using LuaInterface;
using System;

public class TestUTF8 : LuaClient
{
	private string script = "\r\n    local utf8 = utf8\r\n\r\n    function Test()        \r\n\t    local l1 = utf8.len('你好')\r\n        local l2 = utf8.len('こんにちは')\r\n        print('chinese string len is: '..l1..' japanese len: '..l2)     \r\n\r\n        local s = '遍历字符串'                                        \r\n\r\n        for i in utf8.byte_indices(s) do            \r\n            local next = utf8.next(s, i)                   \r\n            print(s:sub(i, next and next -1))\r\n        end   \r\n\r\n        local s1 = '天下风云出我辈'        \r\n        print('风云 count is: '..utf8.count(s1, '风云'))\r\n        s1 = s1:gsub('风云', '風雲')\r\n\r\n        local function replace(s, i, j, repl_char)            \r\n\t        if s:sub(i, j) == '辈' then\r\n\t\t        return repl_char            \r\n\t        end\r\n        end\r\n\r\n        print(utf8.replace(s1, replace, '輩'))\r\n    end\r\n";

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
		this.luaState.DoString(this.script, "LuaState.cs");
		LuaFunction function = this.luaState.GetFunction("Test", true);
		function.Call();
		function.Dispose();
	}
}
