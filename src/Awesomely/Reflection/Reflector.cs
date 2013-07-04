using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Awesomely.Reflection
{
    public static class Reflector
    {
        public static IEnumerable<T> GetInstancesOf<T>()
        {
            var types = Assembly
                  .GetExecutingAssembly()
                  .GetTypes()
                  .Where(x => ((typeof(T).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract)));

            return types.Select(t => (T)Activator.CreateInstance(t));
        }
    }
}
