using BlazorPDFViewer.Specs.Common;
using BlazorPDFViewer.Specs.Hooks;
using BlazorPDFViewer.Specs.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BlazorPDFViewer.Specs.Steps
{
    [Binding]
    public class ZoomFunctionsSteps
    {
        private readonly IndexPage _indexPage;
        private readonly string _originalHeight;
        private readonly string _originalWidth;

        public ZoomFunctionsSteps(ScenarioContext scenarioContext)
        {
            _indexPage = new IndexPage(WebDriverHooks.GetDriver(scenarioContext));
            _originalHeight = _indexPage.MainCanvas.GetAttribute("height");
            _originalWidth = _indexPage.MainCanvas.GetAttribute("width");
        }

        [Given(@"I click the zoom increase button")]
        public void GivenIClickTheZoomIncreaseButton()
        {
            ActionWaits.PageWait(() => _indexPage.ZoomInButton.Click());
        }

        [Given(@"I click the zoom decrease button")]
        public void GivenIClickTheZoomDecreaseButton()
        {
            ActionWaits.PageWait(() => _indexPage.ZoomOutButton.Click());
        }

        [Then(@"the document will increase in size")]
        public void ThenTheDocumentWillIncreaseInSize()
        {
            Assert.Less(int.Parse(_originalHeight), int.Parse(_indexPage.MainCanvas.GetAttribute("height")));
            Assert.Less(int.Parse(_originalWidth), int.Parse(_indexPage.MainCanvas.GetAttribute("width")));
        }

        [Then(@"the document will decrease in size")]
        public void ThenTheDocumentWillDecreaseInSize()
        {
            Assert.Less(int.Parse(_indexPage.MainCanvas.GetAttribute("height")), int.Parse(_originalHeight));
            Assert.Less(int.Parse(_indexPage.MainCanvas.GetAttribute("width")), int.Parse(_originalWidth));
        }
    }
}