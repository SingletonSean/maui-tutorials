using System.Text.Json.Serialization;

namespace MockedMode.Features.ViewRandomCatFact
{
    public class CatFact
    {
        [JsonPropertyName("fact")]
        public string Content { get; set; }
    }
}
