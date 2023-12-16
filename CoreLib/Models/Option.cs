using ReTo.Abstractions.Models;

namespace ReTo.CoreLib.Models;

internal class Option : Model, IOption
{
    public string Name { get; set; }

    public string? Value { get; set; }

    public Guid? UpdaterID { get; set; }
}
