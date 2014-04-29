using Newtonsoft.Json;
using OneApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneApi.Converter
{
    public class LanguageCodeConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            int pos = 0;
            string[] objectIdParts = new string[2];

            while (reader.Read())
            {
                if (pos < 1)
                {
                    if (reader.TokenType == JsonToken.String)
                    {
                        objectIdParts[pos] = reader.Value.ToString();
                        pos++;
                    }
                }
                // read until the end of the JsonReader
            }

            return new LanguageCode((Language) StringEnum.GetEnumValue(objectIdParts[0], typeof(Language)));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var languageCode = value as LanguageCode;
            var code = languageCode.ToString();
            if (!String.IsNullOrEmpty(code))
            {
                writer.WriteRawValue("\"" + code + "\"");
            }
            else
            {
                writer.WriteNull();
            }
        }

        public override bool CanWrite
        {
            get
            {
                return base.CanWrite;
            }
        }

        public override bool CanRead { get { return true; } }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
