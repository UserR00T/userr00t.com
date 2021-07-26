using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pointer.Core.Application.Converters
{
    public class ReadOnlyConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString();
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteNullValue();
        }
    }
}