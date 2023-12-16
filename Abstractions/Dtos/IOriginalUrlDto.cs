using ReTo.Abstractions.Models;

namespace ReTo.Abstractions.Dtos;

public interface IOriginalUrlDto : IClient
{
    /// <summary>
    /// 使用者識別碼
    /// </summary>
    Guid? UserID { get; }

    /// <summary>
    /// 網址
    /// </summary>
    string Url { get; }
}
