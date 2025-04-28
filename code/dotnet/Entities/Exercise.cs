using System.Text.Json.Serialization;

namespace dotnet.Entities
{
    /// <summary>
    /// Represents a discrete exercise.
    /// </summary>
    public class Exercise
    {
        [JsonPropertyName("id")]
        [JsonRequired]
        public int ID { get; set; }
        [JsonPropertyName("title")]
        [JsonRequired]
        public string? Title { get; set; }

        /// <summary>
        /// Retrieves an Exercise object given the title (name) of the exercise.
        /// </summary>
        /// <param name="exercises">Array of exercises.</param>
        /// <param name="title">Title of the exercise.</param>
        /// <returns></returns>
        public static Exercise? GetExerciseByTitle(Exercise[] exercises, string title)
            => exercises?
                .Where(e => e.Title == title)?
                .FirstOrDefault();

        /// <summary>
        /// Standard override for display and debugging purposes.
        /// </summary>
        /// <returns>String with usable information about the Exercise object.</returns>
        public override string ToString()
            => $"Exercise ID {ID}: {Title ?? "(no name)"}";
    }
}
