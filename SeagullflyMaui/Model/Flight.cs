using SQLite;
using SQLiteNetExtensions.Attributes;

namespace SeagullflyMaui.Model;
public class Flight : BaseTable
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public float LastPrice { get; set; }
    public string Carrier { get; set; }
    public string Source { get; set; }
    [ForeignKey(typeof(SearchQuery))]
    public int SearchQueryId { get; set; }
    [OneToOne]
    public SearchQuery SearchQuery { get; set; }
}
