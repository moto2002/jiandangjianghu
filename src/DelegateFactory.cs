using Aoi;
using DG.Tweening;
using DG.Tweening.Core;
using LuaFramework;
using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class DelegateFactory
{
	private class System_Action_Event : LuaDelegate
	{
		public System_Action_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_Events_UnityAction_Event : LuaDelegate
	{
		public UnityEngine_Events_UnityAction_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_Events_UnityAction_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Predicate_int_Event : LuaDelegate
	{
		public System_Predicate_int_Event(LuaFunction func) : base(func)
		{
		}

		public System_Predicate_int_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Action_int_Event : LuaDelegate
	{
		public System_Action_int_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_int_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Comparison_int_Event : LuaDelegate
	{
		public System_Comparison_int_Event(LuaFunction func) : base(func)
		{
		}

		public System_Comparison_int_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public int Call(int param0, int param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public int CallWithSelf(int param0, int param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_Core_DOGetter_float_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOGetter_float_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOGetter_float_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public float Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			float result = (float)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public float CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			float result = (float)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_Core_DOSetter_float_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOSetter_float_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOSetter_float_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(float param0)
		{
			this.func.BeginPCall();
			this.func.Push((double)param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(float param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push((double)param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_Core_DOGetter_double_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOGetter_double_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOGetter_double_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public double Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			double result = this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public double CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			double result = this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_Core_DOSetter_double_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOSetter_double_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOSetter_double_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(double param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(double param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_Core_DOGetter_int_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOGetter_int_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOGetter_int_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public int Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public int CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_Core_DOSetter_int_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOSetter_int_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOSetter_int_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_Core_DOGetter_uint_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOGetter_uint_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOGetter_uint_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public uint Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			uint result = (uint)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public uint CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			uint result = (uint)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_Core_DOSetter_uint_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOSetter_uint_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOSetter_uint_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(uint param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(uint param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_Core_DOGetter_long_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOGetter_long_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOGetter_long_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public long Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			long result = this.func.CheckLong();
			this.func.EndPCall();
			return result;
		}

		public long CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			long result = this.func.CheckLong();
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_Core_DOSetter_long_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOSetter_long_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOSetter_long_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(long param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(long param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_Core_DOGetter_ulong_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOGetter_ulong_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOGetter_ulong_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public ulong Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			ulong result = this.func.CheckULong();
			this.func.EndPCall();
			return result;
		}

		public ulong CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			ulong result = this.func.CheckULong();
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_Core_DOSetter_ulong_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOSetter_ulong_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOSetter_ulong_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(ulong param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(ulong param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_Core_DOGetter_string_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOGetter_string_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOGetter_string_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public string Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			string result = this.func.CheckString();
			this.func.EndPCall();
			return result;
		}

		public string CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			string result = this.func.CheckString();
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_Core_DOSetter_string_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOSetter_string_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOSetter_string_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_Core_DOGetter_UnityEngine_Vector2_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOGetter_UnityEngine_Vector2_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOGetter_UnityEngine_Vector2_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public Vector2 Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			Vector2 result = this.func.CheckVector2();
			this.func.EndPCall();
			return result;
		}

		public Vector2 CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			Vector2 result = this.func.CheckVector2();
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_Core_DOSetter_UnityEngine_Vector2_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOSetter_UnityEngine_Vector2_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOSetter_UnityEngine_Vector2_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Vector2 param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Vector2 param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_Core_DOGetter_UnityEngine_Vector3_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOGetter_UnityEngine_Vector3_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOGetter_UnityEngine_Vector3_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public Vector3 Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			Vector3 result = this.func.CheckVector3();
			this.func.EndPCall();
			return result;
		}

		public Vector3 CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			Vector3 result = this.func.CheckVector3();
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_Core_DOSetter_UnityEngine_Vector3_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOSetter_UnityEngine_Vector3_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOSetter_UnityEngine_Vector3_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Vector3 param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Vector3 param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_Core_DOGetter_UnityEngine_Vector4_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOGetter_UnityEngine_Vector4_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOGetter_UnityEngine_Vector4_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public Vector4 Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			Vector4 result = this.func.CheckVector4();
			this.func.EndPCall();
			return result;
		}

		public Vector4 CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			Vector4 result = this.func.CheckVector4();
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_Core_DOSetter_UnityEngine_Vector4_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOSetter_UnityEngine_Vector4_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOSetter_UnityEngine_Vector4_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Vector4 param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Vector4 param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_Core_DOGetter_UnityEngine_Quaternion_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOGetter_UnityEngine_Quaternion_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOGetter_UnityEngine_Quaternion_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public Quaternion Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			Quaternion result = this.func.CheckQuaternion();
			this.func.EndPCall();
			return result;
		}

		public Quaternion CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			Quaternion result = this.func.CheckQuaternion();
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_Core_DOSetter_UnityEngine_Quaternion_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOSetter_UnityEngine_Quaternion_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOSetter_UnityEngine_Quaternion_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Quaternion param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Quaternion param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_Core_DOGetter_UnityEngine_Color_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOGetter_UnityEngine_Color_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOGetter_UnityEngine_Color_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public Color Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			Color result = this.func.CheckColor();
			this.func.EndPCall();
			return result;
		}

		public Color CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			Color result = this.func.CheckColor();
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_Core_DOSetter_UnityEngine_Color_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOSetter_UnityEngine_Color_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOSetter_UnityEngine_Color_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Color param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Color param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_Core_DOGetter_UnityEngine_Rect_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOGetter_UnityEngine_Rect_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOGetter_UnityEngine_Rect_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public Rect Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			Rect result = (Rect)this.func.CheckObject(typeof(Rect));
			this.func.EndPCall();
			return result;
		}

		public Rect CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			Rect result = (Rect)this.func.CheckObject(typeof(Rect));
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_Core_DOSetter_UnityEngine_Rect_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOSetter_UnityEngine_Rect_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOSetter_UnityEngine_Rect_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Rect param0)
		{
			this.func.BeginPCall();
			this.func.PushValue(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Rect param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PushValue(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_Core_DOGetter_UnityEngine_RectOffset_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOGetter_UnityEngine_RectOffset_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOGetter_UnityEngine_RectOffset_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public RectOffset Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			RectOffset result = (RectOffset)this.func.CheckObject(typeof(RectOffset));
			this.func.EndPCall();
			return result;
		}

		public RectOffset CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			RectOffset result = (RectOffset)this.func.CheckObject(typeof(RectOffset));
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_Core_DOSetter_UnityEngine_RectOffset_Event : LuaDelegate
	{
		public DG_Tweening_Core_DOSetter_UnityEngine_RectOffset_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_Core_DOSetter_UnityEngine_RectOffset_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(RectOffset param0)
		{
			this.func.BeginPCall();
			this.func.PushObject(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(RectOffset param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PushObject(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_TweenCallback_float_Event : LuaDelegate
	{
		public DG_Tweening_TweenCallback_float_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_TweenCallback_float_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(float param0)
		{
			this.func.BeginPCall();
			this.func.Push((double)param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(float param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push((double)param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_TweenCallback_Event : LuaDelegate
	{
		public DG_Tweening_TweenCallback_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_TweenCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class DG_Tweening_EaseFunction_Event : LuaDelegate
	{
		public DG_Tweening_EaseFunction_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_EaseFunction_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public float Call(float param0, float param1, float param2, float param3)
		{
			this.func.BeginPCall();
			this.func.Push((double)param0);
			this.func.Push((double)param1);
			this.func.Push((double)param2);
			this.func.Push((double)param3);
			this.func.PCall();
			float result = (float)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public float CallWithSelf(float param0, float param1, float param2, float param3)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push((double)param0);
			this.func.Push((double)param1);
			this.func.Push((double)param2);
			this.func.Push((double)param3);
			this.func.PCall();
			float result = (float)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class DG_Tweening_TweenCallback_int_Event : LuaDelegate
	{
		public DG_Tweening_TweenCallback_int_Event(LuaFunction func) : base(func)
		{
		}

		public DG_Tweening_TweenCallback_int_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_Camera_CameraCallback_Event : LuaDelegate
	{
		public UnityEngine_Camera_CameraCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_Camera_CameraCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Camera param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Camera param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_Application_LogCallback_Event : LuaDelegate
	{
		public UnityEngine_Application_LogCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_Application_LogCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(string param0, string param1, LogType param2)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(string param0, string param1, LogType param2)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_Application_AdvertisingIdentifierCallback_Event : LuaDelegate
	{
		public UnityEngine_Application_AdvertisingIdentifierCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_Application_AdvertisingIdentifierCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(string param0, bool param1, string param2)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(string param0, bool param1, string param2)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_AudioClip_PCMReaderCallback_Event : LuaDelegate
	{
		public UnityEngine_AudioClip_PCMReaderCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_AudioClip_PCMReaderCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(float[] param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(float[] param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UnityEngine_AudioClip_PCMSetPositionCallback_Event : LuaDelegate
	{
		public UnityEngine_AudioClip_PCMSetPositionCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UnityEngine_AudioClip_PCMSetPositionCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIPanel_OnGeometryUpdated_Event : LuaDelegate
	{
		public UIPanel_OnGeometryUpdated_Event(LuaFunction func) : base(func)
		{
		}

		public UIPanel_OnGeometryUpdated_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIPanel_OnClippingMoved_Event : LuaDelegate
	{
		public UIPanel_OnClippingMoved_Event(LuaFunction func) : base(func)
		{
		}

		public UIPanel_OnClippingMoved_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(UIPanel param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(UIPanel param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIWidget_OnDimensionsChanged_Event : LuaDelegate
	{
		public UIWidget_OnDimensionsChanged_Event(LuaFunction func) : base(func)
		{
		}

		public UIWidget_OnDimensionsChanged_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIWidget_OnPostFillCallback_Event : LuaDelegate
	{
		public UIWidget_OnPostFillCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UIWidget_OnPostFillCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(UIWidget param0, int param1, BetterList<Vector3> param2, BetterList<Vector2> param3, BetterList<Color32> param4)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PushObject(param2);
			this.func.PushObject(param3);
			this.func.PushObject(param4);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(UIWidget param0, int param1, BetterList<Vector3> param2, BetterList<Vector2> param3, BetterList<Color32> param4)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PushObject(param2);
			this.func.PushObject(param3);
			this.func.PushObject(param4);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIDrawCall_OnRenderCallback_Event : LuaDelegate
	{
		public UIDrawCall_OnRenderCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UIDrawCall_OnRenderCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Material param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Material param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIWidget_HitCheck_Event : LuaDelegate
	{
		public UIWidget_HitCheck_Event(LuaFunction func) : base(func)
		{
		}

		public UIWidget_HitCheck_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(Vector3 param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(Vector3 param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class UIGrid_OnReposition_Event : LuaDelegate
	{
		public UIGrid_OnReposition_Event(LuaFunction func) : base(func)
		{
		}

		public UIGrid_OnReposition_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Comparison_UnityEngine_Transform_Event : LuaDelegate
	{
		public System_Comparison_UnityEngine_Transform_Event(LuaFunction func) : base(func)
		{
		}

		public System_Comparison_UnityEngine_Transform_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public int Call(Transform param0, Transform param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public int CallWithSelf(Transform param0, Transform param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Action_UnityEngine_GameObject_string_Event : LuaDelegate
	{
		public System_Action_UnityEngine_GameObject_string_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_UnityEngine_GameObject_string_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, string param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, string param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_UnityEngine_AudioClip_string_Event : LuaDelegate
	{
		public System_Action_UnityEngine_AudioClip_string_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_UnityEngine_AudioClip_string_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(AudioClip param0, string param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(AudioClip param0, string param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class LuaFramework_LuaBehaviour_UiExtendEventDeal_Event : LuaDelegate
	{
		public LuaFramework_LuaBehaviour_UiExtendEventDeal_Event(LuaFunction func) : base(func)
		{
		}

		public LuaFramework_LuaBehaviour_UiExtendEventDeal_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, string param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, string param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UITable_OnReposition_Event : LuaDelegate
	{
		public UITable_OnReposition_Event(LuaFunction func) : base(func)
		{
		}

		public UITable_OnReposition_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class LuaFramework_GameManager_DownloadPackProgressChanged_Event : LuaDelegate
	{
		public LuaFramework_GameManager_DownloadPackProgressChanged_Event(LuaFunction func) : base(func)
		{
		}

		public LuaFramework_GameManager_DownloadPackProgressChanged_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(float param0)
		{
			this.func.BeginPCall();
			this.func.Push((double)param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(float param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push((double)param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class LuaFramework_TimerManager_UpdateFunc_Event : LuaDelegate
	{
		public LuaFramework_TimerManager_UpdateFunc_Event(LuaFunction func) : base(func)
		{
		}

		public LuaFramework_TimerManager_UpdateFunc_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_NotiData_Event : LuaDelegate
	{
		public System_Action_NotiData_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_NotiData_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(NotiData param0)
		{
			this.func.BeginPCall();
			this.func.PushObject(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(NotiData param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PushObject(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIInput_OnValidate_Event : LuaDelegate
	{
		public UIInput_OnValidate_Event(LuaFunction func) : base(func)
		{
		}

		public UIInput_OnValidate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public char Call(string param0, int param1, char param2)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push((int)param2);
			this.func.PCall();
			char result = (char)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public char CallWithSelf(string param0, int param1, char param2)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push((int)param2);
			this.func.PCall();
			char result = (char)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class UIPopupList_LegacyEvent_Event : LuaDelegate
	{
		public UIPopupList_LegacyEvent_Event(LuaFunction func) : base(func)
		{
		}

		public UIPopupList_LegacyEvent_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIProgressBar_OnDragFinished_Event : LuaDelegate
	{
		public UIProgressBar_OnDragFinished_Event(LuaFunction func) : base(func)
		{
		}

		public UIProgressBar_OnDragFinished_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIToggle_Validate_Event : LuaDelegate
	{
		public UIToggle_Validate_Event(LuaFunction func) : base(func)
		{
		}

		public UIToggle_Validate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(bool param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(bool param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class UIWrapContent_OnInitializeItem_Event : LuaDelegate
	{
		public UIWrapContent_OnInitializeItem_Event(LuaFunction func) : base(func)
		{
		}

		public UIWrapContent_OnInitializeItem_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, int param1, int param2)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, int param1, int param2)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.Push(param2);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_GetKeyStateFunc_Event : LuaDelegate
	{
		public UICamera_GetKeyStateFunc_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_GetKeyStateFunc_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(KeyCode param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(KeyCode param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class UICamera_GetAxisFunc_Event : LuaDelegate
	{
		public UICamera_GetAxisFunc_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_GetAxisFunc_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public float Call(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			float result = (float)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public float CallWithSelf(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			float result = (float)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class UICamera_OnScreenResize_Event : LuaDelegate
	{
		public UICamera_OnScreenResize_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_OnScreenResize_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_OnCustomInput_Event : LuaDelegate
	{
		public UICamera_OnCustomInput_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_OnCustomInput_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_VoidDelegate_Event : LuaDelegate
	{
		public UICamera_VoidDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_VoidDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_BoolDelegate_Event : LuaDelegate
	{
		public UICamera_BoolDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_BoolDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, bool param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, bool param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_FloatDelegate_Event : LuaDelegate
	{
		public UICamera_FloatDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_FloatDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, float param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push((double)param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, float param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push((double)param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_VectorDelegate_Event : LuaDelegate
	{
		public UICamera_VectorDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_VectorDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, Vector2 param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, Vector2 param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_ObjectDelegate_Event : LuaDelegate
	{
		public UICamera_ObjectDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_ObjectDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, GameObject param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, GameObject param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_KeyCodeDelegate_Event : LuaDelegate
	{
		public UICamera_KeyCodeDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_KeyCodeDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, KeyCode param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, KeyCode param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_MoveDelegate_Event : LuaDelegate
	{
		public UICamera_MoveDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_MoveDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(Vector2 param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(Vector2 param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UICamera_GetTouchCountCallback_Event : LuaDelegate
	{
		public UICamera_GetTouchCountCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_GetTouchCountCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public int Call()
		{
			this.func.BeginPCall();
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public int CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class UICamera_GetTouchCallback_Event : LuaDelegate
	{
		public UICamera_GetTouchCallback_Event(LuaFunction func) : base(func)
		{
		}

		public UICamera_GetTouchCallback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public UICamera.Touch Call(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			UICamera.Touch result = (UICamera.Touch)this.func.CheckObject(typeof(UICamera.Touch));
			this.func.EndPCall();
			return result;
		}

		public UICamera.Touch CallWithSelf(int param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			UICamera.Touch result = (UICamera.Touch)this.func.CheckObject(typeof(UICamera.Touch));
			this.func.EndPCall();
			return result;
		}
	}

	private class EventDelegate_Callback_Event : LuaDelegate
	{
		public EventDelegate_Callback_Event(LuaFunction func) : base(func)
		{
		}

		public EventDelegate_Callback_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIEventListener_VoidDelegate_Event : LuaDelegate
	{
		public UIEventListener_VoidDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UIEventListener_VoidDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIEventListener_BoolDelegate_Event : LuaDelegate
	{
		public UIEventListener_BoolDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UIEventListener_BoolDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, bool param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, bool param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIEventListener_FloatDelegate_Event : LuaDelegate
	{
		public UIEventListener_FloatDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UIEventListener_FloatDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, float param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push((double)param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, float param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push((double)param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIEventListener_VectorDelegate_Event : LuaDelegate
	{
		public UIEventListener_VectorDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UIEventListener_VectorDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, Vector2 param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, Vector2 param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIEventListener_ObjectDelegate_Event : LuaDelegate
	{
		public UIEventListener_ObjectDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UIEventListener_ObjectDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, GameObject param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, GameObject param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIEventListener_KeyCodeDelegate_Event : LuaDelegate
	{
		public UIEventListener_KeyCodeDelegate_Event(LuaFunction func) : base(func)
		{
		}

		public UIEventListener_KeyCodeDelegate_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0, KeyCode param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0, KeyCode param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class UIScrollView_OnDragNotification_Event : LuaDelegate
	{
		public UIScrollView_OnDragNotification_Event(LuaFunction func) : base(func)
		{
		}

		public UIScrollView_OnDragNotification_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class SpringPanel_OnFinished_Event : LuaDelegate
	{
		public SpringPanel_OnFinished_Event(LuaFunction func) : base(func)
		{
		}

		public SpringPanel_OnFinished_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Predicate_ServerInfo_Event : LuaDelegate
	{
		public System_Predicate_ServerInfo_Event(LuaFunction func) : base(func)
		{
		}

		public System_Predicate_ServerInfo_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public bool Call(ServerInfo param0)
		{
			this.func.BeginPCall();
			this.func.PushObject(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}

		public bool CallWithSelf(ServerInfo param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PushObject(param0);
			this.func.PCall();
			bool result = this.func.CheckBoolean();
			this.func.EndPCall();
			return result;
		}
	}

	private class System_Action_ServerInfo_Event : LuaDelegate
	{
		public System_Action_ServerInfo_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_ServerInfo_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(ServerInfo param0)
		{
			this.func.BeginPCall();
			this.func.PushObject(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(ServerInfo param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PushObject(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Comparison_ServerInfo_Event : LuaDelegate
	{
		public System_Comparison_ServerInfo_Event(LuaFunction func) : base(func)
		{
		}

		public System_Comparison_ServerInfo_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public int Call(ServerInfo param0, ServerInfo param1)
		{
			this.func.BeginPCall();
			this.func.PushObject(param0);
			this.func.PushObject(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}

		public int CallWithSelf(ServerInfo param0, ServerInfo param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PushObject(param0);
			this.func.PushObject(param1);
			this.func.PCall();
			int result = (int)this.func.CheckNumber();
			this.func.EndPCall();
			return result;
		}
	}

	private class Move_PathFinished_Event : LuaDelegate
	{
		public Move_PathFinished_Event(LuaFunction func) : base(func)
		{
		}

		public Move_PathFinished_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class RoleStateTransition_OnStateChanged_Event : LuaDelegate
	{
		public RoleStateTransition_OnStateChanged_Event(LuaFunction func) : base(func)
		{
		}

		public RoleStateTransition_OnStateChanged_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(int param0, string param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(int param0, string param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class EntityCreate_OnRoleCreated_Event : LuaDelegate
	{
		public EntityCreate_OnRoleCreated_Event(LuaFunction func) : base(func)
		{
		}

		public EntityCreate_OnRoleCreated_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(SceneEntity param0, S2c_aoi_syncplayer param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PushObject(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(SceneEntity param0, S2c_aoi_syncplayer param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PushObject(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class EntityCreate_OnNpcCreated_Event : LuaDelegate
	{
		public EntityCreate_OnNpcCreated_Event(LuaFunction func) : base(func)
		{
		}

		public EntityCreate_OnNpcCreated_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(SceneEntity param0, S2c_aoi_syncnpc param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PushObject(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(SceneEntity param0, S2c_aoi_syncnpc param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PushObject(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_bool_Event : LuaDelegate
	{
		public System_Action_bool_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_bool_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(bool param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(bool param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class MessageBox_onButtonClicked_Event : LuaDelegate
	{
		public MessageBox_onButtonClicked_Event(LuaFunction func) : base(func)
		{
		}

		public MessageBox_onButtonClicked_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(GameObject param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class SDKInterface_LoginSucHandler_Event : LuaDelegate
	{
		public SDKInterface_LoginSucHandler_Event(LuaFunction func) : base(func)
		{
		}

		public SDKInterface_LoginSucHandler_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(LoginResult param0)
		{
			this.func.BeginPCall();
			this.func.PushObject(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(LoginResult param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PushObject(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class SDKInterface_LogoutHandler_Event : LuaDelegate
	{
		public SDKInterface_LogoutHandler_Event(LuaFunction func) : base(func)
		{
		}

		public SDKInterface_LogoutHandler_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call()
		{
			this.func.Call();
		}

		public void CallWithSelf()
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_string_Event : LuaDelegate
	{
		public System_Action_string_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_string_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(string param0)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	private class System_Action_string_string_Event : LuaDelegate
	{
		public System_Action_string_string_Event(LuaFunction func) : base(func)
		{
		}

		public System_Action_string_string_Event(LuaFunction func, LuaTable self) : base(func, self)
		{
		}

		public void Call(string param0, string param1)
		{
			this.func.BeginPCall();
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}

		public void CallWithSelf(string param0, string param1)
		{
			this.func.BeginPCall();
			this.func.Push(this.self);
			this.func.Push(param0);
			this.func.Push(param1);
			this.func.PCall();
			this.func.EndPCall();
		}
	}

	public delegate Delegate DelegateValue(LuaFunction func, LuaTable self, bool flag);

	public static Dictionary<Type, DelegateFactory.DelegateValue> dict;

	static DelegateFactory()
	{
		DelegateFactory.dict = new Dictionary<Type, DelegateFactory.DelegateValue>();
		DelegateFactory.Register();
	}

	[NoToLua]
	public static void Register()
	{
		DelegateFactory.dict.Clear();
		DelegateFactory.dict.Add(typeof(Action), new DelegateFactory.DelegateValue(DelegateFactory.System_Action));
		DelegateFactory.dict.Add(typeof(UnityAction), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_Events_UnityAction));
		DelegateFactory.dict.Add(typeof(Predicate<int>), new DelegateFactory.DelegateValue(DelegateFactory.System_Predicate_int));
		DelegateFactory.dict.Add(typeof(Action<int>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_int));
		DelegateFactory.dict.Add(typeof(Comparison<int>), new DelegateFactory.DelegateValue(DelegateFactory.System_Comparison_int));
		DelegateFactory.dict.Add(typeof(DOGetter<float>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOGetter_float));
		DelegateFactory.dict.Add(typeof(DOSetter<float>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOSetter_float));
		DelegateFactory.dict.Add(typeof(DOGetter<double>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOGetter_double));
		DelegateFactory.dict.Add(typeof(DOSetter<double>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOSetter_double));
		DelegateFactory.dict.Add(typeof(DOGetter<int>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOGetter_int));
		DelegateFactory.dict.Add(typeof(DOSetter<int>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOSetter_int));
		DelegateFactory.dict.Add(typeof(DOGetter<uint>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOGetter_uint));
		DelegateFactory.dict.Add(typeof(DOSetter<uint>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOSetter_uint));
		DelegateFactory.dict.Add(typeof(DOGetter<long>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOGetter_long));
		DelegateFactory.dict.Add(typeof(DOSetter<long>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOSetter_long));
		DelegateFactory.dict.Add(typeof(DOGetter<ulong>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOGetter_ulong));
		DelegateFactory.dict.Add(typeof(DOSetter<ulong>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOSetter_ulong));
		DelegateFactory.dict.Add(typeof(DOGetter<string>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOGetter_string));
		DelegateFactory.dict.Add(typeof(DOSetter<string>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOSetter_string));
		DelegateFactory.dict.Add(typeof(DOGetter<Vector2>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Vector2));
		DelegateFactory.dict.Add(typeof(DOSetter<Vector2>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Vector2));
		DelegateFactory.dict.Add(typeof(DOGetter<Vector3>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Vector3));
		DelegateFactory.dict.Add(typeof(DOSetter<Vector3>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Vector3));
		DelegateFactory.dict.Add(typeof(DOGetter<Vector4>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Vector4));
		DelegateFactory.dict.Add(typeof(DOSetter<Vector4>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Vector4));
		DelegateFactory.dict.Add(typeof(DOGetter<Quaternion>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Quaternion));
		DelegateFactory.dict.Add(typeof(DOSetter<Quaternion>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Quaternion));
		DelegateFactory.dict.Add(typeof(DOGetter<Color>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Color));
		DelegateFactory.dict.Add(typeof(DOSetter<Color>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Color));
		DelegateFactory.dict.Add(typeof(DOGetter<Rect>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Rect));
		DelegateFactory.dict.Add(typeof(DOSetter<Rect>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Rect));
		DelegateFactory.dict.Add(typeof(DOGetter<RectOffset>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_RectOffset));
		DelegateFactory.dict.Add(typeof(DOSetter<RectOffset>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_RectOffset));
		DelegateFactory.dict.Add(typeof(TweenCallback<float>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_TweenCallback_float));
		DelegateFactory.dict.Add(typeof(TweenCallback), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_TweenCallback));
		DelegateFactory.dict.Add(typeof(EaseFunction), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_EaseFunction));
		DelegateFactory.dict.Add(typeof(TweenCallback<int>), new DelegateFactory.DelegateValue(DelegateFactory.DG_Tweening_TweenCallback_int));
		DelegateFactory.dict.Add(typeof(Camera.CameraCallback), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_Camera_CameraCallback));
		DelegateFactory.dict.Add(typeof(Application.LogCallback), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_Application_LogCallback));
		DelegateFactory.dict.Add(typeof(Application.AdvertisingIdentifierCallback), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_Application_AdvertisingIdentifierCallback));
		DelegateFactory.dict.Add(typeof(AudioClip.PCMReaderCallback), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_AudioClip_PCMReaderCallback));
		DelegateFactory.dict.Add(typeof(AudioClip.PCMSetPositionCallback), new DelegateFactory.DelegateValue(DelegateFactory.UnityEngine_AudioClip_PCMSetPositionCallback));
		DelegateFactory.dict.Add(typeof(UIPanel.OnGeometryUpdated), new DelegateFactory.DelegateValue(DelegateFactory.UIPanel_OnGeometryUpdated));
		DelegateFactory.dict.Add(typeof(UIPanel.OnClippingMoved), new DelegateFactory.DelegateValue(DelegateFactory.UIPanel_OnClippingMoved));
		DelegateFactory.dict.Add(typeof(UIWidget.OnDimensionsChanged), new DelegateFactory.DelegateValue(DelegateFactory.UIWidget_OnDimensionsChanged));
		DelegateFactory.dict.Add(typeof(UIWidget.OnPostFillCallback), new DelegateFactory.DelegateValue(DelegateFactory.UIWidget_OnPostFillCallback));
		DelegateFactory.dict.Add(typeof(UIDrawCall.OnRenderCallback), new DelegateFactory.DelegateValue(DelegateFactory.UIDrawCall_OnRenderCallback));
		DelegateFactory.dict.Add(typeof(UIWidget.HitCheck), new DelegateFactory.DelegateValue(DelegateFactory.UIWidget_HitCheck));
		DelegateFactory.dict.Add(typeof(UIGrid.OnReposition), new DelegateFactory.DelegateValue(DelegateFactory.UIGrid_OnReposition));
		DelegateFactory.dict.Add(typeof(Comparison<Transform>), new DelegateFactory.DelegateValue(DelegateFactory.System_Comparison_UnityEngine_Transform));
		DelegateFactory.dict.Add(typeof(Action<GameObject, string>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_UnityEngine_GameObject_string));
		DelegateFactory.dict.Add(typeof(Action<AudioClip, string>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_UnityEngine_AudioClip_string));
		DelegateFactory.dict.Add(typeof(LuaBehaviour.UiExtendEventDeal), new DelegateFactory.DelegateValue(DelegateFactory.LuaFramework_LuaBehaviour_UiExtendEventDeal));
		DelegateFactory.dict.Add(typeof(UITable.OnReposition), new DelegateFactory.DelegateValue(DelegateFactory.UITable_OnReposition));
		DelegateFactory.dict.Add(typeof(GameManager.DownloadPackProgressChanged), new DelegateFactory.DelegateValue(DelegateFactory.LuaFramework_GameManager_DownloadPackProgressChanged));
		DelegateFactory.dict.Add(typeof(TimerManager.UpdateFunc), new DelegateFactory.DelegateValue(DelegateFactory.LuaFramework_TimerManager_UpdateFunc));
		DelegateFactory.dict.Add(typeof(Action<NotiData>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_NotiData));
		DelegateFactory.dict.Add(typeof(UIInput.OnValidate), new DelegateFactory.DelegateValue(DelegateFactory.UIInput_OnValidate));
		DelegateFactory.dict.Add(typeof(UIPopupList.LegacyEvent), new DelegateFactory.DelegateValue(DelegateFactory.UIPopupList_LegacyEvent));
		DelegateFactory.dict.Add(typeof(UIProgressBar.OnDragFinished), new DelegateFactory.DelegateValue(DelegateFactory.UIProgressBar_OnDragFinished));
		DelegateFactory.dict.Add(typeof(UIToggle.Validate), new DelegateFactory.DelegateValue(DelegateFactory.UIToggle_Validate));
		DelegateFactory.dict.Add(typeof(UIWrapContent.OnInitializeItem), new DelegateFactory.DelegateValue(DelegateFactory.UIWrapContent_OnInitializeItem));
		DelegateFactory.dict.Add(typeof(UICamera.GetKeyStateFunc), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_GetKeyStateFunc));
		DelegateFactory.dict.Add(typeof(UICamera.GetAxisFunc), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_GetAxisFunc));
		DelegateFactory.dict.Add(typeof(UICamera.OnScreenResize), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_OnScreenResize));
		DelegateFactory.dict.Add(typeof(UICamera.OnCustomInput), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_OnCustomInput));
		DelegateFactory.dict.Add(typeof(UICamera.VoidDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_VoidDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.BoolDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_BoolDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.FloatDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_FloatDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.VectorDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_VectorDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.ObjectDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_ObjectDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.KeyCodeDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_KeyCodeDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.MoveDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_MoveDelegate));
		DelegateFactory.dict.Add(typeof(UICamera.GetTouchCountCallback), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_GetTouchCountCallback));
		DelegateFactory.dict.Add(typeof(UICamera.GetTouchCallback), new DelegateFactory.DelegateValue(DelegateFactory.UICamera_GetTouchCallback));
		DelegateFactory.dict.Add(typeof(EventDelegate.Callback), new DelegateFactory.DelegateValue(DelegateFactory.EventDelegate_Callback));
		DelegateFactory.dict.Add(typeof(UIEventListener.VoidDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_VoidDelegate));
		DelegateFactory.dict.Add(typeof(UIEventListener.BoolDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_BoolDelegate));
		DelegateFactory.dict.Add(typeof(UIEventListener.FloatDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_FloatDelegate));
		DelegateFactory.dict.Add(typeof(UIEventListener.VectorDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_VectorDelegate));
		DelegateFactory.dict.Add(typeof(UIEventListener.ObjectDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_ObjectDelegate));
		DelegateFactory.dict.Add(typeof(UIEventListener.KeyCodeDelegate), new DelegateFactory.DelegateValue(DelegateFactory.UIEventListener_KeyCodeDelegate));
		DelegateFactory.dict.Add(typeof(UIScrollView.OnDragNotification), new DelegateFactory.DelegateValue(DelegateFactory.UIScrollView_OnDragNotification));
		DelegateFactory.dict.Add(typeof(SpringPanel.OnFinished), new DelegateFactory.DelegateValue(DelegateFactory.SpringPanel_OnFinished));
		DelegateFactory.dict.Add(typeof(Predicate<ServerInfo>), new DelegateFactory.DelegateValue(DelegateFactory.System_Predicate_ServerInfo));
		DelegateFactory.dict.Add(typeof(Action<ServerInfo>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_ServerInfo));
		DelegateFactory.dict.Add(typeof(Comparison<ServerInfo>), new DelegateFactory.DelegateValue(DelegateFactory.System_Comparison_ServerInfo));
		DelegateFactory.dict.Add(typeof(Move.PathFinished), new DelegateFactory.DelegateValue(DelegateFactory.Move_PathFinished));
		DelegateFactory.dict.Add(typeof(RoleStateTransition.OnStateChanged), new DelegateFactory.DelegateValue(DelegateFactory.RoleStateTransition_OnStateChanged));
		DelegateFactory.dict.Add(typeof(EntityCreate.OnRoleCreated), new DelegateFactory.DelegateValue(DelegateFactory.EntityCreate_OnRoleCreated));
		DelegateFactory.dict.Add(typeof(EntityCreate.OnNpcCreated), new DelegateFactory.DelegateValue(DelegateFactory.EntityCreate_OnNpcCreated));
		DelegateFactory.dict.Add(typeof(Action<bool>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_bool));
		DelegateFactory.dict.Add(typeof(MessageBox.onButtonClicked), new DelegateFactory.DelegateValue(DelegateFactory.MessageBox_onButtonClicked));
		DelegateFactory.dict.Add(typeof(SDKInterface.LoginSucHandler), new DelegateFactory.DelegateValue(DelegateFactory.SDKInterface_LoginSucHandler));
		DelegateFactory.dict.Add(typeof(SDKInterface.LogoutHandler), new DelegateFactory.DelegateValue(DelegateFactory.SDKInterface_LogoutHandler));
		DelegateFactory.dict.Add(typeof(Action<string>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_string));
		DelegateFactory.dict.Add(typeof(Action<string, string>), new DelegateFactory.DelegateValue(DelegateFactory.System_Action_string_string));
	}

	[NoToLua]
	public static Delegate CreateDelegate(Type t, LuaFunction func = null)
	{
		DelegateFactory.DelegateValue delegateValue = null;
		if (!DelegateFactory.dict.TryGetValue(t, out delegateValue))
		{
			throw new LuaException(string.Format("Delegate {0} not register", LuaMisc.GetTypeName(t)), null, 1);
		}
		if (!(func != null))
		{
			return delegateValue(func, null, false);
		}
		LuaState luaState = func.GetLuaState();
		LuaDelegate luaDelegate = luaState.GetLuaDelegate(func);
		if (luaDelegate != null)
		{
			return Delegate.CreateDelegate(t, luaDelegate, luaDelegate.method);
		}
		Delegate @delegate = delegateValue(func, null, false);
		luaDelegate = (@delegate.Target as LuaDelegate);
		luaState.AddLuaDelegate(luaDelegate, func);
		return @delegate;
	}

	[NoToLua]
	public static Delegate CreateDelegate(Type t, LuaFunction func, LuaTable self)
	{
		DelegateFactory.DelegateValue delegateValue = null;
		if (!DelegateFactory.dict.TryGetValue(t, out delegateValue))
		{
			throw new LuaException(string.Format("Delegate {0} not register", LuaMisc.GetTypeName(t)), null, 1);
		}
		if (!(func != null))
		{
			return delegateValue(func, self, true);
		}
		LuaState luaState = func.GetLuaState();
		LuaDelegate luaDelegate = luaState.GetLuaDelegate(func, self);
		if (luaDelegate != null)
		{
			return Delegate.CreateDelegate(t, luaDelegate, luaDelegate.method);
		}
		Delegate @delegate = delegateValue(func, self, true);
		luaDelegate = (@delegate.Target as LuaDelegate);
		luaState.AddLuaDelegate(luaDelegate, func, self);
		return @delegate;
	}

	[NoToLua]
	public static Delegate RemoveDelegate(Delegate obj, LuaFunction func)
	{
		LuaState luaState = func.GetLuaState();
		Delegate[] invocationList = obj.GetInvocationList();
		for (int i = 0; i < invocationList.Length; i++)
		{
			LuaDelegate luaDelegate = invocationList[i].Target as LuaDelegate;
			if (luaDelegate != null && luaDelegate.func == func)
			{
				obj = Delegate.Remove(obj, invocationList[i]);
				luaState.DelayDispose(luaDelegate.func);
				break;
			}
		}
		return obj;
	}

	[NoToLua]
	public static Delegate RemoveDelegate(Delegate obj, Delegate dg)
	{
		LuaDelegate luaDelegate = dg.Target as LuaDelegate;
		if (luaDelegate == null)
		{
			obj = Delegate.Remove(obj, dg);
			return obj;
		}
		LuaState luaState = luaDelegate.func.GetLuaState();
		Delegate[] invocationList = obj.GetInvocationList();
		for (int i = 0; i < invocationList.Length; i++)
		{
			LuaDelegate luaDelegate2 = invocationList[i].Target as LuaDelegate;
			if (luaDelegate2 != null && luaDelegate2 == luaDelegate)
			{
				obj = Delegate.Remove(obj, invocationList[i]);
				luaState.DelayDispose(luaDelegate2.func);
				luaState.DelayDispose(luaDelegate2.self);
				break;
			}
		}
		return obj;
	}

	public static Delegate System_Action(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_Event system_Action_Event = new DelegateFactory.System_Action_Event(func);
			Action action = new Action(system_Action_Event.Call);
			system_Action_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_Event system_Action_Event2 = new DelegateFactory.System_Action_Event(func, self);
		Action action2 = new Action(system_Action_Event2.CallWithSelf);
		system_Action_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate UnityEngine_Events_UnityAction(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UnityAction(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_Events_UnityAction_Event unityEngine_Events_UnityAction_Event = new DelegateFactory.UnityEngine_Events_UnityAction_Event(func);
			UnityAction unityAction = new UnityAction(unityEngine_Events_UnityAction_Event.Call);
			unityEngine_Events_UnityAction_Event.method = unityAction.Method;
			return unityAction;
		}
		DelegateFactory.UnityEngine_Events_UnityAction_Event unityEngine_Events_UnityAction_Event2 = new DelegateFactory.UnityEngine_Events_UnityAction_Event(func, self);
		UnityAction unityAction2 = new UnityAction(unityEngine_Events_UnityAction_Event2.CallWithSelf);
		unityEngine_Events_UnityAction_Event2.method = unityAction2.Method;
		return unityAction2;
	}

	public static Delegate System_Predicate_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Predicate<int>((int param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.System_Predicate_int_Event system_Predicate_int_Event = new DelegateFactory.System_Predicate_int_Event(func);
			Predicate<int> predicate = new Predicate<int>(system_Predicate_int_Event.Call);
			system_Predicate_int_Event.method = predicate.Method;
			return predicate;
		}
		DelegateFactory.System_Predicate_int_Event system_Predicate_int_Event2 = new DelegateFactory.System_Predicate_int_Event(func, self);
		Predicate<int> predicate2 = new Predicate<int>(system_Predicate_int_Event2.CallWithSelf);
		system_Predicate_int_Event2.method = predicate2.Method;
		return predicate2;
	}

	public static Delegate System_Action_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<int>(delegate(int param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_int_Event system_Action_int_Event = new DelegateFactory.System_Action_int_Event(func);
			Action<int> action = new Action<int>(system_Action_int_Event.Call);
			system_Action_int_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_int_Event system_Action_int_Event2 = new DelegateFactory.System_Action_int_Event(func, self);
		Action<int> action2 = new Action<int>(system_Action_int_Event2.CallWithSelf);
		system_Action_int_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Comparison_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Comparison<int>((int param0, int param1) => 0);
		}
		if (!flag)
		{
			DelegateFactory.System_Comparison_int_Event system_Comparison_int_Event = new DelegateFactory.System_Comparison_int_Event(func);
			Comparison<int> comparison = new Comparison<int>(system_Comparison_int_Event.Call);
			system_Comparison_int_Event.method = comparison.Method;
			return comparison;
		}
		DelegateFactory.System_Comparison_int_Event system_Comparison_int_Event2 = new DelegateFactory.System_Comparison_int_Event(func, self);
		Comparison<int> comparison2 = new Comparison<int>(system_Comparison_int_Event2.CallWithSelf);
		system_Comparison_int_Event2.method = comparison2.Method;
		return comparison2;
	}

	public static Delegate DG_Tweening_Core_DOGetter_float(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOGetter<float>(() => 0f);
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOGetter_float_Event dG_Tweening_Core_DOGetter_float_Event = new DelegateFactory.DG_Tweening_Core_DOGetter_float_Event(func);
			DOGetter<float> dOGetter = new DOGetter<float>(dG_Tweening_Core_DOGetter_float_Event.Call);
			dG_Tweening_Core_DOGetter_float_Event.method = dOGetter.Method;
			return dOGetter;
		}
		DelegateFactory.DG_Tweening_Core_DOGetter_float_Event dG_Tweening_Core_DOGetter_float_Event2 = new DelegateFactory.DG_Tweening_Core_DOGetter_float_Event(func, self);
		DOGetter<float> dOGetter2 = new DOGetter<float>(dG_Tweening_Core_DOGetter_float_Event2.CallWithSelf);
		dG_Tweening_Core_DOGetter_float_Event2.method = dOGetter2.Method;
		return dOGetter2;
	}

	public static Delegate DG_Tweening_Core_DOSetter_float(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOSetter<float>(delegate(float param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOSetter_float_Event dG_Tweening_Core_DOSetter_float_Event = new DelegateFactory.DG_Tweening_Core_DOSetter_float_Event(func);
			DOSetter<float> dOSetter = new DOSetter<float>(dG_Tweening_Core_DOSetter_float_Event.Call);
			dG_Tweening_Core_DOSetter_float_Event.method = dOSetter.Method;
			return dOSetter;
		}
		DelegateFactory.DG_Tweening_Core_DOSetter_float_Event dG_Tweening_Core_DOSetter_float_Event2 = new DelegateFactory.DG_Tweening_Core_DOSetter_float_Event(func, self);
		DOSetter<float> dOSetter2 = new DOSetter<float>(dG_Tweening_Core_DOSetter_float_Event2.CallWithSelf);
		dG_Tweening_Core_DOSetter_float_Event2.method = dOSetter2.Method;
		return dOSetter2;
	}

	public static Delegate DG_Tweening_Core_DOGetter_double(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOGetter<double>(() => 0.0);
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOGetter_double_Event dG_Tweening_Core_DOGetter_double_Event = new DelegateFactory.DG_Tweening_Core_DOGetter_double_Event(func);
			DOGetter<double> dOGetter = new DOGetter<double>(dG_Tweening_Core_DOGetter_double_Event.Call);
			dG_Tweening_Core_DOGetter_double_Event.method = dOGetter.Method;
			return dOGetter;
		}
		DelegateFactory.DG_Tweening_Core_DOGetter_double_Event dG_Tweening_Core_DOGetter_double_Event2 = new DelegateFactory.DG_Tweening_Core_DOGetter_double_Event(func, self);
		DOGetter<double> dOGetter2 = new DOGetter<double>(dG_Tweening_Core_DOGetter_double_Event2.CallWithSelf);
		dG_Tweening_Core_DOGetter_double_Event2.method = dOGetter2.Method;
		return dOGetter2;
	}

	public static Delegate DG_Tweening_Core_DOSetter_double(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOSetter<double>(delegate(double param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOSetter_double_Event dG_Tweening_Core_DOSetter_double_Event = new DelegateFactory.DG_Tweening_Core_DOSetter_double_Event(func);
			DOSetter<double> dOSetter = new DOSetter<double>(dG_Tweening_Core_DOSetter_double_Event.Call);
			dG_Tweening_Core_DOSetter_double_Event.method = dOSetter.Method;
			return dOSetter;
		}
		DelegateFactory.DG_Tweening_Core_DOSetter_double_Event dG_Tweening_Core_DOSetter_double_Event2 = new DelegateFactory.DG_Tweening_Core_DOSetter_double_Event(func, self);
		DOSetter<double> dOSetter2 = new DOSetter<double>(dG_Tweening_Core_DOSetter_double_Event2.CallWithSelf);
		dG_Tweening_Core_DOSetter_double_Event2.method = dOSetter2.Method;
		return dOSetter2;
	}

	public static Delegate DG_Tweening_Core_DOGetter_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOGetter<int>(() => 0);
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOGetter_int_Event dG_Tweening_Core_DOGetter_int_Event = new DelegateFactory.DG_Tweening_Core_DOGetter_int_Event(func);
			DOGetter<int> dOGetter = new DOGetter<int>(dG_Tweening_Core_DOGetter_int_Event.Call);
			dG_Tweening_Core_DOGetter_int_Event.method = dOGetter.Method;
			return dOGetter;
		}
		DelegateFactory.DG_Tweening_Core_DOGetter_int_Event dG_Tweening_Core_DOGetter_int_Event2 = new DelegateFactory.DG_Tweening_Core_DOGetter_int_Event(func, self);
		DOGetter<int> dOGetter2 = new DOGetter<int>(dG_Tweening_Core_DOGetter_int_Event2.CallWithSelf);
		dG_Tweening_Core_DOGetter_int_Event2.method = dOGetter2.Method;
		return dOGetter2;
	}

	public static Delegate DG_Tweening_Core_DOSetter_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOSetter<int>(delegate(int param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOSetter_int_Event dG_Tweening_Core_DOSetter_int_Event = new DelegateFactory.DG_Tweening_Core_DOSetter_int_Event(func);
			DOSetter<int> dOSetter = new DOSetter<int>(dG_Tweening_Core_DOSetter_int_Event.Call);
			dG_Tweening_Core_DOSetter_int_Event.method = dOSetter.Method;
			return dOSetter;
		}
		DelegateFactory.DG_Tweening_Core_DOSetter_int_Event dG_Tweening_Core_DOSetter_int_Event2 = new DelegateFactory.DG_Tweening_Core_DOSetter_int_Event(func, self);
		DOSetter<int> dOSetter2 = new DOSetter<int>(dG_Tweening_Core_DOSetter_int_Event2.CallWithSelf);
		dG_Tweening_Core_DOSetter_int_Event2.method = dOSetter2.Method;
		return dOSetter2;
	}

	public static Delegate DG_Tweening_Core_DOGetter_uint(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOGetter<uint>(() => 0u);
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOGetter_uint_Event dG_Tweening_Core_DOGetter_uint_Event = new DelegateFactory.DG_Tweening_Core_DOGetter_uint_Event(func);
			DOGetter<uint> dOGetter = new DOGetter<uint>(dG_Tweening_Core_DOGetter_uint_Event.Call);
			dG_Tweening_Core_DOGetter_uint_Event.method = dOGetter.Method;
			return dOGetter;
		}
		DelegateFactory.DG_Tweening_Core_DOGetter_uint_Event dG_Tweening_Core_DOGetter_uint_Event2 = new DelegateFactory.DG_Tweening_Core_DOGetter_uint_Event(func, self);
		DOGetter<uint> dOGetter2 = new DOGetter<uint>(dG_Tweening_Core_DOGetter_uint_Event2.CallWithSelf);
		dG_Tweening_Core_DOGetter_uint_Event2.method = dOGetter2.Method;
		return dOGetter2;
	}

	public static Delegate DG_Tweening_Core_DOSetter_uint(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOSetter<uint>(delegate(uint param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOSetter_uint_Event dG_Tweening_Core_DOSetter_uint_Event = new DelegateFactory.DG_Tweening_Core_DOSetter_uint_Event(func);
			DOSetter<uint> dOSetter = new DOSetter<uint>(dG_Tweening_Core_DOSetter_uint_Event.Call);
			dG_Tweening_Core_DOSetter_uint_Event.method = dOSetter.Method;
			return dOSetter;
		}
		DelegateFactory.DG_Tweening_Core_DOSetter_uint_Event dG_Tweening_Core_DOSetter_uint_Event2 = new DelegateFactory.DG_Tweening_Core_DOSetter_uint_Event(func, self);
		DOSetter<uint> dOSetter2 = new DOSetter<uint>(dG_Tweening_Core_DOSetter_uint_Event2.CallWithSelf);
		dG_Tweening_Core_DOSetter_uint_Event2.method = dOSetter2.Method;
		return dOSetter2;
	}

	public static Delegate DG_Tweening_Core_DOGetter_long(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOGetter<long>(() => 0L);
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOGetter_long_Event dG_Tweening_Core_DOGetter_long_Event = new DelegateFactory.DG_Tweening_Core_DOGetter_long_Event(func);
			DOGetter<long> dOGetter = new DOGetter<long>(dG_Tweening_Core_DOGetter_long_Event.Call);
			dG_Tweening_Core_DOGetter_long_Event.method = dOGetter.Method;
			return dOGetter;
		}
		DelegateFactory.DG_Tweening_Core_DOGetter_long_Event dG_Tweening_Core_DOGetter_long_Event2 = new DelegateFactory.DG_Tweening_Core_DOGetter_long_Event(func, self);
		DOGetter<long> dOGetter2 = new DOGetter<long>(dG_Tweening_Core_DOGetter_long_Event2.CallWithSelf);
		dG_Tweening_Core_DOGetter_long_Event2.method = dOGetter2.Method;
		return dOGetter2;
	}

	public static Delegate DG_Tweening_Core_DOSetter_long(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOSetter<long>(delegate(long param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOSetter_long_Event dG_Tweening_Core_DOSetter_long_Event = new DelegateFactory.DG_Tweening_Core_DOSetter_long_Event(func);
			DOSetter<long> dOSetter = new DOSetter<long>(dG_Tweening_Core_DOSetter_long_Event.Call);
			dG_Tweening_Core_DOSetter_long_Event.method = dOSetter.Method;
			return dOSetter;
		}
		DelegateFactory.DG_Tweening_Core_DOSetter_long_Event dG_Tweening_Core_DOSetter_long_Event2 = new DelegateFactory.DG_Tweening_Core_DOSetter_long_Event(func, self);
		DOSetter<long> dOSetter2 = new DOSetter<long>(dG_Tweening_Core_DOSetter_long_Event2.CallWithSelf);
		dG_Tweening_Core_DOSetter_long_Event2.method = dOSetter2.Method;
		return dOSetter2;
	}

	public static Delegate DG_Tweening_Core_DOGetter_ulong(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOGetter<ulong>(() => 0uL);
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOGetter_ulong_Event dG_Tweening_Core_DOGetter_ulong_Event = new DelegateFactory.DG_Tweening_Core_DOGetter_ulong_Event(func);
			DOGetter<ulong> dOGetter = new DOGetter<ulong>(dG_Tweening_Core_DOGetter_ulong_Event.Call);
			dG_Tweening_Core_DOGetter_ulong_Event.method = dOGetter.Method;
			return dOGetter;
		}
		DelegateFactory.DG_Tweening_Core_DOGetter_ulong_Event dG_Tweening_Core_DOGetter_ulong_Event2 = new DelegateFactory.DG_Tweening_Core_DOGetter_ulong_Event(func, self);
		DOGetter<ulong> dOGetter2 = new DOGetter<ulong>(dG_Tweening_Core_DOGetter_ulong_Event2.CallWithSelf);
		dG_Tweening_Core_DOGetter_ulong_Event2.method = dOGetter2.Method;
		return dOGetter2;
	}

	public static Delegate DG_Tweening_Core_DOSetter_ulong(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOSetter<ulong>(delegate(ulong param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOSetter_ulong_Event dG_Tweening_Core_DOSetter_ulong_Event = new DelegateFactory.DG_Tweening_Core_DOSetter_ulong_Event(func);
			DOSetter<ulong> dOSetter = new DOSetter<ulong>(dG_Tweening_Core_DOSetter_ulong_Event.Call);
			dG_Tweening_Core_DOSetter_ulong_Event.method = dOSetter.Method;
			return dOSetter;
		}
		DelegateFactory.DG_Tweening_Core_DOSetter_ulong_Event dG_Tweening_Core_DOSetter_ulong_Event2 = new DelegateFactory.DG_Tweening_Core_DOSetter_ulong_Event(func, self);
		DOSetter<ulong> dOSetter2 = new DOSetter<ulong>(dG_Tweening_Core_DOSetter_ulong_Event2.CallWithSelf);
		dG_Tweening_Core_DOSetter_ulong_Event2.method = dOSetter2.Method;
		return dOSetter2;
	}

	public static Delegate DG_Tweening_Core_DOGetter_string(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOGetter<string>(() => null);
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOGetter_string_Event dG_Tweening_Core_DOGetter_string_Event = new DelegateFactory.DG_Tweening_Core_DOGetter_string_Event(func);
			DOGetter<string> dOGetter = new DOGetter<string>(dG_Tweening_Core_DOGetter_string_Event.Call);
			dG_Tweening_Core_DOGetter_string_Event.method = dOGetter.Method;
			return dOGetter;
		}
		DelegateFactory.DG_Tweening_Core_DOGetter_string_Event dG_Tweening_Core_DOGetter_string_Event2 = new DelegateFactory.DG_Tweening_Core_DOGetter_string_Event(func, self);
		DOGetter<string> dOGetter2 = new DOGetter<string>(dG_Tweening_Core_DOGetter_string_Event2.CallWithSelf);
		dG_Tweening_Core_DOGetter_string_Event2.method = dOGetter2.Method;
		return dOGetter2;
	}

	public static Delegate DG_Tweening_Core_DOSetter_string(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOSetter<string>(delegate(string param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOSetter_string_Event dG_Tweening_Core_DOSetter_string_Event = new DelegateFactory.DG_Tweening_Core_DOSetter_string_Event(func);
			DOSetter<string> dOSetter = new DOSetter<string>(dG_Tweening_Core_DOSetter_string_Event.Call);
			dG_Tweening_Core_DOSetter_string_Event.method = dOSetter.Method;
			return dOSetter;
		}
		DelegateFactory.DG_Tweening_Core_DOSetter_string_Event dG_Tweening_Core_DOSetter_string_Event2 = new DelegateFactory.DG_Tweening_Core_DOSetter_string_Event(func, self);
		DOSetter<string> dOSetter2 = new DOSetter<string>(dG_Tweening_Core_DOSetter_string_Event2.CallWithSelf);
		dG_Tweening_Core_DOSetter_string_Event2.method = dOSetter2.Method;
		return dOSetter2;
	}

	public static Delegate DG_Tweening_Core_DOGetter_UnityEngine_Vector2(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOGetter<Vector2>(() => default(Vector2));
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Vector2_Event dG_Tweening_Core_DOGetter_UnityEngine_Vector2_Event = new DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Vector2_Event(func);
			DOGetter<Vector2> dOGetter = new DOGetter<Vector2>(dG_Tweening_Core_DOGetter_UnityEngine_Vector2_Event.Call);
			dG_Tweening_Core_DOGetter_UnityEngine_Vector2_Event.method = dOGetter.Method;
			return dOGetter;
		}
		DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Vector2_Event dG_Tweening_Core_DOGetter_UnityEngine_Vector2_Event2 = new DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Vector2_Event(func, self);
		DOGetter<Vector2> dOGetter2 = new DOGetter<Vector2>(dG_Tweening_Core_DOGetter_UnityEngine_Vector2_Event2.CallWithSelf);
		dG_Tweening_Core_DOGetter_UnityEngine_Vector2_Event2.method = dOGetter2.Method;
		return dOGetter2;
	}

	public static Delegate DG_Tweening_Core_DOSetter_UnityEngine_Vector2(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOSetter<Vector2>(delegate(Vector2 param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Vector2_Event dG_Tweening_Core_DOSetter_UnityEngine_Vector2_Event = new DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Vector2_Event(func);
			DOSetter<Vector2> dOSetter = new DOSetter<Vector2>(dG_Tweening_Core_DOSetter_UnityEngine_Vector2_Event.Call);
			dG_Tweening_Core_DOSetter_UnityEngine_Vector2_Event.method = dOSetter.Method;
			return dOSetter;
		}
		DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Vector2_Event dG_Tweening_Core_DOSetter_UnityEngine_Vector2_Event2 = new DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Vector2_Event(func, self);
		DOSetter<Vector2> dOSetter2 = new DOSetter<Vector2>(dG_Tweening_Core_DOSetter_UnityEngine_Vector2_Event2.CallWithSelf);
		dG_Tweening_Core_DOSetter_UnityEngine_Vector2_Event2.method = dOSetter2.Method;
		return dOSetter2;
	}

	public static Delegate DG_Tweening_Core_DOGetter_UnityEngine_Vector3(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOGetter<Vector3>(() => default(Vector3));
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Vector3_Event dG_Tweening_Core_DOGetter_UnityEngine_Vector3_Event = new DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Vector3_Event(func);
			DOGetter<Vector3> dOGetter = new DOGetter<Vector3>(dG_Tweening_Core_DOGetter_UnityEngine_Vector3_Event.Call);
			dG_Tweening_Core_DOGetter_UnityEngine_Vector3_Event.method = dOGetter.Method;
			return dOGetter;
		}
		DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Vector3_Event dG_Tweening_Core_DOGetter_UnityEngine_Vector3_Event2 = new DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Vector3_Event(func, self);
		DOGetter<Vector3> dOGetter2 = new DOGetter<Vector3>(dG_Tweening_Core_DOGetter_UnityEngine_Vector3_Event2.CallWithSelf);
		dG_Tweening_Core_DOGetter_UnityEngine_Vector3_Event2.method = dOGetter2.Method;
		return dOGetter2;
	}

	public static Delegate DG_Tweening_Core_DOSetter_UnityEngine_Vector3(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOSetter<Vector3>(delegate(Vector3 param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Vector3_Event dG_Tweening_Core_DOSetter_UnityEngine_Vector3_Event = new DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Vector3_Event(func);
			DOSetter<Vector3> dOSetter = new DOSetter<Vector3>(dG_Tweening_Core_DOSetter_UnityEngine_Vector3_Event.Call);
			dG_Tweening_Core_DOSetter_UnityEngine_Vector3_Event.method = dOSetter.Method;
			return dOSetter;
		}
		DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Vector3_Event dG_Tweening_Core_DOSetter_UnityEngine_Vector3_Event2 = new DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Vector3_Event(func, self);
		DOSetter<Vector3> dOSetter2 = new DOSetter<Vector3>(dG_Tweening_Core_DOSetter_UnityEngine_Vector3_Event2.CallWithSelf);
		dG_Tweening_Core_DOSetter_UnityEngine_Vector3_Event2.method = dOSetter2.Method;
		return dOSetter2;
	}

	public static Delegate DG_Tweening_Core_DOGetter_UnityEngine_Vector4(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOGetter<Vector4>(() => default(Vector4));
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Vector4_Event dG_Tweening_Core_DOGetter_UnityEngine_Vector4_Event = new DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Vector4_Event(func);
			DOGetter<Vector4> dOGetter = new DOGetter<Vector4>(dG_Tweening_Core_DOGetter_UnityEngine_Vector4_Event.Call);
			dG_Tweening_Core_DOGetter_UnityEngine_Vector4_Event.method = dOGetter.Method;
			return dOGetter;
		}
		DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Vector4_Event dG_Tweening_Core_DOGetter_UnityEngine_Vector4_Event2 = new DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Vector4_Event(func, self);
		DOGetter<Vector4> dOGetter2 = new DOGetter<Vector4>(dG_Tweening_Core_DOGetter_UnityEngine_Vector4_Event2.CallWithSelf);
		dG_Tweening_Core_DOGetter_UnityEngine_Vector4_Event2.method = dOGetter2.Method;
		return dOGetter2;
	}

	public static Delegate DG_Tweening_Core_DOSetter_UnityEngine_Vector4(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOSetter<Vector4>(delegate(Vector4 param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Vector4_Event dG_Tweening_Core_DOSetter_UnityEngine_Vector4_Event = new DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Vector4_Event(func);
			DOSetter<Vector4> dOSetter = new DOSetter<Vector4>(dG_Tweening_Core_DOSetter_UnityEngine_Vector4_Event.Call);
			dG_Tweening_Core_DOSetter_UnityEngine_Vector4_Event.method = dOSetter.Method;
			return dOSetter;
		}
		DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Vector4_Event dG_Tweening_Core_DOSetter_UnityEngine_Vector4_Event2 = new DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Vector4_Event(func, self);
		DOSetter<Vector4> dOSetter2 = new DOSetter<Vector4>(dG_Tweening_Core_DOSetter_UnityEngine_Vector4_Event2.CallWithSelf);
		dG_Tweening_Core_DOSetter_UnityEngine_Vector4_Event2.method = dOSetter2.Method;
		return dOSetter2;
	}

	public static Delegate DG_Tweening_Core_DOGetter_UnityEngine_Quaternion(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOGetter<Quaternion>(() => default(Quaternion));
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Quaternion_Event dG_Tweening_Core_DOGetter_UnityEngine_Quaternion_Event = new DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Quaternion_Event(func);
			DOGetter<Quaternion> dOGetter = new DOGetter<Quaternion>(dG_Tweening_Core_DOGetter_UnityEngine_Quaternion_Event.Call);
			dG_Tweening_Core_DOGetter_UnityEngine_Quaternion_Event.method = dOGetter.Method;
			return dOGetter;
		}
		DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Quaternion_Event dG_Tweening_Core_DOGetter_UnityEngine_Quaternion_Event2 = new DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Quaternion_Event(func, self);
		DOGetter<Quaternion> dOGetter2 = new DOGetter<Quaternion>(dG_Tweening_Core_DOGetter_UnityEngine_Quaternion_Event2.CallWithSelf);
		dG_Tweening_Core_DOGetter_UnityEngine_Quaternion_Event2.method = dOGetter2.Method;
		return dOGetter2;
	}

	public static Delegate DG_Tweening_Core_DOSetter_UnityEngine_Quaternion(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOSetter<Quaternion>(delegate(Quaternion param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Quaternion_Event dG_Tweening_Core_DOSetter_UnityEngine_Quaternion_Event = new DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Quaternion_Event(func);
			DOSetter<Quaternion> dOSetter = new DOSetter<Quaternion>(dG_Tweening_Core_DOSetter_UnityEngine_Quaternion_Event.Call);
			dG_Tweening_Core_DOSetter_UnityEngine_Quaternion_Event.method = dOSetter.Method;
			return dOSetter;
		}
		DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Quaternion_Event dG_Tweening_Core_DOSetter_UnityEngine_Quaternion_Event2 = new DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Quaternion_Event(func, self);
		DOSetter<Quaternion> dOSetter2 = new DOSetter<Quaternion>(dG_Tweening_Core_DOSetter_UnityEngine_Quaternion_Event2.CallWithSelf);
		dG_Tweening_Core_DOSetter_UnityEngine_Quaternion_Event2.method = dOSetter2.Method;
		return dOSetter2;
	}

	public static Delegate DG_Tweening_Core_DOGetter_UnityEngine_Color(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOGetter<Color>(() => default(Color));
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Color_Event dG_Tweening_Core_DOGetter_UnityEngine_Color_Event = new DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Color_Event(func);
			DOGetter<Color> dOGetter = new DOGetter<Color>(dG_Tweening_Core_DOGetter_UnityEngine_Color_Event.Call);
			dG_Tweening_Core_DOGetter_UnityEngine_Color_Event.method = dOGetter.Method;
			return dOGetter;
		}
		DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Color_Event dG_Tweening_Core_DOGetter_UnityEngine_Color_Event2 = new DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Color_Event(func, self);
		DOGetter<Color> dOGetter2 = new DOGetter<Color>(dG_Tweening_Core_DOGetter_UnityEngine_Color_Event2.CallWithSelf);
		dG_Tweening_Core_DOGetter_UnityEngine_Color_Event2.method = dOGetter2.Method;
		return dOGetter2;
	}

	public static Delegate DG_Tweening_Core_DOSetter_UnityEngine_Color(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOSetter<Color>(delegate(Color param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Color_Event dG_Tweening_Core_DOSetter_UnityEngine_Color_Event = new DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Color_Event(func);
			DOSetter<Color> dOSetter = new DOSetter<Color>(dG_Tweening_Core_DOSetter_UnityEngine_Color_Event.Call);
			dG_Tweening_Core_DOSetter_UnityEngine_Color_Event.method = dOSetter.Method;
			return dOSetter;
		}
		DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Color_Event dG_Tweening_Core_DOSetter_UnityEngine_Color_Event2 = new DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Color_Event(func, self);
		DOSetter<Color> dOSetter2 = new DOSetter<Color>(dG_Tweening_Core_DOSetter_UnityEngine_Color_Event2.CallWithSelf);
		dG_Tweening_Core_DOSetter_UnityEngine_Color_Event2.method = dOSetter2.Method;
		return dOSetter2;
	}

	public static Delegate DG_Tweening_Core_DOGetter_UnityEngine_Rect(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOGetter<Rect>(() => default(Rect));
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Rect_Event dG_Tweening_Core_DOGetter_UnityEngine_Rect_Event = new DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Rect_Event(func);
			DOGetter<Rect> dOGetter = new DOGetter<Rect>(dG_Tweening_Core_DOGetter_UnityEngine_Rect_Event.Call);
			dG_Tweening_Core_DOGetter_UnityEngine_Rect_Event.method = dOGetter.Method;
			return dOGetter;
		}
		DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Rect_Event dG_Tweening_Core_DOGetter_UnityEngine_Rect_Event2 = new DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_Rect_Event(func, self);
		DOGetter<Rect> dOGetter2 = new DOGetter<Rect>(dG_Tweening_Core_DOGetter_UnityEngine_Rect_Event2.CallWithSelf);
		dG_Tweening_Core_DOGetter_UnityEngine_Rect_Event2.method = dOGetter2.Method;
		return dOGetter2;
	}

	public static Delegate DG_Tweening_Core_DOSetter_UnityEngine_Rect(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOSetter<Rect>(delegate(Rect param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Rect_Event dG_Tweening_Core_DOSetter_UnityEngine_Rect_Event = new DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Rect_Event(func);
			DOSetter<Rect> dOSetter = new DOSetter<Rect>(dG_Tweening_Core_DOSetter_UnityEngine_Rect_Event.Call);
			dG_Tweening_Core_DOSetter_UnityEngine_Rect_Event.method = dOSetter.Method;
			return dOSetter;
		}
		DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Rect_Event dG_Tweening_Core_DOSetter_UnityEngine_Rect_Event2 = new DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_Rect_Event(func, self);
		DOSetter<Rect> dOSetter2 = new DOSetter<Rect>(dG_Tweening_Core_DOSetter_UnityEngine_Rect_Event2.CallWithSelf);
		dG_Tweening_Core_DOSetter_UnityEngine_Rect_Event2.method = dOSetter2.Method;
		return dOSetter2;
	}

	public static Delegate DG_Tweening_Core_DOGetter_UnityEngine_RectOffset(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOGetter<RectOffset>(() => null);
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_RectOffset_Event dG_Tweening_Core_DOGetter_UnityEngine_RectOffset_Event = new DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_RectOffset_Event(func);
			DOGetter<RectOffset> dOGetter = new DOGetter<RectOffset>(dG_Tweening_Core_DOGetter_UnityEngine_RectOffset_Event.Call);
			dG_Tweening_Core_DOGetter_UnityEngine_RectOffset_Event.method = dOGetter.Method;
			return dOGetter;
		}
		DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_RectOffset_Event dG_Tweening_Core_DOGetter_UnityEngine_RectOffset_Event2 = new DelegateFactory.DG_Tweening_Core_DOGetter_UnityEngine_RectOffset_Event(func, self);
		DOGetter<RectOffset> dOGetter2 = new DOGetter<RectOffset>(dG_Tweening_Core_DOGetter_UnityEngine_RectOffset_Event2.CallWithSelf);
		dG_Tweening_Core_DOGetter_UnityEngine_RectOffset_Event2.method = dOGetter2.Method;
		return dOGetter2;
	}

	public static Delegate DG_Tweening_Core_DOSetter_UnityEngine_RectOffset(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new DOSetter<RectOffset>(delegate(RectOffset param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_RectOffset_Event dG_Tweening_Core_DOSetter_UnityEngine_RectOffset_Event = new DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_RectOffset_Event(func);
			DOSetter<RectOffset> dOSetter = new DOSetter<RectOffset>(dG_Tweening_Core_DOSetter_UnityEngine_RectOffset_Event.Call);
			dG_Tweening_Core_DOSetter_UnityEngine_RectOffset_Event.method = dOSetter.Method;
			return dOSetter;
		}
		DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_RectOffset_Event dG_Tweening_Core_DOSetter_UnityEngine_RectOffset_Event2 = new DelegateFactory.DG_Tweening_Core_DOSetter_UnityEngine_RectOffset_Event(func, self);
		DOSetter<RectOffset> dOSetter2 = new DOSetter<RectOffset>(dG_Tweening_Core_DOSetter_UnityEngine_RectOffset_Event2.CallWithSelf);
		dG_Tweening_Core_DOSetter_UnityEngine_RectOffset_Event2.method = dOSetter2.Method;
		return dOSetter2;
	}

	public static Delegate DG_Tweening_TweenCallback_float(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new TweenCallback<float>(delegate(float param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_TweenCallback_float_Event dG_Tweening_TweenCallback_float_Event = new DelegateFactory.DG_Tweening_TweenCallback_float_Event(func);
			TweenCallback<float> tweenCallback = new TweenCallback<float>(dG_Tweening_TweenCallback_float_Event.Call);
			dG_Tweening_TweenCallback_float_Event.method = tweenCallback.Method;
			return tweenCallback;
		}
		DelegateFactory.DG_Tweening_TweenCallback_float_Event dG_Tweening_TweenCallback_float_Event2 = new DelegateFactory.DG_Tweening_TweenCallback_float_Event(func, self);
		TweenCallback<float> tweenCallback2 = new TweenCallback<float>(dG_Tweening_TweenCallback_float_Event2.CallWithSelf);
		dG_Tweening_TweenCallback_float_Event2.method = tweenCallback2.Method;
		return tweenCallback2;
	}

	public static Delegate DG_Tweening_TweenCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new TweenCallback(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_TweenCallback_Event dG_Tweening_TweenCallback_Event = new DelegateFactory.DG_Tweening_TweenCallback_Event(func);
			TweenCallback tweenCallback = new TweenCallback(dG_Tweening_TweenCallback_Event.Call);
			dG_Tweening_TweenCallback_Event.method = tweenCallback.Method;
			return tweenCallback;
		}
		DelegateFactory.DG_Tweening_TweenCallback_Event dG_Tweening_TweenCallback_Event2 = new DelegateFactory.DG_Tweening_TweenCallback_Event(func, self);
		TweenCallback tweenCallback2 = new TweenCallback(dG_Tweening_TweenCallback_Event2.CallWithSelf);
		dG_Tweening_TweenCallback_Event2.method = tweenCallback2.Method;
		return tweenCallback2;
	}

	public static Delegate DG_Tweening_EaseFunction(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new EaseFunction((float param0, float param1, float param2, float param3) => 0f);
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_EaseFunction_Event dG_Tweening_EaseFunction_Event = new DelegateFactory.DG_Tweening_EaseFunction_Event(func);
			EaseFunction easeFunction = new EaseFunction(dG_Tweening_EaseFunction_Event.Call);
			dG_Tweening_EaseFunction_Event.method = easeFunction.Method;
			return easeFunction;
		}
		DelegateFactory.DG_Tweening_EaseFunction_Event dG_Tweening_EaseFunction_Event2 = new DelegateFactory.DG_Tweening_EaseFunction_Event(func, self);
		EaseFunction easeFunction2 = new EaseFunction(dG_Tweening_EaseFunction_Event2.CallWithSelf);
		dG_Tweening_EaseFunction_Event2.method = easeFunction2.Method;
		return easeFunction2;
	}

	public static Delegate DG_Tweening_TweenCallback_int(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new TweenCallback<int>(delegate(int param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.DG_Tweening_TweenCallback_int_Event dG_Tweening_TweenCallback_int_Event = new DelegateFactory.DG_Tweening_TweenCallback_int_Event(func);
			TweenCallback<int> tweenCallback = new TweenCallback<int>(dG_Tweening_TweenCallback_int_Event.Call);
			dG_Tweening_TweenCallback_int_Event.method = tweenCallback.Method;
			return tweenCallback;
		}
		DelegateFactory.DG_Tweening_TweenCallback_int_Event dG_Tweening_TweenCallback_int_Event2 = new DelegateFactory.DG_Tweening_TweenCallback_int_Event(func, self);
		TweenCallback<int> tweenCallback2 = new TweenCallback<int>(dG_Tweening_TweenCallback_int_Event2.CallWithSelf);
		dG_Tweening_TweenCallback_int_Event2.method = tweenCallback2.Method;
		return tweenCallback2;
	}

	public static Delegate UnityEngine_Camera_CameraCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Camera.CameraCallback(delegate(Camera param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_Camera_CameraCallback_Event unityEngine_Camera_CameraCallback_Event = new DelegateFactory.UnityEngine_Camera_CameraCallback_Event(func);
			Camera.CameraCallback cameraCallback = new Camera.CameraCallback(unityEngine_Camera_CameraCallback_Event.Call);
			unityEngine_Camera_CameraCallback_Event.method = cameraCallback.Method;
			return cameraCallback;
		}
		DelegateFactory.UnityEngine_Camera_CameraCallback_Event unityEngine_Camera_CameraCallback_Event2 = new DelegateFactory.UnityEngine_Camera_CameraCallback_Event(func, self);
		Camera.CameraCallback cameraCallback2 = new Camera.CameraCallback(unityEngine_Camera_CameraCallback_Event2.CallWithSelf);
		unityEngine_Camera_CameraCallback_Event2.method = cameraCallback2.Method;
		return cameraCallback2;
	}

	public static Delegate UnityEngine_Application_LogCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Application.LogCallback(delegate(string param0, string param1, LogType param2)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_Application_LogCallback_Event unityEngine_Application_LogCallback_Event = new DelegateFactory.UnityEngine_Application_LogCallback_Event(func);
			Application.LogCallback logCallback = new Application.LogCallback(unityEngine_Application_LogCallback_Event.Call);
			unityEngine_Application_LogCallback_Event.method = logCallback.Method;
			return logCallback;
		}
		DelegateFactory.UnityEngine_Application_LogCallback_Event unityEngine_Application_LogCallback_Event2 = new DelegateFactory.UnityEngine_Application_LogCallback_Event(func, self);
		Application.LogCallback logCallback2 = new Application.LogCallback(unityEngine_Application_LogCallback_Event2.CallWithSelf);
		unityEngine_Application_LogCallback_Event2.method = logCallback2.Method;
		return logCallback2;
	}

	public static Delegate UnityEngine_Application_AdvertisingIdentifierCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Application.AdvertisingIdentifierCallback(delegate(string param0, bool param1, string param2)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_Application_AdvertisingIdentifierCallback_Event unityEngine_Application_AdvertisingIdentifierCallback_Event = new DelegateFactory.UnityEngine_Application_AdvertisingIdentifierCallback_Event(func);
			Application.AdvertisingIdentifierCallback advertisingIdentifierCallback = new Application.AdvertisingIdentifierCallback(unityEngine_Application_AdvertisingIdentifierCallback_Event.Call);
			unityEngine_Application_AdvertisingIdentifierCallback_Event.method = advertisingIdentifierCallback.Method;
			return advertisingIdentifierCallback;
		}
		DelegateFactory.UnityEngine_Application_AdvertisingIdentifierCallback_Event unityEngine_Application_AdvertisingIdentifierCallback_Event2 = new DelegateFactory.UnityEngine_Application_AdvertisingIdentifierCallback_Event(func, self);
		Application.AdvertisingIdentifierCallback advertisingIdentifierCallback2 = new Application.AdvertisingIdentifierCallback(unityEngine_Application_AdvertisingIdentifierCallback_Event2.CallWithSelf);
		unityEngine_Application_AdvertisingIdentifierCallback_Event2.method = advertisingIdentifierCallback2.Method;
		return advertisingIdentifierCallback2;
	}

	public static Delegate UnityEngine_AudioClip_PCMReaderCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new AudioClip.PCMReaderCallback(delegate(float[] param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_AudioClip_PCMReaderCallback_Event unityEngine_AudioClip_PCMReaderCallback_Event = new DelegateFactory.UnityEngine_AudioClip_PCMReaderCallback_Event(func);
			AudioClip.PCMReaderCallback pCMReaderCallback = new AudioClip.PCMReaderCallback(unityEngine_AudioClip_PCMReaderCallback_Event.Call);
			unityEngine_AudioClip_PCMReaderCallback_Event.method = pCMReaderCallback.Method;
			return pCMReaderCallback;
		}
		DelegateFactory.UnityEngine_AudioClip_PCMReaderCallback_Event unityEngine_AudioClip_PCMReaderCallback_Event2 = new DelegateFactory.UnityEngine_AudioClip_PCMReaderCallback_Event(func, self);
		AudioClip.PCMReaderCallback pCMReaderCallback2 = new AudioClip.PCMReaderCallback(unityEngine_AudioClip_PCMReaderCallback_Event2.CallWithSelf);
		unityEngine_AudioClip_PCMReaderCallback_Event2.method = pCMReaderCallback2.Method;
		return pCMReaderCallback2;
	}

	public static Delegate UnityEngine_AudioClip_PCMSetPositionCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new AudioClip.PCMSetPositionCallback(delegate(int param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UnityEngine_AudioClip_PCMSetPositionCallback_Event unityEngine_AudioClip_PCMSetPositionCallback_Event = new DelegateFactory.UnityEngine_AudioClip_PCMSetPositionCallback_Event(func);
			AudioClip.PCMSetPositionCallback pCMSetPositionCallback = new AudioClip.PCMSetPositionCallback(unityEngine_AudioClip_PCMSetPositionCallback_Event.Call);
			unityEngine_AudioClip_PCMSetPositionCallback_Event.method = pCMSetPositionCallback.Method;
			return pCMSetPositionCallback;
		}
		DelegateFactory.UnityEngine_AudioClip_PCMSetPositionCallback_Event unityEngine_AudioClip_PCMSetPositionCallback_Event2 = new DelegateFactory.UnityEngine_AudioClip_PCMSetPositionCallback_Event(func, self);
		AudioClip.PCMSetPositionCallback pCMSetPositionCallback2 = new AudioClip.PCMSetPositionCallback(unityEngine_AudioClip_PCMSetPositionCallback_Event2.CallWithSelf);
		unityEngine_AudioClip_PCMSetPositionCallback_Event2.method = pCMSetPositionCallback2.Method;
		return pCMSetPositionCallback2;
	}

	public static Delegate UIPanel_OnGeometryUpdated(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIPanel.OnGeometryUpdated(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIPanel_OnGeometryUpdated_Event uIPanel_OnGeometryUpdated_Event = new DelegateFactory.UIPanel_OnGeometryUpdated_Event(func);
			UIPanel.OnGeometryUpdated onGeometryUpdated = new UIPanel.OnGeometryUpdated(uIPanel_OnGeometryUpdated_Event.Call);
			uIPanel_OnGeometryUpdated_Event.method = onGeometryUpdated.Method;
			return onGeometryUpdated;
		}
		DelegateFactory.UIPanel_OnGeometryUpdated_Event uIPanel_OnGeometryUpdated_Event2 = new DelegateFactory.UIPanel_OnGeometryUpdated_Event(func, self);
		UIPanel.OnGeometryUpdated onGeometryUpdated2 = new UIPanel.OnGeometryUpdated(uIPanel_OnGeometryUpdated_Event2.CallWithSelf);
		uIPanel_OnGeometryUpdated_Event2.method = onGeometryUpdated2.Method;
		return onGeometryUpdated2;
	}

	public static Delegate UIPanel_OnClippingMoved(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIPanel.OnClippingMoved(delegate(UIPanel param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIPanel_OnClippingMoved_Event uIPanel_OnClippingMoved_Event = new DelegateFactory.UIPanel_OnClippingMoved_Event(func);
			UIPanel.OnClippingMoved onClippingMoved = new UIPanel.OnClippingMoved(uIPanel_OnClippingMoved_Event.Call);
			uIPanel_OnClippingMoved_Event.method = onClippingMoved.Method;
			return onClippingMoved;
		}
		DelegateFactory.UIPanel_OnClippingMoved_Event uIPanel_OnClippingMoved_Event2 = new DelegateFactory.UIPanel_OnClippingMoved_Event(func, self);
		UIPanel.OnClippingMoved onClippingMoved2 = new UIPanel.OnClippingMoved(uIPanel_OnClippingMoved_Event2.CallWithSelf);
		uIPanel_OnClippingMoved_Event2.method = onClippingMoved2.Method;
		return onClippingMoved2;
	}

	public static Delegate UIWidget_OnDimensionsChanged(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIWidget.OnDimensionsChanged(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIWidget_OnDimensionsChanged_Event uIWidget_OnDimensionsChanged_Event = new DelegateFactory.UIWidget_OnDimensionsChanged_Event(func);
			UIWidget.OnDimensionsChanged onDimensionsChanged = new UIWidget.OnDimensionsChanged(uIWidget_OnDimensionsChanged_Event.Call);
			uIWidget_OnDimensionsChanged_Event.method = onDimensionsChanged.Method;
			return onDimensionsChanged;
		}
		DelegateFactory.UIWidget_OnDimensionsChanged_Event uIWidget_OnDimensionsChanged_Event2 = new DelegateFactory.UIWidget_OnDimensionsChanged_Event(func, self);
		UIWidget.OnDimensionsChanged onDimensionsChanged2 = new UIWidget.OnDimensionsChanged(uIWidget_OnDimensionsChanged_Event2.CallWithSelf);
		uIWidget_OnDimensionsChanged_Event2.method = onDimensionsChanged2.Method;
		return onDimensionsChanged2;
	}

	public static Delegate UIWidget_OnPostFillCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIWidget.OnPostFillCallback(delegate(UIWidget param0, int param1, BetterList<Vector3> param2, BetterList<Vector2> param3, BetterList<Color32> param4)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIWidget_OnPostFillCallback_Event uIWidget_OnPostFillCallback_Event = new DelegateFactory.UIWidget_OnPostFillCallback_Event(func);
			UIWidget.OnPostFillCallback onPostFillCallback = new UIWidget.OnPostFillCallback(uIWidget_OnPostFillCallback_Event.Call);
			uIWidget_OnPostFillCallback_Event.method = onPostFillCallback.Method;
			return onPostFillCallback;
		}
		DelegateFactory.UIWidget_OnPostFillCallback_Event uIWidget_OnPostFillCallback_Event2 = new DelegateFactory.UIWidget_OnPostFillCallback_Event(func, self);
		UIWidget.OnPostFillCallback onPostFillCallback2 = new UIWidget.OnPostFillCallback(uIWidget_OnPostFillCallback_Event2.CallWithSelf);
		uIWidget_OnPostFillCallback_Event2.method = onPostFillCallback2.Method;
		return onPostFillCallback2;
	}

	public static Delegate UIDrawCall_OnRenderCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIDrawCall.OnRenderCallback(delegate(Material param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIDrawCall_OnRenderCallback_Event uIDrawCall_OnRenderCallback_Event = new DelegateFactory.UIDrawCall_OnRenderCallback_Event(func);
			UIDrawCall.OnRenderCallback onRenderCallback = new UIDrawCall.OnRenderCallback(uIDrawCall_OnRenderCallback_Event.Call);
			uIDrawCall_OnRenderCallback_Event.method = onRenderCallback.Method;
			return onRenderCallback;
		}
		DelegateFactory.UIDrawCall_OnRenderCallback_Event uIDrawCall_OnRenderCallback_Event2 = new DelegateFactory.UIDrawCall_OnRenderCallback_Event(func, self);
		UIDrawCall.OnRenderCallback onRenderCallback2 = new UIDrawCall.OnRenderCallback(uIDrawCall_OnRenderCallback_Event2.CallWithSelf);
		uIDrawCall_OnRenderCallback_Event2.method = onRenderCallback2.Method;
		return onRenderCallback2;
	}

	public static Delegate UIWidget_HitCheck(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIWidget.HitCheck((Vector3 param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.UIWidget_HitCheck_Event uIWidget_HitCheck_Event = new DelegateFactory.UIWidget_HitCheck_Event(func);
			UIWidget.HitCheck hitCheck = new UIWidget.HitCheck(uIWidget_HitCheck_Event.Call);
			uIWidget_HitCheck_Event.method = hitCheck.Method;
			return hitCheck;
		}
		DelegateFactory.UIWidget_HitCheck_Event uIWidget_HitCheck_Event2 = new DelegateFactory.UIWidget_HitCheck_Event(func, self);
		UIWidget.HitCheck hitCheck2 = new UIWidget.HitCheck(uIWidget_HitCheck_Event2.CallWithSelf);
		uIWidget_HitCheck_Event2.method = hitCheck2.Method;
		return hitCheck2;
	}

	public static Delegate UIGrid_OnReposition(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIGrid.OnReposition(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIGrid_OnReposition_Event uIGrid_OnReposition_Event = new DelegateFactory.UIGrid_OnReposition_Event(func);
			UIGrid.OnReposition onReposition = new UIGrid.OnReposition(uIGrid_OnReposition_Event.Call);
			uIGrid_OnReposition_Event.method = onReposition.Method;
			return onReposition;
		}
		DelegateFactory.UIGrid_OnReposition_Event uIGrid_OnReposition_Event2 = new DelegateFactory.UIGrid_OnReposition_Event(func, self);
		UIGrid.OnReposition onReposition2 = new UIGrid.OnReposition(uIGrid_OnReposition_Event2.CallWithSelf);
		uIGrid_OnReposition_Event2.method = onReposition2.Method;
		return onReposition2;
	}

	public static Delegate System_Comparison_UnityEngine_Transform(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Comparison<Transform>((Transform param0, Transform param1) => 0);
		}
		if (!flag)
		{
			DelegateFactory.System_Comparison_UnityEngine_Transform_Event system_Comparison_UnityEngine_Transform_Event = new DelegateFactory.System_Comparison_UnityEngine_Transform_Event(func);
			Comparison<Transform> comparison = new Comparison<Transform>(system_Comparison_UnityEngine_Transform_Event.Call);
			system_Comparison_UnityEngine_Transform_Event.method = comparison.Method;
			return comparison;
		}
		DelegateFactory.System_Comparison_UnityEngine_Transform_Event system_Comparison_UnityEngine_Transform_Event2 = new DelegateFactory.System_Comparison_UnityEngine_Transform_Event(func, self);
		Comparison<Transform> comparison2 = new Comparison<Transform>(system_Comparison_UnityEngine_Transform_Event2.CallWithSelf);
		system_Comparison_UnityEngine_Transform_Event2.method = comparison2.Method;
		return comparison2;
	}

	public static Delegate System_Action_UnityEngine_GameObject_string(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<GameObject, string>(delegate(GameObject param0, string param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_UnityEngine_GameObject_string_Event system_Action_UnityEngine_GameObject_string_Event = new DelegateFactory.System_Action_UnityEngine_GameObject_string_Event(func);
			Action<GameObject, string> action = new Action<GameObject, string>(system_Action_UnityEngine_GameObject_string_Event.Call);
			system_Action_UnityEngine_GameObject_string_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_UnityEngine_GameObject_string_Event system_Action_UnityEngine_GameObject_string_Event2 = new DelegateFactory.System_Action_UnityEngine_GameObject_string_Event(func, self);
		Action<GameObject, string> action2 = new Action<GameObject, string>(system_Action_UnityEngine_GameObject_string_Event2.CallWithSelf);
		system_Action_UnityEngine_GameObject_string_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Action_UnityEngine_AudioClip_string(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<AudioClip, string>(delegate(AudioClip param0, string param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_UnityEngine_AudioClip_string_Event system_Action_UnityEngine_AudioClip_string_Event = new DelegateFactory.System_Action_UnityEngine_AudioClip_string_Event(func);
			Action<AudioClip, string> action = new Action<AudioClip, string>(system_Action_UnityEngine_AudioClip_string_Event.Call);
			system_Action_UnityEngine_AudioClip_string_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_UnityEngine_AudioClip_string_Event system_Action_UnityEngine_AudioClip_string_Event2 = new DelegateFactory.System_Action_UnityEngine_AudioClip_string_Event(func, self);
		Action<AudioClip, string> action2 = new Action<AudioClip, string>(system_Action_UnityEngine_AudioClip_string_Event2.CallWithSelf);
		system_Action_UnityEngine_AudioClip_string_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate LuaFramework_LuaBehaviour_UiExtendEventDeal(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new LuaBehaviour.UiExtendEventDeal(delegate(GameObject param0, string param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.LuaFramework_LuaBehaviour_UiExtendEventDeal_Event luaFramework_LuaBehaviour_UiExtendEventDeal_Event = new DelegateFactory.LuaFramework_LuaBehaviour_UiExtendEventDeal_Event(func);
			LuaBehaviour.UiExtendEventDeal uiExtendEventDeal = new LuaBehaviour.UiExtendEventDeal(luaFramework_LuaBehaviour_UiExtendEventDeal_Event.Call);
			luaFramework_LuaBehaviour_UiExtendEventDeal_Event.method = uiExtendEventDeal.Method;
			return uiExtendEventDeal;
		}
		DelegateFactory.LuaFramework_LuaBehaviour_UiExtendEventDeal_Event luaFramework_LuaBehaviour_UiExtendEventDeal_Event2 = new DelegateFactory.LuaFramework_LuaBehaviour_UiExtendEventDeal_Event(func, self);
		LuaBehaviour.UiExtendEventDeal uiExtendEventDeal2 = new LuaBehaviour.UiExtendEventDeal(luaFramework_LuaBehaviour_UiExtendEventDeal_Event2.CallWithSelf);
		luaFramework_LuaBehaviour_UiExtendEventDeal_Event2.method = uiExtendEventDeal2.Method;
		return uiExtendEventDeal2;
	}

	public static Delegate UITable_OnReposition(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UITable.OnReposition(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UITable_OnReposition_Event uITable_OnReposition_Event = new DelegateFactory.UITable_OnReposition_Event(func);
			UITable.OnReposition onReposition = new UITable.OnReposition(uITable_OnReposition_Event.Call);
			uITable_OnReposition_Event.method = onReposition.Method;
			return onReposition;
		}
		DelegateFactory.UITable_OnReposition_Event uITable_OnReposition_Event2 = new DelegateFactory.UITable_OnReposition_Event(func, self);
		UITable.OnReposition onReposition2 = new UITable.OnReposition(uITable_OnReposition_Event2.CallWithSelf);
		uITable_OnReposition_Event2.method = onReposition2.Method;
		return onReposition2;
	}

	public static Delegate LuaFramework_GameManager_DownloadPackProgressChanged(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new GameManager.DownloadPackProgressChanged(delegate(float param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.LuaFramework_GameManager_DownloadPackProgressChanged_Event luaFramework_GameManager_DownloadPackProgressChanged_Event = new DelegateFactory.LuaFramework_GameManager_DownloadPackProgressChanged_Event(func);
			GameManager.DownloadPackProgressChanged downloadPackProgressChanged = new GameManager.DownloadPackProgressChanged(luaFramework_GameManager_DownloadPackProgressChanged_Event.Call);
			luaFramework_GameManager_DownloadPackProgressChanged_Event.method = downloadPackProgressChanged.Method;
			return downloadPackProgressChanged;
		}
		DelegateFactory.LuaFramework_GameManager_DownloadPackProgressChanged_Event luaFramework_GameManager_DownloadPackProgressChanged_Event2 = new DelegateFactory.LuaFramework_GameManager_DownloadPackProgressChanged_Event(func, self);
		GameManager.DownloadPackProgressChanged downloadPackProgressChanged2 = new GameManager.DownloadPackProgressChanged(luaFramework_GameManager_DownloadPackProgressChanged_Event2.CallWithSelf);
		luaFramework_GameManager_DownloadPackProgressChanged_Event2.method = downloadPackProgressChanged2.Method;
		return downloadPackProgressChanged2;
	}

	public static Delegate LuaFramework_TimerManager_UpdateFunc(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new TimerManager.UpdateFunc(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.LuaFramework_TimerManager_UpdateFunc_Event luaFramework_TimerManager_UpdateFunc_Event = new DelegateFactory.LuaFramework_TimerManager_UpdateFunc_Event(func);
			TimerManager.UpdateFunc updateFunc = new TimerManager.UpdateFunc(luaFramework_TimerManager_UpdateFunc_Event.Call);
			luaFramework_TimerManager_UpdateFunc_Event.method = updateFunc.Method;
			return updateFunc;
		}
		DelegateFactory.LuaFramework_TimerManager_UpdateFunc_Event luaFramework_TimerManager_UpdateFunc_Event2 = new DelegateFactory.LuaFramework_TimerManager_UpdateFunc_Event(func, self);
		TimerManager.UpdateFunc updateFunc2 = new TimerManager.UpdateFunc(luaFramework_TimerManager_UpdateFunc_Event2.CallWithSelf);
		luaFramework_TimerManager_UpdateFunc_Event2.method = updateFunc2.Method;
		return updateFunc2;
	}

	public static Delegate System_Action_NotiData(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<NotiData>(delegate(NotiData param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_NotiData_Event system_Action_NotiData_Event = new DelegateFactory.System_Action_NotiData_Event(func);
			Action<NotiData> action = new Action<NotiData>(system_Action_NotiData_Event.Call);
			system_Action_NotiData_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_NotiData_Event system_Action_NotiData_Event2 = new DelegateFactory.System_Action_NotiData_Event(func, self);
		Action<NotiData> action2 = new Action<NotiData>(system_Action_NotiData_Event2.CallWithSelf);
		system_Action_NotiData_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate UIInput_OnValidate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIInput.OnValidate((string param0, int param1, char param2) => '\0');
		}
		if (!flag)
		{
			DelegateFactory.UIInput_OnValidate_Event uIInput_OnValidate_Event = new DelegateFactory.UIInput_OnValidate_Event(func);
			UIInput.OnValidate onValidate = new UIInput.OnValidate(uIInput_OnValidate_Event.Call);
			uIInput_OnValidate_Event.method = onValidate.Method;
			return onValidate;
		}
		DelegateFactory.UIInput_OnValidate_Event uIInput_OnValidate_Event2 = new DelegateFactory.UIInput_OnValidate_Event(func, self);
		UIInput.OnValidate onValidate2 = new UIInput.OnValidate(uIInput_OnValidate_Event2.CallWithSelf);
		uIInput_OnValidate_Event2.method = onValidate2.Method;
		return onValidate2;
	}

	public static Delegate UIPopupList_LegacyEvent(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIPopupList.LegacyEvent(delegate(string param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIPopupList_LegacyEvent_Event uIPopupList_LegacyEvent_Event = new DelegateFactory.UIPopupList_LegacyEvent_Event(func);
			UIPopupList.LegacyEvent legacyEvent = new UIPopupList.LegacyEvent(uIPopupList_LegacyEvent_Event.Call);
			uIPopupList_LegacyEvent_Event.method = legacyEvent.Method;
			return legacyEvent;
		}
		DelegateFactory.UIPopupList_LegacyEvent_Event uIPopupList_LegacyEvent_Event2 = new DelegateFactory.UIPopupList_LegacyEvent_Event(func, self);
		UIPopupList.LegacyEvent legacyEvent2 = new UIPopupList.LegacyEvent(uIPopupList_LegacyEvent_Event2.CallWithSelf);
		uIPopupList_LegacyEvent_Event2.method = legacyEvent2.Method;
		return legacyEvent2;
	}

	public static Delegate UIProgressBar_OnDragFinished(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIProgressBar.OnDragFinished(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIProgressBar_OnDragFinished_Event uIProgressBar_OnDragFinished_Event = new DelegateFactory.UIProgressBar_OnDragFinished_Event(func);
			UIProgressBar.OnDragFinished onDragFinished = new UIProgressBar.OnDragFinished(uIProgressBar_OnDragFinished_Event.Call);
			uIProgressBar_OnDragFinished_Event.method = onDragFinished.Method;
			return onDragFinished;
		}
		DelegateFactory.UIProgressBar_OnDragFinished_Event uIProgressBar_OnDragFinished_Event2 = new DelegateFactory.UIProgressBar_OnDragFinished_Event(func, self);
		UIProgressBar.OnDragFinished onDragFinished2 = new UIProgressBar.OnDragFinished(uIProgressBar_OnDragFinished_Event2.CallWithSelf);
		uIProgressBar_OnDragFinished_Event2.method = onDragFinished2.Method;
		return onDragFinished2;
	}

	public static Delegate UIToggle_Validate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIToggle.Validate((bool param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.UIToggle_Validate_Event uIToggle_Validate_Event = new DelegateFactory.UIToggle_Validate_Event(func);
			UIToggle.Validate validate = new UIToggle.Validate(uIToggle_Validate_Event.Call);
			uIToggle_Validate_Event.method = validate.Method;
			return validate;
		}
		DelegateFactory.UIToggle_Validate_Event uIToggle_Validate_Event2 = new DelegateFactory.UIToggle_Validate_Event(func, self);
		UIToggle.Validate validate2 = new UIToggle.Validate(uIToggle_Validate_Event2.CallWithSelf);
		uIToggle_Validate_Event2.method = validate2.Method;
		return validate2;
	}

	public static Delegate UIWrapContent_OnInitializeItem(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIWrapContent.OnInitializeItem(delegate(GameObject param0, int param1, int param2)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIWrapContent_OnInitializeItem_Event uIWrapContent_OnInitializeItem_Event = new DelegateFactory.UIWrapContent_OnInitializeItem_Event(func);
			UIWrapContent.OnInitializeItem onInitializeItem = new UIWrapContent.OnInitializeItem(uIWrapContent_OnInitializeItem_Event.Call);
			uIWrapContent_OnInitializeItem_Event.method = onInitializeItem.Method;
			return onInitializeItem;
		}
		DelegateFactory.UIWrapContent_OnInitializeItem_Event uIWrapContent_OnInitializeItem_Event2 = new DelegateFactory.UIWrapContent_OnInitializeItem_Event(func, self);
		UIWrapContent.OnInitializeItem onInitializeItem2 = new UIWrapContent.OnInitializeItem(uIWrapContent_OnInitializeItem_Event2.CallWithSelf);
		uIWrapContent_OnInitializeItem_Event2.method = onInitializeItem2.Method;
		return onInitializeItem2;
	}

	public static Delegate UICamera_GetKeyStateFunc(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.GetKeyStateFunc((KeyCode param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.UICamera_GetKeyStateFunc_Event uICamera_GetKeyStateFunc_Event = new DelegateFactory.UICamera_GetKeyStateFunc_Event(func);
			UICamera.GetKeyStateFunc getKeyStateFunc = new UICamera.GetKeyStateFunc(uICamera_GetKeyStateFunc_Event.Call);
			uICamera_GetKeyStateFunc_Event.method = getKeyStateFunc.Method;
			return getKeyStateFunc;
		}
		DelegateFactory.UICamera_GetKeyStateFunc_Event uICamera_GetKeyStateFunc_Event2 = new DelegateFactory.UICamera_GetKeyStateFunc_Event(func, self);
		UICamera.GetKeyStateFunc getKeyStateFunc2 = new UICamera.GetKeyStateFunc(uICamera_GetKeyStateFunc_Event2.CallWithSelf);
		uICamera_GetKeyStateFunc_Event2.method = getKeyStateFunc2.Method;
		return getKeyStateFunc2;
	}

	public static Delegate UICamera_GetAxisFunc(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.GetAxisFunc((string param0) => 0f);
		}
		if (!flag)
		{
			DelegateFactory.UICamera_GetAxisFunc_Event uICamera_GetAxisFunc_Event = new DelegateFactory.UICamera_GetAxisFunc_Event(func);
			UICamera.GetAxisFunc getAxisFunc = new UICamera.GetAxisFunc(uICamera_GetAxisFunc_Event.Call);
			uICamera_GetAxisFunc_Event.method = getAxisFunc.Method;
			return getAxisFunc;
		}
		DelegateFactory.UICamera_GetAxisFunc_Event uICamera_GetAxisFunc_Event2 = new DelegateFactory.UICamera_GetAxisFunc_Event(func, self);
		UICamera.GetAxisFunc getAxisFunc2 = new UICamera.GetAxisFunc(uICamera_GetAxisFunc_Event2.CallWithSelf);
		uICamera_GetAxisFunc_Event2.method = getAxisFunc2.Method;
		return getAxisFunc2;
	}

	public static Delegate UICamera_OnScreenResize(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.OnScreenResize(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_OnScreenResize_Event uICamera_OnScreenResize_Event = new DelegateFactory.UICamera_OnScreenResize_Event(func);
			UICamera.OnScreenResize onScreenResize = new UICamera.OnScreenResize(uICamera_OnScreenResize_Event.Call);
			uICamera_OnScreenResize_Event.method = onScreenResize.Method;
			return onScreenResize;
		}
		DelegateFactory.UICamera_OnScreenResize_Event uICamera_OnScreenResize_Event2 = new DelegateFactory.UICamera_OnScreenResize_Event(func, self);
		UICamera.OnScreenResize onScreenResize2 = new UICamera.OnScreenResize(uICamera_OnScreenResize_Event2.CallWithSelf);
		uICamera_OnScreenResize_Event2.method = onScreenResize2.Method;
		return onScreenResize2;
	}

	public static Delegate UICamera_OnCustomInput(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.OnCustomInput(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_OnCustomInput_Event uICamera_OnCustomInput_Event = new DelegateFactory.UICamera_OnCustomInput_Event(func);
			UICamera.OnCustomInput onCustomInput = new UICamera.OnCustomInput(uICamera_OnCustomInput_Event.Call);
			uICamera_OnCustomInput_Event.method = onCustomInput.Method;
			return onCustomInput;
		}
		DelegateFactory.UICamera_OnCustomInput_Event uICamera_OnCustomInput_Event2 = new DelegateFactory.UICamera_OnCustomInput_Event(func, self);
		UICamera.OnCustomInput onCustomInput2 = new UICamera.OnCustomInput(uICamera_OnCustomInput_Event2.CallWithSelf);
		uICamera_OnCustomInput_Event2.method = onCustomInput2.Method;
		return onCustomInput2;
	}

	public static Delegate UICamera_VoidDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.VoidDelegate(delegate(GameObject param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_VoidDelegate_Event uICamera_VoidDelegate_Event = new DelegateFactory.UICamera_VoidDelegate_Event(func);
			UICamera.VoidDelegate voidDelegate = new UICamera.VoidDelegate(uICamera_VoidDelegate_Event.Call);
			uICamera_VoidDelegate_Event.method = voidDelegate.Method;
			return voidDelegate;
		}
		DelegateFactory.UICamera_VoidDelegate_Event uICamera_VoidDelegate_Event2 = new DelegateFactory.UICamera_VoidDelegate_Event(func, self);
		UICamera.VoidDelegate voidDelegate2 = new UICamera.VoidDelegate(uICamera_VoidDelegate_Event2.CallWithSelf);
		uICamera_VoidDelegate_Event2.method = voidDelegate2.Method;
		return voidDelegate2;
	}

	public static Delegate UICamera_BoolDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.BoolDelegate(delegate(GameObject param0, bool param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_BoolDelegate_Event uICamera_BoolDelegate_Event = new DelegateFactory.UICamera_BoolDelegate_Event(func);
			UICamera.BoolDelegate boolDelegate = new UICamera.BoolDelegate(uICamera_BoolDelegate_Event.Call);
			uICamera_BoolDelegate_Event.method = boolDelegate.Method;
			return boolDelegate;
		}
		DelegateFactory.UICamera_BoolDelegate_Event uICamera_BoolDelegate_Event2 = new DelegateFactory.UICamera_BoolDelegate_Event(func, self);
		UICamera.BoolDelegate boolDelegate2 = new UICamera.BoolDelegate(uICamera_BoolDelegate_Event2.CallWithSelf);
		uICamera_BoolDelegate_Event2.method = boolDelegate2.Method;
		return boolDelegate2;
	}

	public static Delegate UICamera_FloatDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.FloatDelegate(delegate(GameObject param0, float param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_FloatDelegate_Event uICamera_FloatDelegate_Event = new DelegateFactory.UICamera_FloatDelegate_Event(func);
			UICamera.FloatDelegate floatDelegate = new UICamera.FloatDelegate(uICamera_FloatDelegate_Event.Call);
			uICamera_FloatDelegate_Event.method = floatDelegate.Method;
			return floatDelegate;
		}
		DelegateFactory.UICamera_FloatDelegate_Event uICamera_FloatDelegate_Event2 = new DelegateFactory.UICamera_FloatDelegate_Event(func, self);
		UICamera.FloatDelegate floatDelegate2 = new UICamera.FloatDelegate(uICamera_FloatDelegate_Event2.CallWithSelf);
		uICamera_FloatDelegate_Event2.method = floatDelegate2.Method;
		return floatDelegate2;
	}

	public static Delegate UICamera_VectorDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.VectorDelegate(delegate(GameObject param0, Vector2 param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_VectorDelegate_Event uICamera_VectorDelegate_Event = new DelegateFactory.UICamera_VectorDelegate_Event(func);
			UICamera.VectorDelegate vectorDelegate = new UICamera.VectorDelegate(uICamera_VectorDelegate_Event.Call);
			uICamera_VectorDelegate_Event.method = vectorDelegate.Method;
			return vectorDelegate;
		}
		DelegateFactory.UICamera_VectorDelegate_Event uICamera_VectorDelegate_Event2 = new DelegateFactory.UICamera_VectorDelegate_Event(func, self);
		UICamera.VectorDelegate vectorDelegate2 = new UICamera.VectorDelegate(uICamera_VectorDelegate_Event2.CallWithSelf);
		uICamera_VectorDelegate_Event2.method = vectorDelegate2.Method;
		return vectorDelegate2;
	}

	public static Delegate UICamera_ObjectDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.ObjectDelegate(delegate(GameObject param0, GameObject param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_ObjectDelegate_Event uICamera_ObjectDelegate_Event = new DelegateFactory.UICamera_ObjectDelegate_Event(func);
			UICamera.ObjectDelegate objectDelegate = new UICamera.ObjectDelegate(uICamera_ObjectDelegate_Event.Call);
			uICamera_ObjectDelegate_Event.method = objectDelegate.Method;
			return objectDelegate;
		}
		DelegateFactory.UICamera_ObjectDelegate_Event uICamera_ObjectDelegate_Event2 = new DelegateFactory.UICamera_ObjectDelegate_Event(func, self);
		UICamera.ObjectDelegate objectDelegate2 = new UICamera.ObjectDelegate(uICamera_ObjectDelegate_Event2.CallWithSelf);
		uICamera_ObjectDelegate_Event2.method = objectDelegate2.Method;
		return objectDelegate2;
	}

	public static Delegate UICamera_KeyCodeDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.KeyCodeDelegate(delegate(GameObject param0, KeyCode param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_KeyCodeDelegate_Event uICamera_KeyCodeDelegate_Event = new DelegateFactory.UICamera_KeyCodeDelegate_Event(func);
			UICamera.KeyCodeDelegate keyCodeDelegate = new UICamera.KeyCodeDelegate(uICamera_KeyCodeDelegate_Event.Call);
			uICamera_KeyCodeDelegate_Event.method = keyCodeDelegate.Method;
			return keyCodeDelegate;
		}
		DelegateFactory.UICamera_KeyCodeDelegate_Event uICamera_KeyCodeDelegate_Event2 = new DelegateFactory.UICamera_KeyCodeDelegate_Event(func, self);
		UICamera.KeyCodeDelegate keyCodeDelegate2 = new UICamera.KeyCodeDelegate(uICamera_KeyCodeDelegate_Event2.CallWithSelf);
		uICamera_KeyCodeDelegate_Event2.method = keyCodeDelegate2.Method;
		return keyCodeDelegate2;
	}

	public static Delegate UICamera_MoveDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.MoveDelegate(delegate(Vector2 param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UICamera_MoveDelegate_Event uICamera_MoveDelegate_Event = new DelegateFactory.UICamera_MoveDelegate_Event(func);
			UICamera.MoveDelegate moveDelegate = new UICamera.MoveDelegate(uICamera_MoveDelegate_Event.Call);
			uICamera_MoveDelegate_Event.method = moveDelegate.Method;
			return moveDelegate;
		}
		DelegateFactory.UICamera_MoveDelegate_Event uICamera_MoveDelegate_Event2 = new DelegateFactory.UICamera_MoveDelegate_Event(func, self);
		UICamera.MoveDelegate moveDelegate2 = new UICamera.MoveDelegate(uICamera_MoveDelegate_Event2.CallWithSelf);
		uICamera_MoveDelegate_Event2.method = moveDelegate2.Method;
		return moveDelegate2;
	}

	public static Delegate UICamera_GetTouchCountCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.GetTouchCountCallback(() => 0);
		}
		if (!flag)
		{
			DelegateFactory.UICamera_GetTouchCountCallback_Event uICamera_GetTouchCountCallback_Event = new DelegateFactory.UICamera_GetTouchCountCallback_Event(func);
			UICamera.GetTouchCountCallback getTouchCountCallback = new UICamera.GetTouchCountCallback(uICamera_GetTouchCountCallback_Event.Call);
			uICamera_GetTouchCountCallback_Event.method = getTouchCountCallback.Method;
			return getTouchCountCallback;
		}
		DelegateFactory.UICamera_GetTouchCountCallback_Event uICamera_GetTouchCountCallback_Event2 = new DelegateFactory.UICamera_GetTouchCountCallback_Event(func, self);
		UICamera.GetTouchCountCallback getTouchCountCallback2 = new UICamera.GetTouchCountCallback(uICamera_GetTouchCountCallback_Event2.CallWithSelf);
		uICamera_GetTouchCountCallback_Event2.method = getTouchCountCallback2.Method;
		return getTouchCountCallback2;
	}

	public static Delegate UICamera_GetTouchCallback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UICamera.GetTouchCallback((int param0) => null);
		}
		if (!flag)
		{
			DelegateFactory.UICamera_GetTouchCallback_Event uICamera_GetTouchCallback_Event = new DelegateFactory.UICamera_GetTouchCallback_Event(func);
			UICamera.GetTouchCallback getTouchCallback = new UICamera.GetTouchCallback(uICamera_GetTouchCallback_Event.Call);
			uICamera_GetTouchCallback_Event.method = getTouchCallback.Method;
			return getTouchCallback;
		}
		DelegateFactory.UICamera_GetTouchCallback_Event uICamera_GetTouchCallback_Event2 = new DelegateFactory.UICamera_GetTouchCallback_Event(func, self);
		UICamera.GetTouchCallback getTouchCallback2 = new UICamera.GetTouchCallback(uICamera_GetTouchCallback_Event2.CallWithSelf);
		uICamera_GetTouchCallback_Event2.method = getTouchCallback2.Method;
		return getTouchCallback2;
	}

	public static Delegate EventDelegate_Callback(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new EventDelegate.Callback(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.EventDelegate_Callback_Event eventDelegate_Callback_Event = new DelegateFactory.EventDelegate_Callback_Event(func);
			EventDelegate.Callback callback = new EventDelegate.Callback(eventDelegate_Callback_Event.Call);
			eventDelegate_Callback_Event.method = callback.Method;
			return callback;
		}
		DelegateFactory.EventDelegate_Callback_Event eventDelegate_Callback_Event2 = new DelegateFactory.EventDelegate_Callback_Event(func, self);
		EventDelegate.Callback callback2 = new EventDelegate.Callback(eventDelegate_Callback_Event2.CallWithSelf);
		eventDelegate_Callback_Event2.method = callback2.Method;
		return callback2;
	}

	public static Delegate UIEventListener_VoidDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIEventListener.VoidDelegate(delegate(GameObject param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIEventListener_VoidDelegate_Event uIEventListener_VoidDelegate_Event = new DelegateFactory.UIEventListener_VoidDelegate_Event(func);
			UIEventListener.VoidDelegate voidDelegate = new UIEventListener.VoidDelegate(uIEventListener_VoidDelegate_Event.Call);
			uIEventListener_VoidDelegate_Event.method = voidDelegate.Method;
			return voidDelegate;
		}
		DelegateFactory.UIEventListener_VoidDelegate_Event uIEventListener_VoidDelegate_Event2 = new DelegateFactory.UIEventListener_VoidDelegate_Event(func, self);
		UIEventListener.VoidDelegate voidDelegate2 = new UIEventListener.VoidDelegate(uIEventListener_VoidDelegate_Event2.CallWithSelf);
		uIEventListener_VoidDelegate_Event2.method = voidDelegate2.Method;
		return voidDelegate2;
	}

	public static Delegate UIEventListener_BoolDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIEventListener.BoolDelegate(delegate(GameObject param0, bool param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIEventListener_BoolDelegate_Event uIEventListener_BoolDelegate_Event = new DelegateFactory.UIEventListener_BoolDelegate_Event(func);
			UIEventListener.BoolDelegate boolDelegate = new UIEventListener.BoolDelegate(uIEventListener_BoolDelegate_Event.Call);
			uIEventListener_BoolDelegate_Event.method = boolDelegate.Method;
			return boolDelegate;
		}
		DelegateFactory.UIEventListener_BoolDelegate_Event uIEventListener_BoolDelegate_Event2 = new DelegateFactory.UIEventListener_BoolDelegate_Event(func, self);
		UIEventListener.BoolDelegate boolDelegate2 = new UIEventListener.BoolDelegate(uIEventListener_BoolDelegate_Event2.CallWithSelf);
		uIEventListener_BoolDelegate_Event2.method = boolDelegate2.Method;
		return boolDelegate2;
	}

	public static Delegate UIEventListener_FloatDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIEventListener.FloatDelegate(delegate(GameObject param0, float param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIEventListener_FloatDelegate_Event uIEventListener_FloatDelegate_Event = new DelegateFactory.UIEventListener_FloatDelegate_Event(func);
			UIEventListener.FloatDelegate floatDelegate = new UIEventListener.FloatDelegate(uIEventListener_FloatDelegate_Event.Call);
			uIEventListener_FloatDelegate_Event.method = floatDelegate.Method;
			return floatDelegate;
		}
		DelegateFactory.UIEventListener_FloatDelegate_Event uIEventListener_FloatDelegate_Event2 = new DelegateFactory.UIEventListener_FloatDelegate_Event(func, self);
		UIEventListener.FloatDelegate floatDelegate2 = new UIEventListener.FloatDelegate(uIEventListener_FloatDelegate_Event2.CallWithSelf);
		uIEventListener_FloatDelegate_Event2.method = floatDelegate2.Method;
		return floatDelegate2;
	}

	public static Delegate UIEventListener_VectorDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIEventListener.VectorDelegate(delegate(GameObject param0, Vector2 param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIEventListener_VectorDelegate_Event uIEventListener_VectorDelegate_Event = new DelegateFactory.UIEventListener_VectorDelegate_Event(func);
			UIEventListener.VectorDelegate vectorDelegate = new UIEventListener.VectorDelegate(uIEventListener_VectorDelegate_Event.Call);
			uIEventListener_VectorDelegate_Event.method = vectorDelegate.Method;
			return vectorDelegate;
		}
		DelegateFactory.UIEventListener_VectorDelegate_Event uIEventListener_VectorDelegate_Event2 = new DelegateFactory.UIEventListener_VectorDelegate_Event(func, self);
		UIEventListener.VectorDelegate vectorDelegate2 = new UIEventListener.VectorDelegate(uIEventListener_VectorDelegate_Event2.CallWithSelf);
		uIEventListener_VectorDelegate_Event2.method = vectorDelegate2.Method;
		return vectorDelegate2;
	}

	public static Delegate UIEventListener_ObjectDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIEventListener.ObjectDelegate(delegate(GameObject param0, GameObject param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIEventListener_ObjectDelegate_Event uIEventListener_ObjectDelegate_Event = new DelegateFactory.UIEventListener_ObjectDelegate_Event(func);
			UIEventListener.ObjectDelegate objectDelegate = new UIEventListener.ObjectDelegate(uIEventListener_ObjectDelegate_Event.Call);
			uIEventListener_ObjectDelegate_Event.method = objectDelegate.Method;
			return objectDelegate;
		}
		DelegateFactory.UIEventListener_ObjectDelegate_Event uIEventListener_ObjectDelegate_Event2 = new DelegateFactory.UIEventListener_ObjectDelegate_Event(func, self);
		UIEventListener.ObjectDelegate objectDelegate2 = new UIEventListener.ObjectDelegate(uIEventListener_ObjectDelegate_Event2.CallWithSelf);
		uIEventListener_ObjectDelegate_Event2.method = objectDelegate2.Method;
		return objectDelegate2;
	}

	public static Delegate UIEventListener_KeyCodeDelegate(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIEventListener.KeyCodeDelegate(delegate(GameObject param0, KeyCode param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIEventListener_KeyCodeDelegate_Event uIEventListener_KeyCodeDelegate_Event = new DelegateFactory.UIEventListener_KeyCodeDelegate_Event(func);
			UIEventListener.KeyCodeDelegate keyCodeDelegate = new UIEventListener.KeyCodeDelegate(uIEventListener_KeyCodeDelegate_Event.Call);
			uIEventListener_KeyCodeDelegate_Event.method = keyCodeDelegate.Method;
			return keyCodeDelegate;
		}
		DelegateFactory.UIEventListener_KeyCodeDelegate_Event uIEventListener_KeyCodeDelegate_Event2 = new DelegateFactory.UIEventListener_KeyCodeDelegate_Event(func, self);
		UIEventListener.KeyCodeDelegate keyCodeDelegate2 = new UIEventListener.KeyCodeDelegate(uIEventListener_KeyCodeDelegate_Event2.CallWithSelf);
		uIEventListener_KeyCodeDelegate_Event2.method = keyCodeDelegate2.Method;
		return keyCodeDelegate2;
	}

	public static Delegate UIScrollView_OnDragNotification(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new UIScrollView.OnDragNotification(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.UIScrollView_OnDragNotification_Event uIScrollView_OnDragNotification_Event = new DelegateFactory.UIScrollView_OnDragNotification_Event(func);
			UIScrollView.OnDragNotification onDragNotification = new UIScrollView.OnDragNotification(uIScrollView_OnDragNotification_Event.Call);
			uIScrollView_OnDragNotification_Event.method = onDragNotification.Method;
			return onDragNotification;
		}
		DelegateFactory.UIScrollView_OnDragNotification_Event uIScrollView_OnDragNotification_Event2 = new DelegateFactory.UIScrollView_OnDragNotification_Event(func, self);
		UIScrollView.OnDragNotification onDragNotification2 = new UIScrollView.OnDragNotification(uIScrollView_OnDragNotification_Event2.CallWithSelf);
		uIScrollView_OnDragNotification_Event2.method = onDragNotification2.Method;
		return onDragNotification2;
	}

	public static Delegate SpringPanel_OnFinished(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new SpringPanel.OnFinished(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.SpringPanel_OnFinished_Event springPanel_OnFinished_Event = new DelegateFactory.SpringPanel_OnFinished_Event(func);
			SpringPanel.OnFinished onFinished = new SpringPanel.OnFinished(springPanel_OnFinished_Event.Call);
			springPanel_OnFinished_Event.method = onFinished.Method;
			return onFinished;
		}
		DelegateFactory.SpringPanel_OnFinished_Event springPanel_OnFinished_Event2 = new DelegateFactory.SpringPanel_OnFinished_Event(func, self);
		SpringPanel.OnFinished onFinished2 = new SpringPanel.OnFinished(springPanel_OnFinished_Event2.CallWithSelf);
		springPanel_OnFinished_Event2.method = onFinished2.Method;
		return onFinished2;
	}

	public static Delegate System_Predicate_ServerInfo(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Predicate<ServerInfo>((ServerInfo param0) => false);
		}
		if (!flag)
		{
			DelegateFactory.System_Predicate_ServerInfo_Event system_Predicate_ServerInfo_Event = new DelegateFactory.System_Predicate_ServerInfo_Event(func);
			Predicate<ServerInfo> predicate = new Predicate<ServerInfo>(system_Predicate_ServerInfo_Event.Call);
			system_Predicate_ServerInfo_Event.method = predicate.Method;
			return predicate;
		}
		DelegateFactory.System_Predicate_ServerInfo_Event system_Predicate_ServerInfo_Event2 = new DelegateFactory.System_Predicate_ServerInfo_Event(func, self);
		Predicate<ServerInfo> predicate2 = new Predicate<ServerInfo>(system_Predicate_ServerInfo_Event2.CallWithSelf);
		system_Predicate_ServerInfo_Event2.method = predicate2.Method;
		return predicate2;
	}

	public static Delegate System_Action_ServerInfo(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<ServerInfo>(delegate(ServerInfo param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_ServerInfo_Event system_Action_ServerInfo_Event = new DelegateFactory.System_Action_ServerInfo_Event(func);
			Action<ServerInfo> action = new Action<ServerInfo>(system_Action_ServerInfo_Event.Call);
			system_Action_ServerInfo_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_ServerInfo_Event system_Action_ServerInfo_Event2 = new DelegateFactory.System_Action_ServerInfo_Event(func, self);
		Action<ServerInfo> action2 = new Action<ServerInfo>(system_Action_ServerInfo_Event2.CallWithSelf);
		system_Action_ServerInfo_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Comparison_ServerInfo(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Comparison<ServerInfo>((ServerInfo param0, ServerInfo param1) => 0);
		}
		if (!flag)
		{
			DelegateFactory.System_Comparison_ServerInfo_Event system_Comparison_ServerInfo_Event = new DelegateFactory.System_Comparison_ServerInfo_Event(func);
			Comparison<ServerInfo> comparison = new Comparison<ServerInfo>(system_Comparison_ServerInfo_Event.Call);
			system_Comparison_ServerInfo_Event.method = comparison.Method;
			return comparison;
		}
		DelegateFactory.System_Comparison_ServerInfo_Event system_Comparison_ServerInfo_Event2 = new DelegateFactory.System_Comparison_ServerInfo_Event(func, self);
		Comparison<ServerInfo> comparison2 = new Comparison<ServerInfo>(system_Comparison_ServerInfo_Event2.CallWithSelf);
		system_Comparison_ServerInfo_Event2.method = comparison2.Method;
		return comparison2;
	}

	public static Delegate Move_PathFinished(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Move.PathFinished(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.Move_PathFinished_Event move_PathFinished_Event = new DelegateFactory.Move_PathFinished_Event(func);
			Move.PathFinished pathFinished = new Move.PathFinished(move_PathFinished_Event.Call);
			move_PathFinished_Event.method = pathFinished.Method;
			return pathFinished;
		}
		DelegateFactory.Move_PathFinished_Event move_PathFinished_Event2 = new DelegateFactory.Move_PathFinished_Event(func, self);
		Move.PathFinished pathFinished2 = new Move.PathFinished(move_PathFinished_Event2.CallWithSelf);
		move_PathFinished_Event2.method = pathFinished2.Method;
		return pathFinished2;
	}

	public static Delegate RoleStateTransition_OnStateChanged(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new RoleStateTransition.OnStateChanged(delegate(int param0, string param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.RoleStateTransition_OnStateChanged_Event roleStateTransition_OnStateChanged_Event = new DelegateFactory.RoleStateTransition_OnStateChanged_Event(func);
			RoleStateTransition.OnStateChanged onStateChanged = new RoleStateTransition.OnStateChanged(roleStateTransition_OnStateChanged_Event.Call);
			roleStateTransition_OnStateChanged_Event.method = onStateChanged.Method;
			return onStateChanged;
		}
		DelegateFactory.RoleStateTransition_OnStateChanged_Event roleStateTransition_OnStateChanged_Event2 = new DelegateFactory.RoleStateTransition_OnStateChanged_Event(func, self);
		RoleStateTransition.OnStateChanged onStateChanged2 = new RoleStateTransition.OnStateChanged(roleStateTransition_OnStateChanged_Event2.CallWithSelf);
		roleStateTransition_OnStateChanged_Event2.method = onStateChanged2.Method;
		return onStateChanged2;
	}

	public static Delegate EntityCreate_OnRoleCreated(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new EntityCreate.OnRoleCreated(delegate(SceneEntity param0, S2c_aoi_syncplayer param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.EntityCreate_OnRoleCreated_Event entityCreate_OnRoleCreated_Event = new DelegateFactory.EntityCreate_OnRoleCreated_Event(func);
			EntityCreate.OnRoleCreated onRoleCreated = new EntityCreate.OnRoleCreated(entityCreate_OnRoleCreated_Event.Call);
			entityCreate_OnRoleCreated_Event.method = onRoleCreated.Method;
			return onRoleCreated;
		}
		DelegateFactory.EntityCreate_OnRoleCreated_Event entityCreate_OnRoleCreated_Event2 = new DelegateFactory.EntityCreate_OnRoleCreated_Event(func, self);
		EntityCreate.OnRoleCreated onRoleCreated2 = new EntityCreate.OnRoleCreated(entityCreate_OnRoleCreated_Event2.CallWithSelf);
		entityCreate_OnRoleCreated_Event2.method = onRoleCreated2.Method;
		return onRoleCreated2;
	}

	public static Delegate EntityCreate_OnNpcCreated(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new EntityCreate.OnNpcCreated(delegate(SceneEntity param0, S2c_aoi_syncnpc param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.EntityCreate_OnNpcCreated_Event entityCreate_OnNpcCreated_Event = new DelegateFactory.EntityCreate_OnNpcCreated_Event(func);
			EntityCreate.OnNpcCreated onNpcCreated = new EntityCreate.OnNpcCreated(entityCreate_OnNpcCreated_Event.Call);
			entityCreate_OnNpcCreated_Event.method = onNpcCreated.Method;
			return onNpcCreated;
		}
		DelegateFactory.EntityCreate_OnNpcCreated_Event entityCreate_OnNpcCreated_Event2 = new DelegateFactory.EntityCreate_OnNpcCreated_Event(func, self);
		EntityCreate.OnNpcCreated onNpcCreated2 = new EntityCreate.OnNpcCreated(entityCreate_OnNpcCreated_Event2.CallWithSelf);
		entityCreate_OnNpcCreated_Event2.method = onNpcCreated2.Method;
		return onNpcCreated2;
	}

	public static Delegate System_Action_bool(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<bool>(delegate(bool param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_bool_Event system_Action_bool_Event = new DelegateFactory.System_Action_bool_Event(func);
			Action<bool> action = new Action<bool>(system_Action_bool_Event.Call);
			system_Action_bool_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_bool_Event system_Action_bool_Event2 = new DelegateFactory.System_Action_bool_Event(func, self);
		Action<bool> action2 = new Action<bool>(system_Action_bool_Event2.CallWithSelf);
		system_Action_bool_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate MessageBox_onButtonClicked(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new MessageBox.onButtonClicked(delegate(GameObject param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.MessageBox_onButtonClicked_Event messageBox_onButtonClicked_Event = new DelegateFactory.MessageBox_onButtonClicked_Event(func);
			MessageBox.onButtonClicked onButtonClicked = new MessageBox.onButtonClicked(messageBox_onButtonClicked_Event.Call);
			messageBox_onButtonClicked_Event.method = onButtonClicked.Method;
			return onButtonClicked;
		}
		DelegateFactory.MessageBox_onButtonClicked_Event messageBox_onButtonClicked_Event2 = new DelegateFactory.MessageBox_onButtonClicked_Event(func, self);
		MessageBox.onButtonClicked onButtonClicked2 = new MessageBox.onButtonClicked(messageBox_onButtonClicked_Event2.CallWithSelf);
		messageBox_onButtonClicked_Event2.method = onButtonClicked2.Method;
		return onButtonClicked2;
	}

	public static Delegate SDKInterface_LoginSucHandler(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new SDKInterface.LoginSucHandler(delegate(LoginResult param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.SDKInterface_LoginSucHandler_Event sDKInterface_LoginSucHandler_Event = new DelegateFactory.SDKInterface_LoginSucHandler_Event(func);
			SDKInterface.LoginSucHandler loginSucHandler = new SDKInterface.LoginSucHandler(sDKInterface_LoginSucHandler_Event.Call);
			sDKInterface_LoginSucHandler_Event.method = loginSucHandler.Method;
			return loginSucHandler;
		}
		DelegateFactory.SDKInterface_LoginSucHandler_Event sDKInterface_LoginSucHandler_Event2 = new DelegateFactory.SDKInterface_LoginSucHandler_Event(func, self);
		SDKInterface.LoginSucHandler loginSucHandler2 = new SDKInterface.LoginSucHandler(sDKInterface_LoginSucHandler_Event2.CallWithSelf);
		sDKInterface_LoginSucHandler_Event2.method = loginSucHandler2.Method;
		return loginSucHandler2;
	}

	public static Delegate SDKInterface_LogoutHandler(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new SDKInterface.LogoutHandler(delegate
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.SDKInterface_LogoutHandler_Event sDKInterface_LogoutHandler_Event = new DelegateFactory.SDKInterface_LogoutHandler_Event(func);
			SDKInterface.LogoutHandler logoutHandler = new SDKInterface.LogoutHandler(sDKInterface_LogoutHandler_Event.Call);
			sDKInterface_LogoutHandler_Event.method = logoutHandler.Method;
			return logoutHandler;
		}
		DelegateFactory.SDKInterface_LogoutHandler_Event sDKInterface_LogoutHandler_Event2 = new DelegateFactory.SDKInterface_LogoutHandler_Event(func, self);
		SDKInterface.LogoutHandler logoutHandler2 = new SDKInterface.LogoutHandler(sDKInterface_LogoutHandler_Event2.CallWithSelf);
		sDKInterface_LogoutHandler_Event2.method = logoutHandler2.Method;
		return logoutHandler2;
	}

	public static Delegate System_Action_string(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<string>(delegate(string param0)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_string_Event system_Action_string_Event = new DelegateFactory.System_Action_string_Event(func);
			Action<string> action = new Action<string>(system_Action_string_Event.Call);
			system_Action_string_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_string_Event system_Action_string_Event2 = new DelegateFactory.System_Action_string_Event(func, self);
		Action<string> action2 = new Action<string>(system_Action_string_Event2.CallWithSelf);
		system_Action_string_Event2.method = action2.Method;
		return action2;
	}

	public static Delegate System_Action_string_string(LuaFunction func, LuaTable self, bool flag)
	{
		if (func == null)
		{
			return new Action<string, string>(delegate(string param0, string param1)
			{
			});
		}
		if (!flag)
		{
			DelegateFactory.System_Action_string_string_Event system_Action_string_string_Event = new DelegateFactory.System_Action_string_string_Event(func);
			Action<string, string> action = new Action<string, string>(system_Action_string_string_Event.Call);
			system_Action_string_string_Event.method = action.Method;
			return action;
		}
		DelegateFactory.System_Action_string_string_Event system_Action_string_string_Event2 = new DelegateFactory.System_Action_string_string_Event(func, self);
		Action<string, string> action2 = new Action<string, string>(system_Action_string_string_Event2.CallWithSelf);
		system_Action_string_string_Event2.method = action2.Method;
		return action2;
	}
}
