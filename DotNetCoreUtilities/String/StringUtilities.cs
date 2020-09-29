using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreUtilities.String
{
	public static class StringUtilities
	{
		public static string Generate<TS, TD, TE>(TS str, TD separator, IReadOnlyList<TE> elements, Func<TE, TS, string> format)
		{
			var builder = new StringBuilder();

			for (var i = 0; i < elements.Count; i++)
			{
				builder.Append(format(elements[i], str));
				if (i < elements.Count - 1) builder.Append(separator);
			}

			return builder.ToString();
		}

		public static string Generate<TS, TE, TD, TA>(TS str, TD separator, IReadOnlyList<TE> elements, TA preceding, TA succeeding, Func<TE, TS, string> delta)
			=> $"{preceding}{Generate(str, separator, elements, delta)}{succeeding}";

		public static string Join<T>(string separator, Span<T> elements)
		{
			var builder = new StringBuilder();
			for (var i = 0; i < elements.Length; i++)
			{
				builder.Append(elements[i]);
				if (i < elements.Length - 1) builder.Append(separator);
			}

			return builder.ToString();
		}
	}
}