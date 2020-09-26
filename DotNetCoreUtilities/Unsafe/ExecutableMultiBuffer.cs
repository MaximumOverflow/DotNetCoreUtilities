using System.Collections.Generic;
using System.Linq;
using System;

namespace DotNetCoreUtilities.Unsafe
{
	/// <summary>Represents a set of executable memory blocks. Generally used to contain asm functions.</summary>
	public class ExecutableMultiBuffer : IDisposable
	{
		private const ulong DefaultBufferSize = 4096;
		private readonly List<ExecutableBuffer> _buffers;

		public ExecutableMultiBuffer() => _buffers = new List<ExecutableBuffer> { new ExecutableBuffer(DefaultBufferSize) };

		/// <summary>Creates a callable function delegate from a byte array</summary>
		/// <param name="bytes">The function asm</param>
		/// <typeparam name="T">The function delegate type</typeparam>
		/// <exception cref="OutOfMemoryException"></exception>
		public T PushDelegate<T>(byte[] bytes) where T : Delegate 
		{
			var byteCount = (ulong) bytes.LongLength;
			var buffer = _buffers.FirstOrDefault(b => b.Available >= byteCount);
			
			if (buffer == null)
			{
				buffer = new ExecutableBuffer(Math.Max(byteCount, DefaultBufferSize));
				_buffers.Add(buffer);
			}

			return buffer.PushDelegate<T>(bytes);
		}

		public void Allocate(ulong bytes) => _buffers.Add(new ExecutableBuffer(bytes));
		public ulong LargestAvailableSpan => _buffers.Max(b => b.Available);
		public ulong TotalUsedMemory => (ulong) _buffers.Sum((Func<ExecutableBuffer, decimal>)(b => b.Used));
		public ulong TotalAvailableMemory => (ulong) _buffers.Sum((Func<ExecutableBuffer, decimal>)(b => b.Available));

		public void Dispose() => _buffers.ForEach(b => b.Dispose());
	}
}