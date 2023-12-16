namespace ReTo.Abstractions.Models;

public interface IAccountLogin : IModel, IClient
{
    /// <summary>
    /// 帳戶識別碼
    /// </summary>
    Guid? AccountID { get; }

    /// <summary>
    /// 登入時間
    /// </summary>
    DateTime LoginTime { get; }

    /// <summary>
    /// 是否成功
    /// </summary>
    bool IsSuccessful { get; }

    /// <summary>
    /// 是否作廢
    /// </summary>
    bool IsRevoked { get; }

    /// <summary>
    /// 有效期限
    /// </summary>
    DateTime? ExpireAt { get; }
}
