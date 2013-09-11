using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Awesomely.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int chunkSize)
        {
             int i = 0;
             var splits = from item in source
                     group item by i++ % chunkSize into part
                     select part.AsEnumerable();
             return splits;
        }

        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable) action(item);
        }

        public static void ToFile<T>(this IEnumerable<T> enumerable, string filePath)
        {
            using (var sw = new StreamWriter(filePath, true))
            {
                foreach (var item in enumerable)
                {
                    sw.WriteLine(item);
                } sw.Close();
            }
        }
    }
}
