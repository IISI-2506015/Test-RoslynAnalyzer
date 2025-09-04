using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    // Visual Studio 內建的「Fix All」功能
    // 把滑鼠移到 Analyzer 提示的小燈泡（或按 Ctrl+.）。
    // 選擇其中一個修正選項。
    // 在選單裡會出現 「Fix all occurrences in:」，你可以選：
    // Document（只修正目前檔案）
    // Project（整個專案）
    // Solution（整個解決方案）
    // P.S. 也能在 CICD 時 操作cli ，自動建置時修正
    public IActionResult index()
    {
        return View();


    }


    // 幫我寫一個攝氏轉華式的方法 => 只有在Copliot Chat  才會依據 指引及範例來寫程式碼，intellisense不會，除非寫在這個檔案註解裡面


}


