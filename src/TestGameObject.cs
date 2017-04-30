using LuaInterface;
using System;
using UnityEngine;

public class TestGameObject : MonoBehaviour
{
	private string script = "                                                \r\n            local Color = UnityEngine.Color\r\n            local GameObject = UnityEngine.GameObject\r\n            local ParticleSystem = UnityEngine.ParticleSystem\r\n\r\n            function OnComplete()\r\n                print('OnComplete CallBack')\r\n            end                       \r\n            \r\n            local go = GameObject('go', typeof(UnityEngine.Camera))\r\n            go:AddComponent(typeof(ParticleSystem))\r\n            local node = go.transform\r\n            node.position = Vector3.one      \r\n            print('gameObject is: '..tostring(go))                 \r\n            --go.transform:DOPath({Vector3.zero, Vector3.one * 10}, 1, DG.Tweening.PathType.Linear, DG.Tweening.PathMode.Full3D, 10, nil)\r\n            --go.transform:DORotate(Vector3(0,0,360), 2, DG.Tweening.RotateMode.FastBeyond360):OnComplete(OnComplete)\r\n            GameObject.Destroy(go, 2)                  \r\n            print('delay destroy gameobject is: '..go.name)                                           \r\n        ";

	private LuaState lua;

	private void Start()
	{
		this.lua = new LuaState();
		this.lua.LogGC = true;
		this.lua.Start();
		LuaBinder.Bind(this.lua);
		this.lua.DoString(this.script, "TestGameObject.cs");
	}

	private void Update()
	{
		this.lua.CheckTop();
		this.lua.Collect();
	}

	private void OnApplicationQuit()
	{
		this.lua.Dispose();
		this.lua = null;
	}
}
