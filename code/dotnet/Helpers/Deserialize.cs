using System.Text.Json;

namespace dotnet.Helpers
{
    public partial class Helpers
    {
        /// <remarks>
        /// This is needed because the workouts file uses a non-ISO 8601 date/time format (no ‘T’):
        /// "datetime_completed": "2018-03-05 06:42:13",
        /// </remarks>
        private static readonly JsonSerializerOptions readOptions = new()
        {
            Converters = { new DateTimeConverter("yyyy-MM-dd HH:mm:ss") }
        };

        /// <summary>
        /// Parses the text representing a single JSON object into an instance of type T.
        /// </summary>
        /// <typeparam name="T">Type of the JSON object.</typeparam>
        /// <param name="json">String containing the JSON value.</param>
        /// <returns>Object representation of the JSON value.</returns>
        public static T? Deserialize<T>(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return default;
            }
        }

        /// <summary>
        /// Parses the text representing a single JSON object into an instance of type T, with the indicated read option.
        /// </summary>
        /// <typeparam name="T">Type of the JSON object.</typeparam>
        /// <param name="json">String containing the JSON value.</param>
        /// <returns>Object representation of the JSON value.</returns>
        public static T? DeserializeWithOptions<T>(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json, readOptions);
            }
            catch (JsonException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return default;
            }
        }
    }
}
