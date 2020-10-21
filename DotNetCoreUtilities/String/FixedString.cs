#pragma warning disable 649
using System.Runtime.CompilerServices;
using DotNetCoreUtilities.Unsafe;
using System.Collections.Generic;
using System.Collections;
using System;

namespace DotNetCoreUtilities.String
{
	public unsafe struct String32 : IEnumerable<char>
	{
		public const int Capacity = 32;
		public const int ByteSize = sizeof(char) * Capacity;
		
		private fixed char _buffer[Capacity];
		public int Length { get; private set; }

		public String32(string str) : this(str.AsSpan(0)) {}

		public String32(ReadOnlySpan<char> span)
		{
			if(span.Length > Capacity)
				throw new InvalidOperationException("String would exceed the buffer's size.");

			Length = span.Length;
			
			fixed(char* src = &span[0])
			fixed(char* buffer = _buffer)
				System.Buffer.MemoryCopy(src, buffer, ByteSize, sizeof(char)*Length);
		}

		public char* Buffer
		{
			get
			{
				fixed (char* buffer = _buffer)
					return buffer;
			}
		}

		public ref char this[int index]
		{
			get
			{
				if(index < 0 || index >= Capacity)
					throw new IndexOutOfRangeException();

				return ref _buffer[index];
			}
		}

		public void Append(in String32 str) => InPlaceConcat(ref this, str);

		public override string ToString()
		{
			fixed (char* buffer = _buffer)
				return new string(buffer);
		}
		
		public Span<char> AsSpan() => new Span<char>(Buffer, Length);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public IEnumerator<char> GetEnumerator() => new PtrEnumerator<char>(Buffer, Length);

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static String32 Concat(in String32 a, in String32 b)
		{
			if(a.Length + b.Length > Capacity)
				throw new InvalidOperationException("Concatenation of strings would exceed the buffer's size.");

			var str = new String32 {Length = a.Length + b.Length};

			fixed (char* aBuf = a._buffer)
			fixed (char* bBuf = b._buffer)
			{
				var aSize = sizeof(char) * a.Length;
				System.Buffer.MemoryCopy(aBuf, str._buffer, ByteSize, aSize);
				System.Buffer.MemoryCopy(bBuf, str._buffer + a.Length, ByteSize - aSize, sizeof(char) * b.Length);
			}

			return str;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static void InPlaceConcat(ref String32 a, in String32 b)
		{
			if(a.Length + b.Length > Capacity)
				throw new InvalidOperationException("Concatenation of strings would exceed the buffer's size.");
			
			fixed (char* aBuf = a._buffer)
			fixed (char* bBuf = b._buffer)
				System.Buffer.MemoryCopy(bBuf, aBuf + a.Length, ByteSize, sizeof(char) * b.Length);

			a.Length += b.Length;
		}

		public static String32 Repeat<T>(in T obj, int count)
		{
			String32 str = obj.ToString();
			var length = str.Length * count;
			var res = new String32{Length = length};
			var bytes = str.Length * sizeof(char);
		
			if (count < 0) throw new InvalidOperationException("Repetition count must be >= 0");
			if (length > Capacity) throw new InvalidOperationException("Repetition of string would exceed the buffer's size.");

			for (var i = 0; i < count; i++)
				System.Buffer.MemoryCopy(str._buffer, res._buffer + i * str.Length, ByteSize, bytes);

			return res;
		}

		public static implicit operator String32(in string str) => new String32(str);
		public static implicit operator String32(in Span<char> span) => new String32(span);
		public static String32 operator +(in String32 a, in String32 b) => Concat(a, b);

		public static implicit operator String64(String32 str) => new String64(str.AsSpan());
		public static implicit operator String128(String32 str) => new String128(str.AsSpan());
		public static implicit operator String256(String32 str) => new String256(str.AsSpan());
		public static implicit operator String512(String32 str) => new String512(str.AsSpan());
	}
	
	public unsafe struct String64 : IEnumerable<char>
	{
		public const int Capacity = 64;
		public const int ByteSize = sizeof(char) * Capacity;
		
		private fixed char _buffer[Capacity];
		public int Length { get; private set; }

		public String64(string str) : this(str.AsSpan(0)) {}
		
