using anilistapi.domain.Interfaces;
using anilistapi.domain.Models;

namespace anilistapi.application;

public class AnilistService : IAnilistService
{
    private readonly IGenericRepository<Media> _repository;
    private readonly IGraphqlRepository<Media> _graphqlRepository;

    public AnilistService(
        IGenericRepository<Media> repository, 
        IGraphqlRepository<Media> graphqlRepository)
    {
        _repository = repository;
        _graphqlRepository = graphqlRepository;
    }

    public Task<Media[]> GetAsync(Filter filter)
    {
        return _graphqlRepository.GetAsync(filter);
    }

    public Task<bool> SaveAsync(Media[] media)
    {
        var tasks = media.Select(m => _repository.SaveAsync(m));
        
        return Task.WhenAll(tasks).ContinueWith(t => t.Result.All(r => r));
    }
}