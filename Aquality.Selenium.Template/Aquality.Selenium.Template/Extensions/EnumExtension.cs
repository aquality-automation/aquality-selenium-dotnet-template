using System;
using System.ComponentModel;
using System.Reflection;

namespace Aquality.Selenium.Template.Extensions
{
    public static class EnumExtension
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            string value = enumValue.ToString();
            FieldInfo field = enumValue.GetType().GetField(value);
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);     //Getting the description attribute
            if (objs == null || objs.Length == 0)                                               //If the attribute is not found, it returns the default value
                return value;
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
            return descriptionAttribute.Description;
        }
    }
}