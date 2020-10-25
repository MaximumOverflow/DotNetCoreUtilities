using DotNetCoreUtilities.CodeGeneration;
using System.Reflection;
using System;

namespace DotNetCoreUtilities
{
	/// <summary>I simple utility class to speed up refection based operations</summary>
	public static class TypeInfo<T>
	{
		public static readonly Type Type = typeof(T);

		public static readonly string Name = Type.Name;
		public static readonly string FullName = Type.FullName;

		public static readonly bool IsEnum = Type.IsEnum;
		public static readonly bool IsClass = Type.IsClass;
		public static readonly bool IsInterface = Type.IsInterface;
		public static readonly bool IsValueType = Type.IsValueType;
		
		public static readonly int Hash = Type.GetHashCode();
		public static readonly int Size = System.Runtime.CompilerServices.Unsafe.SizeOf<T>();
		
		public static FieldInfo<T, TF> GetField<TF>(string name)
		{
			var info = Type.GetField(name, Field<T, TF>.Bindings);
			var getter = Field<T, TF>.GetGetter(name);
			var setter = Field<T, TF>.GetSetter(name);
			return new FieldInfo<T, TF>(info, getter, setter);
		}
			
	}

	public readonly struct FieldInfo<T, TF>
	{
		public readonly FieldInfo Info;
		private readonly Field<T, TF>.Getter _getter;
		private readonly Field<T, TF>.Setter _setter;

		public FieldInfo(FieldInfo info, Field<T, TF>.Getter getter, Field<T, TF>.Setter setter)
			=> (Info, _getter, _setter) = (info, getter, setter);

		public TF GetValue(ref T obj) => _getter.Invoke(ref obj);
		public void SetValue(ref T obj, TF value)
		{
			if (_setter == null) throw new InvalidOperationException($"Field {Info} has no setter");
			_setter.Invoke(ref obj, value);
		}
	}
}