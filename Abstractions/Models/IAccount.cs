namespace Abstractions.Models;

public interface IAccount : ISoftdeleteableModel
{
    /// <summary>
    /// 帳號
    /// </summary>
    string Username { get; }

    /// <summary>
    /// 密碼
    /// </summary>
    string Password { get; }

    /// <summary>
    /// 密碼到期日
    /// </summary>
    DateTime? PasswordExpireAt { get; }

    /// <summary>
    /// 是否啟用
    /// </summary>
    bool IsEnabled { get; }
}
