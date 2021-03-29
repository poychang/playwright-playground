using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaywrightSharp;
using System.Threading.Tasks;

namespace PlaywrightSharpPlayground
{
    [TestClass]
    public class BasicUsage
    {
        [TestMethod]
        public async Task NavigateAndTakeScreenshots()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();

            var page = await browser.NewPageAsync();
            var websiteUrl = "http://www.bing.com";
            var screenshotsFilePath = Path.Combine(AppContext.BaseDirectory, "screenshots.png");
            await page.GoToAsync(websiteUrl);
            await page.ScreenshotAsync(screenshotsFilePath);
            await browser.CloseAsync();

            Assert.IsTrue(File.Exists(screenshotsFilePath));
        }
    }
}
