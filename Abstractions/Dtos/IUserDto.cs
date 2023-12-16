namespace ReTo.Abstractions.Dtos;

public interface IUserDto
{
    /// <summary>
    /// 名稱
    /// </summary>
    string Name { get; }

    /// <summary>
    /// 電子信箱
    /// </summary>
    string Email { get; }
}
