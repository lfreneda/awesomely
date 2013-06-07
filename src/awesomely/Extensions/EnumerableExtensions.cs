using System;
using System.Collections.Generic;
using System.IO;

namespace awesomely.Extensions {

    public static class EnumerableExtensions {

        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> action) {
            foreach (var item in enumerable) action(item);
        }

        public static void ToFile<T>(this IEnumerable<T> enumerable, string filePath) {
            using (var sw = new StreamWriter(filePath, true)) {
                foreach (var item in enumerable) {
                    sw.WriteLine(item);
                } sw.Close();
            }
        }
    }
}
