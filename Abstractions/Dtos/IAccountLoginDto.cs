using ReTo.Abstractions.Models;

namespace ReTo.Abstractions.Dtos;

public interface IAccountLoginDto : IClient
{
    /// <summary>
    /// 帳號
    /// </summary>
    string Username { get; }

    /// <summary>
    /// 密碼
    /// </summary>
    string Password { get; }
}