		public String64(ReadOnlySpan<char> span)
		{
			if(span.Length > Capacity)
				throw new InvalidOperationException("String would exceed the buffer's size.");

			Length = span.Length;
			
			fixed(char* src = &span[0])
			fixed(char* buffer = _buffer)
				System.Buffer.MemoryCopy(src, buffer, ByteSize, sizeof(char)*Length);
		}
		
		public char* Buffer
		{
			get
			{
				fixed (char* buffer = _buffer)
					return buffer;
			}
		}

		public ref char this[int index]
		{
			get
			{
				if(index < 0 || index >= Capacity)
					throw new IndexOutOfRangeException();

				return ref _buffer[index];
			}
		}

		public void Append(in String64 str) => InPlaceConcat(ref this, str);

		public override string ToString()
		{
			fixed (char* buffer = _buffer)
				return new string(buffer);
		}
		
		public Span<char> AsSpan() => new Span<char>(Buffer, Length);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public IEnumerator<char> GetEnumerator() => new PtrEnumerator<char>(Buffer, Length);

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static String64 Concat(in String64 a, in String64 b)
		{
			if(a.Length + b.Length > Capacity)
				throw new InvalidOperationException("Concatenation of strings would exceed the buffer's size.");

			var str = new String64 {Length = a.Length + b.Length};

			fixed (char* aBuf = a._buffer)
			fixed (char* bBuf = b._buffer)
			{
				var aSize = sizeof(char) * a.Length;
				System.Buffer.MemoryCopy(aBuf, str._buffer, ByteSize, aSize);
				System.Buffer.MemoryCopy(bBuf, str._buffer + a.Length, ByteSize - aSize, sizeof(char) * b.Length);
			}

			return str;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static void InPlaceConcat(ref String64 a, in String64 b)
		{
			if(a.Length + b.Length > Capacity)
				throw new InvalidOperationException("Concatenation of strings would exceed the buffer's size.");
			
			fixed (char* aBuf = a._buffer)
			fixed (char* bBuf = b._buffer)
				System.Buffer.MemoryCopy(bBuf, aBuf + a.Length, ByteSize, sizeof(char) * b.Length);

			a.Length += b.Length;
		}

		public static String64 Repeat<T>(in T obj, int count)
		{
			String64 str = obj.ToString();
			var length = str.Length * count;
			var res = new String64{Length = length};
			var bytes = str.Length * sizeof(char);
		
			if (count < 0) throw new InvalidOperationException("Repetition count must be >= 0");
			if (length > Capacity) throw new InvalidOperationException("Repetition of string would exceed the buffer's size.");

			for (var i = 0; i < count; i++)
				System.Buffer.MemoryCopy(str._buffer, res._buffer + i * str.Length, ByteSize, bytes);

			return res;
		}

		public static implicit operator String64(in string str) => new String64(str);
		public static String64 operator +(in String64 a, in String64 b) => Concat(a, b);
		
		public static implicit operator String128(String64 str) => new String128(str.AsSpan());
		public static implicit operator String256(String64 str) => new String256(str.AsSpan());
		public static implicit operator String512(String64 str) => new String512(str.AsSpan());
	}
	
	public unsafe struct String128 : IEnumerable<char>
	{
		public const int Capacity = 128;
		public const int ByteSize = sizeof(char) * Capacity;
		
		private fixed char _buffer[Capacity];
		public int Length { get; private set; }

		public String128(string str) : this(str.AsSpan(0)) {}
		
		public String128(ReadOnlySpan<char> span)
		{
			if(span.Length > Capacity)
				throw new InvalidOperationException("String would exceed the buffer's size.");

			Length = span.Length;
			
			fixed(char* src = &span[0])
			fixed(char* buffer = _buffer)
				System.Buffer.MemoryCopy(src, buffer, ByteSize, sizeof(char)*Length);
		}
		
		public char* Buffer
		{
			get
			{
				fixed (char* buffer = _buffer)
					return buffer;
			}
		}

		public ref char this[int index]
		{
			get
			{
				if(index < 0 || index >= Capacity)
					throw new IndexOutOfRangeException();

				return ref _buffer[index];
			}
		}

		public void Append(in String128 str) => InPlaceConcat(ref this, str);

		public override string ToString()
		{
			fixed (char* buffer = _buffer)
				return new string(buffer);
		}
		
