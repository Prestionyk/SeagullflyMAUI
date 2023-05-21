namespace SeagullflyMaui.Model;
public class Travelling
{
    public string From { get; set; }
    public string To { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }

    public string Period => $"{StartTime} - {EndTime}";
}
