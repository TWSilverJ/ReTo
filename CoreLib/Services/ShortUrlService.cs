using ReTo.Abstractions.Dtos;
using ReTo.Abstractions.Models;
using ReTo.Abstractions.Repositories;
using ReTo.Abstractions.Services;
using ReTo.CoreLib.Models;
using ReTo.CoreLib.Utilities;

namespace ReTo.CoreLib.Services;

public class ShortUrlService(IShortUrlRepository shortUrlRepository) : IShortUrlService
{
    private const short GenerateCodeAttemptsCount = 1000;
    private const short ShortCodeLength = 7;
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

        // 產生縮網址代碼並寫入資料庫
        shortUrl.ShortCode = await GenerateShortCodeAsync();
        await _shortUrlRepository.AddShortUrlAsync(shortUrl);
        var changeCount = await _shortUrlRepository.SaveChangeAsync();

        // 回傳實例
        return changeCount > 0
            ? await _shortUrlRepository.GetShortUrlByIdAsync(shortUrl.ID)
            : null;
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

    #region Private Method
    /// <summary>
    /// 產生縮網址代碼
    /// </summary>
    /// <returns>縮網址代碼</returns>
    /// <exception cref="TimeoutException">嘗試次數超過限制。</exception>
    private async Task<string> GenerateShortCodeAsync()
    {
        for (int i = 0; i < GenerateCodeAttemptsCount; i++)
        {
            string shortCode = RandomMagic.GenerateRandomString(ShortCodeLength);
            var shortUrl = await _shortUrlRepository.GetShortUrlByCodeAsync(shortCode);
            if (shortUrl is null)
                return shortCode;
        }

        throw new TimeoutException("Failed to generate a unique short code after multiple attempts.");
    }

    #endregion
}
