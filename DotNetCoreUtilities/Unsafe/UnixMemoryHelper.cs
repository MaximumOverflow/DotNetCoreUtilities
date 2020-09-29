using System;
using System.Runtime.InteropServices;

namespace DotNetCoreUtilities.Unsafe
{
	[Flags]
	public enum UnixMemoryProtection
	{
		None = 0,
		Read = 1,
		Exec = 4,
		Write = 2,
		GrowsUp = 33554432,
		GrowsDown = 16777216
	}

	[Flags]
	public enum UnixMemoryMapFlags
	{
		MapFile = 0,
		MapShared = 1,
		MapPrivate = 2,
		MapSharedValidate = 3,
		MapType = 15,
		MapFixed = 16,
		MapAnonymous = 32,
		MapNoReserve = 16384,
		MapGrowsDown = 256,
		MapDenyWrite = 2048,
		MapExecutable = 4096,
		MapLocked = 8192,
		MapPopulate = 32768,
		MapNonblock = 65536,
		MapStack = 131072,
		MapHugeTlb = 262144,
		MapSync = 524288,
		MapFixedNoReplace = 1048576,
		MapHugeShift = 26,
		MapHugeMask = 63,
		MapHuge64Kb = 1073741824,
		MapHuge512Kb = 1275068416,
		MapHuge1Mb = 1342177280,
		MapHuge2Mb = 1409286144,
		MapHuge8Mb = 1543503872,
		MapHuge16Mb = 1610612736,
		MapHuge32Mb = 1677721600,
		MapHuge256Mb = 1879048192,
		MapHuge512Mb = 1946157056,
		MapHuge1Gb = 2013265920,
		MapHuge2Gb = 2080374784,
		MapHuge16Gb = -2013265920
	}

	public static unsafe class UnixMemoryHelper
	{
		[DllImport("/usr/lib/libc.so.6", EntryPoint = "munmap")]
		public static extern int UnmapMemory(void* addr, ulong length);

		[DllImport("/usr/lib/libc.so.6", EntryPoint = "mprotect")]
		public static extern int SetMemoryProtection(void* addr, ulong len, int prot);

		[DllImport("/usr/lib/libc.so.6", EntryPoint = "mmap")]
		public static extern void* MapMemory(void* addr, ulong length, int prot, int flags, int fd, ulong offset);
	}
}