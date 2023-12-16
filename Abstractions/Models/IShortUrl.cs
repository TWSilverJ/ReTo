namespace Abstractions.Models;

public interface IShortUrl : ISoftdeleteableModel, IClient
{
    /// <summary>
    /// 使用者識別碼
    /// </summary>
    Guid? UserID { get; }

    /// <summary>
    /// 短網址代碼
    /// </summary>
    string ShortCode { get; }

    /// <summary>
    /// 原始網址
    /// </summary>
    string OriginalUrl { get; }

    /// <summary>
    /// 是否啟用
    /// </summary>
    bool IsEnabled { get; }

    /// <summary>
    /// 有效期限
    /// </summary>
    DateTime? ExpireAt { get; }
}
