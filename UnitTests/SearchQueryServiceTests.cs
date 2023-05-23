using Moq;
using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Services;

namespace UnitTests;

public class SearchQueryServiceTests
{
    private readonly Mock<ISeagullflyDatabase> seagullflyDatabaseMock = new();

    private ISearchQueryService searchQueryService;

    [SetUp]
    public void Setup()
    {


        searchQueryService = new SearchQueryService(seagullflyDatabaseMock.Object);
    }

    [Test]
    public void Test1()
    {
        searchQueryService.GetSavedQuerries();
    }
}