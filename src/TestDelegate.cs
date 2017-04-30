using LuaInterface;
using System;
using UnityEngine;

public class TestDelegate : MonoBehaviour
{
	private class TestEventListener_OnClick_Event : LuaDelegate
	{
		public TestEventListener_OnClick_Event(LuaFunction func) : base(func)
		{
		}

		public void Call(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class TestEventListener_VoidDelegate_Event : LuaDelegate
	{
		public TestEventListener_VoidDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public void Call(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private string script = "                              \r\n            function DoClick1(go)                \r\n                print('click1 gameObject is '..go.name)                    \r\n            end\r\n\r\n            function DoClick2(go)                \r\n                print('click2 gameObject is '..go.name)                              \r\n            end                       \r\n\r\n            function AddClick1(listener)       \r\n                if listener.onClick then\r\n                    listener.onClick = listener.onClick + DoClick1                                                    \r\n                else\r\n                    listener.onClick = DoClick1                      \r\n                end                \r\n            end\r\n\r\n            function AddClick2(listener)\r\n                if listener.onClick then\r\n                    listener.onClick = listener.onClick + DoClick2                      \r\n                else\r\n                    listener.onClick = DoClick2\r\n                end                \r\n            end\r\n\r\n            function SetClick1(listener)\r\n                if listener.onClick then\r\n                    listener.onClick:Destroy()\r\n                end\r\n\r\n                listener.onClick = DoClick1         \r\n            end\r\n\r\n            function RemoveClick1(listener)\r\n                if listener.onClick then\r\n                    listener.onClick = listener.onClick - DoClick1      \r\n                else\r\n                    print('empty delegate')\r\n                end\r\n            end\r\n\r\n            function RemoveClick2(listener)\r\n                if listener.onClick then\r\n                    listener.onClick = listener.onClick - DoClick2    \r\n                else\r\n                    print('empty delegate')                                \r\n                end\r\n            end\r\n\r\n            --测试重载问题\r\n            function TestOverride(listener)\r\n                listener:SetOnFinished(TestEventListener.OnClick(DoClick1))\r\n                listener:SetOnFinished(TestEventListener.VoidDelegate(DoClick2))\r\n            end\r\n\r\n            function TestEvent()\r\n                print('this is a event')\r\n            end\r\n\r\n            function AddEvent(listener)\r\n                listener.onClickEvent = listener.onClickEvent + TestEvent\r\n            end\r\n\r\n            function RemoveEvent(listener)\r\n                listener.onClickEvent = listener.onClickEvent - TestEvent\r\n            end\r\n\r\n            local t = {name = 'byself'}\r\n\r\n            function t:TestSelffunc()\r\n                print('callback with self: '..self.name)\r\n            end       \r\n\r\n            function AddSelfClick(listener)\r\n                if listener.onClick then\r\n                    listener.onClick = listener.onClick + TestEventListener.OnClick(t.TestSelffunc, t)\r\n                else\r\n                    listener.onClick = TestEventListener.OnClick(t.TestSelffunc, t)\r\n                end   \r\n            end     \r\n\r\n            function RemoveSelfClick(listener)\r\n                if listener.onClick then\r\n                    listener.onClick = listener.onClick - TestEventListener.OnClick(t.TestSelffunc, t)\r\n                else\r\n                    print('empty delegate')\r\n                end   \r\n            end\r\n    ";

	private LuaState state;

	private TestEventListener listener;

	private LuaFunction SetClick1;

	private LuaFunction AddClick1;

	private LuaFunction AddClick2;

	private LuaFunction RemoveClick1;

	private LuaFunction RemoveClick2;

	private LuaFunction TestOverride;

	private LuaFunction RemoveEvent;

	private LuaFunction AddEvent;

	private LuaFunction AddSelfClick;

	private LuaFunction RemoveSelfClick;

	private void Awake()
	{
		this.state = new LuaState();
		this.state.Start();
		LuaBinder.Bind(this.state);
		this.Bind(this.state);
		this.state.LogGC = true;
		this.state.DoString(this.script, "LuaState.cs");
		GameObject gameObject = new GameObject("TestGo");
		this.listener = (TestEventListener)gameObject.AddComponent(typeof(TestEventListener));
		this.SetClick1 = this.state.GetFunction("SetClick1", true);
		this.AddClick1 = this.state.GetFunction("AddClick1", true);
		this.AddClick2 = this.state.GetFunction("AddClick2", true);
		this.RemoveClick1 = this.state.GetFunction("RemoveClick1", true);
		this.RemoveClick2 = this.state.GetFunction("RemoveClick2", true);
		this.TestOverride = this.state.GetFunction("TestOverride", true);
		this.AddEvent = this.state.GetFunction("AddEvent", true);
		this.RemoveEvent = this.state.GetFunction("RemoveEvent", true);
		this.AddSelfClick = this.state.GetFunction("AddSelfClick", true);
		this.RemoveSelfClick = this.state.GetFunction("RemoveSelfClick", true);
	}

	private void Bind(LuaState L)
	{
		L.BeginModule(null);
		TestEventListenerWrap.Register(this.state);
		L.EndModule();
		DelegateFactory.dict.Add(typeof(TestEventListener.OnClick), new DelegateFactory.DelegateValue(TestDelegate.TestEventListener_OnClick));
		DelegateFactory.dict.Add(typeof(TestEventListener.VoidDelegate), new DelegateFactory.DelegateValue(TestDelegate.TestEventListener_VoidDelegate));
	}

	private void CallLuaFunction(LuaFunction func)
	{
		func.BeginPCall();
		func.Push(this.listener);
		func.PCall();
		func.EndPCall();
	}

	public static Delegate TestEventListener_OnClick(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new TestEventListener.OnClick(delegate
			{
			});
		}
		TestDelegate.TestEventListener_OnClick_Event testEventListener_OnClick_Event = new TestDelegate.TestEventListener_OnClick_Event(func);
		TestEventListener.OnClick onClick = new TestEventListener.OnClick(testEventListener_OnClick_Event.Call);
		testEventListener_OnClick_Event.method = onClick.Method;
		return onClick;
	}

	public static Delegate TestEventListener_VoidDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new TestEventListener.VoidDelegate(delegate
			{
			});
		}
		TestDelegate.TestEventListener_VoidDelegate_Event testEventListener_VoidDelegate_Event = new TestDelegate.TestEventListener_VoidDelegate_Event(func);
		TestEventListener.VoidDelegate voidDelegate = new TestEventListener.VoidDelegate(testEventListener_VoidDelegate_Event.Call);
		testEventListener_VoidDelegate_Event.method = voidDelegate.Method;
		return voidDelegate;
	}

