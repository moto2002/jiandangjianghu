using LuaInterface;
using System;
using UnityEngine;

public class TestOutArg : MonoBehaviour
{
	private string script = "                    \r\n            print('start')\r\n            local box = UnityEngine.BoxCollider\r\n                                                                            \r\n            function TestPick(ray)                                                                  \r\n                local _layer = 2 ^ LayerMask.NameToLayer('Default')\r\n                local flag, hit = UnityEngine.Physics.Raycast(ray, nil, 5000, _layer)                          \r\n                --local flag, hit = UnityEngine.Physics.Raycast(ray, RaycastHit.out, 5000, _layer)                \r\n                \r\n                if flag then\r\n                    print('pick from lua, point: '..tostring(hit.point))                                        \r\n                end\r\n            end\r\n        ";

	private LuaState state;

	private LuaFunction func;

	private void Start()
	{
		new LuaResLoader();
		this.state = new LuaState();
		LuaBinder.Bind(this.state);
		this.state.Start();
		this.state.DoString(this.script, "TestOutArg.cs");
		this.func = this.state.GetFunction("TestPick", true);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Camera main = Camera.main;
			Ray ray = main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			bool flag = Physics.Raycast(ray, out raycastHit, 5000f, 1 << LayerMask.NameToLayer("Default"));
			if (flag)
			{
				Debugger.Log("pick from c#, point: [{0}, {1}, {2}]", raycastHit.point.x, raycastHit.point.y, raycastHit.point.z);
			}
			this.func.BeginPCall();
			this.func.Push(ray);
			this.func.PCall();
			this.func.EndPCall();
		}
		this.state.CheckTop();
		this.state.Collect();
	}

	private void OnDestroy()
	{
		this.func.Dispose();
		this.func = null;
		this.state.Dispose();
		this.state = null;
	}
}
