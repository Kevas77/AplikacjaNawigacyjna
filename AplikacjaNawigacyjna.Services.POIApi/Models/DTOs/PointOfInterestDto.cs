using System.Text.Json.Serialization;

namespace AplikacjaNawigacyjna.Services.POIApi.Models.DTOs
{
    public class PointOfInterestDto
    {
        [JsonPropertyName("xid")]
        public string Xid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("kinds")]
        public string Kinds { get; set; }

        [JsonPropertyName("point")]
        public Coordinates Location { get; set; }
    }
}
