using BaseAutomatedTests.PageObjects;
using Microsoft.Playwright;
using Reqnroll;
using Reqnroll.BoDi;

namespace BaseAutomatedTests
{
    [Binding]
    public class Hooks
    {
        private IPlaywright? _playwright;
        private IBrowser? _browser;
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Channel = "chrome",
                Args = new[] { "--disable-blink-features=AutomationControlled" }
            });
            var browserDriver = new BrowserDriver(Task.FromResult(_browser));
            _container.RegisterInstanceAs<BrowserDriver>(browserDriver);
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            await _browser?.CloseAsync();
            _playwright?.Dispose();
        }
    }
}