using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Awesomely.Extensions
{
    public static class ObjectExtensions
    {
        public static NameValueCollection ToNameValueCollection(this object obj)
        {
            var nameValueCollection = new NameValueCollection();
            var properties = TypeDescriptor.GetProperties(obj);
            foreach (PropertyDescriptor propertyDescriptor in properties)
            {
                var value = propertyDescriptor.GetValue(obj);
                if (value != null) nameValueCollection.Add(propertyDescriptor.Name, value.ToString());
            }

            return nameValueCollection;
        }

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