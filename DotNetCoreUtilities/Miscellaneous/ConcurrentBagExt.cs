using DotNetCoreUtilities.CodeGeneration;
using System.Collections.Concurrent;
using System;

namespace DotNetCoreUtilities.Miscellaneous
{
	public static class ConcurrentBagExt
	{
		/// <summary>Attempts to retrieve an instance of T from a concurrent bag, returns a new T if it fails</summary>
		public static T TakeOrCreate<T>(this ConcurrentBag<T> bag) where T : new()
			=> bag.TryTake(out var result) ? result : Constructor<T>.New();

		/// <summary>Attempts to retrieve an instance of T from a concurrent bag, returns a new T using the provided function if it fails</summary>
		public static T TakeOrCreate<T>(this ConcurrentBag<T> bag, Func<T> @new)
			=> bag.TryTake(out var result) ? result : @new();

		/// <summary>Attempts to retrieve an instance of T from a concurrent bag, returns a new T constructed using the provided arguments if it fails</summary>
		public static T TakeOrCreate<T, TArg0>(this ConcurrentBag<T> bag, TArg0 arg0)
			=> bag.TryTake(out var result) ? result : Constructor<T, TArg0>.New(arg0);
		
		/// <summary>Attempts to retrieve an instance of T from a concurrent bag, returns a new T constructed using the provided arguments if it fails</summary>
		public static T TakeOrCreate<T, TArg0, TArg1>(this ConcurrentBag<T> bag, TArg0 arg0, TArg1 arg1)
			=> bag.TryTake(out var result) ? result : Constructor<T, TArg0, TArg1>.New(arg0, arg1);
		
		/// <summary>Attempts to retrieve an instance of T from a concurrent bag, returns a new T constructed using the provided arguments if it fails</summary>
		public static T TakeOrCreate<T, TArg0, TArg1, TArg2>(this ConcurrentBag<T> bag, TArg0 arg0, TArg1 arg1, TArg2 arg2)
			=> bag.TryTake(out var result) ? result : Constructor<T, TArg0, TArg1, TArg2>.New(arg0, arg1, arg2);
	}
}