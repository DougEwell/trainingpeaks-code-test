using System.Text.Json.Serialization;

namespace dotnet.Entities
{
    /// <summary>
    /// Represents a block of sets for a specific exercise performed during a user’s workout.
    /// </summary>
    public class Block
    {
        [JsonPropertyName("exercise_id")]
        [JsonRequired]
        public int ExerciseID { get; set; }
        [JsonPropertyName("sets")]
        [JsonRequired]
        public Set[]? Sets { get; set; }

        /// <summary>
        /// Standard override for display and debugging purposes.
        /// </summary>
        /// <returns>String with usable information about the Block object.</returns>
        public override string ToString()
            => $"Block of {Sets?.Length ?? 0} set(s) of exercise ID {ExerciseID}";
    }
}