		public Span<char> AsSpan() => new Span<char>(Buffer, Length);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public IEnumerator<char> GetEnumerator() => new PtrEnumerator<char>(Buffer, Length);

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static String128 Concat(in String128 a, in String128 b)
		{
			if(a.Length + b.Length > Capacity)
				throw new InvalidOperationException("Concatenation of strings would exceed the buffer's size.");

			var str = new String128 {Length = a.Length + b.Length};

			fixed (char* aBuf = a._buffer)
			fixed (char* bBuf = b._buffer)
			{
				var aSize = sizeof(char) * a.Length;
				System.Buffer.MemoryCopy(aBuf, str._buffer, ByteSize, aSize);
				System.Buffer.MemoryCopy(bBuf, str._buffer + a.Length, ByteSize - aSize, sizeof(char) * b.Length);
			}

			return str;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static void InPlaceConcat(ref String128 a, in String128 b)
		{
			if(a.Length + b.Length > Capacity)
				throw new InvalidOperationException("Concatenation of strings would exceed the buffer's size.");
			
			fixed (char* aBuf = a._buffer)
			fixed (char* bBuf = b._buffer)
				System.Buffer.MemoryCopy(bBuf, aBuf + a.Length, ByteSize, sizeof(char) * b.Length);

			a.Length += b.Length;
		}

		public static String128 Repeat<T>(in T obj, int count)
		{
			String128 str = obj.ToString();
			var length = str.Length * count;
			var res = new String128{Length = length};
			var bytes = str.Length * sizeof(char);
		
			if (count < 0) throw new InvalidOperationException("Repetition count must be >= 0");
			if (length > Capacity) throw new InvalidOperationException("Repetition of string would exceed the buffer's size.");

			for (var i = 0; i < count; i++)
				System.Buffer.MemoryCopy(str._buffer, res._buffer + i * str.Length, ByteSize, bytes);

			return res;
		}

		public static implicit operator String128(in string str) => new String128(str);
		public static String128 operator +(in String128 a, in String128 b) => Concat(a, b);
		
		public static implicit operator String256(String128 str) => new String256(str.AsSpan());
		public static implicit operator String512(String128 str) => new String512(str.AsSpan());
	}
	
	public unsafe struct String256 : IEnumerable<char>
	{
		public const int Capacity = 256;
		public const int ByteSize = sizeof(char) * Capacity;
		
		private fixed char _buffer[Capacity];
		public int Length { get; private set; }

		public String256(string str) : this(str.AsSpan(0)) {}
		
		public String256(ReadOnlySpan<char> span)
		{
			if(span.Length > Capacity)
				throw new InvalidOperationException("String would exceed the buffer's size.");

			Length = span.Length;
			
			fixed(char* src = &span[0])
			fixed(char* buffer = _buffer)
				System.Buffer.MemoryCopy(src, buffer, ByteSize, sizeof(char)*Length);
		}
		
		public char* Buffer
		{
			get
			{
				fixed (char* buffer = _buffer)
					return buffer;
			}
		}

		public ref char this[int index]
		{
			get
			{
				if(index < 0 || index >= Capacity)
					throw new IndexOutOfRangeException();

				return ref _buffer[index];
			}
		}

		public void Append(in String256 str) => InPlaceConcat(ref this, str);

		public override string ToString()
		{
			fixed (char* buffer = _buffer)
				return new string(buffer);
		}
		
