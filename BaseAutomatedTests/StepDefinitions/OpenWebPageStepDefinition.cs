using BaseAutomatedTests.PageObjects;
using Reqnroll;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace BaseAutomatedTests.StepDefinitions
{
    [Binding]
    public class OpenWebPageStepDefinition
    {
        public OpenWebPageObject _openWebPageObject;
        public OpenWebPageStepDefinition(OpenWebPageObject openTheWebPage) { 
            _openWebPageObject = openTheWebPage;
        }

        [StepDefinition(@"go to '([^']*)'")]
        public async Task GoToWebPage(string appUrl)
        {
            try
            {

                string? baseDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;

                if(baseDirectory is null)
                    throw new Exception("Could not resolve base directory.");
                string configFilePath = Path.Combine(baseDirectory, "Config", "config.json");

                var configBuilder = new ConfigurationBuilder()
                        .SetBasePath(baseDirectory)
                        .AddJsonFile(configFilePath);
                IConfigurationRoot configuration = configBuilder.Build();
            }
            catch (System.IO.FileNotFoundException)
            {
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading config file: {ex.Message}");
            }
            
                await _openWebPageObject.EnsurePageIsOpen(appUrl);
        }

        [Then(@"the page title contains ""(.*)""")]
        public async Task TitleContains(string text)
        {
            var page = await _openWebPageObject._page;
            var title = await page.TitleAsync();
            Assert.That(title, Does.Contain(text));
        }
    }
}
