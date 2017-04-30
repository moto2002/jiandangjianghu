using LuaFramework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
	private AppFacade m_Facade;

	private LuaManager m_LuaMgr;

	private ResourceManager m_ResMgr;

	private NetworkManager m_NetMgr;

	private SoundManager m_SoundMgr;

	private TimerManager m_TimerMgr;

	private ThreadManager m_ThreadMgr;

	private ObjectPoolManager m_ObjectPoolMgr;

	protected AppFacade facade
	{
		get
		{
			if (this.m_Facade == null)
			{
				this.m_Facade = AppFacade.Instance;
			}
			return this.m_Facade;
		}
	}

	protected LuaManager LuaManager
	{
		get
		{
			if (this.m_LuaMgr == null)
			{
				this.m_LuaMgr = this.facade.GetManager<LuaManager>("LuaScriptMgr");
			}
			return this.m_LuaMgr;
		}
	}

	protected ResourceManager ResManager
	{
		get
		{
			if (this.m_ResMgr == null)
			{
				this.m_ResMgr = this.facade.GetManager<ResourceManager>("ResourceManager");
			}
			return this.m_ResMgr;
		}
	}

	protected NetworkManager NetManager
	{
		get
		{
			if (this.m_NetMgr == null)
			{
				this.m_NetMgr = this.facade.GetManager<NetworkManager>("NetworkManager");
			}
			return this.m_NetMgr;
		}
	}

	protected SoundManager soundManager
	{
		get
		{
			if (this.m_SoundMgr == null)
			{
				this.m_SoundMgr = this.facade.GetManager<SoundManager>("SoundManager");
			}
			return this.m_SoundMgr;
		}
	}

	protected TimerManager TimerManager
	{
		get
		{
			if (this.m_TimerMgr == null)
			{
				this.m_TimerMgr = this.facade.GetManager<TimerManager>("TimerManager");
			}
			return this.m_TimerMgr;
		}
	}

	protected ThreadManager ThreadManager
	{
		get
		{
			if (this.m_ThreadMgr == null)
			{
				this.m_ThreadMgr = this.facade.GetManager<ThreadManager>("ThreadManager");
			}
			return this.m_ThreadMgr;
		}
	}

	protected ObjectPoolManager ObjPoolManager
	{
		get
		{
			if (this.m_ObjectPoolMgr == null)
			{
				this.m_ObjectPoolMgr = this.facade.GetManager<ObjectPoolManager>("ObjectPoolManager");
			}
			return this.m_ObjectPoolMgr;
		}
	}

	protected void RegisterMessage(IView view, List<string> messages)
	{
		if (messages == null || messages.Count == 0)
		{
			return;
		}
		Controller.Instance.RegisterViewCommand(view, messages.ToArray());
	}

	protected void RemoveMessage(IView view, List<string> messages)
	{
		if (messages == null || messages.Count == 0)
		{
			return;
		}
		Controller.Instance.RemoveViewCommand(view, messages.ToArray());
	}
}
