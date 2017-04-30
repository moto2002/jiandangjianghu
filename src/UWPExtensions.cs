using System;
using System.Reflection;

public static class UWPExtensions
{
	public static bool IsInstanceOfType(this Type type, object obj)
	{
		return type.IsInstanceOfType(obj);
	}

	public static bool IsPublic(this Type type)
	{
		return type.IsPublic;
	}

	public static bool IsNotPublic(this Type type)
	{
		return type.IsNotPublic;
	}

	public static bool IsNestedPublic(this Type type)
	{
		return type.IsNestedPublic;
	}

	public static bool IsGenericType(this Type type)
	{
		return type.IsGenericType;
	}

	public static bool IsEnum(this Type type)
	{
		return type.IsEnum;
	}

	public static bool IsValueType(this Type type)
	{
		return type.IsValueType;
	}

	public static bool IsPrimitive(this Type type)
	{
		return type.IsPrimitive;
	}

	public static bool IsGenericTypeDefinition(this Type type)
	{
		return type.IsGenericTypeDefinition;
	}

	public static bool IsNested(this Type type)
	{
		return type.IsNested;
	}

	public static bool IsNestedAssembly(this Type type)
	{
		return type.IsNestedAssembly;
	}

	public static bool IsNestedFamORAssem(this Type type)
	{
		return type.IsNestedFamORAssem;
	}

	public static bool IsNestedFamANDAssem(this Type type)
	{
		return type.IsNestedFamANDAssem;
	}

	public static bool IsAbstract(this Type type)
	{
		return type.IsAbstract;
	}

	public static bool IsSealed(this Type type)
	{
		return type.IsSealed;
	}

	public static bool IsInterface(this Type type)
	{
		return type.IsInterface;
	}

	public static bool IsNestedFamily(this Type type)
	{
		return type.IsNestedFamily;
	}

	public static bool IsNestedPrivate(this Type type)
	{
		return type.IsNestedPrivate;
	}

	public static Assembly Assembly(this Type type)
	{
		return type.Assembly;
	}

	public static Type BaseType(this Type type)
	{
		return type.BaseType;
	}

	public static bool IsAssignableFrom(this Type type, Type c)
	{
		return type.IsAssignableFrom(c);
	}

	public static Type[] GetGenericArguments(this Type type)
	{
		return type.GetGenericArguments();
	}

	public static bool IsSubclassOf(this Type type, Type t)
	{
		return type.IsSubclassOf(t);
	}

	public static bool IsDefined(this Type type, Type t, bool inherit)
	{
		return type.IsDefined(t, inherit);
	}

	public static object[] GetCustomAttributes(this Type type, Type attributeType, bool inherit)
	{
		return type.GetCustomAttributes(attributeType, inherit);
	}

	public static MethodInfo Method(this Delegate del)
	{
		return del.Method;
	}
}
