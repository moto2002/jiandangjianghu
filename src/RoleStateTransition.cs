using LuaFramework;
using System;
using System.Collections.Generic;
using ThirdParty;
using UnityEngine;

public class RoleStateTransition : MonoBehaviour
{
	public enum RoleState
	{
		None,
		Fight,
		Jumping,
		HorseRiding = 4,
		BeginAutoQuesting = 8,
		AutoPathfinding = 16,
		Dazuo = 32,
		Guaji = 64,
		OpenUI = 128,
		PathComputeComplete = 256,
		Dead = 512,
		FlyShoe = 1024,
		Husong = 2048,
		ProtectFollow = 4096,
		ShowGuide = 8192,
		Task = 16384
	}

	public delegate void OnStateChanged(int state, string action);

	public static bool firstEnter;

	private Dictionary<string, RoleStateTransition.OnStateChanged> eventListener;

	private readonly int DEFAULT_RESET_FIGHTTIME = 3;

	private readonly int DEFAULT_AUTOACTION_DELAY = 90;

	private int curState;

	private float autoActionDelay
	{
		get;
		set;
	}

	private float autoResetFightTime
	{
		get;
		set;
	}

	private void Awake()
	{
		this.autoActionDelay = (float)this.DEFAULT_AUTOACTION_DELAY;
		this.autoResetFightTime = (float)this.DEFAULT_RESET_FIGHTTIME;
		this.eventListener = new Dictionary<string, RoleStateTransition.OnStateChanged>();
	}

	public bool IsInState(int state)
	{
		return (this.curState & state) > 0;
	}

	public bool CanRide()
	{
		return (this.curState & 1091) == 0;
	}

	public bool CanWalkOnDirection()
	{
		return (this.curState & 1666) == 0;
	}

	public bool CanDaZuo()
	{
		return (this.curState & 3139) == 0;
	}

	public void AddState(int state)
	{
		if (state == 1 || state == 64)
		{
			this.autoResetFightTime = (float)this.DEFAULT_RESET_FIGHTTIME;
		}
		if (!this.IsInState(state))
		{
			this.curState |= state;
			foreach (RoleStateTransition.OnStateChanged current in this.eventListener.Values)
			{
				if (current != null)
				{
					current(state, "addstate");
				}
			}
		}
		else if (state == 256)
		{
			foreach (RoleStateTransition.OnStateChanged current2 in this.eventListener.Values)
			{
				if (current2 != null)
				{
					current2(state, "addstate");
				}
			}
		}
	}

	public void RemoveState(int state)
	{
		if (this.IsInState(state))
		{
			this.curState &= ~state;
			foreach (RoleStateTransition.OnStateChanged current in this.eventListener.Values)
			{
				if (current != null)
				{
					current(state, "removestate");
				}
			}
		}
		else if (state == 256)
		{
			foreach (RoleStateTransition.OnStateChanged current2 in this.eventListener.Values)
			{
				if (current2 != null)
				{
					current2(state, "removestate");
				}
			}
		}
		else if (state == 32)
		{
			foreach (RoleStateTransition.OnStateChanged current3 in this.eventListener.Values)
			{
				if (current3 != null)
				{
					current3(state, "removestate");
				}
			}
		}
	}

	public void ClearStateWhenDead()
	{
		this.curState = 512;
	}

	public void AddListener(string name, RoleStateTransition.OnStateChanged listener)
	{
		if (listener != null && !this.eventListener.ContainsKey(name))
		{
			this.eventListener.Add(name, listener);
		}
	}

	public void RemoveListener(string name)
	{
		if (this.eventListener.ContainsKey(name))
		{
			this.eventListener[name] = null;
			this.eventListener.Remove(name);
		}
	}

	private void OnEnable()
	{
		this.curState = 0;
	}

	private void OnDisable()
	{
		this.eventListener.Clear();
		this.RemoveState(64);
		this.RemoveState(16);
		this.RemoveState(4);
	}

	private void Update()
	{
		if (AppFacade.Instance.GetManager<NetworkManager>("NetworkManager").lostConnect)
		{
			return;
		}
		if (RoleStateTransition.firstEnter)
		{
			this.autoActionDelay = 1f;
			RoleStateTransition.firstEnter = false;
		}
		this.UpdateBeginAutoQuestingState();
		this.UpdateFightState();
		this.UpdateJumpingState();
		this.UpdateAutoPathfindingState();
		this.UpdateHusongFollowState();
	}

	private void UpdateBeginAutoQuestingState()
	{
		if (Input.GetMouseButton(0) || Input.touchCount > 0)
		{
			this.autoActionDelay = (float)this.DEFAULT_AUTOACTION_DELAY;
		}
		else if ((this.curState & 243) == 0)
		{
			this.autoActionDelay -= Time.deltaTime;
		}
		if (this.autoActionDelay <= 0f)
		{
			this.autoActionDelay = (float)this.DEFAULT_AUTOACTION_DELAY;
			this.AddState(8);
		}
	}

	private void UpdateFightState()
	{
		if (this.IsInState(1) && !this.IsInState(64))
		{
			this.autoResetFightTime -= Time.deltaTime;
			if (this.autoResetFightTime <= 0f)
			{
				this.autoResetFightTime = (float)this.DEFAULT_RESET_FIGHTTIME;
				this.RemoveState(1);
			}
		}
	}

	private void UpdateJumpingState()
	{
		if (Singleton<RoleManager>.Instance.mainRole == null)
		{
			return;
		}
		if (!this.IsInState(2))
		{
			if (Singleton<RoleManager>.Instance.mainRole.move.jumpMode != 0)
			{
				this.AddState(2);
			}
		}
		else if (Singleton<RoleManager>.Instance.mainRole.move.jumpMode == 0)
		{
			this.RemoveState(2);
		}
	}

	private void UpdateAutoPathfindingState()
	{
		if (this.IsInState(16) && (this.IsInState(128) || this.IsInState(8192)) && !this.IsInState(2048) && Singleton<RoleManager>.Instance.mainRole.move.InMoving())
		{
			Singleton<WorldPathfinding>.Instance.StopWorldPathfinding();
			Singleton<RoleManager>.Instance.mainRole.move.StopPath();
			this.RemoveState(16);
			if (this.IsInState(16384))
			{
				this.RemoveState(16384);
			}
		}
	}

	private void UpdateHusongFollowState()
	{
		if (this.IsInState(4096) && (Input.GetMouseButton(0) || Input.touchCount > 0) && !this.IsInState(128))
		{
			this.RemoveState(4096);
		}
	}
}
