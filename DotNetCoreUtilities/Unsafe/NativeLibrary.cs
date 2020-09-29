using System.Runtime.InteropServices;
using System;

namespace DotNetCoreUtilities.Unsafe
{
	/// <summary>Represents a dynamically loaded shared library</summary>
	public class NativeLibrary : IDisposable
	{
		public readonly string Path;
		public readonly IntPtr Handle;

		public NativeLibrary(string path)
		{
			Path = path;
			Handle = System.Runtime.InteropServices.NativeLibrary.Load(Path);
			if (Handle == IntPtr.Zero) throw new DllNotFoundException();
		}

		public void Dispose() => System.Runtime.InteropServices.NativeLibrary.Free(Handle);

		/// <summary>Retrieves an exported function from the library</summary>
		/// <param name="name">The name of the exported symbol</param>
		/// <typeparam name="T">The symbol's delegate type</typeparam>
		/// <returns>A delegate bound to the specified exported symbol</returns>
		/// <exception cref="MissingMethodException"></exception>
		public T GetFunction<T>(string name) where T : Delegate
		{
			if (!System.Runtime.InteropServices.NativeLibrary.TryGetExport(Handle, name, out var funcPtr))
				throw new MissingMethodException($"Dynamic library {Path} does not contain an exported symbol named {name}");

			return Marshal.GetDelegateForFunctionPointer<T>(funcPtr);
		}
	}
}