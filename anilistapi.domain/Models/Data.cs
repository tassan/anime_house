using System.Text.Json.Serialization;

namespace anilistapi.domain.Models;

public class Data
{
    [JsonPropertyName("page")]
    public Page Page { get; set; }
}