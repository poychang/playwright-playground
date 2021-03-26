import { chromium } from 'playwright';

(async () => {
    const browser = await chromium.launch({ headless: false, slowMo: 100 });
    const context = await browser.newContext();
    const page = await context.newPage();
    await page.goto('https://www.google.com.tw');
    await page.screenshot({ path: 'screenshot.png' });
    await browser.close();
})();
