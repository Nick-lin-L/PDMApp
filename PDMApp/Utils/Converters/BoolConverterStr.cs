using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
// 常規型態，Boolean to String
namespace PDMApp.Utils.Converters
{
    public class BoolToStringConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.True:
                case JsonTokenType.Number when reader.GetInt32() == 1:
                    return "TRUE";
                case JsonTokenType.False:
                case JsonTokenType.Number when reader.GetInt32() == 0:
                    return "FALSE";
                case JsonTokenType.String:
                    var str = reader.GetString()?.ToUpper();
                    return str switch
                    {
                        "TRUE" or "1" or "YES" or "Y" => "TRUE",
                        "FALSE" or "0" or "NO" or "N" => "FALSE",
                        _ => str ?? ""
                    };
                case JsonTokenType.Null:
                    return "";
                default:
                    return ""; // 改為返回空字串而不是拋出異常
            }
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}
