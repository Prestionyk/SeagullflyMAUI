namespace SeagullflyMaui.Model;
public class FlightOffer
{
    public string Url { get; set; } = "www.google.com";
    public int FullCost { get; set; }
    public string Carrier { get; set; }
    public List<Travelling> Travellings { get; set; }
}
