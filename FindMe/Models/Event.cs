using System;
using Newtonsoft.Json;

namespace FindMe.Models
{
    public class Event
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string WelcomeMessage { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string BackgroundImageUrl { get; set; }
        public string BeaconUuid { get; set; }
        public string BeaconMajor { get; set; }
    }
}
