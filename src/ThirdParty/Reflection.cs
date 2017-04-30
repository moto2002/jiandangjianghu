using System;
using System.Collections.Generic;
using System.Reflection;

namespace ThirdParty
{
	public static class Reflection
	{
		public static FieldInfo GetRuntimeField(this Type type, string name)
		{
			return type.GetField(name);
		}

		public static IEnumerable<FieldInfo> GetRuntimeFields(this Type type)
		{
			return type.GetFields();
		}

		public static PropertyInfo GetRuntimeProperty(this Type type, string name)
		{
			return type.GetProperty(name);
		}

		public static IEnumerable<PropertyInfo> GetRuntimeProperties(this Type type)
		{
			return type.GetProperties();
		}

		public static EventInfo GetRuntimeEvent(this Type type, string name)
		{
			return type.GetEvent(name);
		}

		public static IEnumerable<EventInfo> GetRuntimeEvents(this Type type)
		{
			return type.GetEvents();
		}

		public static MethodInfo GetRuntimeMethod(this Type type, string name, params Type[] parameters)
		{
			return type.GetMethod(name, parameters);
		}

		public static IEnumerable<MethodInfo> GetRuntimeMethods(this Type type)
		{
			return type.GetMethods();
		}
	}
}
