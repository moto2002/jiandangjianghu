using LuaInterface;
using System;
using UnityEngine;

public class TestInherit : MonoBehaviour
{
	private string script = "  LuaTransform = \r\n        {                          \r\n        }                                                   \r\n\r\n        function LuaTransform.Extend(u)         \r\n            local t = {}                        \r\n            local _position = u.position      \r\n            tolua.setpeer(u, t)     \r\n\r\n            t.__index = t\r\n            local get = tolua.initget(t)\r\n            local set = tolua.initset(t)   \r\n\r\n            local _base = u.base            \r\n\r\n            --重写同名属性获取        \r\n            get.position = function(self)                              \r\n                return _position                \r\n            end            \r\n\r\n            --重写同名属性设置\r\n            set.position = function(self, v)                 \t                                            \r\n                if _position ~= v then         \r\n                    _position = v                    \r\n                    _base.position = v                                                                      \t            \r\n                end\r\n            end\r\n\r\n            --重写同名函数\r\n            function t:Translate(...)            \r\n\t            print('child Translate')\r\n\t            _base:Translate(...)                   \r\n            end    \r\n                           \r\n            return u\r\n        end\r\n        \r\n        \r\n        --既保证支持继承函数，又支持go.transform == transform 这样的比较\r\n        function Test(node)        \r\n            local v = Vector3.one           \r\n            local transform = LuaTransform.Extend(node)  \r\n            --local transform = node                                                  \r\n\r\n            local t = os.clock()            \r\n            for i = 1, 200000 do\r\n                transform.position = transform.position\r\n            end\r\n            print('LuaTransform get set cost', os.clock() - t)\r\n\r\n            transform:Translate(1,1,1)                                                                     \r\n                        \r\n            local child = transform:FindChild('child')\r\n            print('child is: ', tostring(child))\r\n            \r\n            if child.parent == transform then            \r\n                print('LuaTransform compare to userdata transform is ok')\r\n            end\r\n\r\n            transform.xyz = 123\r\n            transform.xyz = 456\r\n            print('extern field xyz is: '.. transform.xyz)\r\n        end\r\n        ";

	private LuaState lua;

	private void Start()
	{
		this.lua = new LuaState();
		this.lua.Start();
		LuaBinder.Bind(this.lua);
		this.lua.DoString(this.script, "TestInherit.cs");
		float num = Time.realtimeSinceStartup;
		for (int i = 0; i < 200000; i++)
		{
			Vector3 position = base.transform.position;
			base.transform.position = position;
		}
		num = Time.realtimeSinceStartup - num;
		Debugger.Log("c# Transform get set cost time: " + num);
		LuaFunction function = this.lua.GetFunction("Test", true);
		function.BeginPCall();
		function.Push(base.transform);
		function.PCall();
		function.EndPCall();
		this.lua.CheckTop();
		this.lua.Dispose();
		this.lua = null;
	}
}
