using LuaInterface;
using System;
using System.IO;

namespace LuaFramework
{
	public class LuaManager : Manager
	{
		private LuaState lua;

		private LuaLoader loader;

		private LuaLooper loop;

		private new void Awake()
		{
			this.loader = new LuaLoader();
			this.lua = new LuaState();
			this.OpenLibs();
			this.lua.LuaSetTop(0);
			LuaBinder.Bind(this.lua);
			LuaCoroutine.Register(this.lua, this);
		}

		public void InitStart()
		{
			this.InitLuaPath();
			this.InitLuaBundle();
			this.lua.Start();
			this.StartMain();
			this.StartLooper();
		}

		private void StartLooper()
		{
			this.loop = base.gameObject.AddComponent<LuaLooper>();
			this.loop.luaState = this.lua;
		}

		protected void OpenCJson()
		{
			this.lua.LuaGetField(LuaIndexes.LUA_REGISTRYINDEX, "_LOADED");
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_cjson));
			this.lua.LuaSetField(-2, "cjson");
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_cjson_safe));
			this.lua.LuaSetField(-2, "cjson.safe");
		}

		private void StartMain()
		{
			this.lua.DoFile("Main.lua");
			LuaFunction function = this.lua.GetFunction("Main", true);
			function.Call();
			function.Dispose();
		}

		private void OpenLibs()
		{
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_pb));
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_sproto_core));
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_protobuf_c));
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_lpeg));
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_bit));
			this.lua.OpenLibs(new LuaCSFunction(LuaDLL.luaopen_socket_core));
			this.OpenCJson();
		}

		private void InitLuaPath()
		{
			this.lua.AddSearchPath(Util.DataPath + "lua");
		}

		private void InitLuaBundle()
		{
			string path = Util.DataPath + "lua/";
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			FileInfo[] files = directoryInfo.GetFiles("*.unity3d", SearchOption.AllDirectories);
			FileInfo[] array = files;
			for (int i = 0; i < array.Length; i++)
			{
				FileInfo fileInfo = array[i];
				string text = fileInfo.FullName.Replace('\\', '/');
				string oldValue = Util.DataPath.Replace('\\', '/');
				string bundleName = text.Replace(oldValue, string.Empty);
				this.loader.AddBundle(bundleName);
			}
		}

		public object[] DoFile(string filename)
		{
			return this.lua.DoFile(filename);
		}

		public object[] CallFunction(string funcName, params object[] args)
		{
			LuaFunction function = this.lua.GetFunction(funcName, true);
			if (function != null)
			{
				return function.Call(args);
			}
			return null;
		}

		public void LuaGC()
		{
			this.lua.LuaGC(LuaGCOptions.LUA_GCCOLLECT, 0);
		}

		public void Close()
		{
			if (this.loop != null)
			{
				this.loop.Destroy();
			}
			this.loop = null;
			if (this.lua != null)
			{
				this.lua.Dispose();
			}
			this.lua = null;
			this.loader = null;
		}
	}
}
