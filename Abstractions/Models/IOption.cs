namespace ReTo.Abstractions.Models;

public interface IOption : IModel
{
    /// <summary>
    /// 參數名稱
    /// </summary>
    string Name { get; }

    /// <summary>
    /// 參數值
    /// </summary>
    string? Value { get; }

    /// <summary>
    /// 最後修改者
    /// </summary>
    Guid? UpdaterID { get; }
}
