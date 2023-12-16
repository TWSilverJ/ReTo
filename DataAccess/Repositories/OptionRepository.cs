using Microsoft.EntityFrameworkCore;
using ReTo.Abstractions.Models;
using ReTo.Abstractions.Repositories;
using ReTo.DataAccess.Dtos;
using ReTo.DataAccess.Models;

namespace ReTo.DataAccess.Repositories;

public class OptionRepository(ReToContext context)
    : Repository(context), IOptionRepository
{
    private readonly ReToContext _context = context;

    #region Query
    public async Task<IEnumerable<IOption>> GetOptionListAsync()
    {
        var query = BuildOptionQuery();
        return await query.ToListAsync();
    }
    #endregion
    #region Options
    public async Task AddOptionAsync(IOption option)
    {
        // 建立實例
        var entity = new Option
        {
            Id = option.ID,
            OptionName = option.Name,
            OptionValue = option.Value,
            CreatedAt = GetCurrentDateTime()
        };

        // 加入資料表
        await _context.Options.AddAsync(entity);
    }

    public async Task UpdateOptionAsync(IOption option)
    {
        // 取得實例
        var entity = await _context.Options.FindAsync(option.ID);
        if (entity is null)
            return;

        // 更新實例
        entity.OptionValue = option.Value;
        entity.UpdatedAt = GetCurrentDateTime();
        entity.UpdaterId = option.UpdaterID;
    }

    public async Task DeleteOptionAsync(Guid id)
    {
        // 取得實例
        var entity = await _context.Options.FindAsync(id);
        if (entity is null)
            return;

        // 刪除實例
        _context.Options.Remove(entity);
    }
    #endregion

    #region Private Method
    /// <summary>
    /// 建立 Option 查詢語法
    /// </summary>
    /// <returns>Query</returns>
    private IQueryable<OptionDto> BuildOptionQuery()
    {
        var query = from option in _context.Options.AsNoTracking()
                    select new OptionDto
                    {
                        SequentialID = option.SequentialId,
                        ID = option.Id,
                        Name = option.OptionName,
                        Value = option.OptionValue,
                        UpdaterID = option.UpdaterId,
                        CreatedAt = option.CreatedAt,
                        UpdatedAt = option.UpdatedAt
                    };
        return query;
    }
    #endregion
}
