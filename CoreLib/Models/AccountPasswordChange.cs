using ReTo.Abstractions.Models;
using System.Net;

namespace CoreLib.Models;

internal class AccountPasswordChange : Model, IAccountPasswordChange
{
    public Guid AccountID { get; set; }

    public DateTime ChangeTime { get; } = DateTime.UtcNow;

    public string OriginalPassword { get; set; }

    public IPAddress ClientIP { get; set; }

    public string UserAgent { get; set; }
}