	private void OnGUI()
	{
		if (GUI.Button(new Rect(10f, 10f, 120f, 40f), " = OnClick1"))
		{
			this.CallLuaFunction(this.SetClick1);
		}
		else if (GUI.Button(new Rect(10f, 60f, 120f, 40f), " + Click1"))
		{
			this.CallLuaFunction(this.AddClick1);
		}
		else if (GUI.Button(new Rect(10f, 110f, 120f, 40f), " + Click2"))
		{
			this.CallLuaFunction(this.AddClick2);
		}
		else if (GUI.Button(new Rect(10f, 160f, 120f, 40f), " - Click1"))
		{
			this.CallLuaFunction(this.RemoveClick1);
		}
		else if (GUI.Button(new Rect(10f, 210f, 120f, 40f), " - Click2"))
		{
			this.CallLuaFunction(this.RemoveClick2);
		}
		else if (GUI.Button(new Rect(10f, 260f, 120f, 40f), "+ Click1 in C#"))
		{
			LuaFunction function = this.state.GetFunction("DoClick1", true);
			TestEventListener.OnClick b = (TestEventListener.OnClick)DelegateFactory.CreateDelegate(typeof(TestEventListener.OnClick), function);
			TestEventListener expr_173 = this.listener;
			expr_173.onClick = (TestEventListener.OnClick)Delegate.Combine(expr_173.onClick, b);
		}
		else if (GUI.Button(new Rect(10f, 310f, 120f, 40f), " - Click1 in C#"))
		{
			LuaFunction function2 = this.state.GetFunction("DoClick1", true);
			this.listener.onClick = (TestEventListener.OnClick)DelegateFactory.RemoveDelegate(this.listener.onClick, function2);
			function2.Dispose();
		}
		else if (GUI.Button(new Rect(10f, 360f, 120f, 40f), "OnClick"))
		{
			if (this.listener.onClick != null)
			{
				this.listener.onClick(base.gameObject);
			}
			else
			{
				Debug.Log("empty delegate!!");
			}
		}
		else if (GUI.Button(new Rect(10f, 410f, 120f, 40f), "Override"))
		{
			this.CallLuaFunction(this.TestOverride);
		}
		else if (GUI.Button(new Rect(10f, 460f, 120f, 40f), "Force GC"))
		{
			this.state.LuaGC(LuaGCOptions.LUA_GCCOLLECT, 0);
			GC.Collect();
		}
		else if (GUI.Button(new Rect(10f, 510f, 120f, 40f), "event +"))
		{
			this.CallLuaFunction(this.AddEvent);
		}
		else if (GUI.Button(new Rect(10f, 560f, 120f, 40f), "event -"))
		{
			this.CallLuaFunction(this.RemoveEvent);
		}
		else if (GUI.Button(new Rect(10f, 610f, 120f, 40f), "event call"))
		{
			this.listener.OnClickEvent(base.gameObject);
		}
		else if (GUI.Button(new Rect(200f, 10f, 120f, 40f), "+self call"))
		{
			this.CallLuaFunction(this.AddSelfClick);
		}
		else if (GUI.Button(new Rect(200f, 60f, 120f, 40f), "-self call"))
		{
			this.CallLuaFunction(this.RemoveSelfClick);
		}
	}

	private void Update()
	{
		this.state.Collect();
		this.state.CheckTop();
	}

	private void SafeRelease(ref LuaFunction luaRef)
	{
		if (luaRef != null)
		{
			luaRef.Dispose();
			luaRef = null;
		}
	}

	private void OnDestroy()
	{
		this.SafeRelease(ref this.AddClick1);
		this.SafeRelease(ref this.AddClick2);
		this.SafeRelease(ref this.RemoveClick1);
		this.SafeRelease(ref this.RemoveClick2);
		this.SafeRelease(ref this.SetClick1);
		this.SafeRelease(ref this.TestOverride);
		this.state.Dispose();
		this.state = null;
	}
}
