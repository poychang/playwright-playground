# Playground Playwright

```
npm install --save-dev playwright
```

起手式：

```javascript
const { chromium } = require('playwright');

(async () => {
  const browser = await chromium.launch();
  // Create pages, interact with UI elements, assert values
  await browser.close();
})();
```

## 執行 JavaScript 的指令檔

直接使用 Node.js 來執行即可，執行指令如下：

```bash
node .\src\01_basic-script.js
```

## 執行 TypeScript 的指令檔

此專案有安裝 `ts-node`，可透過 `npx` 來執行，執行指令如下：

```bash
npx ts-node .\src\01_basic-script.ts
```

如果你有將 `ts-node` 安裝在全域環境下，就不用使用 `npx` 直接用 `ts-node` 即可。

關於如何如何直接執行 TypeScript 指令檔，請參考[這篇文章](https://blog.poychang.net/typescript-running-typescript-ts-node/)。
