using Microsoft.EntityFrameworkCore;
using ReTo.Abstractions.Models;
using ReTo.Abstractions.Repositories;
using ReTo.DataAccess.Dtos;
using ReTo.DataAccess.Models;

namespace ReTo.DataAccess.Repositories;

public class UserRepository(ReToContext context)
    : Repository(context), IUserRepository
{
    private readonly ReToContext _context = context;

    #region Query
    public async Task<IEnumerable<IUser>> GetUserListAsync()
    {
        // 建立查詢語法
        var query = BuildUserQuery();

        // 產生搜尋結果
        return await query.ToListAsync();
    }

    public async Task<IUser?> GetUserByIdAsync(Guid id)
    {
        // 建立查詢語法
        var query = BuildUserQuery()
            .Where(x => x.ID == id);

        // 產生搜尋結果
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IUser?> GetUserByEmailAsync(string email)
    {
        // 建立查詢語法
        var query = BuildUserQuery()
            .Where(x => x.Email == email);

        // 產生搜尋結果
        return await query.FirstOrDefaultAsync();
    }
    #endregion
    #region User
    public async Task AddUserAsync(IUser user)
    {
        // 建立實例
        var entity = new User
        {
            Id = user.ID,
            Name = user.Name,
            Email = user.Email,
            IsEmailVerified = user.IsEmailVerified,
            CreatedAt = GetCurrentDateTime()
        };

        // 加入資料表
        await _context.Users.AddAsync(entity);
    }


    public async Task UpdateUserAsync(IUser user)
    {
        // 取得實例
        var entity = await _context.Users.FindAsync(user.ID);
        if (entity is null)
            return;

        // 更新實例
        entity.Name = user.Name;
        entity.Email = user.Email;
        entity.IsEmailVerified = user.IsEmailVerified;
        entity.UpdatedAt = GetCurrentDateTime();
    }

    public async Task DeleteUserAsync(Guid id, bool isSoft = false)
    {
        // 取得實例
        var entity = await _context.Users.FindAsync(id);
        if (entity is null)
            return;

        // 刪除實例或標記刪除
        if (!isSoft)
            _context.Users.Remove(entity);
        else
            entity.DeletedAt ??= GetCurrentDateTime();
    }

    public async Task RestoreUserAdync(Guid id)
    {
        // 取得實例
        var entity = await _context.Users.FindAsync(id);
        if (entity is null)
            return;

        // 還原軟刪除項目
        entity.DeletedAt = null;
    }
    #endregion

    #region 私有方法
    /// <summary>
    /// 建立 User 查詢語法
    /// </summary>
    /// <returns>Query</returns>
    private IQueryable<UserDto> BuildUserQuery()
    {
        var query = from user in _context.Users.AsNoTracking()
                    select new UserDto
                    {
                        SequentialID = user.SequentialId,
                        ID = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        IsEmailVerified = user.IsEmailVerified,
                        CreatedAt = user.CreatedAt,
                        UpdatedAt = user.UpdatedAt,
                        DeletedAt = user.DeletedAt
                    };
        return query;
    }
    #endregion
}
