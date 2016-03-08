using Newtonsoft.Json;

namespace FindMe.Models
{
    public class Attendee
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public bool IsNeudesicEmployee { get; set; }
        public string Bio { get; set; }
        public string HeadshotUrl { get; set; }
        public string EventId { get; set; }
        [JsonProperty("_beacon")]
        public Beacon Beacon { get; set; }
    }
}
