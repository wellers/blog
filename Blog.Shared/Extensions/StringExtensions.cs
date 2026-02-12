using System.Text.RegularExpressions;

namespace Blog.Core.Extensions;

public static class StringExtensions
{
	public static string RemoveSpecialCharacters(this string input)
	{
		var r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
		return r.Replace(input, string.Empty);
	}

	public static string ToRouteTitle(this string input) => input.RemoveSpecialCharacters().ToLower().Replace(" ", "-");	
}
