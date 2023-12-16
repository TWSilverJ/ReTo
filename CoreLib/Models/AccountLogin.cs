using ReTo.Abstractions.Models;
using System.Net;

namespace CoreLib.Models;

internal class AccountLogin : Model, IAccountLogin
{
    public Guid? AccountID { get; set; }

    public DateTime LoginTime { get; } = DateTime.UtcNow;

    public IPAddress ClientIP { get; set; }

    public string UserAgent { get; set; }

    public bool IsSuccessful { get; set; } = false;

    public bool IsRevoked { get; set; } = false;

    public DateTime? ExpireAt { get; set; }
}
