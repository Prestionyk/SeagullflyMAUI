using SQLiteNetExtensions.Attributes;

namespace SeagullflyMaui.Model;
public class Flight : BaseTable
{
    public float LastPrice { get; set; }
    public string Carrier { get; set; }
    public string Source { get; set; }
    [OneToOne]
    public string SearchQueryId { get; set; }
}
