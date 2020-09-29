using static DotNetCoreUtilities.Unsafe.MemoryHelper;
using System.Runtime.InteropServices;
using System;

namespace DotNetCoreUtilities.Unsafe
{
	/// <summary>Represents an executable memory block. Generally used to contain asm functions.</summary>
	public unsafe class ExecutableBuffer : IDisposable
	{
		private const UnixMemoryMapFlags MmapFlags = UnixMemoryMapFlags.MapAnonymous | UnixMemoryMapFlags.MapPrivate;
		private const UnixMemoryProtection MmapProtection = UnixMemoryProtection.Write | UnixMemoryProtection.Exec;
		private readonly ulong _bufferSize;

		private readonly void* _handle;

		public ExecutableBuffer(ulong size)
		{
			_bufferSize = size;
			_handle = MapMemory(null, _bufferSize, (int) MmapProtection, (int) MmapFlags, -1, 0);
			if (_handle == (void*) -1) throw new InvalidOperationException("mmap call failed");
		}

		public ulong Used { get; private set; }
		public ulong Available => _bufferSize - Used;

		public void Dispose() => UnmapMemory(_handle, _bufferSize);

		/// <summary>Creates a callable function delegate from a byte array</summary>
		/// <param name="bytes">The function asm</param>
		/// <typeparam name="T">The function delegate type</typeparam>
		/// <exception cref="OutOfMemoryException"></exception>
		public T PushDelegate<T>(byte[] bytes) where T : Delegate
		{
			var byteCount = (ulong) bytes.LongLength;
			var ptr = (void*) ((byte*) _handle + Used);
			if (Used + byteCount > _bufferSize) throw new OutOfMemoryException();
			Used += byteCount;

			Marshal.Copy(bytes, 0, new IntPtr(ptr), bytes.Length);
			return Marshal.GetDelegateForFunctionPointer<T>(new IntPtr(ptr));
		}

		~ExecutableBuffer() => Dispose();
	}
}