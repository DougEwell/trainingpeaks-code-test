using System.Text.Json.Serialization;

namespace dotnet.Entities
{
    /// <summary>
    /// Represents an entire workout session for a specific user.
    /// </summary>
    public class Workout
    {
        [JsonPropertyName("user_id")]
        [JsonRequired]
        public int UserID { get; set; }
        [JsonPropertyName("datetime_completed")]
        [JsonRequired]
        public DateTime DateTimeCompleted { get; set; }
        [JsonPropertyName("blocks")]
        [JsonRequired]
        public Block[]? Blocks { get; set; }

        /// <summary>
        /// Standard override for display and debugging purposes.
        /// </summary>
        /// <returns>String with usable information about the Workout object.</returns>
        public override string ToString()
            => $"Workout for user {UserID} at {DateTimeCompleted}: {Blocks?.Length ?? 0} block(s)";
    }
}
