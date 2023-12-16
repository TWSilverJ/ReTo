namespace ReTo.Abstractions.Models;

public interface ISoftdeleteableModel : IModel
{
    /// <summary>
    /// 刪除時間
    /// </summary>
    public DateTime? DeletedAt { get; }
}
