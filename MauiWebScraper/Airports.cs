using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MauiWebScraper;

public class Airports
{
    public static void ScrapAirports()
    {
        var files = Directory.GetFiles(FileSystem.Current.AppDataDirectory);
        using var stream = FileSystem.OpenAppPackageFileAsync("chromedriver").Result;
        using var reader = new StreamReader(stream);

        var options = new ChromeOptions();
        options.AddArgument("--headless");
        ChromeDriver driver = new("",options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        driver.Navigate().GoToUrl("https://www.esky.pl/flights/select/roundtrip/ap/wro/mp/mil?departureDate=2023-05-24&returnDate=2023-05-26&pa=1&py=0&pc=0&pi=0&sc=economy");

        var cena = driver.FindElement(By.XPath("/html/body/fsr-app/fsr-flights-search-result/fsr-qsf-layout/section/div/flights-list/div/div[2]/div/div/ul/li[1]/esky-flight-offer-group/div[1]/div[2]/flight-offer-price-info/div/div[1]/div/div[1]/div/esky-offer-price-info/div/esky-price/span[1]")).Text;
        var cena2 = driver.FindElement(By.XPath("/html/body/fsr-app/fsr-flights-search-result/fsr-qsf-layout/section/div/flights-list/div/div[2]/div/div/ul/li[2]/esky-flight-offer-group/div[1]/div[2]/flight-offer-price-info/div/div[1]/div/div[1]/div/esky-offer-price-info/div/esky-price/span[1]")).Text;
    }
}
