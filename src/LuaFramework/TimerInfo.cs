using System;
using UnityEngine;

namespace LuaFramework
{
	[Obsolete("TimerInfo is obsolete, do not use it anymore")]
	public class TimerInfo
	{
		public long tick;

		public bool stop;

		public bool delete;

		public UnityEngine.Object target;

		public string className;

		public TimerInfo(string className, UnityEngine.Object target)
		{
			this.className = className;
			this.target = target;
			this.delete = false;
		}
	}
}
