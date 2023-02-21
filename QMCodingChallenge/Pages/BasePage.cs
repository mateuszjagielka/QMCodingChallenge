using Microsoft.Playwright;
using QMCodingChallenge.Support;

namespace QMCodingChallenge.Pages
{
    public abstract class BasePage
    {
        public readonly WebElements _webElements = new WebElements();
        public abstract string PagePath { get; }

        public abstract IPage Page { get; set; }

        public abstract IBrowser Browser { get; }
        public ILocatorAssertions Expect(ILocator locator) => Assertions.Expect(locator);
        public IPageAssertions Expect(IPage page) => Assertions.Expect(page);
        public IAPIResponseAssertions Expect(IAPIResponse response) => Assertions.Expect(response);


        public async Task NavigateAsync()
        {
            Page = await Browser.NewPageAsync();
            await Page.GotoAsync(PagePath);
            await Page.WaitForURLAsync(PagePath);
            await TakeScreenshot();
        }
        public async Task NavigateTostring (string url)
        {
            await Page.GotoAsync(url);
            await Page.WaitForURLAsync(url);
            await TakeScreenshot();
        }

        public async Task TakeScreenshot()
        {
            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "screenshots/TestScreenshot.jpg"
            });
        }

        public async Task ClickButton(string button)
        {
            await Page.ClickAsync(_webElements.GetValue(button));
        }
    }
}
