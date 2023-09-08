using anilistapi.domain.Interfaces;

namespace anilistapi.infra.Settings;

public class AnilistSettings : IAnilistSettings
{
    public string Connection { get; set; }
    public string Url { get; set; }
}