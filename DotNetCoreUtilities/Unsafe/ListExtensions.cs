using DotNetCoreUtilities.CodeGeneration;
using System.Collections.Generic;
using System;

namespace DotNetCoreUtilities.Unsafe
{
	public static class ListExtensions
	{
		private static class ListHelper<T>
		{
			public static readonly Field<List<T>, T[]>.Getter ItemsGetter 
				= Field<List<T>, T[]>.GetGetter("_items");
		}

		public static Span<T> AsSpan<T>(this List<T> list) => ListHelper<T>.ItemsGetter.Invoke(ref list);

		public static unsafe T* GetPtr<T>(this List<T> list) where T : unmanaged
		{
			var array = ListHelper<T>.ItemsGetter.Invoke(ref list);
			fixed (T* ptr = &array[0]) return ptr;
		}
	}
}