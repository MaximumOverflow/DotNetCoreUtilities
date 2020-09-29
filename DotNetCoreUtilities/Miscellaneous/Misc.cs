using System;
using System.Collections.Generic;

namespace DotNetCoreUtilities.Miscellaneous
{
	public static class Misc
	{
		public static T ParseFlags<T>(this IEnumerable<string> flagList) where T : unmanaged, Enum
		{
			var flags = 0;
			var type = typeof(T);
			foreach (var flag in flagList)
				flags |= (int) Enum.Parse(type, flag);

			return (T) (object) flags;
		}

		/// <param name="i">The byte count</param>
		/// <summary>Returns an easily readable representation of a byte count.</summary>
		/// <returns>An easily readable representation of the provided byte count.</returns>
		public static string GetReadableByteCount(this long i)
		{
			var abs = i < 0 ? -i : i;
			string suffix;
			double readable;

			if (abs >= 0x1000000000000000) // Exabyte
			{
				suffix = "EB";
				readable = i >> 50;
			}
			else if (abs >= 0x4000000000000) // Petabyte
			{
				suffix = "PB";
				readable = i >> 40;
			}
			else if (abs >= 0x10000000000) // Terabyte
			{
				suffix = "TB";
				readable = i >> 30;
			}
			else if (abs >= 0x40000000) // Gigabyte
			{
				suffix = "GB";
				readable = i >> 20;
			}
			else if (abs >= 0x100000) // Megabyte
			{
				suffix = "MB";
				readable = i >> 10;
			}
			else if (abs >= 0x400) // Kilobyte
			{
				suffix = "KB";
				readable = i;
			}
			else
			{
				return i.ToString("0 B"); // Byte
			}

			readable = readable / 1024;
			return readable.ToString("0.### ") + suffix;
		}

		public static int GetLength(this in Range range) => Math.Abs(range.End.Value - range.Start.Value);
	}
}