using System.Text.Json.Serialization;

namespace anilistapi.domain.Models;

public class PageInfo
{
    [JsonPropertyName("total")]
    public int Total { get; set; }
    
    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; set; }
    
    [JsonPropertyName("lastPage")]
    public int LastPage { get; set; }
    
    [JsonPropertyName("hasNextPage")]
    public bool HasNextPage { get; set; }
    
    [JsonPropertyName("perPage")]
    public int PerPage { get; set; }
}