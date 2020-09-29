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
	public class ActionMethod<T>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Action<T>> InstanceMethods = new Dictionary<string, Action<T>>();

		private static readonly Dictionary<string, Action> StaticMethods = new Dictionary<string, Action>();

		public static void Call(string name, T instance)
		{
			Get(name).Invoke(instance);
		}

		public static Action<T> Get(string name)
		{
			if (InstanceMethods.TryGetValue(name, out var action)) return action;
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var call = Expression.Call(instance, method);
			action = Expression.Lambda<Action<T>>(call, instance).CompileFast();
			InstanceMethods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name)
		{
			GetStatic(name).Invoke();
		}

		public static Action GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var call = Expression.Call(method);
			action = Expression.Lambda<Action>(call).CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class ActionMethod<T, T0>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Action<T, T0>> Methods = new Dictionary<string, Action<T, T0>>();

		private static readonly Dictionary<string, Action<T0>> StaticMethods = new Dictionary<string, Action<T0>>();

		public static void Call(string name, T instance, in T0 arg0)
		{
			Get(name).Invoke(instance, arg0);
		}

		public static Action<T, T0> Get(string name)
		{
			if (Methods.TryGetValue(name, out var action)) return action;
			var args = new[] {TypeInfo<T0>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			action = Expression.Lambda<Action<T, T0>>(call, new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name, in T0 arg0)
		{
			GetStatic(name).Invoke(arg0);
		}

		public static Action<T0> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
			var args = new[] {TypeInfo<T0>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			action = Expression.Lambda<Action<T0>>(call, parameters).CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class ActionMethod<T, T0, T1>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Action<T, T0, T1>> Methods =
			new Dictionary<string, Action<T, T0, T1>>();

		private static readonly Dictionary<string, Action<T0, T1>> StaticMethods =
			new Dictionary<string, Action<T0, T1>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1)
		{
			Get(name).Invoke(instance, arg0, arg1);
		}

		public static Action<T, T0, T1> Get(string name)
		{
			if (Methods.TryGetValue(name, out var action)) return action;
			var args = new[] {TypeInfo<T0>.Type, TypeInfo<T1>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			action = Expression.Lambda<Action<T, T0, T1>>(call, new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1)
		{
			GetStatic(name).Invoke(arg0, arg1);
		}

		public static Action<T0, T1> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
			var args = new[] {TypeInfo<T0>.Type, TypeInfo<T1>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			action = Expression.Lambda<Action<T0, T1>>(call, parameters).CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class ActionMethod<T, T0, T1, T2>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Action<T, T0, T1, T2>> Methods =
			new Dictionary<string, Action<T, T0, T1, T2>>();

		private static readonly Dictionary<string, Action<T0, T1, T2>> StaticMethods =
			new Dictionary<string, Action<T0, T1, T2>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2);
		}

		public static Action<T, T0, T1, T2> Get(string name)
		{
			if (Methods.TryGetValue(name, out var action)) return action;
			var args = new[] {TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			action = Expression.Lambda<Action<T, T0, T1, T2>>(call, new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2);
		}

		public static Action<T0, T1, T2> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
			var args = new[] {TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			action = Expression.Lambda<Action<T0, T1, T2>>(call, parameters).CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class ActionMethod<T, T0, T1, T2, T3>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Action<T, T0, T1, T2, T3>> Methods =
			new Dictionary<string, Action<T, T0, T1, T2, T3>>();

		private static readonly Dictionary<string, Action<T0, T1, T2, T3>> StaticMethods =
			new Dictionary<string, Action<T0, T1, T2, T3>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3);
		}

		public static Action<T, T0, T1, T2, T3> Get(string name)
		{
			if (Methods.TryGetValue(name, out var action)) return action;
			var args = new[] {TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			action = Expression.Lambda<Action<T, T0, T1, T2, T3>>(call, new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3);
		}

		public static Action<T0, T1, T2, T3> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
			var args = new[] {TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			action = Expression.Lambda<Action<T0, T1, T2, T3>>(call, parameters).CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class ActionMethod<T, T0, T1, T2, T3, T4>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Action<T, T0, T1, T2, T3, T4>> Methods =
			new Dictionary<string, Action<T, T0, T1, T2, T3, T4>>();

		private static readonly Dictionary<string, Action<T0, T1, T2, T3, T4>> StaticMethods =
			new Dictionary<string, Action<T0, T1, T2, T3, T4>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4);
		}

		public static Action<T, T0, T1, T2, T3, T4> Get(string name)
		{
			if (Methods.TryGetValue(name, out var action)) return action;
			var args = new[]
				{TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic,
				null, CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var instance = Expression.Parameter(Type);
			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(instance, method, parameters);
			action = Expression.Lambda<Action<T, T0, T1, T2, T3, T4>>(call, new[] {instance}.ArrayAppend(parameters))
				.CompileFast();
			Methods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4);
		}

		public static Action<T0, T1, T2, T3, T4> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
			var args = new[]
				{TypeInfo<T0>.Type, TypeInfo<T1>.Type, TypeInfo<T2>.Type, TypeInfo<T3>.Type, TypeInfo<T4>.Type};
			var method = Type.GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, null,
				CallingConventions.Any, args, null);
			if (method == null) throw new MissingMethodException($"Type {Type} does not implement method {name}().");

			var parameters = args.Select(Expression.Parameter).ToArray();
			var call = Expression.Call(method, parameters);
			action = Expression.Lambda<Action<T0, T1, T2, T3, T4>>(call, parameters).CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class ActionMethod<T, T0, T1, T2, T3, T4, T5>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5>> Methods =
			new Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5>>();

		private static readonly Dictionary<string, Action<T0, T1, T2, T3, T4, T5>> StaticMethods =
			new Dictionary<string, Action<T0, T1, T2, T3, T4, T5>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5);
		}

		public static Action<T, T0, T1, T2, T3, T4, T5> Get(string name)
		{
			if (Methods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T, T0, T1, T2, T3, T4, T5>>(call, new[] {instance}.ArrayAppend(parameters))
				.CompileFast();
			Methods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5);
		}

		public static Action<T0, T1, T2, T3, T4, T5> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T0, T1, T2, T3, T4, T5>>(call, parameters).CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class ActionMethod<T, T0, T1, T2, T3, T4, T5, T6>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6>> Methods =
			new Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6>>();

		private static readonly Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6>> StaticMethods =
			new Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static Action<T, T0, T1, T2, T3, T4, T5, T6> Get(string name)
		{
			if (Methods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T, T0, T1, T2, T3, T4, T5, T6>>(call, new[] {instance}.ArrayAppend(parameters))
				.CompileFast();
			Methods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static Action<T0, T1, T2, T3, T4, T5, T6> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T0, T1, T2, T3, T4, T5, T6>>(call, parameters).CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class ActionMethod<T, T0, T1, T2, T3, T4, T5, T6, T7>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7>> Methods =
			new Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7>>();

		private static readonly Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7>> StaticMethods =
			new Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static Action<T, T0, T1, T2, T3, T4, T5, T6, T7> Get(string name)
		{
			if (Methods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T, T0, T1, T2, T3, T4, T5, T6, T7>>(call, new[] {instance}.ArrayAppend(parameters))
				.CompileFast();
			Methods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static Action<T0, T1, T2, T3, T4, T5, T6, T7> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T0, T1, T2, T3, T4, T5, T6, T7>>(call, parameters).CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class ActionMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, T8>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8>> Methods =
			new Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8>>();

		private static readonly Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7, T8>> StaticMethods =
			new Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7, T8>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8> Get(string name)
		{
			if (Methods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8>>(call,
				new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static Action<T0, T1, T2, T3, T4, T5, T6, T7, T8> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T0, T1, T2, T3, T4, T5, T6, T7, T8>>(call, parameters).CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class ActionMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>> Methods =
			new Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>();

		private static readonly Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>> StaticMethods =
			new Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> Get(string name)
		{
			if (Methods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>(call,
				new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>>(call, parameters).CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class ActionMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> Methods =
			new Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>();

		private static readonly Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> StaticMethods =
			new Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Get(string name)
		{
			if (Methods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(call,
				new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(call, parameters)
				.CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class ActionMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>
			Methods = new Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>();

		private static readonly Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>
			StaticMethods = new Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Get(string name)
		{
			if (Methods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(call,
				new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(call, parameters)
				.CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class ActionMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>
			Methods = new Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>();

		private static readonly Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>
			StaticMethods = new Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11,
				arg12);
		}

		public static Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Get(string name)
		{
			if (Methods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(call,
				new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(call, parameters)
				.CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class ActionMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly
			Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> Methods =
				new Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>();

		private static readonly Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>
			StaticMethods =
				new Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12,
			in T13 arg13)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11,
				arg12, arg13);
		}

		public static Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Get(string name)
		{
			if (Methods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(call,
				new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12,
			in T13 arg13)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12,
				arg13);
		}

		public static Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
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
			action = Expression
				.Lambda<Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(call, parameters)
				.CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}

	/// <summary>A utility class to allow duck-typed method calls</summary>
	public class ActionMethod<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
	{
		private static readonly Type Type = TypeInfo<T>.Type;

		private static readonly
			Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> Methods =
				new Dictionary<string, Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>();

		private static readonly
			Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> StaticMethods =
				new Dictionary<string, Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>();

		public static void Call(string name, T instance, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12,
			in T13 arg13, in T14 arg14)
		{
			Get(name).Invoke(instance, arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11,
				arg12, arg13, arg14);
		}

		public static Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Get(string name)
		{
			if (Methods.TryGetValue(name, out var action)) return action;
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
			action = Expression.Lambda<Action<T, T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(call,
				new[] {instance}.ArrayAppend(parameters)).CompileFast();
			Methods.Add(name, action);
			return action;
		}

		public static void CallStatic(string name, in T0 arg0, in T1 arg1, in T2 arg2, in T3 arg3, in T4 arg4,
			in T5 arg5, in T6 arg6, in T7 arg7, in T8 arg8, in T9 arg9, in T10 arg10, in T11 arg11, in T12 arg12,
			in T13 arg13, in T14 arg14)
		{
			GetStatic(name).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12,
				arg13, arg14);
		}

		public static Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> GetStatic(string name)
		{
			if (StaticMethods.TryGetValue(name, out var action)) return action;
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
			action = Expression
				.Lambda<Action<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(call, parameters)
				.CompileFast();
			StaticMethods.Add(name, action);
			return action;
		}
	}
}