using System;
using UnityEngine;

namespace LuaFramework
{
	public class LuaTimerBehaviour : MonoBehaviour
	{
		private TimerManager.UpdateFunc repeatFunc;

		private TimerManager.UpdateFunc func;

		public void StartTimer(float delay, TimerManager.UpdateFunc func)
		{
			this.func = func;
			base.Invoke("TimerExcute", delay);
		}

		public void StartRepeatingTimer(float delay, float interval, TimerManager.UpdateFunc func)
		{
			this.repeatFunc = func;
			base.InvokeRepeating("TimerUpdate", delay, interval);
		}

		public void StopRepeatingTimer()
		{
			base.CancelInvoke("TimerUpdate");
			UnityEngine.Object.Destroy(this);
		}

		private void TimerUpdate()
		{
			if (this.repeatFunc != null)
			{
				this.repeatFunc();
			}
		}

		private void TimerExcute()
		{
			if (this.func != null)
			{
				this.func();
			}
			UnityEngine.Object.Destroy(this);
		}
	}
}
