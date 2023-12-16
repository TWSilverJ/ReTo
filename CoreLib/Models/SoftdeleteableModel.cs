using ReTo.Abstractions.Models;

namespace ReTo.CoreLib.Models;

internal class SoftdeleteableModel : Model, ISoftdeleteableModel
{
    public DateTime? DeletedAt { get; }
}
