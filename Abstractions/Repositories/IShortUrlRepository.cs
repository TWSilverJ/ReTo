using ReTo.Abstractions.Models;

namespace ReTo.Abstractions.Repositories;

public interface IShortUrlRepository : IRepository
{
    #region Query
    /// <summary>
    /// 取得縮網址列表
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<IShortUrl>> GetShortUrlListAsync();

    /// <summary>
    /// 透過 ID 取得縮網址
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    /// <returns>縮網址</returns>
    Task<IShortUrl?> GetShortUrlByIdAsync(Guid id);

    /// <summary>
    /// 透過代碼取得縮網址
    /// </summary>
    /// <param name="shortCode">代碼</param>
    /// <returns>縮網址</returns>
    Task<IShortUrl?> GetShortUrlByCodeAsync(string shortCode);
    #endregion
    #region ShortUrl
    /// <summary>
    /// 新增縮網址
    /// </summary>
    /// <param name="shortUrl">縮網址</param>
    Task AddShortUrlAsync(IShortUrl shortUrl);

    /// <summary>
    /// 更新縮網址
    /// </summary>
    /// <param name="shortUrl">縮網址</param>
    Task UpdateShortUrlAsync(IShortUrl shortUrl);

    /// <summary>
    /// 刪除縮網址
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    /// <param name="isSoft">是否軟刪除</param>
    Task DeleteShortUrlAsync(Guid id, bool isSoft = false);

    /// <summary>
    /// 恢復軟刪除縮網址
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    Task RestoreShortUrlAsync(Guid id);
    #endregion
}
