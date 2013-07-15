using System;

namespace awesomely.Extensions
{
    public static class EncondingStringExtensions
    {
        public static bool ContainsIn(this string str, string @in)
        {
            return @in.IndexOf(str, StringComparison.Ordinal) != -1;
        }

        public static string From64(this string str)
        {
            var encodedDataAsBytes = Convert.FromBase64String(str);
            return System.Text.Encoding.UTF8.GetString(encodedDataAsBytes);
        }

        public static string To64(this string str)
        {
            var toEncodeAsBytes = System.Text.Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(toEncodeAsBytes);
        }
    }
}