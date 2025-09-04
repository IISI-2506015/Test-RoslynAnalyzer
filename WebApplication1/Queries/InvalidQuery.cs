namespace WebApplication1;

public class InvalidQuery
{
    public string QueryText { get; set; } = string.Empty;
    // 這個類別沒有以 Query 結尾，應該會觸發錯誤
}
