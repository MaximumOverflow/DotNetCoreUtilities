using System;

namespace DotNetCoreUtilities
{
	/// <summary>I simple utility class for providing a cached typeof(T)</summary>
	public static class TypeInfo<T>
	{
		public static readonly Type Type = typeof(T);

		public static readonly string Name = Type.Name;
		public static readonly string FullName = Type.FullName;

		public static readonly bool IsEnum = Type.IsEnum;
		public static readonly bool IsClass = Type.IsClass;
		public static readonly bool IsInterface = Type.IsInterface;
		public static readonly bool IsValueType = Type.IsValueType;
	}
}