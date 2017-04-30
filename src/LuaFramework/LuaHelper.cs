using LuaInterface;
using System;
using System.Reflection;
using UnityEngine;

namespace LuaFramework
{
	public static class LuaHelper
	{
		public static Type GetType(string classname)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Type type = executingAssembly.GetType(classname);
			if (type == null)
			{
				type = executingAssembly.GetType(classname);
			}
			return type;
		}

		public static PanelManager GetPanelManager()
		{
			return AppFacade.Instance.GetManager<PanelManager>("PanelManager");
		}

		public static ResourceManager GetResManager()
		{
			return AppFacade.Instance.GetManager<ResourceManager>("ResourceManager");
		}

		public static NetworkManager GetNetManager()
		{
			return AppFacade.Instance.GetManager<NetworkManager>("NetworkManager");
		}

		public static SoundManager GetSoundManager()
		{
			return AppFacade.Instance.GetManager<SoundManager>("SoundManager");
		}

		public static TimerManager GetTimerManager()
		{
			return AppFacade.Instance.GetManager<TimerManager>("TimerManager");
		}

		public static GameManager GetGameManager()
		{
			return AppFacade.Instance.GetManager<GameManager>("GameManager");
		}

		public static Action Action(LuaFunction func)
		{
			return delegate
			{
				func.Call();
			};
		}

		public static UIEventListener.VoidDelegate VoidDelegate(LuaFunction func)
		{
			return delegate(GameObject go)
			{
				func.Call(new object[]
				{
					go
				});
			};
		}

		public static void OnCallLuaFunc(LuaByteBuffer data, LuaFunction func)
		{
			if (func != null)
			{
				func.Call(new object[]
				{
					data
				});
			}
			Debug.LogWarning("OnCallLuaFunc length:>>" + data.buffer.Length);
		}

		public static void OnJsonCallFunc(string data, LuaFunction func)
		{
			Debug.LogWarning(string.Concat(new object[]
			{
				"OnJsonCallback data:>>",
				data,
				" lenght:>>",
				data.Length
			}));
			if (func != null)
			{
				func.Call(new object[]
				{
					data
				});
			}
		}
	}
}
