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

    /// <summary>
    /// 透過 ID 取得帳戶
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    /// <returns>帳戶</returns>
    Task<IAccount?> GetAccountByIdAsync(Guid id);

    /// <summary>
    /// 透過帳號取得帳戶
    /// </summary>
    /// <param name="username">帳號</param>
    /// <returns>帳戶</returns>
    Task<IAccount?> GetAccountByUsernameAsync(string username);

    /// <summary>
    /// 取得登入記錄列表
    /// </summary>
    /// <param name="userId">使用者識別碼</param>
    /// <returns>登入記錄列表</returns>
    Task<IEnumerable<ILoginLog>> GetLoginLogAsync(Guid? userId);

    /// <summary>
    /// 透過 ID 取得登入記錄
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    /// <returns>登入記錄</returns>
    Task<ILoginLog?> GetLoginLogByIdAsync(Guid id);

    /// <summary>
    /// 取得密碼變更記錄列表
    /// </summary>
    /// <param name="userId">使用者識別碼</param>
    /// <returns>密碼變更記錄列表</returns>
    Task<IEnumerable<IPasswordLog>> GetPasswordLogList(Guid? userId);
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
    #region UserAccount
    /// <summary>
    /// 建立帳號
    /// </summary>
    /// <param name="account">帳號</param>
    Task AddAccountAsync(IAccount account);

    /// <summary>
    /// 更新帳號
    /// </summary>
    /// <param name="account">帳號</param>
    Task UpdateAccountAsync(IAccount account);

    /// <summary>
    /// 刪除帳號
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    /// <param name="isSoft">是否軟刪除</param>
    Task DeleteAccountAsync(Guid id, bool isSoft = false);

    /// <summary>
    /// 恢復軟刪除帳號
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    Task RestoreAccountAdync(Guid id);
    #endregion
    #region UserLogin
    /// <summary>
    /// 建立登入記錄
    /// </summary>
    /// <param name="loginLog">登入記錄</param>
    Task AddLoginLogAsync(ILoginLog loginLog);

    /// <summary>
    /// 更新登入記錄
    /// </summary>
    /// <param name="loginLog">登入記錄</param>
    Task UpdateLoginLogAsync(ILoginLog loginLog);
    #endregion
    #region UserPasswordLog
    /// <summary>
    /// 建立密碼變更記錄
    /// </summary>
    /// <param name="passwordLog">密碼變更記錄</param>
    Task AddPasswordLogAsync(IPasswordLog passwordLog);
    #endregion
}
