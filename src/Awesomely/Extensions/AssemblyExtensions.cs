using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Awesomely.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<T> GetInstancesOf<T>(this Assembly assembly)
        {
            var types = assembly
                .GetTypes()
                .Where(x => ((typeof(T).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract)));

            return types.Select(t => (T)Activator.CreateInstance(t));
        }
    }
}