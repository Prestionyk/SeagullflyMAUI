using SeagullflyMaui.Enums;
using SQLite;

namespace SeagullflyMaui.Model;
public class Passenger
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public PassengerType Type { get; set; }
    public int Quantity { get; set; }
}
