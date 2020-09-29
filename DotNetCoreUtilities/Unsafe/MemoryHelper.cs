using System;

namespace DotNetCoreUtilities.Unsafe
{
	public static unsafe class MemoryHelper
	{
		private static readonly PlatformID PlatformId = Environment.OSVersion.Platform;

		public static int UnmapMemory(void* addr, ulong length)
		{
			return PlatformId switch
			{
				PlatformID.Unix => UnixMemoryHelper.UnmapMemory(addr, length),
				_ => throw new NotImplementedException()
			};
		}

		public static int SetMemoryProtection(void* addr, ulong len, int prot)
		{
			return PlatformId switch
			{
				PlatformID.Unix => UnixMemoryHelper.SetMemoryProtection(addr, len, prot),
				_ => throw new NotImplementedException()
			};
		}

		public static void* MapMemory(void* addr, ulong length, int prot, int flags, int fd, ulong offset)
		{
			return PlatformId switch
			{
				PlatformID.Unix => UnixMemoryHelper.MapMemory(addr, length, prot, flags, fd, offset),
				_ => throw new NotImplementedException()
			};
		}

		public static void MemSet(byte* buffer, byte value, int size, int offset = 0)
		{
			for (var i = offset; i < size; i++) *(buffer + i) = value;
		}
	}
}