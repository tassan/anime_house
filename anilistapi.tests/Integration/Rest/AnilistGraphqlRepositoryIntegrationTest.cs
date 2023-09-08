using anilistapi.domain.Models;
using anilistapi.infra;
using anilistapi.infra.rest;
using anilistapi.infra.Settings;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace anilistapi.tests.Integration.Rest;

[Trait("Category", "Integration")]
[Trait("Integration", "Rest")]
public class AnilistGraphqlRepositoryIntegrationTest
{
    private readonly AnilistRepository _databaseRepository;
    private readonly AnilistGraphqlRepository _restGraphqlRepository;
    private readonly ITestOutputHelper _output;

    public AnilistGraphqlRepositoryIntegrationTest(ITestOutputHelper output)
    {
        _output = output;
        var settings = new AnilistSettings
        {
            Url = "https://graphql.anilist.co"
        };
        _databaseRepository = new AnilistRepository(settings);
        _restGraphqlRepository = new AnilistGraphqlRepository(settings);
    }

    [Fact]
    public async Task AnilistRepository_Should_Get()
    {
        // Arrange
        var filter = new Filter
        {
            Id = 125478,
            Page = 1,
            PerPage = 10,
            Search = "naruto"
        };

        // Act
        var result = await _restGraphqlRepository.GetAsync(filter);

        // Assert
        Assert.NotNull(result);

        _output.WriteLine(JsonConvert.SerializeObject(result));
    }
}