using SeagullflyMaui.DTOs;

namespace SeagullflyMaui.Interfaces;
public interface ISearchQueryService
{
    Task<List<SearchQueryDto>> GetSavedQuerries();
    Task SaveQuery(SearchQueryDto query);
    Task DeleteQuery(int id);
}
