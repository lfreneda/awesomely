using System;
using System.ComponentModel;
using System.Globalization;

namespace Awesomely.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString(CultureInfo.InvariantCulture));
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString(CultureInfo.InvariantCulture) : attribute.Description;
        }
    }
}