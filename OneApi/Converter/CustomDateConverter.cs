using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OneApi.Model
{
    class CustomDateConverter : DateTimeConverterBase
    {
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                var ticks = (long)reader.Value;
                var date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                date = date.AddMilliseconds(ticks);
                return date;

            } 
            else if (reader.TokenType == JsonToken.Date) 
            {
                return (DateTime)reader.Value; 
            } 
            else 
            {
                throw new Exception(
                   String.Format("Unexpected token parsing date.",
                   reader.TokenType));
            }   
        }

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            long ticks;
            if (value is DateTime)
            {
                var epoc = new DateTime(1970, 1, 1);
                var delta = ((DateTime)value) - epoc;
                if (delta.TotalMilliseconds < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Unix epoc starts January 1st, 1970");
                }
                ticks = (long)delta.TotalMilliseconds;
            }
            else
            {
                throw new Exception("Expected date object value.");
            }
            writer.WriteValue(ticks);
        }
    }
}
