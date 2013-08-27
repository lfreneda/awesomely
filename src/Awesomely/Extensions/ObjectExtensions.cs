using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;

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
        
        public static void SetPropertyValue(this Object obj, object value, string propertyName) {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
            propertyInfo.SetValue(obj, value, null);
        }

        public static object GetPropertyValue(this Object obj, string propertyName) {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
            return propertyInfo.GetValue(obj, null);
        }

        public static object GetFieldValue(this Object obj, string fieldName) {
            FieldInfo fieldInfo = obj.GetType().GetField(fieldName,
                BindingFlags.Instance | BindingFlags.NonPublic);
            return fieldInfo.GetValue(obj);
        }

        public static void SetFieldValue(this Object obj, object value, string fieldName) {
            FieldInfo fieldInfo = obj.GetType().GetField(fieldName,
                BindingFlags.Instance | BindingFlags.NonPublic);
            fieldInfo.SetValue(obj, value);
        }

        public static void SetFieldValue(this Object obj, Type type, object value, string fieldName) {
            FieldInfo fieldInfo = type.GetType().GetField(fieldName,
                BindingFlags.Instance | BindingFlags.NonPublic);
            fieldInfo.SetValue(obj, value);
        }
    }
}
