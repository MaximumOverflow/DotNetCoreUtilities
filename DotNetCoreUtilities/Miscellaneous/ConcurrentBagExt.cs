using System.Collections.Concurrent;
using System;

namespace DotNetCoreUtilities.Miscellaneous
{
	public static class ConcurrentBagExt
	{
		/// <summary>Attempts to retrieve an instance of T from a concurrent bag, returns a new T if it fails</summary>
		public static T TakeOrCreate<T>(this ConcurrentBag<T> bag) where T : new()
		{
			return bag.TryTake(out var result) ? result : new T();
		}

		/// <summary>Attempts to retrieve an instance of T from a concurrent bag, returns a new T using the provided function if it fails</summary>
		public static T TakeOrCreate<T>(this ConcurrentBag<T> bag, Func<T> @new)
		{
			return bag.TryTake(out var result) ? result : @new();
		}
	}
}