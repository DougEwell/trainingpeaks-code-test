using System.Text.Json.Serialization;

namespace dotnet.Entities
{
    /// <summary>
    /// Represents a set (number of reps at a given weight) for a specific user and exercise.
    /// </summary>
    public class Set
    {
        [JsonPropertyName("reps")]
        [JsonRequired]
        public int Reps { get; set; }
        [JsonPropertyName("weight")]
        [JsonRequired]
        public int? Weight { get; set; }

        /// <summary>
        /// Standard override for display and debugging purposes.
        /// </summary>
        /// <returns>String with usable information about the Set object.</returns>
        public override string ToString()
            => $"{Reps} rep(s) of {Weight ?? 0} pound(s) ({Reps * Weight ?? 0} total)";
    }
}
