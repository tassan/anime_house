using System.Text.Json.Serialization;

namespace anilistapi.domain.Models;

public class Edges
{
    [JsonPropertyName("node")]
    public Node Node { get; set; }
    
    [JsonPropertyName("role")]
    public string Role { get; set; }
}