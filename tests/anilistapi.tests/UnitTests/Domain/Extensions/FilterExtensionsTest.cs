using anilistapi.domain.Extensions;
using anilistapi.domain.Models;
using anilistapi.tests.Fixtures;

namespace anilistapi.tests.UnitTests.Domain.Extensions;

[Trait("Category", "Unit")]
[Trait("Unit", "Extensions")]
public class FilterExtensionsTest : IClassFixture<AnilistFixture>
{
    private readonly AnilistFixture _fixture;

    public FilterExtensionsTest(AnilistFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Fact]
    public void FilterExtensions_Should_Return_Variables()
    {
        // Arrange
        var filter = _fixture.GenerateFilter();
        
        // Act
        var variables = filter.ToVariables();
        
        // Assert
        variables.Should().BeOfType<Variables>();
        variables.Id.Should().Be(filter.Id);
        variables.Page.Should().Be(filter.Page);
        variables.PerPage.Should().Be(filter.PerPage);
        variables.Search.Should().Be(filter.Search);
    }
}