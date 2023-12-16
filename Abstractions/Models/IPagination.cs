namespace ReTo.Abstractions.Models;

public interface IPagination
{
    /// <summary>
    /// 目標頁碼
    /// </summary>
    int PageNumber { get; set; }

    /// <summary>
    /// 單頁數量
    /// </summary>
    int PageSize { get; set; }

    /// <summary>
    /// 資料總數
    /// </summary>
    int TotalCount { get; set; }
}
