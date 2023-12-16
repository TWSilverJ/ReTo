namespace ReTo.Abstractions.Models;

public interface ILoginLog : IModel, IClient
{
    /// <summary>
    /// 使用者識別碼
    /// </summary>
    Guid? UserID { get; }

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
