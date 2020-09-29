using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System;

namespace DotNetCoreUtilities.Miscellaneous
{
	public static class EnumerableExt
	{
		public static IEnumerable<T> ThisOrEmpty<T>(this IEnumerable<T> enumerable)
		{
			return enumerable ?? Array.Empty<T>();
		}

		public static T[] ThisOrEmpty<T>(this T[] en)
		{
			return en ?? Array.Empty<T>();
		}

		/// <returns>An array containing the selected values.</returns>
		/// <summary>Same as LINQ's Select method, but returns an array instead.</summary>
		public static TOut[] ArraySelect<TIn, TOut>(this IReadOnlyList<TIn> list, Func<TIn, TOut> select)
		{
			if ((list?.Count ?? 0) == 0) return Array.Empty<TOut>();

			var arr = new TOut[list.Count];
			for (var i = 0; i < arr.Length; i++)
				arr[i] = select(list[i]);
			return arr;
		}

		/// <returns>An array containing the selected values.</returns>
		/// <summary>Same as LINQ's Select method, but returns an array instead.</summary>
		public static TOut[] ArraySelect<TIn, TOut>(this Span<TIn> span, Func<TIn, TOut> select)
		{
			if (span.Length == 0) return Array.Empty<TOut>();

			var arr = new TOut[span.Length];
			for (var i = 0; i < arr.Length; i++)
				arr[i] = select(span[i]);

			return arr;
		}

		/// <param name="source">The source list.</param>
		/// <param name="select">The selection criteria.</param>
		/// <param name="destination">The destination list.</param>
		/// <param name="offset">Where to start from when inserting the elements into the destination list.</param>
		/// <summary>Similar to LINQ's select, but it places the results into the provided destination list.</summary>
		/// <exception cref="IndexOutOfRangeException">Receiving list must be at least as big as the source list + offset.</exception>
		public static void InPlaceSelect<TIn, TOut>(this IReadOnlyList<TIn> source, IList<TOut> destination,
			Func<TIn, TOut> select, int offset = 0)
		{
			if (source.Count > destination.Count - offset)
				throw new IndexOutOfRangeException("Receiving list is too small.");

			for (var i = offset; i < source.Count + offset; i++)
				destination[i] = select(source[i]);
		}

		/// <param name="source">The source span.</param>
		/// <param name="select">The selection criteria.</param>
		/// <param name="destination">The destination span.</param>
		/// <param name="offset">Where to start from when inserting the elements into the destination span.</param>
		/// <summary>Similar to LINQ's select, but it places the results into the provided destination span.</summary>
		/// <exception cref="IndexOutOfRangeException">The destination span must be at least as big as the source span + offset.</exception>
		public static void InPlaceSelect<TIn, TOut>(this Span<TIn> source, Span<TOut> destination,
			Func<TIn, TOut> select, int offset = 0)
		{
			if (source.Length > destination.Length - offset)
				throw new IndexOutOfRangeException("Destination span is too small.");

			for (var i = offset; i < source.Length + offset; i++)
				destination[i] = select(source[i]);
		}

        /// <exception cref="InvalidOperationException">The second list must at least be as long as the first one.</exception>
        /// <summary>Similar to LINQ's select, but return a list of pairs containing the selected value,plus the corresponding value in the second list.</summary>
        public static IReadOnlyList<(TIn0, TIn1)> DoubleSelect<TIn0, TIn1>
			(this IReadOnlyList<TIn0> list0, IReadOnlyList<TIn1> list1, Func<TIn0, bool> select)
		{
			if (list0.Count > list1.Count)
				throw new
					InvalidOperationException("Second enumerable must be at least as large as the first one");

			var list = new List<(TIn0, TIn1)>(list0.Count);
			for (var i = 0; i < list0.Count; i++)
				if (select(list0[i]))
					list.Add((list0[i], list1[i]));

			return list;
		}

		public static T[] ArrayAppend<T>([NotNull] this IReadOnlyList<T> list, [NotNull] IReadOnlyList<T> append)
		{
			var arr = new T[list.Count + append.Count];
			for (var i = 0; i < list.Count; i++) arr[i] = list[i];
			for (var i = list.Count; i < list.Count + append.Count; i++) arr[i] = append[i - list.Count];
			return arr;
		}

		/// <summary>Similar to LINQ's SequenceEqual, but only compares a limited portion of the input list.</summary>
		public static bool IncompleteSequenceEqual<T>(this IReadOnlyList<T> list, IReadOnlyList<T> comp)
		{
			if (comp.Count < list.Count) return false;

			for (var i = 0; i < list.Count; i++)
				if (!list[i].Equals(comp[i]))
					return false;

			return true;
		}
	}
}