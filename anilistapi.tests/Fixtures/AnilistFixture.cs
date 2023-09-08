using anilistapi.domain.Models;

namespace anilistapi.tests.Fixtures;

public class AnilistFixture : IDisposable
{
    public Filter GenerateFilter()
    {
        var faker = new Faker<Filter>("pt_BR");
        
        faker.RuleFor(x => x.Id, f => f.Random.Int())
            .RuleFor(x => x.Page, f => f.Random.Int(1, 2))
            .RuleFor(x => x.PerPage, f => f.Random.Int(10, 20))
            .RuleFor(x => x.Search, f => f.Lorem.Word());
        
        return faker.Generate();
    }
    
    public Media GenerateMedia()
    {
        var faker = new Faker<Media>();

        faker.RuleFor(x => x.Id, f => f.Random.Int())
            .RuleFor(x => x.Title, f => GenerateTitle())
            .RuleFor(x => x.Characters, f => GenerateCharacter())
            .RuleFor(x => x.BannerImage, f => f.Image.PicsumUrl());

        return faker.Generate();
    }

    public Media[] GenerateMediaArray()
    {
        var faker = new Faker<Media>();

        faker.RuleFor(x => x.Id, f => f.Random.Int())
            .RuleFor(x => x.Title, f => GenerateTitle())
            .RuleFor(x => x.Characters, f => GenerateCharacter())
            .RuleFor(x => x.BannerImage, f => f.Image.PicsumUrl());

        return faker.Generate(10).ToArray();
        
        
    }

    public Title GenerateTitle()
    {
        var faker = new Faker<Title>();

        faker.RuleFor(x => x.English, f => f.Random.String())
            .RuleFor(x => x.Romaji, f => f.Random.String());

        return faker.Generate();
    }
    
    public Name GenerateName()
    {
        var faker = new Faker<Name>();

        faker.RuleFor(x => x.Full, f => f.Person.FullName);

        return faker.Generate();
    }
    
    public Node GenerateNode()
    {
        var faker = new Faker<Node>();

        faker.RuleFor(x => x.Id, f => f.Random.Int())
            .RuleFor(x => x.Description, f => f.Random.String())
            .RuleFor(x => x.Name, f => GenerateName());

        return faker.Generate();
    }
    
    public Edges GenerateEdges()
    {
        var faker = new Faker<Edges>();

        faker.RuleFor(x => x.Node, f => GenerateNode())
            .RuleFor(x => x.Role, f => f.Random.String());

        return faker.Generate();
    }

    public Character GenerateCharacter()
    {
        var faker = new Faker<Character>();

        faker.RuleFor(x => x.Edges, f => new Edges[] { GenerateEdges() });
        
        return faker.Generate();
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            // TODO release managed resources here
        }
        // TODO release unmanaged resources here
    }
}