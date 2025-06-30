using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
// 常規型態，時間取至hhmmss
namespace PDMApp.Utils.Converters
{
    public class BoolToStringConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.True:
                    return "TRUE";
                case JsonTokenType.False:
                    return "FALSE";
                case JsonTokenType.String:
                    return reader.GetString();
                case JsonTokenType.Null:
                    return null;
                default:
                    throw new JsonException($"Cannot convert {reader.TokenType} to string");
            }
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}
