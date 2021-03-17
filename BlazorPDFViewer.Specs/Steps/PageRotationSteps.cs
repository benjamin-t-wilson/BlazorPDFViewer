using BlazorPDFViewer.Specs.Common;
using BlazorPDFViewer.Specs.Hooks;
using BlazorPDFViewer.Specs.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BlazorPDFViewer.Specs.Steps
{
    [Binding]
    public class PageRotationSteps
    {
        private readonly IndexPage _indexPage;
        private readonly string _originalHeight;
        private readonly string _originalWidth;

        public PageRotationSteps(ScenarioContext scenarioContext)
        {
            _indexPage = new IndexPage(WebDriverHooks.GetDriver(scenarioContext));
            _originalHeight = _indexPage.MainCanvas.GetAttribute("height");
            _originalWidth = _indexPage.MainCanvas.GetAttribute("width");
        }

        [Given(@"I click the rotate button")]
        public void GivenIClickTheRotateButton()
        {
            ActionWaits.ApiWait(() => _indexPage.RotateCWButton.Click());
        }

        [Then(@"the page will have rotated 90 degrees")]
        public void ThenThePageWillHaveRotatedDegrees()
        {
            Assert.AreEqual(_originalWidth, _indexPage.MainCanvas.GetAttribute("height"));
            Assert.AreEqual(_originalHeight, _indexPage.MainCanvas.GetAttribute("width"));
        }
    }
}