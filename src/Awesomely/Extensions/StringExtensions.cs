using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Awesomely.Extensions {

    public static class StringExtensions {

        public static string RemoveNewLinesAndSpaces(this string str) {
            return str.ExceptChars(new HashSet<char>(new[] { ' ', '\t', '\n', '\r' }));
        }

        public static string RemoveSpecialCharacters(this string str) {
            var r = new Regex("(?:[^a-z0-9|ç| ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return r.Replace(str, String.Empty);
        }

        public static string ExceptChars(this string str, IEnumerable<char> toExclude) {
            var sb = new StringBuilder(str.Length);
            for (int i = 0; i < str.Length; i++) {
                char c = str[i];
                if (!toExclude.Contains(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}