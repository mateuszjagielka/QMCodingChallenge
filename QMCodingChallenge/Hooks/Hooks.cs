using BoDi;
using Microsoft.Playwright;
using QMCodingChallenge.Pages;
using TechTalk.SpecFlow;

namespace QMCodingChallenge.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        public async Task BeforeScenario(IObjectContainer container)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions {
                Headless = false,
            });
            var mainPage = new MainPage(browser);
            var jobOffersPage = new JobOffersPage(browser);
            container.RegisterInstanceAs(playwright);
            container.RegisterInstanceAs(browser);
            container.RegisterInstanceAs(mainPage);
            container.RegisterInstanceAs(jobOffersPage);
        }

        [AfterScenario]
        public async Task AfterScenario(IObjectContainer container)
        {
            var browser = container.Resolve<IBrowser>();
            await browser.CloseAsync();
            var playwright = container.Resolve<IPlaywright>();
            playwright.Dispose();
        }
    }
}