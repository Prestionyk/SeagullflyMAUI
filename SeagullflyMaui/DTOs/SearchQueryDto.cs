namespace SeagullflyMaui.DTOs;
public class SearchQueryDto
{
    public string Name { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public DateTime Departure { get; set; }
    public DateTime Arrival { get; set; }
    public string FlightType { get; set; }
    public int AdultCount { get; set; }
    public int YouthCount { get; set; }
    public int ChildrenCount { get; set; }
    public int InfantCount { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
