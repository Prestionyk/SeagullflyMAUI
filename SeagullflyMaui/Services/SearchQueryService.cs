using SeagullflyMaui.DTOs;
using SeagullflyMaui.Interfaces;

namespace SeagullflyMaui.Services;
public class SearchQueryService : ISearchQueryService
{
    private readonly ISeagullflyDatabase _seagullflyDatabase;

    public SearchQueryService(ISeagullflyDatabase seagullflyDatabase)
    {
        _seagullflyDatabase = seagullflyDatabase;
    }

    public List<SearchQueryDto> GetSavedQuerries()
    {
        var qierries = new List<SearchQueryDto>()
        {
            new SearchQueryDto()
            {
                Name = "One"
            }
        };//_seagullflyDatabase.GetAll<SearchQuery>().ToList();

        return qierries;
    }

    public void SaveQuery(SearchQueryDto query)
    {
        //_seagullflyDatabase.Add(query);
    }
}
