using LuaInterface;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class TestLuaStack : MonoBehaviour
{
	public GameObject go;

	public GameObject go2;

	public static LuaFunction show = null;

	public static LuaFunction testRay = null;

	public static LuaFunction showStack = null;

	public static LuaFunction test4 = null;

	private static GameObject testGo = null;

	private string tips = string.Empty;

	public static TestLuaStack Instance = null;

	private LuaState state;

	public TextAsset text;

	private static Action TestDelegate = delegate
	{
	};

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Test1(IntPtr L)
	{
		try
		{
			TestLuaStack.show.BeginPCall();
			TestLuaStack.show.PCall();
			TestLuaStack.show.EndPCall();
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, null);
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int PushLuaError(IntPtr L)
	{
		try
		{
			TestLuaStack.testRay.BeginPCall();
			TestLuaStack.testRay.Push(TestLuaStack.Instance);
			TestLuaStack.testRay.PCall();
			TestLuaStack.testRay.EndPCall();
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, null);
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Test3(IntPtr L)
	{
		try
		{
			TestLuaStack.testRay.BeginPCall();
			TestLuaStack.testRay.PCall();
			TestLuaStack.testRay.CheckRay();
			TestLuaStack.testRay.EndPCall();
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, null);
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Test4(IntPtr L)
	{
		try
		{
			TestLuaStack.show.BeginPCall();
			TestLuaStack.show.PCall();
			TestLuaStack.show.EndPCall();
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, null);
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Test5(IntPtr L)
	{
		try
		{
			TestLuaStack.test4.BeginPCall();
			TestLuaStack.test4.PCall();
			bool flag = TestLuaStack.test4.CheckBoolean();
			flag = !flag;
			TestLuaStack.test4.EndPCall();
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, null);
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Test6(IntPtr L)
	{
		int result;
		try
		{
			throw new LuaException("this a lua exception", null, 1);
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TestOutOfBound(IntPtr L)
	{
		int result;
		try
		{
			Transform transform = TestLuaStack.testGo.transform;
			Transform child = transform.GetChild(20);
			ToLua.Push(L, child);
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TestArgError(IntPtr L)
	{
		try
		{
			LuaDLL.luaL_typerror(L, 1, "number", null);
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, null);
		}
		return 0;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TestTableInCo(IntPtr L)
	{
		int result;
		try
		{
			LuaTable luaTable = ToLua.CheckLuaTable(L, 1);
			string obj = (string)luaTable["name"];
			ToLua.Push(L, obj);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TestCycle(IntPtr L)
	{
		int result;
		try
		{
			LuaState luaState = LuaState.Get(L);
			LuaFunction function = luaState.GetFunction("TestCycle", true);
			int num = (int)LuaDLL.luaL_checknumber(L, 1);
			if (num <= 2)
			{
				LuaDLL.lua_pushnumber(L, 1.0);
			}
			else
			{
				function.BeginPCall();
				function.Push(num - 1);
				function.PCall();
				int num2 = (int)function.CheckNumber();
				function.EndPCall();
				function.BeginPCall();
				function.Push(num - 2);
				function.PCall();
				int num3 = (int)function.CheckNumber();
				function.EndPCall();
				LuaDLL.lua_pushnumber(L, (double)(num2 + num3));
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TestNull(IntPtr L)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			ToLua.Push(L, gameObject.name);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TestAddComponent(IntPtr L)
	{
		int result;
		try
		{
			GameObject gameObject = (GameObject)ToLua.CheckUnityObject(L, 1, typeof(GameObject));
			gameObject.AddComponent<TestInstantiate2>();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	private static void TestMul1()
	{
		throw new Exception("multi stack error");
	}

	private static void TestMul0()
	{
		TestLuaStack.TestMul1();
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int TestMulStack(IntPtr L)
	{
		int result;
		try
		{
			TestLuaStack.TestMul0();
			result = 0;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	private void OnSendMsg()
	{
		try
		{
			LuaFunction function = this.state.GetFunction("TestStack.Test6", true);
			function.BeginPCall();
			function.PCall();
			function.EndPCall();
		}
		catch (Exception e)
		{
			this.state.ThrowLuaException(e);
		}
	}

	private void Awake()
	{
		Application.logMessageReceived += new Application.LogCallback(this.ShowTips);
		TestLuaStack.Instance = this;
		new LuaResLoader();
		TestLuaStack.testGo = base.gameObject;
		this.state = new LuaState();
		this.state.Start();
		LuaBinder.Bind(this.state);
		this.state.BeginModule(null);
		this.state.RegFunction("TestArgError", new LuaCSFunction(TestLuaStack.TestArgError));
		this.state.RegFunction("TestTableInCo", new LuaCSFunction(TestLuaStack.TestTableInCo));
		this.state.RegFunction("TestCycle", new LuaCSFunction(TestLuaStack.TestCycle));
		this.state.RegFunction("TestNull", new LuaCSFunction(TestLuaStack.TestNull));
		this.state.RegFunction("TestAddComponent", new LuaCSFunction(TestLuaStack.TestAddComponent));
		this.state.RegFunction("TestOutOfBound", new LuaCSFunction(TestLuaStack.TestOutOfBound));
		this.state.RegFunction("TestMulStack", new LuaCSFunction(TestLuaStack.TestMulStack));
		this.state.BeginStaticLibs("TestStack");
		this.state.RegFunction("Test1", new LuaCSFunction(TestLuaStack.Test1));
		this.state.RegFunction("PushLuaError", new LuaCSFunction(TestLuaStack.PushLuaError));
		this.state.RegFunction("Test3", new LuaCSFunction(TestLuaStack.Test3));
		this.state.RegFunction("Test4", new LuaCSFunction(TestLuaStack.Test4));
		this.state.RegFunction("Test5", new LuaCSFunction(TestLuaStack.Test5));
		this.state.RegFunction("Test6", new LuaCSFunction(TestLuaStack.Test6));
		this.state.EndStaticLibs();
		this.state.EndModule();
		this.state.Require("TestErrorStack");
		TestLuaStack.show = this.state.GetFunction("Show", true);
		TestLuaStack.testRay = this.state.GetFunction("TestRay", true);
		TestLuaStack.showStack = this.state.GetFunction("ShowStack", true);
		TestLuaStack.test4 = this.state.GetFunction("Test4", true);
		TestLuaStack.TestDelegate = (Action)Delegate.Combine(TestLuaStack.TestDelegate, new Action(this.TestD1));
		TestLuaStack.TestDelegate = (Action)Delegate.Combine(TestLuaStack.TestDelegate, new Action(this.TestD2));
	}

	private void Update()
	{
		this.state.CheckTop();
	}

	private void OnApplicationQuit()
	{
		Application.logMessageReceived -= new Application.LogCallback(this.ShowTips);
		this.state.Dispose();
		this.state = null;
	}

	private void ShowTips(string msg, string stackTrace, LogType type)
	{
		this.tips += msg;
		this.tips += "\r\n";
		if (type == LogType.Error || type == LogType.Exception)
		{
			this.tips += stackTrace;
		}
	}

	private void TestD1()
	{
		Debugger.Log("delegate 1");
		TestLuaStack.TestDelegate = (Action)Delegate.Remove(TestLuaStack.TestDelegate, new Action(this.TestD2));
	}

	private void TestD2()
	{
		Debugger.Log("delegate 2");
	}

	private void OnGUI()
	{
		GUI.Label(new Rect((float)(Screen.width / 2 - 300), (float)(Screen.height / 2 - 150), 800f, 400f), this.tips);
		if (GUI.Button(new Rect(10f, 10f, 120f, 40f), "Error1"))
		{
			this.tips = string.Empty;
			TestLuaStack.showStack.BeginPCall();
			TestLuaStack.showStack.Push(this.go);
			TestLuaStack.showStack.PCall();
			TestLuaStack.showStack.EndPCall();
			TestLuaStack.showStack.Dispose();
			TestLuaStack.showStack = null;
		}
		else if (GUI.Button(new Rect(10f, 60f, 120f, 40f), "Instantiate Error"))
		{
			this.tips = string.Empty;
			LuaFunction function = this.state.GetFunction("Instantiate", true);
			function.BeginPCall();
			function.Push(this.go);
			function.PCall();
			function.EndPCall();
			function.Dispose();
		}
		else if (GUI.Button(new Rect(10f, 110f, 120f, 40f), "Check Error"))
		{
			this.tips = string.Empty;
			LuaFunction function2 = this.state.GetFunction("TestRay", true);
			function2.BeginPCall();
			function2.PCall();
			function2.CheckRay();
			function2.EndPCall();
			function2.Dispose();
		}
		else if (GUI.Button(new Rect(10f, 160f, 120f, 40f), "Push Error"))
		{
			this.tips = string.Empty;
			LuaFunction function3 = this.state.GetFunction("TestRay", true);
			function3.BeginPCall();
			function3.Push(TestLuaStack.Instance);
			function3.PCall();
			function3.EndPCall();
			function3.Dispose();
		}
		else if (GUI.Button(new Rect(10f, 210f, 120f, 40f), "LuaPushError"))
		{
			this.tips = string.Empty;
			LuaFunction function4 = this.state.GetFunction("PushLuaError", true);
			function4.BeginPCall();
			function4.PCall();
			function4.EndPCall();
			function4.Dispose();
		}
		else if (GUI.Button(new Rect(10f, 260f, 120f, 40f), "Check Error"))
		{
			this.tips = string.Empty;
			LuaFunction function5 = this.state.GetFunction("Test5", true);
			function5.BeginPCall();
			function5.PCall();
			function5.EndPCall();
			function5.Dispose();
		}
		else if (GUI.Button(new Rect(10f, 310f, 120f, 40f), "Test Resume"))
		{
			this.tips = string.Empty;
			LuaFunction function6 = this.state.GetFunction("Test6", true);
			function6.BeginPCall();
			function6.PCall();
			function6.EndPCall();
			function6.Dispose();
		}
		else if (GUI.Button(new Rect(10f, 360f, 120f, 40f), "out of bound"))
		{
			this.tips = string.Empty;
			LuaFunction function7 = this.state.GetFunction("TestOutOfBound", true);
			function7.BeginPCall();
			function7.PCall();
			function7.EndPCall();
			function7.Dispose();
		}
		else if (GUI.Button(new Rect(10f, 410f, 120f, 40f), "TestArgError"))
		{
			this.tips = string.Empty;
			LuaFunction function8 = this.state.GetFunction("Test8", true);
			function8.BeginPCall();
			function8.PCall();
			function8.EndPCall();
			function8.Dispose();
		}
		else if (GUI.Button(new Rect(10f, 460f, 120f, 40f), "TestFuncDispose"))
		{
			this.tips = string.Empty;
			LuaFunction function9 = this.state.GetFunction("Test8", true);
			function9.Dispose();
			function9.BeginPCall();
			function9.PCall();
			function9.EndPCall();
			function9.Dispose();
		}
		else if (GUI.Button(new Rect(10f, 510f, 120f, 40f), "SendMessage"))
		{
			this.tips = string.Empty;
			base.gameObject.SendMessage("OnSendMsg");
		}
		else if (GUI.Button(new Rect(10f, 560f, 120f, 40f), "SendMessageInLua"))
		{
			LuaFunction function10 = this.state.GetFunction("SendMsgError", true);
			function10.BeginPCall();
			function10.Push(base.gameObject);
			function10.PCall();
			function10.EndPCall();
			function10.Dispose();
		}
		else if (GUI.Button(new Rect(10f, 610f, 120f, 40f), "AddComponent"))
		{
			this.tips = string.Empty;
			LuaFunction function11 = this.state.GetFunction("TestAddComponent", true);
			function11.BeginPCall();
			function11.Push(base.gameObject);
			function11.PCall();
			function11.EndPCall();
			function11.Dispose();
		}
		else if (GUI.Button(new Rect(210f, 10f, 120f, 40f), "TableGetSet"))
		{
			this.tips = string.Empty;
			LuaTable table = this.state.GetTable("testev", true);
			int newTop = this.state.LuaGetTop();
			try
			{
				this.state.Push(table);
				this.state.LuaGetField(-1, "Add");
				LuaFunction luaFunction = this.state.CheckLuaFunction(-1);
				if (luaFunction != null)
				{
					luaFunction.Call();
					luaFunction.Dispose();
				}
				this.state.LuaPop(1);
				this.state.Push(123456);
				this.state.LuaSetField(-2, "value");
				this.state.LuaGetField(-1, "value");
				int num = (int)this.state.LuaCheckNumber(-1);
				Debugger.Log("value is: " + num);
				this.state.LuaPop(1);
				this.state.Push("Add");
				this.state.LuaGetTable(-2);
				luaFunction = this.state.CheckLuaFunction(-1);
				if (luaFunction != null)
				{
					luaFunction.Call();
					luaFunction.Dispose();
				}
				this.state.LuaPop(1);
				this.state.Push("look");
				this.state.Push(456789);
				this.state.LuaSetTable(-3);
				this.state.LuaGetField(-1, "look");
				num = (int)this.state.LuaCheckNumber(-1);
				Debugger.Log("look: " + num);
			}
			catch (Exception ex)
			{
				this.state.LuaSetTop(newTop);
				throw ex;
			}
			this.state.LuaSetTop(newTop);
		}
		else if (GUI.Button(new Rect(210f, 60f, 120f, 40f), "TestTableInCo"))
		{
			this.tips = string.Empty;
			LuaFunction function12 = this.state.GetFunction("TestCoTable", true);
			function12.BeginPCall();
			function12.PCall();
			function12.EndPCall();
			function12.Dispose();
		}
		else if (GUI.Button(new Rect(210f, 110f, 120f, 40f), "Instantiate2 Error"))
		{
			this.tips = string.Empty;
			LuaFunction function13 = this.state.GetFunction("Instantiate", true);
			function13.BeginPCall();
			function13.Push(this.go2);
			function13.PCall();
			function13.EndPCall();
			function13.Dispose();
		}
		else if (GUI.Button(new Rect(210f, 160f, 120f, 40f), "Instantiate3 Error"))
		{
			this.tips = string.Empty;
			UnityEngine.Object.Instantiate<GameObject>(this.go2);
		}
		else if (GUI.Button(new Rect(210f, 210f, 120f, 40f), "TestCycle"))
		{
			this.tips = string.Empty;
			int num2 = 20;
			LuaFunction function14 = this.state.GetFunction("TestCycle", true);
			function14.BeginPCall();
			function14.Push(num2);
			function14.PCall();
			int num3 = (int)function14.CheckNumber();
			function14.EndPCall();
			Debugger.Log("Fib({0}) is {1}", num2, num3);
		}
		else if (GUI.Button(new Rect(210f, 260f, 120f, 40f), "TestNull"))
		{
			this.tips = string.Empty;
			Action action = delegate
			{
				LuaFunction function16 = this.state.GetFunction("TestNull", true);
				function16.BeginPCall();
				function16.PushObject(null);
				function16.PCall();
				function16.EndPCall();
			};
			base.StartCoroutine(this.TestCo(action));
		}
		else if (GUI.Button(new Rect(210f, 310f, 120f, 40f), "TestMulti"))
		{
			this.tips = string.Empty;
			LuaFunction function15 = this.state.GetFunction("TestMulStack", true);
			function15.BeginPCall();
			function15.PushObject(null);
			function15.PCall();
			function15.EndPCall();
		}
	}

	[DebuggerHidden]
	private IEnumerator TestCo(Action action)
	{
		TestLuaStack.<TestCo>c__Iterator29 <TestCo>c__Iterator = new TestLuaStack.<TestCo>c__Iterator29();
		<TestCo>c__Iterator.action = action;
		<TestCo>c__Iterator.<$>action = action;
		return <TestCo>c__Iterator;
	}
}
