using DotNetCoreUtilities.CodeGeneration;
using System.Collections.Generic;

namespace DotNetCoreUtilities.Extensions
{
	public static class DictionaryExtensions
	{
		private static class DictionaryHelper<TKey, T>
		{
			public delegate ref T FindValueDelegate(Dictionary<TKey, T> dict, TKey key);
			public static readonly FindValueDelegate FindValue = Method<Dictionary<TKey, T>>.Get<FindValueDelegate>
				("FindValue", TypeInfo<TKey>.Type);
		}
		
		public static unsafe ref T GetByRef<TKey, T>(this Dictionary<TKey, T> dict, TKey key)
		{
			ref var @ref = ref DictionaryHelper<TKey, T>.FindValue(dict, key);
			
			if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref @ref) == null) 
				throw new KeyNotFoundException($"The given key '{key}' was not present in the dictionary");
			
			return ref @ref;
		}
	}
}