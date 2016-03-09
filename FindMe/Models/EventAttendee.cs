using Newtonsoft.Json;

namespace FindMe.Models
{
    public class EventAttendee
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("eventId")]
        public string EventId { get; set; }

        [JsonProperty("attendeeId")]
        public string AttendeeId { get; set; }

        [JsonProperty("beaconId")]
        public string BeaconId { get; set; }
    }
}
