using System.Runtime.InteropServices;
using DotNetCoreUtilities.String;
using System.Collections.Generic;
using System.Collections;
using System;

namespace DotNetCoreUtilities.Unsafe
{
	/// <summary>Represents an array of T allocated on the unmanaged heap. Useful for interoperability.</summary>
	public readonly unsafe struct NativeArray<T> : IDisposable, IEnumerable<T> where T : unmanaged
	{
		public readonly int Length;
		private readonly T* _buffer;
		private readonly IntPtr _handle;

		public NativeArray(int length, bool zeroFill = false)
		{
			Length = length;
			_handle = Marshal.AllocHGlobal(sizeof(T) * length);
			_buffer = (T*) _handle;
			if (zeroFill) MemoryHelper.MemSet((byte*) _buffer, 0, Length * sizeof(T));
		}

		public ref T this[int index]
		{
			get
			{
				if (index < 0 || index >= Length)
					throw new IndexOutOfRangeException($"Index out of range [{new Range(0, Length)}].");

				return ref _buffer[index];
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public IEnumerator<T> GetEnumerator() => new Enumerator(_buffer, Length);

		public void Dispose() => Marshal.FreeHGlobal(_handle);

		public override string ToString() 
			=> $"[{StringUtilities.Join<T>(", ", this)}]";

		public static implicit operator Span<T>(in NativeArray<T> arr)
			=> new Span<T>(arr._buffer, arr.Length);


		private class Enumerator : IEnumerator<T>
		{
			private readonly T* _buffer;
			private readonly int _length;
			private int _position;

			public Enumerator(T* buffer, int length)
			{
				_buffer = buffer;
				_length = length;
				_position = 0;
			}

			public T Current => _buffer[_position];
			object IEnumerator.Current => Current;

			public bool MoveNext()
			{
				_position++;
				return _position < _length;
			}

			public void Dispose() {}

			public void Reset() => _position = 0;
		}
	}
}