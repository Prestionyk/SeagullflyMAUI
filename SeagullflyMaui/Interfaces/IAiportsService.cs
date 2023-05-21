using SeagullflyMaui.Model;

namespace SeagullflyMaui.Interfaces;
public interface IAiportsService
{
    Task<List<Airport>> GetAirports();
}
