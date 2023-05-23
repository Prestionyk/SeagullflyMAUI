using Moq;
using SeagullflyMaui.Enums;
using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Model;
using SeagullflyMaui.Services;

namespace UnitTests;

public class SearchQueryServiceTests
{
    private readonly Mock<ISeagullflyDatabase> seagullflyDatabaseMock = new();

    private ISearchQueryService searchQueryService;

    [SetUp]
    public void Setup()
    {

        seagullflyDatabaseMock.Setup(x => x.GetAll<SearchQuery>()).ReturnsAsync(new List<SearchQuery>() { new SearchQuery
        {
            Passengers = new[]
            {
                new Passenger(){ Type = PassengerType.Adult, Quantity = 1},
                new Passenger(){ Type = PassengerType.Youth, Quantity = 2},
                new Passenger(){ Type = PassengerType.Children, Quantity = 3},
                new Passenger(){ Type = PassengerType.Infant, Quantity = 4},
            }.ToList()
        } });
        searchQueryService = new SearchQueryService(seagullflyDatabaseMock.Object);
    }

    [Test]
    public void SearchQueryServiceReturnNotEmptyListWhenDatabaseReturnData()
    {
        var queries = searchQueryService.GetSavedQuerries().Result;

        Assert.That(queries, Is.Not.Empty);
        Assert.That(queries, Has.Count.EqualTo(1));
    }
}