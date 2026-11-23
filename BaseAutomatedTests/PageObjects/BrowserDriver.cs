using Microsoft.Playwright;

namespace BaseAutomatedTests.PageObjects
{
    public class BrowserDriver
    {
        public Task<IBrowser> Current { get; }
        public BrowserDriver(Task<IBrowser> browser)
        {
            Current = browser;
        }
    }
}