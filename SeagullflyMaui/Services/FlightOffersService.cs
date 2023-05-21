using SeagullflyMaui.DTOs;
using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Model;

namespace SeagullflyMaui.Services;
public class FlightOffersService : IFlightOffersService
{
    public List<FlightOffer> GetFlightOffers(SearchQueryDto searchQuery)
    {
        List<FlightOffer> offers = new()
        {
            new FlightOffer()
            {
                Carrier = "LOT",
                FullCost = 1256,
                Travellings = new List<Travelling>
                {
                    new Travelling()
                    {
                        From = "WRO",
                        StartTime = "07:05",
                        To = "WAW",
                        EndTime = "08:05"
                    },
                    new Travelling()
                    {
                        From = "WAW",
                        StartTime = "09:00",
                        To = "BRI",
                        EndTime = "11:30"
                    }
                }
            },
            new FlightOffer()
            {
                Carrier = "LOT",
                FullCost = 1506,
                Travellings = new List<Travelling>
                {
                    new Travelling()
                    {
                        From = "WRO",
                        StartTime = "07:05",
                        To = "BRI",
                        EndTime = "11:30"
                    }
                }
            }
        };

        return offers;
    }
}
