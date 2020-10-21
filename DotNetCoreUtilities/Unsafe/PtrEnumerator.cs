using System.Collections.Generic;
using System.Collections;

namespace DotNetCoreUtilities.Unsafe
{
	public unsafe struct PtrEnumerator<T> : IEnumerator<T> where T : unmanaged
	{
		private readonly T* _buffer;
		private readonly int _size;
		private int _index;

		public PtrEnumerator(T* buffer, int size)
		{
			_buffer = buffer;
			_size = size;
			_index = -1;
		}

		public bool MoveNext()
		{
			_index++;
			return _index < _size;
		}

		public void Reset() => _index = -1;

		public T Current => _buffer[_index];

		object IEnumerator.Current => Current;

		public void Dispose() {}
	}
}