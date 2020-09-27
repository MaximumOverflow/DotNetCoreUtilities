using DotNetCoreUtilities.Unsafe;
using System.IO;

namespace DotNetCoreUtilities.Miscellaneous
{
	public static class StreamExt
	{
		public static void Read<T>(this Stream stream, ref T obj) where T : unmanaged => stream.Read(obj.GetBytes());
		public static void Write<T>(this Stream stream, T obj) where T : unmanaged => stream.Write(obj.GetBytes());
		public static void Write<T>(this Stream stream, ref T obj) where T : unmanaged => stream.Write(obj.GetBytes());

		public static T Read<T>(this Stream stream) where T : unmanaged
		{
			var obj = new T();
			stream.Read(obj.GetBytes());
			return obj;
		}
	}
}