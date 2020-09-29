using DotNetCoreUtilities.Miscellaneous;
using System.Collections.Generic;
using System.Linq.Expressions;
using FastExpressionCompiler;
using System.Reflection;
using System.Linq;
using System;

namespace DotNetCoreUtilities.CodeGeneration
{
	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Func<T, TOut>> InstanceMethods =
			new Dictionary<string, Func<T, TOut>>();

		private static readonly Dictionary<string, Func<TOut>> StaticMethods = new Dictionary<string, Func<TOut>>();

		public static void Call(string name, T instance)
		{
			Get(name).Invoke(instance);
		}

		public static Func<T, TOut> Get(string name)
		{
			if (InstanceMethods.TryGetValue(name, out var action)) return action;
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var call = Expression.Call(instance, method);
			action = action = Expression.Lambda<Func<T, TOut>>(call, instance).CompileFast();
			InstanceMethods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name)
		{
			GetStatic(name).Invoke();
		}

		public static Func<TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var call = Expression.Call(method);
			action = Expression.Lambda<Func<TOut>>(call).CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Func<T, T0, TOut>> Methods =
			new Dictionary<string, Func<T, T0, TOut>>();

		private static readonly Dictionary<string, Func<T0, TOut>> StaticMethods =
			new Dictionary<string, Func<T0, TOut>>();

		public static void Call(string name, T instance, in T0 arg0)
		{
			Get(name).Invoke(instance, arg0);
		}

		public static Func<T, T0, TOut> Get(string name)
		{
			if (Methods.TryGetValue(name, out var func)) return func;
			var args = new[] {TypeInfo<T0>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			func = Expression.Lambda<Func<T, T0, TOut>>(call, new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, func);
			return func;
		}

		public static void CallStatic(string name, in T0 arg0)
		{
			GetStatic(name).Invoke(arg0);
		}

		public static Func<T0, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[] {TypeInfo<T0>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression.Lambda<Func<T0, TOut>>(call, parameters).CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, T1, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Func<T, T0, T1, TOut>> Methods =
			new Dictionary<string, Func<T, T0, T1, TOut>>();

		private static readonly Dictionary<string, Func<T0, T1, TOut>> StaticMethods =
			new Dictionary<string, Func<T0, T1, TOut>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1)
		{
			Get(name).Invoke(instance, arg0, arg1);
		}

		public static Func<T, T0, T1, TOut> Get(string name)
		{
			if (Methods.TryGetValue(name, out var func)) return func;
			var args = new[] {TypeInfo<T0>.Type, TypeInfo<T1>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			func = Expression.Lambda<Func<T, T0, T1, TOut>>(call, new[] {instance}.ArrayAppend(parameters))
				.CompileFast();
			Methods.Add(name, func);
			return func;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1)
		{
			GetStatic(name).Invoke(arg0, arg1);
		}

		public static Func<T0, T1, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[] {TypeInfo<T0>.Type, TypeInfo<T1>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression.Lambda<Func<T0, T1, TOut>>(call, parameters).CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, T1, T2, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Func<T, T0, T1, T2, TOut>> Methods =
			new Dictionary<string, Func<T, T0, T1, T2, TOut>>();

		private static readonly Dictionary<string, Func<T0, T1, T2, TOut>> StaticMethods =
			new Dictionary<string, Func<T0, T1, T2, TOut>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2);
		}

		public static Func<T, T0, T1, T2, TOut> Get(string name)
		{
			if (Methods.TryGetValue(name, out var func)) return func;
			var args = new[] {TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			func = Expression.Lambda<Func<T, T0, T1, T2, TOut>>(call, new[] {instance}.ArrayAppend(parameters))
				.CompileFast();
			Methods.Add(name, func);
			return func;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2);
		}

		public static Func<T0, T1, T2, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[] {TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression.Lambda<Func<T0, T1, T2, TOut>>(call, parameters).CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, T1, T2, T3, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Func<T, T0, T1, T2, T3, TOut>> Methods =
			new Dictionary<string, Func<T, T0, T1, T2, T3, TOut>>();

		private static readonly Dictionary<string, Func<T0, T1, T2, T3, TOut>> StaticMethods =
			new Dictionary<string, Func<T0, T1, T2, T3, TOut>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3);
		}

		public static Func<T, T0, T1, T2, T3, TOut> Get(string name)
		{
			if (Methods.TryGetValue(name, out var func)) return func;
			var args = new[] {TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			func = Expression.Lambda<Func<T, T0, T1, T2, T3, TOut>>(call, new[] {instance}.ArrayAppend(parameters))
				.CompileFast();
			Methods.Add(name, func);
			return func;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3);
		}

