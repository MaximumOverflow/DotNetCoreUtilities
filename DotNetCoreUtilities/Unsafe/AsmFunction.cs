using static DotNetCoreUtilities.Unsafe.MemoryHelper;
using System.Runtime.InteropServices;
using System;

namespace DotNetCoreUtilities.Unsafe
{
	/// <summary>Represents an unmanaged function obtained from a byte array</summary>
	/// <typeparam name="T">The function delegate type</typeparam>
	public unsafe class AsmFunction<T> : IDisposable where T : Delegate 
	{
		private const UnixMemoryMapFlags MmapFlags = UnixMemoryMapFlags.MapAnonymous | UnixMemoryMapFlags.MapPrivate;
		private const UnixMemoryProtection MmapProtection = UnixMemoryProtection.Read | UnixMemoryProtection.Write;
		private const UnixMemoryProtection MprotProtection = UnixMemoryProtection.Read | UnixMemoryProtection.Exec;

		public readonly T Delegate;
		private readonly void* _handle;
		private readonly ulong _bufferSize;

		public AsmFunction(byte[] bytes)
		{
			_bufferSize = (ulong) bytes.Length;
			_handle = MapMemory(null, _bufferSize, (int) MmapProtection, (int) MmapFlags, -1, 0);
			if(_handle == (void*) -1) throw new InvalidOperationException("mmap call failed");
			Marshal.Copy(bytes, 0, new IntPtr(_handle), bytes.Length);
			var res = SetMemoryProtection(_handle, _bufferSize, (int) MprotProtection);
			if(res != 0) throw new InvalidOperationException("mprotect call failed");
			Delegate = Marshal.GetDelegateForFunctionPointer<T>(new IntPtr(_handle));
		}
		
		~AsmFunction() => Dispose();
		public void Dispose() => UnmapMemory(_handle, _bufferSize);
		public static implicit operator T(in AsmFunction<T> fun) => fun.Delegate;
	}
}