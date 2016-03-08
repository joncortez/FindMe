using Newtonsoft.Json;

namespace FindMe.Models
{
    public class Beacon
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string Minor { get; set; }
        public string Name { get; set; }
    }
}
