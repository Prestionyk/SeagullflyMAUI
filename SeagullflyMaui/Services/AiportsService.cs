using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Model;
using Syncfusion.Maui.DataSource.Extensions;

namespace SeagullflyMaui.Services;
public class AiportsService : IAiportsService
{
    public async Task<List<Airport>> GetAirports()
    {
        List<Airport> airports = new();

        using var stream = await FileSystem.OpenAppPackageFileAsync("Airports.txt");
        using var reader = new StreamReader(stream);

        var fileAirports = reader.ReadToEnd().Split("\r\n");
        fileAirports.ForEach(airport => airports.Add(new Airport
        {
            FullName = airport,
            Name = airport.Split(" (")[0],
            IATACode = airport.Split(" (")[1].Replace(")", "")
        }));

        return airports;
    }
}
