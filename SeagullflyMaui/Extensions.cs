using SeagullflyMaui.Enums;

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
}
