using ReTo.Abstractions.Models;

namespace ReTo.Abstractions.Repositories;

public interface IUserRepository
{
    #region Query
    /// <summary>
    /// 取得使用者列表
    /// </summary>
    /// <returns>使用者列表</returns>
    Task<IEnumerable<IUser>> GetUserListAsync();

    /// <summary>
    /// 透過 ID 取得使用者
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    /// <returns>使用者</returns>
    Task<IUser?> GetUserByIdAsync(Guid id);

    /// <summary>
    /// 透過 Email 取得使用者
    /// </summary>
    /// <param name="email">電子信箱</param>
    /// <returns>使用者</returns>
    Task<IUser?> GetUserByEmailAsync(string email);
    #endregion
    #region User
    /// <summary>
    /// 建立使用者
    /// </summary>
    /// <param name="user">使用者</param>
    Task AddUserAsync(IUser user);

    /// <summary>
    /// 更新使用者
    /// </summary>
    /// <param name="user">使用者</param>
    Task UpdateUserAsync(IUser user);

    /// <summary>
    /// 刪除使用者
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    /// <param name="isSoft">是否軟刪除</param>
    /// <returns></returns>
    Task DeleteUserAsync(Guid id, bool isSoft = false);

    /// <summary>
    /// 恢復軟刪除使用者
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    Task RestoreUserAdync(Guid id);
    #endregion
}
