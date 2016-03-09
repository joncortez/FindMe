using System;
using Newtonsoft.Json;

namespace FindMe.Models
{
    public class Event
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("welcomeMessage")]
        public string WelcomeMessage { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("backgroundImageUrl")]
        public string BackgroundImageUrl { get; set; }

        [JsonProperty("beaconUuid")]
        public string BeaconUuid { get; set; }

        [JsonProperty("beaconMajor")]
        public string BeaconMajor { get; set; }
    }
}
