using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BlazorPDFViewer.Specs.Factories
{
    public static class WebDriverFactory
    {
        public static IWebDriver Default()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");

            return new ChromeDriver(options);
        }
    }
}