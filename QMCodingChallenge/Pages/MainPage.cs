using Microsoft.Playwright;
using QMCodingChallenge.Support;
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
        public ILocator acceptCookiesButton => Page.Locator(_webElements.GetValue("Accept Cookies"));
        public ILocator cookieBanner => Page.Locator(_webElements.GetValue("Cookie Banner"));

        // Services Menu
        public ILocator servicesMenu => Page.Locator(_webElements.GetValue("Services Menu"));
        public ILocator servicesMenuHovered => Page.Locator(_webElements.GetValue("Services Menu Hovered"));
        public ILocator portfolioMenu => Page.Locator(_webElements.GetValue("Portfolio Menu"));
        public ILocator portfolioMenuHovered => Page.Locator(_webElements.GetValue("Portfolio Menu Hovered"));

        // About Us Menu
        public ILocator aboutUsMenu => Page.Locator(_webElements.GetValue("About Us Menu"));
        public ILocator aboutUsMenuHovered => Page.Locator(_webElements.GetValue("About Us Menu Hovered"));

        // Career Menu
        public ILocator careerMenu => Page.Locator(_webElements.GetValue("Career Menu"));

        // Language Menu
        public ILocator languageMenu => Page.Locator(_webElements.GetValue("Language Menu"));
        public ILocator languageMenuHovered => Page.Locator(_webElements.GetValue("Language Menu Hovered"));
        public ILocator languageEnglishButton => Page.Locator(_webElements.GetValue("English Flag"));
        public ILocator languageGermanButton => Page.Locator(_webElements.GetValue("German Flag"));
        public ILocator languagePolishButton => Page.Locator(_webElements.GetValue("Polish Flag"));



        #endregion

        #region Actions

        public async Task CloseCookieBanner()
        {
            await acceptCookiesButton.ClickAsync();
            await Expect(cookieBanner).ToBeHiddenAsync();
        }
        public async Task HoverOverMenu(string menu)
        {
            switch (menu)
            {
                case "Portfolio":
                case "Services":
                    await servicesMenu.HoverAsync();
                    break;
                case "Language":
                    await languageMenu.HoverAsync();
                    break;
                case "About Us":
                    await aboutUsMenu.HoverAsync();
                    break;
                default:
                    throw new Exception($"Menu '{menu}' not recognized");
            }
        }
        public async Task IsSubmenuDisplayedAfterHover(string menu)
        {
            switch (menu)
            {
                case "About Us":
                    await aboutUsMenuHovered.WaitForAsync();
                    break;
                default:
                    throw new Exception($"Menu '{menu}' not recognized");
            }
        }
        public async Task IsPageLanguageCorrect(string language)
        {
            switch (language)
            {
                case "English":
                    await Expect(servicesMenu).ToContainTextAsync(_webElements.GetValue("Services Menu Text En"));
                    break;
                case "German":
                    await Expect(servicesMenu).ToContainTextAsync(_webElements.GetValue("Services Menu Text De"));
                    break;
                case "Polish":
                    await Expect(servicesMenu).ToContainTextAsync(_webElements.GetValue("Services Menu Text Pl"));
                    break;
                default:
                    throw new Exception($"Language '{language}' not recognized");
            }
        }
        public async Task CurrentUrlIs(string url)
        {
            await Page.WaitForURLAsync(url);
        }
        public async Task IsSelectedPageOpened(string page)
        {
            page += " Page URL";
            await Expect(Page).ToHaveURLAsync(_webElements.GetValue(page));
        }

        #endregion
    }
}
