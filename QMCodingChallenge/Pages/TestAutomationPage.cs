using Microsoft.Playwright;
using TechTalk.SpecFlow;


namespace QMCodingChallenge.Pages
{
    public class TestAutomationPage : MainPage
    {
        //public override string PagePath => "https://qualityminds.com/de/karriere/stellenangebote";
        public TestAutomationPage(IBrowser browser) : base(browser) => Browser = browser;
        public override IPage Page { get; set; }
        public override IBrowser Browser { get; }

        #region Elements and constants

        public ILocator kontaktiereUnsButton => Page.Locator(_webElements.GetValue("Kontaktiere Uns"));




        #endregion

        #region Actions
        
        public async Task IsButtonLinkedToEmailAddress(string button, string emailAddress)
        {
            string? obtainedLink = await kontaktiereUnsButton.GetAttributeAsync("href");
            if (obtainedLink == null)
                throw new Exception($"Button '{button}' doesn't contain any link.");
            obtainedLink.Should().Contain($"mailto:{emailAddress}");
        }

        #endregion
    }
}
