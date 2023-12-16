namespace Abstractions.Models;

public interface IModel
{
    /// <summary>
    /// 流水號
    /// </summary>
    int SequentialID { get; }

    /// <summary>
    /// 唯一識別碼
    /// </summary>
    Guid ID { get; }

    /// <summary>
    /// 建立時間
    /// </summary>
    /// <remarks>統一由資料存取層產生</remarks>
    DateTime CreatedAt { get; }

    /// <summary>
    /// 最後更新時間
    /// </summary>
    /// <remarks>統一由資料存取層產生</remarks>
    DateTime? UpdatedAt { get; }
}
