using SeagullflyMaui.DTOs;
using SeagullflyMaui.Enums;
using SeagullflyMaui.Model;

namespace SeagullflyMaui;
public static class Extensions
{
    public static FlightType ToFlightType(this string flightTypeString)
    {
        switch (flightTypeString)
        {
            case "Jednostronny": return FlightType.OneWay;
            case "Jednostronny bezpośredni": return FlightType.OneWayDirect;
            case "Dwustronny": return FlightType.TwoWays;
            case "Dwustronny bezpośredni": return FlightType.TwoWaysDirect;
            default: throw new ArgumentOutOfRangeException("flightType");
        }
    }
    public static string ToPolishString(this FlightType flightType)
    {
        switch (flightType)
        {
            case FlightType.OneWay: return "Jednostronny";
            case FlightType.OneWayDirect: return "Jednostronny bezpośredni";
            case FlightType.TwoWays: return "Dwustronny";
            case FlightType.TwoWaysDirect: return "Dwustronny bezpośredni";
            default: throw new ArgumentOutOfRangeException("flightType");
        }
    }

    public static SearchQuery ToNotDto(this SearchQueryDto queryDto)
    {
        return new SearchQuery
        {
            Name = queryDto.Name,
            From = queryDto.From,
            To = queryDto.To,
            Arrival = queryDto.Arrival,
            Departure = queryDto.Departure,
            FlightType = queryDto.FlightType.ToFlightType(),
            Passengers = new List<Passenger>
            {
                new Passenger
                {
                    Type = PassengerType.Adult,
                    Quantity = queryDto.AdultCount
                },
                new Passenger
                {
                    Type = PassengerType.Children,
                    Quantity = queryDto.ChildrenCount
                },
                new Passenger
                {
                    Type = PassengerType.Youth,
                    Quantity = queryDto.YouthCount
                },
                new Passenger
                {
                    Type = PassengerType.Infant,
                    Quantity = queryDto.InfantCount
                },
            }
        };
    }

    public static SearchQueryDto ToDto(this SearchQuery query)
    {
        return new SearchQueryDto
        {
            Name = query.Name,
            From = query.From,
            To = query.To,
            Arrival = query.Arrival,
            Departure = query.Departure,
            FlightType = query.FlightType.ToString(),
            AdultCount = query.Passengers.Where(p => p.Type == PassengerType.Adult).First().Quantity,
            YouthCount = query.Passengers.Where(p => p.Type == PassengerType.Youth).First().Quantity,
            ChildrenCount = query.Passengers.Where(p => p.Type == PassengerType.Children).First().Quantity,
            InfantCount = query.Passengers.Where(p => p.Type == PassengerType.Infant).First().Quantity,
        };
    }
}
