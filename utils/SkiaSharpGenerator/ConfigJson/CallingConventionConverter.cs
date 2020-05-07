using System;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SkiaSharpGenerator
{
    public class CallingConventionConverter : JsonConverter<CallingConvention>
    {
        public override CallingConvention Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            (CallingConvention)Enum.Parse(typeof(CallingConvention), reader.GetString(), true);

        public override void Write(Utf8JsonWriter writer, CallingConvention value, JsonSerializerOptions options) =>
            throw new NotImplementedException();
    }
}
