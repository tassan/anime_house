using System.Text.Json.Serialization;

namespace anilistapi.domain.Models;

public class Name
{
    [JsonPropertyName("full")]
    public string Full { get; set; }
}