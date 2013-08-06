using System;
using System.Text.RegularExpressions;

namespace Awesomely.Extensions
{
    public static class FormatStringExtensions
    {
        public static string RemoveSpecialCharacters(this string str)
        {
            var r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return r.Replace(str, String.Empty);
        }

        public static string FormatWith(this string format, params object[] args)
        {
            if (format == null) throw new ArgumentNullException("format");
            return string.Format(format, args); 
        }

        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            if (format == null) throw new ArgumentNullException("format");
            return string.Format(provider, format, args);
        }
    }
}