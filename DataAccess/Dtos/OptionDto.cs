using ReTo.Abstractions.Models;

namespace ReTo.DataAccess.Dtos;

internal class OptionDto : IOption
{
    public int SequentialID { get; set; }

    public Guid ID { get; set; }

    public string Name { get; set; }

    public string Value { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid? UpdaterID { get; set; }
}
