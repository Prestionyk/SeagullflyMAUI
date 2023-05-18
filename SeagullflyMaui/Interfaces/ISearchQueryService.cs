using SeagullflyMaui.Model;

namespace SeagullflyMaui.Interfaces;
public interface ISearchQueryService
{
    List<SearchQuery> GetSavedQuerries();
    void SaveQuery(SearchQuery query);
}
