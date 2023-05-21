using SeagullflyMaui.Enums;
using SQLiteNetExtensions.Attributes;

namespace SeagullflyMaui.Model;
public class SearchQuery : BaseTable
{
    public string Name { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public DateTime Departure { get; set; }
    public DateTime Arrival { get; set; }
    public FlightType FlightType { get; set; }
    [OneToOne]
    public Flight Flight { get; set; }
    [OneToMany]
    public List<Passenger> Passengers { get; set; }
}
