using SeagullflyMaui.DTOs;
using SeagullflyMaui.Model;

namespace SeagullflyMaui.Interfaces;
public interface IFlightOffersService
{
    List<FlightOffer> GetFlightOffers(SearchQueryDto searchQuery);
}
