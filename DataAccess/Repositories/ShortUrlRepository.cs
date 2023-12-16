using Microsoft.EntityFrameworkCore;
using ReTo.Abstractions.Models;
using ReTo.Abstractions.Repositories;
using ReTo.DataAccess.Dtos;
using ReTo.DataAccess.Models;
using System.Net;

namespace ReTo.DataAccess.Repositories;

public class ShortUrlRepository(ReToContext context)
    : Repository(context), IShortUrlRepository
{
    private readonly ReToContext _context = context;

    #region Query
    public async Task<IEnumerable<IShortUrl>> GetShortUrlListAsync()
    {
        var query = BuildShortUrlQuery();
        return await query.ToListAsync();
    }

    public async Task<IShortUrl?> GetShortUrlByIdAsync(Guid id)
    {
        var query = BuildShortUrlQuery()
            .Where(x => x.ID == id);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IShortUrl?> GetShortUrlByCodeAsync(string shortCode)
    {
        var query = BuildShortUrlQuery()
            .Where(x => x.ShortCode == shortCode);
        return await query.FirstOrDefaultAsync();
    }
    #endregion
    #region ShortUrl
    public async Task AddShortUrlAsync(IShortUrl shortUrl)
    {
        // 建立實例
        var entity = new ShortUrl
        {
            Id = shortUrl.ID,
            UserId = shortUrl.UserID,
            ShortCode = shortUrl.ShortCode,
            OriginalUrl = shortUrl.OriginalUrl,
            IsEnabled = shortUrl.IsEnabled,
            ExpireAt = shortUrl.ExpireAt,
            ClientIp = shortUrl.ClientIP.ToString(),
            CreatedAt = GetCurrentDateTime()
        };

        // 加入資料表
        await _context.ShortUrls.AddAsync(entity);
    }

    public async Task UpdateShortUrlAsync(IShortUrl shortUrl)
    {
        // 取得實例
        var entity = await _context.ShortUrls.FindAsync(shortUrl.ID);
        if (entity is null)
            return;

        // 更新實例
        entity.ShortCode = shortUrl.ShortCode;
        entity.OriginalUrl = shortUrl.OriginalUrl;
        entity.IsEnabled = shortUrl.IsEnabled;
        entity.ExpireAt = shortUrl.ExpireAt;
        entity.UpdatedAt = GetCurrentDateTime();
    }

    public async Task DeleteShortUrlAsync(Guid id, bool isSoft = false)
    {
        // 取得實例
        var entity = await _context.ShortUrls.FindAsync(id);
        if (entity is null)
            return;

        // 刪除實例或標記刪除
        if (!isSoft)
            _context.ShortUrls.Remove(entity);
        else
            entity.DeletedAt ??= GetCurrentDateTime();
    }


    public async Task RestoreShortUrlAsync(Guid id)
    {
        // 取得實例
        var entity = await _context.ShortUrls.FindAsync(id);
        if (entity is null)
            return;

        // 還原軟刪除項目
        entity.DeletedAt = null;
    }
    #endregion

    #region Private Method
    /// <summary>
    /// 建立 ShortUrl 查詢語法
    /// </summary>
    /// <returns>Query</returns>
    private IQueryable<ShortUrlDto> BuildShortUrlQuery()
    {
        var query = from su in _context.ShortUrls.AsNoTracking()
                    select new ShortUrlDto
                    {
                        SequentialID = su.SequentialId,
                        ID = su.Id,
                        ShortCode = su.ShortCode,
                        OriginalUrl = su.OriginalUrl,
                        IsEnabled = su.IsEnabled,
                        ClientIP = IPAddress.Parse(su.ClientIp),
                        CreatedAt = su.CreatedAt,
                        UpdatedAt = su.UpdatedAt,
                        DeletedAt = su.DeletedAt
                    };
        return query;
    }
    #endregion
}
