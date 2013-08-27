using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Awesomely.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveNewLinesAndSpaces(this string str)
        {
            return str.ExceptChars(new HashSet<char>(new[] { ' ', '\t', '\n', '\r' }));
        }

        public static string ExceptChars(this string str, IEnumerable<char> toExclude)
        {
            StringBuilder sb = new StringBuilder(str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (!toExclude.Contains(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}