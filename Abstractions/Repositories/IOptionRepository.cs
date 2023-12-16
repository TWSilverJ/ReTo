using ReTo.Abstractions.Models;

namespace ReTo.Abstractions.Repositories;

public interface IOptionRepository : IRepository
{
    #region Query
    /// <summary>
    /// 取得應用程式參數列表
    /// </summary>
    /// <returns>應用程式參數列表</returns>
    Task<IEnumerable<IOption>> GetOptionListAsync();

    /// <summary>
    /// 透過名稱取得參數
    /// </summary>
    /// <param name="name">參數名稱</param>
    /// <returns>參數</returns>
    Task<IOption?> GetOptionByNameAsync(string name);
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
