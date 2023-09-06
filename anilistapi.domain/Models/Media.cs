namespace anilistapi.domain.Models;

public class Media
{
    public int Id { get; set; }
    public Title Title { get; set; }
    public string? BannerImage { get; set; }
    public Character Characters { get; set; }
}