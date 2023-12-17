using ReTo.Abstractions.Models;

namespace ReTo.Abstractions.Dtos;

public interface IAccountPasswordDto : IClient
{
    /// <summary>
    /// 原始密碼
    /// </summary>
    string OriginalPassword { get; }

    /// <summary>
    /// 新密碼
    /// </summary>
    string NewPassword { get; }
}
