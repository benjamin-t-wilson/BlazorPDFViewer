using BlazorPDFViewer.Specs.Common;
using BlazorPDFViewer.Specs.Hooks;
using BlazorPDFViewer.Specs.Pages;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;

namespace BlazorPDFViewer.Specs.Steps
{
    [Binding]
    public class ChangePageSteps
    {
        private readonly IndexPage _indexPage;

        public ChangePageSteps(ScenarioContext scenarioContext)
        {
            _indexPage = new IndexPage(WebDriverHooks.GetDriver(scenarioContext));
        }

        [Given(@"I click the next page button")]
        public void GivenIClickTheNextPageButton()
        {
            ActionWaits.PageWait(() => _indexPage.NextPageButton.Click());
        }

        [Given(@"I click the thumbnail for page (.*)")]
        public void GivenIClickTheThumbnailForPage(int p0)
        {
            ActionWaits.PageWait(() => _indexPage.Thumbnails.ElementAt(p0).Click());
        }

        [Then(@"the page number will increase to 2")]
        public void ThenThePageNumberWillIncrease()
        {
            Assert.AreEqual(_indexPage.PageIndex.GetAttribute("value"), "2");
        }

        [Then(@"the page number will reflect (.*)")]
        public void ThenThePageNumberWillReflect(int p0)
        {
            Assert.AreEqual(_indexPage.PageIndex.GetAttribute("value"), p0.ToString());
        }
    }
}