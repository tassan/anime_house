using System.Text.Json.Serialization;

namespace anilistapi.domain.Models;

public class Root
{
    [JsonPropertyName("data")]
    public Data Data { get; set; }
    
    public Media[]? ExtractMedia() => Data.Page.Media;
    
}