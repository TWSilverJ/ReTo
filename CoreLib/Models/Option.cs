using ReTo.Abstractions.Models;

namespace CoreLib.Models;

internal class Option : Model, IOption
{
    public string Name { get; set; }

    public string? Value { get; set; }

    public Guid? UpdaterID { get; set; }
}
