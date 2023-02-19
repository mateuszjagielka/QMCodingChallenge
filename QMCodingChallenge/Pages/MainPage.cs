using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMCodingChallenge.Pages
{
    public class MainPage : BasePage
    {   
        public override string PagePath => "https://qualityminds.com/";
        public MainPage(IBrowser browser) => Browser = browser;
        public override IPage Page { get; set; }
        public override IBrowser Browser { get; }

        #region Elements
        public ILocator acceptCookiesButton => Page.Locator("//button[contains(@class,'cmplz-accept')]");
        public ILocator languageMenu => Page.Locator("//ul[@id='top-menu']/li[contains(@class,'current-language')]");
        public ILocator languageMenuHovered => Page.Locator("//ul[@id='top-menu']/li[contains(@class,'current-language') and contains(@class,'et-hover')]");


        #endregion
        #region Actions

        public async Task CloseCookieBanner()
        {
            await acceptCookiesButton.ClickAsync();
        }


        public async Task HoverOverMenu(string menu)
        {
            await languageMenu.HoverAsync();
            await languageMenuHovered.WaitForAsync();
            await TakeScreenshot();
        }
        #endregion

        public Task FillInSearchField(string subject) => Page.FillAsync("body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.RNNXgb > div > div.a4bIc > input", subject);

        public async Task ClickOnSearchAsync()
        {
            await Page.ClickAsync("body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.FPdoLc.lJ9FBc > center > input.gNO89b");
            await Page.WaitForURLAsync("");
        }

        public async Task ClickOnSpecFlowLink()
        {
            await Page.ClickAsync("#rso > div:nth-child(1) > div > div > div > div > div > div > div.yuRUbf > a");
            await Page.WaitForURLAsync("");
        }
    }
}
