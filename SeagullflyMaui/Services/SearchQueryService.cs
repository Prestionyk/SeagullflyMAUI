﻿using SeagullflyMaui.DTOs;
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

        try
        {
            var searchQuerries = await _seagullflyDatabase.GetAll<SearchQuery>();
            searchQuerries.ToList().ForEach(sq => querries.Add(sq.ToDto()));
        }
        catch { }

        return querries;
    }

    public async Task SaveQuery(SearchQueryDto query)
    {
        var queryToSave = query.ToNotDto();
        await _seagullflyDatabase.Add(queryToSave);
    }

    public async Task DeleteQuery(int id)
    {
        await _seagullflyDatabase.Remove<SearchQuery>(id);
    }
}
