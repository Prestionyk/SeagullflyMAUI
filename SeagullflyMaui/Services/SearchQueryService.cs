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
        var qierries = new List<SearchQuery>()
        {
            new SearchQuery()
            {
                Name = "One"
            }
        };//_seagullflyDatabase.GetAll<SearchQuery>().ToList();

        return qierries;
    }

    public void SaveQuery(SearchQuery query)
    {
        //_seagullflyDatabase.Add(query);
    }
}
