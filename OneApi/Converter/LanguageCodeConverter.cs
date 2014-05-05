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

            return new Language((LanguageCode)StringEnum.GetEnumValue(objectIdParts[0], typeof(LanguageCode)));//TODO: add: , objectIdParts[1], objectIdParts[2]);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var language = value as Language;
            var code = language.Value;
            var codeString = StringEnum.GetStringValue(code);
            if (!String.IsNullOrEmpty(codeString))
            {
                writer.WriteStartObject();
                writer.WritePropertyName("languageCode");
                writer.WriteValue(codeString);
                writer.WritePropertyName("useLockingShift");
                writer.WriteValue(language.UseLockingShift);
                writer.WritePropertyName("useSingleShift");
                writer.WriteValue(language.UseSingleShift);
                writer.WriteEndObject();
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
