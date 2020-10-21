using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Collections;
using System;

namespace DotNetCoreUtilities.Containers
{
	public class FixedStack<T> : IEnumerable<T>
	{
		private readonly T[] _buffer;
		public readonly int Capacity;
		public int Count { get; private set; }

		public FixedStack(int capacity)
		{
			Count = 0;
			Capacity = capacity;
			_buffer = new T[capacity];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public void Push(in T obj)
		{
			if(Count == Capacity) throw new InvalidOperationException("Insertion out of bounds");
			_buffer[Count++] = obj;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public T Pop()
		{
			if(Count == 0) throw new InvalidOperationException("Queue is empty");
			return _buffer[--Count];
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public bool TryPush(in T obj)
		{
			if (Count == Capacity) return false;
			_buffer[Count++] = obj;
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public bool TryPop(out T obj)
		{
			if (Count == 0)
			{
				obj = default;
				return false;
			}

			obj = _buffer[--Count];
			return true;
		}

		public IEnumerator<T> GetEnumerator() => new Enumerator(this);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public class Enumerator : IEnumerator<T>
		{
			private FixedStack<T> _stack;
			private T _current;

			public T Current => _current;


			public Enumerator(FixedStack<T> stack) => _stack = stack;

			object IEnumerator.Current => Current;

			public bool MoveNext() => _stack.TryPop(out _current);

			public void Dispose() {}
			public void Reset() => throw new NotSupportedException();
		}
	}
}