		public Span<char> AsSpan() => new Span<char>(Buffer, Length);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public IEnumerator<char> GetEnumerator() => new PtrEnumerator<char>(Buffer, Length);

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static String256 Concat(in String256 a, in String256 b)
		{
			if(a.Length + b.Length > Capacity)
				throw new InvalidOperationException("Concatenation of strings would exceed the buffer's size.");

			var str = new String256 {Length = a.Length + b.Length};

			fixed (char* aBuf = a._buffer)
			fixed (char* bBuf = b._buffer)
			{
				var aSize = sizeof(char) * a.Length;
				System.Buffer.MemoryCopy(aBuf, str._buffer, ByteSize, aSize);
				System.Buffer.MemoryCopy(bBuf, str._buffer + a.Length, ByteSize - aSize, sizeof(char) * b.Length);
			}

			return str;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static void InPlaceConcat(ref String256 a, in String256 b)
		{
			if(a.Length + b.Length > Capacity)
				throw new InvalidOperationException("Concatenation of strings would exceed the buffer's size.");
			
			fixed (char* aBuf = a._buffer)
			fixed (char* bBuf = b._buffer)
				System.Buffer.MemoryCopy(bBuf, aBuf + a.Length, ByteSize, sizeof(char) * b.Length);

			a.Length += b.Length;
		}

		public static String256 Repeat<T>(in T obj, int count)
		{
			String256 str = obj.ToString();
			var length = str.Length * count;
			var res = new String256{Length = length};
			var bytes = str.Length * sizeof(char);
		
			if (count < 0) throw new InvalidOperationException("Repetition count must be >= 0");
			if (length > Capacity) throw new InvalidOperationException("Repetition of string would exceed the buffer's size.");

			for (var i = 0; i < count; i++)
				System.Buffer.MemoryCopy(str._buffer, res._buffer + i * str.Length, ByteSize, bytes);

			return res;
		}

		public static implicit operator String256(in string str) => new String256(str);
		public static String256 operator +(in String256 a, in String256 b) => Concat(a, b);
		
		public static implicit operator String512(String256 str) => new String512(str.AsSpan());
	}
	
	public unsafe struct String512 : IEnumerable<char>
	{
		public const int Capacity = 256;
		public const int ByteSize = sizeof(char) * Capacity;
		
		private fixed char _buffer[Capacity];
		public int Length { get; private set; }

		public String512(string str) : this(str.AsSpan(0)) {}
		
		public String512(ReadOnlySpan<char> span)
		{
			if(span.Length > Capacity)
				throw new InvalidOperationException("String would exceed the buffer's size.");

			Length = span.Length;
			
			fixed(char* src = &span[0])
			fixed(char* buffer = _buffer)
				System.Buffer.MemoryCopy(src, buffer, ByteSize, sizeof(char)*Length);
		}
		
		public char* Buffer
		{
			get
			{
				fixed (char* buffer = _buffer)
					return buffer;
			}
		}

		public ref char this[int index]
		{
			get
			{
				if(index < 0 || index >= Capacity)
					throw new IndexOutOfRangeException();

				return ref _buffer[index];
			}
		}

		public void Append(in String512 str) => InPlaceConcat(ref this, str);

		public override string ToString()
		{
			fixed (char* buffer = _buffer)
				return new string(buffer);
		}
		
		public Span<char> AsSpan() => new Span<char>(Buffer, Length);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public IEnumerator<char> GetEnumerator() => new PtrEnumerator<char>(Buffer, Length);

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static String512 Concat(in String512 a, in String512 b)
		{
			if(a.Length + b.Length > Capacity)
				throw new InvalidOperationException("Concatenation of strings would exceed the buffer's size.");

			var str = new String512 {Length = a.Length + b.Length};

			fixed (char* aBuf = a._buffer)
			fixed (char* bBuf = b._buffer)
			{
				var aSize = sizeof(char) * a.Length;
				System.Buffer.MemoryCopy(aBuf, str._buffer, ByteSize, aSize);
				System.Buffer.MemoryCopy(bBuf, str._buffer + a.Length, ByteSize - aSize, sizeof(char) * b.Length);
			}

			return str;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public static void InPlaceConcat(ref String512 a, in String512 b)
		{
			if(a.Length + b.Length > Capacity)
				throw new InvalidOperationException("Concatenation of strings would exceed the buffer's size.");
			
			fixed (char* aBuf = a._buffer)
			fixed (char* bBuf = b._buffer)
				System.Buffer.MemoryCopy(bBuf, aBuf + a.Length, ByteSize, sizeof(char) * b.Length);

			a.Length += b.Length;
		}

		public static String512 Repeat<T>(in T obj, int count)
		{
			String512 str = obj.ToString();
			var length = str.Length * count;
			var res = new String512{Length = length};
			var bytes = str.Length * sizeof(char);
		
			if (count < 0) throw new InvalidOperationException("Repetition count must be >= 0");
			if (length > Capacity) throw new InvalidOperationException("Repetition of string would exceed the buffer's size.");

			for (var i = 0; i < count; i++)
				System.Buffer.MemoryCopy(str._buffer, res._buffer + i * str.Length, ByteSize, bytes);

			return res;
		}

		public static implicit operator String512(in string str) => new String512(str);
		public static String512 operator +(in String512 a, in String512 b) => Concat(a, b);
	}
}