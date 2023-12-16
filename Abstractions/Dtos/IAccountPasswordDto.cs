using ReTo.Abstractions.Models;

namespace ReTo.Abstractions.Dtos;

public interface IAccountPasswordDto : IClient
{
    /// <summary>
    /// 密碼
    /// </summary>
    string Password { get; }
}
