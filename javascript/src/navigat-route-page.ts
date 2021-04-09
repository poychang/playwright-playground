import { chromium } from 'playwright';

(async () => {
    const browser = await chromium.launch({ headless: false, slowMo: 500 });
    const context = await browser.newContext();
    const page = await context.newPage();
    await page.goto('http://127.0.0.1:8080/');
    await page.click('.button_submit_padleft');
    await page.click('text="手動設定模式(進階)"');
    await page.click('#Status_topnav');
    // await page.click('[name="bt_connect"]');
    await page.click('[name="bt_disconnect"]');

    await page.screenshot({ path: 'screenshot.png' });
    await browser.close();
})();
