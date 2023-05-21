using SeagullflyMaui.DTOs;

namespace SeagullflyMaui.Interfaces;
public interface ISearchQueryService
{
    Task<List<SearchQueryDto>> GetSavedQuerries();
    void SaveQuery(SearchQueryDto query);
}
