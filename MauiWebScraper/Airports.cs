using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;

namespace MauiWebScraper;

public class Airports
{
    public static void ScrapAirports()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        var chromeDriverService = ChromeDriverService.CreateDefaultService();
        var options = new ChromeOptions();
        options.AddArgument("--headless");
        ChromeDriver driver = new(chromeDriverService, options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        driver.Navigate().GoToUrl("https://www.esky.pl/flights/select/roundtrip/ap/wro/mp/mil?departureDate=2023-05-24&returnDate=2023-05-26&pa=1&py=0&pc=0&pi=0&sc=economy");

        var cena = driver.FindElement(By.XPath("/html/body/fsr-app/fsr-flights-search-result/fsr-qsf-layout/section/div/flights-list/div/div[2]/div/div/ul/li[1]/esky-flight-offer-group/div[1]/div[2]/flight-offer-price-info/div/div[1]/div/div[1]/div/esky-offer-price-info/div/esky-price/span[1]")).Text;
        var cena2 = driver.FindElement(By.XPath("/html/body/fsr-app/fsr-flights-search-result/fsr-qsf-layout/section/div/flights-list/div/div[2]/div/div/ul/li[2]/esky-flight-offer-group/div[1]/div[2]/flight-offer-price-info/div/div[1]/div/div[1]/div/esky-offer-price-info/div/esky-price/span[1]")).Text;
    }
}
