using System.Collections.Generic;
using System.Linq.Expressions;
using FastExpressionCompiler;
using System.Reflection;
using System;

namespace DotNetCoreUtilities.CodeGeneration
{
	public static class Field<T, TF>
	{
		public const BindingFlags Bindings = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
		public delegate void Setter(ref T obj, TF value);
		public delegate TF Getter(ref T obj);

		private static Dictionary<string, Getter> _get = new Dictionary<string, Getter>();
		private static Dictionary<string, Setter> _set = new Dictionary<string, Setter>();
		
		public static TF GetValue(string name, ref T obj) => GetGetter(name).Invoke(ref obj);
		
		public static void SetValue(string name, ref T obj, TF value) => GetSetter(name).Invoke(ref obj, value);

		public static Getter GetGetter(string name)
		{
			if (_get.TryGetValue(name, out var get))
				return get;

			lock (_get)
			{
				var type = TypeInfo<T>.Type;
				var fieldType = TypeInfo<TF>.Type;
				var field = type.GetField(name, Bindings);
				
				if (field == null) throw new KeyNotFoundException($"Type {type} has no fields named {name}");
				if (field.FieldType != fieldType) throw new InvalidCastException($"Field {name} is not of type {fieldType}");
				
				var instance = Expression.Parameter(type.MakeByRefType(), "instance");
				var member = Expression.Field(instance, field);
				get = Expression.Lambda<Getter>(member, instance).CompileFast();
				_get.Add(name, get);
				return get;
			}
		}

		public static Setter GetSetter(string name)
		{
			if (_set.TryGetValue(name, out var set))
				return set;

			lock (_set)
			{
				var type = TypeInfo<T>.Type;
				var fieldType = TypeInfo<TF>.Type;
				var field = type.GetField(name, Bindings);
				
				if (field == null) throw new KeyNotFoundException($"Type {type} has no fields named {name}");
				if (field.FieldType != fieldType) throw new InvalidCastException($"Field {name} is not of type {fieldType}");
				if (field.IsInitOnly) return null;

				var instance = Expression.Parameter(type.MakeByRefType(), "instance");
				var member = Expression.Field(instance, field);
				var parameter = Expression.Parameter(fieldType, "value");
				var assign = Expression.Assign(member, parameter);
				set = Expression.Lambda<Setter>(assign, instance, parameter).CompileFast();
				_set.Add(name, set);
				return set;
			}
		}
	}
}