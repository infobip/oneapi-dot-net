using System;
using System.Reflection;

namespace OneApi.Model
{
    public class StringValue : System.Attribute
    {
        public string Value { get; private set; }

        public StringValue(string value)
        {
            Value = value;
        }
    }

    public static class StringEnum
    {
        public static string GetStringValue(Enum value)
        {
            string output = null;
            if (null == value)
                return null;
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            StringValue[] attrs =
                fi.GetCustomAttributes(typeof(StringValue), false) as StringValue[];

            if (attrs.Length > 0)
                output = attrs[0].Value;

            return output;
        }

        public static object GetEnumValue(string stringValue, Type enumType)
        {
            FieldInfo[] fields = enumType.GetFields();
            foreach (var field in fields)
            {
                StringValue[] attrs = field.GetCustomAttributes(typeof(StringValue), false) as StringValue[];
                if (attrs.Length > 0)
                {
                    if (attrs[0].Value == stringValue)
                    {
                        return field.GetRawConstantValue();
                    }
                }
            }
            return null;
        }
    }
}
