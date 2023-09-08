using anilistapi.domain.Interfaces;
using anilistapi.domain.Models;
using anilistapi.tests.Fixtures;

namespace anilistapi.tests.UnitTests.Infra.Repositories;

[Trait("Category", "Unit")]
[Trait("Unit", "Infra")]
[Trait("Infra", "Repositories")]
public class AnilistRepositoryTest : IClassFixture<AnilistFixture>
{
    private readonly AnilistFixture _anilistFixture;
    private readonly Mock<IGenericRepository<Media>> _mockRepository;

    public AnilistRepositoryTest(AnilistFixture anilistFixture)
    {
        _anilistFixture = anilistFixture;
        _mockRepository = new Mock<IGenericRepository<Media>>();
        _mockRepository.Setup(r => r.Dispose());
    }

    [Fact]
    public async Task AnilistRepository_Should_Save()
    {
        // Arrange
        _mockRepository.Setup(r => r.SaveAsync(It.IsAny<Media>()))
            .Returns(() => Task.FromResult(true));
        
        var repository = _mockRepository.Object;
        
        // Act
        var result = await repository.SaveAsync(It.IsAny<Media>());
        
        // Assert
        Assert.True(result);
    }
}