namespace DotNetCoreUtilities.String
{
	public static class StringExt
	{
		/// <summary>Replace all the instances of [remove] with nothing</summary>
		public static string Remove(this string str, string remove)
			=> str.Replace(remove, "");

		public static bool IsNullOrEmpty(this string str) 
			=> string.IsNullOrEmpty(str);

		public static bool IsNullOrWhiteSpace(this string str)
			=> string.IsNullOrWhiteSpace(str);

		public static string StartingWith(this string str, char start)
			=> str.StartsWith(start) ? str : start + str;

		public static string StartingWith(this string str, string start)
			=> str.StartsWith(start) ? str : start + str;

		public static string EndingWith(this string str, char end)
			=> str.EndsWith(end) ? str : str + end;

		public static string EndingWith(this string str, string end)
			=> str.EndsWith(end) ? str : str + end;
	}
}