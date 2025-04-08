# ClassUploadSolution

這是一個使用 **Test-Driven Development（TDD）** 概念建立的 C# 專案，目的是實作一個可以上傳 `.cs` 類別檔案並檢查其是否能成功編譯的功能，並透過單元測試驗證其正確性與穩定性。

---

## 🧪 TDD（Test-Driven Development）簡介

TDD 是一種軟體開發流程，主要流程為：

1. ✍️ **撰寫測試**：先定義期望的行為與結果（即撰寫失敗的測試）
2. 💻 **實作功能**：撰寫能讓測試通過的最少程式碼
3. 🔧 **重構與優化**：改善程式碼品質，同時保持測試通過

這個專案中，採用 `xUnit` 撰寫測試，確保：
- 上傳的 `.cs` 類別檔案可以成功被動態編譯
- 錯誤的語法會回傳適當的錯誤訊息

---

## 📁 專案結構說明
ClassUploadSolution/ 
├── ClassUploadSolution.sln # Visual Studio 解決方案檔案 
├── ClassUploadTester/ # 主程式專案 │ 
├── ClassUploadTester.csproj 
│ └── FileCompiler.cs # 處理類別檔案編譯邏輯 
└── ClassUploadTester.Tests/ # 單元測試專案 
├── ClassUploadTester.Tests.csproj 
└── FileCompilerTests.cs # 測試 FileCompiler 功能

