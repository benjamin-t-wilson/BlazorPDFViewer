using OpenQA.Selenium;
using System.Collections.Generic;
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
        public IWebElement NextPageButton => webDriver.FindElement(By.Id(PdfViewerSelectors.NextPageButtonId));
        public IWebElement PageIndex => webDriver.FindElement(By.Id(PdfViewerSelectors.CurrentPageInputId));
        public IEnumerable<IWebElement> Thumbnails => webDriver.FindElements(By.ClassName(PdfViewerSelectors.ThumbnailCanvasContainerClass));
        public IWebElement ZoomInButton => webDriver.FindElement(By.Id(PdfViewerSelectors.ZoomInButtonId));
        public IWebElement ZoomOutButton => webDriver.FindElement(By.Id(PdfViewerSelectors.ZoomOutButtonId));
        public IWebElement MainCanvas => webDriver.FindElement(By.Id(PdfViewerSelectors.MainCanvasId));

        public void OpenIndexPage()
        {
            webDriver.Navigate().GoToUrl(@"https://localhost:5001/");
        }
    }
}