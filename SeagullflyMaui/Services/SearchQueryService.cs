using SeagullflyMaui.DTOs;
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

    public async Task<List<SearchQueryDto>> GetSavedQuerries()
    {
        var querries = new List<SearchQueryDto>();

        var searchQuerries = await _seagullflyDatabase.GetAll<SearchQuery>();
        searchQuerries.ToList().ForEach(sq => querries.Add(sq.ToDto()));

        return querries;
    }

    public void SaveQuery(SearchQueryDto query)
    {
        _seagullflyDatabase.Add(query.ToNotDto());
    }
}
