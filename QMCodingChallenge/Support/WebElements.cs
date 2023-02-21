using Microsoft.Playwright;
using NUnit.Framework.Internal;

namespace QMCodingChallenge.Support
{
    public class WebElements
    {
        private readonly Dictionary<string, string> _webElements;
        public Dictionary<string, string> WebElementsDictionary { get { return _webElements; } }
        public WebElements()
        {
            _webElements = new Dictionary<string, string>();

            #region URLs

            _webElements.Add("Main Page URL", "https://qualityminds.com/");
            _webElements.Add("Main Page De URL", "https://qualityminds.com/de/");
            _webElements.Add("Automatisiertes Testen Page URL", "https://qualityminds.com/de/portfolio/qa-kernkompetenzen/automatisiertes-testen/");
            _webElements.Add("Test Automation Page URL", "https://qualityminds.com/services/core-qa-services/test-automation/");
            _webElements.Add("Events Page URL", "https://qualityminds.com/events/");
            _webElements.Add("Stellenangebote Page URL", "https://qualityminds.com/de/karriere/stellenangebote/");

            #endregion

            #region Main Page

            // Cookie banner
            _webElements.Add("Accept Cookies", "//button[contains(@class,'cmplz-accept')]");
            _webElements.Add("Cookie Banner", "//div[contains(@class,'cookiebanner')]");

            // Top bar - Services Menu
            const string servicesMenu = "//ul[@id='top-menu']/li[contains(@class,'mega-menu')]";
            const string servicesMenuHovered = "//ul[@id='top-menu']/li[contains(@class,'mega-menu') and contains(@class,'et-hover')]";
            _webElements.Add("Services Menu", servicesMenu);
            _webElements.Add("Portfolio Menu", servicesMenu);
            _webElements.Add("Services Menu Hovered", servicesMenuHovered);
            _webElements.Add("Portfolio Menu Hovered", servicesMenuHovered);
            // Top bar - Services Menu - Submenu
            _webElements.Add("Automatisiertes Testen", "text=Automatisiertes Testen");
            _webElements.Add("Test Automation", "text=Test Automation");
            // Top bar - Services Menu - Buttons texts
            _webElements.Add("Services Menu Text En", "SERVICES");
            _webElements.Add("Services Menu Text De", "PORTFOLIO");
            _webElements.Add("Services Menu Text Pl", "USŁUGI");

            // Top bar - About Us Menu
            _webElements.Add("About Us Menu", "//ul[@id='top-menu']//a[.='ABOUT US']/parent::li");
            _webElements.Add("About Us Menu Hovered", "//ul[@id='top-menu']//a[.='ABOUT US']/parent::li[contains(@class,'et-hover')]");
            //_webLocators.Add("Events", "");

            // Top bar - Career Menu
            //_webLocators.Add("Career Menu", "//ul[@id='top-menu']//a[.='CAREER']/parent::li");
            //_webLocators.Add("Karriere Menu", "//ul[@id='top-menu']//a[.='KARRIERE']/parent::li");
            _webElements.Add("Career Menu", "text=CAREER");
            _webElements.Add("Karriere Menu", "text=KARRIERE");

            // Top bar - Language Menu
            _webElements.Add("Language Menu", "//ul[@id='top-menu']/li[contains(@class,'current-language')]");
            _webElements.Add("Language Menu Hovered", "//ul[@id='top-menu']/li[contains(@class,'current-language') and contains(@class,'et-hover')]");
            _webElements.Add("English Flag", "//ul[@id='top-menu']/li/ul/li[contains(@class,'item-en')]");
            _webElements.Add("German Flag", "//ul[@id='top-menu']/li/ul/li[contains(@class,'item-de')]");
            _webElements.Add("Polish Flag", "//ul[@id='top-menu']/li/ul/li[contains(@class,'item-pl')]");

            #endregion

            #region Test Automation Page


            //_webLocators.Add("", "");
            //_webLocators.Add("", "");

            #endregion

            #region Events Page
            /*            _webLocators.Add("", "");
                        _webLocators.Add("", "");
                        _webLocators.Add("", "");
                        _webLocators.Add("", "");*/

            #endregion

            #region Job Offers Page
            _webElements.Add("Job Offer Elements", "//div[contains(@class,'job-listing-item')]");
            _webElements.Add("First Job Offer Element", "(//div[contains(@class,'job-listing-item')])[1]");
            _webElements.Add("First Job Offer View More Button", "(//div[contains(@class,'job-listing-item')])[1]//span[contains(@class,'job-more')]");
            //_webLocators.Add("", "");

        #endregion

        #region Empty Page

        #endregion
    }
    public string GetValue(string key)
    {
        string searchedElement;
        try
        {
            searchedElement = WebElementsDictionary[key];
            return searchedElement;
        }
        catch
        {
            throw new Exception($"Key '{key}' not found.");
        }
    }
}
}