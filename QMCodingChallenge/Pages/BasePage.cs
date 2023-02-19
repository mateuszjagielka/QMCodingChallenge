using Microsoft.Playwright;

namespace QMCodingChallenge.Pages
{
    public abstract class BasePage
    {
        public abstract string PagePath { get; }

        public abstract IPage Page { get; set; }

        public abstract IBrowser Browser { get; }

        public async Task NavigateAsync()
        {
            Page = await Browser.NewPageAsync();
            await Page.GotoAsync(PagePath);
            await Page.WaitForURLAsync(PagePath);
        }

        public async Task TakeScreenshot()
        {
            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "screenshots/TestScreenshot.jpg"
            });
        }
    }
}
