using SeagullflyMaui.DTOs;
using SeagullflyMaui.Enums;
using SeagullflyMaui.Model;

namespace SeagullflyMaui.MockData;
public class RandomData
{
    public static string GetRandomCarrier()
    {
        string[] carriers = { "LOT", "Wizz Air", "Ryanair", "Lufthansa", "Smartwings" };
        return carriers[new Random().Next(carriers.Length)];
    }

    public static List<DayOffer> GetOffersOfTheDay()
    {
        List<DayOffer> offers = new();
        var offerCount = new Random().Next(1,10);

        for (int i = 0; i < offerCount; i++)
            offers.Add(new DayOffer
            {
                Price = $"{new Random().Next(70, 1001)} PLN",
                Description = GetRandomDescription(),
                Shortcut = GetRandomShortcut()
            });

        return offers;
    }

    public static string GetRandomShortcut()
    {
        string[] descriptions = {
            "Turcja all inclusive z 5 miast",
            "Last minute tylko w naszym biurze",
            "Hotel 5* wraz z wyżywieniem",
            "Ostatnie miejsca do rezerwacji",
            "Ktoś inny właśnie przegląda tę ofertę" };
        return descriptions[new Random().Next(descriptions.Length)];
    }

    public static string GetRandomDescription()
    {
        string[] descriptions = {
            "Tygodniowe all inclusive w 5* hotelu w Turcji",
            "Trzy dni na słonecznych Malediwach",
            "Złote piaski, hotel, plaża i śniadania w cenie",
            "Dwa tygodnie z przewodnikiem po pustyni",
            "Wymarzone wakacje we dwoje na tropikalnych wyspach" };
        return descriptions[new Random().Next(descriptions.Length)];
    }

    public static List<Travelling> GetRandomTravelings(SearchQueryDto queryDto)
    {
        List<Travelling> travellings = new();


        if(queryDto.FlightType.ToFlightType() == FlightType.OneWayDirect || queryDto.FlightType.ToFlightType() == FlightType.TwoWaysDirect)
        {
            travellings.Add(new Travelling
            {
                From = queryDto.From,
                StartTime = GetRandomTime(),
                To = queryDto.To,
                EndTime = GetRandomTime()
            });

            return travellings;
        }

        travellings.Add(new Travelling
        {
            From = queryDto.From,
            StartTime = GetRandomTime(),
            To = GetRandomAirport(),
            EndTime = GetRandomTime()
        });
        travellings.Add(new Travelling
        {
            From = GetRandomAirport(),
            StartTime = GetRandomTime(),
            To = queryDto.To,
            EndTime = GetRandomTime()
        });

        return travellings;
    }

    private static string GetRandomTime()
    {
        return $"{new Random().Next(10,25)}:{new Random().Next(10, 60)}";
    }

    private static string GetRandomAirport()
    {
        string[] airports = { "ATL", "PEK", "LAX", "LHR", "FRA", "WAW", "WRI" };
        return airports[new Random().Next(airports.Length)];
    }
}
