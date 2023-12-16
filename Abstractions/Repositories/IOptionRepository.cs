using Abstractions.Models;

namespace Abstractions.Repositories;

public interface IOptionRepository
{
    #region Query
    /// <summary>
    /// 取得應用程式參數列表
    /// </summary>
    /// <returns>應用程式參數列表</returns>
    Task<IEnumerable<IOption>> GetOptionListAsync();
    #endregion
    #region Options
    /// <summary>
    /// 新增應用程式參數
    /// </summary>
    /// <param name="option">應用程式參數</param>
    Task AddOptionAsync(IOption option);

    /// <summary>
    /// 更新應用程式參數
    /// </summary>
    /// <param name="option">應用程式參數</param>
    Task UpdateOptionAsync(IOption option);

    /// <summary>
    /// 刪除應用程式參數
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    Task DeleteOptionAsync(Guid id);
    #endregion
}
