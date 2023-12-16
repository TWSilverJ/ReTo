using ReTo.Abstractions.Dtos;
using ReTo.Abstractions.Models;

namespace ReTo.Abstractions.Services;

public interface IShortUrlService
{
    /// <summary>
    /// 產生縮網址
    /// </summary>
    /// <param name="originalUrlDto">DTO</param>
    /// <returns>縮網址</returns>
    Task<IShortUrl?> CreateShortUrlAsync(IOriginalUrlDto originalUrlDto);

    /// <summary>
    /// 透過 ID 取得縮網址
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    /// <returns>縮網址</returns>
    Task<IShortUrl?> GetShortUrlByIdAsync(Guid id);

    /// <summary>
    /// 透過代碼取得縮網址
    /// </summary>
    /// <param name="shortCode">縮網址代碼</param>
    /// <param name="client">客戶端資料</param>
    /// <returns>縮網址</returns>
    Task<IShortUrl?> GetShortUrlByShortCodeAsync(string shortCode, IClient client);
}
