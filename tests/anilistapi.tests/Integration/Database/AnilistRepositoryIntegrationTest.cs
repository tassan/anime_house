using anilistapi.domain.Models;
using anilistapi.infra;
using anilistapi.infra.rest;
using anilistapi.infra.Settings;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace anilistapi.tests.Integration;

[Trait("Category", "Integration")]
[Trait("Integration", "Database")]
public class AnilistRepositoryIntegrationTest
{
    private readonly AnilistRepository _databaseRepository;
    private readonly ITestOutputHelper _output;

    public AnilistRepositoryIntegrationTest(ITestOutputHelper output)
    {
        _output = output;
        var settings = new AnilistSettings
        {
            Connection = "Host=localhost;Port=3366;user=root;database=animechar;password=my-secret-pw;",
        };
        _databaseRepository = new AnilistRepository(settings);
    }

    [Fact]
    public async Task AnilistRepository_Should_Save()
    {
        // Arrange
        var media = new Media
        {
            Id = 123456,
            Title = new Title
            {
                Romaji = "NARUTO",
                English = "Naruto"
            },
            BannerImage = "https://s4.anilist.co/file/anilistcdn/media/anime/banner/1.jpg",
            Characters = new Character
            {
                Edges = new Edges[]
                {
                    new()
                    {
                        Node = new Node
                        {
                            Id = 1,
                            Name = new Name
                            {
                                Full = "Naruto Uzumaki"
                            },
                            Description = "Naruto Uzumaki (うずまきナルト, Uzumaki Naruto) is a shinobi of Konohagakure\\'s Uzumaki clan."
                        },
                        Role = "Main"
                    },
                    new()
                    {
                        Node = new Node
                        {
                            Id = 2,
                            Name = new Name
                            {
                                Full = "Sasuke Uchiha"
                            },
                            Description = "Sasuke Uchiha (うちはサスケ, Uchiha Sasuke) is one of the last surviving members of Konohagakure\\'s Uchiha clan.",
                        },
                        Role = "Main"
                    },
                    new()
                    {
                        Node = new Node
                        {
                            Id = 3,
                            Name = new Name
                            {
                                Full = "Sakura Haruno"
                            },
                            Description = "Sakura Haruno (春野サクラ, Haruno Sakura) is a kunoichi of Konohagakure."
                        },
                        Role = "Main"
                    }
                }
            }
        };

        // Act
        var result = await _databaseRepository.SaveAsync(media);

        // Assert
        Assert.True(result);
    }
}