using Microsoft.Playwright;
using TechTalk.SpecFlow;


namespace QMCodingChallenge.Pages
{
    public class JobOffersPage : MainPage
    {
        public override string PagePath => "https://qualityminds.com/de/karriere/stellenangebote";
        public JobOffersPage(IBrowser browser) : base(browser)
        {
            Browser = browser;
        }
        public override IPage Page { get; set; }
        public override IBrowser Browser { get; }

        #region Elements and constants

        // Job offers
        public ILocator jobOfferElements => Page.Locator(_webElements.GetValue("Job Offer Elements"));
        public ILocator firstJobOfferElement => Page.Locator(_webElements.GetValue("First Job Offer Element"));
        public ILocator firstJobOfferViewMoreButton => Page.Locator(_webElements.GetValue("First Job Offer View More Button"));




        #endregion

        #region Actions

        public async Task CheckIfPageContainsAtLeastOneJobOffer(int count)
        {
            int jobOffersCount = await jobOfferElements.CountAsync();
            jobOffersCount.Should().BeGreaterThanOrEqualTo(count);
            //await Expect(jobOfferElements).Not.ToHaveCountAsync(0);
        }

        #endregion
    }
}
