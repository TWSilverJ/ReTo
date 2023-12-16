using ReTo.Abstractions.Repositories;
using ReTo.DataAccess.Models;

namespace ReTo.DataAccess.Repositories;

public class Repository(ReToContext context) : IRepository
{
    private readonly ReToContext _context = context;

    public Task<int> SaveChangeAsync()
        => _context.SaveChangesAsync();

    /// <summary>
    /// 取得當前時間
    /// </summary>
    /// <returns>當前時間</returns>
    protected static DateTime GetCurrentDateTime()
        => DateTime.UtcNow;
}
