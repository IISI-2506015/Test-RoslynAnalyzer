namespace WebApplication1;

public class InvalidDto
{
    public string Name { get; set; } = string.Empty;
    // 這個類別沒有以 Dto 結尾，應該會觸發錯誤
}
