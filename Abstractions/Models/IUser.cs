namespace ReTo.Abstractions.Models;

public interface IUser : ISoftdeleteableModel
{
    /// <summary>
    /// 名稱
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// 電子信箱
    /// </summary>
    string Email { get; set; }

    /// <summary>
    /// 是否驗證信箱
    /// </summary>
    bool IsEmailVerified { get; set; }
}
