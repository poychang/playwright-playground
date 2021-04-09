using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaywrightSharp;
using System;
using System.IO;
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
            await using var browser = await playwright.Chromium.LaunchAsync(new LaunchOptions { Headless = false, SlowMo = 500 });

            var page = await browser.NewPageAsync();
            var websiteUrl = "http://127.0.0.1:8080/";
            await page.GoToAsync(websiteUrl);
            await page.ClickAsync(".button_submit_padleft");
            await page.ClickAsync("text='手動設定模式(進階)'");
            await page.ClickAsync("#Status_topnav");

#if DEBUG
            var dialogTask = page.WaitForEventAsync(PageEvent.Dialog, args =>
            {
                args.Dialog.DismissAsync();
                return true;
            }, 1000);
#endif
            //await page.ClickAsync("[name='bt_connect']");
            await page.ClickAsync("[name='bt_disconnect']");
#if DEBUG
            await dialogTask;
#endif

            var screenshotsFilePath = Path.Combine(AppContext.BaseDirectory, "screenshots.png");
            await page.ScreenshotAsync(screenshotsFilePath);
            await browser.CloseAsync();

            Assert.IsTrue(File.Exists(screenshotsFilePath));
        }
    }
}
