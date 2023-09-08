namespace anilistapi.domain.Interfaces;

public interface IGenericRepository<in T> : IDisposable 
    where T : class
{
    Task<bool> SaveAsync(T entity);
}