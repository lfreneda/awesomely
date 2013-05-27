using System;
using System.Text.RegularExpressions;

namespace awesomely.Extensions
{
    public static class StringExtensions {
	
        public static string RemoveSpecialCharacters(this string str) {
            var r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return r.Replace(str, String.Empty);
        }
		
        public static string FormatWith(this string format, params object[] args) {
            if (format == null) throw new ArgumentNullException("format");
            return string.Format(format, args);
        }

        public static string FormatWith(this string format, IFormatProvider provider, params object[] args) {
            if (format == null) throw new ArgumentNullException("format");
            return string.Format(provider, format, args);
        }

	public static bool ContainsIn(this string str, string @in) {
            return @in.IndexOf(str, StringComparison.Ordinal) != -1;
        }
		
	public static string From64(this string str) {
            var encodedDataAsBytes = Convert.FromBase64String(str);
            return System.Text.Encoding.UTF8.GetString(encodedDataAsBytes);
        }

        public static string To64(this string str) {
            var toEncodeAsBytes = System.Text.Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(toEncodeAsBytes);
        }
    }
}
