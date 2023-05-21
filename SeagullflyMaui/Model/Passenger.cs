using SeagullflyMaui.Enums;
using SQLiteNetExtensions.Attributes;

namespace SeagullflyMaui.Model;
public class Passenger : BaseTable
{
    public PassengerType Type { get; set; }
    public int Quantity { get; set; }
    [ManyToOne]
    public SearchQuery SearchQuery { get; set; }
}
