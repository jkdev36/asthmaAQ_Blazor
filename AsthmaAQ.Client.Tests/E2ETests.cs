using Microsoft.Playwright;
using System.Threading.Tasks;
using Xunit;

public class E2ETests
{
    [Fact]
    public async Task SearchCity_ShowsAQIData()
    {
        using var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true
        });
        var page = await browser.NewPageAsync();

        // Replace with your local or deployed URL
        await page.GotoAsync("http://localhost:5026/");

        // Enter city
        await page.FillAsync("input[placeholder='Enter city...']", "Dublin");

        // Submit form
        await page.ClickAsync("button:has-text('Search')");

        // Wait for AQI box
        var aqiBox = await page.WaitForSelectorAsync("div:has-text('AQI')");

        Assert.NotNull(aqiBox);
        var text = await aqiBox.InnerTextAsync();
        Assert.Contains("AQI:", text);

        await browser.CloseAsync();
    }
}
