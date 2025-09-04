namespace WebApplication1
{
    public class TestFormatting
    {
        private string fieldName;
        private int fieldValue;

        public TestFormatting()
        {
            // 這些 this. 限定符應該在存檔時被自動移除
            this.fieldName = "test";
            this.fieldValue = 42;
        }

        public void TestMethod()
        {
            // 這些 this. 限定符也應該被移除
            Console.WriteLine(this.fieldName);
            Console.WriteLine(this.fieldValue.ToString());
        }
    }
}

// 自動排版及程式碼整理
// 工具 > 選項> 文字編輯器 > 程式碼清除 > 設定程式碼清除
//但排版和自動修正，會依據 .editorconfig ，但程式碼清除的profile 存在
//Windows: % USERPROFILE %\AppData\Local\Microsoft\VisualStudio\<version>\CodeCleanupProfiles.json
//Mac: ~/ Library / Preferences / VisualStudio /< version >/ CodeCleanupProfiles.json