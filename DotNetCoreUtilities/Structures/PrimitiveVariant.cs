using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DotNetCoreUtilities.Unsafe;
using System;

namespace DotNetCoreUtilities.Structures
{
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct PrimitiveVariant
	{
		[FieldOffset(0)] private readonly int _type;
		[FieldOffset(sizeof(int))] private readonly int _vInt;
		[FieldOffset(sizeof(int))] private readonly uint _vUInt;
		[FieldOffset(sizeof(int))] private readonly char _vChar;
		[FieldOffset(sizeof(int))] private readonly byte _vByte;
		[FieldOffset(sizeof(int))] private readonly long _vLong;
		[FieldOffset(sizeof(int))] private readonly ulong _vULong;
		[FieldOffset(sizeof(int))] private readonly sbyte _vSByte;
		[FieldOffset(sizeof(int))] private readonly float _vFloat;
		[FieldOffset(sizeof(int))] private readonly short _vShort;
		[FieldOffset(sizeof(int))] private readonly ushort _vUShort;
		[FieldOffset(sizeof(int))] private readonly double _vDouble;

		public PrimitiveVariant(int value) : this() => (_type, _vInt) = (TypeInfo<int>.Hash, value);
		public PrimitiveVariant(uint value) : this() => (_type, _vUInt) = (TypeInfo<uint>.Hash, value);
		public PrimitiveVariant(char value) : this() => (_type, _vChar) = (TypeInfo<char>.Hash, value);
		public PrimitiveVariant(byte value) : this() => (_type, _vByte) = (TypeInfo<byte>.Hash, value);
		public PrimitiveVariant(long value) : this() => (_type, _vLong) = (TypeInfo<long>.Hash, value);
		public PrimitiveVariant(ulong value) : this() => (_type, _vULong) = (TypeInfo<ulong>.Hash, value);
		public PrimitiveVariant(sbyte value) : this() => (_type, _vSByte) = (TypeInfo<sbyte>.Hash, value);
		public PrimitiveVariant(float value) : this() => (_type, _vFloat) = (TypeInfo<float>.Hash, value);
		public PrimitiveVariant(short value) : this() => (_type, _vShort) = (TypeInfo<short>.Hash, value);
		public PrimitiveVariant(ushort value) : this() => (_type, _vUShort) = (TypeInfo<ushort>.Hash, value);
		public PrimitiveVariant(double value) : this() => (_type, _vDouble) = (TypeInfo<double>.Hash, value);

		public static implicit operator PrimitiveVariant(int value) => new PrimitiveVariant(value);
		public static implicit operator PrimitiveVariant(uint value) => new PrimitiveVariant(value);
		public static implicit operator PrimitiveVariant(char value) => new PrimitiveVariant(value);
		public static implicit operator PrimitiveVariant(byte value) => new PrimitiveVariant(value);
		public static implicit operator PrimitiveVariant(long value) => new PrimitiveVariant(value);
		public static implicit operator PrimitiveVariant(ulong value) => new PrimitiveVariant(value);
		public static implicit operator PrimitiveVariant(sbyte value) => new PrimitiveVariant(value);
		public static implicit operator PrimitiveVariant(float value) => new PrimitiveVariant(value);
		public static implicit operator PrimitiveVariant(short value) => new PrimitiveVariant(value);
		public static implicit operator PrimitiveVariant(ushort value) => new PrimitiveVariant(value);
		public static implicit operator PrimitiveVariant(double value) => new PrimitiveVariant(value);

		public static implicit operator int(PrimitiveVariant variant)
		{
			if (variant._type != TypeInfo<int>.Hash) throw new InvalidOperationException("Value is not of type int");
			return variant._vInt;
		}
		
		public static implicit operator uint(PrimitiveVariant variant)
		{
			if (variant._type != TypeInfo<uint>.Hash) throw new InvalidOperationException("Value is not of type uint");
			return variant._vUInt;
		}
		
		public static implicit operator char(PrimitiveVariant variant)
		{
			if (variant._type != TypeInfo<char>.Hash) throw new InvalidOperationException("Value is not of type char");
			return variant._vChar;
		}
		
		public static implicit operator byte(PrimitiveVariant variant)
		{
			if (variant._type != TypeInfo<byte>.Hash) throw new InvalidOperationException("Value is not of type byte");
			return variant._vByte;
		}
		
		public static implicit operator sbyte(PrimitiveVariant variant)
		{
			if (variant._type != TypeInfo<sbyte>.Hash) throw new InvalidOperationException("Value is not of type sbyte");
			return variant._vSByte;
		}
		
		public static implicit operator short(PrimitiveVariant variant)
		{
			if (variant._type != TypeInfo<short>.Hash) throw new InvalidOperationException("Value is not of type short");
			return variant._vShort;
		}
		
		public static implicit operator ushort(PrimitiveVariant variant)
		{
			if (variant._type != TypeInfo<ushort>.Hash) throw new InvalidOperationException("Value is not of type ushort");
			return variant._vUShort;
		}
		
		public static implicit operator float(PrimitiveVariant variant)
		{
			if (variant._type != TypeInfo<float>.Hash) throw new InvalidOperationException("Value is not of type float");
			return variant._vFloat;
		}
		
		public static implicit operator double(PrimitiveVariant variant)
		{
			if (variant._type != TypeInfo<double>.Hash) throw new InvalidOperationException("Value is not of type double");
			return variant._vDouble;
		}
		
		public static implicit operator long(PrimitiveVariant variant)
		{
			if (variant._type != TypeInfo<long>.Hash) throw new InvalidOperationException("Value is not of type long");
			return variant._vLong;
		}
		
		public static implicit operator ulong(PrimitiveVariant variant)
		{
			if (variant._type != TypeInfo<ulong>.Hash) throw new InvalidOperationException("Value is not of type ulong");
			return variant._vULong;
		}
	}
	
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct UnsafePrimitiveVariant
	{
		[FieldOffset(0)] private readonly int _vInt;
		[FieldOffset(0)] private readonly uint _vUInt;
		[FieldOffset(0)] private readonly char _vChar;
		[FieldOffset(0)] private readonly byte _vByte;
		[FieldOffset(0)] private readonly long _vLong;
		[FieldOffset(0)] private readonly ulong _vULong;
		[FieldOffset(0)] private readonly sbyte _vSByte;
		[FieldOffset(0)] private readonly float _vFloat;
		[FieldOffset(0)] private readonly short _vShort;
		[FieldOffset(0)] private readonly ushort _vUShort;
		[FieldOffset(0)] private readonly double _vDouble;

		public UnsafePrimitiveVariant(int value) : this() => _vInt = value;
		public UnsafePrimitiveVariant(uint value) : this() => _vUInt = value;
		public UnsafePrimitiveVariant(char value) : this() => _vChar = value;
		public UnsafePrimitiveVariant(byte value) : this() => _vByte = value;
		public UnsafePrimitiveVariant(long value) : this() => _vLong = value;
		public UnsafePrimitiveVariant(ulong value) : this() => _vULong = value;
		public UnsafePrimitiveVariant(sbyte value) : this() => _vSByte = value;
		public UnsafePrimitiveVariant(float value) : this() => _vFloat = value;
		public UnsafePrimitiveVariant(short value) : this() => _vShort = value;
		public UnsafePrimitiveVariant(ushort value) : this() => _vUShort = value;
		public UnsafePrimitiveVariant(double value) : this() => _vDouble = value;

		public static UnsafePrimitiveVariant Create<T>(T value) where T : unmanaged
			=> new UnsafePrimitiveVariant(value.Reinterpret<ulong, T>());

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnsafePrimitiveVariant(int value) => new UnsafePrimitiveVariant(value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnsafePrimitiveVariant(uint value) => new UnsafePrimitiveVariant(value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnsafePrimitiveVariant(char value) => new UnsafePrimitiveVariant(value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnsafePrimitiveVariant(byte value) => new UnsafePrimitiveVariant(value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnsafePrimitiveVariant(long value) => new UnsafePrimitiveVariant(value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnsafePrimitiveVariant(ulong value) => new UnsafePrimitiveVariant(value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnsafePrimitiveVariant(sbyte value) => new UnsafePrimitiveVariant(value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnsafePrimitiveVariant(float value) => new UnsafePrimitiveVariant(value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnsafePrimitiveVariant(short value) => new UnsafePrimitiveVariant(value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnsafePrimitiveVariant(ushort value) => new UnsafePrimitiveVariant(value);
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator UnsafePrimitiveVariant(double value) => new UnsafePrimitiveVariant(value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Void(UnsafePrimitiveVariant _) => new Void();
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator int(UnsafePrimitiveVariant variant) => variant._vInt;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator uint(UnsafePrimitiveVariant variant) => variant._vUInt;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator char(UnsafePrimitiveVariant variant) => variant._vChar;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator byte(UnsafePrimitiveVariant variant) => variant._vByte;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator long(UnsafePrimitiveVariant variant) => variant._vLong;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator ulong(UnsafePrimitiveVariant variant) => variant._vULong;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator sbyte(UnsafePrimitiveVariant variant) => variant._vSByte;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator float(UnsafePrimitiveVariant variant) => variant._vFloat;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator short(UnsafePrimitiveVariant variant) => variant._vShort;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator ushort(UnsafePrimitiveVariant variant) => variant._vUShort;
		[MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator double(UnsafePrimitiveVariant variant) => variant._vDouble;
	}
}