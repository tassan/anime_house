using anilistapi.domain.Models;

namespace anilistapi.domain.Interfaces;

public interface IAnilistService
{
    Task<Media[]> GetAsync(Filter filter);
    Task<bool> SaveAsync(Media[] media);
}