using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace awesomely.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<T> GetInstances<T>(Assembly assembly)
        {
            var types = assembly
                .GetTypes()
                .Where(x => ((typeof(T).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract)));

            return types.Select(t => (T)Activator.CreateInstance(t));
        }

        public static IEnumerable<T> GetInstances<T>()
        {
            var types = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => ((typeof(T).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract)));

            return types.Select(t => (T)Activator.CreateInstance(t));
        }
    }
}