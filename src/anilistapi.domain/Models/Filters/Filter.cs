using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace anilistapi.domain.Models;

public class Filter
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("page")]
    public int Page { get; set; }
    
    [JsonPropertyName("perPage")]
    public int PerPage { get; set; }
    
    [JsonPropertyName("search")]
    public string Search { get; set; }

    public Filter()
    {
        Id = RandomNumberGenerator.GetInt32(1, 100000);
        Page = 1;
        PerPage = 10;
        Search = string.Empty;
    }
    
    public Filter(int page, int perPage, string search)
    {
        Id = RandomNumberGenerator.GetInt32(1, 100000);
        Page = page;
        PerPage = perPage;
        Search = search;
    }

    public Filter(int page, string search)
    {
        Id = RandomNumberGenerator.GetInt32(1, 100000);
        Page = page;
        PerPage = 10;
        Search = search;
    }
}