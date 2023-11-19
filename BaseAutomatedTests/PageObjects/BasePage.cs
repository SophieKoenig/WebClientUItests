using Microsoft.Playwright;
using SpecFlow.Actions.Playwright;

namespace BaseAutomatedTests.PageObjects
{
    public class BasePage
    {
        public readonly Task<IBrowserContext> _browserContext;
        public readonly Task<ITracing> _tracing;
        public readonly Task<IPage> _page;
        public Interactions _interactions;
        public IDictionary<string, string> Elements = new Dictionary<string, string>();
        public DateTime LastPageUpdate = DateTime.Now;

        public Task<ITracing> Tracing => _tracing;

        public BasePage(BrowserDriver browserDriver)
        {
            _browserContext = CreateBrowserContextAsync(browserDriver.Current);
            _tracing = _browserContext.ContinueWith(t => t.Result.Tracing);
            _page = CreatePageAsync(_browserContext);
            _interactions = new Interactions(_page);
        }

        public BasePage(BasePage basePage)
        {
            _browserContext = basePage._browserContext;
            _tracing = basePage._tracing;
            _page = basePage._page;
            _interactions = new Interactions(_page);
        }

        private async Task<IBrowserContext> CreateBrowserContextAsync(Task<IBrowser> browser)
        {
            return await (await browser).NewContextAsync();
        }

        private async Task<IPage> CreatePageAsync(Task<IBrowserContext> browserContext)
        {
            var page = await (await browserContext).NewPageAsync();
            return page;
        }
    }
}
