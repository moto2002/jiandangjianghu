using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace LuaFramework
{
	public class TimerManager : Manager
	{
		public delegate void UpdateFunc();

		[Obsolete("interval is obsolete, do not use it anymore")]
		private float interval;

		[Obsolete("objects is obsolete, do not use it anymore")]
		private List<TimerInfo> objects = new List<TimerInfo>();

		private Dictionary<string, LuaTimerBehaviour> timers = new Dictionary<string, LuaTimerBehaviour>();

		[Obsolete("Interval is obsolete, do not use it anymore")]
		public float Interval
		{
			get
			{
				return this.interval;
			}
			set
			{
				this.interval = value;
			}
		}

		private new void Start()
		{
		}

		[Obsolete("StartTimer is obsolete, see AddTimer or AddRepeatingTimer")]
		public void StartTimer(float value)
		{
			this.interval = value;
			base.InvokeRepeating("Run", 0f, this.interval);
		}

		[Obsolete("StartTimer is obsolete, use RemoveTimer instead")]
		public void StopTimer()
		{
			base.CancelInvoke("Run");
		}

		[Obsolete("AddTimerEvent is obsolete, do not use it anymore")]
		public void AddTimerEvent(TimerInfo info)
		{
			if (!this.objects.Contains(info))
			{
				this.objects.Add(info);
			}
		}

		[Obsolete("RemoveTimerEvent is obsolete, do not use it anymore")]
		public void RemoveTimerEvent(TimerInfo info)
		{
			if (this.objects.Contains(info) && info != null)
			{
				info.delete = true;
			}
		}

		[Obsolete("StopTimerEvent is obsolete, do not use it anymore")]
		public void StopTimerEvent(TimerInfo info)
		{
			if (this.objects.Contains(info) && info != null)
			{
				info.stop = true;
			}
		}

		[Obsolete("ResumeTimerEvent is obsolete, do not use it anymore")]
		public void ResumeTimerEvent(TimerInfo info)
		{
			if (this.objects.Contains(info) && info != null)
			{
				info.delete = false;
			}
		}

		[Obsolete("Run is obsolete, do not use it anymore")]
		private void Run()
		{
			if (this.objects.Count == 0)
			{
				return;
			}
			for (int i = 0; i < this.objects.Count; i++)
			{
				TimerInfo timerInfo = this.objects[i];
				if (!timerInfo.delete && !timerInfo.stop)
				{
					ITimerBehaviour timerBehaviour = timerInfo.target as ITimerBehaviour;
					timerBehaviour.TimerUpdate();
					timerInfo.tick += 1L;
				}
			}
			for (int j = this.objects.Count - 1; j >= 0; j--)
			{
				if (this.objects[j].delete)
				{
					this.objects.Remove(this.objects[j]);
				}
			}
		}

		public void AddRepeatingTimer(GameObject go, string timerName, float delay, float interval, TimerManager.UpdateFunc func)
		{
			Debugger.Log("AddRepeatingTimer: " + timerName);
			if (!this.timers.ContainsKey(timerName))
			{
				LuaTimerBehaviour luaTimerBehaviour = go.AddComponent<LuaTimerBehaviour>();
				luaTimerBehaviour.StartRepeatingTimer(delay, interval, func);
				this.timers.Add(timerName, luaTimerBehaviour);
			}
		}

		public void RemoveRepeatingTimer(string timerName)
		{
			Debugger.Log("RemoveRepeatingTimer: " + timerName);
			if (this.timers.ContainsKey(timerName))
			{
				this.timers[timerName].StopRepeatingTimer();
				this.timers.Remove(timerName);
			}
		}

		public void AddTimer(GameObject go, string timerName, float delay, TimerManager.UpdateFunc func)
		{
			if (!this.timers.ContainsKey(timerName))
			{
				LuaTimerBehaviour luaTimerBehaviour = go.AddComponent<LuaTimerBehaviour>();
				luaTimerBehaviour.StartTimer(delay, func);
				this.timers.Add(timerName, luaTimerBehaviour);
			}
		}
	}
}
