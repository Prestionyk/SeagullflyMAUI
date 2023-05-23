using SeagullflyMaui.Enums;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace SeagullflyMaui.Model;
public class Passenger : BaseTable
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public PassengerType Type { get; set; }
    public int Quantity { get; set; }
    [ForeignKey(typeof(SearchQuery))]
    public int SearchQueryId { get; set; }
    [ManyToOne]
    public SearchQuery SearchQuery { get; set; }
}
