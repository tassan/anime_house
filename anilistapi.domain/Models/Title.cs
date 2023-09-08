using System.Text.Json.Serialization;

namespace anilistapi.domain.Models;

public class Title
{
    [JsonPropertyName("romaji")]
    public string? Romaji { get; set; }
    
    [JsonPropertyName("english")]
    public string? English { get; set; }
}