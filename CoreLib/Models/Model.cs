using ReTo.Abstractions.Models;

namespace CoreLib.Models;

internal class Model : IModel
{
    public int SequentialID { get; }

    public Guid ID { get; } = Guid.NewGuid();

    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; }
}
