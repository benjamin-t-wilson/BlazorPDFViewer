using OpenQA.Selenium;
using static BlazorPDFViewer.Entities.Constants;

namespace BlazorPDFViewer.Specs.Pages
{
    public class IndexPage
    {
        private readonly IWebDriver webDriver;

        public IndexPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement LoadingModal => webDriver.FindElement(By.Id(PdfViewerSelectors.LoadingModalId));
        public IWebElement PdfWindow => webDriver.FindElement(By.Id(PdfViewerSelectors.PdfWindowId));

        public void OpenIndexPage()
        {
            webDriver.Navigate().GoToUrl(@"https://localhost:5001/");
        }
    }
}