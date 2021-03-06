using System;

namespace DotNetCoreUtilities.Miscellaneous
{
	public static class Int
	{
		public static int Parse(ReadOnlySpan<char> chars)
		{
			if (chars.Length == 0)
				throw new ArgumentException($"Span length must be at least 1.");

			var val = 0;
			var neg = chars[0] == '-';
			for (var i = neg ? 1 : 0; i < chars.Length; i++)
			{
				var c = chars[i];
				if (c < '0' || c > '9') 
					throw new ArgumentException("Sequence contains an invalid character");

				if (c == '0' && val == 0)
					continue;

				checked
				{
					val *= 10;
					val += c - '0';
				}
			}
			return neg ? -val : val;
		}
		
		public static int Parse(string chars)
		{
			if (chars.Length == 0)
				throw new ArgumentException($"Span length must be at least 1.");

			var val = 0;
			var neg = chars[0] == '-';
			for (var i = neg ? 1 : 0; i < chars.Length; i++)
			{
				var c = chars[i];
				if (c < '0' || c > '9') 
					throw new ArgumentException("Sequence contains an invalid character");
				
				if (c == '0' && val == 0)
					continue;

				checked
				{
					val *= 10;
					val += c - '0';
				}
			}
			return neg ? -val : val;
		}
		
		public static int ParseUnchecked(ReadOnlySpan<char> chars)
		{
			if (chars.Length == 0)
				throw new ArgumentException($"Span length must be at least 1.");

			var val = 0;
			var neg = chars[0] == '-';
			for (var i = neg ? 1 : 0; i < chars.Length; i++)
			{
				var c = chars[i];
				if (c < '0' || c > '9') 
					throw new ArgumentException("Sequence contains an invalid character");
					
				if (c == '0' && val == 0)
					continue;

				val *= 10;
				val += c - '0';
			}
			return neg ? -val : val;
		}
		
		public static int ParseUnchecked(string chars)
		{
			if (chars.Length == 0)
				throw new ArgumentException($"Span length must be at least 1.");

			var val = 0;
			var neg = chars[0] == '-';
			for (var i = neg ? 1 : 0; i < chars.Length; i++)
			{
				var c = chars[i];
				if (c < '0' || c > '9') 
					throw new ArgumentException("Sequence contains an invalid character");
				
				if (c == '0' && val == 0)
					continue;

				val *= 10;
				val += c - '0';
			}
			return neg ? -val : val;
		}

		public static bool TryParse(ReadOnlySpan<char> chars, out int value)
		{
			if (chars.Length == 0)
			{
				value = default;
				return false;
			}

			var val = 0;
			var neg = chars[0] == '-';
			try
			{
				for (var i = neg ? 1 : 0; i < chars.Length; i++)
				{
					var c = chars[i];
					if (c < '0' || c > '9') 
					{
						value = default;
						return false;
					}
					
					if (c == '0' && val == 0)
						continue;
				
					val *= 10;
					val += c - '0';
				}
			}
			catch (OverflowException)
			{
				value = default;
				return false;
			}
			
			value = neg ? -val : val;
			return true;
		}
		
		public static bool TryParse(string chars, out int value)
		{
			if (chars.Length == 0)
			{
				value = default;
				return false;
			}

			var val = 0;
			var neg = chars[0] == '-';
			try
			{
				for (var i = neg ? 1 : 0; i < chars.Length; i++)
				{
					var c = chars[i];
					if (c < '0' || c > '9') 
					{
						value = default;
						return false;
					}
					
					if (c == '0' && val == 0)
						continue;
				
					val *= 10;
					val += c - '0';
				}
			}
			catch (OverflowException)
			{
				value = default;
				return false;
			}
			
			value = neg ? -val : val;
			return true;
		}
	}
}