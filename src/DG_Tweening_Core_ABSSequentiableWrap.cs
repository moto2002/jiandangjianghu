using DG.Tweening.Core;
using LuaInterface;
using System;

public class DG_Tweening_Core_ABSSequentiableWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ABSSequentiable), typeof(object), null);
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.EndClass();
	}
}
