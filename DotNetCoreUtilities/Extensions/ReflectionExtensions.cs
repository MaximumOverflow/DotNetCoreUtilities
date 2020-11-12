using System.Reflection;
using System;

namespace DotNetCoreUtilities.Extensions
{
	public static class ReflectionExtensions
	{
		public static TD CreateDelegate<TD>(this MethodInfo methodInfo) where TD : Delegate
			=> (TD) methodInfo.CreateDelegate(TypeInfo<TD>.Type);
	}
}