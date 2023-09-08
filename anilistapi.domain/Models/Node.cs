using System.Text.Json.Serialization;

namespace anilistapi.domain.Models;

public class Node
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public Name Name { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
