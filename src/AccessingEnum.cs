using LuaInterface;
using System;
using UnityEngine;

public class AccessingEnum : MonoBehaviour
{
	private string script = "\r\n            space = nil\r\n\r\n            function TestEnum(e)        \r\n                print('Enum is:'..tostring(e))        \r\n\r\n                if space:ToInt() == 0 then\r\n                    print('enum ToInt() is ok')                \r\n                end\r\n\r\n                if not space:Equals(0) then\r\n                    print('enum compare int is ok')                \r\n                end\r\n\r\n                if space == e then\r\n                    print('enum compare enum is ok')\r\n                end\r\n\r\n                local s = UnityEngine.Space.IntToEnum(0)\r\n\r\n                if space == s then\r\n                    print('IntToEnum change type is ok')\r\n                end\r\n            end\r\n\r\n            function ChangeLightType(light, type)\r\n                print('change light type to Directional')\r\n                light.type = UnityEngine.LightType.Directional\r\n            end\r\n        ";

	private void Start()
	{
		LuaState luaState = new LuaState();
		luaState.Start();
		LuaBinder.Bind(luaState);
		luaState.DoString(this.script, "LuaState.cs");
		luaState["space"] = Space.World;
		LuaFunction function = luaState.GetFunction("TestEnum", true);
		function.BeginPCall();
		function.Push(Space.World);
		function.PCall();
		function.EndPCall();
		function.Dispose();
		GameObject gameObject = GameObject.Find("/Light");
		Light component = gameObject.GetComponent<Light>();
		function = luaState.GetFunction("ChangeLightType", true);
		function.BeginPCall();
		function.Push(component);
		function.Push(LightType.Directional);
		function.PCall();
		function.EndPCall();
		function.Dispose();
		luaState.CheckTop();
		luaState.Dispose();
	}
}
