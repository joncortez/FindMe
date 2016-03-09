using Newtonsoft.Json;

namespace FindMe.Models
{
    public class Beacon
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("minor")]
        public string Minor { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
