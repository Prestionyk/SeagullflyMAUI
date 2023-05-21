using Newtonsoft.Json;

namespace SeagullflyMaui;

public sealed class Config
{
    private static Config _instance;
    public string SyncfusionLicenseKey { get; set; }
    public string SupportEmailAddress { get; set; }
    public string SMTPCredentials { get; set; }

    public static Config GetInstance()
    {
        if (_instance == null)
        {
            using var stream = FileSystem.OpenAppPackageFileAsync("Config.json").Result;
            using var reader = new StreamReader(stream);

            Config config = JsonConvert.DeserializeObject<Config>(reader.ReadToEnd());
            _instance = config;
        }
        return _instance;
    }
}
