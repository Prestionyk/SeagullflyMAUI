using SeagullflyMaui.DTOs;

namespace SeagullflyMaui.Interfaces;
public interface ISearchQueryService
{
    List<SearchQueryDto> GetSavedQuerries();
    void SaveQuery(SearchQueryDto query);
}
