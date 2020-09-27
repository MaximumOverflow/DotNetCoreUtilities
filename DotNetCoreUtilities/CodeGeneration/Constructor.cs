using System.Linq.Expressions;
using FastExpressionCompiler;
using System.Linq;
using System;

namespace DotNetCoreUtilities.CodeGeneration
{
	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T> where T : new()
	{
		private static readonly Func<T> Ctor = Create();
		public static T New() => Ctor();

		private static Func<T> Create()
		{
			var args = Array.Empty<Type>();
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0>
	{
		private static readonly Func<TArg0, T> Ctor = Create();
		public static T New(in TArg0 arg0) => Ctor(arg0);

		private static Func<TArg0, T> Create()
		{
			var args = new[] { typeof(TArg0), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0, TArg1>
	{
		private static readonly Func<TArg0, TArg1, T> Ctor = Create();
		public static T New(in TArg0 arg0, in TArg1 arg1) => Ctor(arg0, arg1);

		private static Func<TArg0, TArg1, T> Create()
		{
			var args = new[] { typeof(TArg0), typeof(TArg1), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, TArg1, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0, TArg1, TArg2>
	{
		private static readonly Func<TArg0, TArg1, TArg2, T> Ctor = Create();
		public static T New(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2) => Ctor(arg0, arg1, arg2);

		private static Func<TArg0, TArg1, TArg2, T> Create()
		{
			var args = new[] { typeof(TArg0), typeof(TArg1), typeof(TArg2), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, TArg1, TArg2, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0, TArg1, TArg2, TArg3>
	{
		private static readonly Func<TArg0, TArg1, TArg2, TArg3, T> Ctor = Create();
		public static T New(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3) => Ctor(arg0, arg1, arg2, arg3);

		private static Func<TArg0, TArg1, TArg2, TArg3, T> Create()
		{
			var args = new[] { typeof(TArg0), typeof(TArg1), typeof(TArg2), typeof(TArg3), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, TArg1, TArg2, TArg3, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4>
	{
		private static readonly Func<TArg0, TArg1, TArg2, TArg3, TArg4, T> Ctor = Create();
		public static T New(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4) => Ctor(arg0, arg1, arg2, arg3, arg4);

		private static Func<TArg0, TArg1, TArg2, TArg3, TArg4, T> Create()
		{
			var args = new[] { typeof(TArg0), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, TArg1, TArg2, TArg3, TArg4, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>
	{
		private static readonly Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, T> Ctor = Create();
		public static T New(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5) => Ctor(arg0, arg1, arg2, arg3, arg4, arg5);

		private static Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, T> Create()
		{
			var args = new[] { typeof(TArg0), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
	{
		private static readonly Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, T> Ctor = Create();
		public static T New(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6) => Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6);

		private static Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, T> Create()
		{
			var args = new[] { typeof(TArg0), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
	{
		private static readonly Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, T> Ctor = Create();
		public static T New(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7) => Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);

		private static Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, T> Create()
		{
			var args = new[] { typeof(TArg0), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
	{
		private static readonly Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, T> Ctor = Create();
		public static T New(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8) => Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

		private static Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, T> Create()
		{
			var args = new[] { typeof(TArg0), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>
	{
		private static readonly Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, T> Ctor = Create();
		public static T New(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9) => Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);

		private static Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, T> Create()
		{
			var args = new[] { typeof(TArg0), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>
	{
		private static readonly Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, T> Ctor = Create();
		public static T New(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10) => Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);

		private static Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, T> Create()
		{
			var args = new[] { typeof(TArg0), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>
	{
		private static readonly Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, T> Ctor = Create();
		public static T New(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11) => Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);

		private static Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, T> Create()
		{
			var args = new[] { typeof(TArg0), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10), typeof(TArg11), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>
	{
		private static readonly Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, T> Ctor = Create();
		public static T New(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12) => Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);

		private static Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, T> Create()
		{
			var args = new[] { typeof(TArg0), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10), typeof(TArg11), typeof(TArg12), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>
	{
		private static readonly Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, T> Ctor = Create();
		public static T New(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13) => Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);

		private static Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, T> Create()
		{
			var args = new[] { typeof(TArg0), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10), typeof(TArg11), typeof(TArg12), typeof(TArg13), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>
	{
		private static readonly Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, T> Ctor = Create();
		public static T New(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14) => Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);

		private static Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, T> Create()
		{
			var args = new[] { typeof(TArg0), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10), typeof(TArg11), typeof(TArg12), typeof(TArg13), typeof(TArg14), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}

	/// <summary>An utility class to execute fast duck-typed constructor calls</summary>
	public static class Constructor<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>
	{
		private static readonly Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, T> Ctor = Create();
		public static T New(in TArg0 arg0, in TArg1 arg1, in TArg2 arg2, in TArg3 arg3, in TArg4 arg4, in TArg5 arg5, in TArg6 arg6, in TArg7 arg7, in TArg8 arg8, in TArg9 arg9, in TArg10 arg10, in TArg11 arg11, in TArg12 arg12, in TArg13 arg13, in TArg14 arg14, in TArg15 arg15) => Ctor(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);

		private static Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, T> Create()
		{
			var args = new[] { typeof(TArg0), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TArg6), typeof(TArg7), typeof(TArg8), typeof(TArg9), typeof(TArg10), typeof(TArg11), typeof(TArg12), typeof(TArg13), typeof(TArg14), typeof(TArg15), };
			var ctor = typeof(T).GetConstructor(args);
			if(ctor == null) 
				throw new MissingMethodException($"Type {typeof(T)} does not implement the specified constructor");

			var argExpressions = args.Select(Expression.Parameter).ToArray();
			var ctorExpression = Expression.New(ctor, argExpressions);
			var expression = Expression.Lambda<Func<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, T>>(ctorExpression, argExpressions);
			return expression.CompileFast();

		}
	}
}