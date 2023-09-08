using System.Text.Json.Serialization;

namespace anilistapi.domain.Models;

public class Page
{
    [JsonPropertyName("pageInfo")]
    public PageInfo PageInfo { get; set; }
    
    [JsonPropertyName("media")]
    public Media[]? Media { get; set; } 
}