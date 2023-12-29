using BaseAutomatedTests.PageObjects;
using TechTalk.SpecFlow;
using Microsoft.Extensions.Configuration; 

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
    }
}
