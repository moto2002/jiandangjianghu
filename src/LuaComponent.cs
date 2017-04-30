using LuaFramework;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LuaComponent : MonoBehaviour
{
	public LuaTable table;

	private LuaFunction _callback;

	private Dictionary<string, LuaFunction> buttons = new Dictionary<string, LuaFunction>();

	public static LuaTable Add(GameObject go, LuaTable tableClass)
	{
		LuaComponent luaComponent = go.AddComponent<LuaComponent>();
		luaComponent.table = tableClass;
		luaComponent.CallAwake();
		return luaComponent.table;
	}

	public static LuaTable Get(GameObject go, LuaTable table)
	{
		LuaComponent[] components = go.GetComponents<LuaComponent>();
		int num = components.Length;
		for (int i = 0; i < num; i++)
		{
			string a = table.ToString();
			string b = components[i].table.GetMetaTable().ToString();
			if (a == b)
			{
				return components[i].table;
			}
		}
		return null;
	}

	private void CallAwake()
	{
		LuaFunction luaFunction = this.table.GetLuaFunction("OnCreate");
		if (luaFunction != null)
		{
			luaFunction.Call(new object[]
			{
				this.table,
				base.gameObject
			});
		}
	}

	private void OnEnable()
	{
		if (this.table == null)
		{
			return;
		}
		LuaFunction luaFunction = this.table.GetLuaFunction("OnEnable");
		if (luaFunction != null)
		{
			luaFunction.Call(new object[]
			{
				this.table,
				base.gameObject
			});
		}
	}

	private void Start()
	{
		LuaFunction luaFunction = this.table.GetLuaFunction("Start");
		if (luaFunction != null)
		{
			luaFunction.Call(new object[]
			{
				this.table,
				base.gameObject
			});
		}
		if (this._callback != null)
		{
			this._callback.Call();
		}
	}

	private void Update()
	{
	}

	private void OnCollisionEnter(Collision collisionInfo)
	{
	}

	public void AddClick(GameObject go, LuaFunction luafunc)
	{
		if (go == null || luafunc == null)
		{
			return;
		}
		this.buttons.Add(go.name, luafunc);
		UIEventListener.Get(go).onClick = delegate(GameObject o)
		{
			LuaBehaviour.ExtendEventDeal(go, "luaComponent");
			luafunc.Call(new object[]
			{
				go
			});
		};
	}
}
