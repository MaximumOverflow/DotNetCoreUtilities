using System.Collections.Generic;
using System.Text;
using System;

namespace DotNetCoreUtilities.String
{
	public static class StringUtilities
	{
		public static string Generate<TS, TD, TE>(TS str, TD delimiter, IReadOnlyList<TE> elements, Func<TE, TS, string> format)
		{
			var builder = new StringBuilder();
			
			for (var i = 0; i < elements.Count; i++)
			{
				builder.Append(format(elements[i], str));
				if (i < elements.Count - 1) builder.Append(delimiter);
			}

			return builder.ToString();
		}

		public static string Generate<TS, TE, TD, TA>(TS str, TD delimiter, IReadOnlyList<TE> elements, TA preceding, TA succeeding, Func<TE, TS, string> delta) 
			=> $"{preceding}{Generate(str, delimiter, elements, delta)}{succeeding}";
	}
}