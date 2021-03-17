using BlazorPDFViewer.Specs.Common;
using BlazorPDFViewer.Specs.Hooks;
using BlazorPDFViewer.Specs.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BlazorPDFViewer.Specs.Steps
{
    [Binding]
    public sealed class LoadingModalStepDefinitions
    {
        private readonly IndexPage _indexPage;

        public LoadingModalStepDefinitions(ScenarioContext scenarioContext)
        {
            _indexPage = new IndexPage(WebDriverHooks.GetDriver(scenarioContext));
        }

        [Given(@"I open the index page")]
        public void GivenIOpenTheIndexPage()
        {
            _indexPage.OpenIndexPage();
        }

        [Then(@"A loading modal shows while I wait")]
        public void ThenALoadingModalShowsWhileIWait()
        {
            Assert.IsNotNull(_indexPage.LoadingModal);
            Assert.IsTrue(_indexPage.LoadingModal.Displayed);
        }

        [Given(@"I give the page time to load")]
        public void GivenIGiveThePageTimeToLoad()
        {
            Waits.ApiWait();
        }

        [Then(@"the loading modal will be gone")]
        public void ThenTheLoadingModalWillBeGone()
        {
            Assert.IsNotNull(_indexPage.LoadingModal);
            Assert.IsFalse(_indexPage.LoadingModal.Displayed);
        }

        [Then(@"the pdf window will be present")]
        public void ThenThePdfWindowWillBePresent()
        {
            Assert.IsNotNull(_indexPage.PdfWindow);
            Assert.IsTrue(_indexPage.PdfWindow.Displayed);
        }
    }
}