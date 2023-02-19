using QMCodingChallenge.Pages;

namespace QMCodingChallenge.StepDefinitions
{
    [Binding]
    public class MainPageSteps
    {
        private readonly MainPage _mainPage;

        public MainPageSteps(MainPage mainPage)
        {
            _mainPage = mainPage;
        }

        [Given(@"QualityMinds main page is opened")]
        public async Task GivenQualityMindsMainPageIsOpened()
        {
            await _mainPage.NavigateAsync();
            await _mainPage.CloseCookieBanner();
        }

        [When(@"I hover over (.*) menu")]
        public async Task WhenIHoverOverMenu(string menu)
        {
            await _mainPage.HoverOverMenu(menu);
        }

        [When(@"I click (.*) button")]
        public async Task WhenIClickAButton(string button)
        {
            throw new PendingStepException();
        }

        [Then(@"QualityMinds main page is opened in (.*)")]
        public async Task ThenQualityMindsMainPageIsOpenedInGerman(string language)
        {
            throw new PendingStepException();
        }
    }
}