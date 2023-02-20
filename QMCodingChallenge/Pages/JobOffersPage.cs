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

        // Cookie banner
        public ILocator abc => Page.Locator("");


        #endregion

        #region Actions

        public async Task CloseCookieBannerdsada()
        {
            await acceptCookiesButton.ClickAsync();
            await Expect(cookieBanner).ToBeHiddenAsync();
            await TakeScreenshot();
        }
        public async Task CheckIfPageLanguageIsCorrect4234(string language)
        {
            string? obtainedCareerButtonText = await careerMenu.TextContentAsync();
            if (obtainedCareerButtonText != null) {
                switch (obtainedCareerButtonText) {
                    case careerMenuButtonTextEn:
                        language.Should().Be("English");
                        break;
                    case careerMenuButtonTextDe:
                        language.Should().Be("German");
                        break;
                    case careerMenuButtonTextPl:
                        language.Should().Be("Polish");
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}
