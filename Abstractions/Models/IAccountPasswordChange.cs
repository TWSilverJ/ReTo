namespace ReTo.Abstractions.Models;

public interface IAccountPasswordChange : IModel, IClient
{
    /// <summary>
    /// 帳戶識別碼
    /// </summary>
    Guid AccountID { get; }

    /// <summary>
    /// 登入時間
    /// </summary>
    DateTime ChangeTime { get; }

    /// <summary>
    /// 原始密碼
    /// </summary>
    string OriginalPassword { get; }
}