		public static Func<T0, T1, T2, T3, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[] {TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression.Lambda<Func<T0, T1, T2, T3, TOut>>(call, parameters).CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, T1, T2, T3, T4, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Func<T, T0, T1, T2, T3, T4, TOut>> Methods =
			new Dictionary<string, Func<T, T0, T1, T2, T3, T4, TOut>>();

		private static readonly Dictionary<string, Func<T0, T1, T2, T3, T4, TOut>> StaticMethods =
			new Dictionary<string, Func<T0, T1, T2, T3, T4, TOut>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4);
		}

		public static Func<T, T0, T1, T2, T3, T4, TOut> Get(string name)
		{
			if (Methods.TryGetValue(name, out var func)) return func;
			var args = new[]
				{TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			func = Expression.Lambda<Func<T, T0, T1, T2, T3, T4, TOut>>(call, new[] {instance}.ArrayAppend(parameters))
				.CompileFast();
			Methods.Add(name, func);
			return func;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4);
		}

		public static Func<T0, T1, T2, T3, T4, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[]
				{TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression.Lambda<Func<T0, T1, T2, T3, T4, TOut>>(call, parameters).CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, T1, T2, T3, T4, T5, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, TOut>> Methods =
			new Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, TOut>>();

		private static readonly Dictionary<string, Func<T0, T1, T2, T3, T4, T5, TOut>> StaticMethods =
			new Dictionary<string, Func<T0, T1, T2, T3, T4, T5, TOut>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5);
		}

		public static Func<T, T0, T1, T2, T3, T4, T5, TOut> Get(string name)
		{
			if (Methods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			func = Expression
				.Lambda<Func<T, T0, T1, T2, T3, T4, T5, TOut>>(call, new[] {instance}.ArrayAppend(parameters))
				.CompileFast();
			Methods.Add(name, func);
			return func;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5);
		}

		public static Func<T0, T1, T2, T3, T4, T5, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, TOut>>(call, parameters).CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, T1, T2, T3, T4, T5, T6, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, TOut>> Methods =
			new Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, TOut>>();

		private static readonly Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, TOut>> StaticMethods =
			new Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, TOut>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static Func<T, T0, T1, T2, T3, T4, T5, T6, TOut> Get(string name)
		{
			if (Methods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			func = Expression
				.Lambda<Func<T, T0, T1, T2, T3, T4, T5, T6, TOut>>(call, new[] {instance}.ArrayAppend(parameters))
				.CompileFast();
			Methods.Add(name, func);
			return func;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static Func<T0, T1, T2, T3, T4, T5, T6, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, TOut>>(call, parameters).CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, TOut>> Methods =
			new Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, TOut>>();

		private static readonly Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, TOut>> StaticMethods =
			new Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, TOut>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6, in T7 arg7)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static Func<T, T0, T1, T2, T3, T4, T5, T6, T7, TOut> Get(string name)
		{
			if (Methods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			func = Expression
				.Lambda<Func<T, T0, T1, T2, T3, T4, T5, T6, T7, TOut>>(call, new[] {instance}.ArrayAppend(parameters))
				.CompileFast();
			Methods.Add(name, func);
			return func;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, in T5 arg5, in T6 arg6, in T7 arg7)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static Func<T0, T1, T2, T3, T4, T5, T6, T7, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, TOut>>(call, parameters).CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, TOut>> Methods =
			new Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, TOut>>();

		private static readonly Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TOut>> StaticMethods =
			new Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TOut>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, TOut> Get(string name)
		{
			if (Methods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type, TypeInfo<T8>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			func = Expression
				.Lambda<Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, TOut>>(call,
					new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, func);
			return func;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type, TypeInfo<T8>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, TOut>>(call, parameters).CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut>> Methods =
			new Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut>>();

		private static readonly Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut>> StaticMethods =
			new Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut> Get(string name)
		{
			if (Methods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type, TypeInfo<T8>.Type, TypeInfo<T9>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			func = Expression
				.Lambda<Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut>>(call,
					new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, func);
			return func;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type, TypeInfo<T8>.Type, TypeInfo<T9>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, TOut>>(call, parameters)
				.CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TOut>> Methods =
			new Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TOut>>();

		private static readonly Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TOut>>
			StaticMethods = new Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TOut>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TOut> Get(string name)
		{
			if (Methods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type, TypeInfo<T8>.Type, TypeInfo<T9>.Type,
				TypeInfo<T10>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			func = Expression
				.Lambda<Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TOut>>(call,
					new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, func);
			return func;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type, TypeInfo<T8>.Type, TypeInfo<T9>.Type,
				TypeInfo<T10>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TOut>>(call, parameters)
				.CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TOut>>
			Methods = new Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TOut>>();

		private static readonly Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TOut>>
			StaticMethods = new Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TOut>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TOut> Get(string name)
		{
			if (Methods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type, TypeInfo<T8>.Type, TypeInfo<T9>.Type,
				TypeInfo<T10>.Type, TypeInfo<T11>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			func = Expression
				.Lambda<Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TOut>>(call,
					new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, func);
			return func;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type, TypeInfo<T8>.Type, TypeInfo<T9>.Type,
				TypeInfo<T10>.Type, TypeInfo<T11>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TOut>>(call, parameters)
				.CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TOut>>
			Methods = new Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TOut>>();

		private static readonly Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TOut>>
			StaticMethods = new Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TOut>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11,
				arg12);
		}

		public static Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TOut> Get(string name)
		{
			if (Methods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type, TypeInfo<T8>.Type, TypeInfo<T9>.Type,
				TypeInfo<T10>.Type, TypeInfo<T11>.Type, TypeInfo<T12>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			func = Expression
				.Lambda<Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TOut>>(call,
					new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, func);
			return func;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type, TypeInfo<T8>.Type, TypeInfo<T9>.Type,
				TypeInfo<T10>.Type, TypeInfo<T11>.Type, TypeInfo<T12>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression
				.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TOut>>(call, parameters)
				.CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TOut>> Methods =
			new Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TOut>>();

		private static readonly Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TOut>> StaticMethods =
			new Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TOut>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12, in T13 arg13)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11,
				arg12, arg13);
		}

		public static Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TOut> Get(string name)
		{
			if (Methods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type, TypeInfo<T8>.Type, TypeInfo<T9>.Type,
				TypeInfo<T10>.Type, TypeInfo<T11>.Type, TypeInfo<T12>.Type, TypeInfo<T13>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			func = Expression
				.Lambda<Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TOut>>(call,
					new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, func);
			return func;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4, 
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12, in T13 arg13)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type, TypeInfo<T8>.Type, TypeInfo<T9>.Type,
				TypeInfo<T10>.Type, TypeInfo<T11>.Type, TypeInfo<T12>.Type, TypeInfo<T13>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression
				.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TOut>>(call, parameters)
				.CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly
			Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TOut>> Methods = 
				new Dictionary<string, Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TOut>>();

		private static readonly
			Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TOut>>
			StaticMethods = new Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TOut>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12,
			in T13 arg13, in T14 arg14)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11,
				arg12, arg13, arg14);
		}

		public static Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TOut> Get(string name)
		{
			if (Methods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type, TypeInfo<T8>.Type, TypeInfo<T9>.Type,
				TypeInfo<T10>.Type, TypeInfo<T11>.Type, TypeInfo<T12>.Type, TypeInfo<T13>.Type, TypeInfo<T14>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			func = Expression
				.Lambda<Func<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TOut>>(call,
					new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, func);
			return func;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12,
			in T13 arg13, in T14 arg14)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12,
				arg13, arg14);
		}

		public static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type, TypeInfo<T8>.Type, TypeInfo<T9>.Type,
				TypeInfo<T10>.Type, TypeInfo<T11>.Type, TypeInfo<T12>.Type, TypeInfo<T13>.Type, TypeInfo<T14>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression
				.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TOut>>(call, parameters)
				.CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class FuncMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TOut>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly
			Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TOut>>
			StaticMethods = new Dictionary<string, Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TOut>>();

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12,
			in T13 arg13, in T14 arg14, in T15 arg15)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12,
				arg13, arg14, arg15);
		}

		public static Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TOut> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var func)) return func;
			var args = new[]
			{
				TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type,
				TypeInfo<T5>.Type, TypeInfo<T6>.Type, TypeInfo<T7>.Type, TypeInfo<T8>.Type, TypeInfo<T9>.Type,
				TypeInfo<T10>.Type, TypeInfo<T11>.Type, TypeInfo<T12>.Type, TypeInfo<T13>.Type, TypeInfo<T14>.Type,
				TypeInfo<T15>.Type
			};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			func = Expression
				.Lambda<Func<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TOut>>(call,
					parameters).CompileFast();
			StaticMethods.Add(name, func);
			return func;
		}
	}
}