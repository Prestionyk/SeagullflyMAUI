using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Model;

namespace SeagullflyMaui.Services;
public class SearchQueryService : ISearchQueryService
{
    private readonly ISeagullflyDatabase _seagullflyDatabase;

    public SearchQueryService(ISeagullflyDatabase seagullflyDatabase)
    {
        _seagullflyDatabase = seagullflyDatabase;
    }

    public List<SearchQuery> GetSavedQuerries()
    {
        var qierries = _seagullflyDatabase.GetAll<SearchQuery>().ToList();

        return qierries;
    }
}
