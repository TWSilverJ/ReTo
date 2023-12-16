namespace ReTo.Abstractions.Services;

public interface IOptionService
{
    /// <summary>
    /// 讀取應用程式參數
    /// </summary>
    /// <returns>應用程式參數</returns>
    Task<IDictionary<string, string>> GetOptionsAsync();

    /// <summary>
    /// 寫入應用程式參數
    /// </summary>
    /// <param name="options">應用程式參數</param>
    /// <returns>操作結果</returns>
    Task<bool> SetOptionsAsync(IDictionary<string, string> options);
}
