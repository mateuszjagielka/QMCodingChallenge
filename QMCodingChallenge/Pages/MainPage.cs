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

        // Services Menu
        public ILocator servicesMenu => Page.Locator("//ul[@id='top-menu']/li[contains(@class,'mega-menu')]");
        public ILocator servicesMenuHovered => Page.Locator("//ul[@id='top-menu']/li[contains(@class,'mega-menu') and contains(@class,'et-hover')]");

        // Career Menu
        public ILocator careerMenu => Page.Locator("(//ul[@id='top-menu']/li/a)[5]");
        public const string careerMenuButtonTextEn = "CAREER";
        public const string careerMenuButtonTextDe = "KARRIERE";
        public const string careerMenuButtonTextPl = "KARIERA";

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
                    Console.WriteLine($"Language '{language}' not recognized");
                    break;
            }
            await TakeScreenshot();
        }
        public async Task CheckIfPageLanguageIsCorrect(string language)
        {
            switch (language) {
                case "English":
                    await Expect(careerMenu).ToContainTextAsync(careerMenuButtonTextEn);
                    break;
                case "German":
                    await Expect(careerMenu).ToContainTextAsync(careerMenuButtonTextDe);
                    break;
                case "Polish":
                    await Expect(careerMenu).ToContainTextAsync(careerMenuButtonTextPl);
                    break;
                default:
                    throw new Exception($"Language '{language}' not recognized");
            }
        }
        public async Task CurrentUrlIs(string url)
        {
            await Page.WaitForURLAsync(url);
        }

        #endregion
        public Task FillInSearchField(string subject) => Page.FillAsync("body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.RNNXgb > div > div.a4bIc > input", subject);

    }
}
