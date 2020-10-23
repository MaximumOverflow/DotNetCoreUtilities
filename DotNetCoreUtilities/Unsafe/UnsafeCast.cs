using System.Runtime.CompilerServices;

namespace DotNetCoreUtilities.Unsafe
{
	public static class UnsafeCast
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static unsafe ref TOut Reinterpret<TOut, TIn>(this ref TIn obj) where TIn : unmanaged where TOut : unmanaged
		{
			fixed (TIn* ptr = &obj)
				return ref *(TOut*) ptr;
		}
	}
}