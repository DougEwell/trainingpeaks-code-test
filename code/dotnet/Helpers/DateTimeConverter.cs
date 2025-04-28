using System.Text.Json;
using System.Text.Json.Serialization;

namespace dotnet.Helpers
{
    internal class DateTimeConverter(string customDateFormat) : JsonConverter<DateTime>
    {
        // This is needed because the workouts file uses a non-ISO 8601 date/time format (no ‘T’):
        // "datetime_completed": "2018-03-05 06:42:13",

        private readonly string dateFormat = customDateFormat;

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                return DateTime.ParseExact(reader.GetString() ?? string.Empty, dateFormat, null);
            }
            catch (FormatException ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw new JsonException("DateTimeConverter custom exception", ex);
            }
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(dateFormat));
    }
}
