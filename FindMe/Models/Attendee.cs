using Newtonsoft.Json;

namespace FindMe.Models
{
    public class Attendee
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("isNeudesicEmployee")]
        public bool IsNeudesicEmployee { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("headshotUrl")]
        public string HeadshotUrl { get; set; }

        [JsonProperty("eventId")]
        public string EventId { get; set; }

        [JsonProperty("_beacon")]
        public Beacon Beacon { get; set; }

        [JsonIgnore]
        public string Fullname => $"{FirstName} {LastName}";
    }
}
