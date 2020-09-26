using System;
using System.Collections.Generic;

namespace DotNetCoreUtilities.Miscellaneous
{
    public static class EnumerableExt
    {
        public static IEnumerable<T> ThisOrEmpty<T>(this IEnumerable<T> enumerable)
            => enumerable ?? Array.Empty<T>();
        
        public static T[] ThisOrEmpty<T>(this T[] en)
            => en ?? Array.Empty<T>();

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

        public static TOut[] ArraySelectPrependOne<TIn, TOut>(this IReadOnlyList<TIn> list, Func<TIn, TOut> select, TOut first)
        {
            var arr = new TOut[(list?.Count ?? 0) + 1];
            arr[0] = first;
            for (var i = 1; i < arr.Length; i++)
                arr[i] = select(list[i-1]);
            return arr;
        }
        
        public static TOut[] ArraySelectAppendOne<TIn, TOut>(this IReadOnlyList<TIn> list, Func<TIn, TOut> select, TOut last)
        {
            var arr = new TOut[(list?.Count ?? 0) + 1];
            for (var i = 0; i < arr.Length; i++)
                arr[i] = select(list[i]);

            arr[^1] = last;
            return arr;
        }

        /// <exception cref="InvalidOperationException">The second list must at least be as long as the first one.</exception>
        /// <summary>Similar to LINQ's select, but return a list of pairs containing the selected value,plus the corresponding value in the second list.</summary>
        public static IReadOnlyList<(TIn0, TIn1)> DoubleSelect<TIn0, TIn1>
        (this IReadOnlyList<TIn0> list0, IReadOnlyList<TIn1> list1, Func<TIn0, bool> select)
        {
            if(list0.Count > list1.Count) throw new 
                InvalidOperationException("Second enumerable must be at least as large as the first one");
            
            var list = new List<(TIn0, TIn1)>(list0.Count);
            for (var i = 0; i < list0.Count; i++)
                if(select(list0[i])) list.Add((list0[i], list1[i]));

            return list;
        }

        /// <summary>Similar to LINQ's SequenceEqual, but only compares a limited portion of the input list.</summary>
        public static bool IncompleteSequenceEqual<T>(this IReadOnlyList<T> list, IReadOnlyList<T> comp)
        {
            if (comp.Count < list.Count) return false;
            
            for (var i = 0; i < list.Count; i++)
                if (!list[i].Equals(comp[i])) return false;

            return true;
        }
    }
}