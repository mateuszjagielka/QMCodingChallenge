using Microsoft.Playwright;
using TechTalk.SpecFlow;


namespace QMCodingChallenge.Pages
{
    public class MainPage : BasePage
    {   
        public override string PagePath => "https://qualityminds.com/";
        public MainPage(IBrowser browser) => Browser = browser;
        public override IPage Page { get; set; }
        public override IBrowser Browser { get; }

        #region Elements and constants

        // Cookie banner
        public ILocator acceptCookiesButton => Page.Locator("//button[contains(@class,'cmplz-accept')]");
        public ILocator cookieBanner => Page.Locator("//div[contains(@class,'cookiebanner')]");
        

        // Career Menu
        public ILocator careerMenu => Page.Locator("(//ul[@id='top-menu']/li/a)[5]");
        public const string carrerMenuButtonTextEn = "CAREER";
        public const string carrerMenuButtonTextDe = "KARRIERE";
        public const string carrerMenuButtonTextPl = "KARIERA";

        // Language Menu
        public ILocator servicesMenu => Page.Locator("//ul[@id='top-menu']/li[contains(@class,'mega-menu')]");
        public ILocator servicesMenuHovered => Page.Locator("//ul[@id='top-menu']/li[contains(@class,'mega-menu') and contains(@class,'et-hover')]");

        // Language Menu
        public ILocator languageMenu => Page.Locator("//ul[@id='top-menu']/li[contains(@class,'current-language')]");
        public ILocator languageMenuHovered => Page.Locator("//ul[@id='top-menu']/li[contains(@class,'current-language') and contains(@class,'et-hover')]");
        public ILocator languageEnglishButton => Page.Locator("//ul[@id='top-menu']/li/ul/li[contains(@class,'item-en')]");
        public ILocator languageGermanButton => Page.Locator("//ul[@id='top-menu']/li/ul/li[contains(@class,'item-de')]");
        public ILocator languagePolishButton => Page.Locator("//ul[@id='top-menu']/li/ul/li[contains(@class,'item-pl')]");


        #endregion

        #region Actions

        public async Task CloseCookieBanner()
        {
            await acceptCookiesButton.ClickAsync();
            await Expect(cookieBanner).ToBeHiddenAsync();
        }
        public async Task HoverOverMenu(string menu)
        {
            switch (menu) {
                case "Language":
                    await languageMenu.HoverAsync();
                    await languageMenuHovered.WaitForAsync();
                    break;
                case "Portfolio": case "Services":
                    await servicesMenu.HoverAsync();
                    await servicesMenuHovered.WaitForAsync();
                    break;
                default:
                    Console.WriteLine($"Menu '{menu}' not recognized");
                    break;
            }
            await TakeScreenshot();
        }
        public async Task SelectLanguage(string language)
        {
            switch (language) {
                case "English":
                    await languageEnglishButton.ClickAsync();
                    await CheckIfPageLanguageIsCorrect(language);
                    break;
                case "German":
                    await languageGermanButton.ClickAsync();
                    await CheckIfPageLanguageIsCorrect(language);
                    break;
                case "Polish":
                    await languagePolishButton.ClickAsync();
                    await CheckIfPageLanguageIsCorrect(language);
                    break;
                default:
                    Console.WriteLine($"Language '{language}' not recongnized");
                    break;
            }
            await TakeScreenshot();
        }
        public async Task CheckIfPageLanguageIsCorrect(string language)
        {
            string? obtainedCareerButtonText = await careerMenu.TextContentAsync();
            if (obtainedCareerButtonText != null) {
                switch (obtainedCareerButtonText) {
                    case carrerMenuButtonTextEn:
                        language.Should().Be("English");
                        break;
                    case carrerMenuButtonTextDe:
                        language.Should().Be("German");
                        break;
                    case carrerMenuButtonTextPl:
                        language.Should().Be("Polish");
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
        public Task FillInSearchField(string subject) => Page.FillAsync("body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.RNNXgb > div > div.a4bIc > input", subject);
    }
}
