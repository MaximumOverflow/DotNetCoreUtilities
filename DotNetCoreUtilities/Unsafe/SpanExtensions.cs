using System.Runtime.CompilerServices;
using System;

namespace DotNetCoreUtilities.Unsafe
{
	public static class Unmanaged
	{
		/// <returns><![CDATA[A Span<byte> representation of T]]></returns>
		/// <summary><![CDATA[Returns a Span<byte> representation of an unmanaged type]]></summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static unsafe Span<byte> GetBytes<T>(this ref T obj) where T : unmanaged
		{
			fixed (T* ptr = &obj) return new Span<byte>(ptr, sizeof(T));
		}

		/// <returns>A pointer to the first element of the provided Span</returns>
		/// <summary>Gets a pointer to the first element of an unmanaged Span</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static unsafe T* GetPtr<T>(this Span<T> span) where T : unmanaged
		{
			fixed (T* ptr = &span[0]) return ptr;
		}

		/// <returns><![CDATA[A Span<T> representation of T]]></returns>
		/// <summary><![CDATA[Returns a Span<T> representation of an unmanaged type]]></summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static unsafe Span<T> AsSpan<T>(this ref T obj) where T : unmanaged
		{
			fixed (T* ptr = &obj) return new Span<T>(ptr, 1);
		}

		/// <returns><![CDATA[A Span<TOut>]]></returns>
		/// <summary><![CDATA[Reinterprets a Span<TIn> as a Span<TOut>]]></summary>
		/// <exception cref="InvalidOperationException">The two spans must be correctly aligned</exception>
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static unsafe Span<TOut> AsSpanOf<TOut, TIn>(this ref Span<TIn> span)
			where TIn : unmanaged
			where TOut : unmanaged
		{
			var typeSize = sizeof(TOut);
			var bytes = sizeof(TIn) * span.Length;

			var alignment = bytes % typeSize;
			if (alignment != 0)
				throw new InvalidOperationException(
					$"Span size misaligned with Span<{typeof(TOut).Name}> by {typeSize - alignment} bytes.");

			fixed (TIn* ptr = span) return new Span<TOut>(ptr, bytes / typeSize);
		}
	}
}