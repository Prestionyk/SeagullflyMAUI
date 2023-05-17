namespace SeagullflyMaui.Model;
public class SearchingFilter
{
    public string From { get; set; }
    public string To { get; set; }
    public DateTime Departure { get; set; }
    public DateTime Arrival { get; set; }
    public string FlightType { get; set; }
    public int AdultCount { get; set; }
    public int YouthCount { get; set; }
    public int ChildrenCount { get; set; }
    public int InfantCount { get; set; }
}
