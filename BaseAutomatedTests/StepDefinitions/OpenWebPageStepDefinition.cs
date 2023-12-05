using BaseAutomatedTests.PageObjects;
using TechTalk.SpecFlow;
using Microsoft.Extensions.Configuration;

namespace BaseAutomatedTests.StepDefinitions
{
    [Binding]
    public class OpenWebPageStepDefinition
    {
        private readonly OpenWebPageObject _openWebPageObject;
        public OpenWebPageStepDefinition(OpenWebPageObject openWebPage) { 
            _openWebPageObject = openWebPage;
        }

        [StepDefinition(@"go to '([^']*)'")]
        public async Task GoToWebPage(string appUrl)
        {
            await _openWebPageObject.EnsurePageIsOpen(appUrl);
        }
    }
}
