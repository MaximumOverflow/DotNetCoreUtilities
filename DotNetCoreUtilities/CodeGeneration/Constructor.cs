﻿using System.Collections.Generic;
using System.Linq.Expressions;
using FastExpressionCompiler;
using System.Linq;
using System;

namespace DotNetCoreUtilities.CodeGeneration
{
	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor
	{
		private static readonly Dictionary<Type, Func<object>> Ctor = new Dictionary<Type, Func<object>>();

		public static object New(Type type)
		{
			if (Ctor.TryGetValue(type, out var ctor)) return ctor();
			ctor = Create(type);
			Ctor.Add(type, ctor);
			return ctor();
		}

		private static Func<object> Create(Type type)
		{
			if (type.IsValueType)
			{
				var ctorExpression = Expression.New(type);
				var castExpression = Expression.Convert(ctorExpression, TypeInfo<object>.Type);
				var expression = Expression.Lambda<Func<object>>(castExpression);
				return expression.CompileFast();
			}
			else
			{
				var args = Array.Empty<Type>();
				var ctor = type.GetConstructor(args);
				if (ctor == null)
					throw new MissingMethodException($"Type {type} does not implement the specified constructor.");

				var ctorExpression = Expression.New(type);
				var castExpression = Expression.Convert(ctorExpression, TypeInfo<object>.Type);
				var expression = Expression.Lambda<Func<object>>(castExpression);
				return expression.CompileFast();
			}
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T>
	{
		private static readonly Func<T> Ctor = Create();

		public static T New()
		{
			return Ctor();
		}

		private static Func<T> Create()
		{
			var args = Array.Empty<Type>();
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<T>>(ctorExpression, argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0>
	{
		private static readonly Func<T0, T> Ctor = Create();

		public static T New(in T0 arg0)
		{
			return Ctor(arg0);
		}

		private static Func<T0, T> Create()
		{
			var args = new[] {typeof(T0)};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<T0, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0, T1>
	{
		private static readonly Func<T0, T1, T> Ctor = Create();

		public static T New(in T0 arg0, in T1 arg1)
		{
			return Ctor(arg0, arg1);
		}

		private static Func<T0, T1, T> Create()
		{
			var args = new[] {typeof(T0), typeof(T1)};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<T0, T1, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0, T1, T2>
	{
		private static readonly Func<T0, T1, T2, T> Ctor = Create();

		public static T New(in T0 arg0, in T1 arg1, in T2 arg2)
		{
			return Ctor(arg0, arg1, arg2);
		}

		private static Func<T0, T1, T2, T> Create()
		{
			var args = new[] {typeof(T0), typeof(T1), typeof(T2)};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<T0, T1, T2, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0, T1, T2, T3>
	{
		private static readonly Func<T0, T1, T2, T3, T> Ctor = Create();

		public static T New(in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3)
		{
			return Ctor(arg0, arg1, arg2, arg3);
		}

		private static Func<T0, T1, T2, T3, T> Create()
		{
			var args = new[] {typeof(T0), typeof(T1), typeof(T2), typeof(T3)};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<T0, T1, T2, T3, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0, T1, T2, T3, T4>
	{
		private static readonly Func<T0, T1, T2, T3, T4, T> Ctor = Create();

		public static T New(in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4)
		{
			return Ctor(arg0, arg1, arg2, arg3, arg4);
		}

		private static Func<T0, T1, T2, T3, T4, T> Create()
		{
			var args = new[] {typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4)};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<T0, T1, T2, T3, T4, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0, T1, T2, T3, T4, T5>
	{
		private static readonly Func<T0, T1, T2, T3, T4, T5, T> Ctor = Create();

		public static T New(in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5)
		{
			return Ctor(arg0, arg1, arg2, arg3, arg4, arg5);
		}

		private static Func<T0, T1, T2, T3, T4, T5, T> Create()
		{
			var args = new[] {typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5)};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0, T1, T2, T3, T4, T5, T6>
	{
		private static readonly Func<T0, T1, T2, T3, T4, T5, T6, T> Ctor = Create();

		public static T New(in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6)
		{
			return Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		private static Func<T0, T1, T2, T3, T4, T5, T6, T> Create()
		{
			var args = new[] {typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6)};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0, T1, T2, T3, T4, T5, T6, T7>
	{
		private static readonly Func<T0, T1, T2, T3, T4, T5, T6, T7, T> Ctor = Create();

		public static T New(in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6,
			in T7 arg7)
		{
			return Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		private static Func<T0, T1, T2, T3, T4, T5, T6, T7, T> Create()
		{
			var args = new[]
				{typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7)};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0, T1, T2, T3, T4, T5, T6, T7, T8>
	{
		private static readonly Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T> Ctor = Create();

		public static T New(in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6,
			in T7 arg7, in T8 arg8)
		{
			return Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		private static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T> Create()
		{
			var args = new[]
			{
				typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7),
				typeof(T8)
			};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression =
				Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>
	{
		private static readonly Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T> Ctor = Create();

		public static T New(in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6,
			in T7 arg7, in T8 arg8, in T9 arg9)
		{
			return Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		private static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T> Create()
		{
			var args = new[]
			{
				typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7),
				typeof(T8), typeof(T9)
			};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression =
				Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
	{
		private static readonly Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T> Ctor = Create();

		public static T New(in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6,
			in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10)
		{
			return Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		private static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T> Create()
		{
			var args = new[]
			{
				typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7),
				typeof(T8), typeof(T9), typeof(T10)
			};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression =
				Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
	{
		private static readonly Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T> Ctor = Create();

		public static T New(in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6,
			in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11)
		{
			return Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		private static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T> Create()
		{
			var args = new[]
			{
				typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7),
				typeof(T8), typeof(T9), typeof(T10), typeof(T11)
			};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression =
				Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T>>(ctorExpression,
					argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
	{
		private static readonly Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T> Ctor = Create();

		public static T New(in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6,
			in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12)
		{
			return Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		private static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T> Create()
		{
			var args = new[]
			{
				typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7),
				typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12)
			};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression =
				Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T>>(ctorExpression,
					argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
	{
		private static readonly Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T> Ctor = Create();

		public static T New(in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6,
			in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12, in T13 arg13)
		{
			return Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		private static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T> Create()
		{
			var args = new[]
			{
				typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7),
				typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13)
			};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression =
				Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T>>(ctorExpression,
					argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
	{
		private static readonly Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T>
			Ctor = Create();

		public static T New(in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6,
			in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12, in T13 arg13, in T14 arg14)
		{
			return Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		private static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T> Create()
		{
			var args = new[]
			{
				typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7),
				typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14)
			};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression =
				Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T>>(
					ctorExpression, argExpressions);
			return expression.CompileFast();
		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls.</summary>
	public static class Constructor<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
	{
		private static readonly Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T> Ctor =
			Create();

		public static T New(in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6,
			in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12, in T13 arg13, in T14 arg14,
			in T15 arg15)
		{
			return Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14,
				arg15);
		}

		private static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T> Create()
		{
			var args = new[]
			{
				typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7),
				typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15)
			};
			var ctor = typeof(T).GetConstructor(args);
			if (ctor == null)
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor.");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression =
				Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T>>(
					ctorExpression, argExpressions);
			return expression.CompileFast();
		}
	}
}