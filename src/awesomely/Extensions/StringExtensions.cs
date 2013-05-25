using System;
using System.Text.RegularExpressions;

namespace awesomely.Extensions
{
    public static class StringExtensions {
        public static string RemoveSpecialCharacters(this string str) {
            var r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return r.Replace(str, String.Empty);
        }
    }
}