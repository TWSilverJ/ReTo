using ReTo.Abstractions.Dtos;
using ReTo.Abstractions.Models;
using ReTo.Abstractions.Repositories;
using ReTo.Abstractions.Services;
using ReTo.CoreLib.Models;

namespace ReTo.CoreLib.Services;

public class ShortUrlService(IShortUrlRepository shortUrlRepository) : IShortUrlService
{
    private readonly IShortUrlRepository _shortUrlRepository = shortUrlRepository;

    public async Task<IShortUrl?> CreateShortUrlAsync(IOriginalUrlDto originalUrlDto)
    {
        // 建立實例
        var shortUrl = new ShortUrl
        {
            ShortCode = string.Empty,
            OriginalUrl = originalUrlDto.Url,
            ClientIP = originalUrlDto.ClientIP,
            UserAgent = originalUrlDto.UserAgent
        };

        // 寫入資料庫
        await _shortUrlRepository.AddShortUrlAsync(shortUrl);
        var changeCount = await _shortUrlRepository.SaveChangeAsync();

        // 回傳實例
        if (changeCount > 0)
            return await _shortUrlRepository.GetShortUrlByIdAsync(shortUrl.ID);
        return null;
    }

    public Task<IShortUrl?> GetShortUrlByIdAsync(Guid id)
        => _shortUrlRepository.GetShortUrlByIdAsync(id);

    public async Task<IShortUrl?> GetShortUrlByShortCodeAsync(string shortCode, IClient client)
    {
        // 取得實例
        var shortUrl = await _shortUrlRepository.GetShortUrlByCodeAsync(shortCode);
        if (shortUrl is null || !shortUrl.IsEnabled)
            return null;

        // TODO: 記錄點擊

        return shortUrl;
    }
}
