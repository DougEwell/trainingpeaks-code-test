using System.Text.Json.Serialization;

namespace dotnet.Entities
{
    /// <summary>
    /// Represents a user (athlete).
    /// </summary>
    public class User
    {
        [JsonPropertyName("id")]
        [JsonRequired]
        public int ID { get; set; }
        [JsonPropertyName("name_first")]
        [JsonRequired]
        public string? NameFirst { get; set; }
        [JsonPropertyName("name_last")]
        [JsonRequired]
        public string? NameLast { get; set; }

        /// <summary>
        /// Retrieves a User object given the user’s first and last name.
        /// </summary>
        /// <param name="users">Array of users.</param>
        /// <param name="first">User’s first name.</param>
        /// <param name="last">User’s last name.</param>
        /// <returns></returns>
        public static User? GetUserByName(User[] users, string first, string last)
            => users?
                .Where(u => u.NameFirst == first && u.NameLast == last)?
                .FirstOrDefault();

        /// <summary>
        /// Standard override for display and debugging purposes.
        /// </summary>
        /// <returns>String with usable information about the User object.</returns>
        public override string ToString()
            => $"User {ID}, {NameFirst ?? ""} {NameLast ?? ""}";
    }
}
