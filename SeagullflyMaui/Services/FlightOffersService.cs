using SeagullflyMaui.DTOs;
using SeagullflyMaui.Interfaces;
using SeagullflyMaui.MockData;
using SeagullflyMaui.Model;

namespace SeagullflyMaui.Services;
public class FlightOffersService : IFlightOffersService
{
    public List<FlightOffer> GetFlightOffers(SearchQueryDto searchQuery)
    {
        List<FlightOffer> offers = new();

        var offerCount = new Random().Next(0, 7);
        for(int i = 0; i <= offerCount; i++)
        {
            offers.Add(new FlightOffer
            {
                Carrier = RandomData.GetRandomCarrier(),
                FullCost = new Random().Next(200, 2000),
                Travellings = RandomData.GetRandomTravelings(searchQuery)
            });
        }

        return offers.OrderBy(offer => offer.FullCost).ToList();
    }
}
