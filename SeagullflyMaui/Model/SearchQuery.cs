using SeagullflyMaui.Enums;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace SeagullflyMaui.Model;
public class SearchQuery : BaseTable
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public DateTime Departure { get; set; }
    public DateTime Arrival { get; set; }
    public FlightType FlightType { get; set; }
    [OneToMany(CascadeOperations  = CascadeOperation.All)]
    public List<Passenger> Passengers { get; set; }
}
