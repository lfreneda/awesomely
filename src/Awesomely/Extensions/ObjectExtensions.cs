using System.Collections.Generic;
using System.ComponentModel;

namespace Awesomely.Extensions
{
    public static class ObjectExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object obj)
        {
            return obj.ToDictionary<object>();
        }

        public static IDictionary<string, T> ToDictionary<T>(this object obj)
        {
            var dictionary = new Dictionary<string, T>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(obj);
            foreach (PropertyDescriptor propertyDescriptor in properties)
            {
                object value = propertyDescriptor.GetValue(obj);
                dictionary.Add(propertyDescriptor.Name, (T)value);
            }

            return dictionary;
        }
    }
}