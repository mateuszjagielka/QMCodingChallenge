using QMCodingChallenge.Pages;

namespace QMCodingChallenge.StepDefinitions
{
    [Binding]
    public class TestAutomationPageSteps
    {
        private readonly TestAutomationPage _testAutomationPage;

        public TestAutomationPageSteps(TestAutomationPage testAutomationPage) => _testAutomationPage = testAutomationPage;

        [Then(@"button (Kontaktiere Uns) links to the email address: (.*)")]
        public async Task ThenButtonLinksToTheEmailAddress(string button, string emailAddress)
        {
            await _testAutomationPage.IsButtonLinkedToEmailAddress(button, emailAddress);
        }

    }
}