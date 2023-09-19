using System.Text.Json.Serialization;

namespace DecoratorDemoApi.Models
{
    public class Location
    {
        [JsonPropertyName("Location")]
        public string LocationName { get; set; }
        [JsonPropertyName("Post_Office")]
        public string PostOffice { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
    }
}