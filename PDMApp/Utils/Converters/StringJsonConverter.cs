using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PDMApp.Utils.Converters
{
    public class StringJsonConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Number:
                    return reader.GetDecimal().ToString(); // 直接解析 decimal
                case JsonTokenType.String:
                    string stringValue = reader.GetString();
                    if (string.IsNullOrWhiteSpace(stringValue))
                    {
                        return null; // 空字串情況，這裡返回 0 或其他適合的預設值
                    }
                    return stringValue; // 成功轉換
            }

            throw new JsonException($"Invalid JSON value for decimal: {reader.GetString()}");
        }



        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }

}