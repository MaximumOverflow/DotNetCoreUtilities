using System;
using System.Reflection;

namespace DotNetCoreUtilities.Miscellaneous
{
	public static class ReflectionExtensions
	{
		public static TD CreateDelegate<TD>(this MethodInfo methodInfo) where TD : Delegate
			=> (TD) methodInfo.CreateDelegate(TypeInfo<TD>.Type);
	}
}