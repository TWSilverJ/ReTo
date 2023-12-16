namespace ReTo.Abstractions.Models;

public interface IPasswordLog : IModel, IClient
{
    /// <summary>
    /// 使用者識別碼
    /// </summary>
    Guid UserID { get; }

    /// <summary>
    /// 登入時間
    /// </summary>
    DateTime ChangeTime { get; }

    /// <summary>
    /// 原始密碼
    /// </summary>
    string OriginalPassword { get; }
}
