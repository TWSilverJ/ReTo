using ReTo.Abstractions.Models;
using System.Net;

namespace ReTo.DataAccess.Dtos;

internal class AccountPasswordChangeDto : IAccountPasswordChange
{
    public int SequentialID { get; set; }

    public Guid ID { get; set; }

    public Guid AccountID { get; set; }

    public DateTime ChangeTime { get; set; }

    public string OriginalPassword { get; set; }

    public IPAddress ClientIP { get; set; }

    public string UserAgent { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
