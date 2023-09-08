using anilistapi.domain.Interfaces;
using anilistapi.domain.Models;
using anilistapi.tests.Fixtures;

namespace anilistapi.tests.UnitTests.Infra.Rest;

[Trait("Category", "Unit")]
[Trait("Unit", "Infra")]
[Trait("Infra", "Rest")]
public class AnilistGraphqlRepositoryTest : IClassFixture<AnilistFixture>
{
    private readonly AnilistFixture _anilistFixture;
    private readonly Mock<IGraphqlRepository<Media>> _mockRepository;

    public AnilistGraphqlRepositoryTest(AnilistFixture anilistFixture)
    {
        _anilistFixture = anilistFixture;
        _mockRepository = new Mock<IGraphqlRepository<Media>>();
        _mockRepository.Setup(r => r.Dispose());
    }

    [Fact]
    public async Task GraphqlAnilistRepository_Should_Get()
    {
        // Arrange
        _mockRepository.Setup(r => r.GetAsync(It.IsAny<Filter>()))
            .Returns(() => Task.FromResult(_anilistFixture.GenerateMediaArray()));
        
        var repository = _mockRepository.Object;
        
        // Act
        var filter = _anilistFixture.GenerateFilter();
        var result = await repository.GetAsync(filter);
        
        // Assert
        Assert.NotNull(result);
    }
}