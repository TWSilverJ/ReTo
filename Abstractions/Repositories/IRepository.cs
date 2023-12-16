namespace Abstractions.Repositories;

public interface IRepository
{
    /// <summary>
    /// 儲存對資料庫的修改
    /// </summary>
    /// <returns>影響的資料筆數</returns>
    Task<int> SaveChangeAsync();
}
