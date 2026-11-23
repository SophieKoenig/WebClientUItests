using Microsoft.Playwright;
using NUnit.Framework;
using Reqnroll;

namespace BaseAutomatedTests.PageObjects
{
    public class OpenWebPageObject : BasePage
    {
        public OpenWebPageObject(BrowserDriver browserDriver) : base(browserDriver) 
        { 
        }

        public async Task EnsurePageIsOpen(string appId)
        {
            var pageUrl = string.Format(TestContext.Parameters.Get("webAppUrl") ?? "https://{0}", appId);
            //if ((await _page).Url != pageUrl)
            {
                await (await _page).GotoAsync(pageUrl, new PageGotoOptions { Timeout = 10000 });
            }
        }
    }
}