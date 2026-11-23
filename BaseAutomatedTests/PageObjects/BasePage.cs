using Microsoft.Playwright;
using Reqnroll;

namespace BaseAutomatedTests.PageObjects
{
    public class BasePage
    {
        public readonly Task<IBrowserContext> _browserContext;
        public readonly Task<ITracing> _tracing;
        public readonly Task<IPage> _page;
        public IDictionary<string, string> Elements = new Dictionary<string, string>();
        public DateTime LastPageUpdate = DateTime.Now;

        public Task<ITracing> Tracing => _tracing;

        public BasePage(BrowserDriver browserDriver)
        {
            try
            {
                Console.WriteLine("Starting browser context creation...");
                _browserContext = CreateBrowserContextAsync(browserDriver.Current);
                Console.WriteLine("Browser context creation task started.");

                _tracing = _browserContext.ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Console.WriteLine($"Error in browser context creation: {t.Exception}");
                        throw t.Exception!.InnerException!;
                    }

                    Console.WriteLine("Browser context created successfully.");
                    return t.Result.Tracing;
                });

                Console.WriteLine("Starting page creation...");
                _page = CreatePageAsync(_browserContext);
                _page.ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Console.WriteLine($"Error in page creation: {t.Exception}");
                    }
                    else
                    {
                        Console.WriteLine("Page created successfully.");
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BasePage constructor: {ex.Message}");
                throw;
            }
        }

        public BasePage(BasePage basePage)
        {
            _browserContext = basePage._browserContext;
            _tracing = basePage._tracing;
            _page = basePage._page;
        }

        private async Task<IBrowserContext> CreateBrowserContextAsync(Task<IBrowser> browserTask)
        {
            if (browserTask == null)
            {
                throw new ArgumentNullException(nameof(browserTask), "The browser task cannot be null.");
            }

            try
            {
                Console.WriteLine("Waiting for browser task to complete...");
                var browser = await browserTask;
                if (browser == null)
                {
                    throw new Exception("The browser instance returned by the task is null.");
                }

                Console.WriteLine("Creating new browser context...");
                var context = await browser.NewContextAsync(new BrowserNewContextOptions());
                if (context == null)
                {
                    throw new Exception("The browser context is null.");
                }

                Console.WriteLine("New browser context created successfully.");
                return context;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating browser context: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw new Exception($"Error creating browser context: {ex.Message}", ex);
            }
        }


        private async Task<IPage> CreatePageAsync(Task<IBrowserContext> browserContextTask)
        {
            if (browserContextTask == null)
            {
                throw new ArgumentNullException(nameof(browserContextTask), "The browser context task cannot be null.");
            }

            try
            {
                Console.WriteLine("Waiting for browser context to complete...");
                var browserContext = await browserContextTask;
                if (browserContext == null)
                {
                    throw new Exception("The browser context is null.");
                }

                Console.WriteLine("Creating new page...");
                var page = await browserContext.NewPageAsync();
                if (page == null)
                {
                    throw new Exception("The created page is null.");
                }

                Console.WriteLine("New page created successfully.");
                return page;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating page: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw new Exception($"Error creating page: {ex.Message}", ex);
            }
        }
    }
}

