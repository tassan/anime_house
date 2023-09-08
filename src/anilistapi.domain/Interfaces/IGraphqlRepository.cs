using anilistapi.domain.Models;

namespace anilistapi.domain.Interfaces;

public interface IGraphqlRepository<T> : IDisposable 
    where T : class
{
    Task<T[]> GetAsync(Filter filter);
}