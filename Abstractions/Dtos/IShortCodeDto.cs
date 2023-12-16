using ReTo.Abstractions.Models;

namespace ReTo.Abstractions.Dtos;

public interface IShortCodeDto : IClient
{
    /// <summary>
    /// 短網址代碼
    /// </summary>
    string ShortCode { get; }
}
