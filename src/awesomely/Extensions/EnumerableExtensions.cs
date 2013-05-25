using System;
using System.Collections.Generic;

namespace awesomely.Extensions {

    public static class EnumerableExtensions {
        public static void Each<T>(this IEnumerable<T> source, Action<T> action) {
            foreach (var item in source) action(item);
        }
    }
}
