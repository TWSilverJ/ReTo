using ReTo.Abstractions.Dtos;
using ReTo.Abstractions.Models;
using ReTo.Abstractions.Repositories;
using ReTo.Abstractions.Services;
using ReTo.CoreLib.Models;

namespace ReTo.CoreLib.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<IUser?> CreateUserAsync(IUserDto userDto)
    {
        // 建立實例
        var user = new User
        {
            Name = userDto.Name,
            Email = userDto.Email
        };

        // 寫入資料庫
        await _userRepository.AddUserAsync(user);
        var changeCount = await _userRepository.SaveChangeAsync();

        // 回傳實例
        if (changeCount > 0)
            return await _userRepository.GetUserByIdAsync(user.ID);
        return null;
    }

    public async Task<bool?> UpdateUserAsync(Guid id, IUserDto userDto)
    {
        // 取得實例
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user is null)
            return null;

        // 更新實例
        user.Name = userDto.Name;

        // 寫入資料庫
        await _userRepository.UpdateUserAsync(user);
        var changeCount = await _userRepository.SaveChangeAsync();
        return changeCount > 0;
    }
}
