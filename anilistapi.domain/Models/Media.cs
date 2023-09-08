using System.Text.Json.Serialization;

namespace anilistapi.domain.Models;

public class Media
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("title")]
    public Title Title { get; set; }
    
    [JsonPropertyName("bannerImage")]
    public string? BannerImage { get; set; }
    
    [JsonPropertyName("characters")]
    public Character Characters { get; set; }
    
    public Edges[] ExtractEdges() => Characters.Edges;
}