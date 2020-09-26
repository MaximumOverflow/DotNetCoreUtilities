using System.Linq.Expressions;
using FastExpressionCompiler;
using System;

namespace DotNetCoreUtilities.CodeGeneration
{
	public static class Stub
	{
		public static Action CreatePreceding(Action action, Action function)
		{
			var callAction = Expression.Call(action.Method);
			var callFunction = Expression.Call(function.Method);
			return Expression.Lambda<Action>(Expression.Block(callAction, callFunction)).CompileFast();
		}
		
		public static Action CreateSucceeding(Action action, Action function)
		{
			var callAction = Expression.Call(action.Method);
			var callFunction = Expression.Call(function.Method);
			return Expression.Lambda<Action>(Expression.Block(callFunction, callAction)).CompileFast();
		}

		public static Func<T> CreatePreceding<T>(Action action, Func<T> function)
		{
			var callAction = Expression.Call(action.Method);
			var callFunction = Expression.Call(function.Method);
			return Expression.Lambda<Func<T>>(Expression.Block(callAction, callFunction)).CompileFast();
		}
		
		public static Func<T> CreateSucceeding<T>(Action action, Func<T> function)
		{
			var callAction = Expression.Call(action.Method);
			var callFunction = Expression.Call(function.Method);
			return Expression.Lambda<Func<T>>(Expression.Block(callFunction, callAction)).CompileFast();
		}
	}
}