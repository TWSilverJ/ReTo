using ReTo.Abstractions.Models;

namespace ReTo.Abstractions.Repositories;

public interface IAccountRepository : IRepository
{
    #region Query
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
    /// 取得登入列表
    /// </summary>
    /// <param name="accountId">帳戶識別碼</param>
    /// <returns>登入列表</returns>
    Task<IEnumerable<IAccountLogin>> GetLoginListAsync(Guid? accountId);

    /// <summary>
    /// 透過 ID 取得登入
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    /// <returns>登入</returns>
    Task<IAccountLogin?> GetLoginByIdAsync(Guid id);

    /// <summary>
    /// 取得密碼變更列表
    /// </summary>
    /// <param name="accountId">帳戶識別碼</param>
    /// <returns>密碼變更列表</returns>
    Task<IEnumerable<IAccountPasswordChange>> GetPasswordChangeListAxync(Guid? accountId);
    #endregion
    #region Account
    /// <summary>
    /// 建立帳戶
    /// </summary>
    /// <param name="account">帳戶</param>
    Task AddAccountAsync(IAccount account);

    /// <summary>
    /// 更新帳戶
    /// </summary>
    /// <param name="account">帳戶</param>
    Task UpdateAccountAsync(IAccount account);

    /// <summary>
    /// 刪除帳戶
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    /// <param name="isSoft">是否軟刪除</param>
    Task DeleteAccountAsync(Guid id, bool isSoft = false);

    /// <summary>
    /// 恢復軟刪除帳戶
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    Task RestoreAccountAdync(Guid id);
    #endregion
    #region AccountLogin
    /// <summary>
    /// 建立登入
    /// </summary>
    /// <param name="login">登入</param>
    Task AddLoginAsync(IAccountLogin login);

    /// <summary>
    /// 更新登入
    /// </summary>
    /// <param name="login">登入</param>
    Task UpdateLoginAsync(IAccountLogin login);
    #endregion
    #region AccountPasswordChange
    /// <summary>
    /// 建立密碼變更
    /// </summary>
    /// <param name="passwordChange">密碼變更</param>
    Task AddPasswordChangeAsync(IAccountPasswordChange passwordChange);
    #endregion
}
