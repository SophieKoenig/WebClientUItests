using Microsoft.Playwright;
using NUnit.Framework;
using SpecFlow.Actions.Playwright;

namespace BaseAutomatedTests.PageObjects
{
    public class OpenWebPage : BasePage
    {
        public async Task EnsurePageIsOpen(string appId)
        {
            var pageUrl = string.Format(TextContext.Parameters.Get("webAppUrl"), appId);
            if ((await _page).Url != pageUrl)
            {
                await (await _page).GotoAsync(pageUrl, new PageGotoOptions);
            }
        }
    }
}