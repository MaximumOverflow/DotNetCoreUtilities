using DotNetCoreUtilities.Unsafe;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;

namespace DotNetCoreUtilities.Miscellaneous
{
	public static class Enum
	{
		private static class EnumHelper<T> where T : System.Enum
		{
			public static readonly Dictionary<string, T> Values;
			public static readonly Type UnderlyingType;

			static EnumHelper()
			{
				var type = TypeInfo<T>.Type;
				Values = new Dictionary<string, T>();
				UnderlyingType = type.GetEnumUnderlyingType();

				var values = (T[]) type.GetEnumValues();
				var names = type.GetEnumNames();
				
				for (var i = 0; i < values.Length; i++)
					Values.Add(names[i], values[i]);
			}
		}
		
		public static T Parse<T>(string str) where T : System.Enum
		{
			if (EnumHelper<T>.Values.TryGetValue(str, out var value))
				return value;
			
			throw new ArgumentException($"Requested value {str} was not found.");
		}
		
		public static T ParseFlags<T>(IEnumerable<string> flagList) where T : unmanaged, System.Enum
		{
			var underlyingType = EnumHelper<T>.UnderlyingType;
			
			if (underlyingType == TypeInfo<int>.Type)
			{
				var flags = 0;
				foreach (var flag in flagList)
				{
					var res = Parse<T>(flag);
					flags |= res.Reinterpret<int, T>();
				}
			
				return flags.Reinterpret<T, int>();
			}
			
			if (underlyingType == TypeInfo<long>.Type)
			{
				var flags = 0L;
				foreach (var flag in flagList)
				{
					var res = Parse<T>(flag);
					flags |= res.Reinterpret<long, T>();
				}
			
				return flags.Reinterpret<T, long>();
			}
			
			if (underlyingType == TypeInfo<short>.Type)
			{
				var flags = (short) 0;
				foreach (var flag in flagList)
				{
					var res = Parse<T>(flag);
					flags |= res.Reinterpret<short, T>();
				}
			
				return flags.Reinterpret<T, short>();
			}
			
			if (underlyingType == TypeInfo<byte>.Type)
			{
				var flags = (byte) 0;
				foreach (var flag in flagList)
				{
					var res = Parse<T>(flag);
					flags |= res.Reinterpret<byte, T>();
				}
			
				return flags.Reinterpret<T, byte>();
			}
			
			if (underlyingType == TypeInfo<sbyte>.Type)
			{
				var flags = (sbyte) 0;
				foreach (var flag in flagList)
				{
					var res = Parse<T>(flag);
					flags |= res.Reinterpret<sbyte, T>();
				}
			
				return flags.Reinterpret<T, sbyte>();
			}
			
			if (underlyingType == TypeInfo<uint>.Type)
			{
				var flags = 0u;
				foreach (var flag in flagList)
				{
					var res = Parse<T>(flag);
					flags |= res.Reinterpret<uint, T>();
				}
			
				return flags.Reinterpret<T, uint>();
			}

			if (underlyingType == TypeInfo<ulong>.Type)
			{
				var flags = 0uL;
				foreach (var flag in flagList)
				{
					var res = Parse<T>(flag);
					flags |= res.Reinterpret<ulong, T>();
				}
			
				return flags.Reinterpret<T, ulong>();
			}

			if (underlyingType == TypeInfo<ushort>.Type)
			{
				var flags = (ushort) 0;
				foreach (var flag in flagList)
				{
					var res = Parse<T>(flag);
					flags |= res.Reinterpret<ushort, T>();
				}
			
				return flags.Reinterpret<T, ushort>();
			}

			throw new NotSupportedException("Unsupported underlying type.");
		}
	}
}