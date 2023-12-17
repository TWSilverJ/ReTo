using ReTo.Abstractions.Dtos;
using ReTo.Abstractions.Models;

namespace ReTo.Abstractions.Services;

public interface IAccountService
{
    /// <summary>
    /// 取得帳戶列表
    /// </summary>
    /// <param name="pagination">控制分頁</param>
    /// <returns>帳戶列表</returns>
    Task<IEnumerable<IAccount>> GetAccountListAsync(IPagination pagination);

    /// <summary>
    /// 透過 ID 取得帳戶
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    /// <returns>帳戶</returns>
    Task<IAccount?> GetAccountByIdAsync(Guid id);

    /// <summary>
    /// 建立帳戶
    /// </summary>
    /// <param name="accountDto">DTO</param>
    /// <returns>帳戶</returns>
    Task<IAccount?> CreateAccountAsync(IAccountDto accountDto);

    /// <summary>
    /// 更改密碼
    /// </summary>
    /// <param name="id">唯一識別碼</param>
    /// <param name="passwordDto">DTO</param>
    /// <returns>操作結果</returns>
    Task<bool?> ChangePasswordAsync(Guid id, IAccountPasswordDto passwordDto);

    /// <summary>
    /// 帳戶登入
    /// </summary>
    /// <param name="loginDto">DTO</param>
    /// <returns>帳戶</returns>
    Task<IAccountLogin> LoginAsync(IAccountLoginDto loginDto);

    /// <summary>
    /// 登出單筆登入
    /// </summary>
    /// <param name="loginId">登入識別碼</param>
    /// <returns>操作結果</returns>
    Task<bool?> LogoutAsync(Guid loginId);

    /// <summary>
    /// 登出指定帳戶所有登入
    /// </summary>
    /// <param name="accountId">帳戶識別碼</param>
    /// <returns>操作結果</returns>
    Task<bool?> LogoutAllSessionsAsync(Guid accountId);
}
