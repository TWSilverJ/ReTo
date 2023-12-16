using ReTo.Abstractions.Models;

namespace CoreLib.Models;

internal class SoftdeleteableModel : Model, ISoftdeleteableModel
{
    public DateTime? DeletedAt { get; }
}
