using anilistapi.domain.Models;

namespace anilistapi.domain.Extensions;

public static class FilterExtensions
{
    public static Variables ToVariables(this Filter filter)
    {
        var searchDecoded = Uri.UnescapeDataString(filter.Search);
        
        return new Variables
        {
            Id = filter.Id,
            Page = filter.Page,
            PerPage = filter.PerPage,
            Search = searchDecoded
        };
    } 
}