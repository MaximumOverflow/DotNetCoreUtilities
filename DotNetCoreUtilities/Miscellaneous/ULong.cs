using System;

namespace DotNetCoreUtilities.Miscellaneous
{
	public static class ULong
	{
		public static ulong Parse(ReadOnlySpan<char> chars)
		{
			if (chars.Length == 0)
				throw new ArgumentException($"Span length must be at least 1.");

			var val = 0uL;
			for (var i = 0; i < chars.Length; i++)
			{
				var c = chars[i];
				if (c < '0' || c > '9') 
					throw new ArgumentException("Sequence contains an invalid character");

				if (c == '0' && val == 0)
					continue;

				checked
				{
					val *= 10;
					val += (ulong) c - '0';
				}
			}

			return val;
		}
		
		public static ulong Parse(string chars)
		{
			if (chars.Length == 0)
				throw new ArgumentException($"Span length must be at least 1.");

			var val = 0uL;
			for (var i = 0; i < chars.Length; i++)
			{
				var c = chars[i];
				if (c < '0' || c > '9') 
					throw new ArgumentException("Sequence contains an invalid character");

				if (c == '0' && val == 0)
					continue;

				checked
				{
					val *= 10;
					val += (ulong) c - '0';
				}
			}

			return val;
		}
		
		public static ulong ParseUnchecked(ReadOnlySpan<char> chars)
		{
			if (chars.Length == 0)
				throw new ArgumentException($"Span length must be at least 1.");

			var val = 0uL;
			for (var i = 0; i < chars.Length; i++)
			{
				var c = chars[i];
				if (c < '0' || c > '9') 
					throw new ArgumentException("Sequence contains an invalid character");

				if (c == '0' && val == 0)
					continue;

				val *= 10;
				val += (ulong) c - '0';
			}

			return val;
		}
		
		public static ulong ParseUnchecked(string chars)
		{
			if (chars.Length == 0)
				throw new ArgumentException($"Span length must be at least 1.");

			var val = 0uL;
			for (var i = 0; i < chars.Length; i++)
			{
				var c = chars[i];
				if (c < '0' || c > '9') 
					throw new ArgumentException("Sequence contains an invalid character");

				if (c == '0' && val == 0)
					continue;

				val *= 10;
				val += (ulong) c - '0';
			}

			return val;
		}

		public static bool TryParse(ReadOnlySpan<char> chars, out ulong value)
		{
			if (chars.Length == 0)
			{
				value = default;
				return false;
			}

			var val = 0uL;
			try
			{
				for (var i = 0; i < chars.Length; i++)
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
					val += (ulong) c - '0';
				}
			}
			catch (OverflowException)
			{
				value = default;
				return false;
			}

			value = val;
			return true;
		}
		
		public static bool TryParse(string chars, out ulong value)
		{
			if (chars.Length == 0)
			{
				value = default;
				return false;
			}

			var val = 0uL;
			try
			{
				for (var i = 0; i < chars.Length; i++)
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
					val += (ulong) c - '0';
				}
			}
			catch (OverflowException)
			{
				value = default;
				return false;
			}

			value = val;
			return true;
		}
	}
}