using System.Text.Json.Serialization;

namespace anilistapi.domain.Models;

public class Variables
{
    [JsonPropertyName("id")]
    public int? Id { get; set; } 
    
    [JsonPropertyName("page")]
    public int? Page { get; set; }
    
    [JsonPropertyName("perPage")]
    public int? PerPage { get; set; }
    
    [JsonPropertyName("search")]
    public string? Search { get; set; }
}