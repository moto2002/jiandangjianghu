using LuaFramework;
using System;
using UnityEngine;

public class StartUpCommand : ControllerCommand
{
	public override void Execute(IMessage message)
	{
		if (!Util.CheckEnvironment())
		{
			return;
		}
		GameObject gameObject = GameObject.Find("GlobalGenerator");
		if (gameObject != null)
		{
			gameObject.AddComponent<AppView>();
		}
		AppFacade.Instance.RegisterCommand("DispatchMessage", typeof(SocketCommand));
		AppFacade.Instance.AddManager<LuaManager>("LuaScriptMgr");
		AppFacade.Instance.AddManager<PanelManager>("PanelManager");
		AppFacade.Instance.AddManager<SoundManager>("SoundManager");
		AppFacade.Instance.AddManager<TimerManager>("TimerManager");
		AppFacade.Instance.AddManager<NetworkManager>("NetworkManager");
		AppFacade.Instance.AddManager<ResourceManager>("ResourceManager");
		AppFacade.Instance.AddManager<ThreadManager>("ThreadManager");
		AppFacade.Instance.AddManager<ObjectPoolManager>("ObjectPoolManager");
		AppFacade.Instance.AddManager<GameManager>("GameManager");
	}
}
