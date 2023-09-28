using minimo.dtos;

public interface ISearchService
{
    Task<List<SearchResult>> SearchAsync(searchdto search);
}
