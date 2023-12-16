using ReTo.Abstractions.Dtos;
using ReTo.Abstractions.Models;

namespace ReTo.Abstractions.Services;

public interface IUserService
{
    /// <summary>
    /// 建立使用者
    /// </summary>
    /// <param name="userDto">DTO</param>
    /// <returns>使用者</returns>
    Task<IUser?> CreateUserAsync(IUserDto userDto);

    /// <summary>
    /// 更新使用者資料
    /// </summary>
    /// <param name="userDto">DTO</param>
    /// <returns>操作結果</returns>
    Task<bool?> UpdateUserAsync(IUserDto userDto);
}
