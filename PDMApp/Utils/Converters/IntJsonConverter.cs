using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PDMApp.Utils.Converters
{
    public class IntJsonConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Number:
                    return reader.GetInt16(); // 直接解析 decimal
                case JsonTokenType.String:
                    string stringValue = reader.GetString();
                    if (string.IsNullOrWhiteSpace(stringValue))
                    {
                        return default; // 空字串情況，這裡返回 0 或其他適合的預設值
                    }
                    if (int.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
                    {
                        return result; // 成功轉換
                    }
                    break;
            }

            throw new JsonException($"Invalid JSON value for decimal: {reader.GetString()}");


        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);  // 以數字格式寫入 JSON
        }
    }
}