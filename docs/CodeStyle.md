# Team C# Code Style & Copilot 指南

## 目的
統一團隊 C# 程式風格（命名、格式、使用習慣），讓 Visual Studio、Copilot、CI 都遵循。

## 快速開始
1. 專案根目錄含 .editorconfig，IDE 會自動套用。
2. 看到 IDE 的波浪線或燈泡，依建議修正；命名違規會出 Warning。
3. Copilot 會根據 .editorconfig 生成更符合規範的程式碼。

## 規範摘要
- 型別、方法、屬性、事件：PascalCase
- 欄位、參數、區域變數：camelCase
- 常數（const 欄位）：UPPER_CASE（建議）
- 偏好 ar（當型別明顯）：啟用
- 成員前置限定（this. / 類型.）：一般不需要

完整規則請參見根目錄 .editorconfig。

## 在 Visual Studio 中使用
- Tools > Options > Text Editor > C# > Code Style：可視化調整，並「Generate .editorconfig」輸出到方案。
- 重新命名（Refactor Rename）：使用 Ctrl+R, R，可一次修正命名違規。
- 一鍵修正建議：點擊燈泡（或 Ctrl+.）。

## 與 Copilot 搭配
- Copilot 會讀取目前檔案與專案設定（含 .editorconfig）以產生建議。
- 若建議與規範不符，IDE 的分析器仍會標示；請以 .editorconfig / 分析器為準。

## 可選：加入 StyleCop 強化規範
在專案加入套件：

`ash
dotnet add WebApplication1/WebApplication1.csproj package StyleCop.Analyzers
`

之後可用 .editorconfig 或 stylecop.json 微調規則與嚴重性。

## CI 建議
- 在建置流程啟用 TreatWarningsAsErrors（或提升關鍵規則至 error）確保不帶違規程式碼進主幹。
- 也可加上格式化步驟（dotnet format）。

## 常見問答
- Copilot 能強制規範嗎？
  - 不能強制，但會「傾向」遵循；強制由分析器與 CI 把關。
- 我可以在個人 VS 覆寫設定嗎？
  - 可以，但會被 .editorconfig 覆蓋為團隊標準。