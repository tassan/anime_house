using System.Text.Json.Serialization;

namespace anilistapi.domain.Models;

public class Character
{
    [JsonPropertyName("edges")]
    public Edges[] Edges { get; set; }
}