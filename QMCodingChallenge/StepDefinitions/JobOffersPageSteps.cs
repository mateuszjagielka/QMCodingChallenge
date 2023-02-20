using QMCodingChallenge.Pages;

namespace QMCodingChallenge.StepDefinitions
{
    [Binding]
    public class JobOffersPageSteps
    {
        private readonly JobOffersPage _jobOffersPage;

        public JobOffersPageSteps(JobOffersPage jobOffersPage)
        {
            _jobOffersPage = jobOffersPage;
        }

        [Given(@"QualityMinds job offers page is opened")]
        public async Task GivenQualityMindsJobOffersPageIsOpened()
        {
            await _jobOffersPage.NavigateAsync();
            await _jobOffersPage.CloseCookieBanner();
        }
    }
}